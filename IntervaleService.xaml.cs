using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
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
using System.Globalization;
using Autocare_WPF.data_access;
using Autocare_WPF.domain.Services;

namespace Autocare_WPF
{
   
    public partial class IntervaleService : Window
    {
        private int currentCarID;
        int currentUserID;
        private string currentUsername = string.Empty;
        public IntervaleService(string username)
        {
            InitializeComponent();
            currentUsername = DataAccess.Instance.CurrentUsername;
            LoadUserData();
            myheader.Username = currentUsername;

        }
        private void LoadUserData()
        {
          
            currentUserID = DataAccess.Instance.CurrentUserID;
            LoadCars();  
        }
        

        private void LoadCars()
        {
            List<ServiceCar> carList = DataAccess.Instance.GetCarsForUser(currentUserID);

            if (carList.Count == 0)
            {
                MessageBox.Show("No cars found for the user.");
            }
            else
            {
                CarComboBox.ItemsSource = carList;
                CarComboBox.DisplayMemberPath = "Brand";  
                CarComboBox.SelectedValuePath = "CarID";  
            }
        }

        private void CarComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CarComboBox.SelectedItem is ServiceCar selectedCar)
            {
                LoadServiceIntervals(selectedCar.CarID);
            }
        }


        private void LoadServiceIntervals(int carID)
        {
            List<ServiceInterval> serviceList = DataAccess.Instance.GetServiceIntervalsForCar(carID);

            if (serviceList.Count == 0)
            {
                MessageBox.Show("No service intervals found for this car.");
                ServiceListView.ItemsSource = null;
            }
            else
            {
                ServiceListView.ItemsSource = serviceList;
            }
        }

        private void OpenAddServiceWindow(object sender, RoutedEventArgs e)
        {
            if (CarComboBox.SelectedValue != null)
            {
                int selectedCarId = Convert.ToInt32(CarComboBox.SelectedValue);
                AddService addServiceWindow = new AddService(selectedCarId);
                addServiceWindow.Left = this.Left + (this.Width - addServiceWindow.Width) / 2;
                addServiceWindow.Top = this.Top + (this.Height - addServiceWindow.Height) / 2;
                addServiceWindow.ShowDialog();
                LoadServiceIntervals(selectedCarId); 
            }
            else
            {
                MessageBox.Show("Please select a car first.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        


    }
}
