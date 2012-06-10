﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using MonitorSystem.MonitorSystemGlobal;
using MonitorSystem.Web.Moldes;
using System.Windows.Input;
using MonitorSystem.Controls;

namespace MonitorSystem.ZTControls
{
    /// <summary>
    /// 50	ExtProControl	2	Text.jpg	组态控件	外部应用程序新版
    /// </summary>
    public class ExtProControl : MonitorControl
    {
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

        public override object GetRootControl()
        {
            return this;
        }

        public override event EventHandler Selected;

        public override void SetPropertyValue()
        {
            // 2009-1-17
            foreach (var pro in ListElementProp)
            {
                try
                {

                    string name = pro.PropertyName.Trim().ToUpper();
                    string value = pro.PropertyValue.Trim();
                    if (name == "BackColor".ToUpper())
                    {
                        BackColor = Common.StringToColor(value);
                    }
                    else if (name == "Font".ToUpper())
                    { 

                    }
                    else if (name == "ForeColor".ToUpper())
                    {
                        ForeColor = Common.StringToColor(value);
                    }
                    else if (name == "ExtPath".ToUpper())
                    {
                        ExtPath = value;
                    }
                    else if (name == "ExtParam".ToUpper())
                    {
                        ExtParam = value;
                    }
                        
                    else if (name == "MyText".ToUpper())
                    {
                        //this.button1.Text = value;
                        MyText = value;
                    }
                    else if (name == "BackImageName".ToUpper())
                    {
                        if (value != null && value.Trim() != "")
                            BackImageName = value.Trim();
                    }
                    else if (name == "myTextImageRelation".ToUpper())
                    {
                        if (value != null && value.Trim() != "")
                            myTextImageRelation = GetTextImageRelationFromStr(value.Trim());
                    }
                }
                catch
                {
                }

            }
        }

        public override void SetCommonPropertyValue()
        {
            this.SetValue(Canvas.LeftProperty, (double)ScreenElement.ScreenX);
            this.SetValue(Canvas.TopProperty, (double)ScreenElement.ScreenY);
            this.Width = (double)ScreenElement.Width;
            this.Height = (double)ScreenElement.Height;
        }

        private string[] _browsableProperties = new string[] { "Width", "Height", "Left", "Top", "FontFamily", "FontSize",
            "Location", "Size", "BackColor", "Transparent", "Font", "ForeColor", "LevelNo", "MyText", "ExtPath", "ExtParam", "BackImageName", "myTextImageRelation" };
        public override string[] BrowsableProperties
        {
            get { return _browsableProperties; }
            set { _browsableProperties = value; }
        }

        #region 属性

        private static readonly DependencyProperty BackColorProperty =
            DependencyProperty.Register("BackColor",
            typeof(Color), typeof(ExtProControl), new PropertyMetadata(Colors.White, new PropertyChangedCallback(BackColor_Changed)));

        public Color BackColor
        {
            get { return (Color)this.GetValue(BackColorProperty); }
            set { this.SetValue(BackColorProperty, value); SetAttrByName("BackColor", value); }
        }

        private static void BackColor_Changed(DependencyObject element, DependencyPropertyChangedEventArgs e)
        {
            ExtProControl ExtProControl = (ExtProControl)element;
            ExtProControl.OnBackColorChanged((Color)e.NewValue, (Color)e.OldValue);
        }

        public void OnBackColorChanged(Color oldValue, Color newValue)
        {
            PaintBackground();
        }

        private static readonly DependencyProperty ForeColorProperty =
            DependencyProperty.Register("ForeColor",
            typeof(Color), typeof(ExtProControl), new PropertyMetadata(Colors.Black, new PropertyChangedCallback(ForeColor_Changed)));

        public Color ForeColor
        {
            get { return (Color)this.GetValue(ForeColorProperty); }
            set { this.SetValue(ForeColorProperty, value); SetAttrByName("ForeColor", value); }
        }

        private static void ForeColor_Changed(DependencyObject element, DependencyPropertyChangedEventArgs e)
        {
            ExtProControl ExtProControl = (ExtProControl)element;
            ExtProControl.OnForeColorChanged((Color)e.NewValue, (Color)e.OldValue);
        }

        public void OnForeColorChanged(Color oldValue, Color newValue)
        {
            SetForeground();
        }

        public static readonly DependencyProperty MyTextProperty =
            DependencyProperty.Register("MyText", typeof(string), typeof(ExtProControl), new PropertyMetadata(string.Empty));

        public string MyText
        {
            get { return (string)_text.GetValue(TextBlock.TextProperty); }
            set { _text.SetValue(TextBlock.TextProperty, value); SetAttrByName("MyText", value); }
        }

