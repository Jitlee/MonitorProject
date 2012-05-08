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
using MonitorSystem.MonitorSystemGlobal;
using System.ComponentModel;

namespace MonitorSystem.ZTControls
{
    /// <summary>
    /// 53	InputTextBox	2	Text.jpg	组态控件	输入框
    /// </summary>
    public class InputTextBox : MonitorControl
    {
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
                AdornerLayer.Editabled = true;
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

        public override object GetRootControl()
        {
            return this;
        }

        public override event EventHandler Selected;

        public override void SetPropertyValue()
        {
            
        }

        public override void SetCommonPropertyValue()
        {
            this.SetValue(Canvas.LeftProperty, (double)ScreenElement.ScreenX);
            this.SetValue(Canvas.TopProperty, (double)ScreenElement.ScreenY);
            this.Width = (double)ScreenElement.Width;
            this.Height = (double)ScreenElement.Height;
        }

        private string[] _browsableProperties = new[] { "BackColor", "ForeColor", "MyText", "MyScrollBars" };
        public override string[] BrowsableProperties
        {
            get { return _browsableProperties; }
            set { _browsableProperties = value; }
        }

        #region 属性

        private static readonly DependencyProperty BackColorProperty =
            DependencyProperty.Register("BackColor",
            typeof(Color), typeof(InputTextBox), new PropertyMetadata(Colors.White, new PropertyChangedCallback(BackColor_Changed)));

        public Color BackColor
        {
            get { return (Color)this.GetValue(BackColorProperty); }
            set { this.SetValue(BackColorProperty, value); }
        }

        private static void BackColor_Changed(DependencyObject element, DependencyPropertyChangedEventArgs e)
        {
            InputTextBox InputTextBox = (InputTextBox)element;
            InputTextBox.OnBackColorChanged((Color)e.NewValue, (Color)e.OldValue);
        }

        public void OnBackColorChanged(Color oldValue, Color newValue)
        {
            PaintBackground();
        }

        private static readonly DependencyProperty ForeColorProperty =
            DependencyProperty.Register("ForeColor",
            typeof(Color), typeof(InputTextBox), new PropertyMetadata(Colors.Black, new PropertyChangedCallback(ForeColor_Changed)));

        public Color ForeColor
        {
            get { return (Color)this.GetValue(ForeColorProperty); }
            set { this.SetValue(ForeColorProperty, value); }
        }

        private static void ForeColor_Changed(DependencyObject element, DependencyPropertyChangedEventArgs e)
        {
            InputTextBox InputTextBox = (InputTextBox)element;
            InputTextBox.OnForeColorChanged((Color)e.NewValue, (Color)e.OldValue);
        }

        public void OnForeColorChanged(Color oldValue, Color newValue)
        {
            SetForeground();
        }

        public static readonly DependencyProperty MyTextProperty =
            DependencyProperty.Register("MyText", typeof(string), typeof(InputTextBox), new PropertyMetadata(string.Empty));

        public string MyText
        {
            get { return (string)_textBox.GetValue(TextBox.TextProperty); }
            set { _textBox.SetValue(TextBox.TextProperty, value); }
        }

        public static readonly DependencyProperty MyScrollBarsProperty =
            DependencyProperty.Register("MyScrollBars", typeof(string), typeof(InputTextBox), new PropertyMetadata("1", new PropertyChangedCallback(MyScrollBars_Changed)));

        [DefaultValue("1"), Description("1为无,2为垂直滚动条,3为水平滚动条,4为全部"), Category("我的属性")]
        public string MyScrollBars
        {
            get { return (string)this.GetValue(MyScrollBarsProperty); }
            set { this.SetValue(MyScrollBarsProperty, value); }
        }

        private static void MyScrollBars_Changed(DependencyObject element, DependencyPropertyChangedEventArgs e)
        {
            InputTextBox InputTextBox = (InputTextBox)element;
            InputTextBox.OnMyScrollBarsChanged((string)e.OldValue, (string)e.NewValue);
        }

        public void OnMyScrollBarsChanged(string oldValue, string newValue)
        {
            SetScrollBar(newValue);
        }
        #endregion

        private TextBox _textBox = new TextBox();

        public InputTextBox()
        {
            this.Content = _textBox;

            SetForeground();

            PaintBackground();

            SetScrollBar(MyScrollBars);

            _textBox.GotFocus += (o, e) => {
                AdornerLayer.IsSelected = true; AdornerLayer.OnSelected();
                _textBox.TextChanged -= Text_Changed;
                _textBox.TextChanged += Text_Changed;
            };
            _textBox.LostFocus += (o, e) => { 
                _textBox.TextChanged -= Text_Changed;
            };
        }

        private void Text_Changed(object sender, TextChangedEventArgs e)
        {
            AdornerLayer.OnSelected();
        }

        private void SetForeground()
        {
            _textBox.Foreground = new SolidColorBrush(ForeColor);
        }

        private void PaintBackground()
        {
            _textBox.Background = new SolidColorBrush(BackColor);
        }

        public void SetScrollBar(string value)
        {
            if (value.ToUpper().Trim() == "3")
            {
                _textBox.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
                _textBox.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;
            }
            else if (value.ToUpper().Trim() == "2")
            {
                _textBox.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
                _textBox.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
            }
            else if (value.ToUpper().Trim() == "4")
            {
                _textBox.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
                _textBox.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
            }
            else if (value.ToUpper().Trim() == "1")
            {
                _textBox.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
                _textBox.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
            }
        }
    }
}
