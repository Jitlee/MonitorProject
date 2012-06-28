﻿using System;
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

        public static bool ConvertToBool(string strValue)
        {
            strValue = strValue.ToUpper();
            if(string.IsNullOrEmpty(strValue))
                return false;
            if (strValue == "0")
                return false;
            if (strValue == "1")
                return true;
            if (strValue == "TRUE" || strValue== "FALSE")
                return Convert.ToBoolean(strValue);
            return false;
        }



        #region Font
        /// <summary>
        /// 中文转英文
        /// </summary>
        /// <returns></returns>
        public static string GetFontEn(string str)
        {
            switch (str.Trim())
            {
                case "隶书":
                    str = "LiSu";
                    break;
                case "幼圆":
                    str = "YouYuan";
                    break;
                case "舒体":
                    str = "FZShuTi";
                    break;
                case "姚体":
                    str = "FZYaoti";
                    break;
                case "楷体":
                    str = "STKaiti";
                    break;
                case "宋体":
                    str = "STSong";
                    break;
                case "中宋":
                    str = "STZhongsong";
                    break;
                case "仿宋":
                    str = "STFangsong";
                    break;
                case "彩云":
                    str = "STCaiyun";
                    break;
                case "琥珀":
                    str = "STHupo";
                    break;
                case "行楷":
                    str = "STXingkai";
                    break;
                case "新魏":
                    str = "STXinwei";
                    break;
                case "细黑":
                    str = "STXihei";
                    break;
                default:
                    str = "STSong";
                    break;
            }
            return str;
        }

        /// <summary>
        /// 英文转中文
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetFontCN(string str)
        {
            switch (str.Trim())
            {
                case "LiSu":
                    str = "隶书";
                    break;
                case "YouYuan":
                    str = "幼圆";
                    break;
                case "FZShuTi":
                    str = "舒体";
                    break;
                case "FZYaoti":
                    str = "姚体";
                    break;
                case "STKaiti":
                    str = "楷体";
                    break;
                case "STSong":
                    str = "宋体";
                    break;
                case "STZhongsong":
                    str = "中宋";
                    break;
                case "STFangsong":
                    str = "仿宋";
                    break;
                case "STCaiyun":
                    str = "彩云";
                    break;
                case "STHupo":
                    str = "琥珀";
                    break;
                case "STXingkai":
                    str = "行楷";
                    break;
                case "STXinwei":
                    str = "新魏";
                    break;
                case "STXihei":
                    str = "细黑";
                    break;
                default:
                    str = "宋体";
                    break;
            }
            return str;
        }
        #endregion
    }
}
