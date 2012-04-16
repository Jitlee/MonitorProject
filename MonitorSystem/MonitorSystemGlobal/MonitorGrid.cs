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
using MonitorSystem.Web.Moldes;
using System.Collections.Generic;

namespace MonitorSystem.MonitorSystemGlobal
{
    public class MonitorGrid: MonitorControl
    {
        TextBox _mTxt = new TextBox();
        public MonitorGrid()
        {
            Content = _mTxt;
        }
        public override event EventHandler Selected;

        #region 属性
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
                    _mTxt.Background=new SolidColorBrush();
                    _mTxt.BorderBrush = new SolidColorBrush();
                }
                else
                {
                    _mTxt.Background = new SolidColorBrush(Colors.White);
                    
                }
                
                if (ScreenElement != null)
                    ScreenElement.Transparent = value;
            }

        }

        private static readonly DependencyProperty RowCountProperty =
          DependencyProperty.Register("RowCount",
          typeof(int), typeof(MonitorText), new PropertyMetadata(0));
        private int _RowCount = 0;
        public int RowCount
        {
            get { return _RowCount; }
            set
            {
                _RowCount = value;
                SetAttrByName("RowCount", value);
            }
        }

        private static readonly DependencyProperty GridColorProperty =
         DependencyProperty.Register("GridColor",
         typeof(string), typeof(MonitorText), new PropertyMetadata(""));
        private string _GridColor = "";
        public string GridColor
        {
            get { return _GridColor; }
            set
            {
                _GridColor = value;
                SetAttrByName("GridColor", value);
            }
        }

        private static readonly DependencyProperty ColumnCountProperty =
          DependencyProperty.Register("ColumnCount",
          typeof(int), typeof(MonitorText), new PropertyMetadata(0));
        private int _ColumnCount = 0;
        public int ColumnCount
        {
            get { return _ColumnCount; }
            set
            {
                _ColumnCount = value;
                SetAttrByName("ColumnCount", value);
            }
        }

        private static readonly DependencyProperty LineWidthProperty =
          DependencyProperty.Register("LineWidth",
          typeof(int), typeof(MonitorText), new PropertyMetadata(0));
        private int _LineWidth = 0;
        public int LineWidth
        {
            get { return _LineWidth; }
            set
            {
                _LineWidth = value;
                SetAttrByName("LineWidth", value);
            }
        }
        
        #endregion

         public void SetLinearChange(bool IsEnable)
         {
             if (IsEnable)
             {

             }
         }


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
                if (pro.PropertyName == "RowCount")
                {

                    _RowCount = int.Parse(pro.PropertyValue);
                }
                else if (pro.PropertyName == "ColumnCount")
                {
                    _ColumnCount = int.Parse(pro.PropertyValue);
                }
                else if (pro.PropertyName == "LineWidth")
                {
                    _LineWidth = int.Parse(pro.PropertyValue);
                }
                else if (pro.PropertyName == "GridColor")
                {
                    GridColor = pro.PropertyValue;
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
