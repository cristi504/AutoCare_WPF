using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.OleDb;
using Autocare_WPF.data_access;

namespace Autocare_WPF
{
    
    public partial class MainWindow : Window
    {
       
      
        private string currentUsername= DataAccess.Instance.CurrentUsername;
      

        public MainWindow()
        {

            InitializeComponent();

            myheader.Username = currentUsername;
            
            

        }
        private void btnStatus_Click(object sender, RoutedEventArgs e)
        {
            
            StatusGeneral newWindow = new StatusGeneral(currentUsername);
            newWindow.Left= this.Left+(this.Width-newWindow.Width)/2;
            newWindow.Top= this.Top+(this.Height-newWindow.Height)/2;
            newWindow.Show();

            
        }
        private void btnIntervale_Click(object sender, RoutedEventArgs e)
        {
            IntervaleService intervaleService = new IntervaleService(currentUsername);
            intervaleService.Left = this.Left + (this.Width-intervaleService.Width)/2;
            intervaleService.Top = this.Top + (this.Height-intervaleService.Height)/2;
            intervaleService.Show();
        }

        private void btnDocumente_Click(object sender, RoutedEventArgs e)
        {
            Documente documente = new Documente(currentUsername);
            documente.Left = this.Left + (this.Width - documente.Width)/2;
            documente.Top = this.Top + (this.Height-documente.Height) /2;
            documente.Show();   
           

        }

        private void btnProblem_Click(object sender, RoutedEventArgs e)
        {
            DoyouhaveaProblem problem = new DoyouhaveaProblem(currentUsername);
            problem.Left = this.Left + (this.Width-problem.Width) /2;
            problem.Top = this.Top + (this.Height - problem.Height) / 2 ; 
            problem.Show();
        }

        private void btntest_Click(object sender, RoutedEventArgs e)
        {
            testwindow testwindow = new testwindow();
            testwindow.Show();
           

        }

        private void Buttonlogout_Click(object sender, RoutedEventArgs e)
        {
            Window2 window2 = new Window2();    
            foreach (Window window in Application.Current.Windows)
            {
                if (window != window2) 
                {
                    window2.Left = this.Left + (this.Width - window2.Width) / 2;
                    window2.Top = this.Top + (this.Height - window2.Height) / 2;
                    window2.Show();
                    window.Close();
                }

            }
        }
       

        private void btnMartori_Click(object sender, RoutedEventArgs e)
        {
            CarConnect obd = new CarConnect();
            obd.Left = this.Left + (this.Width - obd.Width); 
            obd.Top = this.Top + (this.Height - obd.Height);
            obd.Show();
        }
    }
}