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

        public static MonitorControl CoptyObj=null;
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
            AddElementCanvas.MouseLeftButtonDown += AddElementCanvas_MouseLeftButtonDown;
            AddElementCanvas.MouseLeftButtonUp += AddElementCanvas_MouseLeftButtonUp;
            csScreen.AddHandler(FrameworkElement.MouseLeftButtonDownEvent, new MouseButtonEventHandler(CsScreen_MouseLeftButtonDown), false);
            csScreen.VerticalAlignment = VerticalAlignment.Top;
            csScreen.HorizontalAlignment = HorizontalAlignment.Left;
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


            string gbUrl = string.Format("{0}/Upload/ImageMap/{1}", Common.TopUrl(), screen.ImageURL);
            BitmapImage bitmap = new BitmapImage(new Uri(gbUrl, UriKind.Absolute));
            bitmap.ImageOpened += new EventHandler<RoutedEventArgs>(bitmap_ImageOpened);
            ImageBrush imgB = new ImageBrush();
            imgB.ImageSource = bitmap;
            csScreen.Background = imgB;
          
        }

        public void SetScreenImg(string strImg)
        {
            string gbUrl = string.Format("{0}/Upload/ImageMap/{1}", Common.TopUrl(), strImg);
            BitmapImage bitmap = new BitmapImage(new Uri(gbUrl, UriKind.Absolute));
            bitmap.ImageOpened += new EventHandler<RoutedEventArgs>(bitmap_ImageOpened);
            
            ImageBrush imgB = new ImageBrush();
            imgB.ImageSource = bitmap;

            csScreen.Background = imgB;
        }

        private string _BgImagePath;
        private const string PATH = "ImageMap";
        [Image(PATH, OnlyImage = true)]
        public string BgImagePath
        {
            set
            {
                _BgImagePath = value;
                _CurrentScreen.ImageURL = value;
                SetScreenImg(value);
            }
            get
            {
                return _BgImagePath;
            }
        }
        
        //SceneBackgroundPanel b = new SceneBackgroundPanel();
        private void CsScreen_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Adorner.CancelSelected();
            HideFocusElement.Focus();

            PropertyMain.Instance.ControlPropertyGrid.SelectedObject = null;
            PropertyMain.Instance.ControlPropertyGrid.BrowsableProperties = new []{"BgImagePath"};
            _BgImagePath = _CurrentScreen.ImageURL;
            PropertyMain.Instance.ControlPropertyGrid.SelectedObject =this; 

        }
        #endregion

        #region 绘制控件

        /// <summary>
        /// 表示添加新控件模式
        /// </summary>
        public static void AddElementModel()
        {
            if (null != _instance && _instance.AddElementCanvas.Visibility != Visibility.Visible)
            {
                _instance.AddElementCanvas.SetValue(CustomCursor.CustomProperty, true);
                _instance.AddElementCanvas.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// 表示添加新控件模式
        /// </summary>
        public static void UnAddElementModel()
        {
            if (null != _instance && _instance.AddElementCanvas.Visibility != Visibility.Collapsed)
            {
                _instance.AddElementCanvas.Visibility = Visibility.Collapsed;
                _instance.AddElementCanvas.SetValue(CustomCursor.CustomProperty, false);
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
                AddSelectControlElement(width, height, left, top);
            }

            PropertyMain.Instance.ResetSelected();
        }

        private void AddElementCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            var point = e.GetPosition(csScreen);
            var offsetX = point.X - _originPoint.X;
            var offsetY = point.Y - _originPoint.Y;
            AddElementRectangle.SetValue(Canvas.LeftProperty, offsetX < 0 ? point.X : _originPoint.X);
            AddElementRectangle.SetValue(Canvas.TopProperty, offsetY < 0 ? point.Y : _originPoint.Y);
            AddElementRectangle.SetValue(WidthProperty, Math.Abs(offsetX));
            AddElementRectangle.SetValue(HeightProperty, Math.Abs(offsetY));
        }

        #endregion

        #region 实例化
        /// <summary>
        /// 弹出属性窗口控件
        /// </summary>
        FloatableWindow fwProperty;
        PropertyMain prop = new PropertyMain();

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

            //实例化属性窗口
            fwProperty = new FloatableWindow();
            fwProperty.ParentLayoutRoot = LayoutRoot;//LayoutRoot;
            fwProperty.Content = prop;
            prop.Height = 420d;
            fwProperty.Width = 300d;
            fwProperty.Height = 450d;
            fwProperty.Title = "场景";
            fwProperty.SetValue(Canvas.ZIndexProperty, 900);
            fwProperty.SetValue(Canvas.TopProperty,80d);
            AddElementCanvas.SetValue(Canvas.ZIndexProperty, 800);
          
            this.SizeChanged += (o, e) => {
               
                fwProperty.RenderTransform = new CompositeTransform()
                {
                    TranslateX = (e.NewSize.Width - fwProperty.Width)/2d  - 25d,
                    TranslateY = (e.NewSize.Height - fwProperty.Height)/2d + 120d
                };
            };
            fwProperty.Closed += (o, e) => { prop.ResetSelected(); };
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
                if (vobj == null)
                    continue;
                if (vobj.ScreenElement.DeviceID.Value != -1 && vobj.ScreenElement.ChannelNo.Value != -1)
                {
                    float fValue = float.Parse(obj.MonitorValue.ToString());
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
            _DataContext.V_ScreenMonitorValues.Clear();
        }
        #endregion

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
            

            tbWait.IsBusy = true;

            csScreen.Children.OfType<MonitorControl>().ToList().ForEach(mc => mc.UnDesignMode());

            ScreenAllElement.Clear();
            csScreen.Children.Clear();
            lblShowMsg.Content = _Screen.ScreenName;

           // BackgroundPanel.BgImagePath = _Screen.ImageURL;
            
            AddElementCanvas.Width = csScreen.Width = 1000;
            AddElementCanvas.Height = csScreen.Height =600;

            string gbUrl = string.Format("{0}/Upload/ImageMap/{1}", Common.TopUrl(), _Screen.ImageURL);
            BitmapImage bitmap = new BitmapImage(new Uri(gbUrl, UriKind.Absolute));
            bitmap.ImageOpened += new EventHandler<RoutedEventArgs>(bitmap_ImageOpened);
            ImageBrush imgB = new ImageBrush();
            imgB.ImageSource = bitmap;
            csScreen.Background = imgB;

            
            //设置当前
            _CurrentScreen = _Screen;
            //加载元素
            _DataContext.Load(_DataContext.GetT_ElementQuery().Where(a => a.ScreenID == _Screen.ScreenID),
                LoadElementCompleted, _Screen.ScreenID);
        }

        private void bitmap_ImageOpened<TEventArgs>(object sender, TEventArgs e)
        {
            BitmapImage bi = (BitmapImage)sender;
            if (bi.PixelWidth > 500 && bi.PixelHeight > 500)
            {
                var width = (double)bi.PixelWidth;
                var height = (double)bi.PixelHeight;
                if (width > 1024d || height > 768d)
                {
                    var scale = height / width;
                    if (scale > 0.75d)
                    {
                        height = 768d;
                        width = 768d / scale;
                    }
                    else
                    {
                        width = 1024d;
                        height = 1024d * scale;
                    }
                }

                AddElementCanvas.Width = csScreen.Width = width;
                AddElementCanvas.Height = csScreen.Height = height;
            }
            //double h = bi.PixelHeight;
            //double w = bi.PixelWidth;
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
            List<t_Element> lsitElement = _DataContext.t_Elements.Where(a => a.ScreenID == Convert.ToInt32(result.UserState)).ToList();
            foreach (t_Element el in lsitElement)
            {
                var list = _DataContext.t_ElementProperties.Where(a => a.ElementID == el.ElementID);
                ShowElement(el, ElementSate.Save, list.ToList());
                ScreenAllElement.Add(el);
            }
            //如果不是组态，打开定时器
            //if (CBIsztControl.IsChecked == false)
            if(IsZT)
            {
                timerRefrshValue.Start();
            }
            tbWait.IsBusy = false;
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
        private MonitorControl ShowElement(t_Element obj, ElementSate eleStae, List<t_ElementProperty> listObj)
        {
            if (obj.ImageURL != null && obj.ImageURL.IndexOf("MonitorSystem") == 0)
            {
                MonitorControl instance = (MonitorControl)Activator.CreateInstance(Type.GetType(obj.ImageURL));
                //var instance = Activator.CreateInstance(Type.GetType(t.ImageURL));
                SetEletemt(instance, obj, eleStae, listObj);
                return instance;
            }
            else
            {
                switch (obj.ElementName)
                {
                    case "MyButton":
                        TP_Button mtpButtom = new TP_Button();
                        SetEletemt(mtpButtom, obj, eleStae, listObj);
                        return mtpButtom;
                    //break;
                    case "MonitorLine":
                        MonitorLine mPubLine = new MonitorLine();
                        SetEletemt(mPubLine, obj, eleStae, listObj);
                        return mPubLine;
                    //break;
                    case "MonitorText":
                        MonitorText mPubText = new MonitorText();
                        mPubText.MyText = obj.TxtInfo;
                        SetEletemt(mPubText, obj, eleStae, listObj);
                        return mPubText;
                    //break;
                    case "ColorText":
                        ColorText mColorText = new ColorText();
                        SetEletemt(mColorText, obj, eleStae, listObj);
                        return mColorText;
                    //break;
                    case "InputTextBox":
                        InputTextBox mInputTextBox = new InputTextBox();
                        mInputTextBox.MyText = obj.TxtInfo;
                        SetEletemt(mInputTextBox, obj, eleStae, listObj);
                        return mInputTextBox;
                    //break;
                    case "ButtonCtrl":
                        ButtonCtrl mButtonCtrl = new ButtonCtrl();
                        mButtonCtrl.MyText = obj.TxtInfo;
                        SetEletemt(mButtonCtrl, obj, eleStae, listObj);
                        return mButtonCtrl;
                    //break;
                    case "MonitorCur":
                        MonitorCur mPubCur = new MonitorCur();
                        SetEletemt(mPubCur, obj, eleStae, listObj);
                        return mPubCur;
                    //break;
                    case "MonitorRectangle":
                        MonitorRectangle mPubRec = new MonitorRectangle();
                        SetEletemt(mPubRec, obj, eleStae, listObj);
                        return mPubRec;
                    //break;
                    case "MonitorGrid":
                        MonitorGrid mPubGrid = new MonitorGrid();
                        SetEletemt(mPubGrid, obj, eleStae, listObj);
                        return mPubGrid;
                    //break;
                    case "FoldLine":
                        MonitorFoldLine mPubFoldLine = new MonitorFoldLine();
                        SetEletemt(mPubFoldLine, obj, eleStae, listObj);
                        return mPubFoldLine;
                    //break;
                    case "Temprary":
                        Temprary mTemprary = new Temprary();
                        SetEletemt(mTemprary, obj, eleStae, listObj);
                        return mTemprary;
                    case "DLBiaoPan":
                        DLBiaoPan mDLBiaoPan = new DLBiaoPan();
                        obj.Width = 2 * obj.Height.Value;
                        SetEletemt(mDLBiaoPan, obj, eleStae, listObj);
                        return mDLBiaoPan;
                    case "DigitalBiaoPan":
                        DigitalBiaoPan mDigitalBiaoPan = new DigitalBiaoPan();
                        SetEletemt(mDigitalBiaoPan, obj, eleStae, listObj);
                        return mDigitalBiaoPan;
                    case "Switch":
                        Switch mSwitch = new Switch();
                        SetEletemt(mSwitch, obj, eleStae, listObj);
                        return mSwitch;
                    case "SignalSwitch":
                        SignalSwitch mSignalSwitch = new SignalSwitch();
                        obj.Width = obj.Height;
                        SetEletemt(mSignalSwitch, obj, eleStae, listObj);
                        return mSignalSwitch;
                    case "DetailSwitch":
                        DetailSwitch mDetailSwitch = new DetailSwitch();
                        SetEletemt(mDetailSwitch, obj, eleStae, listObj);
                        return mDetailSwitch;
                    case "RealTimeCurve":
                        RealTimeCurve mRealTime = new RealTimeCurve();
                        SetEletemt(mRealTime, obj, eleStae, listObj);
                        return mRealTime;
                    case "TableCtrl":
                        TableCtrl mTableCtrl = new TableCtrl();
                        SetEletemt(mTableCtrl, obj, eleStae, listObj);
                        return mTableCtrl;
                    case "zedGraphCtrl":
                        zedGraphCtrl mzedGraphCtrl = new zedGraphCtrl();
                        SetEletemt(mzedGraphCtrl, obj, eleStae, listObj);
                        return mzedGraphCtrl;
                    case "zedGraphLineCtrl":
                        zedGraphLineCtrl mzedGraphLineCtrl = new zedGraphLineCtrl();
                        SetEletemt(mzedGraphLineCtrl, obj, eleStae, listObj);
                        return mzedGraphLineCtrl;
                    case "zedGraphPieCtrl":
                        zedGraphPieCtrl mzedGraphPieCtrl = new zedGraphPieCtrl();
                        SetEletemt(mzedGraphPieCtrl, obj, eleStae, listObj);
                        return mzedGraphPieCtrl;
                    case "MyLine"://曲线
                        MyLine mMyLine = new MyLine();
                        SetEletemt(mMyLine, obj, eleStae, listObj);
                        return mMyLine;
                    case "BackgroundRect"://背景
                        BackgroundRect mBackgroundRect = new BackgroundRect();
                        SetEletemt(mBackgroundRect, obj, eleStae, listObj);
                        return mBackgroundRect;
                    case "PicBox"://窗口式背景控件
                        PicBox mPicBox = new PicBox();
                        SetEletemt(mPicBox, obj, eleStae, listObj);
                        return mPicBox;
                    case "DrawLine"://窗口式背景控件
                        DrawLine mDrawLine = new DrawLine();
                        SetEletemt(mDrawLine, obj, eleStae, listObj);
                        return mDrawLine;
                    case "ExtProControl"://窗口式背景控件
                        ExtProControl mExtProControl = new ExtProControl();
                        SetEletemt(mExtProControl, obj, eleStae, listObj);
                        return mExtProControl;
                    case "DimorphismGraphCtrl"://窗口式背景控件
                        DimorphismGraphCtrl mDimorphismGraphCtrl = new DimorphismGraphCtrl();
                        SetEletemt(mDimorphismGraphCtrl, obj, eleStae, listObj);
                        return mDimorphismGraphCtrl;
                    //case "dlfh01"://电力符号
                    //    Dlfh01 dlfh01Ctrl = new Dlfh01();
                    //    SetEletemt(dlfh01Ctrl, obj, eleStae, listObj);
                    //    return dlfh01Ctrl;
                    //case "dlfh02"://电力符号
                    //    Dlfh02 dlfh02Ctrl = new Dlfh02();
                    //    SetEletemt(dlfh02Ctrl, obj, eleStae, listObj);
                    //    return dlfh02Ctrl;

                    //case "Dldz01"://电力电子
                    //    Dldz01 Dldz01Ctrl = new Dldz01();
                    //    SetEletemt(Dldz01Ctrl, obj, eleStae, listObj);
                    //    return Dldz01Ctrl;
                    //case "Dldz02"://电力电子
                    //    Dldz02 Dldz02Ctrl = new Dldz02();
                    //    SetEletemt(Dldz02Ctrl, obj, eleStae, listObj);
                    //    return Dldz02Ctrl;

                    //case "Dqfh01"://电气符号
                    //    Dqfh01 Dqfh01Ctrl = new Dqfh01();
                    //    SetEletemt(Dqfh01Ctrl, obj, eleStae, listObj);
                    //    return Dqfh01Ctrl;
                    //case "Dqfh02"://电气符号
                    //    Dqfh02 Dqfh02Ctrl = new Dqfh02();
                    //    SetEletemt(Dqfh02Ctrl, obj, eleStae, listObj);
                    //    return Dqfh02Ctrl;

                    //case "Meter1":  // 仪表1
                    //    var meter1 = new Meter1();
                    //    SetEletemt(meter1, obj, eleStae, listObj);
                    //    return meter1;
                    default:
                        string url = string.Format("/MonitorSystem;component/Images/ControlsImg/{0}", obj.ImageURL);
                        BitmapImage bitmap = new BitmapImage(new Uri(url, UriKind.Relative));
                        ImageSource mm = bitmap;
                        TP mtp = new TP();
                        mtp.Source = mm;
                        SetEletemt(mtp, obj, eleStae, listObj);
                        return mtp;


                    //break;
                }
            }
        }

        private void SetEletemt(MonitorControl mControl, t_Element obj, ElementSate eleStae,
            List<t_ElementProperty> listObj)
        {
            mControl.Selected += (o, e) =>
            {
                PropertyMain.Instance.ControlPropertyGrid.SelectedObject = null;
                PropertyMain.Instance.ControlPropertyGrid.BrowsableProperties = mControl.BrowsableProperties;
                PropertyMain.Instance.ControlPropertyGrid.SelectedObject = mControl.GetRootControl(); 
            };
            if (eleStae == ElementSate.Save)
            {
                mControl.Name = obj.ElementID.ToString();
            }
            mControl.ScreenElement = obj;
            mControl.ListElementProp = listObj;
            mControl.ElementState = eleStae;

            if (eleStae == ElementSate.Save)
            {
                mControl.Name = obj.ElementID.ToString();
            }
            mControl.SetPropertyValue();
            mControl.SetCommonPropertyValue();
            //添加到场景
            csScreen.Children.Add(mControl);

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
        private void AddSelectControlElement(double mWidth, double mHeight, double mMagrinX, double mMagrinY)
        {
            t_Control t = GetSelectControl();
            CreateControl(t, mWidth, mHeight, mMagrinX, mMagrinY);
        }

        public void CreateControl(t_Control t, double width, double height, double x, double y)
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

                ShowElement(mElement, ElementSate.New, listElementPro).DesignMode();
            }
        }

        #region  画控件
        /// <summary>
        /// 获取属性框，选中组件。
        /// </summary>
        /// <returns></returns>
        private t_Control GetSelectControl()
        {
            return PropertyMain.Instance.GetSelected();
        }

        /// <summary>
        /// 初使化Element
        /// </summary>
        /// <param name="tCon"></param>
        /// <returns></returns>
        private t_Element InitElement(t_Control tCon)
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
            mElem.Transparent =0;
            mElem.oldX = 0;
            mElem.oldY =0;
            mElem.Method =0;
            mElem.MinFloat = 0;
            mElem.MaxFloat = 0;
            //mElem.SerialNum = "";
            //mElem.TotalLength = "";
            mElem.LevelNo = 1;
            mElem.ComputeStr = "";
            return mElem;
        }
        #endregion

        /// <summary>
        /// 属性窗口改变大小时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void f_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            prop.ChangeSize(e.NewSize.Height, e.NewSize.Width);
        }
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

        List<MonitorControl> listMonitorAddElement=new List<MonitorControl>();
        int AddElementNumber = 0;
        private void SaveElement()
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
            for (int i = 0; i < csScreen.Children.Count; i++)
            {
                var ui = csScreen.Children[i];

                if (ui is MonitorControl)
                {
                    MonitorControl m = (MonitorControl)ui;
                    ElementSate el = m.ElementState;
                    t_Element meleObj = m.ScreenElement;
                    meleObj.Width = Convert.ToInt32( m.Width);
                    meleObj.Height = Convert.ToInt32( m.Height);
                    meleObj.ScreenX = Convert.ToInt32( m.GetValue(Canvas.LeftProperty));
                    meleObj.ScreenY =Convert.ToInt32( m.GetValue(Canvas.TopProperty));

                    if (el == ElementSate.New)
                    {
                        m.ScreenElement = meleObj;
                        listMonitorAddElement.Add(m);
                    }
                    else
                    {
                        CheckElementChange(meleObj);

                        //保存属性
                        List<t_ElementProperty> listPro = m.ListElementProp;
                        if (listPro != null && listPro.Count > 0)
                        {
                            foreach (t_ElementProperty cp in listPro)
                            {
                              var v  =_DataContext.t_ElementProperties.Where(a => a.ElementID == cp.ElementID &&
                                    a.PropertyNo == cp.PropertyNo);
                              if (v != null && v.Count() > 0)
                              {
                                  v.First().PropertyValue = cp.PropertyValue;
                              }
                            }//end foreach
                        }//end if (listPro
                    }
                }
            }

            //循环已添加的属性
            foreach (t_Element mEle in ScreenAllElement)
            {
               var v= csScreen.FindName(mEle.ElementID.ToString());
               if (v == null)
               {
                   _DataContext.t_Elements.Remove(mEle);
                   //移出属性
                   var vPro = _DataContext.t_ElementProperties.Where(a => a.ElementID == mEle.ElementID);
                   if (vPro.Count() > 0)
                   {
                       List<t_ElementProperty> listEp=vPro.ToList();
                       foreach (t_ElementProperty ep in listEp)
                       {
                           //_DataContext.t_ElementProperties.d
                           _DataContext.t_ElementProperties.Remove(ep);
                       }
                   }
               }
            }

            if (listMonitorAddElement.Count > 0)
            {
                AddElementNumber = 0;

                t_Element elem = listMonitorAddElement[0].ScreenElement;
                _DataContext.t_Elements.Add(elem);
                _DataContext.SubmitChanges(SubmitCompleted, null);
            }
            else
            {
                _DataContext.SubmitChanges(SubmitCompleted, null);
            }
        }

        /// <summary>
        /// 提交元素完成。
        /// </summary>
        /// <param name="result"></param>
        private void SubmitCompleted(SubmitOperation result)
        {
           EntityChangeSet obj= result.ChangeSet;
           if (obj.AddedEntities.Count == 0)
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
           foreach (var v in obj.AddedEntities)
           {
               if (v is t_Element)
               {
                   t_Element vobj = (t_Element)v;
                   


                   foreach (t_ElementProperty ep in listMonitorAddElement[AddElementNumber].ListElementProp)
                   {
                        ep.ElementID = vobj.ElementID;
                       _DataContext.t_ElementProperties.Add(ep);
                   }
                   _DataContext.SubmitChanges(SubmitPropertyCompleted,null);
               }
           }
        }
        /// <summary>
        /// 提交元素完成
        /// </summary>
        /// <param name="result"></param>
        private void SubmitPropertyCompleted(SubmitOperation result)
        {
            AddElementNumber++;
            if (listMonitorAddElement.Count <= AddElementNumber)
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
            t_Element elem = listMonitorAddElement[AddElementNumber].ScreenElement;
            _DataContext.t_Elements.Add(elem);
            _DataContext.SubmitChanges(SubmitCompleted, null);
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
            ModifierKeys keys = ModifierKeys.Control;
            if (keys == ModifierKeys.Control && e.Key == Key.V)
            {
                if (CoptyObj != null)
                {
                    ScreenElementObj mobj = new MonitorSystemGlobal.ScreenElementObj();
                    int mWidth = Convert.ToInt16(CoptyObj.Width);
                    int mHeight = Convert.ToInt16(CoptyObj.Height);
                    mobj.ElementClone((MonitorControl)CoptyObj, mWidth, mHeight);
                    ShowElement(mobj.Element, ElementSate.New, mobj.ListElementProperty);
                }              
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
            IsZT = true;
                       
            //加截属性窗口
            fwProperty.SizeChanged += new SizeChangedEventHandler(f_SizeChanged);
            prop.ChangeScreen += new EventHandler(prop_ChangeScreen);
            fwProperty.Show();
            //鼠标事件
            this.KeyDown += new KeyEventHandler(Screen_KeyDown);
           
            for (int i = 0; i < csScreen.Children.Count; i++)
            {
                var ui = csScreen.Children[i];
                if (ui is MonitorControl)
                {
                    MonitorControl mControl = ui as MonitorControl;
                    mControl.DesignMode();
                }
            }
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
            IsZT = false;

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
          
            for (int i = 0; i < csScreen.Children.Count; i++)
            {
                var ui = csScreen.Children[i];
                if (ui is MonitorControl)
                {
                    MonitorControl mControl = ui as MonitorControl;
                    mControl.UnDesignMode();
                }
            }
            fwProperty.SizeChanged -= new SizeChangedEventHandler(f_SizeChanged);
            prop.ChangeScreen -= new EventHandler(prop_ChangeScreen);
            fwProperty.Close();

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
    }
}

