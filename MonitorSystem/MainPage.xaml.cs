using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace MonitorSystem
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();

            this.Content = new LoadScreen();
            //LoadPro();
        }
        FloatableWindow f = new FloatableWindow();
        PropertyMain prop = new PropertyMain();
        private void LoadPro()
        {
         
            f.ParentLayoutRoot = LayoutRoot;
            f.Content = prop;
            f.Margin = new Thickness(500,5,0,0);
            f.Width = 300;
            f.Height=500;
            f.Title = "设计";
            f.MaxHeight = 500;
            f.MaxWidth = 400;
            //f.IsEnabledChanged +=new DependencyPropertyChangedEventHandler(f_IsEnabledChanged);

            f.Show();
            
            f.SizeChanged +=new SizeChangedEventHandler(f_SizeChanged);
        }
        protected void f_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            
        }
       protected void f_SizeChanged(object sender, SizeChangedEventArgs e)
       {
          
         //  e.NewSize.Height;
           prop.ChangeSize(e.NewSize.Height, e.NewSize.Width);
       }
    }
}
