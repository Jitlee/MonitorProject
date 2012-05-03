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
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Threading;
using MonitorSystem.Web.Moldes;
using MonitorSystem.MonitorSystemGlobal;

namespace MonitorSystem.ZTControls
{
    /// <summary>
    /// 44	RealTimeCurve	2	Text.jpg		实时曲线
    /// </summary>
    public class RealTimeCurve :  MonitorControl
    {
        /// <summary>
        /// 主控件，里面放了所有的显示内容
        /// </summary>
        private Canvas picCurveShow;
        TextBlock labShowTime = new TextBlock();
        public RealTimeCurve()
        {
            this.picCurveShow = new Canvas();
            this.Content = picCurveShow;

            this.noteMessages = new CoordinatesValue[this.maxNote];
            picCurveShow.Height = 400;
            picCurveShow.Width = 400;
            
            //显示背景和刷新值
            this.RefBackground();
           // ShowCurve(RealtimeValue);

            //定时更新值
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 5);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

             this.SizeChanged +=new SizeChangedEventHandler(RealTimeCurve_SizeChanged);
        }

        protected void timer_Tick(object sender, EventArgs e)
        {
            ShowCurve(RealtimeValue);
        }


        private void RealTimeCurve_SizeChanged(object sender, SizeChangedEventArgs e)
        {
           picCurveShow.Width= e.NewSize.Width;
           picCurveShow.Height= e.NewSize.Height;
           RefBackground();
        }
       

        #region 属性设置
        SetSingleProperty tpp = new SetSingleProperty();
        private void PropertyMenuItem_Click(object sender, RoutedEventArgs e)
        {
            tpp = new SetSingleProperty();

            tpp.Closing += new EventHandler<System.ComponentModel.CancelEventArgs>(tpp_Closing);
            tpp.DeviceID = this.ScreenElement.DeviceID.Value;
            tpp.ChanncelID = this.ScreenElement.ChannelNo.Value;
            tpp.LevelNo = this.ScreenElement.LevelNo.Value;
            tpp.ComputeStr = this.ScreenElement.ComputeStr;
            tpp.Init();
            tpp.Show();
        }

