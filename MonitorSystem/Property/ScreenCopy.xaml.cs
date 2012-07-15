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
using MonitorSystem.Web.Moldes;
using MonitorSystem.Web.Servers;

namespace MonitorSystem.Property
{
    public partial class ScreenCopy : ChildWindow
    {
        public ScreenCopy()
        {
            InitializeComponent();

            cbScreen.ItemsSource = PropertyMain.listScreen;
            cbScreen.DisplayMemberPath = "ScreenName";
        }

        t_Screen _oldScreen;
        /// <summary>
        /// 场景对象 
        /// </summary>
        public t_Screen oldScreen
        {
            set { _oldScreen = value; }
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            t_Screen tNew =(t_Screen)cbScreen.SelectedItem;
            //MessageBox.Show(tNew.ScreenName);
            MonitorServers _DataContext = new MonitorServers();            
            _DataContext.CopyScreenElement(tNew.ScreenID,_oldScreen.ScreenID);
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}

