using System;
using System.Configuration;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input.StylusPlugIns;
using Newtonsoft.Json.Serialization;
using OBD.NET.Communication;
using OBD.NET.DataTypes;
using OBD.NET.Devices;
using OBD.NET.Events;
using OBD.NET.Logging;
using OBD.NET.OBDData;

namespace Autocare_WPF
{
    public partial class CarConnect : Window
    {
        private SerialConnection connection;
        private ELM327 dev;

        public CarConnect()
        {
            InitializeComponent();
            LoadAvailablePorts();
        }

        private void LoadAvailablePorts()
        {
            string[] ports = System.IO.Ports.SerialPort.GetPortNames();
            foreach (var port in ports)
            {
                PortComboBox.Items.Add(port);
            }

            if (ports.Length > 0)
                PortComboBox.SelectedIndex = 0;
            else
                MessageBox.Show("No COM ports detected. Ensure your device is properly connected.");
        }

        private async void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            string selectedPort = PortComboBox.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedPort))
            {
                MessageBox.Show("Please select a COM port.");
                return;
            }

            try
            {
                connection = new SerialConnection(selectedPort);
                dev = new ELM327(connection, new OBDConsoleLogger(OBDLogLevel.Debug));
                await Task.Run(() => dev.Initialize()); 
                MessageBox.Show("Connected to ELM327 and ready!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting to ELM327: {ex.Message}");
            }
        }

        private async void FetchDataButton_Click(object sender, RoutedEventArgs e)
        {
            if (dev == null)
            {
                MessageBox.Show("Please connect to the ELM327 adapter first.");
                return;
            }

            dev.SubscribeDataReceived<EngineRPM>((_, data) =>
            {
                Dispatcher.Invoke(() => EngineRPMText.Text = $"{data.Data.Rpm} RPM");
            });

            // Subscribe to Engine Coolant Temperature
            dev.SubscribeDataReceived<EngineCoolantTemperature>((_, data) =>
            {
                Dispatcher.Invoke(() => EngineCoolantTempText.Text = $"{data.Data.Temperature} °C");
            });

            // Subscribe to Vehicle Speed
            dev.SubscribeDataReceived<VehicleSpeed>((_, data) =>
            {
                Dispatcher.Invoke(() => VehicleSpeedText.Text = $"{data.Data.Speed} km/h");
            });

            // Subscribe to Fuel Level
            dev.SubscribeDataReceived<EngineFuelRate>((_, data) =>
            {
                Dispatcher.Invoke(() => FuelLevelText.Text = $"{data.Data.FuelRate}%");
               
            });

            // Subscribe to Intake Air Temperature
            dev.SubscribeDataReceived<IntakeAirTemperature>((_, data) =>
            {
                Dispatcher.Invoke(() => IntakeAirTempText.Text = $"{data.Data.Temperature} °C");
            });

            // Subscribe to Throttle Position
            dev.SubscribeDataReceived<ThrottlePosition>((_, data) =>
            {
                Dispatcher.Invoke(() => ThrottlePositionText.Text = $"{data.Data.Position}%");
            });

            // Subscribe to Engine Load
            dev.SubscribeDataReceived<CalculatedEngineLoad>((_, data) =>
            {
                Dispatcher.Invoke(() => EngineLoadText.Text = $"{data.Data.Load}%");
            });

            // Subscribe to Timing Advance
            dev.SubscribeDataReceived<TimingAdvance>((_, data) =>
            {
                Dispatcher.Invoke(() => TimingAdvanceText.Text = $"{data.Data.Timing}°");
            });

            // Subscribe to Mass Air Flow (MAF) Rate
            dev.SubscribeDataReceived<MAFAirFlowRate>((_, data) =>
            {
                Dispatcher.Invoke(() => MAFRateText.Text = $"{data.Data.Rate} g/s");
               // MessageBox.Show($"Raw MAF Data: {data.Data}");
            });

            await Task.Run(() =>
            {
                while (true)
                {
                    dev.RequestData<EngineRPM>();
                    dev.RequestData<EngineCoolantTemperature>();
                    dev.RequestData<VehicleSpeed>();
                    dev.RequestData<EngineFuelRate>();
                    dev.RequestData<IntakeAirTemperature>();
                    dev.RequestData<ThrottlePosition>();
                    dev.RequestData<CalculatedEngineLoad>();
                    dev.RequestData<TimingAdvance>();
                    dev.RequestData<MAFAirFlowRate>();
                    Task.Delay(1000).Wait();
                }
            });
        }
        private async void ReadDTCButton_Click(object sender, RoutedEventArgs e)
        {
            if (dev == null)
            {
                MessageBox.Show("Please connect to the ELM327 adapter first.");
                return;
            }

            try
            {
                // Clear previous DTCs
                DTCText.Items.Clear();

                dev.SubscribeDataReceived<IOBDData>((sender, eventArgs) =>
                {
                    Dispatcher.Invoke(() =>
                    {
                        // Extract actual data from eventArgs
                        var data = eventArgs.Data;

                        Debug.WriteLine($"Received Data Type: {data.GetType().FullName}");
                       // MessageBox.Show($"Received Data Type: {data.GetType().FullName}");

                        if (data is IOBDData obdData)
                        {
                            Debug.WriteLine($"OBD Data Content: {Newtonsoft.Json.JsonConvert.SerializeObject(obdData)}");

                            // Try extracting a property that holds the raw response
                            var properties = obdData.GetType().GetProperties();
                            foreach (var prop in properties)
                            {
                                Debug.WriteLine($"Property: {prop.Name}, Value: {prop.GetValue(obdData)}");
                            }

                            // If there is a payload in byte[] format, use it for DTC parsing
                            byte[] rawData = null;
                            var payloadProp = properties.FirstOrDefault(p => p.PropertyType == typeof(byte[]));
                            if (payloadProp != null)
                            {
                                rawData = payloadProp.GetValue(obdData) as byte[];
                                Debug.WriteLine($"Extracted Raw Data: {BitConverter.ToString(rawData ?? new byte[0])}");
                            }

                            if (rawData != null && rawData.Length > 0)
                            {
                                List<string> dtcCodes = ParseDTCs(rawData);
                                DTCText.Items.Clear();

                                if (dtcCodes.Count > 0)
                                {
                                    foreach (var dtc in dtcCodes)
                                    {
                                        DTCText.Items.Add(dtc);
                                    }
                                }
                                else
                                {
                                    DTCText.Items.Add("No error codes found.");
                                }
                            }
                        }
                        else
                        {
                            Debug.WriteLine("Received an unexpected data type.");
                        }
                    });
                });

                // Send the OBD command to request DTCs (Mode 03)
                byte mode = 0x03;
                await dev.RequestDataAsync(mode);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading DTCs: {ex.Message}");
            }
        }
      


        private string DecodeDTC(int firstByte, int secondByte)
        {
            string[] dtcPrefixes = { "P", "C", "B", "U" };
            int category = (firstByte & 0xC0) >> 6;
            string dtc = dtcPrefixes[category];

            dtc += ((firstByte & 0x3F)).ToString("X2"); // Remaining bits of first byte
            dtc += secondByte.ToString("X2"); // Second byte

            return dtc;
        }
        private List<string> ParseDTCs(byte[] rawData)
        {
            List<string> dtcList = new List<string>();

            if (rawData.Length < 3) return dtcList; // No DTCs present

            for (int i = 1; i < rawData.Length; i += 2) // Skip mode byte (first byte)
            {
                if (i + 1 >= rawData.Length) break;

                int firstByte = rawData[i];
                int secondByte = rawData[i + 1];

                if (firstByte == 0 && secondByte == 0) continue; // No more DTCs

                string dtc = DecodeDTC(firstByte, secondByte);
                dtcList.Add(dtc);
            }

            return dtcList;
        }



    }
}
