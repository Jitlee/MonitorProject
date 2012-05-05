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
using System.Windows.Browser;

namespace MonitorSystem
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            string strWhere = string.Empty;
            if (HtmlPage.Document.QueryString.Count > 0)
                strWhere = HtmlPage.Document.QueryString["toWhere"];

            //this.Content = new SilverlightControl1();
            //return;
            if (strWhere == "RealtimeCurve")
            {
                this.Content = new MainRealtimeCurve();
            }
            else
            {
                this.Content = new LoadScreen();
            }
        }
    }
}
