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

        //public event PropertyChangedEventHandler PropertyChanged;
        //private void RaisePropertyChanged(string propertyName)
        //{
        //    if (null != PropertyChanged)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}
        private void cbDeviceID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbDeviceID.SelectedIndex < 0)
                return;
            t_Device d = (t_Device)cbDeviceID.Items[cbDeviceID.SelectedIndex];
            LoadChanncel(d.DeviceID);
        }
        private void LoadChanncel(int deviceid, int ChanncelID)
        {
            _DataCV.Load(_DataCV.GetT_ChannelQuery().Where(a => a.DeviceID == deviceid),
                LoadChanncelCommplete, ChanncelID);
        }
        private void LoadChanncel(int deviceid)
        {
            _DataCV.Load(_DataCV.GetT_ChannelQuery().Where(a => a.DeviceID == deviceid),
                LoadChanncelCommplete, null);
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
                if (result.UserState != null)
                {
                    var vc = v.Where(a => a.ChannelNo == Convert.ToInt32(result.UserState));
                    if (vc.Count() > 0)
                    {
                        cbChanncel.SelectedItem = vc.First();
                    }
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

            ShowYear.Value = DateTime.Now.Year;
            ShowMonth.Value = DateTime.Now.Month;
            ShowDay.Value = DateTime.Now.Day;

            ShowHH.Value = DateTime.Now.Hour;
            ShowMi.Value = DateTime.Now.Minute;
            ShowSS.Value = DateTime.Now.Millisecond;
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

        ObservableCollection<t_Element_RealTimeLine> _ListEletement = new ObservableCollection<t_Element_RealTimeLine>();
        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<t_Element_RealTimeLine> ListEletement
        {
            get { return _ListEletement; }
            set { _ListEletement = value; }
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

            //线信息
            foreach (RealTimeLineOR obj in _RealTimeData.ListRealTimeLine)
            {
                ListEletement.Add(obj.LineInfo);
            }
            SetDefult();
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
            _RealTimeData.InfoLWidth = int.Parse(this.InfoLWidth.Text); //信息栏宽度

            //放缩设置
            _RealTimeData.MouseDrawEnlare = this.MouseDrawEnlare.IsChecked.Value;// 鼠标拖动放大		
            _RealTimeData.XZEnlare = this.XZEnlare.IsChecked.Value;// X轴放大		
            _RealTimeData.YZEnlare = this.YZEnlare.IsChecked.Value;// Y轴放大		
            _RealTimeData.MouseDrawMove = this.MouseDrawMove.IsChecked.Value;// 鼠标拖动移动		
            _RealTimeData.XZMove = this.XZMove.IsChecked.Value;// X轴移动		
            _RealTimeData.YZMove = this.YZMove.IsChecked.Value;// Y轴移动
        }

        private void AdminLine()
        {
            //移出
            if (DeleteRealTime.Count > 0)
            {
                foreach (t_Element_RealTimeLine obj in DeleteRealTime)
                {
                    //_RealTimeData.
                    RealTimeLineOR _line = GetRealLine(obj);
                    if (_line != null)
                    {
                        _RealTimeData.ListRealTimeLine.Remove(_line);
                        _RealTimeData._CanvasLine.Children.Remove(_line.PolyLine);
                        if (_RealTimeData.ElementState == MonitorSystemGlobal.ElementSate.Save)
                        {
                            var v = LoadScreen._DataContext.t_Element_RealTimeLines.Where(a => a.ID == obj.ID);
                            if (v.Count() == 1)
                            {
                                LoadScreen._DataContext.t_Element_RealTimeLines.Remove(v.First());
                            }
                        }
                    }
                }
            }
            //修改、添加
            foreach (t_Element_RealTimeLine obj in ListEletement)
            {
                RealTimeLineOR _line = GetRealLine(obj);
                if (_line != null)
                {
                    _line.LineInfo = obj;
                }
                else
                {
                    RealTimeLineOR _data = new RealTimeLineOR(obj);
                    _RealTimeData.ListRealTimeLine.Add(_data);
                    if (_RealTimeData.ElementState == MonitorSystemGlobal.ElementSate.Save)
                    {
                        obj.ScreenID = _RealTimeData.ScreenElement.ScreenID.Value;
                        obj.ElementID = _RealTimeData.ScreenElement.ElementID;
                        LoadScreen._DataContext.t_Element_RealTimeLines.Add(obj);
                    }
                }
            }
        }

        private RealTimeLineOR GetRealLine(t_Element_RealTimeLine obj)
        {
            foreach (RealTimeLineOR line in _RealTimeData.ListRealTimeLine)
            {
                if (line.LineInfo.ID == obj.ID)
                    return line;
            }
            return null;
        }



        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            SaveDate();
            AdminLine();
            _RealTimeData.PaintBasicInfo();
            
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
        private void SetDefult()
        {
            this.LineName.Text = "ll";
            LineType.SelectedIndex = 0;
            LineCZ.SelectedIndex = 0;
            LineShowType.SelectedIndex = 0;
            LineStyle.SelectedIndex = 0;

            LinePointBJ.SelectedIndex = 0;

            LineColor.Color = Colors.Blue;
            MinValue.Text = "0";
            MaxValue.Text = "100";
            ValueDecimal.Value = 0;

            FormartYear.IsChecked = false;
            FormartMonth.IsChecked = false;
            FormartDay.IsChecked = false;

            FormartHH.IsChecked = true;
            FormartMi.IsChecked = true;
            FormartSS.IsChecked = true;

            TimeLen.Text = "100";
            TimeLenType.SelectedIndex = 0;

            LineCYZQLent.Text = "1";
            LineCYZQType.SelectedIndex = 0;
            this.ComputeStr.Text = "";

            ShowYear.Value = DateTime.Now.Year;
            ShowMonth.Value = DateTime.Now.Month;
            ShowDay.Value = DateTime.Now.Day;

            ShowHH.Value = DateTime.Now.Hour;
            ShowMi.Value = DateTime.Now.Minute;
            ShowSS.Value = DateTime.Now.Millisecond;
        }

        private void SetRealTimeLineOR(t_Element_RealTimeLine obj)
        {
            _RealTime = obj;

            if (obj == null)
                return;
            this.LineName.Text = obj.LineName;
            LineType.SelectedIndex = obj.LineType;
            LineCZ.SelectedIndex = obj.LineCZ.Value;
            LineShowType.SelectedIndex = obj.LineShowType.Value;
            LineStyle.SelectedIndex = obj.LineStyle.Value;

            LinePointBJ.SelectedIndex = obj.LinePointBJ.Value;

            LineColor.Color = Common.StringToColor(obj.LineColor);
            MinValue.Text = obj.MinValue;
            MaxValue.Text = obj.MaxValue;
            ValueDecimal.Value = obj.ValueDecimal;


            FormartYear.IsChecked = false;
            FormartMonth.IsChecked = false;
            FormartDay.IsChecked = false;
            FormartHH.IsChecked = false;
            FormartMi.IsChecked = false;
            FormartSS.IsChecked = false;


            if (obj.ShowFormat.IndexOf("yyyy") == 0)//年度
            {
                FormartYear.IsChecked = true;
            }
            if (obj.ShowFormat.IndexOf("MM") >= 0)//月
            {
                FormartMonth.IsChecked = true;
            }
            if (obj.ShowFormat.IndexOf("dd") >= 0)//日
            {
                FormartDay.IsChecked = true;
            }

            if (obj.ShowFormat.IndexOf("HH") >= 0)//日
            {
                FormartHH.IsChecked = true;
            }

            if (obj.ShowFormat.IndexOf("mm") >= 0)//分
            {
                FormartMi.IsChecked = true;
            }

            if (obj.ShowFormat.IndexOf("ss") >= 0)//秒
            {
                FormartSS.IsChecked = true;
            }

            TimeLen.Text = obj.TimeLen.ToString();
            TimeLenType.SelectedIndex = GetIndex(obj.TimeLenType);

            LineCYZQLent.Text = obj.LineCYZQLent;
            LineCYZQType.SelectedIndex = GetIndex(obj.LineCYZQType);


            if (obj.ComputeStr == null)
                obj.ComputeStr = "";
            this.ComputeStr.Text = obj.ComputeStr;

            if (obj.DeviceID.HasValue)
            {
                var v = _devices.FirstOrDefault(a => a.DeviceID == obj.DeviceID);
                cbDeviceID.SelectedValue = v;

                if (obj.ChannelNo.HasValue)
                {
                    LoadChanncel(v.DeviceID, obj.ChannelNo.Value);
                }
                else
                {
                    LoadChanncel(v.DeviceID);
                }
            }


            //obj.ComputeStr = this.ComputeStr.Text;
            ShowYear.Value = DateTime.Now.Year;
            ShowMonth.Value = DateTime.Now.Month;
            ShowDay.Value = DateTime.Now.Day;

            ShowHH.Value = DateTime.Now.Hour;
            ShowMi.Value = DateTime.Now.Minute;
            ShowSS.Value = DateTime.Now.Millisecond;
        }
        t_Element_RealTimeLine _RealTime = new t_Element_RealTimeLine();
        private void SaveRealTimeLineOR()
        {

            _RealTime.LineName = this.LineName.Text;

            _RealTime.LineType = this.LineStyle.SelectedIndex;
            _RealTime.LineCZ = LineCZ.SelectedIndex;
            _RealTime.LineShowType = LineShowType.SelectedIndex;
            _RealTime.LineStyle = LineStyle.SelectedIndex;
            _RealTime.LinePointBJ = LinePointBJ.SelectedIndex;

            _RealTime.LineColor = LineColor.Color.ToString();
            _RealTime.MinValue = MinValue.Text;
            _RealTime.MaxValue = MaxValue.Text;
            _RealTime.ValueDecimal = int.Parse(ValueDecimal.Value.ToString());

            string strShowFormat = string.Empty;
            if (this.FormartYear.IsChecked.Value)//年度
            {
                strShowFormat = "yyyy";
            }
            if (this.FormartMonth.IsChecked.Value)//月
            {
                strShowFormat = string.Format("{0}{1}MM", strShowFormat, string.IsNullOrEmpty(strShowFormat) ? "" : "-");
            }
            if (this.FormartDay.IsChecked.Value)//日
            {
                strShowFormat = string.Format("{0}{1}dd", strShowFormat, string.IsNullOrEmpty(strShowFormat) ? "" : "-");
            }

            if (this.FormartHH.IsChecked.Value)//时
            {
                strShowFormat = string.Format("{0}{1}HH", strShowFormat, string.IsNullOrEmpty(strShowFormat) ? "" : " ");
            }

            if (this.FormartMi.IsChecked.Value)//分
            {
                strShowFormat = string.Format("{0}{1}mm", strShowFormat, string.IsNullOrEmpty(strShowFormat) ? "" : ":");
            }

            if (this.FormartSS.IsChecked.Value)//秒
            {
                strShowFormat = string.Format("{0}{1}ss", strShowFormat, string.IsNullOrEmpty(strShowFormat) ? "" : ":");
            }
            _RealTime.ShowFormat = strShowFormat;

            _RealTime.TimeLen = int.Parse(TimeLen.Text);
            //ComboBoxItem cbi = (ComboBoxItem)TimeLenType.SelectedItem;
            _RealTime.TimeLenType = GetStr(TimeLenType.SelectedIndex);

            _RealTime.LineCYZQLent = LineCYZQLent.Text;
            //cbi = (ComboBoxItem)LineCYZQType.SelectedItem;
            _RealTime.LineCYZQType = GetStr(LineCYZQType.SelectedIndex);

            if (cbDeviceID.SelectedIndex >= 0)
            {
                t_Device d = (t_Device)cbDeviceID.Items[cbDeviceID.SelectedIndex];
                _RealTime.DeviceID = d.DeviceID;
            }

            if (cbChanncel.SelectedIndex >= 0)
            {
                t_Channel tc = (t_Channel)cbChanncel.Items[cbChanncel.SelectedIndex];
                _RealTime.ChannelNo = tc.ChannelNo;
            }

            _RealTime.ComputeStr = this.ComputeStr.Text;

            string strTime = string.Format("{0}:{1}:{2} {3}:{4}:{5}", this.ShowYear.Value, this.ShowMonth.Value, this.ShowDay.Value,
                this.ShowHH.Value, this.ShowMi.Value, this.ShowSS.Value);

        }
        #region 时间范围处理
        private int GetIndex(string str)
        {
            if (str == "ss")
            {
                return 0;
            }
            else if (str == "mm")
            {
                return 1;
            }
            else if (str == "")
            {
                return 2;
            }

            return 3;
        }

        private string GetStr(int index)
        {
            if (index == 0)
            {
                return "ss";
            }
            else if (index == 1)
            {
                return "mm";
            }
            else if (index == 2)
            {
                return "hh";
            }
            return "dd";
        }
        #endregion

        List<t_Element_RealTimeLine> DeleteRealTime = new List<t_Element_RealTimeLine>();
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            _RealTime = new t_Element_RealTimeLine();
            _RealTime.ID = Guid.NewGuid().ToString();
            SaveRealTimeLineOR();
            //名称
            foreach (t_Element_RealTimeLine obj in ListEletement)
            {
                if (obj.LineName == _RealTime.LineName)
                {
                    MessageBox.Show(string.Format("名称：{0}，已经存在！", _RealTime.LineName));
                    return;
                }
            }
            ListEletement.Add(_RealTime);
        }

        private void btnAlert_Click(object sender, RoutedEventArgs e)
        {
            if (dgDataList.SelectedItem == null)
            {
                MessageBox.Show("请选择移出项！");
                return;
            }
            SaveRealTimeLineOR();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgDataList.SelectedItem == null)
            {
                MessageBox.Show("请选择移出项！");
                return;
            }
            var v = dgDataList.SelectedItem as t_Element_RealTimeLine;
            ListEletement.Remove(v);
            DeleteRealTime.Add(v);

        }
        #endregion

        private void dgDataList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var v = ((DataGrid)sender).SelectedItem as t_Element_RealTimeLine;
            SetRealTimeLineOR(v);

        }



    }
}

