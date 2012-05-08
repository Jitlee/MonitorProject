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

        //public struct Font
        //{
        //    public double FontSize { get; set; }
        //    public FontWeight Font
        //    public FontFamily FontFamily { get; set; }
        //    public override string ToString()
        //    {
        //        return base.ToString();
        //    }
        //}

        //public Font GetFontFromStr(string strFont)
        //{
        //    if (strFont == null)
        //        return new Font("宋体", 12);
        //    // 设置字体
        //    string Name = "宋体";
        //    float fontSize = 12;
        //    FontStyle style = FontStyle.Regular;
        //    GraphicsUnit units = 0;
        //    byte gdiCharSet = 1;
        //    bool gdiVerti = false;

        //    int idx = strFont.IndexOf("Font:");
        //    if (idx != -1)
        //    {
        //        strFont = strFont.Substring(idx + 5);
        //        strFont = strFont.Remove(strFont.Length - 1);
        //        char[] slip = new char[] { ',' };
        //        string[] arrStr = strFont.Split(slip);
        //        foreach (string str in arrStr)
        //        {
        //            char[] slipKey = new char[] { '=' };
        //            string[] keyVal = str.Split(slipKey);
        //            int LEN = keyVal[0].Length;
        //            string tmp = "Name";
        //            int LEN2 = tmp.Length;
        //            if (keyVal[0].Equals(" Name", StringComparison.OrdinalIgnoreCase))
        //                Name = keyVal[1];
        //            if (keyVal[0].Equals(" Size", StringComparison.OrdinalIgnoreCase))
        //                fontSize = (float)(Convert.ToDouble(keyVal[1]));
        //            if (keyVal[0] == " Units")
        //                units = (GraphicsUnit)Convert.ToInt32(keyVal[1]);
        //            if (keyVal[0] == " GdiCharSet")
        //                gdiCharSet = Convert.ToByte(keyVal[1]);
        //            if (keyVal[0] == " GdiVerticalFont")
        //                gdiVerti = Convert.ToBoolean(keyVal[1]);
        //        }
        //    }
        //    Font tmpfont = new Font(Name, fontSize, style, units, gdiCharSet, gdiVerti);
        //    return tmpfont;
        //}
    }
}
