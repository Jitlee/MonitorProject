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

        private t_Screen _Screen;
        /// <summary>
        /// 选择的场景
        /// </summary>
        public t_Screen Screen
        {
            get { return _Screen; }
            set {
                cbScreenList.SelectedItem = value;
                _Screen = value; 
            }
        }

        private bool _IsOK=false;
        /// <summary>
        /// 是否点击的OK按钮
        /// </summary>
        public bool IsOK
        {
            get { return _IsOK; }
        }

        private void InitProperty()
        {
            this.cbScreenList.ItemsSource = LoadScreen._DataContext.t_Screens;
            this.cbScreenList.DisplayMemberPath = "ScreenName";           
        }
       
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            if (cbScreenList.SelectedItem == null)
            {
                MessageBox.Show("请选择场景！");
                return;
            }
            _Screen = (t_Screen)cbScreenList.SelectedItem;
            
            _IsOK = true;
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            _IsOK = false;
            this.DialogResult = false;
        }
    }
}

