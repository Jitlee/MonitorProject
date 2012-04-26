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
using System.Windows.Media.Imaging;
using MonitorSystem.MonitorSystemGlobal;
using MonitorSystem.Web.Servers;
using System.ServiceModel.DomainServices.Client;
using System.Collections.ObjectModel;

namespace MonitorSystem
{
    public partial class LoadScreen : UserControl
    {
        #region 变量 
        public static MonitorServers _DataContext = new MonitorServers();
        /// <summary>
        /// 场景列表
        /// </summary>
        public static IEnumerable<t_Screen> listScreen;

        /// <summary>
        /// 当前场景
        /// </summary>
        t_Screen _CurrentScreen;

        /// <summary>
        /// 系统参数
        /// </summary>
        t_MonitorSystemParam SystemParam;
        #endregion
        public LoadScreen()
        {
            InitializeComponent();
           
            //实例化
            Init();
            
        }
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
            fwProperty.ParentLayoutRoot = LayoutRoot;
            fwProperty.Content = prop;
           
            fwProperty.Width = 300;
            fwProperty.Height = 600;
            fwProperty.Title = "设计";
            fwProperty.MaxHeight = 600;
            fwProperty.MaxWidth = 400;
           // fwProperty.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
           // double d = Convert.ToDouble(gdContent.GetValue(Canvas.WidthProperty));
           //MessageBox.Show(d.ToString());
            double mtop = 100;
            double mLeft = 800;
            fwProperty.SetValue(Canvas.TopProperty, mtop);
            fwProperty.SetValue(Canvas.LeftProperty, mLeft);
            checkBox1.IsEnabled = true;
        }

        /// <summary>
        /// 加载数据完成检查
        /// </summary>
        private void InitComplete()
        {
            if (LoadCommpleteNumber != 4)
                return;
            else
            {
                if (!string.IsNullOrEmpty(ErrorMsg))
                {
                    MessageBox.Show(ErrorMsg.Replace("\"",""));
                    return;
                }
            }
            SetDefultScreen();
            if (_CurrentScreen != null)
            {
                LoadScreenData(_CurrentScreen);
            }
        }

