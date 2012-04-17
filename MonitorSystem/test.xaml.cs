using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace MonitorSystem
{
    public partial class SilverlightControl1 : UserControl
    {
        public SilverlightControl1()
        {
            InitializeComponent();

            bod.BorderBrush = new SolidColorBrush(Colors.Red);
            Thickness thi = new Thickness();
            thi.Left = 3;
            thi.Top = 2;
            thi.Right = 2;
            thi.Bottom = 0;
            bod.BorderThickness = thi;
            
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
