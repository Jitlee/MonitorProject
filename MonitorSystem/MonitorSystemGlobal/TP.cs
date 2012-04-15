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
    public class TP : MonitorControl
    {

        public TP()
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

        public  ImageSource Source
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
        private t_Screen GetChildScreenID()
        {
            string mScreenID = base.ScreenElement.ChildScreenID;
            if (mScreenID == "0")
            {
                return null;
            }
            mScreenID = mScreenID.Replace(";", "");
            string[] attr=mScreenID.Split('#');
            if (attr.Length == 2)
            {
                int Scrennid=Convert.ToInt32(attr[1]);
                t_Screen t = LoadScreen.listScreen.Single(a => a.ScreenID == Scrennid);
                //return LoadScreen.listScreen.Where().First();
                return t;
            }
            return null;
        }
        #endregion

      
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

        TPSetProperty tpp = new TPSetProperty();
        private void PropertyMenuItem_Click(object sender, RoutedEventArgs e)
        {
            tpp.Closing += new EventHandler<System.ComponentModel.CancelEventArgs>(tpp_Closing);
            tpp.Screen = GetChildScreenID();
            tpp.Show();
        }

        protected void tpp_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (tpp.IsOK)
            {
                this.ScreenElement.ChildScreenID = string.Format("{0}#{1};", tpp.Screen.ScreenName, 
                    tpp.Screen.ScreenID);
                //MessageBox.Show(tpp.Screen.ScreenName);
            }
        }

        public override void SetPropertyValue()
        {
           
        }

        public override object GetRootControl()
        {
            return this;
        }
    }
}
