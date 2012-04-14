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

namespace MonitorSystem.MonitorSystemGlobal
{
    public partial class TP_ButtonSetProperty : ChildWindow
    {
        TP_Button BaseCtl;
        public TP_ButtonSetProperty(TP_Button _baseCtl)
        {
            InitializeComponent();

            BaseCtl = _baseCtl;
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

