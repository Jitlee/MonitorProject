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
    /// 电力电子20
    /// </summary>
    public class Dldz21 : MonitorControl
    {
        private Canvas _canvas = new Canvas();
        Line _Line1 = new Line();
        Line _Line2 = new Line();
        Line _Line3 = new Line();

        Polygon gy = new Polygon();

        Line _Linex1 = new Line();
        Line _Linex2 = new Line();
        public Dldz21()
        {

            this.Width = 100;
            this.Height = 31;

            this.Content = _canvas;

            //线
            _Line1.Stroke = _Line2.Stroke = _Line3.Stroke = gy.Stroke =
                _Linex1.Stroke= _Linex2.Stroke= new SolidColorBrush(DLDZCommon.DLDZLineColor);

            _Line1.StrokeThickness = _Line2.StrokeThickness = _Line3.StrokeThickness =
                gy.StrokeThickness = _Linex1.StrokeThickness = _Linex2.StrokeThickness = DLDZCommon.DLDZLineWidth;

            gy.Fill = new SolidColorBrush(DLDZCommon.DLDZFilleColor);

            _canvas.Children.Add(_Line1);
            _canvas.Children.Add(_Line2);
            _canvas.Children.Add(_Line3);

            _canvas.Children.Add(_Linex1);
            _canvas.Children.Add(_Linex2);
            _canvas.Children.Add(gy);
            Paint();
            this.SizeChanged += new SizeChangedEventHandler(Control_SizeChanged);
        }

        private void Control_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.Width = e.NewSize.Width;
            this.Height = e.NewSize.Width * 0.31;
            Paint();
        }

        #region 公共
        #region 函数
        public override event EventHandler Selected;
		
		public override event EventHandler Unselected;

		private void OnUnselected(object sender, EventArgs e)
		{
			if(null != Unselected)
			{
				Unselected(this, RoutedEventArgs.Empty);
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


        public override FrameworkElement GetRootControl()
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
           typeof(Color), typeof(Dldz21), new PropertyMetadata(Colors.White));
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
            typeof(Color), typeof(Dldz21), new PropertyMetadata(Colors.Black));
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
        typeof(int), typeof(Dldz21), new PropertyMetadata(0));
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
            _Line1.X1 = 0;
            _Line1.X2 = this.Width * 0.4;
            _Line1.Y1 = _Line1.Y2 = this.Height / 2;

            _Line2.X1 = this.Width * 0.6;
            _Line2.X2 = this.Width;
            _Line2.Y1 = _Line2.Y2 = this.Height / 2;


            _Line3.X1 = _Line3.X2 = this.Width * 0.6;
            _Line3.Y1 = this.Height* 0.2;
            _Line3.Y2 = this.Height * 0.8;

            _Linex1.X1 = this.Width * 0.6;
            _Linex1.X2 = this.Width * 0.68;
            _Linex1.Y1 = this.Height * 0.2;
            _Linex1.Y2 = 0;

            _Linex2.X1 = this.Width * 0.6;
            _Linex2.X2 = this.Width * 0.52;
            _Linex2.Y1 = this.Height * 0.8;
            _Linex2.Y2 = this.Height;

            PointCollection pc = new PointCollection();
            gy.Points = pc;
            pc.Add(new Point(this.Width * 0.4, this.Height * 0.05));
            pc.Add(new Point(this.Width * 0.4, this.Height* 0.95));
            pc.Add(new Point(this.Width * 0.6, this.Height / 2));
        }

    }
}