        // 摘要:
        //     指定控件上的文本和图像彼此之间的相对位置。
        public enum TextImageRelation
        {
            // 摘要:
            //     指定图像和文本共享控件上的同一空间。
            Overlay = 0,
            //
            // 摘要:
            //     指定图像垂直显示在控件文本的上方。
            ImageAboveText = 1,
            //
            // 摘要:
            //     指定文本垂直显示在控件图像的上方。
            TextAboveImage = 2,
            //
            // 摘要:
            //     指定图像水平显示在控件文本的前方。
            ImageBeforeText = 4,
            //
            // 摘要:
            //     指定文本水平显示在控件图像的前方。
            TextBeforeImage = 8,
        }

        private TextImageRelation GetTextImageRelationFromStr(string s)
        {
            //System .Windows .Forms .TextImageRelation .ImageAboveText;
            //System .Windows .Forms .TextImageRelation.ImageBeforeText
            //System .Windows .Forms .TextImageRelation.Overlay;
            //System .Windows .Forms .TextImageRelation.TextAboveImage;
            //System .Windows .Forms .TextImageRelation.TextBeforeImage;
            if (string.IsNullOrEmpty(s))
            {
                return TextImageRelation.ImageBeforeText;
            }
            TextImageRelation t;
            switch (s.Trim())
            {
                case "ImageAboveText":
                    t = TextImageRelation.ImageAboveText;
                    break;
                case "ImageBeforeText":
                    t = TextImageRelation.ImageBeforeText;
                    break;
                case "Overlay":
                    t = TextImageRelation.Overlay;
                    break;
                case "TextAboveImage":
                    t = TextImageRelation.TextAboveImage;
                    break;
                case "TextBeforeImage":
                    t = TextImageRelation.TextBeforeImage;
                    break;
                default:
                    t = TextImageRelation.ImageBeforeText;
                    break;

            }
            return t;
        }

        private string GetStrFromTextImageRelation(TextImageRelation t)
        {
            string s = null;
            if (t == TextImageRelation.ImageAboveText)
            {
                s = "ImageAboveText";
            }
            else if (t == TextImageRelation.ImageBeforeText)
            {
                s = "ImageBeforeText";
            }
            else if (t == TextImageRelation.Overlay)
            {
                s = "Overlay";
            }
            else if (t == TextImageRelation.TextAboveImage)
            {
                s = "TextAboveImage";
            }
            else if (t == TextImageRelation.TextBeforeImage)
            {
                s = "TextBeforeImage";
            }
            if (string.IsNullOrEmpty(s))
            {
                s = "ImageBeforeText";
                return s;
            }
            else
            {
                return s;
            }
        }

        public static readonly DependencyProperty myTextImageRelationProperty =
            DependencyProperty.Register("myTextImageRelation", typeof(TextImageRelation), typeof(ExtProControl), new PropertyMetadata(default(TextImageRelation), new PropertyChangedCallback(myTextImageRelation_Changed)));

        [DefaultValue(""), Description("设置文字字体摆放样式"), Category("我的属性")]
        public TextImageRelation myTextImageRelation
        {
            get { return (TextImageRelation)this.GetValue(myTextImageRelationProperty); }
            set { this.SetValue(myTextImageRelationProperty, value); SetAttrByName("myTextImageRelation", GetStrFromTextImageRelation(value)); }
        }

        private static void myTextImageRelation_Changed(DependencyObject element, DependencyPropertyChangedEventArgs e)
        {
            ExtProControl ExtProControl = (ExtProControl)element;
            ExtProControl.OnmyTextImageRelationChanged((TextImageRelation)e.OldValue, (TextImageRelation)e.NewValue);
        }

        public void OnmyTextImageRelationChanged(TextImageRelation oldValue, TextImageRelation newValue)
        {
            SetTextImageRelation();
        }

        public static readonly DependencyProperty BackImageNameProperty =
           DependencyProperty.Register("BackImageName", typeof(string), typeof(ExtProControl), new PropertyMetadata("", new PropertyChangedCallback(BackImageName_Changed)));

        [ImageAttribute("PIC\\ButtonImage")]
        [DefaultValue(""), Description("背景图片名字\r\n注意：\r\n背景图片一定要放在程序\r\n所在目录的\\PIC\\ButtonImage下\r\n必须带后缀名"), Category("我的属性")]
        public string BackImageName
        {
            get { return (string)this.GetValue(BackImageNameProperty); }
            set { this.SetValue(BackImageNameProperty, value); SetAttrByName("BackImageName", value); }
        }

        private static void BackImageName_Changed(DependencyObject element, DependencyPropertyChangedEventArgs e)
        {
            ExtProControl ExtProControl = (ExtProControl)element;
            ExtProControl.OnBackImageNameChanged((string)e.OldValue, (string)e.NewValue);
        }

        public void OnBackImageNameChanged(string oldValue, string newValue)
        {
            _image.Source = new BitmapImage(new Uri(Application.Current.Host.Source, string.Concat("../Upload/Pic/ButtonImage/", newValue.Trim('/'))));
        }

        public static readonly DependencyProperty ExtPathProperty =
           DependencyProperty.Register("ExtPath", typeof(string), typeof(ExtProControl), new PropertyMetadata("", new PropertyChangedCallback(ExtPath_Changed)));

