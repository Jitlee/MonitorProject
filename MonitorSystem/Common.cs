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

        public static Color StringToColor(string htmlColr)
        {
            try
            {
                int baseIndex = 1;
                byte a, r, g, b; a = r = g = b = 255;
                if (htmlColr.Length == 9)
                {
                    a = Convert.ToByte(htmlColr.Substring(baseIndex, 2), 16); baseIndex += 2;
                }
                r = Convert.ToByte(htmlColr.Substring(baseIndex, 2), 16);
                g = Convert.ToByte(htmlColr.Substring(baseIndex += 2, 2), 16);
                b = Convert.ToByte(htmlColr.Substring(baseIndex += 2, 2), 16);
                return Color.FromArgb(a, r, g, b);
            }
            catch
            {
                return Colors.White;
            }
        }
    }
}
