
using System;
using System.Data.OleDb;
using System.Windows;
using System.Windows.Controls;
using Autocare_WPF.data_access;
using Autocare_WPF.domain.documents;
using Microsoft.Win32;

namespace Autocare_WPF
{
    public partial class UpdateDocumentWindow : Window
    {
       
        private readonly int documentId;
        private string newPhotoPath = null;

        public UpdateDocumentWindow(int documentId, string documentType, string series, DateTime issueDate, DateTime expiryDate)
        {
            InitializeComponent();
            this.documentId = documentId;

            // Populate controls with existing values
            DocumentTypeComboBox.Text = documentType;
            SeriesTextBox.Text = series;
            IssueDatePicker.SelectedDate = issueDate;
            ExpiryDatePicker.SelectedDate = expiryDate;

            // Restrict date selection
            IssueDatePicker.DisplayDateEnd = DateTime.Today;
            ExpiryDatePicker.DisplayDateStart = DateTime.Today;
        }

        
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve updated values
            string documentType = (DocumentTypeComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            string series = SeriesTextBox.Text;
            DateTime? issueDate = IssueDatePicker.SelectedDate;
            DateTime? expiryDate = ExpiryDatePicker.SelectedDate;

            if (string.IsNullOrEmpty(documentType) || string.IsNullOrEmpty(series) || issueDate == null || expiryDate == null)
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            // Update document details
            DataAccess.UpdateDocument(new UpdateDocument(documentType, series, issueDate, expiryDate, documentId));

            // If there's a new photo, update it
            if (!string.IsNullOrEmpty(newPhotoPath))
            {
                 DataAccess.SaveDocumentPhoto(documentId, newPhotoPath);
            }
                MessageBox.Show("Document updated successfully!");
                this.Close();
          
        }
        private void UpdatePhotoButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                newPhotoPath = openFileDialog.FileName;
                MessageBox.Show("Photo selected. It will be updated when you save changes.");
            }
        }
    }
}


