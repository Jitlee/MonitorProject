using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.ServiceModel.DomainServices.EntityFramework;
using System.ServiceModel.DomainServices.Hosting;
using System.ServiceModel.DomainServices.Server;
using MonitorSystem.Web.Moldes;

namespace MonitorSystem.Web.Servers
{
    class Analysis
    {
        //用于采集计算公式及校验类型表达式，表示接收到的数据的长度
        public int LENGTH(string strData)
        {
            return strData.Length;
        }

        //表示接收到的数据（系统不管该数据类型为ASCII或十六进制都用字符表示
        //例子：假如数据类型为ASCII，接收到的数据为1234ABC，函数ACHAR(4,2)的值为4A
        public string ACHAR(string strData, int p1, int p2)
        {
            if (0 == strData.Length)
            {
                Console.WriteLine("数据为空！");

                return "-1";
            }
            if (strData.Length < p2)
            {
                Console.WriteLine("截取的长度大于数据长度！");

                return "-1";
            }
            string strResult = strData.Substring(p1 - 1, p2);

            return strResult;
        }

        //表示接收到的数据（系统不管该数据类型为ASCII或十六进制都用字符表示）
        //假如数据类型为ASCII，接收到的数据为1234ABC，函数LCHAR(4,2)的值为34
        public string LCHAR(string strData, int p1, int p2)
        {
            if (0 == strData.Length)
            {
                Console.WriteLine("数据为空！");
                return "-1";
            }
            if (strData.Length < p2)
            {
                Console.WriteLine("截取的长度大于数据长度！");
                return "-1";
            }
            string strResult = strData.Substring(strData.Length - p1 - 1, p2);

            return strResult;
        }

        //表示接收到的数据全部做为字符对待，取从p1开始后的p2个字符，值为这些字符所表示的十六进制数（结果转化为十进制数）
        //例子：假如数据类型为ASCII，接收到的数据为1234ABC，函数A $(4,2)的值为74（十六进制为4A）
        public int Adollar(string strData, int p1, int p2)
        {
            if (0 == strData.Length)
            {
                Console.WriteLine("数据为空！");
                return -1;
            }
            if (strData.Length < p2 + p1)
            {
                Console.WriteLine("截取的长度大于数据长度！");
                return -1;
            }
            string strResult = strData.Substring(p1 - 1, p2);

            //16进制转换成10进制
            int iResult = Convert.ToInt32(strResult, 16);

            return iResult;
        }

        //表示接收到的数据全部做为字符对待，取从后面往前数p1开始前的p2个字符，值为这些字符所表示的十六进制数（结果转化为十进制数）
        //例子：假如数据类型为ASCII，接收到的数据为1234ABC，函数AL $(4,2)的值为52（十六进制为34）
        public int ALdollar(string strData, int p1, int p2)
        {
            if (0 == strData.Length)
            {
                Console.WriteLine("数据为空！");
                return -1;
            }
            if (strData.Length < p2 + p1)
            {
                Console.WriteLine("截取的长度大于数据长度！");
                return -1;
            }
            string strResult = strData.Substring(strData.Length - p1 - 1, p2);

            //16进制转换成10进制
            int iResult = Convert.ToInt32(strResult, 16);

            return iResult;
        }

        //表示接收到的数据全部做为字符对待，每个字符认为其由一个4位二进制码来表示（例如A为1010），即使不能用一个4位二进制码来表示也把其当为4位（例如除了0~9，ABCDEF的其它字符）
        //例子：假如数据类型为ASCII，接收到的数据为1K34ABC，函数AB$ (1,3)的值为0（二进制为000），AB$(9,4)的值为3（二进制为0011）
        public int ABdollar(string strData, int p1, int p2)
        {

            if (0 == strData.Length)
            {
                Console.WriteLine("数据为空！");
                return -1;
            }
            if (strData.Length * 4 < p1)
            {
                Console.WriteLine("截取的长度大于数据长度！");
                return -1;
            }
            string[] charsetTable = { "0000", "0001", "0010", "0011", "0100", "0101", "0110", "0111", "1000", "1001", "1010", "1011", "1100", "1101", "1110", "1111" };
            string strResult = "";
            for (int i = 0; i < strData.Length; ++i)
            {
                int tmp = 0;
                if ('0' <= strData[i] && strData[i] <= '9' || 'A' <= strData[i] && strData[i] <= 'F' || 'a' <= strData[i] && strData[i] <= 'f')
                {
                    tmp = Convert.ToInt32(strData.Substring(i, 1), 16);
                }

                strResult += charsetTable[tmp];
            }
            // 将二进制字符串转成16进制数
            int iResult = Convert.ToInt32(strResult.Substring(p1 - 1, p2), 2);

            return iResult;
        }

