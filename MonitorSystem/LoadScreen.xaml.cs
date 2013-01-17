﻿using System;
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
using System.Windows.Media.Imaging;
using MonitorSystem.MonitorSystemGlobal;
using MonitorSystem.Web.Servers;
using System.ServiceModel.DomainServices.Client;
using System.Collections.ObjectModel;

using MonitorSystem.ZTControls;
//using SL4PopupMenu;
using System.Threading;
using System.Windows.Threading;
using MonitorSystem.Controls;
using System.Windows.Browser;
using MonitorSystem.Dlfh;
using MonitorSystem.Dqfh;
using MonitorSystem.Dldz;
using MonitorSystem.Gallery.Meter;
using System.Diagnostics;
using MonitorSystem.Other;
using System.ComponentModel;

namespace MonitorSystem
{
    public partial class LoadScreen : UserControl
    {
       
        #region 变量 
        /// <summary>
        /// 获取是否是组态模式
        /// </summary>
        public static bool IsZT { get; private set; }

        public static MonitorServers _DataContext = new MonitorServers();
        public static CV _DataCV = new CV();

        //public static MonitorControl CoptyObj=null;
        public static IEnumerable<ScreenElementObj> CopyArray;
        /// <summary>
        /// 场景列表
        /// </summary>
        public static IEnumerable<t_Screen> listScreen;

        /// <summary>
        /// 当前场景
        /// </summary>
        t_Screen _CurrentScreen;

        public  static LoadScreen _instance = null;

        /// <summary>
        /// 系统参数
        /// </summary>
        t_MonitorSystemParam SystemParam;

        /// <summary>
        /// 当前屏幕所有元素,已保存的元素,用于删除
        /// </summary>
        List<t_Element> ScreenAllElement = new List<t_Element>();

        /// <summary>
        /// 定时更新值
        /// </summary>
        DispatcherTimer timerRefrshValue = new DispatcherTimer();
        /// <summary>
        /// 加载场景列表，用于后退功能
        /// </summary>
        Stack<t_Screen> LoadScreenList = new Stack<t_Screen>();
        /// <summary>
        /// 用于记录上一个场景
        /// </summary>
        t_Screen ReturnScreen;
        /// <summary>
        /// 主页
        /// </summary>
        t_Screen MainPage;
        /// <summary>
        /// 是否Pop列表
        /// </summary>
        //bool IsPop = false;
        #endregion

        public LoadScreen()
        {
            InitializeComponent();
            wrapPanel1.SetValue(Canvas.ZIndexProperty, 999);
            tbWait.IsBusy = true;
            //实例化
            Init();
            _SenceCommand = new DelegateCommand<t_Screen>(LoadSence);
            _instance = this;
            //SceenViewBox.Stretch = Stretch.;
            //AddElementCanvas.MouseLeftButtonDown += AddElementCanvas_MouseLeftButtonDown;
            //AddElementCanvas.MouseLeftButtonUp += AddElementCanvas_MouseLeftButtonUp;
            csScreen.AddHandler(FrameworkElement.MouseLeftButtonDownEvent, new MouseButtonEventHandler(CsScreen_MouseLeftButtonDown), false);
            csScreen.VerticalAlignment = VerticalAlignment.Top;
            csScreen.HorizontalAlignment = HorizontalAlignment.Left;
            GridScreen.AddHandler(Grid.MouseWheelEvent, new MouseWheelEventHandler(GridScreen_MouseWheel), false);
            GridScreen.MouseLeftButtonDown += GridScreen_MouseLeftButtonDown;
        }
        public static void Load(t_Screen screen)
        {
            if (screen == null)
                return;
            ISBack = false;
            _instance.LoadScreenData(screen);
        }

        #region 背景
        public void SetScreenImg(t_Screen screen)
        {
            if (_CurrentScreen == null || screen == null)
                return;
            if (_CurrentScreen.ScreenID != screen.ScreenID)
                return;

            SetScreenImg(screen.ImageURL);           
        }

        public void SetScreenImg(string strImg, bool resize = false)
        {
            var gbUrl = string.Format("{0}/Upload/ImageMap/{1}", Common.TopUrl(), strImg);
            var bitmap = new BitmapImage(new Uri(gbUrl, UriKind.Absolute));
            if (resize)
            {
                bitmap.ImageOpened += Screen_ImageOpened;
            }
            bitmap.ImageFailed += Screen_ImageFailed;

            var imgB = new ImageBrush() { Stretch = Stretch.UniformToFill };
            imgB.ImageSource = bitmap;
            csScreen.Background = imgB;

            //_ScreenView.SetScreenImg(strImg);
            
          
        }

        private void Screen_ImageOpened(object sender, RoutedEventArgs e)
        {
            var image = (BitmapImage)sender;
            if (MessageBox.Show(
                    string.Format("当前背景图片的大小(像素)为：{0}×{1}, 是否同时修改场景的大小",
                        image.PixelWidth, image.PixelHeight),
                    "询问",
                    MessageBoxButton.OKCancel)
                == MessageBoxResult.OK)
            {
                CanvasWidth = image.PixelWidth;
                CanvasHeight = image.PixelHeight;
            }
        }

        private void Screen_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            ThumbnailCanvas.Background = csScreen.Background = new SolidColorBrush(Common.StringToColor(_CurrentScreen.BackColor, Color.FromArgb(0xff, 0xF5, 0xF5, 0xDC)));
        }

        private string _bgImagePath;
        private const string PATH = "ImageMap";
        [Image(PATH, OnlyImage = true)]
        [DefaultValue(""), Description("设置场景背景图片"), Category("杂项"), DisplayName("背景图片")]
        public string BgImagePath
        {
            set
            {
                _bgImagePath = value;
                _CurrentScreen.ImageURL = value;
                SetScreenImg(value, true);
            }
            get
            {
                return _bgImagePath;
            }
        }

        [DefaultValue(""), Description("设置场景宽度"), Category("杂项"), DisplayName("宽度")]
        public int CanvasWidth
        {
            set
            {
                _CurrentScreen.Width = value;
                csScreen.Width = AddElementCanvas.Width = value;
                UpdateThumbnail();
            }
            get
            {
                return (_CurrentScreen.Width.HasValue && _CurrentScreen.Width > 100d) ? _CurrentScreen.Width.Value : 1920;
            }
        }

        [DefaultValue(""), Description("设置场景高度"), Category("杂项"), DisplayName("高度")]
        public int CanvasHeight
        {
            set
            {
                _CurrentScreen.Height = (int)value;
                csScreen.Height = AddElementCanvas.Height = value;
                UpdateThumbnail();
            }
            get
            {
                return (_CurrentScreen.Height.HasValue && _CurrentScreen.Height > 100d) ? _CurrentScreen.Height.Value : 1024;
            }
        }
        
        //SceneBackgroundPanel b = new SceneBackgroundPanel();
        private void CsScreen_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Adorner.CancelSelected();
            HideFocusElement.Focus();