        [DefaultValue(""), Description("外部程序绝对路径"), Category("我的属性")]
        public string ExtPath
        {
            get { return (string)this.GetValue(ExtPathProperty); }
            set { this.SetValue(ExtPathProperty, value); SetAttrByName("ExtPath", value); }
        }

        private static void ExtPath_Changed(DependencyObject element, DependencyPropertyChangedEventArgs e)
        {
            ExtProControl ExtProControl = (ExtProControl)element;
            ExtProControl.OnExtPathChanged((string)e.OldValue, (string)e.NewValue);
        }

        public void OnExtPathChanged(string oldValue, string newValue)
        {
        }

        public static readonly DependencyProperty ExtParamProperty =
           DependencyProperty.Register("ExtParam", typeof(string), typeof(ExtProControl), new PropertyMetadata("", new PropertyChangedCallback(ExtParam_Changed)));

        [DefaultValue(""), Description("外部程序参数,\r只有打开浏览器才需要填写参数"), Category("我的属性")]
        public string ExtParam
        {
            get { return (string)this.GetValue(ExtParamProperty); }
            set { this.SetValue(ExtParamProperty, value); SetAttrByName("ExtParam", value); }
        }

        private static void ExtParam_Changed(DependencyObject element, DependencyPropertyChangedEventArgs e)
        {
            ExtProControl ExtProControl = (ExtProControl)element;
            ExtProControl.OnExtParamChanged((string)e.OldValue, (string)e.NewValue);
        }

        public void OnExtParamChanged(string oldValue, string newValue)
        {
        }
        #endregion

        private TextBlock _text = new TextBlock() { HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center, };
        private Image _image = new Image();
        private Button _button = new Button();
        private Grid _grid = new Grid();
        private readonly DelegateCommand<t_Screen> _command;

        public ExtProControl()
        {
            this.Content = _button;

            _grid.Children.Add(_image);
            _grid.Children.Add(_text);

            _button.Content = _grid;

            SetForeground();

            PaintBackground();

            SetTextImageRelation();

            //_button.Click += Button_Click;

            //_command = new DelegateCommand<t_Screen>(ShowName);

            _button.Click +=_button_Click;
        }
        public void _button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(ExtPath))
                return;
            string mUrl =ExtPath;
            if (!string.IsNullOrEmpty(ExtParam))
            {
                mUrl += "?" + ExtParam.Trim();
            }
            if (!(mUrl.IndexOf("http") == 0))
                mUrl = "http://" + mUrl;
            System.Windows.Browser.HtmlPage.Window.Navigate(new Uri(mUrl, UriKind.RelativeOrAbsolute), "_blank");
            //
            //System.Windows.Browser.HtmlPage.Window.NavigateToBookmark(ExtPath);
        }
        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        System.Windows.Browser.HtmlPage.Window.Navigate(new Uri(ExtPath, UriKind.Absolute), "_blank");
        //    }
        //    catch (Exception ex)
        //    {
        //        return;
        //    }
        //}

        //private void ShowName(t_Screen screen)
        //{
        //    LoadScreen.Load(screen);
        //}

        private void SetTextImageRelation()
        {
            _image.SetValue(Grid.RowProperty, 0);
            _text.SetValue(Grid.RowProperty, 0);
            _image.SetValue(Grid.ColumnProperty, 0);
            _text.SetValue(Grid.ColumnProperty, 0);
            _grid.RowDefinitions.Clear();
            _grid.ColumnDefinitions.Clear();

            switch (myTextImageRelation)
            {
                case TextImageRelation.ImageAboveText:
                    _grid.RowDefinitions.Add(new RowDefinition());
                    _grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1d, GridUnitType.Auto) });

                    _text.SetValue(Grid.RowProperty, 1);
                    break;
                case TextImageRelation.ImageBeforeText:
                    _grid.ColumnDefinitions.Add(new ColumnDefinition());
                    _grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1d, GridUnitType.Auto) });
                    _text.SetValue(Grid.ColumnProperty, 1);
                    break;
                case TextImageRelation.Overlay:
                    break;
                case TextImageRelation.TextAboveImage:
                    _grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1d, GridUnitType.Auto) });
                    _grid.RowDefinitions.Add(new RowDefinition());
                    _image.SetValue(Grid.RowProperty, 1);
                    break;
                case TextImageRelation.TextBeforeImage:
                    _grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1d, GridUnitType.Auto) });
                    _grid.ColumnDefinitions.Add(new ColumnDefinition());
                    _image.SetValue(Grid.ColumnProperty, 1);
                    break;
            }
        }

        private void Text_Changed(object sender, TextChangedEventArgs e)
        {
            if (null != AdornerLayer)
            {
                AdornerLayer.OnSelected();
            }
            SetAttrByName("MyText", MyText);
        }

        private void SetForeground()
        {
            _text.Foreground = new SolidColorBrush(ForeColor);
        }

        private void PaintBackground()
        {
            _button.Background = new SolidColorBrush(BackColor);
        }
    }
}
