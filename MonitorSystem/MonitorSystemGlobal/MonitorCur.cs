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
using MonitorSystem.Web.Moldes;
using System.Collections.Generic;

namespace MonitorSystem.MonitorSystemGlobal
{
    public class MonitorCur : MonitorControl
    {
        Ellipse _mElli = new Ellipse();
        public MonitorCur()
        {
            _mElli.StrokeThickness = 1;
            _mElli.Stroke = new SolidColorBrush(Colors.Black);
            _mElli.Fill = new SolidColorBrush(Colors.White);

            Content = _mElli;
        }
        public override event EventHandler Selected;

        #region 属性
        private string[] m_BrowsableProperties = new string[] { "Left", "Top", "Width", "Height", "FontFamily", "FontSize","Translate", "Foreground","Transparent"
            ,"Radius" };

        public override string[] BrowsableProperties
        {
            get { return m_BrowsableProperties; }
            set { m_BrowsableProperties = value; }
        }

        private static readonly DependencyProperty TransparentProperty =
          DependencyProperty.Register("Transparent",
          typeof(int), typeof(MonitorText), new PropertyMetadata(0));
        private int _Transparent;
        public int Transparent
        {
            get { return _Transparent; }
            set
            {
                _Transparent = value;
                if (value == 1)
                {
                    _mElli.Fill = new SolidColorBrush();
                }
                else
                {
                    _mElli.Fill = new SolidColorBrush(Colors.White);                    
                }
                if (ScreenElement != null)
                    ScreenElement.Transparent = value;
            }

        }

        private static readonly DependencyProperty LinearChangeProperty =
          DependencyProperty.Register("Radius",
          typeof(int), typeof(MonitorText), new PropertyMetadata(0));
        private int _Radius =0;
         public int Radius
        {
            get { return _Radius; }
            set {
                _Radius = value;
                SetAttrByName("Radius", value);
            }
        }
        #endregion

        public override void DesignMode()
        {
            if (!IsDesignMode)
            {
                AdornerLayer = new Adorner(this);
                AdornerLayer.Selected += OnSelected;
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
        
        public override void SetPropertyValue()
        {
            foreach (t_ElementProperty pro in ListElementProp)
            {
                if (pro.PropertyName == "Radius")
                {
                    Radius = int.Parse(pro.PropertyValue);
                }
            }
        }

        public override void SetCommonPropertyValue()
        {
            this.SetValue(Canvas.LeftProperty, (double)ScreenElement.ScreenX);
            this.SetValue(Canvas.TopProperty, (double)ScreenElement.ScreenY);
            Transparent = ScreenElement.Transparent.Value;
            this.Width = (double)ScreenElement.Width;
            this.Height = (double)ScreenElement.Height;
        }

        public List<t_ElementProperty> GetProperty()
        {
            return ListElementProp;
        }

        public override object GetRootControl()
        {
            return this;
        }
    }
}

        
    