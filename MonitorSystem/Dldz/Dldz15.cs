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
using System.ComponentModel;
using MonitorSystem.Web.Moldes;

namespace MonitorSystem.Dldz
{
    /// <summary>
    /// 电力电子15
    /// </summary>
    public class Dldz15 : MonitorControl
    {
        private Canvas _canvas = new Canvas();

        Line _line1 = new Line();
        Line _line2 = new Line();
        Line _line3 = new Line();
        Line _line4 = new Line();

        Rectangle _rect1 = new Rectangle();
        Rectangle _rect2 = new Rectangle();
        Rectangle _rect3 = new Rectangle();
        public Dldz15()
        {
            this.Content = _canvas;
            this.Width = 100;
            this.Height = 22;

            _line1.StrokeThickness = _line2.StrokeThickness = _line3.StrokeThickness = _line4.StrokeThickness =
            _rect1.StrokeThickness = _rect2.StrokeThickness = _rect3.StrokeThickness = DLDZCommon.DLDZLineWidth;

            _line1.Stroke = _line2.Stroke = _line3.Stroke = _line4.Stroke =
                _rect1.Stroke = _rect2.Stroke = _rect3.Stroke = new SolidColorBrush(DLDZCommon.DLDZLineColor);

            _rect1.Fill = _rect2.Fill = _rect3.Fill = new SolidColorBrush(DLDZCommon.DLDZFilleColor);

            _canvas.Children.Add(_line1);
            _canvas.Children.Add(_line2);
            _canvas.Children.Add(_line3);
            _canvas.Children.Add(_line4);
            _canvas.Children.Add(_rect1);
            _canvas.Children.Add(_rect2);
            _canvas.Children.Add(_rect3);

            Paint();
            this.SizeChanged += new SizeChangedEventHandler(Control_SizeChanged);
        }

        private void Control_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.Width = e.NewSize.Width;
            this.Height = e.NewSize.Width * 0.22;
            Paint();
        }

        #region 公共
        #region 函数
        public override event EventHandler Selected;
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

        public override void DesignMode()
        {
            if (!IsDesignMode)
            {
                AdornerLayer = new Adorner(this);
                AdornerLayer.Selected += OnSelected;
                AdornerLayer.IsLockScale = true;
            }
        }

        private void OnSelected(object sender, EventArgs e)
        {
            if (null != Selected)
            {
                Selected(this, RoutedEventArgs.Empty);
            }
        }


        public override object GetRootControl()
        {
            return this;
        }

        public override void SetChannelValue(float fValue, float dValue)
        {

        }
        #endregion

        #region 属性
        public override void SetPropertyValue()
        {
            foreach (t_ElementProperty pro in ListElementProp)
            {
                string name = pro.PropertyName.ToUpper();
                string value = pro.PropertyValue;
            }
            //Paint();
        }

        public override void SetCommonPropertyValue()
        {
            this.SetValue(Canvas.LeftProperty, (double)ScreenElement.ScreenX);
            this.SetValue(Canvas.TopProperty, (double)ScreenElement.ScreenY);
            this.Width = (double)ScreenElement.Width;
            this.Height = (double)ScreenElement.Height;
            Transparent = ScreenElement.Transparent.Value;

            BackColor = Common.StringToColor(ScreenElement.BackColor);
            ForeColor = Common.StringToColor(ScreenElement.ForeColor);
        }



        private string[] m_BrowsableProperties = new string[] { "Left", "Top", "Width", "Height", "FontFamily", "FontSize",
           "BackColor", "ForeColor", "Transparent","Translate"};
        public override string[] BrowsableProperties
        {
            get { return m_BrowsableProperties; }
            set { m_BrowsableProperties = value; }
        }


        private static readonly DependencyProperty BackColorProperty =
           DependencyProperty.Register("BackColor",
           typeof(Color), typeof(Dldz15), new PropertyMetadata(Colors.White));
        [DefaultValue(""), Description("背景色"), Category("外观")]
        public Color BackColor
        {
            get { return (Color)this.GetValue(BackColorProperty); }
            set
            {
                this.SetValue(BackColorProperty, value);
                if (ScreenElement != null)
                    ScreenElement.BackColor = value.ToString();
            }
        }

        private static readonly DependencyProperty ForeColorProperty =
            DependencyProperty.Register("ForeColor",
            typeof(Color), typeof(Dldz15), new PropertyMetadata(Colors.Black));
        [DefaultValue(""), Description("前景色"), Category("外观")]
        public Color ForeColor
        {
            get { return (Color)this.GetValue(ForeColorProperty); }
            set
            {
                this.SetValue(ForeColorProperty, value);
                if (ScreenElement != null)
                    ScreenElement.ForeColor = value.ToString();
            }
        }


        private static readonly DependencyProperty TransparentProperty = DependencyProperty.Register("Transparent",
        typeof(int), typeof(Dldz15), new PropertyMetadata(0));
        private int _Transparent = 0;
        [DefaultValue(""), Description("透明"), Category("杂项")]
        public int Transparent
        {
            get { return _Transparent; }
            set
            {
                _Transparent = value;
                if (ScreenElement != null)
                    ScreenElement.Transparent = value;
            }
        }
        #endregion

        #endregion


        private void Paint()
        {
            double _lineY = this.Height * 0.88;
            double RectWidth = this.Width * 0.06;
            //Lin1
            _line1.X1 = 0;
            _line1.Y2 = _line1.Y1 = this.Height/2;
            _line1.X2 = 0.294 * this.Width;

            //Lin2
            _line2.X1 = 0.352 * this.Width;
            _line2.X2 = this.Width * 0.674;
            _line2.Y2=_line2.Y1 = this.Height / 2;
            

            _line3.X1 = this.Width * 0.72;
            _line3.X2 = this.Width;
            _line3.Y2 = _line3.Y1 = RectWidth/2;

            _line4.X1 = this.Width * 0.72;
            _line4.X2 = this.Width;
            _line4.Y2 = _line4.Y1 = this.Height - RectWidth / 2;

            _rect1.Width = _rect1.Height = _rect1.RadiusX = _rect1.RadiusY = RectWidth;
            _rect2.Width = _rect2.Height = _rect2.RadiusX = _rect2.RadiusY = RectWidth;
            _rect3.Width = _rect3.Height = _rect3.RadiusX = _rect3.RadiusY = RectWidth;

            _rect1.SetValue(Canvas.TopProperty, this.Height/2 - RectWidth/2);
            _rect1.SetValue(Canvas.LeftProperty, 0.294 * this.Width);

            _rect2.SetValue(Canvas.TopProperty,  0d);
            _rect2.SetValue(Canvas.LeftProperty, this.Width * 0.664);

            _rect3.SetValue(Canvas.TopProperty, this.Height - RectWidth);
            _rect3.SetValue(Canvas.LeftProperty, this.Width * 0.664);

        }

    }
}

