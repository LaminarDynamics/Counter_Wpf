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
    public partial class MainWindow : Window
    {
        private double image_zoom = 1;

        private Point start;
        private Point canvas_translate_amount;
        private Point mouse_pos;


        private int index_of_catagories = 0;
        private List<Catagories> ListOfCatagories = new List<Catagories>();

        public MainWindow()
        {
            InitializeComponent();
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

            index_of_catagories++;

            CatagoriesControl catagoriesControl1 = new CatagoriesControl
            {
                //Width = 500
            };
            catagoriesControl1.colorCircle.Fill = new SolidColorBrush(Colors.Blue);
           
            catagories.Children.Add(catagoriesControl1);
    
        }

        private void image_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {

            double x = e.GetPosition(myCanvas).X; //get mouse coordinates over canvas
            double y = e.GetPosition(myCanvas).Y;

            Ellipse marker = new Ellipse
            {
                StrokeThickness = 3,
                Stroke = Brushes.Red, // Creates hollow circle. Fill instead of Stroke for fill
                Margin = new Thickness(x - 10, y - 10, 0, 0), // Minus half of width/height to place centered
                Width = 20,
                Height = 20
        };

            myCanvas.Children.Add(marker);
        }
    }
}