        #region 加载数据 完成处理
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
            var v = listScreen.Where(a => a.ScreenID == SystemParam.StartScreenID);
            if (v.Count() == 0)
            {
                _CurrentScreen = listScreen.First();
                return;
            }
            _CurrentScreen = v.First();
        }

        /// <summary>
        /// 属性窗口，打开场景事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        protected void prop_ChangeScreen(object sender,EventArgs args)
        {
            if (_CurrentScreen != null)
            {
                if (MessageBox.Show("确定当前改动吗？", "提示", MessageBoxButton.OKCancel)
                    == MessageBoxResult.OK)
                {
                    SaveElement();
                }
            }

            ScreenArgs mobj = (ScreenArgs)args;
            _CurrentScreen = mobj.Screen;
            LoadScreenData(_CurrentScreen);
        }
        #endregion

        #region 加载场景

        /// <summary>
        /// 加载场景
        /// </summary>
        /// <param name="_Screen"></param>
        private void LoadScreenData(t_Screen _Screen)
        {
            tbWait.Visibility = Visibility.Visible;

            csScreen.Children.Clear();
            string url = string.Format("{0}/ImageMap/{1}", Common.TopUrl(), _Screen.ImageURL);
            BitmapImage bitmap = new BitmapImage(new Uri(url, UriKind.Absolute));
            ImageBrush imgB = new ImageBrush();
            imgB.ImageSource = bitmap;
           // imgB.Stretch = Stretch.Uniform;
            imgB.Stretch = Stretch.None;
            imgB.AlignmentX = AlignmentX.Left;
            imgB.AlignmentY = AlignmentY.Top;

            csScreen.Background = imgB;

            lblShowMsg.Content = _Screen.ScreenName;

            RC.SetValue(Canvas.ZIndexProperty, 1000);
            RC.Stroke = new SolidColorBrush(Colors.Black);
            csScreen.Children.Add(RC);

            //加载元素
            _DataContext.Load(_DataContext.GetT_ElementQuery().Where(a => a.ScreenID == _Screen.ScreenID),
                LoadElementCompleted, _Screen.ScreenID);

        }

        private void LoadElementCompleted(LoadOperation<t_Element> result)
        {
            if (result.HasError)
            {
                MessageBox.Show(result.Error.Message);
                return;
            }
            _DataContext.Load(_DataContext.GetScreenElementPropertyQuery(Convert.ToInt32(result.UserState)),
                LoadElementPropertiesCompleted, result.UserState);
           
        }

        private void LoadElementPropertiesCompleted(LoadOperation<t_ElementProperty> result)
        {
            if (result.HasError)
            {
                MessageBox.Show(result.Error.Message);
                return;
            }
            List<t_Element> lsitElement = _DataContext.t_Elements.Where(a => a.ScreenID == Convert.ToInt32(result.UserState)).ToList();
            foreach (t_Element el in lsitElement)
            {
                var list = _DataContext.t_ElementProperties.Where(a => a.ElementID == el.ElementID);
                ShowElement(el, ElementSate.Save, list.ToList());
            }
            tbWait.Visibility = Visibility.Collapsed;
        }
        #endregion

        private MonitorControl ShowElement(t_Element obj, ElementSate eleStae, List<t_ElementProperty> listObj)
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

        private void SetEletemt(MonitorControl mControl, t_Element obj, ElementSate eleStae,
            List<t_ElementProperty> listObj)
        {
          
           // tp.Tag = t;
            //tp.KeyDown += new KeyEventHandler(TP_KeyDown);
            mControl.Selected += (o, e) =>
            {
                PropertyMain.Instance.ControlPropertyGrid.BrowsableProperties = mControl.BrowsableProperties;
                PropertyMain.Instance.ControlPropertyGrid.SelectedObject = mControl.GetRootControl(); 
            };
           
            mControl.ScreenElement = obj;
            mControl.ListElementProp = listObj;
            mControl.ElementState = eleStae;
            
            mControl.SetPropertyValue();
            mControl.SetCommonPropertyValue();
            //添加到场景
            csScreen.Children.Add(mControl);
            //mControl.DesignMode();
        }

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
            if (t != null && t.ControlID > 0)
            {
                t_Element mElement = InitElement(t);

                mElement.Width = (int)mWidth;
                mElement.Height = (int)mHeight;
                mElement.ScreenX = (int)mMagrinX;
                mElement.ScreenY = (int)mMagrinY;
                mElement.ScreenID = _CurrentScreen.ScreenID;

                IEnumerable<t_ControlProperty> listObj = _DataContext.t_ControlProperties.
                    Where(a => a.ControlID == t.ControlID);
                List<t_ElementProperty> listElementPro=new List<t_ElementProperty>();
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
                //_DataContext.t_Elements.Add(mElement);
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

       

        //private void checkBox1_Click(object sender, RoutedEventArgs e)
        //{
        //    if (checkBox1.IsChecked.Value)
        //    {
        //        //加截属性窗口
        //        fwProperty.SizeChanged += new SizeChangedEventHandler(f_SizeChanged);
        //        prop.ChangeScreen += new EventHandler(prop_ChangeScreen);
        //        fwProperty.Show();

        //        //注册事件
        //        Content.MouseLeftButtonDown +=new MouseButtonEventHandler(Content_MouseLeftButtonDown);
        //        Content.MouseLeftButtonUp+=new MouseButtonEventHandler(Content_MouseLeftButtonUp);
                    
        //        for (int i = 0; i < csScreen.Children.Count; i++)
        //        {
        //            var ui = csScreen.Children[i];
        //            if (ui is MonitorControl)
        //            {
        //                MonitorControl mControl = ui as MonitorControl;
        //                mControl.DesignMode();
        //            }
        //        }
        //    }
        //    else
        //    {
        //        //取消注册
        //        Content.MouseLeftButtonDown -= new MouseButtonEventHandler(Content_MouseLeftButtonDown);
        //        Content.MouseLeftButtonUp -= new MouseButtonEventHandler(Content_MouseLeftButtonUp);

        //        for (int i = 0; i < csScreen.Children.Count; i++)
        //        {
        //            var ui = csScreen.Children[i];
        //            if (ui is MonitorControl)
        //            {
        //                MonitorControl mControl = ui as MonitorControl;
        //                mControl.UnDesignMode();
        //            }
        //        }
        //        fwProperty.SizeChanged -= new SizeChangedEventHandler(f_SizeChanged);
        //        prop.ChangeScreen -= new EventHandler(prop_ChangeScreen);
        //        fwProperty.Close();
        //    }
        //}

      

        //protected void TP_KeyDown(object sender, KeyEventArgs e)
        //{
        //    MessageBox.Show(e.PlatformKeyCode.ToString());
        //}
        #region 添加元素，处理鼠标事件

        Point mStartPoint;
        bool IsDown = false;
        Rectangle RC = new Rectangle();
        private void Content_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
             t_Control t = GetSelectControl();
             if (t != null && t.ControlID > 0)
             {
                 IsDown = true;
                 var point = e.GetPosition(this);

                 RC.Visibility = Visibility.Visible;
                 mStartPoint = point;

                 RC.Width = 0;
                 RC.Height = 0;
                 RC.Margin = new Thickness(point.X, point.Y - 35, 0, 0);
             }
           
        }

        private void Content_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (IsDown &&  checkBox1.IsChecked.Value)
            {
                double mMagrinX = mStartPoint.X;
                double mMagrinY = mStartPoint.Y - 35;

                var mEndPoint = e.GetPosition(this);
                double mWidth = mEndPoint.X - mStartPoint.X;
                if (mWidth < 0)
                {
                    mWidth = mStartPoint.X - mEndPoint.X;
                    mMagrinX = mEndPoint.X;
                }
                double mHeight = mEndPoint.Y - mStartPoint.Y;
                if (mHeight < 0)
                {
                    mHeight = mStartPoint.Y - mEndPoint.Y;
                    mMagrinY = mEndPoint.Y - 35;
                }
                if (mWidth > 0 && mHeight > 0 && mMagrinX > 0 && mMagrinY > 0)
                {
                    AddSelectControlElement(mWidth, mHeight, mMagrinX, mMagrinY);
                }

                PropertyMain.Instance.ResetSelected();
            }
            IsDown = false;
            RC.Visibility = Visibility.Collapsed;
        }
        private void Content_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsDown)
            {
                var EndPoint = e.GetPosition(this);
                SetRCProperty(EndPoint);
            }
        }

        private void SetRCProperty(Point mEndPoint)
        {

            double mWidth = mEndPoint.X - mStartPoint.X;
            if (mWidth < 0)
            {
                mWidth = mStartPoint.X - mEndPoint.X;
            }            
            double mHeight = mEndPoint.Y - mStartPoint.Y;
            if (mHeight < 0)
            {
                mHeight = mStartPoint.Y - mEndPoint.Y;               
            }
           
            RC.Width = mWidth;
            RC.Height = mHeight;
        }
        #endregion      

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveElement();
        }
        #region 保存场景及元素、属性

        List<MonitorControl> listMonitorAddElement=new List<MonitorControl>();
        int AddElementNumber = 0;
        private void SaveElement()
        {
            

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
                        //meleObj.ElementID = MaxID;
                        //_DataContext.t_Elements.Add(meleObj);
                        //m.ElementState = ElementSate.Save;
                        m.ScreenElement = meleObj;

                        listMonitorAddElement.Add(m);
                        //_DataContext
                        //_DataContext.Load(_DataContext.
                       // _DataContext.SubmitChanges(SubmitCompleted, m);
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
            if (listMonitorAddElement.Count > 0)
            {
                AddElementNumber = 0;

                t_Element elem = listMonitorAddElement[0].ScreenElement;
                _DataContext.t_Elements.Add(elem);
                _DataContext.SubmitChanges(SubmitCompleted, null);
            }
            else
            {
                _DataContext.SubmitChanges();
            }
        }

        /// <summary>
        /// 提交元素完成。
        /// </summary>
        /// <param name="result"></param>
        private void SubmitCompleted(SubmitOperation result)
        {
           EntityChangeSet obj= result.ChangeSet;
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
                LoadScreenData(_CurrentScreen);
                return;
            }
            t_Element elem = listMonitorAddElement[AddElementNumber].ScreenElement;
            _DataContext.t_Elements.Add(elem);
            _DataContext.SubmitChanges(SubmitCompleted, null);
        }

        #endregion


        /// <summary>
        /// 检查更新字段并赋值
        /// </summary>
        /// <param name="mobj"></param>
        private void CheckElementChange(t_Element mobj)
        {
            t_Element saveEle = _DataContext.t_Elements.Single(a => a.ElementID == mobj.ElementID);
            if (saveEle == null)
                return;

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

        private void zt_Checked(object sender, RoutedEventArgs e)
        {
            //加截属性窗口
            fwProperty.SizeChanged += new SizeChangedEventHandler(f_SizeChanged);
            prop.ChangeScreen += new EventHandler(prop_ChangeScreen);
            fwProperty.Show();

            //注册事件
            Content.MouseLeftButtonDown += new MouseButtonEventHandler(Content_MouseLeftButtonDown);
            Content.MouseLeftButtonUp += new MouseButtonEventHandler(Content_MouseLeftButtonUp);

            for (int i = 0; i < csScreen.Children.Count; i++)
            {
                var ui = csScreen.Children[i];
                if (ui is MonitorControl)
                {
                    MonitorControl mControl = ui as MonitorControl;
                    mControl.DesignMode();
                }
            }
        }

        private void zt_Unchecked(object sender, RoutedEventArgs e)
        {
            //取消注册
            Content.MouseLeftButtonDown -= new MouseButtonEventHandler(Content_MouseLeftButtonDown);
            Content.MouseLeftButtonUp -= new MouseButtonEventHandler(Content_MouseLeftButtonUp);

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
        }

       
    }
}