        protected void tpp_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (tpp.IsOK)
            {
                this.ScreenElement.DeviceID = tpp.DeviceID;
                this.ScreenElement.ChannelNo = tpp.ChanncelID;
                this.ScreenElement.LevelNo = tpp.LevelNo;
                this.ScreenElement.ComputeStr = tpp.ComputeStr;
            }
        }

        #endregion

        
        #region 控件公共属性
        public override event EventHandler Selected;
        public override void DesignMode()
        {
            if (!IsDesignMode)
            {
                AdornerLayer = new Adorner(this);
                AdornerLayer.Selected += OnSelected;

                var menu = new ContextMenu();
                var menuItem = new MenuItem() { Header = "属性" };
                menuItem.Click += PropertyMenuItem_Click;
                menu.Items.Add(menuItem);
                AdornerLayer.SetValue(ContextMenuService.ContextMenuProperty, menu);
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
            }
        }

        private void OnSelected(object sender, EventArgs e)
        {
            if (null != Selected)
            {
                Selected(this, RoutedEventArgs.Empty);
            }
        }

        private string[] m_BrowsableProperties = new string[] { "Left", "Top", "Width", "Height", "FontFamily", "FontSize",
            "Translate", "Location", "RealtimeValue", "YmaxValue", "YminValue", "MyScale", "Yupper", "Ylower", "GridHeight" };

        public override string[] BrowsableProperties
        {
            get { return m_BrowsableProperties; }
            set { m_BrowsableProperties = value; }
        }

        public override void SetCommonPropertyValue()
        {
            this.SetValue(Canvas.LeftProperty, (double)ScreenElement.ScreenX);
            this.SetValue(Canvas.TopProperty, (double)ScreenElement.ScreenY);
            Transparent = ScreenElement.Transparent.Value;
            picCurveShow.Width = this.Width = (double)ScreenElement.Width;
            picCurveShow.Height=this.Height = (double)ScreenElement.Height;
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
                if (name == "RealtimeValue".ToUpper())
                {
                    if (value != null && value != "")
                    {
                        RealtimeValue = double.Parse(value);
                    }
                    else
                    {
                        RealtimeValue = 0f;
                    }
                }
                else if (name == "YmaxValue".ToUpper())
                {
                    if (value != null && value != "")
                    {
                        YmaxValue = double.Parse(value);
                    }
                    else
                    {
                        YmaxValue = 0;
                    }
                }
                else if (name == "YminValue".ToUpper())
                {
                    if (value != null && value != "")
                    {
                        YminValue = double.Parse(value);
                    }
                    else
                    {
                        YminValue = 0;
                    }
                }
                else if (name == "Yupper".ToUpper())
                {
                    if (value != null && value != "")
                    {
                        Yupper = double.Parse(value);
                    }
                    else
                    {
                        Yupper = 0;
                    }
                }
                else if (name == "Ylower".ToUpper())
                {
                    if (value != null && value != "")
                    {
                        Ylower = double.Parse(value);
                    }
                    else
                    {
                        Ylower = 0;
                    }
                }
                else if (name == "GridHeight".ToUpper())
                {
                    if (value != null && value != "")
                    {
                        GridHeight = double.Parse(value);
                    }
                    else
                    {
                        GridHeight = 0;
                    }
                }
            }
            this.RefBackground();
        }
        #endregion        

        #region 属性

        private static readonly DependencyProperty TransparentProperty =
         DependencyProperty.Register("Transparent",
         typeof(int), typeof(RealTimeCurve), new PropertyMetadata(0));
        private int _Transparent;
        public int Transparent
        {
            get { return _Transparent; }
            set
            {
                _Transparent = value;
                if (value == 1)
                {
                    //_mTxt.Background = new SolidColorBrush();
                    //_mTxt.BorderBrush = new SolidColorBrush();
                }
                else
                {
                    //_mTxt.Background = new SolidColorBrush(Colors.White);

                }
                if (ScreenElement != null)
                    ScreenElement.Transparent = value;
            }
        }

        private static readonly DependencyProperty myScaleProperty =
         DependencyProperty.Register("MyScale",
         typeof(String), typeof(RealTimeCurve), new PropertyMetadata(""));
        private string myScale;
        public String MyScale
        {
            get { return myScale; }
            set
            {
                myScale = value;
                SetAttrByName("MyScale", value);
            }
        }

        private static readonly DependencyProperty RealtimeValueProperty =
         DependencyProperty.Register("RealtimeValue",
         typeof(double), typeof(RealTimeCurve), new PropertyMetadata((double)30));
        private double _RealtimeValue=30;
        public double RealtimeValue
        {
            get { return _RealtimeValue; }
            set
            {
                _RealtimeValue = value;
                SetAttrByName("RealtimeValue", value);
            }
        }

        private static readonly DependencyProperty YmaxValueProperty =
         DependencyProperty.Register("YmaxValue",
         typeof(double), typeof(RealTimeCurve), new PropertyMetadata((double)50));
        private double _YmaxValue = 50;
        public double YmaxValue
        {
            get
            {
                return _YmaxValue;
            }
            set
            {
                _YmaxValue = value;
                SetAttrByName("YmaxValue", value);
                RefBackground();
            }
        }

        private static readonly DependencyProperty YminValueProperty =
        DependencyProperty.Register("YminValue",
        typeof(double), typeof(RealTimeCurve), new PropertyMetadata((double)-20));
        private double _YminValue = -20;
        public double YminValue
        {
            get
            {
                return _YminValue;
            }
            set
            {
                _YminValue = value;
                 SetAttrByName("YminValue", value.ToString());
                 RefBackground();
            }
        }

        private static readonly DependencyProperty YupperProperty =
        DependencyProperty.Register("Yupper",
       typeof(double), typeof(RealTimeCurve), new PropertyMetadata((double)30));
        private double _Yupper = 30;
        public double Yupper
        {
            get
            {
                return _Yupper;
            }
            set
            {
                _Yupper = value;
                SetAttrByName("Yupper", value.ToString());
                RefBackground();
            }
        }

        private static readonly DependencyProperty YlowerProperty =
       DependencyProperty.Register("Ylower",
      typeof(double), typeof(RealTimeCurve), new PropertyMetadata((double)15));
        private double _Ylower = 15;
        public double Ylower
        {
            get
            {
                return _Ylower;
            }
            set
            {
                _Ylower = value;
                SetAttrByName("Ylower", value.ToString());
                RefBackground();
            }
        }

        private static readonly DependencyProperty GridHeightProperty =
      DependencyProperty.Register("GridHeight",
     typeof(double), typeof(RealTimeCurve), new PropertyMetadata((double)40));

        private double _GridHeight = 40;
        [DefaultValue("10"), Description("网格高度"), Category("我的属性")]
        public double GridHeight
        {
            get
            {
                return _GridHeight;
            }
            set
            {
                _GridHeight = value;
                SetAttrByName("GridHeight", value.ToString());

                RefBackground();
            }
        }
        #endregion

        
        public int GetDeviceID()
        {
            return 0;// this.m_ElementObj.DeviceID;
        }

        public int GetChannelNo()
        {
            return 0;// this.m_ElementObj.ChannelNo;
        }

        public void SetDeviceID(int deviceID)
        {
            //m_ElementObj.DeviceID = deviceID;
            //m_ElementObj.SetState(ElementObj.STATE_MODIFY);
        }
        //2011-5-31:zeng
        public void SetLevel(int levelNo)
        {
            //m_ElementObj.LevelNo = levelNo;
            //m_ElementObj.SetState(ElementObj.STATE_MODIFY);
        }
        //2011-5-31:zeng
        //public int GetLevel()
        //{
        //    return this.m_ElementObj.LevelNo;
        //}
        public void SetChannelID(int channelID)
        {
            //m_ElementObj.ChannelNo = channelID;
            //m_ElementObj.SetState(ElementObj.STATE_MODIFY);
        }

        public  void SetChannelValue(double fValue)
        {
            if (MyScale == null || MyScale == "")
                MyScale = "1";
            double temp = double.Parse(MyScale);
            if (temp <= 0)
                temp = 1;
            fValue = (double)(fValue / temp);

            RealtimeValue = fValue;
            //mycurveControl.ShowCurve(RealtimeValue);
            ShowCurve(RealtimeValue);
        }

        //private void mycontextMenuStrip_Opening(object sender, CancelEventArgs e)
        //{
        //    this.Property_Item.Enabled = m_showContexOrNot;
        //}

        private void Property_Item_Click(object sender, EventArgs e)
        {

        }
        #region 曲线数据定义
        /// <summary>
        /// 定义曲线窗体标题
        /// </summary>
        private string title = "实时曲线";
        /// <summary>
        /// 定义曲线标题颜色
        /// </summary>
        private Color titleColor = Colors.Yellow;
        /// <summary>
        /// 定义是否显示系统时间
        /// </summary>
        private bool showTime = true;
        /// <summary>
        /// 定义显示系统时间颜色
        /// </summary>
        private Color showTimeColor = Colors.Red;

        /// <summary>
        /// 定义坐标零点向右偏移量
        /// </summary>
        private double coordinate = 50F;
       
        /// <summary>
        /// 定义曲线Y轴最大值提示文字
        /// </summary>
        private string yMaxString = "最大值：";
       

        /// <summary>
        /// 定义曲线Y轴最小值提示文字
        /// </summary>
        private string yMinString = "最小值：";
       
        /// <summary>
        /// 定义曲线Y轴正常值（上限）提示文本
        /// </summary>
        private string yUpperString = "上限：";
       
        /// <summary>
        /// 定义曲线Y轴正常值（下限）提示文本
        /// </summary>
        private string yLowerString = "下限：";
        /// <summary>
        /// 定义曲线正常值上下限线段颜色
        /// </summary>
        private Color yUpperAndLowerColor = Colors.Red;
        /// <summary>
        /// 定义曲线正常值上下限线段宽度
        /// </summary>
        private double yUpperAndLowerPenWidth = 1F;
        /// <summary>
        /// 定义背景颜色
        /// </summary>
        private Color backGroundColor = Colors.Black;

        /// <summary>
        /// 定义是否滚动网格线
        /// </summary>
        private bool removeGrid = true;
        /// <summary>
        /// 定义背景网格线颜色
        /// </summary>
        private Color gridColor = Colors.DarkGray;
        /// <summary>
        /// 定义背景网格文字颜色
        /// </summary>
        private Color gridForeColor = Colors.Red;
        /// <summary>
        /// 定义背景网格（分隔线）宽度
        /// </summary>
        private double gridCompart = 1F;
        /// <summary>
        /// 定义背景网格文字大小
        /// </summary>
        private double gridFontSize = 9f;
        /// <summary>
        /// 定义背景网格线画笔宽度
        /// </summary>
        private double gridPenWidth = 1F;
        /// <summary>
        /// 定义背景网格线单元格宽度
        /// </summary>
        private double gridWidth = 10F;
       
        /// <summary>
        /// 定义曲线颜色
        /// </summary>
        private Color curveColor = Colors.White;
        /// <summary>
        /// 定义曲线画笔宽度
        /// </summary>
        private double curvePenWidth = 1;
        /// <summary>
        /// 定义曲线移动距离
        /// </summary>
        private int curveRemove = 5;
        /// <summary>
        /// 定义数值节点正方形宽度
        /// </summary>
        private double rectangleWidth = 1F;
        /// <summary>
        /// 定义正方形颜色
        /// </summary>
        private Color rectangleColor = Colors.White;

        /// <summary>
        /// 定义显示节点数值鼠标X，Y轴容差精度
        /// </summary>
        private double xYPrecision = 4F;
        /// <summary>
        /// 曲线节点数据最大存储量
        /// </summary>
        private int maxNote = 1000;
        #endregion
       

        #region 全局变量
        /// <summary>
        /// 背景方格移动量
        /// </summary>
        private double gridRemoveX = 1;
        /// <summary>
        /// 鼠标X，Y 坐标值，及该点坐标记录值、记录时间（数组）
        /// </summary>
        private CoordinatesValue[] noteMessages;
        /// <summary>
        /// 当前鼠标 X，Y坐标记录数组下标值
        /// </summary>
        private int noteNow = 0;
       
        /// <summary>
        /// 系统窗体高度临时值，用于窗体变形时刷新数组坐标。
        /// </summary>
        private double lastTimeSystemWindowHeight = 0;
        /// <summary>
        /// 系统窗体宽度临时值，用于窗体变形时刷新数组坐标。
        /// </summary>
        private double lastTimeSystemWindowWidth = 0;
        #endregion
        #region 曲线数据显示

        #region 绘制背景网格
        /// <summary>
        /// 刷新背景网格线，并返回背景图片（背景不判断是否滚动）
        /// </summary>
        /// <returns>返回背景图片</returns>
        private void RefBackground()
        {
            noteNow = 0;

            double douooo = 0;
              //  SolidColorBrush
            if (this.picCurveShow.Height < 1 || this.picCurveShow.Width < 1)
            {
                return;
            }
            picCurveShow.Children.Clear();

            picCurveShow.Background = new SolidColorBrush(Colors.Black);
                        
            //绘制表格背景线
            //绘制背景横轴线
            //this.picCurveShow.Height = 300;
            //this.Background=new SolidColorBrush(this.backGroundColor());
            int value = 0; double zongvalue = 0, iHeight =(int) this.picCurveShow.Height;

            zongvalue = this._YmaxValue - this._YminValue;
            value = 0; double CurrentPx = 0, CurrentValue1 = this._YmaxValue;
            for (double k = zongvalue; k >= 0; k = k - _GridHeight) 
            {
                CurrentPx = (double)value * _GridHeight * this.picCurveShow.Height / zongvalue;

                Line liGrid = new Line();
                liGrid.StrokeThickness = 0.5;
                //liGrid.StrokeDashArray = new DoubleCollection() { 2.0, 2.0 };
                liGrid.Stroke = new SolidColorBrush(Colors.Blue);
                liGrid.X1 = coordinate;
                liGrid.X2 = this.picCurveShow.Width;
                liGrid.Y1 = liGrid.Y2 = CurrentPx;
                liGrid.SetValue(Canvas.ZIndexProperty, 1);
                picCurveShow.Children.Add(liGrid);

                CurrentValue1 = this._YmaxValue - value * this._GridHeight;
                TextBlock txtValue = new TextBlock();
                txtValue.Text = CurrentValue1.ToString();
                txtValue.Foreground = new SolidColorBrush(this.gridForeColor);
                txtValue.SetValue(Canvas.LeftProperty, this.coordinate);
                txtValue.SetValue(Canvas.TopProperty, CurrentPx - this.FontSize / 2);
                txtValue.SetValue(Canvas.ZIndexProperty, 500);
                if (CurrentValue1 == _YminValue)
                {
                    txtValue.SetValue(Canvas.TopProperty, CurrentPx-12);
                }
                picCurveShow.Children.Add(txtValue);
                value++;
            }

            //绘制背景纵轴线
           // picCurveShow.Width = 300;
            SolidColorBrush brush = new SolidColorBrush(Colors.Blue);// (Color.FromArgb(0xff, 0x19, 0x72, 0xc9));
            //SolidColorBrush redBrush = new SolidColorBrush(Colors.Red);
           
            for (double i = this.picCurveShow.Width; i >= 0; i = i - this.gridWidth)
            {
                if (i - gridRemoveX >= this.coordinate)
                {
                    Line ll = new Line();
                    ll.StrokeThickness = 0.6;
                    ll.Stroke = new SolidColorBrush(Colors.Blue);
                    ll.X1 = i - gridRemoveX;
                    ll.X2 = i - gridRemoveX;
                    ll.Y1 = 0;
                    ll.Y2 = this.picCurveShow.Height;
                    ll.SetValue(Canvas.ZIndexProperty, 1);
                    picCurveShow.Children.Add(ll);
                }

                //picCurveShow
            }

            //绘制分隔线。
            //backGroundImage.DrawLine(gridCompartPen, 0, 0, 0, this.picCurveShow.Height);
            Line FbLine = new Line();
            FbLine.X1 = coordinate;
            FbLine.Y1 = 0;
            FbLine.X2 = coordinate;
            FbLine.Stroke = new SolidColorBrush(Colors.Red);
            FbLine.Y2 = this.picCurveShow.Height;
            picCurveShow.Children.Add(FbLine);

            //数值区间
            double my = 0;

            if (this._Ylower > 0)
            {
                my = ((this._YmaxValue - this._Ylower) * this.picCurveShow.Height / zongvalue);
                //backGroundImage.DrawLine(upperAndLowerPen, 0, my, this.picCurveShow.Width, my);
                ////绘制下限文字
                //backGroundImage.DrawString(this.yLowerString + this.yLower.ToString(), backGroundFont, brush, -this.coordinate, my - fontHight / 2);

                Line line = new Line();
                line.StrokeThickness = 1;
                line.StrokeDashArray = new DoubleCollection() { 2.0, 2.0 };
                line.Stroke = new SolidColorBrush(Colors.Red);
                line.X1 =  this.coordinate;
                line.X2 = this.picCurveShow.Width;
                line.Y1 =my;
                line.Y2 = my;
                picCurveShow.Children.Add(line);

                CurrentValue1 = this._YmaxValue - value * this._GridHeight;
                
                TextBlock txtValue = new TextBlock();
                txtValue.Text = yLowerString +  _Ylower.ToString();
                txtValue.Foreground = new SolidColorBrush(Colors.Red);
                txtValue.SetValue(Canvas.LeftProperty, douooo);
                txtValue.SetValue(Canvas.TopProperty, my - this.gridFontSize / 2);
                picCurveShow.Children.Add(txtValue);
            }
            ////绘制0点横坐标
            if (_YminValue <= 0) 
            {
                my = (-_YminValue) * picCurveShow.Height / (_YmaxValue - _YminValue);
                my = picCurveShow.Height - my;
            }
            else
            {
                my = _YminValue * picCurveShow.Height / (_YmaxValue - _YminValue);
                my = picCurveShow.Height - my;
            }

            if (_YminValue < 0)
            {
                Line Line0 = new Line();
                Line0.StrokeThickness = 0.6;
                Line0.Stroke = new SolidColorBrush(Colors.Blue);
                Line0.X1 = coordinate;
                Line0.X2 = this.picCurveShow.Width;
                Line0.Y1 = my;
                Line0.Y2 = my;
                picCurveShow.Children.Add(Line0);

                TextBlock txt0 = new TextBlock();
                txt0.Text = "0:";
                txt0.Foreground = brush;
                txt0.SetValue(Canvas.LeftProperty, this.coordinate - 18);
                txt0.SetValue(Canvas.TopProperty, my - this.gridFontSize / 2);
                picCurveShow.Children.Add(txt0);
            }

            if (this._Yupper > 0)
            {
                my = ((this._YmaxValue - this._Yupper) * this.picCurveShow.Height / zongvalue);
                //backGroundImage.DrawLine(upperAndLowerPen, 0, my, this.picCurveShow.Width, my);
                ////绘制上限文字
                //backGroundImage.DrawString(this.yUpperString + this.yUpper.ToString(), backGroundFont, brush, -this.coordinate, my - fontHight / 2);

                Line upperAndLowerLine11 = new Line();
                upperAndLowerLine11.StrokeThickness = 1;
                upperAndLowerLine11.Stroke = new SolidColorBrush(Colors.Red);
                upperAndLowerLine11.StrokeDashArray = new DoubleCollection() { 2.0, 2.0 };
                upperAndLowerLine11.X1 = this.coordinate;
                upperAndLowerLine11.X2 = this.picCurveShow.Width ;
                upperAndLowerLine11.Y1 = my;
                upperAndLowerLine11.Y2 = my;
                picCurveShow.Children.Add(upperAndLowerLine11);

                TextBlock txtupperAndLower11 = new TextBlock();
                txtupperAndLower11.Text = this.yUpperString + this._Yupper.ToString();
                txtupperAndLower11.Foreground = new SolidColorBrush(Colors.Red);
                txtupperAndLower11.SetValue(Canvas.LeftProperty, douooo);
                txtupperAndLower11.SetValue(Canvas.TopProperty, my - this.gridFontSize / 2);
                picCurveShow.Children.Add(txtupperAndLower11);
            }
            
            TextBlock txtMax = new TextBlock();
            txtMax.Text = this.yMaxString;
            txtMax.Foreground = new SolidColorBrush(Colors.Red);
            txtMax.SetValue(Canvas.LeftProperty, douooo);
            txtMax.SetValue(Canvas.TopProperty, douooo);
            picCurveShow.Children.Add(txtMax);


            //绘制最小值文字
            //backGroundImage.DrawString(this.yMinString, backGroundFont, brush, -this.coordinate, (float)this.picCurveShow.Height - fontHight);
            TextBlock txtMin = new TextBlock();
            txtMin.Text = this.yMinString;
            txtMin.Foreground = new SolidColorBrush(Colors.Red);
            txtMin.SetValue(Canvas.LeftProperty, douooo);
            txtMin.SetValue(Canvas.TopProperty, this.picCurveShow.Height - 12);
            picCurveShow.Children.Add(txtMin);


            ////绘制曲线窗体标题
            brush = new SolidColorBrush(this.showTimeColor);
            TextBlock txtTitle = new TextBlock();
            txtTitle.Text = this.title;
            txtTitle.Foreground = brush;
            txtTitle.SetValue(Canvas.LeftProperty, this.picCurveShow.Width / 2 - this.title.Length * this.gridFontSize);
            txtTitle.SetValue(Canvas.TopProperty, douooo);
            picCurveShow.Children.Add(txtTitle);

            //绘制系统时间
            if (this.showTime)
            {
                labShowTime.Foreground = new SolidColorBrush(Colors.Red);
                labShowTime.Text = DateTime.Now.ToString("hh:mm:ss");
                picCurveShow.Children.Add(labShowTime);

                labShowTime.SetValue(Canvas.LeftProperty, picCurveShow.Width - 80);
                labShowTime.SetValue(Canvas.TopProperty, picCurveShow.Height - 20);
            }
            //return bitmap;
        }
       
        #endregion

        /// <summary>
        /// 刷新背景网格线，显示曲线
        /// </summary>
        public void ShowCurve()
        {
            //窗体高度发生变化，先刷新数组Y坐标值
            if ((this.picCurveShow.Height != this.lastTimeSystemWindowHeight) || 
                (this.picCurveShow.Width != this.lastTimeSystemWindowWidth))
            {
                this.RefurbishArray();
                
            }
            //绘制曲线
            //判断数组中是否有两个以上的数值
            //绘制直线
            if (this.noteNow > 1)
            {
                PointCollection pc = new PointCollection();

                //int pointI = 0;
                for (int i = 0; i <= this.noteNow - 1; i++)
                {
                    if (this.noteMessages[i].X >= this.coordinate)
                    {
                        Point p = new Point(this.noteMessages[i].X, this.noteMessages[i].Y);
                        pc.Add(p);
                        //pointI++;
                    }
                }

                Polyline pl = new Polyline();
                pl.Stroke = new SolidColorBrush(Colors.Yellow);
                pl.StrokeThickness = 2;
                pl.Points = pc;
                pl.Name = "ShowLinePolyline";
               var v= picCurveShow.FindName("ShowLinePolyline");
               picCurveShow.Children.Remove((Polyline)v);
                picCurveShow.Children.Add(pl);
            }

            labShowTime.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        /// <summary>
        /// 刷新背景网格线，显示曲线，自动添加即时数值
        /// </summary>
        /// <param name="Value">即时数值</param>
        public void ShowCurve(double Value)
        {
            if (_YminValue <= 0)
            {
                Value -= _YminValue;
            }
            this.AddNewValue(Value);
            this.ShowCurve();
        }

        #endregion

        #region 自动将最新采样数值添加到数组
        /// <summary>
        /// 自动将最新采样数值添加到数组
        /// </summary>
        /// <param name="newValue">最新采样数值</param>
        private void AddNewValue(double newValue)
        {
            //先判断数组下标
           // newValue = newValue + noteNow;
            if (this.noteNow >= this.maxNote - 1)
            {
                //数组已经存满数值
                for (int i = 0; i < this.noteNow; i++)
                {
                    this.noteMessages[i] = this.noteMessages[i + 1];
                    this.noteMessages[i].X = this.noteMessages[i].X - curveRemove;
                }
                this.noteMessages[this.noteNow].Value = newValue;
                this.noteMessages[this.noteNow].time = System.DateTime.Now;
                this.noteMessages[this.noteNow].X = (int)this.picCurveShow.Width;
                this.noteMessages[this.noteNow].Y = (int)(this.picCurveShow.Height - (newValue / (this._YmaxValue - this._YminValue)) * this.picCurveShow.Height);

            }
            else
            {
                //数组未存满数值
                for (int i = 0; i < this.noteNow; i++)
                {
                    this.noteMessages[i].X = this.noteMessages[i].X - curveRemove;
                }
                this.noteMessages[this.noteNow].Value = newValue;
                this.noteMessages[this.noteNow].time = System.DateTime.Now;
                this.noteMessages[this.noteNow].X =(int) this.picCurveShow.Width;

                this.noteMessages[this.noteNow].Y = (int)(this.picCurveShow.Height - (newValue / (this._YmaxValue - this._YminValue)) * this.picCurveShow.Height);

                this.noteNow++;
            }
        }
        #endregion

        #region 窗体大小变化，自动刷新窗体Y轴值
        /// <summary>
        /// 窗体大小变化，自动刷新窗体Y轴值
        /// </summary>
        private void RefurbishArray()
        {
            if (this.noteNow <= 0)
                return;

            //改变窗体大小时自动修改窗体高度临时值
            this.lastTimeSystemWindowHeight = this.picCurveShow.Height;
            this.lastTimeSystemWindowWidth = this.picCurveShow.Width;
        }
        #endregion

        private void picCurveShow_MouseLeave(object sender, System.EventArgs e)
        {
            //鼠标离开曲线控件
            //this.labShowView.Visible = false;
        }

        private void CurveControl_Paint(object sender, System.EventArgs e)
        {
            picCurveShow.Height = this.Height;
            picCurveShow.Width = this.Width;
        }

        private void 属性ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void picCurveShow_Click(object sender, EventArgs e)
        {
            this.Focus();
        }

        private void RealTimeCurve_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void picCurveShow_MouseDown(object sender, MouseEventArgs e)
        {

        }
    }

    #region 定义鼠标X，Y 坐标值，及该点坐标记录值、记录时间
    /// <summary>
    /// 定义鼠标X，Y 坐标值，及该点坐标记录值、记录时间
    /// </summary>
    struct CoordinatesValue
    {
        public int X;
        public int Y;
        public double Value;
        public System.DateTime time;
    }
    #endregion




}


