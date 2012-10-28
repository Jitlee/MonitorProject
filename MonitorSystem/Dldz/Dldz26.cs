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
    /// 电力电子
    /// </summary>
    public class Dldz26 : MonitorControl
    {
        private Canvas _canvas = new Canvas();

        Path py = new Path();
        GeometryGroup gg = new GeometryGroup();
        PathGeometry _pathG = new PathGeometry();
        //棱形
        PathFigureCollection pfc = new PathFigureCollection();
        PathFigure pf = new PathFigure();
        PathSegmentCollection psc = new PathSegmentCollection();

        public Dldz26()
        {
            this.Content = _canvas;
            this.Width = 100;
            this.Height = 39;
            
            _pathG.Figures = pfc;
            pfc.Add(pf);
            pf.Segments = psc;
            gg.FillRule = FillRule.Nonzero;
            gg.Children.Add(_pathG);
            py.Data = gg;
            py.StrokeThickness = 0;// DLDZCommon.DLDZLineWidth;
            py.Stroke = new SolidColorBrush(DLDZCommon.DLDZLineColor);
            py.Fill = new SolidColorBrush(DLDZCommon.DLDZFilleColor2);
            _canvas.Children.Add(py);

            Paint();
            this.SizeChanged += new SizeChangedEventHandler(Control_SizeChanged);
        }

        private void Control_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.Width = e.NewSize.Width;
            this.Height = e.NewSize.Width * 0.39;
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
           typeof(Color), typeof(Dldz26), new PropertyMetadata(Colors.White));
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
            typeof(Color), typeof(Dldz26), new PropertyMetadata(Colors.Black));
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
        typeof(int), typeof(Dldz26), new PropertyMetadata(0));
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
            pf.StartPoint = new Point(0, 0);
            psc.Clear();
            //直线
            ArcSegment arcs = new ArcSegment();
            arcs.Point = new Point(this.Width * 0.75, 0);
            psc.Add(arcs);
            
            
            arcs = new ArcSegment();
            arcs.Point = new Point(this.Width, this.Height / 2);
            arcs.Size = new Size()
            {
                Height = this.Height / 2,
                Width = this.Width * 0.25
            };
            arcs.SweepDirection = SweepDirection.Clockwise;
            psc.Add(arcs);

            //下面
            arcs = new ArcSegment();
            arcs.Point = new Point(this.Width * 0.75, this.Height);
            arcs.Size = new Size()
            {
                Height = this.Height / 2,
                Width = this.Width * 0.25
            };
            arcs.SweepDirection = SweepDirection.Clockwise;
            psc.Add(arcs);
            //中间最右边线
            arcs = new ArcSegment();
            arcs.Point = new Point(0, this.Height);
            psc.Add(arcs);
        }

    }
}

