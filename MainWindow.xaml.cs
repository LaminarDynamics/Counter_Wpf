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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 


    public partial class MainWindow : Window
    {
        private double image_zoom = 1;

        private Point start;
        private Point canvas_translate_amount;
        private Point mouse_pos;


        private int index_of_catagories = 0;
        public static List<Catagories> listOfCatagoryObjects = new List<Catagories>();  // List of Catagory Objects
        public List<CatagoriesControl> listOfCatagoryControls = new List<CatagoriesControl>();  // List of Catagory Controls


        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnClosed(EventArgs e)   // Need this to make closing the program work right after CatagoriesControls added
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)    // Manual scaling for dynamic sizing (Hopefully)
        {
            // Get screen size to dynamically size components
            double screen_width = SystemParameters.PrimaryScreenWidth;
            double screen_height = SystemParameters.PrimaryScreenHeight;


            // Scale canvas
            double canvas_scale_width = .75;
            myCanvas.Width = screen_width * canvas_scale_width;

            // Sidebar scaling
            groupBox.Height = screen_height * .5;
            groupBox.Width = (screen_width - myCanvas.Width) * .97;

            // Slider scaling
            slider.Height = screen_height * .95;
            slider.Margin = new Thickness(myCanvas.Width - groupBox.Width, 0, 0, 0);

            // Scroller scaling
            scrollViewer.Height = screen_height * .5;

            // Bottom right grid scaling
            bottom_right_grid.Height = (screen_height - scrollViewer.Height) * .9;
            bottom_right_grid.Width = (screen_width - myCanvas.Width) * .97;

            // Scale Image to fit canvas
            image.Width = myCanvas.Width;
            image.Height = myCanvas.Height;
        }

        private void image_MouseWheel(object sender, MouseWheelEventArgs e) // Mousewheel Zoom
        {
            // Zoom controls
            double zoom_speed = .5;
            if (e.Delta > 0) // Zoom in 
            {
                image_zoom += zoom_speed;
            }
            if (e.Delta < 0 && image_zoom >= 1 + zoom_speed) // Zoom out (Only if already zoomed in)
            {
                image_zoom -= zoom_speed;
            }
            ChangeTranslationAndZoom();
            slider.Value = image_zoom;
        }

        private void ChangeTranslationAndZoom() // Translation/Zoom logic implementation
        {
            // Move image/canvas by translation/zoom amount
            Matrix translation = new Matrix();
            translation.Translate(canvas_translate_amount.X, canvas_translate_amount.Y);
            translation.Scale(image_zoom, image_zoom);
            myCanvas.RenderTransform = new MatrixTransform(translation);
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)   // Slider Controls
        {
            // Zoom slider
            image_zoom = slider.Value;
            ChangeTranslationAndZoom();
        }

        private void image_MouseMove_1(object sender, MouseEventArgs e) // Translation/Zoom logic
        {
            // Used with left click to slide image
            mouse_pos = e.MouseDevice.GetPosition(image);
            textBox.Text = mouse_pos.ToString();

            if (e.LeftButton == MouseButtonState.Pressed) // If moving while clicked
            {
                // Get mouse move distance
                double x_distance = start.X - mouse_pos.X;
                double y_distance = start.Y - mouse_pos.Y;

                // Canvas translation amount
                canvas_translate_amount.X += x_distance * -.1;
                canvas_translate_amount.Y += y_distance * -.1;

                // Move image by translation amount
                ChangeTranslationAndZoom();
            }
        }

        private void image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Important to get mouse start position for image translation to work
            start = e.MouseDevice.GetPosition(image);
            textBox.Text = "Start pos is: " + start.ToString();
        }

        // Center and unzoom photo
        private void centerButton_Click(object sender, RoutedEventArgs e)
        {
            canvas_translate_amount.X = 0;
            canvas_translate_amount.Y = 0;
            image_zoom = 1;
            ChangeTranslationAndZoom();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {


        }

        private void addCatButton_Click(object sender, RoutedEventArgs e)   // Add new REUSEABLE user control for catagories
        {
            // Get name of catagory from user 
            ChangeTextDialog setDialog = new ChangeTextDialog();
            setDialog.ShowDialog();

            string userText = setDialog.newNameTextBox.Text.ToString();
            char firstLetter = userText[0];
            // Check follows name convention (Not starting with number)
            bool validName = firstLetter.ToString().Any(x => char.IsLetter(x)); // Check if first character is a letter

            if (!string.IsNullOrWhiteSpace(userText) && validName)    // Only build crap if user gives a name
            {
                if (CheckIfNameDuplicate(userText) == false)    // Only continue if not already taken
                {
                    CatagoriesControl catagoriesControl1 = new CatagoriesControl();
                    string userGivenName = setDialog.NewName;
                    SolidColorBrush userSelectedColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString(setDialog.SelectedColor));

                    catagoriesControl1.colorCircle.Fill = userSelectedColor;
                    catagoriesControl1.Background = userSelectedColor;
                    catagoriesControl1.Name = userGivenName.ToString();

                    catagories.Children.Add(catagoriesControl1);    // Add to scrolller

                    var currentObject = catagoriesControl1.CatagoryAdded(index_of_catagories, userGivenName, 0, setDialog.SelectedColor, true);

                    listOfCatagoryObjects.Add(currentObject);   // Add to list of objects

                    catagoriesControl1.RestyleControl(currentObject);
                    index_of_catagories++;


                    SelectedCatagoryChange(catagoriesControl1.Name);    // Changes active object
                    catagoriesControl1.HighlightCatagory(catagoriesControl1.Name); // Changes active hightlighted component


                    // Add control to list
                    listOfCatagoryControls.Add(catagoriesControl1);
                }

                else  // If name already used
                {
                    MessageBox.Show("That name is already used. \nPlease try another", "Name Duplicate");
                }

            }

            else // Name is invalid
            {
                MessageBox.Show("That is not a valid name. Names must begin with a letter. \nPlease try again.", "Invalid Name");
            }

        }

        /// <summary>
        /// Checks if name is already taken in catagories
        /// </summary>
        /// <param name="desiredName">The name to check</param>
        /// <returns>bool true or fasle</returns>
        private bool CheckIfNameDuplicate(string desiredName)
        {
            bool duplicate = false;
            foreach (var myObject in listOfCatagoryObjects)
            {
                if (desiredName == myObject.Name)
                {
                    duplicate = true;
                }
            }
            return duplicate;
        }


        /// <summary>
        /// Set which object is active. Sets all to false if no catagory received
        /// </summary>
        /// <param name="receivedActiveCatagory">Name of object to activate</param>
        public void SelectedCatagoryChange(string receivedActiveCatagory)
        {
            // Find previous active catagory and set to inactive
            foreach (var currentCatagory in listOfCatagoryObjects)
            {
                if (currentCatagory.Name == receivedActiveCatagory)
                {
                    currentCatagory.Active = true;
                }

                else
                {
                    currentCatagory.Active = false;
                }
            }

            // Test
            foreach (var item in listOfCatagoryObjects)
            {
                Console.WriteLine("Change Detected");
                Console.WriteLine("Index: " + item.Index.ToString());
                Console.WriteLine("Name: " + item.Name);
                Console.WriteLine("Count: " + item.Count.ToString());
                Console.WriteLine("Color: " + item.Color);
                Console.WriteLine("Active: " + item.Active);
                Console.WriteLine("-------------------------------------");

            }
        }


        /// <summary>
        /// Draw on image where right clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void image_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {

            double x = e.GetPosition(myCanvas).X; //get mouse coordinates over canvas
            double y = e.GetPosition(myCanvas).Y;

            // Get color of currently active catagory
            Catagories activeCatagory = GetActiveCatagory();

            if (activeCatagory != null) // Only add points if catagory is selected
            {
                SolidColorBrush activeColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString(activeCatagory.Color));

                Ellipse marker = new Ellipse
                {
                    StrokeThickness = 3,
                    Stroke = activeColor, // Creates hollow circle. Fill instead of Stroke for fill
                    Margin = new Thickness(x - 10, y - 10, 0, 0), // Minus half of width/height to place centered
                    Width = 20,
                    Height = 20
                };
                myCanvas.Children.Add(marker);
                activeCatagory.Count++;

                CatagoriesControl currentControl = listOfCatagoryControls[activeCatagory.Index];    // Get index of active control
                currentControl.countTextbox.Text = activeCatagory.Count.ToString(); // Update active control
            }
            else
            {
                MessageBox.Show("Please select or add a catagory", "No catagory selected");
            }

        }



        /// <summary>
        /// Go through list of objects and return the active one
        /// </summary>
        /// <returns>The active catagory</returns>
        public Catagories GetActiveCatagory()
        {
            Catagories activeCatagory = null;
            foreach (var catagory in listOfCatagoryObjects)
            {
                if (catagory.Active == true)
                {
                    activeCatagory = catagory;
                }

            }
            return activeCatagory;
        }
    }
}