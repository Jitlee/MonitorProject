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
    public class MonitorText : MonitorControl
    {
        TextBox _mTxt = new TextBox();
        public MonitorText()
        {
            Content = _mTxt;
            //Stretch = Stretch.Fill;

            MyText = "";
        }

        #region 属性
        public override event EventHandler Selected;

        //MyText
        private static readonly DependencyProperty StretchProperty =
          DependencyProperty.Register("MyText",
          typeof(string), typeof(MonitorText), new PropertyMetadata(""));

        public string MyText
        {
            get { return _mTxt.Text; }
            set { _mTxt.Text = value;
            if (ScreenElement != null)
                ScreenElement.TxtInfo = value; 
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
            throw new NotImplementedException();
        }

        public override object GetRootControl()
        {
            return this;
        }
    }
}