        //表示接收到的数据全部做为字符对待，每个字符认为其由一个4位二进制码来表示（例如A为1010），即使不能用一个4位二进制码来表示也把其当为4位（例如除了0~9，ABCDEF的其它字符）
        // 先从第p1个字节开始算，然后从第p2个位开始算，取出p3位的值.
        //例子：假如数据类型为ASCII，接收到的数据为1K34ABC，函数ABC$ (3,1,3)的值为1（二进制为001）
        public int ABCdollar(string strData, int p1, int p2, int p3)
        {
            if (0 == strData.Length)
            {
                Console.WriteLine("数据为空！");
                return -1;
            }
            if (strData.Length < p1)
            {
                Console.WriteLine("截取的长度大于数据长度！");
                return -1;
            }
            strData = strData.Substring(p1 - 1);
            string[] charsetTable = { "0000", "0001", "0010", "0011", "0100", "0101", "0110", "0111", "1000", "1001", "1010", "1011", "1100", "1101", "1110", "1111" };
            string strResult = "";
            for (int i = 0; i < strData.Length; ++i)
            {
                int tmp = 0;
                if ('0' <= strData[i] && strData[i] <= '9' || 'A' <= strData[i] && strData[i] <= 'F' || 'a' <= strData[i] && strData[i] <= 'f')
                {
                    tmp = Convert.ToInt32(strData.Substring(i, 1), 16);
                }

                strResult += charsetTable[tmp];
            }
            // 将二进制字符串转成16进制数
            int iResult = Convert.ToInt32(strResult.Substring(p1 - 1, p2), 2);

            return iResult;
        }

        //p1表示一个字符的码（例如A的码为65，1的码为49，TAB字符的码为9，空格的码为0），p2表示第几个，LONAC表示把采集到的数据当成是通过p1所代表的字符分隔的字符串，取第p2个被分隔的数据
        //例如接收的数据若为：121_213_415_1F2_789_122，LONAC('_'，2）为531（十六进制为213）
        public string LONAC(string strData, int p1, int p2)
        {
            if (0 == strData.Length)
            {
                Console.WriteLine("数据为空！");
                return "-1";
            }

            char cTmp = (char)p1;
            string strTemp = "";
            int iLength = 0;

            strTemp += (char)p1; ;

            for (int i = 0; i < p2; i++)
            {
                if (p2 - 1 == i)
                    iLength = strData.IndexOf(strTemp);
                else
                    strData = strData.Substring(strData.IndexOf(strTemp) + 1);
            }

            int iResult = Convert.ToInt32(strData.Substring(0, iLength), 16);

            strTemp = iResult.ToString();

            return strTemp;
        }

        //用法与LONAC(p1,p2)基本相同，不同的地方为：取到的数据当成十六进制，再把它转化为十进制
        public string LONAdollar(string strData, int p1, int p2)
        {
            if (0 == strData.Length)
            {
                Console.WriteLine("数据为空！");
                return "-1";
            }

            char cTmp = (char)p1;
            string strTemp = "";
            int iLength = 0;

            strTemp += (char)p1; ;

            for (int i = 0; i < p2; i++)
            {
                if (p2 - 1 == i)
                    iLength = strData.IndexOf(strTemp);
                else
                    strData = strData.Substring(strData.IndexOf(strTemp) + 1);
            }
            strTemp = strData.Substring(0, iLength);

            return strTemp;
        }

        //把p1及p2当成字符串，在接收到的串中，求出夹在p1及p2之间的字符串
        //接收到的串为AACD 100 MM200KK，则INSTRS(CD ，MM)的值为100
        string INSTRS(string strData, string p1, string p2)
        {
            if (0 == strData.Length || 0 == p1.Length || 0 == p2.Length)
            {
                Console.WriteLine("数据为空！");
                return "-1";
            }

            strData = strData.Substring(strData.IndexOf(p1, p1.Length) + p1.Length);

            return strData.Substring(0, strData.IndexOf(p2, p2.Length));
        }

