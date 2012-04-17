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

        private string[] m_BrowsableProperties = new string[] { "Left", "Top", "Width", "Height", "FontFamily", "FontSize",
            "Translate", "Foreground","Transparent","MyText","LinearChange","FromColor","ToColor" };

        public override string[] BrowsableProperties
        {
            get { return m_BrowsableProperties; }
            set { m_BrowsableProperties = value; }
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

        public override void SetCommonPropertyValue()
        {

        }
    }
}
