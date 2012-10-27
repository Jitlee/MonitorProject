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
using System.Collections.ObjectModel;
using MonitorSystem.Web.Moldes;
using System.ServiceModel.DomainServices.Client;
using System.ComponentModel;

namespace MonitorSystem.Other
{
    public partial class RealtimeProperty : ChildWindow
    {
        MonitorServers _dataContext = new MonitorServers();
        CV _DataCV = new CV();

        #region 处理设备通道信息
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
            }
        }

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

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            if (null != PropertyChanged)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private void cbDeviceID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            t_Device d = (t_Device)cbDeviceID.Items[cbDeviceID.SelectedIndex];
            LoadChanncel(d.DeviceID);
        }

        private void LoadChanncel(int deviceid)
        {
            _DataCV.Load(_DataCV.GetT_ChannelQuery().Where(a => a.DeviceID == deviceid),
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
                Channels = new ObservableCollection<t_Channel>(v);
                cbChanncel.ItemsSource = Channels;
                var vc = v.Where(a => a.ChannelNo == _ChanncelID);
                if (vc.Count() > 0)
                {
                    cbChanncel.SelectedItem = vc.First();
                }
            }
        }
        #endregion

        public RealtimeProperty()
        {
            InitializeComponent();

            _dataContext = LoadScreen._DataContext;
            _DataCV = LoadScreen._DataCV;
            
            Devices = new ObservableCollection<t_Device>(_DataCV.t_Devices);
            cbDeviceID.DisplayMemberPath = "DeviceName";
            this.DataContext = this;
        }

        RealTimeT _RealTimeData;
        /// <summary>
        /// 
        /// </summary>
        public RealTimeT RealTimeData
        {
            get { return _RealTimeData; }
            set { _RealTimeData = value; }
        }

        public void Init()
        {
            if (_RealTimeData == null)
                return;
            //X轴
            this.XISSGShow.IsChecked = _RealTimeData.XISSGShow;         //是否X轴栅格显示
            this.XMainNumber.SelectedIndex = _RealTimeData.XMainNumber; //X主分度数
            this.XMainColor.Color = _RealTimeData.XMainColor;           //X主分度颜色
            this.XPriNumber.SelectedIndex = _RealTimeData.XPriNumber;   //X次分度数
            this.XPriColor.Color = _RealTimeData.XPriColor;             //X度次分颜色

            //Y轴
            this.YISSGShow.IsChecked = _RealTimeData.YISSGShow;         //是否Y轴栅格显示
            this.YMainNumber.SelectedIndex = _RealTimeData.YMainNumber; //Y主分度数
            this.YMainColor.Color = _RealTimeData.YMainColor;           //Y主分度颜色
            this.YPriNumber.SelectedIndex = _RealTimeData.YPriNumber;   //Y次分度数
            this.YPriColor.Color = _RealTimeData.YPriColor;             //Y度次分颜色

            //其它颜色		
            this.ISShowBorder.IsChecked = _RealTimeData.ISShowBorder; //显示边框
            this.BorderColor.Color = _RealTimeData.BorderColor;      //边框

            this.ISShowGridBack.IsChecked = _RealTimeData.ISShowGridBack; //显示背景		
            this.GridBackColor.Color = _RealTimeData.GridBackColor; //背景颜色		

            this.ISShowCursor.IsChecked = _RealTimeData.ISShowCursor; //显示游标		
            this.CursorColor.Color = _RealTimeData.CursorColor; //游标颜色		

            this.ISShowTime.IsChecked = _RealTimeData.ISShowTime; //显示时间		
            this.TimeColor.Color = _RealTimeData.TimeColor; //时间颜色

            this.UsePerZB.IsChecked = _RealTimeData.UsePerZB;//采用百分比坐标
            this.NoUseDataMove.IsChecked = _RealTimeData.NoUseDataMove;//无效数据移出
            this.DoubleClickShowSet.IsChecked = _RealTimeData.DoubleClickShowSet;//双击显示设置框
            this.RightShowYZB.IsChecked = _RealTimeData.RightShowYZB;           //右显示Y轴坐标

            this.MultiXZShow.IsChecked = _RealTimeData.MultiXZShow; //多X轴显示
            this.MultiYZShow.IsChecked = _RealTimeData.MultiYZShow; //多Y轴显示
            this.IsShowLegend.IsChecked = _RealTimeData.IsShowLegend;   //显示图例
            //_RealTimeData.ShowLegend;
            this.InfoLWidth.Text = _RealTimeData.InfoLWidth.ToString(); //信息栏宽度

            //放缩设置
            this.MouseDrawEnlare.IsChecked = _RealTimeData.MouseDrawEnlare;// 鼠标拖动放大		
            this.XZEnlare.IsChecked = _RealTimeData.XZEnlare;// X轴放大		
            this.YZEnlare.IsChecked = _RealTimeData.YZEnlare;// Y轴放大		
            this.MouseDrawMove.IsChecked = _RealTimeData.MouseDrawMove;// 鼠标拖动移动		
            this.XZMove.IsChecked = _RealTimeData.XZMove;// X轴移动		
            this.YZMove.IsChecked = _RealTimeData.YZMove;// Y轴移动
        }

        /// <summary>
        /// 保存设置的数据
        /// </summary>
        private void SaveDate()
        {
            //X轴
            _RealTimeData.XISSGShow = this.XISSGShow.IsChecked.Value;     //是否X轴栅格显示
            _RealTimeData.XMainNumber = this.XMainNumber.SelectedIndex;   //X主分度数
            _RealTimeData.XMainColor = this.XMainColor.Color; //X主分度颜色
            _RealTimeData.XPriNumber = this.XPriNumber.SelectedIndex;    //X次分度数
            _RealTimeData.XPriColor = this.XPriColor.Color; //X度次分颜色

            //Y轴
            _RealTimeData.YISSGShow = this.YISSGShow.IsChecked.Value;     //是否Y轴栅格显示
            _RealTimeData.YMainNumber = this.YMainNumber.SelectedIndex;   //Y主分度数
            _RealTimeData.YMainColor = this.YMainColor.Color; //Y主分度颜色
            _RealTimeData.YPriNumber = this.YPriNumber.SelectedIndex;    //Y次分度数
            _RealTimeData.YPriColor = this.YPriColor.Color; //Y度次分颜色

            //其它颜色
            _RealTimeData.ISShowBorder = this.ISShowBorder.IsChecked.Value; //显示边框
            _RealTimeData.BorderColor = this.BorderColor.Color;      //边框

            _RealTimeData.ISShowGridBack = this.ISShowGridBack.IsChecked.Value; //显示背景		
            _RealTimeData.GridBackColor = this.GridBackColor.Color; //背景颜色		

            _RealTimeData.ISShowCursor = this.ISShowCursor.IsChecked.Value; //显示游标		
            _RealTimeData.CursorColor = this.CursorColor.Color; //游标颜色		

            _RealTimeData.ISShowTime = this.ISShowTime.IsChecked.Value; //显示时间		
            _RealTimeData.TimeColor = this.TimeColor.Color; //时间颜色


            _RealTimeData.UsePerZB = this.UsePerZB.IsChecked.Value;//采用百分比坐标
            _RealTimeData.NoUseDataMove = this.NoUseDataMove.IsChecked.Value;//无效数据移出
            _RealTimeData.DoubleClickShowSet = this.DoubleClickShowSet.IsChecked.Value;//双击显示设置框
            _RealTimeData.RightShowYZB = this.RightShowYZB.IsChecked.Value;           //右显示Y轴坐标

            _RealTimeData.MultiXZShow = this.MultiXZShow.IsChecked.Value; //多X轴显示
            _RealTimeData.MultiYZShow = this.MultiYZShow.IsChecked.Value; //多Y轴显示
            _RealTimeData.IsShowLegend = this.IsShowLegend.IsChecked.Value;   //显示图例
            //_RealTimeData.ShowLegend;
            _RealTimeData.InfoLWidth=int.Parse(this.InfoLWidth.Text); //信息栏宽度

            //放缩设置
            _RealTimeData.MouseDrawEnlare = this.MouseDrawEnlare.IsChecked.Value;// 鼠标拖动放大		
            _RealTimeData.XZEnlare = this.XZEnlare.IsChecked.Value;// X轴放大		
            _RealTimeData.YZEnlare = this.YZEnlare.IsChecked.Value;// Y轴放大		
            _RealTimeData.MouseDrawMove = this.MouseDrawMove.IsChecked.Value;// 鼠标拖动移动		
            _RealTimeData.XZMove = this.XZMove.IsChecked.Value;// X轴移动		
            _RealTimeData.YZMove = this.YZMove.IsChecked.Value;// Y轴移动
        }



        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            t_Channel t = (t_Channel)cbChanncel.SelectedItem;
            MessageBox.Show(t.ChannelName);
            SaveDate();
            this.DialogResult = true;
        }


        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        #region 鼠标移动处理
        private void MouseDrawEnlare_Checked(object sender, RoutedEventArgs e)
        {
            XZEnlare.IsChecked = true;
            YZEnlare.IsChecked = true;
            XZEnlare.IsEnabled = true;
            YZEnlare.IsEnabled = true;

            MouseDrawMove.IsChecked = false;
            XZMove.IsChecked = false;
            YZMove.IsChecked = false;
            XZMove.IsEnabled = false;
            YZMove.IsEnabled = false;
        }

        private void MouseDrawMove_Checked(object sender, RoutedEventArgs e)
        {
            XZMove.IsChecked = true;
            YZMove.IsChecked = true;
            XZMove.IsEnabled = true;
            YZMove.IsEnabled = true;

            MouseDrawEnlare.IsChecked = false;
            XZEnlare.IsChecked = false;
            YZEnlare.IsChecked = false;
            XZEnlare.IsEnabled = false;
            YZEnlare.IsEnabled = false;
        }
        #endregion

        #region 曲线处理

        private ElementRealTimeLineOR GetRealTimeLineOR()
        {
            ElementRealTimeLineOR obj = new ElementRealTimeLineOR();
            obj.Linename = this.LineName.Text;
            
            //obj.ID
            /*
obj.ScreenID
ElementID
LineType
LineName
LineCZ
LineShowType
LineStyle
LinePointBJ
LineColor
MinValue
MaxValue
ValueDecimal
ShowFormat
TimeLen
TimeLenType
LineCYZQLent
LineCYZQType
DeviceID
ChannelNo
ComputeStr
StartTime

*/
            return obj;
        }

        List<ElementRealTimeLineOR> listRealTimeLisne = new List<ElementRealTimeLineOR>();
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAlert_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public class ElementRealTimeLineOR
    {

        private string _Id;
        /// <summary>
        /// 
        /// </summary>
        public string Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private int _Screenid;
        /// <summary>
        /// 场景ID
        /// </summary>
        public int Screenid
        {
            get { return _Screenid; }
            set { _Screenid = value; }
        }

        private int _Elementid;
        /// <summary>
        /// 无素ID
        /// </summary>
        public int Elementid
        {
            get { return _Elementid; }
            set { _Elementid = value; }
        }

        private int _Linetype;
        /// <summary>
        /// 线类型
        /// </summary>
        public int Linetype
        {
            get { return _Linetype; }
            set { _Linetype = value; }
        }

        private string _Linename;
        /// <summary>
        /// 线名称
        /// </summary>
        public string Linename
        {
            get { return _Linename; }
            set { _Linename = value; }
        }

        private int _Linecz;
        /// <summary>
        /// 取值()
        /// </summary>
        public int Linecz
        {
            get { return _Linecz; }
            set { _Linecz = value; }
        }

        private int _Lineshowtype;
        /// <summary>
        /// 类型(直线、阶梯线)
        /// </summary>
        public int Lineshowtype
        {
            get { return _Lineshowtype; }
            set { _Lineshowtype = value; }
        }

        private int _Linestyle;
        /// <summary>
        /// 样式
        /// </summary>
        public int Linestyle
        {
            get { return _Linestyle; }
            set { _Linestyle = value; }
        }

        private int _Linepointbj;
        /// <summary>
        /// 标记,不画点
        /// </summary>
        public int Linepointbj
        {
            get { return _Linepointbj; }
            set { _Linepointbj = value; }
        }

        private string _Linecolor;
        /// <summary>
        /// 线颜色
        /// </summary>
        public string Linecolor
        {
            get { return _Linecolor; }
            set { _Linecolor = value; }
        }

        private string _Minvalue;
        /// <summary>
        /// 最小值
        /// </summary>
        public string Minvalue
        {
            get { return _Minvalue; }
            set { _Minvalue = value; }
        }

        private string _Maxvalue;
        /// <summary>
        /// 最大值
        /// </summary>
        public string Maxvalue
        {
            get { return _Maxvalue; }
            set { _Maxvalue = value; }
        }

        private int _Valuedecimal;
        /// <summary>
        /// 小数位长度
        /// </summary>
        public int Valuedecimal
        {
            get { return _Valuedecimal; }
            set { _Valuedecimal = value; }
        }

        private string _Showformat;
        /// <summary>
        /// 显示格式
        /// </summary>
        public string Showformat
        {
            get { return _Showformat; }
            set { _Showformat = value; }
        }

        private int _Timelen;
        /// <summary>
        /// 时间长度
        /// </summary>
        public int Timelen
        {
            get { return _Timelen; }
            set { _Timelen = value; }
        }

        private string _Timelentype;
        /// <summary>
        /// 时间长度类型
        /// </summary>
        public string Timelentype
        {
            get { return _Timelentype; }
            set { _Timelentype = value; }
        }

        private string _Linecyzqlent;
        /// <summary>
        /// 时间采样周期
        /// </summary>
        public string Linecyzqlent
        {
            get { return _Linecyzqlent; }
            set { _Linecyzqlent = value; }
        }

        private string _Linecyzqtype;
        /// <summary>
        /// 采样周期类型
        /// </summary>
        public string Linecyzqtype
        {
            get { return _Linecyzqtype; }
            set { _Linecyzqtype = value; }
        }

        private int _Deviceid;
        /// <summary>
        /// 取值设备ID
        /// </summary>
        public int Deviceid
        {
            get { return _Deviceid; }
            set { _Deviceid = value; }
        }

        private int _Channelno;
        /// <summary>
        /// 取值设备通道
        /// </summary>
        public int Channelno
        {
            get { return _Channelno; }
            set { _Channelno = value; }
        }

        private string _Computestr;
        /// <summary>
        /// 取值表达试
        /// </summary>
        public string Computestr
        {
            get { return _Computestr; }
            set { _Computestr = value; }
        }

        private DateTime _Starttime;
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime Starttime
        {
            get { return _Starttime; }
            set { _Starttime = value; }
        }

        /// <summary>
        /// ElementRealTimeLine构造函数
        /// </summary>
        public ElementRealTimeLineOR()
        {

        }
    }

}

