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
                if (htmlColr.IndexOf("RGB(") == 0)
                {
                    string[] rgb = htmlColr.ToUpper().Replace("RGB(", "").Replace(")", "").Split(',');
                    if (rgb.Length == 3)//RGB(177,255,255)
                    {
                        r=Convert.ToByte(int.Parse(rgb[0]));
                        g=Convert.ToByte(int.Parse(rgb[1]));
                        b=Convert.ToByte(int.Parse(rgb[2]));
                    }
                }
                else
                {
                    r = Convert.ToByte(htmlColr.Substring(baseIndex, 2), 16);
                    g = Convert.ToByte(htmlColr.Substring(baseIndex += 2, 2), 16);
                    b = Convert.ToByte(htmlColr.Substring(baseIndex += 2, 2), 16);
                }
                return Color.FromArgb(a, r, g, b);

                //ColorTranslator.FromHtml(strColor);
            }
            catch
            {
                return Colors.White;
            }
        }
    }
}