            PropertyMain.Instance.ControlPropertyGrid.SelectedObject = null;
            PropertyMain.Instance.ControlPropertyGrid.BrowsableProperties = new []{"BgImagePath", "CanvasWidth", "CanvasHeight" };
            _bgImagePath = _CurrentScreen.ImageURL;
            PropertyMain.Instance.ControlPropertyGrid.SelectedObject =this; 

        }
        #endregion



        #region 右键框选

        private void GridScreen_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            GridScreen.CaptureMouse();
            _originPoint = e.GetPosition(csScreen);
            AddElementRectangle.SetValue(Canvas.LeftProperty, _originPoint.X);
            AddElementRectangle.SetValue(Canvas.TopProperty, _originPoint.Y);
            AddElementRectangle.SetValue(HeightProperty, 0d);
            AddElementRectangle.SetValue(WidthProperty, 0d);
            AddElementCanvas.Visibility = Visibility.Visible;
            AddElementRectangle.Visibility = Visibility.Visible;
            GridScreen.MouseMove -= GridScreen_MouseRightMove;
            GridScreen.MouseMove += GridScreen_MouseRightMove;
            GridScreen.MouseLeave -= GridScreen_MouseRightLeave;
            GridScreen.MouseLeave += GridScreen_MouseRightLeave;
            GridScreen.MouseRightButtonUp -= GridScreen_MouseRightButtonUp;
            GridScreen.MouseRightButtonUp += GridScreen_MouseRightButtonUp;

            e.Handled = true;
        }

        private void GridScreen_MouseRightLeave(object sender, MouseEventArgs e)
        {
            GridScreen.ReleaseMouseCapture();
            GridScreen.MouseMove -= GridScreen_MouseRightMove;
            GridScreen.MouseRightButtonUp -= GridScreen_MouseRightButtonUp;
            AddElementCanvas.Visibility = Visibility.Collapsed;
            AddElementRectangle.Visibility = Visibility.Collapsed;
        }

        private void GridScreen_MouseRightMove(object sender, MouseEventArgs e)
        {
            var transform = csScreen.TransformToVisual(GridScreen).Transform(new Point());
            var point = e.GetPosition(csScreen);
            var offsetX = point.X - _originPoint.X;
            var offsetY = point.Y - _originPoint.Y;
            AddElementRectangle.SetValue(Canvas.LeftProperty, (offsetX < 0 ? point.X : _originPoint.X));
            AddElementRectangle.SetValue(Canvas.TopProperty, (offsetY < 0 ? point.Y : _originPoint.Y));
            AddElementRectangle.SetValue(WidthProperty, Math.Abs(offsetX));
            AddElementRectangle.SetValue(HeightProperty, Math.Abs(offsetY));
        }

        private void GridScreen_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            GridScreen.ReleaseMouseCapture();
            GridScreen.MouseMove -= GridScreen_MouseRightMove;
            GridScreen.MouseLeave -= GridScreen_MouseRightLeave;
            GridScreen.MouseRightButtonUp -= GridScreen_MouseRightButtonUp;
            AddElementCanvas.Visibility = Visibility.Collapsed;
            AddElementRectangle.Visibility = Visibility.Collapsed;

            var point = e.GetPosition(csScreen);
            var offsetX = point.X - _originPoint.X;
            var offsetY = point.Y - _originPoint.Y;
            var left = offsetX < 0 ? point.X : _originPoint.X;
            var top = offsetY < 0 ? point.Y : _originPoint.Y;
            var width = Math.Abs(offsetX);
            var height = Math.Abs(offsetY);

            Adorner.CancelSelected();

            var rect = new Rect(left, top, width, height);
            foreach (var control in csScreen.Children.OfType<MonitorControl>())
            {
                if (control.Visibility == Visibility.Visible &&
                    control.Contains(rect))
                {
                    Adorner.AddMutiSelected(control.AdornerLayer);
                }
            }
        }
        #endregion

        #region 绘制控件

        /// <summary>
        /// 表示添加新控件模式
        /// </summary>
        public void AddElementModel()
        {
            if (AddElementCanvas.Visibility != Visibility.Visible)
            {
                AddElementCanvas.SetValue(CustomCursor.CustomProperty, true);
                AddElementCanvas.Visibility = Visibility.Visible;
                GridScreen.MouseLeftButtonDown -= GridScreen_MouseLeftButtonDown;
                GridScreen.MouseLeftButtonDown -= AddElementCanvas_MouseLeftButtonDown;
                GridScreen.MouseLeftButtonDown += AddElementCanvas_MouseLeftButtonDown;
                GridScreen.MouseLeftButtonUp -= AddElementCanvas_MouseLeftButtonUp;
                GridScreen.MouseLeftButtonUp += AddElementCanvas_MouseLeftButtonUp;
                GridScreen.MouseRightButtonDown -= GridScreen_MouseRightButtonDown;
            }
        }

        /// <summary>
        /// 表示添加新控件模式
        /// </summary>
        public void UnAddElementModel()
        {
            if (AddElementCanvas.Visibility != Visibility.Collapsed)
            {
                AddElementCanvas.Visibility = Visibility.Collapsed;
                AddElementCanvas.SetValue(CustomCursor.CustomProperty, false);
                GridScreen.MouseLeftButtonDown -= GridScreen_MouseLeftButtonDown;
                GridScreen.MouseLeftButtonDown += GridScreen_MouseLeftButtonDown;
                GridScreen.MouseLeftButtonDown -= AddElementCanvas_MouseLeftButtonDown;
                GridScreen.MouseLeftButtonUp -= AddElementCanvas_MouseLeftButtonUp;
                GridScreen.MouseRightButtonDown += GridScreen_MouseRightButtonDown;
            }
        }

        private Point _originPoint;
        private void AddElementCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AddElementCanvas.CaptureMouse();
            _originPoint = e.GetPosition(csScreen);
            AddElementRectangle.SetValue(Canvas.LeftProperty, _originPoint.X);
            AddElementRectangle.SetValue(Canvas.TopProperty, _originPoint.Y);
            AddElementRectangle.SetValue(HeightProperty, 0d);
            AddElementRectangle.SetValue(WidthProperty, 0d);
            AddElementRectangle.Visibility = Visibility.Visible;
            AddElementCanvas.MouseMove -= AddElementCanvas_MouseMove;
            AddElementCanvas.MouseMove += AddElementCanvas_MouseMove;
        }

        private void AddElementCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AddElementCanvas.MouseMove -= AddElementCanvas_MouseMove;

            AddElementCanvas.ReleaseMouseCapture();

            AddElementRectangle.Visibility = Visibility.Collapsed;

            var point = e.GetPosition(csScreen);
            var offsetX = point.X - _originPoint.X;
            var offsetY = point.Y - _originPoint.Y;
            var left = offsetX < 0 ? point.X : _originPoint.X;
            var top = offsetY < 0 ? point.Y : _originPoint.Y;
            var width = Math.Abs(offsetX);
            var height = Math.Abs(offsetY);

            if (width > 0 && height > 0)
            {
                if (null != Adorner.CurrenttoolTipControl
                    && Adorner.CurrenttoolTipControl.Contains(left, top))
                {
                    var position = Adorner.CurrenttoolTipControl.GetPosition();
                    // 添加到ToolTipControl区域
                    var monitor = AddSelectControlElement(Adorner.CurrenttoolTipControl.ToolTipCanvas, width, height, left - position.X, top - position.Y);
                    if (null != monitor
                        && null != monitor.AdornerLayer)
                    {
                        monitor.ParentControl = Adorner.CurrenttoolTipControl;
                        monitor.AllowToolTip = false;
                        monitor.ClearValue(Canvas.ZIndexProperty);
                        monitor.AdornerLayer.AllToolTip = false;
                    }
                    if (null != monitor.ScreenElement)
                    {
                        monitor.ScreenElement.ElementType = "ToolTip";
                    }
                }
                else
                {
                    // 判断是否有背景框
                    var children = csScreen.Children.ToArray().Reverse();
                    foreach (var child in children)
                    {
                        var backgrondControl = child as BackgroundControl;
                        if (null != backgrondControl && backgrondControl.Contains(left, top))
                        {
                            var position = backgrondControl.GetPosition();
                            // 添加到ToolTipControl区域
                            var monitor = AddSelectControlElement(backgrondControl.BackgroundCanvas, width, height, left - position.X, top - position.Y);

                            monitor.ParentControl = backgrondControl;
                            if (null != monitor
                                && null != monitor.AdornerLayer)
                            {
                                monitor.AllowToolTip = false;
                                monitor.ClearValue(Canvas.ZIndexProperty);
                                monitor.AdornerLayer.AllToolTip = false;
                            }
                            if (null != monitor.ScreenElement)
                            {
                                monitor.ScreenElement.ElementType = "Background";
                            }
                            PropertyMain.Instance.ResetSelected();
                            GalleryControl.Instance.ResetSelected();
                            return;
                        }
                    }
                    // 其他正常控件
                    AddSelectControlElement(this.csScreen, width, height, left, top);
                }
            }

            PropertyMain.Instance.ResetSelected();
            GalleryControl.Instance.ResetSelected();
        }

        private void AddElementCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            var transform = csScreen.TransformToVisual(GridScreen).Transform(new Point());
            var point = e.GetPosition(csScreen);
            var offsetX = point.X - _originPoint.X;
            var offsetY = point.Y - _originPoint.Y;
            AddElementRectangle.SetValue(Canvas.LeftProperty, (offsetX < 0 ? point.X : _originPoint.X));
            AddElementRectangle.SetValue(Canvas.TopProperty, (offsetY < 0 ? point.Y : _originPoint.Y));
            AddElementRectangle.SetValue(WidthProperty, Math.Abs(offsetX));
            AddElementRectangle.SetValue(HeightProperty, Math.Abs(offsetY));
        }

        #endregion

        #region 实例化
        ///// <summary>
        ///// 弹出属性窗口控件
        ///// </summary>
        //FloatableWindow fwProperty;
        //PropertyMain prop = new PropertyMain();

        int LoadCommpleteNumber = 0;
        /// <summary>
        /// 错误信息
        /// </summary>
        string ErrorMsg = string.Empty;
        /// <summary>
        /// 系统初使化，初始化属性窗口
        /// </summary>
        private void Init()
        {
            //加载场景
            _DataContext.Load(_DataContext.GetT_ScreenQuery(), LoadScreenCompleted, null);
            //加载参数
            _DataContext.Load(_DataContext.GetT_MonitorSystemParamQuery(), LoadParmCompleted, null);

            _DataContext.Load(_DataContext.GetT_Element_LibraryQuery(), LoadElement_LibraryCompleted, null);

            _DataContext.Load(_DataContext.GetT_ElementProperty_LibraryQuery(), LoadElementProperty_LibraryCompleted, null);
           //加载控件属性
            _DataContext.Load(_DataContext.GetT_ControlPropertyQuery(), LoadControlPropertyCompleted, null);

           // _DataContext.Load(_DataContext.GetT_Element_RealTimeLineQuery().Where(a=> a.ElementID== 

            ////实例化属性窗口
            //fwProperty = new FloatableWindow();
            //fwProperty.ParentLayoutRoot = LayoutRoot;//LayoutRoot;
            //fwProperty.Content = prop;
            //prop.Height = 420d;
            //fwProperty.Width = 300d;
            //fwProperty.Height = 450d;
            //fwProperty.Title = "场景";
            //fwProperty.SetValue(Canvas.ZIndexProperty, 900);
            //fwProperty.SetValue(Canvas.TopProperty,80d);
            //AddElementCanvas.SetValue(Canvas.ZIndexProperty, 800);
          
            //this.SizeChanged += (o, e) => {
               
            //    fwProperty.RenderTransform = new CompositeTransform()
            //    {
            //        TranslateX = (e.NewSize.Width - fwProperty.Width)/2d  - 25d,
            //        TranslateY = (e.NewSize.Height - fwProperty.Height)/2d + 120d
            //    };
            //};
            //fwProperty.Closed += (o, e) => { prop.ResetSelected(); };

            this.SizeChanged += LoadScreen_SizeChanged;
        }

        private void LoadScreen_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var width = 280d;
            var height = (e.NewSize.Height - 65d) * 0.8d;
            var left = e.NewSize.Width - width - 20d;
            var top = (e.NewSize.Height - 65d) * 0.1d + 65d;
            DesignFloatPanel.Width = width;
            DesignFloatPanel.Height = height;
            DesignFloatPanel.Left = left;
            DesignFloatPanel.Top = top;

            UpdateThumbnail(e.NewSize);
        }

        private void UpdateThumbnail(Size size)
        {
            
        }

        #region 实例化其它参数
        private void InitOther()
        {
            _DataCV.Load(_DataCV.GetT_DeviceQuery().Where(a => a.StationID == this._CurrentScreen.StationID.Value), LoadDeviceListComplete, null);
        }

        public void LoadDeviceListComplete(LoadOperation<t_Device> result)
        {
            if (result.HasError)
            {
                MessageBox.Show(result.Error.Message, "出错啦", MessageBoxButton.OK);
                return;
            }
            timerRefrshValue.Start();
        }
        #endregion

        #region 加载场景
        
        #region 加载数据 完成处理 当前共五项 t_Element_Library、t_ElementProperty_Library、t_Screen、t_MonitorSystemParam、t_ControlProperty

        /// <summary>
        /// 加载数据完成检查
        /// </summary>
        private void InitComplete()
        {
            if (LoadCommpleteNumber != 5)
                return;
            else
            {
                if (!string.IsNullOrEmpty(ErrorMsg))
                {
                    tbWait.IsBusy = false;
                    MessageBox.Show(ErrorMsg.Replace("\"", ""));
                    return;
                }
            }
            SetDefultScreen();
            //初使化定时器
            int MonitorTime=SystemParam.MonitorRefreshTime.Value;
            if(MonitorTime <=0)
                MonitorTime=5;
            timerRefrshValue.Interval = new TimeSpan(0, 0, MonitorTime);
            timerRefrshValue.Tick += new EventHandler(timer_Tick);
            if (_CurrentScreen != null)
            {
                ISBack = false;
                LoadScreenData(_CurrentScreen);
            }
            //实例化其它参数
            InitOther();
        }

        private void LoadElement_LibraryCompleted(LoadOperation<t_Element_Library> result)
        {
            if (result.HasError)
            {
                LoadCommpleteNumber++;
                ErrorMsg += "无法元素属性Lib数据！\n";
                InitComplete();
                return;
            }

            LoadCommpleteNumber++;
            InitComplete();
        }

        private void LoadElementProperty_LibraryCompleted(LoadOperation<t_ElementProperty_Library> result)
        {
            if (result.HasError)
            {
                LoadCommpleteNumber++;
                ErrorMsg += "无法加载元素属性数据！\n";
                InitComplete();
                return;
            }

            LoadCommpleteNumber++;
            InitComplete();
        }

        /// <summary>
        /// 加载参数完成！
        /// </summary>
        /// <param name="result"></param>
        private void LoadParmCompleted(LoadOperation<t_MonitorSystemParam> result)
        {
            if (result.HasError)
            {
                LoadCommpleteNumber++;
                ErrorMsg += "无法加载系统参数数据！\n";
                InitComplete();
                return;
            }
            if (result.Entities.Count() == 0)
            {
                ErrorMsg += "未设置系统参数！\n";
            }
            else
            {
                SystemParam = result.Entities.First();
            }
            LoadCommpleteNumber++;
            InitComplete();
        }
         /// <summary>
        /// 加载参数完成！
        /// </summary>
        /// <param name="result"></param>
        private void LoadControlPropertyCompleted(LoadOperation<t_ControlProperty> result)
        {
            if (result.HasError)
            {
                LoadCommpleteNumber++;
                ErrorMsg += "无法加载控件属性数据！\n";
                InitComplete();
                return;
            }
            LoadCommpleteNumber++;
            InitComplete();
        }

        private void LoadScreenCompleted(LoadOperation<t_Screen> result)
        {
            if (result.HasError)
            {
                LoadCommpleteNumber++;
                ErrorMsg += "无法加载场景数据！\n";
                InitComplete();
                return;
            }
            listScreen = result.Entities;
            InitMenuScript();
            LoadCommpleteNumber++;
            InitComplete();
        }

        private void InitMenuScript()
        {
            var roots = listScreen.Where(s => s.ParentScreenID == 0);
            foreach (var s in roots)
            {
                AllSencesMenuScriptItem.Items.Add(InitMenuScriptItem(s));
            }
        }

        public MenuScriptItem InitMenuScriptItem(t_Screen screen)
        {
            var menuItem = new MenuScriptItem();
            menuItem.Header = screen.ScreenName;
            var children = listScreen.Where(s => s.ParentScreenID == screen.ScreenID);
            if (children.Count() > 0)
            {
                foreach (var s in children)
                {
                    menuItem.Items.Add(InitMenuScriptItem(s));
                }
            }
            menuItem.Command = _SenceCommand;
            menuItem.CommandParameter = screen;
            return menuItem;
        }


        private readonly DelegateCommand<t_Screen> _SenceCommand;

        private void LoadSence(t_Screen screen)
        {
            ISBack = false;
            LoadScreenData(screen);
        }
        #endregion

       
         /// <summary>
        /// 从listScreen中选择默认场景 
        /// </summary>
        private void SetDefultScreen()
        {
            if (listScreen == null)
                return;
            if (listScreen.Count() == 0)
            {
                _CurrentScreen = null;
                return;
            }
            if (SystemParam == null)
            {
                MessageBox.Show("加载系统参数出错，无法显示！", "温馨提示:", MessageBoxButton.OK);
                return;
            }
            var v = listScreen.Where(a => a.ScreenID == SystemParam.StartScreenID);
            if (v.Count() == 0)
            {
                _CurrentScreen = listScreen.First();
                return;
            }
            _CurrentScreen = v.First();
            MainPage = _CurrentScreen;
        }

        /// <summary>
        /// 是否显示保存成功提示
        /// </summary>
        Boolean IsShowSaveToot = false;
        /// <summary>
        /// 属性窗口，打开场景事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        protected void prop_ChangeScreen(object sender,EventArgs args)
        {
            ScreenArgs mobj = (ScreenArgs)args;
            _CurrentScreen = mobj.Screen;

            if (_CurrentScreen != null)
            {
                if (MessageBox.Show("确定当前改动吗？", "提示", MessageBoxButton.OKCancel)
                    == MessageBoxResult.OK)
                {
                    IsShowSaveToot = false;
                    SaveElement();
                }
                else
                {
                    ISBack = false;
                    LoadScreenData(_CurrentScreen);
                }
            }
            
        }
        #endregion

        #region 定时更新值
        

        protected void timer_Tick(object sender, EventArgs e)
        {
            LoadChanncelValue();
        }

        private void LoadChanncelValue()
        {
            EntityQuery<V_ScreenMonitorValue> v = _DataContext.GetScreenMonitorValueQuery(_CurrentScreen.ScreenID);

            _DataContext.Load(v, ValueLoadComplete, null);
        }

        public void ValueLoadComplete(LoadOperation<V_ScreenMonitorValue> result)
        {
            if (result.HasError)
                return;
            float digitalValue = 0f;
            foreach (V_ScreenMonitorValue obj in result.Entities)
            {
                var vobj = (MonitorControl)this.csScreen.FindName(obj.ElementID.ToString());
                if (null != vobj)
                {
                    SetChannelValue(digitalValue, obj, vobj);
                    if (vobj.ToolTipControl != null)
                    {
                        var child = (MonitorControl)vobj.ToolTipControl.ToolTipCanvas.FindName(obj.ElementID.ToString());
                        SetChannelValue(digitalValue, obj, child);
                    }
                    if (vobj is BackgroundControl)
                    {
                        var backgroundControl = vobj as BackgroundControl;
                        var child = (MonitorControl)backgroundControl.BackgroundCanvas.FindName(obj.ElementID.ToString());
                        SetChannelValue(digitalValue, obj, child);
                    }
                }
            }
            _DataContext.V_ScreenMonitorValues.Clear();
        }

        private void SetChannelValue(float digitalValue, V_ScreenMonitorValue obj, MonitorControl vobj)
        {
            if (vobj == null)
            {
                return;
            }

            if (vobj is RealTimeT)
            {
                (vobj as RealTimeT).SetLineValue(obj);
                return;
            }

            if (vobj.ScreenElement.DeviceID.Value != -1 && vobj.ScreenElement.ChannelNo.Value != -1)
            {
                float fValue;
                if (float.TryParse(obj.MonitorValue.ToString(), out fValue))
                {
                    if (vobj.ScreenElement.ElementName == "DigitalBiaoPan")
                    {
                        digitalValue = fValue;
                        vobj.SetChannelValue(fValue);
                    }
                    else if (vobj.ScreenElement.ElementName == "DrawLine")
                    {
                        vobj.SetChannelValue(fValue, digitalValue);
                    }
                    else
                    {
                        vobj.SetChannelValue(fValue);
                    }
                }
            }
        }
        #endregion

        //ScreenView _ScreenView = new ScreenView();
        /// <summary>
        /// 加载场景
        /// </summary>
        /// <param name="_Screen"></param>
        private void LoadScreenData(t_Screen _Screen)
        {
            //每次在数据库中去查询次
            var v = LoadScreen._DataContext.t_Screens.Where(a => a.ScreenID == _Screen.ScreenID);

            if (v.Count() > 0)
            {
                _Screen = v.First();
            }
            else
            {
                MessageBox.Show("场景不存在！", "温馨提示", MessageBoxButton.OK);
                return;
            }
            
            if (ReturnScreen != null)
            {
                if (_Screen.ScreenID != ReturnScreen.ScreenID)
                {
                    if (!ISBack)
                    {
                        LoadScreenList.Push(ReturnScreen);
                    }
                    ReturnScreen = _Screen;
                }
            }
            else
            {
                ReturnScreen = _Screen;
            }

            _ScreenView.ScreenInit(_Screen);
            double sfPerw =200/ _ScreenView.Width;
            double sfPerh = 150 / _ScreenView.Height;
            if (sfPerh < sfPerw)
                sfPerw = sfPerh;
            ScaleTransform mainShowCanvasScaleTrans = new ScaleTransform();            
            mainShowCanvasScaleTrans.CenterX = 0.0;
            mainShowCanvasScaleTrans.CenterY = 0.0;
            mainShowCanvasScaleTrans.ScaleX = sfPerw;
            mainShowCanvasScaleTrans.ScaleY = sfPerw;
            _ScreenView.RenderTransform = mainShowCanvasScaleTrans;
            

            tbWait.IsBusy = true;

            csScreen.Children.OfType<MonitorControl>().ToList().ForEach(mc => mc.UnDesignMode());

            ScreenAllElement.Clear();
            csScreen.Children.Clear();
            lblShowMsg.Content = _Screen.ScreenName;

           // BackgroundPanel.BgImagePath = _Screen.ImageURL;
            
            //AddElementCanvas.Width = csScreen.Width = 1000;
            //AddElementCanvas.Height = csScreen.Height =600;

            SetScreenImg(_Screen.ImageURL);

            AddElementCanvas.Width = csScreen.Width = (_Screen.Width.HasValue && _Screen.Width > 100d) ? _Screen.Width.Value : 1920;
            AddElementCanvas.Height = csScreen.Height = (_Screen.Height.HasValue && _Screen.Height > 100d) ? _Screen.Height.Value : 1024;
            UpdateThumbnail();

            //设置当前
            _CurrentScreen = _Screen;
            
            _DataContext.Load(_DataContext.GetT_Element_RealTimeLineQuery().Where(a => a.ScreenID == _Screen.ScreenID)
                , LoadElementRealtimeLineCompleted, null);
            //加载元素
            _DataContext.Load(_DataContext.GetT_ElementsByScreenIDQuery(_Screen.ScreenID),
                LoadElementCompleted, _Screen.ScreenID);

            _sacleIndex = 5;
            CanvasScaleTransform.ScaleX = 1d;
            CanvasScaleTransform.ScaleY = 1d;
            CanvasTranslateTransform.X = 0d;
            CanvasTranslateTransform.Y = 0d;
        }

        /// <summary>
        /// 加载元素
        /// </summary>
        /// <param name="result"></param>
        private void LoadElementCompleted(LoadOperation<t_Element> result)
        {
            if (result.HasError)
            {
                tbWait.IsBusy = false;
                MessageBox.Show(result.Error.Message);
                return;
            }
            _DataContext.Load(_DataContext.GetScreenElementPropertyQuery(Convert.ToInt32(result.UserState)),
                LoadElementPropertiesCompleted, result.UserState);
        }

        private void LoadElementRealtimeLineCompleted(LoadOperation<t_Element_RealTimeLine> result)
        {
           //int Count= result.Entities.Count();
           //MessageBox.Show(Count.ToString());
            //暂未做处理
        }
       
        /// <summary>
        /// 加载，元素属性完成
        /// </summary>
        /// <param name="result"></param>
        private void LoadElementPropertiesCompleted(LoadOperation<t_ElementProperty> result)
        {
            if (result.HasError)
            {
                tbWait.IsBusy = false;
                MessageBox.Show(result.Error.Message);
                return;
            }
            List<t_Element> lsitElement = _DataContext.t_Elements.Where(a => a.ScreenID == Convert.ToInt32(result.UserState) && null == a.ParentID).ToList();

            //_ScreenView.Width = 200;
            //_ScreenView.Height = 200;
            //csScreen.Children.Add(_ScreenView);

            ShowElements(lsitElement, csScreen);
            //如果不是组态，打开定时器
            //if (CBIsztControl.IsChecked == false)
            if(IsZT)
            {
                timerRefrshValue.Start();
            }
            tbWait.IsBusy = false;
        }

        private void ShowElements(List<t_Element> lsitElement, Canvas canvas, MonitorControl parentContol = null)
        {
            foreach (t_Element el in lsitElement)
            {
                var list = _DataContext.t_ElementProperties.Where(a => a.ElementID == el.ElementID);
                var monitorControl = ShowElement(canvas, el, ElementSate.Save, list.ToList());

                _ScreenView.ShowElement( el, ElementSate.Save, list.ToList());

                if (null != monitorControl && null != parentContol)
                {
                    monitorControl.ParentControl = parentContol;
                    monitorControl.AllowToolTip = false;
                    monitorControl.ClearValue(Canvas.ZIndexProperty);
                    if (null != monitorControl.AdornerLayer)
                    {
                        monitorControl.AdornerLayer.AllToolTip = false;
                    }
                }
                //_ScreenView.AddEletemt(monitorControl);
                ScreenAllElement.Add(el);
            }
        }
        #endregion

        #region 将元素显示到场景
        /// <summary>
        /// 显示元素
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="eleStae"></param>
        /// <param name="listObj"></param>
        /// <returns></returns>
        public MonitorControl ShowElement(Canvas canvas, t_Element obj, ElementSate eleStae, List<t_ElementProperty> listObj)
        {
            try
            {
                if (obj.ImageURL != null && obj.ImageURL.IndexOf("MonitorSystem") == 0)
                {
                    MonitorControl instance = (MonitorControl)Activator.CreateInstance(Type.GetType(obj.ImageURL));
                    //var instance = Activator.CreateInstance(Type.GetType(t.ImageURL));
                    SetEletemt(canvas, instance, obj, eleStae, listObj);
                    return instance;
                }
                else
                {
                    switch (obj.ElementName)
                    {
                        case "MyButton":
                            TP_Button mtpButtom = new TP_Button();
                            SetEletemt(canvas, mtpButtom, obj, eleStae, listObj);
                            return mtpButtom;
                        //break;
                        case "MonitorLine":
                            MonitorLine mPubLine = new MonitorLine();
                            SetEletemt(canvas, mPubLine, obj, eleStae, listObj);
                            return mPubLine;
                        //break;
                        case "MonitorText":
                            MonitorText mPubText = new MonitorText();
                            mPubText.MyText = obj.TxtInfo;
                            SetEletemt(canvas, mPubText, obj, eleStae, listObj);
                            return mPubText;
                        //break;
                        case "ColorText":
                            ColorText mColorText = new ColorText();
                            SetEletemt(canvas, mColorText, obj, eleStae, listObj);
                            return mColorText;
                        //break;
                        case "InputTextBox":
                            InputTextBox mInputTextBox = new InputTextBox();
                            mInputTextBox.MyText = obj.TxtInfo;
                            SetEletemt(canvas, mInputTextBox, obj, eleStae, listObj);
                            return mInputTextBox;
                        //break;
                        case "ButtonCtrl":
                            ButtonCtrl mButtonCtrl = new ButtonCtrl();
                            mButtonCtrl.MyText = obj.TxtInfo;
                            SetEletemt(canvas, mButtonCtrl, obj, eleStae, listObj);
                            return mButtonCtrl;
                        //break;
                        case "MonitorCur":
                            MonitorCur mPubCur = new MonitorCur();
                            SetEletemt(canvas, mPubCur, obj, eleStae, listObj);
                            return mPubCur;
                        //break;
                        case "MonitorRectangle":
                            MonitorRectangle mPubRec = new MonitorRectangle();
                            SetEletemt(canvas, mPubRec, obj, eleStae, listObj);
                            return mPubRec;
                        //break;
                        case "MonitorGrid":
                            MonitorGrid mPubGrid = new MonitorGrid();
                            SetEletemt(canvas, mPubGrid, obj, eleStae, listObj);
                            return mPubGrid;
                        //break;
                        case "FoldLine":
                            MonitorFoldLine mPubFoldLine = new MonitorFoldLine();
                            SetEletemt(canvas, mPubFoldLine, obj, eleStae, listObj);
                            return mPubFoldLine;
                        //break;
                        case "Temprary":
                            Temprary mTemprary = new Temprary();
                            SetEletemt(canvas, mTemprary, obj, eleStae, listObj);
                            return mTemprary;
                        case "DLBiaoPan":
                            DLBiaoPan mDLBiaoPan = new DLBiaoPan();
                            obj.Width = 2 * obj.Height.Value;
                            SetEletemt(canvas, mDLBiaoPan, obj, eleStae, listObj);
                            return mDLBiaoPan;
                        case "DigitalBiaoPan":
                            DigitalBiaoPan mDigitalBiaoPan = new DigitalBiaoPan();
                            SetEletemt(canvas, mDigitalBiaoPan, obj, eleStae, listObj);
                            return mDigitalBiaoPan;
                        case "Switch":
                            Switch mSwitch = new Switch();
                            SetEletemt(canvas, mSwitch, obj, eleStae, listObj);
                            return mSwitch;
                        case "SignalSwitch":
                            SignalSwitch mSignalSwitch = new SignalSwitch();
                            obj.Width = obj.Height;
                            SetEletemt(canvas, mSignalSwitch, obj, eleStae, listObj);
                            return mSignalSwitch;
                        case "DetailSwitch":
                            DetailSwitch mDetailSwitch = new DetailSwitch();
                            SetEletemt(canvas, mDetailSwitch, obj, eleStae, listObj);
                            return mDetailSwitch;
                        case "RealTimeCurve":
                            RealTimeCurve mRealTime = new RealTimeCurve();
                            SetEletemt(canvas, mRealTime, obj, eleStae, listObj);
                            return mRealTime;
                        case "TableCtrl":
                            TableCtrl mTableCtrl = new TableCtrl();
                            SetEletemt(canvas, mTableCtrl, obj, eleStae, listObj);
                            return mTableCtrl;
                        case "zedGraphCtrl":
                            zedGraphCtrl mzedGraphCtrl = new zedGraphCtrl();
                            SetEletemt(canvas, mzedGraphCtrl, obj, eleStae, listObj);
                            return mzedGraphCtrl;
                        case "zedGraphLineCtrl":
                            zedGraphLineCtrl mzedGraphLineCtrl = new zedGraphLineCtrl();
                            SetEletemt(canvas, mzedGraphLineCtrl, obj, eleStae, listObj);
                            return mzedGraphLineCtrl;
                        case "zedGraphPieCtrl":
                            zedGraphPieCtrl mzedGraphPieCtrl = new zedGraphPieCtrl();
                            SetEletemt(canvas, mzedGraphPieCtrl, obj, eleStae, listObj);
                            return mzedGraphPieCtrl;
                        case "MyLine"://曲线
                            MyLine mMyLine = new MyLine();
                            SetEletemt(canvas, mMyLine, obj, eleStae, listObj);
                            return mMyLine;
                        case "BackgroundRect"://背景
                            BackgroundRect mBackgroundRect = new BackgroundRect();
                            SetEletemt(canvas, mBackgroundRect, obj, eleStae, listObj);
                            return mBackgroundRect;
                        case "PicBox"://窗口式背景控件
                            PicBox mPicBox = new PicBox();
                            SetEletemt(canvas, mPicBox, obj, eleStae, listObj);
                            return mPicBox;
                        case "DrawLine"://窗口式背景控件
                            DrawLine mDrawLine = new DrawLine();
                            SetEletemt(canvas, mDrawLine, obj, eleStae, listObj);
                            return mDrawLine;
                        case "ExtProControl"://窗口式背景控件
                            ExtProControl mExtProControl = new ExtProControl();
                            SetEletemt(canvas, mExtProControl, obj, eleStae, listObj);
                            return mExtProControl;
                        case "DimorphismGraphCtrl"://窗口式背景控件
                            DimorphismGraphCtrl mDimorphismGraphCtrl = new DimorphismGraphCtrl();
                            SetEletemt(canvas, mDimorphismGraphCtrl, obj, eleStae, listObj);
                            return mDimorphismGraphCtrl;
                        case "BackgroundControl":
                            BackgroundControl backgroundControl = new BackgroundControl();
                            SetEletemt(canvas, backgroundControl, obj, eleStae, listObj);
                            var childElements = _DataContext.t_Elements.Where(e => e.ParentID == obj.ElementID && e.ElementType == "Background").ToList();
                            ShowElements(childElements, backgroundControl.BackgroundCanvas, backgroundControl);
                            return backgroundControl;                       
                        default:
                            string url = string.Format("/MonitorSystem;component/Images/ControlsImg/{0}", obj.ImageURL);
                            BitmapImage bitmap = new BitmapImage(new Uri(url, UriKind.Relative));
                            ImageSource mm = bitmap;
                            TP mtp = new TP();
                            mtp.Source = mm;
                            SetEletemt(canvas, mtp, obj, eleStae, listObj);
                            return mtp;


                        //break;
                    }
                }
            }
            catch
            {
                return null;
            }
        }

        private void SetEletemt(Canvas canvas, MonitorControl mControl, t_Element obj, ElementSate eleStae,
            List<t_ElementProperty> listObj)
        {
            mControl.Selected += (o, e) =>
            {
                PropertyMain.Instance.ControlPropertyGrid.SelectedObject = null;
                PropertyMain.Instance.ControlPropertyGrid.BrowsableProperties = mControl.BrowsableProperties;
                PropertyMain.Instance.ControlPropertyGrid.SelectedObject = mControl; 
            };
            if (eleStae == ElementSate.Save)
            {
                mControl.Name = obj.ElementID.ToString();
            }
            mControl.ScreenElement = obj;
            mControl.ListElementProp = listObj;
            mControl.ElementState = eleStae;

            //if (eleStae == ElementSate.Save)
            //{
            //    mControl.Name = obj.ElementID.ToString();
            //}
            mControl.SetPropertyValue();
            mControl.SetCommonPropertyValue();
            //添加到场景
            canvas.Children.Add(mControl);

            //if (CBIsztControl.IsChecked.Value)
            if (IsZT)
            {
                mControl.DesignMode();
            }
        }
        #endregion

        /// <summary>
        /// 从设计中选择的控件并在场景中，画的控件 
        /// </summary>
        /// <param name="mWidth"></param>
        /// <param name="mHeight"></param>
        /// <param name="mMagrinX"></param>
        /// <param name="mMagrinY"></param>
        private MonitorControl AddSelectControlElement(Canvas canvas, double mWidth, double mHeight, double mMagrinX, double mMagrinY)
        {
            var t = GetSelectControl();
            if (null != t)
            {
                return CreateControl(canvas, t, mWidth, mHeight, mMagrinX, mMagrinY);
            }
            return null;
        }

        public MonitorControl CreateControl(Canvas canvas, t_Control t, double width, double height, double x, double y)
        {
            if (t != null && t.ControlID > 0)
            {
                t_Element mElement = InitElement(t);

                mElement.Width = (int)width;
                mElement.Height = (int)height;
                mElement.ScreenX = (int)x;
                mElement.ScreenY = (int)y;
                mElement.ScreenID = _CurrentScreen.ScreenID;

                IEnumerable<t_ControlProperty> listObj = _DataContext.t_ControlProperties.
                    Where(a => a.ControlID == t.ControlID);
                List<t_ElementProperty> listElementPro = new List<t_ElementProperty>();
                foreach (t_ControlProperty cp in listObj)
                {
                    t_ElementProperty tt = new t_ElementProperty();
                    tt.Caption = cp.Caption;
                    tt.ElementID = mElement.ElementID;
                    tt.PropertyNo = cp.PropertyNo;
                    tt.PropertyValue = cp.DefaultValue;
                    tt.PropertyName = cp.PropertyName;
                    listElementPro.Add(tt);
                }

                var monitorControl = ShowElement(canvas, mElement, ElementSate.New, listElementPro);
                monitorControl.DesignMode();
                return monitorControl;
            }
            return null;
        }

        #region  画控件
        /// <summary>
        /// 获取属性框，选中组件。
        /// </summary>
        /// <returns></returns>
        private t_Control GetSelectControl()
        {
            var t = GalleryControl.Instance.GetSelected();
            if (null == t)
            {
                return PropertyMain.Instance.GetSelected();
            }
            return t;
        }

        /// <summary>
        /// 初使化Element
        /// </summary>
        /// <param name="tCon"></param>
        /// <returns></returns>
        public t_Element InitElement(t_Control tCon)
        {
            t_Element mElem = new t_Element();
            mElem.ChildScreenID = "0";
            mElem.ControlID = tCon.ControlID;
            mElem.ElementName = tCon.ControlName;
            mElem.ImageURL = tCon.ImageURL;
            mElem.TxtInfo = "";
            mElem.ForeColor = "RGB(0,0,0)";
            mElem.Font = "宋体";   
            mElem.DeviceID = -1;
            mElem.ChannelNo = -1;
            mElem.BackColor = "RGB(255,255,255)";
            mElem.Transparent =100;
            mElem.oldX = 0;
            mElem.oldY =0;
            mElem.Method =0;
            mElem.MinFloat = 0;
            mElem.MaxFloat = 0;
            //mElem.SerialNum = "";
            //mElem.TotalLength = "";
            if (tCon.ImageURL == "MonitorSystem.Other.RealTimeT")
            {
                mElem.BackColor = "#FFEBE8D9";
                mElem.ForeColor = "#FFD5D5FF";
            }
            mElem.LevelNo = 1;
            mElem.ComputeStr = "";
            return mElem;
        }
        #endregion

        ///// <summary>
        ///// 属性窗口改变大小时发生
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void f_SizeChanged(object sender, SizeChangedEventArgs e)
        //{
        //    prop.ChangeSize(e.NewSize.Height, e.NewSize.Width);
        //}
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            IsShowSaveToot = true;//显示保存成功提示
            SaveElement();
        }

        #region 添加元素，处理鼠标事件

        //Point mStartPoint;
        //bool IsDown = false;
        //Rectangle RC = new Rectangle();
        //private void Content_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //     t_Control t = GetSelectControl();
        //     if (t != null && t.ControlID > 0)
        //     {
        //         IsDown = true;
        //         var point = e.GetPosition(this);

        //         RC.Visibility = Visibility.Visible;
        //         mStartPoint = point;

        //         RC.Width = 0;
        //         RC.Height = 0;
        //         RC.Margin = new Thickness(point.X, point.Y - 35, 0, 0);
        //     }
           
        //}

        //private void Content_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //    if (IsDown && CBIsztControl.IsChecked.Value)
        //    {
        //        double mMagrinX = mStartPoint.X;
        //        double mMagrinY = mStartPoint.Y - 35;

        //        var mEndPoint = e.GetPosition(this);
        //        double mWidth = mEndPoint.X - mStartPoint.X;
        //        if (mWidth < 0)
        //        {
        //            mWidth = mStartPoint.X - mEndPoint.X;
        //            mMagrinX = mEndPoint.X;
        //        }
        //        double mHeight = mEndPoint.Y - mStartPoint.Y;
        //        if (mHeight < 0)
        //        {
        //            mHeight = mStartPoint.Y - mEndPoint.Y;
        //            mMagrinY = mEndPoint.Y - 35;
        //        }
        //        if (mWidth > 0 && mHeight > 0 && mMagrinX > 0 && mMagrinY > 0)
        //        {
        //            AddSelectControlElement(mWidth, mHeight, mMagrinX, mMagrinY);
        //        }

        //        PropertyMain.Instance.ResetSelected();
        //    }
        //    IsDown = false;
        //    RC.Visibility = Visibility.Collapsed;
        //}
        //private void Content_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (IsDown)
        //    {
        //        var EndPoint = e.GetPosition(this);
        //        SetRCProperty(EndPoint);
        //    }
        //}

        //private void SetRCProperty(Point mEndPoint)
        //{

        //    double mWidth = mEndPoint.X - mStartPoint.X;
        //    if (mWidth < 0)
        //    {
        //        mWidth = mStartPoint.X - mEndPoint.X;
        //    }            
        //    double mHeight = mEndPoint.Y - mStartPoint.Y;
        //    if (mHeight < 0)
        //    {
        //        mHeight = mStartPoint.Y - mEndPoint.Y;               
        //    }
           
        //    RC.Width = mWidth;
        //    RC.Height = mHeight;
        //}
        #endregion      

        #region 保存场景及元素、属性

        List<MonitorControl> listMonitorAddElement = new List<MonitorControl>();
        List<MonitorControl> listMonitorModifiedElement = new List<MonitorControl>();
        //int AddElementNumber = 0;
        private void SaveElement()
        {
            try
            {
                //保存背景图片
                //var vScreen = _DataContext.t_Screens.Where(a => a.ScreenID == _CurrentScreen.ScreenID);
                //if (vScreen.Count() > 0)
                //{
                //    t_Screen m_screen = vScreen.First();
                //    m_screen.ImageURL = BackgroundPanel.BgImagePath;
                //}

                //循环所有存在元素
                listMonitorAddElement.Clear();
                listMonitorModifiedElement.Clear();
                tbWait.IsBusy = true;
                for (int i = 0; i < csScreen.Children.Count; i++)
                {
                    var m = csScreen.Children[i] as MonitorControl;

                    if (null != m && !m.IsToolTip)
                    {
                        var el = m.ElementState;
                        var meleObj = m.ScreenElement;
                        meleObj.Width = Convert.ToInt32(m.Width);
                        meleObj.Height = Convert.ToInt32(m.Height);
                        meleObj.ScreenX = Convert.ToInt32(m.GetValue(Canvas.LeftProperty));
                        meleObj.ScreenY = Convert.ToInt32(m.GetValue(Canvas.TopProperty));

                        if (el == ElementSate.New)
                        {
                            m.ScreenElement = meleObj;
                            _DataContext.t_Elements.Add(meleObj); // 2个必须同步添加
                            listMonitorAddElement.Add(m);// 2个必须同步添加
                            m.ElementState = ElementSate.Save;
                        }
                        else
                        {
                            CheckElementChange(meleObj);

                            var removeProperties = _DataContext.t_ElementProperties.Where(p => p.ElementID == meleObj.ElementID).ToList();
                            foreach (var removeProperty in removeProperties)
                            {
                                _DataContext.t_ElementProperties.Remove(removeProperty);
                            }

                            // 删除子属性
                            if (m is RealTimeT)
                            {
                                var removeElements = _DataContext.t_Element_RealTimeLines.Where(r => r.ElementID == meleObj.ElementID).ToList();

                                foreach (var removeElement in removeElements)
                                {
                                    _DataContext.t_Element_RealTimeLines.Remove(removeElement);
                                }
                            }

                            listMonitorModifiedElement.Add(m); // 同修改同步
                        }

                        #region ToolTip

                        var toolTipControl = m.ToolTipControl;

                        if (null != toolTipControl && toolTipControl.ToolTipCanvas.Children.Count > 0)
                        {
                            Debug.Assert(null != toolTipControl.Target, "ToolTipControl 的 Target 属性不能为null.");
                            Debug.Assert(null != toolTipControl.Target.ScreenElement, "ToolTipControl 的 Target.ScreenElement 属性不能为null.");

                            var toolTipElement = toolTipControl.ScreenElement.Clone();

                            toolTipElement.Width = Convert.ToInt32(toolTipControl.Width);
                            toolTipElement.Height = Convert.ToInt32(toolTipControl.Height);

                            if (el != ElementSate.New)
                            {
                                RemoveOldProperties(meleObj, "ToolTip");
                                toolTipElement.ParentID = meleObj.ElementID;
                                toolTipElement.ScreenID = meleObj.ScreenID;
                            }
                            else
                            {
                                toolTipElement.ScreenID = null;
                                toolTipElement.ParentID = meleObj.ElementID;
                            }

                            _DataContext.t_Elements.Add(toolTipElement.Clone());// 2个必须同步添加

                            listMonitorAddElement.Add(toolTipControl);// 2个必须同步添加
                            AddChildControl(toolTipControl.ToolTipCanvas, el, meleObj);
                        }

                        #endregion

                        #region 背景框
                        if (m is BackgroundControl)
                        {
                            var backgroundControl = m as BackgroundControl;
                            if (el == ElementSate.Save)
                            {
                                RemoveOldProperties(meleObj, "Background");
                            }

                            AddChildControl(backgroundControl.BackgroundCanvas, el, meleObj);
                        }
                        #endregion
                    }
                }

                //循环已添加的属性
                foreach (t_Element mEle in ScreenAllElement)
                {
                    var v = csScreen.FindName(mEle.ElementID.ToString());
                    if (v == null)
                    {
                        if (_DataContext.t_Elements.Contains(mEle))
                        {
                            _DataContext.t_Elements.Remove(mEle);

                            var removeProperties = _DataContext.t_ElementProperties.Where(p => p.ElementID == mEle.ElementID).ToList();
                            foreach (var removeProperty in removeProperties)
                            {
                                _DataContext.t_ElementProperties.Remove(removeProperty);
                            }

                            // 删除子 RealTimeT 属性
                            var removeElements = _DataContext.t_Element_RealTimeLines.Where(r => r.ElementID == mEle.ElementID);

                            foreach (var removeElement in removeElements)
                            {
                                _DataContext.t_Element_RealTimeLines.Remove(removeElement);
                            }

                            RemoveOldProperties(mEle, "ToolTip"); // 删除ToolTip子元素及其子元素的属性
                            RemoveOldProperties(mEle, "Background"); // 删除Background子元素及其子元素的属性
                        }
                    }
                }

                if (_DataContext.HasChanges)
                {
                    _DataContext.SubmitChanges(SubmitCompleted, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("保存场景失败，错误信息：{0}", ex.Message));
                tbWait.IsBusy = false;
            }
        }

        private static void RemoveOldProperties(t_Element meleObj, string elementType)
        {
            var removeElements = _DataContext.t_Elements.Where(t => t.ParentID == meleObj.ElementID && t.ElementType == elementType).ToList();
            // 删除老的ToolTip\子控件，及他们的老属性
            foreach (var removeElement in removeElements)
            {
                _DataContext.t_Elements.Remove(removeElement);
                // 删除属性
                var removeProperties = _DataContext.t_ElementProperties.Where(p => p.ElementID == removeElement.ElementID).ToList();
                foreach (var removeProperty in removeProperties)
                {
                    _DataContext.t_ElementProperties.Remove(removeProperty);
                }
            }
        }

        private void AddChildControl(Canvas canvas, ElementSate el, t_Element meleObj)
        {
            // 添加子控件
            foreach (var child in canvas.Children)
            {
                var childMoinitor = child as MonitorControl;
                if (null != childMoinitor)
                {
                    // 保存ToolTip 子控件
                    var childElement = childMoinitor.ScreenElement.Clone();
                    childElement.Width = Convert.ToInt32(childMoinitor.Width);
                    childElement.Height = Convert.ToInt32(childMoinitor.Height);
                    childElement.ScreenX = (int)Canvas.GetLeft(childMoinitor);
                    childElement.ScreenY = (int)Canvas.GetTop(childMoinitor);
                    if (el != ElementSate.New)
                    {
                        childElement.ParentID = meleObj.ElementID;
                        childElement.ScreenID = meleObj.ScreenID;
                    }
                    else
                    {
                        childElement.ScreenID = null;
                    }
                    if (_DataContext.t_Elements.Contains(childElement))
                    {
                        _DataContext.t_Elements.Remove(childElement);
                    }

                    _DataContext.t_Elements.Add(childElement.Clone());// 2个必须同步添加
                    listMonitorAddElement.Add(childMoinitor);// 2个必须同步添加
                }
            }
        }

        /// <summary>
        /// 提交元素完成。
        /// </summary>
        /// <param name="result"></param>
        private void SubmitCompleted(SubmitOperation result)
        {
            if (!result.HasError)
            {
                EntityChangeSet obj = result.ChangeSet;
                if (obj.AddedEntities.Count == 0 && listMonitorModifiedElement.Count == 0)
                {
                    tbWait.IsBusy = false;
                    if (IsShowSaveToot)
                    {
                        IsShowSaveToot = false;
                        MessageBox.Show("保存成功！", "温馨提示", MessageBoxButton.OK);
                    }
                    ISBack = false;
                    LoadScreenData(_CurrentScreen);
                    return;
                }

                var parentID = 0;
                var screenID = 0;
                // 新增
                if (obj.AddedEntities.Count == listMonitorAddElement.Count)
                {
                    for (int i = 0; i < obj.AddedEntities.Count; i++)
                    {
                        var addElement = obj.AddedEntities[i] as t_Element;
                        var addMonitorControl = listMonitorAddElement[i];
                        var listProperties = listMonitorAddElement[i].ListElementProp;

                        if (addElement.ControlID.HasValue
                            && addElement.ControlID.Value != -9999
                            && addElement.ScreenID.HasValue)
                        {
                            parentID = addElement.ElementID;
                            screenID = addElement.ScreenID.Value;
                        }
                        else if (!addElement.ScreenID.HasValue)
                        {
                            var editElment = _DataContext.t_Elements.FirstOrDefault(t => t.ElementID == addElement.ElementID);
                            if (null != editElment)
                            {
                                editElment.ParentID = parentID;
                                editElment.ScreenID = screenID;
                            }
                        }

                        if (addMonitorControl is RealTimeT)
                        {
                            var addRealTimeT = addMonitorControl as RealTimeT;
                            foreach (var line in addRealTimeT.ListRealTimeLine)
                            {
                                line.LineInfo.ScreenID = _CurrentScreen.ScreenID;
                                line.LineInfo.ElementID = addElement.ElementID;
                                _DataContext.t_Element_RealTimeLines.Add(line.LineInfo.Clone());
                            }
                        }

                        foreach (var ep in listProperties)
                        {
                            ep.ElementID = addElement.ElementID;
                            _DataContext.t_ElementProperties.Add(ep.Clone());
                        }
                    }
                }

                foreach (var monitorControl in listMonitorModifiedElement)
                {
                    var modifiedElement = monitorControl.ScreenElement;

                    if (monitorControl is RealTimeT)
                    {
                        var addRealTimeT = monitorControl as RealTimeT;
                        foreach (var line in addRealTimeT.ListRealTimeLine)
                        {
                            line.LineInfo.ScreenID = _CurrentScreen.ScreenID;
                            line.LineInfo.ElementID = monitorControl.ScreenElement.ElementID;
                            _DataContext.t_Element_RealTimeLines.Add(line.LineInfo.Clone());
                        }
                    }

                    foreach (var ep in monitorControl.ListElementProp)
                    {
                        ep.ElementID = modifiedElement.ElementID;
                        _DataContext.t_ElementProperties.Add(ep.Clone());
                    }
                }

                if (_DataContext.HasChanges)
                {
                    _DataContext.SubmitChanges(SubmitPropertyCompleted, null);
                }
            }
            else
            {
                tbWait.IsBusy = false;
            }
        }
        /// <summary>
        /// 提交元素完成
        /// </summary>
        /// <param name="result"></param>
        private void SubmitPropertyCompleted(SubmitOperation result)
        {
            tbWait.IsBusy = false;
            //AddElementNumber++;
            //if (listMonitorAddElement.Count <= AddElementNumber)
            if(!result.HasError)
            {
                if (IsShowSaveToot)
                {
                    IsShowSaveToot = false;
                    MessageBox.Show("保存成功！", "温馨提示", MessageBoxButton.OK);
                }
                ISBack = false;
                LoadScreenData(_CurrentScreen);
                return;
            }
            //t_Element elem = listMonitorAddElement[AddElementNumber].ScreenElement;
            //_DataContext.t_Elements.Add(elem);
            //_DataContext.SubmitChanges(SubmitCompleted, null);
        }

        /// <summary>
        /// 检查更新字段并赋值
        /// </summary>
        /// <param name="mobj"></param>
        private void CheckElementChange(t_Element mobj)
        {
            var vobj = _DataContext.t_Elements.Where(a => a.ElementID == mobj.ElementID);
            if (vobj.Count() > 0)
                return;
            t_Element saveEle = vobj.First();

            if (saveEle.ScreenX != mobj.ScreenX)
                saveEle.ScreenX = mobj.ScreenX;
            if (saveEle.ScreenY != mobj.ScreenY)
                saveEle.ScreenY = mobj.ScreenY;
            if (saveEle.TxtInfo != mobj.TxtInfo)
                saveEle.TxtInfo = mobj.TxtInfo;
            if (saveEle.Width != mobj.Width)
                saveEle.Width = mobj.Width;
            if (saveEle.Height != mobj.Height)
                saveEle.Height = mobj.Height;
            if (saveEle.ImageURL != mobj.ImageURL)
                saveEle.ImageURL = mobj.ImageURL;
            if (saveEle.ForeColor != mobj.ForeColor)
                saveEle.ForeColor = mobj.ForeColor;
            if (saveEle.Font != mobj.Font)
                saveEle.Font = mobj.Font;
            if (saveEle.ChildScreenID != mobj.ChildScreenID)
                saveEle.ChildScreenID = mobj.ChildScreenID;
            if (saveEle.DeviceID != mobj.DeviceID)
                saveEle.DeviceID = mobj.DeviceID;
            if (saveEle.ChannelNo != mobj.ChannelNo)
                saveEle.ChannelNo = mobj.ChannelNo;
            if (saveEle.ScreenID != mobj.ScreenID)
                saveEle.ScreenID = mobj.ScreenID;
            if (saveEle.BackColor != mobj.BackColor)
                saveEle.BackColor = mobj.BackColor;
            if (saveEle.Transparent != mobj.Transparent)
                saveEle.Transparent = mobj.Transparent;
            if (saveEle.oldX != mobj.oldX)
                saveEle.oldX = mobj.oldX;
            if (saveEle.oldY != mobj.oldY)
                saveEle.oldY = mobj.oldY;
            if (saveEle.Method != mobj.Method)
                saveEle.Method = mobj.Method;
            if (saveEle.MinFloat != mobj.MinFloat)
                saveEle.MinFloat = mobj.MinFloat;
            if (saveEle.MaxFloat != mobj.MaxFloat)
                saveEle.MaxFloat = mobj.MaxFloat;
            if (saveEle.SerialNum != mobj.SerialNum)
                saveEle.SerialNum = mobj.SerialNum;
            if (saveEle.TotalLength != mobj.TotalLength)
                saveEle.TotalLength = mobj.TotalLength;
            if (saveEle.LevelNo != mobj.LevelNo)
                saveEle.LevelNo = mobj.LevelNo;
            if (saveEle.ComputeStr != mobj.ComputeStr)
                saveEle.ComputeStr = mobj.ComputeStr;
        }
        #endregion
     

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (null == HtmlPage.Window.Invoke("fullScreen"))
                {
                    System.Windows.Application.Current.Host.Content.IsFullScreen =
                        !System.Windows.Application.Current.Host.Content.IsFullScreen;
                }
            }
            catch (InvalidOperationException ie)
            {
                MessageBox.Show(ie.Message);
            }
        }

        protected void Screen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.V)
            {
                if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
                {
                    //var copyMonitor = CoptyObj as MonitorControl;
                    if (null != CopyArray)
                    {
                        foreach (var obj in CopyArray)
                        {
                            var canvas = csScreen;
                            if (obj.ParentControl is BackgroundControl)
                            {
                                canvas = (obj.ParentControl as BackgroundControl).BackgroundCanvas;
                            }
                            else if (obj.ParentControl is ToolTipControl)
                            {
                                canvas = (obj.ParentControl as ToolTipControl).ToolTipCanvas;
                            }
                            var monitor = ShowElement(canvas, obj.Element, ElementSate.New, obj.ListElementProperty);
                            if (null != obj.ParentControl)
                            {
                                monitor.ParentControl = obj.ParentControl;
                                monitor.DesignMode();
                                monitor.AllowToolTip = false;
                                monitor.ClearValue(Canvas.ZIndexProperty);
                                if (null != monitor.AdornerLayer)
                                {
                                    monitor.AdornerLayer.AllToolTip = false;
                                }

                                if (null != monitor.ScreenElement
                                    && null != obj.ParentControl.ScreenElement)
                                {
                                    monitor.ScreenElement.ElementType = obj.Element.ElementType;
                                    monitor.ScreenElement.ParentID = obj.ParentControl.ScreenElement.ElementID;
                                    monitor.ScreenElement.ScreenID = obj.ParentControl.ScreenElement.ScreenID;
                                }
                            }
                        }
                    }
                }
            }
            else if (e.Key == Key.C)
            {
                if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
                {
                    Adorner.CopyAll();
                }
            }
            else if (e.Key == Key.X)
            {
                if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
                {
                    Adorner.CopyAll();
                    Adorner.DeleteAll();
                }
            }
            else if (e.Key == Key.A)
            {
                if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
                {
                    Adorner.SelectAll();
                }
            }
            else if (e.Key == Key.Delete)
            {
                Adorner.DeleteAll();
            }
        }
            

        #region 菜单事件
        private void TP_Click(object sender, RoutedEventArgs e)
        {
            // 组态设计
            OpartionMenuScriptItem.Visibility = Visibility.Visible;
            ZTMenuScriptItem.Visibility = Visibility.Collapsed;
            AllSencesMenuScriptItem.Visibility = Visibility.Collapsed;
            GalleryButton.Visibility = Visibility.Visible;
            DesignButton.Visibility = Visibility.Visible;
            DesignFloatPanel.IsOpened = true;
            IsZT = true;

            GridScreen.MouseRightButtonDown -= GridScreen_MouseRightButtonDown;
            GridScreen.MouseRightButtonDown += GridScreen_MouseRightButtonDown;
                       
            //加截属性窗口
            //fwProperty.SizeChanged += new SizeChangedEventHandler(f_SizeChanged);
            //prop.ChangeScreen += new EventHandler(prop_ChangeScreen);
            //fwProperty.Show();
            //鼠标事件
            this.KeyDown += new KeyEventHandler(Screen_KeyDown);

            var children = csScreen.Children.ToArray();
            foreach (var child in children)
            {
                if (child is MonitorControl && !(child is ToolTipControl))
                {
                    var mControl = child as MonitorControl;
                    mControl.DesignMode();
                    if (null != mControl.ToolTipControl)
                    {
                        mControl.ToolTipControl.DesignMode();
                    }
                }
            }

            //for (int i = 0; i < csScreen.Children.Count; i++)
            //{
            //    var ui = csScreen.Children[i];
            //    if (ui is MonitorControl)
            //    {
            //        MonitorControl mControl = ui as MonitorControl;
            //        mControl.DesignMode();
            //    }
            //}
            //定时更新值关闭
            timerRefrshValue.Stop();
        }

        private void SaveCurrentSence_Click(object sender, RoutedEventArgs e)
        {
            // 保存当前场景
            IsShowSaveToot = true;//显示保存成功提示
            SaveElement();
        }
        
        private void ZTExit_Click(object sender, RoutedEventArgs e)
        {
            // 退出组态
            OpartionMenuScriptItem.Visibility = Visibility.Collapsed;
            ZTMenuScriptItem.Visibility = Visibility.Visible;
            AllSencesMenuScriptItem.Visibility = Visibility.Visible;
            GalleryButton.Visibility = Visibility.Collapsed;
            DesignButton.Visibility = Visibility.Collapsed;
            DesignFloatPanel.IsOpened = false;
            GalleryFloatPanel.IsOpened = false;
            IsZT = false;

            GridScreen.MouseRightButtonDown -= GridScreen_MouseRightButtonDown;

            this.KeyDown -= new KeyEventHandler(Screen_KeyDown);

            if (MessageBox.Show("是否保存对场景的修改！\r\n确定：保存。\r\n取消：不保存，修改的内容将被取消。", "", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                SaveElement();
            }
            else
            {
                ISBack = false;
                LoadScreenData(_CurrentScreen);
            }
          
            var children = csScreen.Children.ToArray();
            foreach (var child in children)
            {
                if (child is MonitorControl && !(child is ToolTipControl))
                {
                    var mControl = child as MonitorControl;
                    mControl.UnDesignMode();
                    if (null != mControl.ToolTipControl)
                    {
                        mControl.ToolTipControl.UnDesignMode();
                    }
                }
            }
            //fwProperty.SizeChanged -= new SizeChangedEventHandler(f_SizeChanged);
            //prop.ChangeScreen -= new EventHandler(prop_ChangeScreen);
            //fwProperty.Close();

            //定时更新值开启
            timerRefrshValue.Start();
        }

        private void Top_Click(object sender, MouseButtonEventArgs e)
        {
            MainScript.CloseAllItems();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            // 首页
            if (MainPage != null)
            {
                if(_CurrentScreen != null)
                {
                    if(MainPage.ScreenID== _CurrentScreen.ScreenID)
                        return;
                }
                ISBack = false;
                LoadScreenData(MainPage);
            }
        }
        /// <summary>
        /// 是否为返回加载
        /// </summary>
        private static bool ISBack = false;
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            ISBack = true;
            // 后退
            if (LoadScreenList != null && LoadScreenList.Count > 0)
            {
                t_Screen mscreen = LoadScreenList.Pop();
                //IsPop = true;
                LoadScreenData(mscreen);
            }
        }

        Size mBackSize;
        Size mcsScreenSize;
        private void BackgroundPanel_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            mBackSize = e.NewSize;
        }

        private void csScreen_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            mcsScreenSize = e.NewSize;
        }

        #endregion

        private void GalleryButton_Click(object sender, RoutedEventArgs e)
        {
            GalleryFloatPanel.IsOpened = !GalleryFloatPanel.IsOpened;
        }

        private void DesignButton_Click(object sender, RoutedEventArgs e)
        {
            DesignFloatPanel.IsOpened = !DesignFloatPanel.IsOpened;
        }

        private readonly double[] ScaleArray = new[] { 0.1d, 0.15d, 0.25d, 0.5d, 0.75d, 1.0d, 1.25d, 1.50d, 2.0d, 3.0d, 5.0d };
        private int _sacleIndex = 5;
        private void GridScreen_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            var point = e.GetPosition(GridScreen);
            if (e.Delta > 0 && _sacleIndex < ScaleArray.Length - 1)
            {
                ++_sacleIndex;
                ScaleCanvas(point);
            }
            else if(e.Delta < 0 && _sacleIndex > 1)
            {
                --_sacleIndex;
                ScaleCanvas(point);
            }
        }

        private void ScaleCanvas(Point point)
        {
            ScaleTextBlock.Text = string.Format("{0}%", ScaleArray[_sacleIndex] * 100);
            CanvasScaleTransform.ScaleX = CanvasScaleTransform.ScaleY = ScaleArray[_sacleIndex];
            CanvasScaleTransform.CenterX = point.X - CanvasTranslateTransform.X;
            CanvasScaleTransform.CenterY = point.Y - CanvasTranslateTransform.Y;

            AddElementCanvas.RenderTransform = csScreen.RenderTransform;
            UpdateThumbnail();
        }


        private void GridScreen_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GridScreen.CaptureMouse();

            _originPoint = e.GetPosition(GridScreen);

            _originPoint.X -= CanvasTranslateTransform.X;
            _originPoint.Y -= CanvasTranslateTransform.Y;

            GridScreen.MouseMove -= GridScreen_MouseMove;
            GridScreen.MouseMove += GridScreen_MouseMove;
            GridScreen.MouseLeftButtonUp -= GridScreen_MouseLeftButtonUp;
            GridScreen.MouseLeftButtonUp += GridScreen_MouseLeftButtonUp;
        }

        private void GridScreen_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            GridScreen.MouseMove -= GridScreen_MouseMove;
            GridScreen.MouseLeftButtonUp -= GridScreen_MouseLeftButtonUp;
            GridScreen.ReleaseMouseCapture();
        }

        private void GridScreen_MouseMove(object sender, MouseEventArgs e)
        {
            var point = e.GetPosition(GridScreen);
            CanvasTranslateTransform.X = point.X - _originPoint.X;
            CanvasTranslateTransform.Y = point.Y - _originPoint.Y;

            AddElementCanvas.RenderTransform = csScreen.RenderTransform;
            UpdateThumbnail();
        }

        private void UpdateThumbnail()
        {
            var borderWidth = ThumbnailBorder.Width - 2d;
            var borderHeight = ThumbnailBorder.Height - 2d;
            var canvasWidth = csScreen.Width * CanvasScaleTransform.ScaleX;
            var canvasHeight = csScreen.Height * CanvasScaleTransform.ScaleY;
            var viewWidth = GridScreen.ActualWidth;
            var viewHeight = GridScreen.ActualHeight;
            var thumbnailViewWidth = 0d;
            var thumbnailViewHeight = 0d;
            var thumbnailWidth = 0d;
            var thumbnailHeight = 0d;
            var left = 0d;
            var top = 0d;
            if (canvasHeight / canvasWidth > borderHeight / borderWidth)
            {
                thumbnailViewHeight = borderHeight;
                thumbnailViewWidth = borderHeight * canvasWidth / canvasHeight;
            }
            else
            {
                thumbnailViewWidth = borderWidth;
                thumbnailViewHeight = borderWidth * canvasHeight / canvasWidth;
            }
            thumbnailWidth = viewWidth * thumbnailViewWidth / canvasWidth;
            thumbnailHeight = viewHeight * thumbnailViewHeight / canvasHeight;

            if (thumbnailWidth > thumbnailViewWidth)
            {
                thumbnailWidth = thumbnailViewWidth;
            }

            if (thumbnailHeight > thumbnailViewHeight)
            {
                thumbnailHeight = thumbnailViewHeight;
            }

            left = -(CanvasTranslateTransform.X + (1d - CanvasScaleTransform.ScaleX) * CanvasScaleTransform.CenterX) * thumbnailViewWidth / canvasWidth;
            top = -(CanvasTranslateTransform.Y + (1d - CanvasScaleTransform.ScaleY) * CanvasScaleTransform.CenterY) * thumbnailViewHeight / canvasHeight;

            ThumbnailCanvas.Width = thumbnailViewWidth;
            ThumbnailCanvas.Height = thumbnailViewHeight;
            ThumbnailRectangle.Width = thumbnailWidth;
            ThumbnailRectangle.Height = thumbnailHeight;
            ThumbnailRectangle.SetValue(Canvas.LeftProperty, left);
            ThumbnailRectangle.SetValue(Canvas.TopProperty, top);
        }

        private void ThumbnailBorder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ThumbnailBorder.CaptureMouse();

            var point = e.GetPosition(ThumbnailCanvas);

            SetThumbnailToCenter(point);

            ThumbnailBorder.MouseMove -= ThumbnailBorder_MouseMove;
            ThumbnailBorder.MouseMove += ThumbnailBorder_MouseMove;
            ThumbnailBorder.MouseLeftButtonUp -= ThumbnailBorder_MouseLeftButtonUp;
            ThumbnailBorder.MouseLeftButtonUp += ThumbnailBorder_MouseLeftButtonUp;
            e.Handled = true;
        }

        private void ThumbnailBorder_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ThumbnailBorder.MouseMove -= ThumbnailBorder_MouseMove;
            ThumbnailBorder.MouseLeftButtonUp -= ThumbnailBorder_MouseLeftButtonUp;
            ThumbnailBorder.ReleaseMouseCapture();
            e.Handled = true;
        }

        private void ThumbnailBorder_MouseMove(object sender, MouseEventArgs e)
        {
            var point = e.GetPosition(ThumbnailCanvas);
            SetThumbnailToCenter(point);
        }

        private void SetThumbnailToCenter(Point point)
        {
            var canvasWidth = csScreen.Width * CanvasScaleTransform.ScaleX;
            var canvasHeight = csScreen.Height * CanvasScaleTransform.ScaleY;
            var thumbnailViewWidth = ThumbnailCanvas.Width;
            var thumbnailViewHeight = ThumbnailCanvas.Height;
            var thumbnailWidth = ThumbnailRectangle.Width;
            var thumbnailHeight = ThumbnailRectangle.Height;

            var left = point.X - thumbnailWidth / 2d;
            var top = point.Y - thumbnailHeight / 2d;
            ThumbnailRectangle.SetValue(Canvas.LeftProperty, left);
            ThumbnailRectangle.SetValue(Canvas.TopProperty, top);


            CanvasScaleTransform.CenterX = 0d;
            CanvasScaleTransform.CenterY = 0d;
            CanvasTranslateTransform.X  = - left * canvasWidth / thumbnailViewWidth;
            CanvasTranslateTransform.Y = -top* canvasHeight / thumbnailViewHeight;
        }
    }
}

