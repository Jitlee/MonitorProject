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


namespace MonitorSystem
{
    public partial class SilverlightControl1 : UserControl
    {

        public SilverlightControl1()
        {
            InitializeComponent();

            //bod.BorderBrush = new SolidColorBrush(Colors.Red);
            //Thickness thi = new Thickness();
            //thi.Left = 3;
            //thi.Top = 2;
            //thi.Right = 2;
            //thi.Bottom = 0;
            //bod.BorderThickness = thi;
//            this.chart1.Series.x
           // ddd.

            //定时更新值
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 4);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();


        }
        protected void timer_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
           int x= r.Next(500);
          
        }
        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }

   
}
