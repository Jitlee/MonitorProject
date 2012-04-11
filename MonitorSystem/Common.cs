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

namespace MonitorSystem
{
    public class Common
    {
        public static string TopUrl()
        {
            string strTopUrl = Application.Current.Host.Source.ToString()
                    .Replace("/ClientBin/MonitorSystem.xap", "");
            return strTopUrl;
        }
    }
}
