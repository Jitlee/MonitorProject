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
        TextBox _mRect = new TextBox();
        public TP_Button()
        {
            //_mRect.StrokeThickness = 1;
            //_mRect.Stroke = new SolidColorBrush(Colors.Black);
            //_mRect.Fill = new SolidColorBrush(Colors.White);

            Content = _mRect;
        }

        #region 属性
        public override event EventHandler Selected;

        private static readonly DependencyProperty TransparentProperty =
            DependencyProperty.Register("Transparent",
            typeof(int), typeof(MonitorText), new PropertyMetadata(0));
        private int _Transparent;
        public int Transparent
        {
            get { return _Transparent; }
            set
            {
                if (value == 1)
                {
                    _mRect.Background = new SolidColorBrush();
                }
                else
                {
                    _mRect.Background = new SolidColorBrush(Colors.White);
                }

                _Transparent = value;
                if (ScreenElement != null)
                    ScreenElement.Transparent = value;
            }

        }

        private static readonly DependencyProperty HaveEdgeProperty =
          DependencyProperty.Register("HaveEdge",
          typeof(bool), typeof(MonitorText), new PropertyMetadata(false));
        private bool _HaveEdge;
        public bool HaveEdge
        {
            get { return _HaveEdge; }
            set
            {
                if (value)
                {
                    _mRect.BorderBrush = new SolidColorBrush(Colors.Black);
                }
                else
                {
                    _mRect.BorderBrush = new SolidColorBrush();
                }

                _HaveEdge = value;
                SetAttrByName("HaveEdge", value);
            }
        }
        
        private static readonly DependencyProperty TitleProperty =
          DependencyProperty.Register("Title",
          typeof(string), typeof(MonitorText), new PropertyMetadata(""));
         private string _Title;
         public string Title
         {
             get { return _Title; }
             set
             {
                 _mRect.Text = value;
                 _Title = value;
                 SetAttrByName("Title", value);
             }
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
            foreach (t_ElementProperty pro in ListElementProp)
            {
                if (pro.PropertyName == "Title")
                {
                    Title = pro.PropertyValue;
                }
                else if (pro.PropertyName == "HaveEdge")
                {
                    HaveEdge =bool.Parse( pro.PropertyValue);
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

        public override object GetRootControl()
        {
            return this;
        }
    }
}
