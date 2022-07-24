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
        public CatagoriesControl()
        {
            InitializeComponent();
        }

        private void countTextbox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            countTextbox.IsReadOnly = false;
            countTextbox.Background = Brushes.Red;
        }

        private void countTextbox_MouseLeave(object sender, MouseEventArgs e)
        {
            countTextbox.IsReadOnly = true;
            countTextbox.Background = Brushes.White;
        }

        private void catagoryLabel_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ChangeTextDialog setDialog = new ChangeTextDialog();
            setDialog.ShowDialog();
            catagoryLabel.Content = setDialog.NewName;
            //https://stackoverflow.com/questions/2796470/wpf-create-a-dialog-prompt
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            (Parent as StackPanel).Children.Remove(this);
            //https://social.msdn.microsoft.com/Forums/vstudio/en-US/5d0f24ce-9ced-4c3d-af83-3c55ea961d1e/close-a-wpf-user-control?forum=wpf    // Can't beleive this worked first try...
        }
    }
}
