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
    public class TP_Button : MonitorControl
    {
        public TP_Button()
        {
            Content = _image;
            Stretch = Stretch.Fill;
        }

        #region 属性
        public override event EventHandler Selected;
        private Image _image = new Image();

        private static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register("Source",
            typeof(ImageSource), typeof(TP), new PropertyMetadata(null));

        public override ImageSource Source
        {
            get { return (ImageSource)_image.GetValue(Image.SourceProperty); }
            set { _image.SetValue(Image.SourceProperty, value); }
        }

        private static readonly DependencyProperty StretchProperty =
            DependencyProperty.Register("Stretch",
            typeof(Stretch), typeof(TP), new PropertyMetadata(Stretch.Fill));

        public Stretch Stretch
        {
            get { return (Stretch)_image.GetValue(Image.StretchProperty); }
            set { _image.SetValue(Image.StretchProperty, value); }
        }
        #endregion

        #region 场景,TP属性
        /// <summary>
        /// 将对象的ScreenElement的ChildScreenID解析为场景 
        /// </summary>
        /// <returns></returns>
        private List<t_Screen> GetChildScreenID()
        {
            string mScreenID = base.ScreenElement.ChildScreenID;
            if (mScreenID == "0")
            {
                return null;
            }
            List<t_Screen> listScreen = new List<t_Screen>();
            string[] attrS = mScreenID.Split(';');
            foreach (string str in attrS)
            {
                mScreenID = str.Replace(";", "");
                string[] attr = mScreenID.Split('#');
                if (attr.Length == 2)
                {
                    int Scrennid = Convert.ToInt32(attr[1]);
                    t_Screen t = LoadScreen.listScreen.Single(a => a.ScreenID == Scrennid);
                    listScreen.Add(t);
                }
            }
            return listScreen;
        }
        #endregion

      
        public override void DesignMode()
        {
            if (!IsDesignMode)
            {
                AdornerLayer = new Adorner(this);
                var menu = new ContextMenu();
                var menuItem = new MenuItem() { Header = "属性" };
                menuItem.Click += PropertyMenuItem_Click;
                AdornerLayer.Selected += OnSelected;
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

        TP_ButtonSetProperty tpp; 
        private void PropertyMenuItem_Click(object sender, RoutedEventArgs e)
        {
          tpp=  new TP_ButtonSetProperty(this);           
          tpp.Show();
        }

        public override object GetRootControl()
        {
            return this;
        }
    }
}
