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
        public double TiltX
        {
            get; set;
        }

        public double SlideY
        {
            get; set;
        }

        public double SlideZ
        {
            get; set;
        }

        public double BGSlideX
        {
            get; set;
        }

        public double BGSlideZ
        {
            get; set;
        }

        public double SkyBGSlideX
        {
            get; set;
        }

        public double SkyBGSlideZ
        {
            get; set;
        }

        public double SkyBGTiltX
        {
            get; set;
        }
        

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
            Point mousePos = Mouse.GetPosition(HeckinMainWindow);
            double halfWindowWidth = (HeckinMainWindow.ActualWidth / 2);
            double halfWindowHeight = (HeckinMainWindow.ActualHeight / 2);
            double centeredPosX = mousePos.X - halfWindowWidth;
            double centerPosY = ((mousePos.Y) - (halfWindowHeight * 2));
            double centerPosZ = Math.Abs(mousePos.X - halfWindowWidth);

            double MaxTiltX = 20.0;
            double TiltFactorX = (halfWindowWidth / MaxTiltX);
            TiltX = -(centeredPosX / TiltFactorX);

            double MaxSlideY = 0.00;
            double SlideFactorY = (halfWindowHeight / MaxSlideY);
            SlideY = (centerPosY / SlideFactorY);

            double MaxSlideZ = 0.1;
            double SlideFactorZ = (halfWindowWidth / MaxSlideZ);
            SlideZ = (centerPosZ / SlideFactorZ);

            double BGMaxSlideX = 0.25;
            double BGSlideFactorX = (halfWindowWidth / BGMaxSlideX);
            BGSlideX = (centeredPosX / BGSlideFactorX);

            BGSlideZ = (centerPosZ / SlideFactorZ) * 1.5;

            double SkyBGMaxSlideX = 0.8;
            double SkyBGSlideFactorX = (halfWindowWidth / SkyBGMaxSlideX);
            SkyBGSlideX = (centeredPosX / SkyBGSlideFactorX);

            SkyBGSlideZ = (centerPosZ / SlideFactorZ) * 4;

            double SkyBGMaxTiltX = 20.0;
            double SkyBGTiltXFactor = (halfWindowWidth / SkyBGMaxTiltX);
            SkyBGTiltX = -(centeredPosX / SkyBGTiltXFactor);

            RotationX.Angle = TiltX;
            TransformY.OffsetY = SlideY;
            TransformZ.OffsetZ = SlideZ;

            BGRotationX.Angle = TiltX * 0.888;
            BGTransformX.OffsetX = BGSlideX;
            BGTransformY.OffsetY = 0.05;        
            BGTransformZ.OffsetZ = BGSlideZ - 0.5;

            SkyBGRotationX.Angle = SkyBGTiltX;
            SkyBGTransformX.OffsetX = SkyBGSlideX;
            SkyBGTransformZ.OffsetZ = SkyBGSlideZ - 2.0;

            MouseText.Text = "Mouse is at: X = " + centeredPosX.ToString() + " , Tilt = " + TiltX.ToString();
        }
    }
}
