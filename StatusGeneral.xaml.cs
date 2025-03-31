using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
using System.Xml;
using Autocare_WPF.data_access;
using Autocare_WPF.domain.cars;


namespace Autocare_WPF
{
    public partial class StatusGeneral : Window
    {
        private string currentUsername = string.Empty;
        int currentUserID =DataAccess.Instance.CurrentUserID;
        public StatusGeneral(string username)
        {
            InitializeComponent();
            currentUsername = DataAccess.Instance.CurrentUsername;  
            myheader.Username = currentUsername;
        }       
        private void LoadCarDetails()
        {
            CarListView.Items.Clear();
            DataAccess carDataAccess = new DataAccess();
            List<mycars> cars = carDataAccess.GetCarDetails(currentUserID);

            if (cars.Count > 0)
            {
                foreach (var car in cars)
                {
                    CarListView.Items.Add(car);
                }
            }
            else
            {
                MessageBox.Show("No car details found for this user.");
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCarDetails();
        }
        private void OpenAddCarWindow(object sender, RoutedEventArgs e)
        {
            AddCar addCarWindow = new AddCar(currentUsername);
            addCarWindow.Left = this.Left + (this.Width - addCarWindow.Width) / 2;
            addCarWindow.Top = this.Top + (this.Height - addCarWindow.Height) / 2;
            addCarWindow.Show();
        }
        private void DeleteCarButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the CarID from the button's Tag
            Button deleteButton = sender as Button;

            if (deleteButton != null && deleteButton.Tag != null)
            {
                int carId = Convert.ToInt32(deleteButton.Tag);

                DataAccess carDataAccess = new DataAccess();
                bool isDeleted = carDataAccess.DeleteCar(carId);

                //or:

                //bool isDeleted = DataAccess.Instance.DeleteCar(carId);

                if (isDeleted)
                {
                    MessageBox.Show("Car deleted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadCarDetails(); // Refresh ListView
                }
            }
            else
            {
                MessageBox.Show("CarID not found.");
            }
        }


    }
}
