﻿using System;
using System.Collections.Generic;
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

namespace Counter_Wpf
{
    /// <summary>
    /// Interaction logic for ChangeTextDialog.xaml
    /// </summary>
    public partial class ChangeTextDialog : Window
    {
        public ChangeTextDialog()
        {
            InitializeComponent();
            newNameTextBox.Focus();
        }

        public string NewName { get; set; }

        private void setButton_Click(object sender, RoutedEventArgs e)
        {
            if (newNameTextBox.Text != "")  // If new name is typed in textbox
            {
                NewName = newNameTextBox.Text.ToString();
                Close();
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e) // User cancels rename
        {
            Close();
        }
    }
}
