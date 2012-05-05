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
using System.Windows.Controls.DataVisualization.Charting.Compatible;


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

            List<Test> listTest = new List<Test>();

            Test t = new Test();
            t.XValue = "2012.5";
            t.YValue = 28;
            listTest.Add(t);

            Test t1 = new Test();
            t1.XValue = "2012.6";
            t1.YValue = 45;
            listTest.Add(t1);

            var column = new ColumnSeries();
            chart1.Series.Add(column);
            column.ItemsSource = listTest;

            column.DependentValuePath = "YValue";
            column.IndependentValuePath = "XValue";


        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }

    public class Test
    {
        private string _XValue;

        public string XValue
        {
            get { return _XValue; }
            set { _XValue = value; }
        }

        private int _YValue;

        public int YValue
        {
            get { return _YValue; }
            set { _YValue = value; }
        }
    }
}
