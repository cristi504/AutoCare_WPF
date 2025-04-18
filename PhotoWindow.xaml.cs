﻿using System;
using System.Collections.Generic;
using System.IO;
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

namespace Autocare_WPF
{
  
    public partial class PhotoWindow : Window
    {
        public PhotoWindow(byte[] photoData)
        {
        
            InitializeComponent();
            if (photoData != null)
            {
                using (MemoryStream ms = new MemoryStream(photoData))
                {
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.StreamSource = ms;
                    bitmap.EndInit();
                    photoImage.Source = bitmap;
                }
            }
            else
            {
                MessageBox.Show("No photo data available.");
            }
        }
    }
}
