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
using System.Windows.Shapes;

namespace Counter_Wpf
{
    /// <summary>
    /// Interaction logic for ChangeTextDialog.xaml
    /// </summary>
    public partial class ChangeTextDialog : Window
    {

        private SolidColorBrush highlightedBrush = new SolidColorBrush(Colors.Aqua);
        private int highlightThickness = 3;

        public ChangeTextDialog()
        {
            InitializeComponent();
            newNameTextBox.Focus();
        }

        public string NewName { get; set; }
        public string SelectedColor { get; set; } = "#FFFFFFFF"; // Give default color (white) in case user doesn't select one




        private void setButton_Click(object sender, RoutedEventArgs e)
        {
            if (newNameTextBox.Text != "")  // If new name is typed in textbox
            {
                string userInput = newNameTextBox.Text.ToString();
                userInput = userInput.Replace("\n", "").Replace("\r", "").Replace(" ", "");  // Clean user input (Don't trust the stupid users)
                NewName = userInput;
                Close();
            }
            else
            {
                MessageBox.Show("Please type a name", "No Name Selected");
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e) // User cancels rename
        {
            Close();
        }

        private void redCircle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SelectedColor = redCircle.Fill.ToString();
            SetCircleBackgrounds();
            redCircle.Stroke = highlightedBrush;
            redCircle.StrokeThickness = highlightThickness;
        }

        private void greenCircle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SelectedColor = greenCircle.Fill.ToString();
            SetCircleBackgrounds();
            greenCircle.Stroke = highlightedBrush;
            greenCircle.StrokeThickness = highlightThickness;
        }

        private void blueCircle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SelectedColor = blueCircle.Fill.ToString();
            SetCircleBackgrounds();
            blueCircle.Stroke = highlightedBrush;
            blueCircle.StrokeThickness = highlightThickness;
        }

        private void blackCircle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SelectedColor = blackCircle.Fill.ToString();
            SetCircleBackgrounds();
            blackCircle.Stroke = highlightedBrush;
            blackCircle.StrokeThickness = highlightThickness;
        }

        private void whiteCircle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SelectedColor = whiteCircle.Fill.ToString();
            SetCircleBackgrounds();
            whiteCircle.Stroke = highlightedBrush;
            whiteCircle.StrokeThickness = highlightThickness;
        }

        private void orangeCircle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SelectedColor = orangeCircle.Fill.ToString();
            SetCircleBackgrounds();
            orangeCircle.Stroke = highlightedBrush;
            orangeCircle.StrokeThickness = highlightThickness;
        }

        /// <summary>
        /// Set all circle backgrounds to none so selected circle can be highlighted
        /// </summary>
        private void SetCircleBackgrounds()
        {
            SolidColorBrush black = new SolidColorBrush(Colors.Black);

            redCircle.StrokeThickness = 1;
            redCircle.Stroke = black;

            greenCircle.StrokeThickness = 1;
            greenCircle.Stroke = black;

            blueCircle.StrokeThickness = 1;
            blueCircle.Stroke = black;

            blackCircle.StrokeThickness = 1;
            blackCircle.Stroke = black;

            whiteCircle.StrokeThickness = 1;
            whiteCircle.Stroke = black;

            orangeCircle.StrokeThickness = 1;
            orangeCircle.Stroke = black;
        }


    }


}
