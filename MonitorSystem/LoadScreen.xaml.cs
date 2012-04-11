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

namespace MonitorSystem
{
    public partial class LoadScreen : UserControl
    {
      public  static  MonitorServers _DataContext = new MonitorServers();
        List<t_Screen> listScreen;

        public LoadScreen()
        {
            InitializeComponent();

            _DataContext.Load(_DataContext.GetT_ScreenQuery(), LoadScreenCompleted, null);
        }

        private void LoadScreenCompleted(LoadOperation<t_Screen> results)
        {
            if (results.HasError)
            {
                MessageBox.Show("加载场景数据出错。");
                return;
            }
            listScreen = new List<t_Screen>();
            foreach (t_Screen t in results.Entities)
            {
                listScreen.Add(t);
            }
            //实例化
            Init();
        }

        #region 实例化
        private void Init()
        {
            f = new FloatableWindow();
            prop = new PropertyMain();
        }

        FloatableWindow f;
        PropertyMain prop;
        private void LoadPro()
        {
            f.ParentLayoutRoot = LayoutRoot;
            f.Content = prop;
            f.Margin = new Thickness(50, 5, 0, 0);
            f.Width = 300;
            f.Height = 500;
            f.Title = "设计";
            f.MaxHeight = 500;
            f.MaxWidth = 400;
            f.SizeChanged += new SizeChangedEventHandler(f_SizeChanged);
            f.Show();

            //当属性窗口右击打开时执行
            prop.ChangeScreen += (sender, args) =>
            {
                ScreenArgs mobj = (ScreenArgs)args;
                LoadScreenData(mobj.Screen);
            };
        }

        /// <summary>
        /// 加载场景
        /// </summary>
        /// <param name="_Screen"></param>
        private void LoadScreenData(t_Screen _Screen)
        {
            string url = string.Format("{0}/ImageMap/{1}", Common.TopUrl(), _Screen.ImageURL);
            BitmapImage bitmap = new BitmapImage(new Uri(url, UriKind.Absolute));
            ImageBrush imgB = new ImageBrush();
            imgB.ImageSource = bitmap;
            imgB.Stretch = Stretch.Uniform;
            csScreen.Background = imgB;
        }
        #endregion

        /// <summary>
        /// 获取属性框，选中组件。
        /// </summary>
        /// <returns></returns>
        private t_Control GetSelectControl()
        {
            return PropertyMain.Instance.GetSelected();
        }

        
        /// <summary>
        /// 属性窗口改变大小时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void f_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            prop.ChangeSize(e.NewSize.Height, e.NewSize.Width);
        }

        private void checkBox1_Click(object sender, RoutedEventArgs e)
        {
            if (checkBox1.IsChecked.Value)
            {
                //加截属性窗口
                LoadPro();
                //注册事件
                Content.MouseLeftButtonDown +=new MouseButtonEventHandler(Content_MouseLeftButtonDown);
                Content.MouseLeftButtonUp+=new MouseButtonEventHandler(Content_MouseLeftButtonUp);
                    
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
            else
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
                f.Close();
            }
        }

        private void AddElement(double mWidth,double mHeight,double mMagrinX,double mMagrinY)
        {
            t_Control t = GetSelectControl();
            if (t != null)
            {
                TP tp = new TP();

                string url = string.Format("/MonitorSystem;component/Images/ControlsImg/{0}",t.ImageURL);
                BitmapImage bitmap = new BitmapImage(new Uri(url, UriKind.Relative));
                ImageSource mm = bitmap;
                tp.Source = mm;
                tp.Width = mWidth;
                tp.Height = mHeight;
                tp.Tag = t;
                //tp.KeyDown += new KeyEventHandler(TP_KeyDown);
                tp.Selected += (o, e) => { PropertyMain.Instance.ControlPropertyGrid.SelectedObject = tp.GetRootControl(); };

                tp.SetValue(Canvas.LeftProperty, mMagrinX);
                tp.SetValue(Canvas.TopProperty, mMagrinY);
                csScreen.Children.Add(tp);
                tp.DesignMode();
            }
        }
        //protected void TP_KeyDown(object sender, KeyEventArgs e)
        //{
        //    MessageBox.Show(e.PlatformKeyCode.ToString());
        //}
        #region 添加元素

        Point mStartPoint;
        bool IsDown = false;

        private void Content_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
             t_Control t = GetSelectControl();
             if (t != null)
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
                    AddElement(mWidth, mHeight, mMagrinX, mMagrinY);
                }
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

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < csScreen.Children.Count; i++)
            {
                var ui = csScreen.Children[i];
                
                if (ui is MonitorControl)
                {
                    TP mControl = ui as TP;
                   t_Control t=(t_Control)mControl.Tag;
                }
            }
        }

       
    }
}
