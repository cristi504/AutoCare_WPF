using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Autocare_WPF.Header
{
  
    public partial class Header : UserControl
    {
        
        public string Username;

        public Header()
        {
            InitializeComponent();
        }

        private void btnLogo_Click(object sender, RoutedEventArgs e)
        {

            if (Application.Current.Windows.OfType<MainWindow>().Any(window => window.IsActive))
            {
                MessageBox.Show("You are already in the Main Window!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            MainWindow mainWindow = new MainWindow();
            mainWindow.WindowStartupLocation = WindowStartupLocation.Manual; 
            mainWindow.Left = (SystemParameters.PrimaryScreenWidth - mainWindow.Width) / 2;
            mainWindow.Top = (SystemParameters.PrimaryScreenHeight - mainWindow.Height) / 2;

            foreach (Window window in Application.Current.Windows)
            {
                if (window != mainWindow) // Skip the new Main Page window
                {
                    
                    mainWindow.Show();
                    //mainWindow.SetUsername(Username);
                    window.Close();
                }
               
            }



        }
    }
}
    