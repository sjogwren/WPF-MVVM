using BOilerplate.Model;
using BOilerplate.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BOilerplate.View
{
    /// <summary>
    /// Interaction logic for Customers.xaml
    /// </summary>
    public partial class Customers : UserControl
    {
        public Customers()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Alert");
            var parentWindow = Window.GetWindow(this);
            if (parentWindow.GetType() == typeof(MainView))
            {
                (parentWindow as MainView).CustomerControl.Visibility = Visibility.Collapsed;
                (parentWindow as MainView).NewCustomerContentControl.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var code = button.Tag;
            MessageBox.Show(code.ToString());
        }
    }
}
