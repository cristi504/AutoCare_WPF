
using System;
using System.Data.OleDb;
using System.Windows;
using System.Windows.Controls;
using Autocare_WPF.data_access;
using Autocare_WPF.domain.documents;
using Microsoft.Win32;


namespace Autocare_WPF
{
    public partial class AddDocumentxaml : Window
    {
        private readonly int userId;
        

        public AddDocumentxaml(int currentUserId)
        {
            InitializeComponent();
            userId = currentUserId;

            // Restrict date selection (Issue Date cannot be in the future, Expiry Date must be after today)
            IssueDatePicker.DisplayDateEnd = DateTime.Today;
            ExpiryDatePicker.DisplayDateStart = DateTime.Today;
        }
        private int lastInsertedDocumentID = -1;
        private void AddDocumentButton_Click(object sender, RoutedEventArgs e)
        {
            string documentType = (DocumentTypeComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            string series = SeriesTextBox.Text;
            DateTime? issueDate = IssueDatePicker.SelectedDate;
            DateTime? expiryDate = ExpiryDatePicker.SelectedDate;

            if (string.IsNullOrEmpty(documentType) || string.IsNullOrEmpty(series) || issueDate == null || expiryDate == null)
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            // Store the document and get the new ID
            lastInsertedDocumentID = DataAccess.storeDocument(new StoreDocument(userId, documentType, series, (DateTime)issueDate, (DateTime)expiryDate));
            if (lastInsertedDocumentID != -1)
            {
                MessageBox.Show("Document added successfully!");
            }
            else
            {
                MessageBox.Show("Error: Document could not be added.");
            }

        }
        private void UploadPhotoButton_Click(object sender, RoutedEventArgs e)
        {
            if (lastInsertedDocumentID == -1)
            {
                MessageBox.Show("Please add a document before uploading a photo.");
                return;
            }

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string imagePath = openFileDialog.FileName;
                DataAccess.SaveDocumentPhoto(lastInsertedDocumentID, imagePath);
                MessageBox.Show("Photo uploaded successfully!");
            }
        }



    }
}
