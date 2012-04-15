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
using System.Collections.ObjectModel;

namespace MonitorSystem.MonitorSystemGlobal
{
    public class ScreenAddShowName
    {
        public string ScreenShowName { get; set; }
        public string ScreenName { get; set; }

        public t_Screen Screen { get; set; }
    }

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
        public ObservableCollection<ScreenAddShowName> GetChildScreenObj()
        {
            string mScreenID = base.ScreenElement.ChildScreenID;
            if (mScreenID == "0")
            {
                return null;
            }
            ObservableCollection<ScreenAddShowName> listScreenShow = new ObservableCollection<ScreenAddShowName>();
            string[] attrS = mScreenID.Split(';');
            foreach (string str in attrS)
            {
                mScreenID = str.Replace(";", "");
                string[] attr = mScreenID.Split('#');
                if (attr.Length == 2)
                {
                    int Scrennid = Convert.ToInt32(attr[1]);
                    t_Screen t = LoadScreen.listScreen.Single(a => a.ScreenID == Scrennid);

                    ScreenAddShowName mShow = new ScreenAddShowName();
                    mShow.ScreenName = t.ScreenName ;
                    mShow.Screen = t;
                    mShow.ScreenShowName = attr[0] ;
                    listScreenShow.Add(mShow);
                }
            }
            return listScreenShow;
        }

        /// <summary>
        /// 设置属性
        /// </summary>
        /// <param name="litobj"></param>
        public void SetChildScreen(ObservableCollection<ScreenAddShowName> litobj)
        {
            string strScreen = "";
            if (litobj == null)
                strScreen = "0";
            else if (litobj.Count == 0)
                strScreen = "0";
            else
            {
                foreach (ScreenAddShowName obj in litobj)
                {
                    strScreen += string.Format("{0}#{1};", obj.ScreenShowName, obj.Screen.ScreenID);
                }
            }
            ScreenElement.ChildScreenID = strScreen;
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

        public override void SetPropertyValue()
        {
            //throw new NotImplementedException();
        }
        public override object GetRootControl()
        {
            return this;
        }
    }
}
