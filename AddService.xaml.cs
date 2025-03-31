using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Autocare_WPF.data_access;
using Autocare_WPF.domain.Services;

namespace Autocare_WPF
{
    
    public partial class AddService : Window
    {

        private readonly int carId; // Car ID for which the service entry is added
        DataAccess serviceDataAccess = new DataAccess();

        public AddService(int selectedCarId)
        {
            InitializeComponent();
            carId = selectedCarId;
        }
        private void AddServiceButton_Click(object sender, RoutedEventArgs e)
        {
            int mileage;
            int price;
            string oil = OilTextBox.Text;
            string airFilter = AirFilterTextBox.Text;
            string fuelFilter = FuelFilterTextBox.Text;
            string oilFilter = OilFilterTextBox.Text;
            mileage = int.Parse(MileageTextBox.Text);
            price = int.Parse(PriceTextBox.Text);
            string interventions = OtherInterventionsTextBox.Text;

            //if (string.IsNullOrWhiteSpace(price) || string.IsNullOrWhiteSpace(mileage))
            //{
            //    MessageBox.Show("Please fill in all required fields", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            //    return;
            //}

            ServiceEntry serviceEntry = new ServiceEntry
            {
                CarID = carId,
                Oil = oil,
                AirFilter = airFilter,
                FuelFilter = fuelFilter,
                OilFilter = oilFilter,
                OtherInterventions = interventions,
                Mileage = mileage,
                Price = price
            };

            if (serviceDataAccess.AddServiceEntry(serviceEntry))
            {
                MessageBox.Show("Service entry added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
        }
    

    }
}

