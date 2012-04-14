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
using MonitorSystem.Web.Moldes;

namespace MonitorSystem.MonitorSystemGlobal
{
    public abstract partial class MonitorControl : UserControl
    {
        public bool IsDesignMode { get { return null != AdornerLayer; } }
        protected Adorner AdornerLayer { get; set; }
        public abstract void DesignMode();
        public abstract void UnDesignMode();
        public abstract object GetRootControl();
        public abstract ImageSource Source{ get; set; }

        public abstract event EventHandler Selected;
        public t_Element ScreenElement{ get; set; }
        /// <summary>
        /// 控件状态，新添加的，或以保存的
        /// </summary>
        public ElementSate ElementState;
    }

   public enum ElementSate
{
    New, Save
}
}