        //把p1当成输入字符串，把p2当成整数序号，在p1串中，求出夹在空隔之间的第p2个字符串
        //例如：串为AACD 100 MM 200 KK 300，则SUBBSTR(AACD 100 MM 200 KK 300，2)的值为100
        string SUBBSTR(string strData, int p)
        {
            if (strData.Length == 0)
            {
                Console.WriteLine("数据为空！");
                return "-1";
            }

            int iLength = 0;

            for (int i = 0; i < p; i++)
            {
                if (p - 1 == i)
                    iLength = strData.IndexOf(" ", 0);
                else
                    strData = strData.Substring(strData.IndexOf(" ", 0) + 1);
            }

            return strData.Substring(0, iLength);
        }

        //把p1当成十进制数，把p1所代表的ASCII码当成十六进制，再转化为十进制
        //例如：DTOC$D(65)，65代表字符A，A所表示的十六进制为10，所以该函数的值为10
        public int DTOCdollarD(string strData)
        {
            if (strData.Length == 0)
            {
                Console.WriteLine("数据为空！");
                return -1;
            }

            string strResult = "";
            strResult += (char)Convert.ToInt32(strData, 10);

            //16进制转换成10进制
            int iResult = Convert.ToInt32(strResult, 16);

            return iResult;
        }

        //把p1当成十六进制数，$TOA把p1转化为十六进制所表示ASCII码
        //例如：$TOA(323230)，十六进制数32代表ASCII字符2，十六进制数30代表ASCII字符0，所以该函数的值为220
        public string dollarTOA(string strData)
        {
            if (strData.Length == 0)
            {
                Console.WriteLine("数据为空！");
                return "-1";
            }

            string strTemp = "", strResult = "";

            for (int i = 0; i < strData.Length; i += 2)
            {
                strTemp = strData.Substring(i, 2);

                //16进制转换成10进制
                int iResult = Convert.ToInt32(strTemp, 16);

                strResult += (char)iResult;
            }
            return strResult;
        }

        //把p1当成ASCII，ATO$把p1转化为十六进制所表示十六进制数码
        //例如：ATO$ (220)，ASCII字符2代表十六进制数32，ASCII字符0代表十六进制数30，所以该函数的值为323230
        public string ATOdollar(string strData)
        {
            if (strData.Length == 0)
            {
                Console.WriteLine("数据为空！");
                return "-1";
            }

            string strTemp = "", strResult = "";

            for (int i = 0; i < strData.Length; i++)
            {
                int iResult = strData[i];

                //10进制转换成16进制
                strTemp = Convert.ToString(iResult, 16);

                strResult += strTemp;
            }
            return strResult;
        }

        //把p1当成十进制数，DTO$为把p1转化为十六进制
        //例如：DTO$(65)，该函数的值为41（十六进制）；DTO$(49)，该函数的值为31（十六进制）
        public int DTOdollar(string strData)
        {
            if (strData.Length == 0)
            {
                Console.WriteLine("数据为空！");
                return -1;
            }

            //10进制转换成16进制
            int iResult = Convert.ToInt32(strData, 10);
            iResult = Convert.ToInt32(Convert.ToString(iResult, 16), 10);

            return iResult;
        }

        //把p1当成十六进制数，OTD$为把p1转化为十进制
        public int OTDdollar(string strData)
        {
            if (strData.Length == 0)
            {
                Console.WriteLine("数据为空！");
                return -1;
            }

            //16进制转换成10进制
            int iResult = Convert.ToInt32(strData, 16);

            return iResult;
        }

        //把p1，p2当成十进制，AND$表示把p1，p2按位相与后的值为函数的值
        //例如：AND$(3,1)的值为1，AND$(4,1)的值为0，AND$(4,3)的值为0
        public int ANDdollar(string strData1, string strData2)
        {
            if (strData1.Length == 0 || strData2.Length == 0)
            {
                Console.WriteLine("数据为空！");
                return -1;
            }

            //strData1 = Paser.PaserArithmetic(strData1);
            //strData2 = Paser.PaserArithmetic(strData2);

            int iData1 = Convert.ToInt32(strData1, 10);
            int iData2 = Convert.ToInt32(strData2, 10);

            return iData1 & iData2;
        }

