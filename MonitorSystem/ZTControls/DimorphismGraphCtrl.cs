﻿using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using MonitorSystem.MonitorSystemGlobal;
using System.Windows.Threading;
using MonitorSystem.Web.Moldes;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Media.Imaging;

namespace MonitorSystem.ZTControls
{
    /// <summary>
    /// 56	DimorphismGraphCtrl	2	Text.jpg	组态控件	二态图
    /// </summary>
    public class DimorphismGraphCtrl : MonitorControl
    {
        Canvas mRect = new Canvas();
        DispatcherTimer timer = new DispatcherTimer();

        public DimorphismGraphCtrl()
        {
            this.Content = mRect;
            mRect.Background = new SolidColorBrush(Colors.White);

            timer.Interval = new TimeSpan(0, 0, 2);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        protected void timer_Tick(object sender, EventArgs e)
        {
            ChangeImage();
        }

        #region 控件公共属性
        public override event EventHandler Selected;
        public override void DesignMode()
        {
            if (!IsDesignMode)
            {
                AdornerLayer = new Adorner(this);
                AdornerLayer.Selected += OnSelected;

                timer.Stop();
            }
        }
        public override void UnDesignMode()
        {
            if (IsDesignMode)
            {
                AdornerLayer.Selected -= OnSelected;
                AdornerLayer.ClearValue(ContextMenuService.ContextMenuProperty);
                AdornerLayer.Dispose();
                AdornerLayer = null;

                timer.Start();
            }
        }

        private void OnSelected(object sender, EventArgs e)
        {
            if (null != Selected)
            {
                Selected(this, RoutedEventArgs.Empty);
            }
        }
        



        private string[] m_BrowsableProperties = new string[] { "Left", "Top", "Width", "Height", "FontFamily", "FontSize","Transparent",
            "Translate", "BackImageName1", "BackImageName2", "WhichBackImage", "RefreshRate"};

        public override string[] BrowsableProperties
        {
            get { return m_BrowsableProperties; }
            set { m_BrowsableProperties = value; }
        }

        public override void SetCommonPropertyValue()
        {
            this.SetValue(Canvas.LeftProperty, (double)ScreenElement.ScreenX);
            this.SetValue(Canvas.TopProperty, (double)ScreenElement.ScreenY);
            
            this.Width = this.Width = (double)ScreenElement.Width;
            this.Height = this.Height = (double)ScreenElement.Height;
        }

        public List<t_ElementProperty> GetProperty()
        {
            return ListElementProp;
        }

        public override object GetRootControl()
        {
            return this;
        }

        public override void SetPropertyValue()
        {
            foreach (t_ElementProperty pro in ListElementProp)
            {
                string name = pro.PropertyName.ToUpper();
                string value = pro.PropertyValue;
                if (name == "BackImageName1".ToUpper())
                {
                    _BackImageName1 = value;
                }
                else if (name == "BackImageName2".ToUpper())
                {
                    _BackImageName2 = value;
                }
                else if (name == "WhichBackImage".ToUpper())
                {
                    
                }
                else if (name == "RefreshRate".ToUpper())
                {
                    RefreshRate = int.Parse(value);
                }
            }
        }
        #endregion

        #region 属性
        private static readonly DependencyProperty BackImageName1Property =DependencyProperty.Register("BackImageName1",
         typeof(string), typeof(DimorphismGraphCtrl), new PropertyMetadata(""));
        private string _BackImageName1 = "";
        [DefaultValue(""), Description("背景图片名字1"), Category("我的属性")]
        public string BackImageName1
        {
            get
            {
                return _BackImageName1;
            }
            set
            {
                _BackImageName1 = value;
                SetAttrByName("BackImageName1", value);
                ChangeImage();
            }
        }

        private static readonly DependencyProperty BackImageName2Property = DependencyProperty.Register("BackImageName2",
         typeof(string), typeof(DimorphismGraphCtrl), new PropertyMetadata(""));
        private string _BackImageName2 = "";
        [DefaultValue(""), Description("背景图片名字1"), Category("我的属性")]
        public string BackImageName2
        {
            get
            {
                return _BackImageName2;
            }
            set
            {
                _BackImageName2 = value;
                SetAttrByName("BackImageName2", value);
                ChangeImage();
            }
        }

        private static readonly DependencyProperty WhichBackImageProperty = DependencyProperty.Register("WhichBackImage",
        typeof(bool), typeof(DimorphismGraphCtrl), new PropertyMetadata(false));
        private bool _WhichBackImage = false;
        [DefaultValue(false), Description("哪一个背景图"), Category("我的属性")]
        public bool WhichBackImage
        {
            get
            {
                return _WhichBackImage;
            }
            set
            {
                _WhichBackImage = value;
                SetAttrByName("WhichBackImage", value);
                ChangeImage();
            }
        }

        private static readonly DependencyProperty RefreshRateProperty = DependencyProperty.Register("RefreshRate",
        typeof(int), typeof(DimorphismGraphCtrl), new PropertyMetadata(1000));
        private int _RefreshRate = 1000;
        [DefaultValue(1000), Description("刷新频率"), Category("我的属性")]
        public int RefreshRate
        {
            get
            {
                return _RefreshRate;
            }
            set
            {
                _RefreshRate = value;
                SetAttrByName("RefreshRate", value);

                int mRefre = value;
                if (mRefre < 500)
                {
                    mRefre = 500;
                }
                int s = 0;
                int mm = 0;
                if (mRefre >= 1000)
                    s = mRefre / 1000;
                mm = mRefre % 1000;

                timer.Interval = new TimeSpan(0, 0, 0, s, mm);
            }
        }
        #endregion


        private void ChangeImage()
        {
            string gbUrl = "";//
            if (_WhichBackImage)
            {
                if (!string.IsNullOrEmpty(_BackImageName1))
                {
                    gbUrl = string.Format("{0}/Pic/{1}", Common.TopUrl(), _BackImageName1);
                }
                _WhichBackImage = false;
            }
            else
            {
                if (!string.IsNullOrEmpty(_BackImageName2))
                {
                    gbUrl = string.Format("{0}/Pic/{1}", Common.TopUrl(), _BackImageName2);
                }
                _WhichBackImage = true;
            }
            //显示背景
            if (gbUrl == "")
            {
                mRect.Background = new SolidColorBrush(Colors.White);
            }
            else
            {
                BitmapImage bitmap = new BitmapImage(new Uri(gbUrl, UriKind.Absolute));
                ImageBrush img = new ImageBrush();
                img.ImageSource = bitmap;
                img.Stretch = Stretch.Fill;
                mRect.Background = img;
            }
        }
    }
}
