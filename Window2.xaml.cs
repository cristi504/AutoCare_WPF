using System.Data.OleDb;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Media.Animation;
using Autocare_WPF.data_access;
using Autocare_WPF.domain.user_validation;

namespace Autocare_WPF
{
    public partial class Window2 : Window
    {
        public Window2()
        {
            
            InitializeComponent();
            this.WindowStartupLocation=WindowStartupLocation.CenterScreen;
        }
        
        private void OpenPopupUp(object sender, RoutedEventArgs e)
        {
            SignUpPopupUp.IsOpen = true;
        }
        private void OpenPopupIn(object sender, RoutedEventArgs e)
        {
            SignInPopupIn.IsOpen = true;
        }
        private void SubmitSignUp(object sender, RoutedEventArgs e)
        {
            string username = UsernameUp.Text;
            string password = PasswordHashUp.Password;
            string email = emailUp.Text;
            string firstName = FirstNameUp.Text;
            string lastName = LastNameUp.Text;

            Signup newUser = new Signup(firstName, lastName, password, email, username);

            if (DataAccess.Instance.SignUp(newUser))
            {
                MessageBox.Show("Sign up successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Error signing up. Try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SubmitSignIn(object sender, RoutedEventArgs e)
        {
            string username = userni.Text.Trim();
            string password = pass.Password;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Login user = new Login(username, password); 

            if (DataAccess.Instance.LogIn(user)) 
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                // Open the main window
                MainWindow mainWindow = new MainWindow();
                mainWindow.Left = this.Left + (this.Width - mainWindow.Width) / 2;
                mainWindow.Top = this.Top + (this.Height - mainWindow.Height) / 2;
                mainWindow.Show();

                this.Close(); // Close login window
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


    }
}