        //把p1，p2当成十进制，OR$表示把p1，p2按位相或后的值为函数的值
        //例如：OR $(3,1)的值为3，OR $(4,1)的值为5，OR $(4,3)的值为7
        public int ORdollar(string strData1, string strData2)
        {
            if (strData1.Length == 0 || strData2.Length == 0)
            {
                Console.WriteLine("数据为空！");
                return -1;
            }

            int iData1 = Convert.ToInt32(strData1, 10);
            int iData2 = Convert.ToInt32(strData2, 10);

            return iData1 | iData2;
        }

        //把p1当成十进制，NOT$表示对p1按位求反，求反大小为一个字节
        //例如：NOT$(1)的值为254，NOT$(3)的值为252
        public int NOTdollar(string strData)
        {
            if (strData.Length == 0)
            {
                Console.WriteLine("数据为空！");
                return -1;
            }

            int iData = Convert.ToInt32(strData, 10);
            string strResult = Convert.ToString(~iData, 2);

            //截取低8位
            strResult = strResult.Substring(24, 8);

            //2进制转换为10进制
            int iResult = Convert.ToInt32(strResult, 2);
            return iResult;
        }

        //把p1，p2当成十进制，XOR$表示把p1，p2按位相与或非(Xor)后的值为函数的值
        //例如：XOR$ (3,1)的值为2，XOR$(4,1)的值为5
        public int XORdollar(string strData1, string strData2)
        {
            if (strData1.Length == 0 || strData2.Length == 0)
            {
                Console.WriteLine("数据为空！");
                return -1;
            }

            int iData1 = Convert.ToInt32(strData1, 10);
            int iData2 = Convert.ToInt32(strData2, 10);

            return iData1 ^ iData2;
        }

        //把p1等于p2时该函数的值为‘TRUE’，把p1不等于p2时该函数的值为‘FALSE’
        public string EQU(string strData1, string strData2)
        {
            if (strData1.Length == 0 || strData2.Length == 0)
            {
                Console.WriteLine("数据为空！");
                return "-1";
            }

            return (strData1 == strData2 ? "1" : "0");
        }

        //把p1 中找p2,找到时为1,否则为0
        public string FINDSTR(string strData1, string strData2)
        {
            if (strData1.Length == 0 || strData2.Length == 0)
            {
                Console.WriteLine("数据为空！");
                return "-1";
            }

            return strData1.IndexOf(strData2) != -1 ? "1" : "0";
        }

        //执行真假值判断，根据逻辑测试的真假值返回不同的结果。可以使用函数 IF 对数值和公式进行条件检测
        //例子：IF(LENGTH<=5,"1","0")表示如果接收数据的长度小于或等于5，返回值为字符“1”，否则返回值为“0”
        public string IF(string strData, string str1, string str2)
        {
            if (strData.Length == 0 || str1.Length == 0 || str2.Length == 0)
            {
                Console.WriteLine("数据为空！");
                return "-1";
            }

            if (strData == "1")
                return str1;
            if (strData == "0")
                return str2;

            int p1, p2, pos;

            if (strData.IndexOf(">=") != -1)
            {
                pos = strData.IndexOf(">=");

                p1 = Convert.ToInt32(Paser.PaserArithmetic(strData.Substring(0, pos)), 10);
                p2 = Convert.ToInt32(Paser.PaserArithmetic(strData.Substring(pos + 2)), 10);

                if (p1 >= p2)
                    return Paser.PaserArithmetic(str1);
                else return Paser.PaserArithmetic(str2);
            }
            else if (strData.IndexOf("<=") != -1)
            {
                pos = strData.IndexOf("<=");
                p1 = Convert.ToInt32(Paser.PaserArithmetic(strData.Substring(0, pos)), 10);
                p2 = Convert.ToInt32(Paser.PaserArithmetic(strData.Substring(pos + 2)), 10);

                if (p1 <= p2)
                    return Paser.PaserArithmetic(str1);
                else return Paser.PaserArithmetic(str2);
            }
            else if (strData.IndexOf("=") != -1)
            {
                pos = strData.IndexOf("=");
                p1 = Convert.ToInt32(Paser.PaserArithmetic(strData.Substring(0, pos)), 10);
                p2 = Convert.ToInt32(Paser.PaserArithmetic(strData.Substring(pos + 1)), 10);

                if (p1 == p2)
                    return Paser.PaserArithmetic(str1);
                else return Paser.PaserArithmetic(str2);
            }
            else if (strData.IndexOf(">") != -1)
            {
                pos = strData.IndexOf(">");
                p1 = Convert.ToInt32(Paser.PaserArithmetic(strData.Substring(0, pos)), 10);
                p2 = Convert.ToInt32(Paser.PaserArithmetic(strData.Substring(pos + 1)), 10);

                if (p1 > p2)
                    return Paser.PaserArithmetic(str1);
                else return Paser.PaserArithmetic(str2);
            }
            else if (strData.IndexOf("<") != -1)
            {
                pos = strData.IndexOf("<");
                p1 = Convert.ToInt32(Paser.PaserArithmetic(strData.Substring(0, pos)), 10);
                p2 = Convert.ToInt32(Paser.PaserArithmetic(strData.Substring(pos + 1)), 10);

                if (p1 < p2)
                    return Paser.PaserArithmetic(str1);
                else return Paser.PaserArithmetic(str2);
            }
            else return "-1";
        }

