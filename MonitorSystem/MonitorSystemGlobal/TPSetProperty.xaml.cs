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
using MonitorSystem.Web.Servers;
using MonitorSystem.Web.Moldes;
using System.ServiceModel.DomainServices.Client;

namespace MonitorSystem.MonitorSystemGlobal
{
    public partial class TPSetProperty : ChildWindow
    {
        MonitorServers _DataContext = new MonitorServers();
        public TPSetProperty()
        {
            InitializeComponent();
            InitProperty();
        }

      public  string strMessage = "test";

        private void InitProperty()
        {
            this.cbScreenList.ItemsSource = LoadScreen._DataContext.t_Screens;
            this.cbScreenList.DisplayMemberPath = "ScreenName";           
        }
       
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}

