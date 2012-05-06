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
using System.ServiceModel.DomainServices.Client;
using MonitorSystem.Web.Servers;
using MonitorSystem.Web.Moldes;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace MonitorSystem.ZTControls
{
    public partial class SetSingleProperty : ChildWindow, INotifyPropertyChanged
    {
        #region 属性
        private int _DeviceID = 0;
        /// <summary>
        /// 设备ID
        /// </summary>
        public int DeviceID
        {
            get { return _DeviceID; }
            set { _DeviceID = value; }
        }

        private int _ChanncelID = 0;
        /// <summary>
        /// 通道ID
        /// </summary>
        public int ChanncelID
        {
            get { return _ChanncelID; }
            set { _ChanncelID = value; }
        }


        private int _LevelNo = 1;
        /// <summary>
        /// 控件层次ID
        /// </summary>
        public int LevelNo
        {
            get { return _LevelNo; }
            set { _LevelNo = value; }
        }

        private string _ComputeStr = "";
        /// <summary>
        /// 表达式
        /// </summary>
        public string ComputeStr
        {
            get { return _ComputeStr; }
            set { _ComputeStr = value; }
        }

        private bool _IsOK = false;
        /// <summary>
        /// 是否点击的OK按钮
        /// </summary>
        public bool IsOK
        {
            get { return _IsOK; }
        }
        #endregion
        MonitorServers _dataContext = new MonitorServers();
        public SetSingleProperty()
        {
            InitializeComponent();
            _dataContext = LoadScreen._DataContext;
            
            //cbDeviceID.ItemsSource = _dataContext.t_Devices;
            Devices = new ObservableCollection<t_Device>(_dataContext.t_Devices);
            cbDeviceID.DisplayMemberPath = "DeviceName";
            //查询

            this.DataContext = this;
        }

        private ObservableCollection<t_Device> _devices;

        public ObservableCollection<t_Device> Devices
        {
            get
            {
                return _devices;
            }
            set
            {
                _devices = value;
                RaisePropertyChanged("Devices");
            }
        }

        private ObservableCollection<t_Channel> _channels;

        public ObservableCollection<t_Channel> Channels
        {
            get
            {
                return _channels;
            }
            set
            {
                _channels = value;
                RaisePropertyChanged("Channels");
            }
        }

        public void Init()
        {
            var v = LoadScreen._DataContext.t_Devices.Where(a => a.DeviceID == _DeviceID);
            if (v.Count() > 0)
            {
                cbDeviceID.SelectedItem = v.First();
            }
            //通道
            cbLayer.SelectedIndex = _LevelNo - 1;
            txtBDS.Text = _ComputeStr;
        }

        private void cbDeviceID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //cbChanncel.Items.Clear();
            t_Device d=(t_Device)cbDeviceID.Items[cbDeviceID.SelectedIndex];
            LoadChanncel(d.DeviceID);

        }

        private void LoadChanncel(int deviceid)
        {
            _dataContext.Load(_dataContext.GetT_ChannelQuery().Where(a => a.DeviceID == deviceid),
                LoadChanncelCommplete, deviceid);
        }

        private void LoadChanncelCommplete(LoadOperation<t_Channel> result)
        {
            if (result.HasError)
            {
                MessageBox.Show(result.Error.Message, "出错啦！", MessageBoxButton.OK);
                return;
            }
            
            var v = result.Entities;
            if (v.Count() > 0)
            {
                //cbChanncel.ItemsSource = v;
                Channels = new ObservableCollection<t_Channel>(v);
                var vc = v.Where(a => a.ChannelNo == _ChanncelID);
                if (vc.Count() > 0)
                {
                    cbChanncel.SelectedItem = vc.First();
                   // cbChanncel.DisplayMemberPath = "ChannelName";
                }
            }
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            _IsOK = true;

            if (cbDeviceID.SelectedValue == null)
            {
                MessageBox.Show("请选择设备！", "温馨提示！", MessageBoxButton.OK);
                return;
            }
            if (cbChanncel.SelectedValue == null)
            {

                MessageBox.Show("请选择通道！", "温馨提示！", MessageBoxButton.OK);
                return;
            }

            _DeviceID = ((t_Device)cbDeviceID.SelectedValue).DeviceID;
            _ChanncelID = ((t_Channel)cbChanncel.SelectedValue).ChannelNo;
            _LevelNo =int.Parse( ((ComboBoxItem)cbLayer.SelectedItem).Content.ToString());
            _ComputeStr = txtBDS.Text;

            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            _IsOK = false;
            this.DialogResult = false;
        }

    
        private void RaisePropertyChanged(string propertyName)
        {
            if(null != PropertyChanged)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler  PropertyChanged;
    }
}

