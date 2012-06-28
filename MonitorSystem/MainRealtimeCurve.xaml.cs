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
using MonitorSystem.MonitorSystemGlobal;
using MonitorSystem.Web.Servers;
using System.ServiceModel.DomainServices.Client;
using MonitorSystem.Web.Moldes;
using System.Windows.Threading;

namespace MonitorSystem
{
    public partial class MainRealtimeCurve : UserControl
    {
        MonitorServers _DataContext = new MonitorServers();
        t_Sys_MainRealTimeSet SysSetReal = new t_Sys_MainRealTimeSet();
        DispatcherTimer timer = new DispatcherTimer();
        public MainRealtimeCurve()
        {
            InitializeComponent();

            timer.Interval = new TimeSpan(0, 0, 5);
            timer.Tick += new EventHandler(timer_Tick);
          
            //realTime.RealtimeValue
            _DataContext.Load(_DataContext.GetT_Sys_MainRealTimeSetQuery(), LoadSysSetCompleted, null);
            
        }

        private void LoadSysSetCompleted(LoadOperation<t_Sys_MainRealTimeSet> result)
        {
            if (result.HasError)
            {
                MessageBox.Show("加截设置参数出错！", "出错啦！", MessageBoxButton.OK);
                return;
            }
            if (result.Entities.Count() == 0)
            {
                MessageBox.Show("还未设置参数！", "出错啦！", MessageBoxButton.OK);
                return;
            }

            SysSetReal = result.Entities.First();
            realTime.Ylower = SysSetReal.Ylower;
            realTime.Yupper = SysSetReal.Yupper;
            realTime.YmaxValue = SysSetReal.YmaxValue;
            realTime.YminValue = SysSetReal.YminValue;
            realTime.GridHeight = SysSetReal.GridHeight;
            //先加载一个值
            timer_Tick(null,null);
            timer.Start();
        }

        protected void timer_Tick(object sender, EventArgs e)
        {
            //ShowCurve(RealtimeValue);
            if (SysSetReal == null)
                return;
            InvokeOperation<double> result = new CV().SelectNewValue(
                SysSetReal.StationID, SysSetReal.DeviceID
               , SysSetReal.ChannelNO);

            result.Completed += ((p1, q1) =>
            {
                if (result.HasError)
                    return;
                double val=result.Value;
                if (val != -999)
                {
                    this.realTime.RealtimeValue = val;
                }
                
            });          
        }

      

    }
}
