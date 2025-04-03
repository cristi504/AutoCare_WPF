
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using Autocare_WPF.data_access;
using Autocare_WPF.domain;
using Autocare_WPF.domain.documents;
using System.Diagnostics;
using Microsoft.Win32;

namespace Autocare_WPF
{
    public partial class Documente : Window
    {
        private string currentUsername;
        private int currentUserID= DataAccess.Instance.CurrentUserID;

        public Documente(string username)
        {
            InitializeComponent();
            currentUsername = DataAccess.Instance.CurrentUsername;
            myheader.Username = currentUsername;
            //adddocument.Visibility = Visibility.Hidden;

            if (string.IsNullOrEmpty(currentUsername))
            {
                MessageBox.Show("Username cannot be null or empty.");
                return;
            }


            if (currentUserID > 0)
            {
                LoadDocuments();
            }
            else
            {
                MessageBox.Show("Unable to find user ID. Make sure the user exists.");
            }
        }

       

        private void LoadDocuments()
        {
            var documents = DataAccess.DocumentsRetreive(currentUserID);
            foreach (var document in documents)
            {
                document.Photo = DataAccess.GetDocumentPhoto(document.documentID);  // Load the photo here
            }
            if (documents.Count == 0 )
            {
               
                MessageBox.Show("No documents found for this user.");
            }
            else
            {
                DocumentListView.ItemsSource = documents;
                
            }
        }
        private void DocumentListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Check if a document is selected
            if (DocumentListView.SelectedItem != null)
            {
                
                deletedocument.Visibility = Visibility.Visible;
                update.Visibility = Visibility.Visible;
            }
            else
            {
                
                deletedocument.Visibility = Visibility.Hidden;
                update.Visibility=Visibility.Hidden;
            }
        }


        private void OpenUpdateWindow_Click(object sender, RoutedEventArgs e)
        {
            if (DocumentListView.SelectedItem == null)
            {
                MessageBox.Show("Please select a document to update.");
                return;
            }

            var  retrievedDocument = DocumentListView.SelectedItem as RetrievedDocument;
            if (retrievedDocument == null)
            {
                MessageBox.Show("Error retrieving selected document.");
                return;
            }

            int documentID = retrievedDocument.documentID;
            string type = retrievedDocument.Type;
            string series = retrievedDocument.Series;
            DateTime issueDate = retrievedDocument.IssueDate; 
            DateTime expiryDate = retrievedDocument.ExpiryDate;

            UpdateDocumentWindow updateWindow = new UpdateDocumentWindow(documentID, type, series, issueDate, expiryDate);
            updateWindow.Left = this.Left + (this.Width - updateWindow.Width) / 2;
            updateWindow.Top = this.Top + (this.Height - updateWindow.Height) / 2;
            updateWindow.ShowDialog();

            LoadDocuments();
        }

        private void adddocument_Click(object sender, RoutedEventArgs e)
        {
            AddDocumentxaml addDocumentWindow = new AddDocumentxaml(currentUserID);
            addDocumentWindow.Left = this.Left + (this.Width - addDocumentWindow.Width) / 2;
            addDocumentWindow.Top = this.Top + (this.Height - addDocumentWindow.Height) / 2;
            addDocumentWindow.ShowDialog();
            LoadDocuments();
        }
        private void deletedocument_Click(object sender, RoutedEventArgs e)
        {
            if (DocumentListView.SelectedItem == null)
            {
                MessageBox.Show("Please select a document to delete.");
                return;
            }

            var retrievedDocument = DocumentListView.SelectedItem as RetrievedDocument;
            if (retrievedDocument == null)
            {
                MessageBox.Show("Error retrieving selected document.");
                return;
            }

            // Ask for confirmation before deleting
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this document?", "Delete Document", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                // Call DataAccess to delete the document from the database
                bool success = DataAccess.DeleteDocument(retrievedDocument.documentID);
                if (success)
                {
                    MessageBox.Show("Document deleted successfully.");
                    LoadDocuments(); // Reload the documents
                }
                else
                {
                    MessageBox.Show("Error deleting document. Please try again.");
                }
            }
        }
        private void SeePhotoButton_Click(object sender, RoutedEventArgs e)
        {
            // Ensure a document is selected
            if (DocumentListView.SelectedItem == null)
            {
                MessageBox.Show("Please select a document to view.");
                return;
            }

            // Get the selected document
            var retrievedDocument = DocumentListView.SelectedItem as RetrievedDocument;
            if (retrievedDocument == null)
            {
                MessageBox.Show("Error retrieving selected document.");
                return;
            }

            // Get the image byte array from the database
            byte[] imageBytes = DataAccess.GetDocumentPhoto(retrievedDocument.documentID);
            //SaveImageToFile(imageBytes);

            // Check if the byte array is null or empty
            if (imageBytes == null || imageBytes.Length == 0)
            {
                MessageBox.Show("No photo found for this document.");
                return;
            }

            // Try to display the image
            try
            {
                // Convert byte array to an ImageSource
                ImageSource imgSource = GetImageFromByteArray(imageBytes);

                if (imgSource == null)
                {
                    MessageBox.Show("Error displaying image.");
                    return;
                }

                // Create an Image control and set its source to the image
                Image imageControl = new Image();
                imageControl.Source = imgSource;

                // Show the image in a new window
                Window imageWindow = new Window
                {
                    Title = "Document Photo",
                    Content = imageControl,
                    Width = 800,
                    Height = 600
                };
                imageWindow.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the image: {ex.Message}");
            }
        }

        private ImageSource GetImageFromByteArray(byte[] imageBytes)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    BitmapImage image = new BitmapImage();
                    image.BeginInit();
                    image.StreamSource = ms;
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.EndInit();
                    image.Freeze(); // Ensure thread safety
                    return image;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}");
                return null;
            }
        }
        





    }
}

