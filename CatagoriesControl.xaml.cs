using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Counter_Wpf
{
    /// <summary>
    /// Interaction logic for CatagoriesControl.xaml
    /// </summary>
    public partial class CatagoriesControl : UserControl
    {
        public MainWindow MainWindow = new MainWindow();

        public CatagoriesControl()
        {
            InitializeComponent();
        }

        private void countTextbox_MouseDoubleClick(object sender, MouseButtonEventArgs e) // Change count manually
        {
            countTextbox.IsReadOnly = false;
            countTextbox.Background = Brushes.Red;
        }

        private void countTextbox_MouseLeave(object sender, MouseEventArgs e) // After changing count manually
        {
            countTextbox.IsReadOnly = true;
            countTextbox.Background = Brushes.White;
            CountChangedManually();
        }

        private void catagoryLabel_MouseDoubleClick(object sender, MouseButtonEventArgs e) // Change catagory name
        {
            ChangeTextDialog setDialog = new ChangeTextDialog();
            setDialog.ShowDialog();
            catagoryLabel.Content = setDialog.NewName;
            //https://stackoverflow.com/questions/2796470/wpf-create-a-dialog-prompt
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e) // Delete catagory
        {
            (Parent as StackPanel).Children.Remove(this);
            //https://social.msdn.microsoft.com/Forums/vstudio/en-US/5d0f24ce-9ced-4c3d-af83-3c55ea961d1e/close-a-wpf-user-control?forum=wpf    // Can't beleive this worked first try...
        }

        public Catagories CatagoryAdded(int index, string name, int count, string color, List<Point> locations, bool active)
        {
            var newObjectToAdd = new Catagories(index, name, count, locations, color, active);
            return newObjectToAdd;
        }

        public void RestyleControl(Catagories currentObject)
        {
            catagoryLabel.Content = currentObject.Name;
            countTextbox.Text = currentObject.Count.ToString();
        }


        public byte[] RandomColor()
        {

            var rnd = new Random();
            int number = rnd.Next(5);

            switch (number)
            {
                case 0:
                    byte[] color0 = { 0, 163, 44 }; // Green
                    return color0;

                case 1:
                    byte[] color1 = { 0, 11, 163 }; // Blue
                    return color1;

                case 2:
                    byte[] color2 = { 163, 0, 0 }; // Red
                    return color2;

                case 3:
                    byte[] color3 = { 163, 0, 158 }; // Purple
                    return color3;

                case 4:
                    byte[] color4 = { 209, 125, 23 }; // Orange
                    return color4;

                default:
                    byte[] color5 = { 0, 0, 0 };
                    return color5;
            }

        }

        private void catagoryRect_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)    // Set active catagory and change colors
        {
            // Set all backgrounds the same
            SolidColorBrush noBackground = new SolidColorBrush(Colors.Transparent);
            Parent.SetValue(BackgroundProperty, noBackground);
            foreach (var child in (Parent as StackPanel).Children.OfType<CatagoriesControl>())  // Changed object to var and added OfType stuff. Now it works
            {
                child.Background = noBackground;
            }
           
            // Set only one background to highlighted
            this.Background = new SolidColorBrush(Colors.Red);

            // Set all objects to inactive except hightlighted
            MainWindow.SelectedCatagoryChange(this.Name.ToString());    // Send which catagory is active to the main window to change object
        }

        /// <summary>
        /// Set which catagory is hightlighted
        /// </summary>
        /// <param name="catagoryControlToHighlightName">Name of catagory to hightlight</param>
        public void HighlightCatagory(string catagoryControlToHighlightName)
        {
            // Set all backgrounds the same
            SolidColorBrush noBackground = new SolidColorBrush(Colors.Transparent);
            //Parent.SetValue(BackgroundProperty, noBackground);
            foreach (var child in (Parent as StackPanel).Children.OfType<CatagoriesControl>())  // Changed object to var and added OfType stuff. Now it works
            {
                if (child.Name != catagoryControlToHighlightName)
                {
                    child.Background = noBackground;
                }
                else
                {
                    child.Background = new SolidColorBrush(Colors.Red);
                }

            }

        }


        // Random name for object/control reference
        private static Random random = new Random();
        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void CountChangedManually()
        {
            if (int.TryParse(countTextbox.Text, out int count)) // See if textbox only contains numbers
            {
                //MainWindow.CountChanged(count);
                MainWindow.SelectedCatagoryChange("");
            }
            else
            {
                MessageBox.Show("Please enter a number", "Entry not a number");
            }
        }



    }
}
