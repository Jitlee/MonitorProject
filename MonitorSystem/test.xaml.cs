using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting.Compatible;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Windows.Media.Imaging;


namespace MonitorSystem
{
    public partial class SilverlightControl1 : UserControl
    {

        public SilverlightControl1()
        {
            InitializeComponent();

            string gbUrl = string.Format("{0}/Upload/ImageMap/{1}", Common.TopUrl(), "第七泡的状态.JPG");
            BitmapImage bitmap = new BitmapImage(new Uri(gbUrl, UriKind.Absolute));
            image1.Source = bitmap;
            bitmap.ImageOpened +=new EventHandler<RoutedEventArgs>(bitmap_ImageOpened);

        }

        private void bitmap_ImageOpened<TEventArgs>(object sender, TEventArgs e)
        {
            BitmapImage bi = (BitmapImage)sender;
           double h = bi.PixelHeight;
           double w = bi.PixelWidth;
            
            
            //double h = image1.Height;
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
           // MessageBox.Show("");
            //drawLine1.SetChannelValue(0f, 25);
        }
    }

   
}