        //返回某个数字按指定位数舍入后的数字
        //ROUND(2.15, 1) 等于 2.2，ROUND(2.149, 1) 等于 2.1
        public string ROUND(string strData, int p)
        {
            if (strData.Length == 0)
            {
                Console.WriteLine("数据为空！");
                return "-1";
            }

            char[] PRMD = { '+', '-', '*', '/' };
            //如果要处理的字符串还有算术运算符+-*/，则先做算术运算
            if (strData.IndexOfAny(PRMD) != -1)
                strData = Paser.PaserArithmetic(strData);

            double fResult = Convert.ToDouble(strData);
            double k;
            if (fResult > 0)
                k = 0.5;
            else
                k = -0.5;

            fResult = (int)(fResult * (int)Math.Pow(10.0f, p) + k) / Math.Pow(10.0f, p);

            string strResult = fResult.ToString();

            return strResult;
        }

        //所有参数的逻辑值为真时返回 TRUE；只要一个参数的逻辑值为假即返回 FALSE
        //AND(TRUE, TRUE) 等于 TRUE，AND(TRUE, FALSE) 等于 FALSE
        public string AND(string[] strP, int paraNum)
        {
            for (int i = 0; i < paraNum; i++)
            {
                if (strP[i].Length == 0)
                {
                    Console.WriteLine("数据为空！");
                    return "-1";
                }
            }

            bool bResult = true;

            //用IF函数对每一个条件进行判断
            for (int i = 0; i < paraNum; i++)
            {
                bResult = bResult && Convert.ToBoolean(IF(strP[i], "1", "0"));
            }

            if (bResult)
                return "1";
            else return "0";
        }

        //在其参数组中，任何一个参数逻辑值为 TRUE，即返回 TRUE
        //OR(TRUE) 等于 TRUE， OR(1+1=1,2+2=5) 等于 FALSE
        public string OR(string[] strP, int paraNum)
        {
            for (int i = 0; i < paraNum; i++)
            {
                if (strP[i].Length == 0)
                {
                    Console.WriteLine("数据为空！");
                    return "-1";
                }
            }

            bool bResult = false;

            //用IF函数对每一个条件进行判断
            for (int i = 0; i < paraNum; i++)
            {
                bResult = bResult || Convert.ToBoolean(IF(strP[i], "1", "0"));
            }

            if (bResult)
                return "1";
            else return "0";
        }

        //求模, 结果为iP1 % iP2
        public int MOD(int iP1, int iP2)
        {
            return iP1 % iP2;
        }

        //求次方，结果为iP1的iP2次方
        public int EYE(int iP1, int iP2)
        {
            return (int)Math.Pow(iP1, iP2);
        }

        public float CHN(int iP1, int iP2, int iP3)
        {
            float fResult = -1.0f;
            new MonitorServers().GetChanncelValue(iP1, iP2, iP3, out fResult);
            return fResult;
        }

       

    }
}
