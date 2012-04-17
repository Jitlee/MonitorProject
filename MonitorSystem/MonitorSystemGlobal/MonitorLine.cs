using System;
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
using System.Linq;
using MonitorSystem.Web.Moldes;

namespace MonitorSystem.MonitorSystemGlobal
{
    public class MonitorLine : MonitorControl
    {
        Line _mLin = new Line();
        public MonitorLine()
        {
            Content = _mLin;
            //Stretch = Stretch.Fill;
        }

        #region 属性

        private string[] m_BrowsableProperties = new string[] { "Left", "Top", "Width", "Height", "FontFamily", "FontSize","Translate", "Foreground",
            "Stretch"};

        public override string[] BrowsableProperties
        {
            get { return m_BrowsableProperties; }
            set { m_BrowsableProperties = value; }
        }

        public override event EventHandler Selected;
       

        private static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register("Source",
            typeof(ImageSource), typeof(TP), new PropertyMetadata(null));

        public  ImageSource Source
        {
            get{
                return null;
            }
            set { }
        }

        private static readonly DependencyProperty StretchProperty =
            DependencyProperty.Register("Stretch",
            typeof(Stretch), typeof(TP), new PropertyMetadata(Stretch.Fill));

        public Stretch Stretch
        {
            get;
            set;
        }
        #endregion

       

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

        public override void DesignMode()
        {
            if (!IsDesignMode)
            {
                AdornerLayer = new Adorner(this);
            }
        }

        public override void SetPropertyValue()
        { 
            //throw new NotImplementedException();
        }

        public override void SetCommonPropertyValue()
        {
            this.SetValue(Canvas.LeftProperty, (double)ScreenElement.ScreenX);
            this.SetValue(Canvas.TopProperty, (double)ScreenElement.ScreenY);
            //Transparent = ScreenElement.Transparent.Value;
            this.Width = (double)ScreenElement.Width;
            this.Height = (double)ScreenElement.Height;
        }

        public override object GetRootControl()
        {
            return this;
        }
    }
}
 