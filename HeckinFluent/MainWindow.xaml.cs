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

namespace HeckinFluent
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HeckinAcrylic.EnableCompositionBlur();
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            //Point mousePos = Mouse.GetPosition(Mouse.PrimaryDevice.DirectlyOver);
            Point mousePos = Mouse.GetPosition(Application.Current.MainWindow);
            double centeredPos = mousePos.X - (Application.Current.MainWindow.ActualWidth / 2);
            MouseText.Text = "Mouse is at: X = " + centeredPos.ToString();

            //Application.Current.MainWindow.

            
        }
    }
}
