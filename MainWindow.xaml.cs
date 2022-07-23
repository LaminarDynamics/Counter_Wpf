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
        private Point translate_amount;
        private Point mouse_pos;


        private int index_of_catagories = 0;
        private List<Catagories> ListOfCatagories = new List<Catagories>();

        public MainWindow()
        {
            InitializeComponent();

            var dialog = new InfoDialog();
            if (dialog.ShowDialog() == true)
            {
                MessageBox.Show("You said: " + dialog.ResponseText);
                //https://stackoverflow.com/questions/2796470/wpf-create-a-dialog-prompt
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Get screen size to dynamically size components
            double screen_width = SystemParameters.PrimaryScreenWidth;
            double screen_height = SystemParameters.PrimaryScreenHeight;

            // Scale of main photo
            double image_scale_width = .75;
            image.Width = screen_width * image_scale_width;

            // Sidebar scaling
            groupBox.Height = screen_height * .5;
            groupBox.Width = (screen_width - image.Width) * .97;

            // Add button scaling
            //add_listBox_button.Width = listBox.Width * .95;

            // Slider scaling
            slider.Height = screen_height * .95;
            slider.Margin = new Thickness(image.Width - groupBox.Width, 0, 0, 0);

            // Scroller scaling
            scrollViewer.Height = screen_height * .5;

            // Bottom right grid scaling
            bottom_right_grid.Height = (screen_height - scrollViewer.Height) * .9;
            bottom_right_grid.Width = (screen_width - image.Width) * .97;
        }

        private void image_MouseWheel(object sender, MouseWheelEventArgs e)
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

        private void ChangeTranslationAndZoom()
        {
            // Move image by translation amount
            Matrix X = new Matrix();
            X.Translate(translate_amount.X, translate_amount.Y);
            X.Scale(image_zoom, image_zoom);
            image.RenderTransform = new MatrixTransform(X);
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Zoom slider
            image_zoom = slider.Value;
            ChangeTranslationAndZoom();
        }

        private void image_MouseMove_1(object sender, MouseEventArgs e)
        {
            // Used with left click to slide image
            mouse_pos = e.MouseDevice.GetPosition(image);
            textBox.Text = mouse_pos.ToString();

            if (e.LeftButton == MouseButtonState.Pressed) // If moving while clicked
            {
                // Get mouse move distance
                double x_distance = start.X - mouse_pos.X;
                double y_distance = start.Y - mouse_pos.Y;

                // Append movement to translation amount
                translate_amount.X += x_distance * -.5;
                translate_amount.Y += y_distance * -.5;
                //textBox.Text = translate_amount.X.ToString() + "\n" + translate_amount.Y.ToString();

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


        private void add_listBox_button_Click(object sender, RoutedEventArgs e)
        {
            ListBoxItem listBoxItem = new ListBoxItem();

            //listBoxItem.Name = "listBoxItemNumber" + index_of_items;
            listBoxItem.HorizontalAlignment = HorizontalAlignment.Stretch;

        }


        // Center and unzoom photo
        private void centerButton_Click(object sender, RoutedEventArgs e)
        {
            translate_amount.X = 0;
            translate_amount.Y = 0;
            image_zoom = 1;
            ChangeTranslationAndZoom();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {


        }

        private void addCatButton_Click(object sender, RoutedEventArgs e)
        {

            index_of_catagories++;


            var catagoryStack = new StackPanel
            {
                Height = 70,
                Width = double.NaN, // Sets to auto
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(5, 2, 5, 5),
                Background = new SolidColorBrush(Color.FromArgb(100, 35, 94, 130)),
                Name = "catagory_" + index_of_catagories.ToString()
            };


            // Color Circle Stuff
            var rnd = new Random();
            byte red = byte.Parse(rnd.Next(255).ToString());
            byte green = byte.Parse(rnd.Next(255).ToString());
            byte blue = byte.Parse(rnd.Next(255).ToString());
            var circle = new Ellipse
            {
                Height = 50,
                Width = 50,
                Fill = new SolidColorBrush(Color.FromArgb(255, red, green, blue)),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Bottom,
                Margin = new Thickness(10, 10, 0, 0),
            };
            catagoryStack.Children.Add(circle);


            // Delete Button
            var delete_btn = new Button
            {
                Height = 50,
                Width = 50,
                Background = new SolidColorBrush(Colors.Red),
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(0, -50, 10, 0),
                Content = "X",
                Name = "delete_" + index_of_catagories.ToString(),
            };
            delete_btn.Click += Delete_btn_Click;



            catagoryStack.Children.Add(delete_btn);




            catagories.Children.Add(catagoryStack);



            //catagories.Children.Add(new Rectangle
            //{
            //    Name = rect_name,
            //    Height = 70,
            //    Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255)),
            //    Stroke = new SolidColorBrush(Colors.Black),
            //    Width = double.NaN, // Sets to auto
            //    HorizontalAlignment = HorizontalAlignment.Stretch,
            //    VerticalAlignment = VerticalAlignment.Top,
            //    Margin = new Thickness(5, 2, 5, 5),
            //    DataContext = index_of_catagories.ToString()
            //});

            //var tool = new StackPanel();
            //tool.Children.Add(new TextBlock() { Text = "mooooers" });

        }

        private void Delete_btn_Click(object sender, RoutedEventArgs e)
        {
            // Get index
            Button btn = (Button)sender;
            string ident = btn.Name;

            string[] ident_parts = ident.Split(char.Parse("_"));
            int index = int.Parse(ident_parts[1]);

            //catagories.Children.Remove(this);
            //Button btn = (Button)sender;
            //MessageBox.Show(btn.Name.ToString());

            catagories.Children.RemoveAt(index);
        }


    }
}