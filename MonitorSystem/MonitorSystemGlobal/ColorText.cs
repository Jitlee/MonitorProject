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

namespace MonitorSystem.MonitorSystemGlobal
{
    public class ColorText : MonitorControl
    {
        private readonly TextBlock _text = new TextBlock();

        public ColorText()
        {
            this.Content = _text;
        }

        public override void DesignMode()
        {
            throw new NotImplementedException();
        }

        public override void UnDesignMode()
        {
            throw new NotImplementedException();
        }

        public override object GetRootControl()
        {
            throw new NotImplementedException();
        }

        public override void SetPropertyValue()
        {
            throw new NotImplementedException();
        }

        public override event EventHandler Selected;

       
    }
}
