using System;

namespace MonitorSystem.Web.Servers
{
    class Paser
    {
        //解析整条式子
        public string Execute(string strData, string strAnalysis)
        {
            if (strAnalysis.Length == 0)
            {
                Console.WriteLine("解析式子为空！");
                return "-1";
            }
            string strTemp;

            strTemp = PaserFunction(strData, strAnalysis);

            if (strTemp == "ERROR")
            {
                return "ERROR";
            }
            strTemp = PaserArithmetic(strTemp);

            return strTemp;
        }

        //解析函数
        public string PaserFunction(string strData, string strAnalysis)
        {
            Analysis analysis = new Analysis();
            //去除所有空格
            strAnalysis = trim(strAnalysis);

            string strName, strPara;

            int iP1, iP2, iP3, iResult, posName, posPara;

            string strP1, strP2, strP3, strResult = "";

            string[] strP = new string[30];

            string strSymbol = "ABCDEFGHIJKLMNOPQRSTUVWXYZ$";
            char[] SYMBOL = strSymbol.ToCharArray();

            //若有函数
            while (strAnalysis.IndexOfAny(SYMBOL) != -1)
            {
                posName = strAnalysis.IndexOfAny(SYMBOL);

                //取得函数名称
                strName = strAnalysis.Substring(posName, strAnalysis.IndexOf("[", posName) - posName);

                //取得参数
                strPara = strAnalysis.Substring(strAnalysis.IndexOf("[", posName), strAnalysis.IndexOf("]", posName) - strAnalysis.IndexOf("[", posName) + 1);

                posPara = strAnalysis.IndexOf("[", posName);

                //清除函数参数
                strAnalysis = strAnalysis.Remove(posPara, strPara.Length);

                //若参数里面还有函数，则递归执行里面的函数，得到实际的参数
                strPara = PaserFunction(strData, strPara);

                if (strPara == "ERROR")
                {
                    return "ERROR";
                }
                //最终的函数的结果写回字符串数据
                strAnalysis = strAnalysis.Insert(posPara, strPara);

                //若不是完整的函数，则返回表达式
                if (strAnalysis.IndexOf(']') == -1)
                    return strAnalysis;

                strPara = strAnalysis.Substring(strAnalysis.IndexOf('[', posName), strAnalysis.IndexOf(']', posName) - strAnalysis.IndexOf('[', posName) + 1);

                //若找不到函数了，则是最终的参数
                if (strPara.IndexOfAny(SYMBOL) != -1)
                    continue;

                //清除函数名称
                strAnalysis = strAnalysis.Remove(posName, strName.Length);

                //清除函数参数
                strAnalysis = strAnalysis.Remove(posName, strPara.Length);

                //如果函数是LENGTH
                if (strName == "LENGTH")
                {
                    //执行函数得到结果
                    iResult = analysis.LENGTH(strData);

                    strResult = iResult.ToString();

                    //sLog.Format("数据%s,LENGTH函数计算LENGTH[%s],结果为:%s",strData,strData,strResult);
                    //PrintDetail(sLog);
                }

                //如果函数是ACHAR
                if (strName == "ACHAR")
                {
                    //取得参数
                    iP1 = Convert.ToInt32(strPara.Substring(1, strPara.IndexOf(',') - 1), 10);
                    iP2 = Convert.ToInt32(strPara.Substring(strPara.IndexOf(',') + 1, strPara.IndexOf(']') - strPara.IndexOf(',') - 1), 10);

                    //执行函数得到结果
                    strResult = analysis.ACHAR(strData, iP1, iP2);

                    //sLog.Format("数据%s,ACHAR函数计算ACHAR[%d,%d],结果为:%s",strData,iP1,iP2,strResult);
                    //PrintDetail(sLog);

                    if (strResult == "-1")
                    {
                        return "ERROR";
                    }
                }

                //如果函数是ROUND
                if (strName == "ROUND")
                {
                    //取得参数
                    strP1 = strPara.Substring(1, strPara.IndexOf(',') - 1);
                    iP2 = Convert.ToInt32(strPara.Substring(strPara.IndexOf(',') + 1, strPara.IndexOf(']') - strPara.IndexOf(',') - 1), 10);

                    //执行函数得到结果
                    strResult = analysis.ROUND(strP1, iP2);

                    //sLog.Format("数据%s,ROUND函数计算ROUND[%s,%d],结果为:%s",strData,strP1,iP2,strResult);
                    //PrintDetail(sLog);

                    if (strResult == "-1")
                    {
                        return "ERROR";
                    }
                }

                //如果函数是AND$
                if (strName == "AND$")
                {
                    //取得参数
                    strP1 = strPara.Substring(1, strPara.IndexOf(',') - 1);
                    strP2 = strPara.Substring(strPara.IndexOf(',') + 1, strPara.IndexOf(']') - strPara.IndexOf(',') - 1);

                    //执行AND$函数得到结果
                    iResult = analysis.ANDdollar(strP1, strP2);

                    //sLog.Format("数据%s,AND$函数计算AND$[%s,%s],结果为:%d",strData,strP1,strP2,iResult);
                    //PrintDetail(sLog);

                    if (iResult == -1)
                        return "ERROR";
                    strResult = iResult.ToString();
                }

                //如果函数是A$
                if (strName == "A$")
                {
                    //取得参数
                    iP1 = Convert.ToInt32(strPara.Substring(1, strPara.IndexOf(',') - 1), 10);
                    iP2 = Convert.ToInt32(strPara.Substring(strPara.IndexOf(',') + 1, strPara.IndexOf(']') - strPara.IndexOf(',') - 1), 10);

                    //执行A$函数得到结果
                    iResult = analysis.Adollar(strData, iP1, iP2);

                    if (iResult == -1)
                    {
                        //sLog.Format("数据%s,A$函数计算A$[%d,%d],结果错误,为-1",strData,iP1,iP2);
                        return "ERROR";
                    }
                    strResult = iResult.ToString();

                    //sLog.Format("数据%s,A$函数计算A$[%d,%d],结果为:%s",strData,iP1,iP2,strResult);
                    //PrintDetail(sLog);
                }

                //如果函数是AB$
                if (strName == "AB$")
                {
                    //取得参数
                    iP1 = Convert.ToInt32(strPara.Substring(1, strPara.IndexOf(',') - 1), 10);
                    iP2 = Convert.ToInt32(strPara.Substring(strPara.IndexOf(',') + 1, strPara.IndexOf(']') - strPara.IndexOf(',') - 1), 10);

                    //执行A$函数得到结果
                    iResult = analysis.ABdollar(strData, iP1, iP2);

                    //sLog.Format("数据%s,AB$函数计算AB$[%d,%d],结果为:%d",strData,iP1,iP2,iResult);
                    //PrintDetail(sLog);

                    if (iResult == -1)
                        return "ERROR";
                    strResult = iResult.ToString();
                }

                //如果函数是ABC$
                if (strName == "ABC$")
                {
                    //取得参数
                    iP1 = Convert.ToInt32(strPara.Substring(1, strPara.IndexOf(',') - 1), 10);
                    iP2 = Convert.ToInt32(strPara.Substring(strPara.IndexOf(',') + 1, strPara.IndexOf(',', strPara.IndexOf(',') + 1) - strPara.IndexOf(',') - 1), 10);
                    iP3 = Convert.ToInt32((strPara.Substring(strPara.LastIndexOf(',') + 1, strPara.LastIndexOf(']') - strPara.LastIndexOf(',') - 1)), 10);

                    //执行A$函数得到结果
                    iResult = analysis.ABCdollar(strData, iP1, iP2, iP3);

                    //sLog.Format("数据%s,ABC$函数计算ABC$[%d,%d,%d],结果为:%d",strData,iP1,iP2,iP3,iResult);
                    //PrintDetail(sLog);

                    if (iResult == -1)
                        return "ERROR";
                    strResult = iResult.ToString();
                }

                //如果函数是DTOC$D
                if (strName == "DTOC$D")
                {
                    //取得参数
                    strP1 = strPara.Substring(1, strPara.IndexOf(']') - 1);

                    //执行函数得到结果
                    iResult = analysis.DTOCdollarD(strP1);

                    //sLog.Format("数据%s,DTOC$D函数计算DTOC$D[%s],结果为:%d",strData,strP1,iResult);
                    //PrintDetail(sLog);

                    if (iResult == -1)
                        return "ERROR";
                    strResult = iResult.ToString();
                }

                //如果函数是IF
                if (strName == "IF")
                {
                    //取得参数
                    strP1 = strPara.Substring(1, strPara.IndexOf(',') - 1);
                    strP2 = strPara.Substring(strPara.IndexOf(',') + 1, strPara.IndexOf(',', strPara.IndexOf(',') + 1) - strPara.IndexOf(',') - 1);
                    strP3 = strPara.Substring(strPara.LastIndexOf(',') + 1, strPara.LastIndexOf(']') - strPara.LastIndexOf(',') - 1);

                    //执行函数得到结果
                    strResult = analysis.IF(strP1, strP2, strP3);

                    //sLog.Format("数据%s,IF函数计算IF[%s,%s,%s],结果为:%s",strData,strP1,strP2,strP3,strResult);
                    //PrintDetail(sLog);

                    if (strResult == "-1")
                    {
                        return "ERROR";
                    }
                }

                //如果函数是OTD$
                if (strName == "OTD$")
                {
                    //取得参数
                    strP1 = strPara.Substring(1, strPara.IndexOf(']') - 1);

                    //执行函数得到结果
                    iResult = analysis.OTDdollar(strP1);

                    //sLog.Format("数据%s,OTD$函数计算OTD$[%s],结果为:%d",strData,strP1,iResult);
                    //PrintDetail(sLog);

                    if (iResult == -1)
                        return "ERROR";
                    strResult = iResult.ToString();
                }

                //如果函数是AND
                if (strName == "AND")
                {
                    int cur_pos = 0, paraNum = 0;

                    strPara.Remove(strPara.Length - 1, 1);

                    //取得参数
                    for (int i = 0; ; i++)
                    {
                        strP[i] = strPara.Substring(cur_pos + 1, strPara.IndexOf(',', cur_pos + 1) - cur_pos - 1);
                        paraNum++;

                        if ((cur_pos = strPara.IndexOf(',', cur_pos + 1)) == -1)
                            break;
                    }

                    //执行函数得到结果
                    strResult = analysis.AND(strP, paraNum);

                    //sLog.Format("数据%s,AND函数计算,结果为:%s",strData,strResult);
                    //PrintDetail(sLog);

                    if (strResult == "-1")
                    {
                        return "ERROR";
                    }
                }

                //如果函数是OR
                if (strName == "OR")
                {
                    int cur_pos = 0, paraNum = 0;

                    strPara.Remove(strPara.Length - 1, 1);

                    //取得参数
                    for (int i = 0; ; i++)
                    {
                        strP[i] = strPara.Substring(cur_pos + 1, strPara.IndexOf(',', cur_pos + 1) - cur_pos - 1);
                        paraNum++;

                        if ((cur_pos = strPara.IndexOf(',', cur_pos + 1)) == -1)
                            break;
                    }

                    //执行函数得到结果
                    strResult = analysis.OR(strP, paraNum);

                    //sLog.Format("数据%s,OR函数计算,结果为:%s",strData,strResult);
                    //PrintDetail(sLog);

                    if (strResult == "-1")
                    {
                        return "ERROR";
                    }
                }

                //如果函数是MOD
                if (strName == "MOD")
                {
                    //取得参数
                    strP1 = strPara.Substring(1, strPara.IndexOf(',') - 1);
                    strP2 = strPara.Substring(strPara.IndexOf(',') + 1, strPara.IndexOf(']') - strPara.IndexOf(',') - 1);

                    iP1 = Convert.ToInt32(PaserArithmetic(strP1), 10);
                    iP2 = Convert.ToInt32(PaserArithmetic(strP2), 10);

                    //执行A$函数得到结果
                    iResult = analysis.MOD(iP1, iP2);

                    //sLog.Format("数据%s,MOD函数计算MOD[%d,%d],结果为:%d",strData,iP1,iP2,iResult);
                    //PrintDetail(sLog);

                    if (iResult == -1)
                        return "ERROR";
                    strResult = iResult.ToString();
                }

                //如果函数是EYE
                if (strName == "EYE")
                {
                    //取得参数
                    strP1 = strPara.Substring(1, strPara.IndexOf(',') - 1);
                    strP2 = strPara.Substring(strPara.IndexOf(',') + 1, strPara.IndexOf(']') - strPara.IndexOf(',') - 1);

                    iP1 = Convert.ToInt32(PaserArithmetic(strP1), 10);
                    iP2 = Convert.ToInt32(PaserArithmetic(strP2), 10);

                    //执行EYE函数得到结果
                    iResult = analysis.EYE(iP1, iP2);

                    //sLog.Format("数据%s,EYE函数计算EYE[%d,%d],结果为:%d",strData,iP1,iP2,iResult);
                    //PrintDetail(sLog);

                    if (iResult == -1)
                        return "ERROR";
                    strResult = iResult.ToString();
                }

                //如果函数是CHN
                if (strName == "CHN")
                {
                    //取得参数
                    iP1 = Convert.ToInt32(strPara.Substring(1, strPara.IndexOf(',') - 1), 10);
                    iP2 = Convert.ToInt32(strPara.Substring(strPara.IndexOf(',') + 1, strPara.IndexOf(',', strPara.IndexOf(',') + 1) - strPara.IndexOf(',') - 1), 10);
                    iP3 = Convert.ToInt32((strPara.Substring(strPara.LastIndexOf(',') + 1, strPara.LastIndexOf(']') - strPara.LastIndexOf(',') - 1)), 10);

                    //执行A$函数得到结果
                    float fResult = analysis.CHN(iP1, iP2, iP3);
                    int itmp = (int)fResult;

                    //sLog.Format("数据%s,ABC$函数计算ABC$[%d,%d,%d],结果为:%d",strData,iP1,iP2,iP3,iResult);
                    //PrintDetail(sLog);


                    if (itmp == -1)
                        return "ERROR";
                    strResult = fResult.ToString();
                }

                //把函数的结果写回字符串数据
                strAnalysis = strAnalysis.Insert(posName, strResult);

                //如果还有其他函数，可以继续扩展...
            }
            return strAnalysis;
        }

        //删除空格或者tab字符
        static string trim(string str)
        {
            char[] delim = { ' ', '\t' };

            int pos = 0;
            pos = str.IndexOfAny(delim, pos);

            if (pos == -1)
                return str;
            return trim(str.Remove(pos, 1));
        }

        //解析算术
        public static string PaserArithmetic(string strAnalysis)
        {
            string strData = strAnalysis;

            //去除所有空格
            strAnalysis = trim(strAnalysis);

            int iBegin, iEnd;
            int pos;
            string strTemp = strAnalysis, strNew = strAnalysis;

            //如果有括号，则先找到配对括号，然后计算其值，若括号内仍有括号，则进行递归
            while (strAnalysis.LastIndexOf('(') != -1)
            {
                iBegin = iEnd = 0;

                //找到括号里面的内容
                pos = strAnalysis.LastIndexOf('(');
                strTemp = strAnalysis.Substring(pos);

                iEnd = strTemp.IndexOf(')');
                strTemp = strTemp.Substring(1, iEnd - 1);

                //清除括号内的内容
                strAnalysis = strAnalysis.Remove(pos, iEnd + 1);

                //计算括号里面的数值，并写回源字符串数据
                strAnalysis = strAnalysis.Insert(pos, PaserArithmetic(strTemp));
            }

            char[] PRMD = { '+', '-', '*', '/' };
            char[] PR = { '+', '-' };
            char[] MD = { '*', '/' };
            for (int i = 0; i < strAnalysis.Length; i++)
            {
                if ('0' <= strAnalysis[i] && strAnalysis[i] <= '9' || strAnalysis[i] == '.' || strAnalysis[i] == '-')
                {
                    double p1, p2, fResult;

                    //做乘法和除法
                    while (strAnalysis.IndexOfAny(MD) != -1)
                    {
                        pos = strAnalysis.IndexOfAny(MD);
                        strTemp = strAnalysis.Substring(0, pos);

                        //找到参与运算的第一个数
                        if (strTemp.LastIndexOfAny(PRMD) != -1)
                        {
                            iBegin = strTemp.LastIndexOfAny(PRMD) + 1;
                            p1 = Convert.ToDouble(strTemp.Substring(iBegin));
                        }
                        else
                        {
                            iBegin = 0;
                            p1 = Convert.ToDouble(strTemp);
                        }

                        //找到参与运算的第二个数
                        if (strAnalysis.IndexOfAny(PRMD, pos + 1) != -1)
                        {
                            iEnd = strAnalysis.IndexOfAny(PRMD, pos + 1);
                            p2 = Convert.ToDouble(strAnalysis.Substring(pos + 1, iEnd - pos - 1));
                        }
                        else
                        {
                            iEnd = strAnalysis.Length;
                            p2 = Convert.ToDouble(strAnalysis.Substring(pos + 1));
                        }

                        switch (strAnalysis[pos])
                        {
                            case '*':
                                fResult = p1 * p2;
                                break;

                            case '/':
                                fResult = p1 / p2;
                                break;

                            default:
                                Console.WriteLine("不支持该运算符!");
                                return "";
                        }

                        strTemp = fResult.ToString();

                        strAnalysis = strAnalysis.Remove(iBegin, iEnd - iBegin);

                        strAnalysis = strAnalysis.Insert(iBegin, strTemp);
                    }

                    //若还存在加减运算符
                    if (strAnalysis.IndexOfAny(PR) != -1)
                    {
                        //判断是不是结果是负数
                        if (strAnalysis.IndexOf("-") == 0 && strAnalysis.IndexOfAny(PRMD, 1) == -1)
                        {
                            //sLog.Format("计算表达式:%s,结果为:%s",strData,strAnalysis);
                            //PrintDetail(sLog);

                            return strAnalysis;
                        }
                        else if (strAnalysis.IndexOf("-") == 0)
                            pos = strAnalysis.IndexOfAny(PR, 1);
                        else pos = strAnalysis.IndexOfAny(PR);
                    }
                    //已经完成了运算，得到最终的数值
                    else
                    {
                        //sLog.Format("计算表达式:%s,结果为:%s",strData,strAnalysis);
                        //PrintDetail(sLog);

                        return strAnalysis;
                    }

                    p1 = Convert.ToDouble(strAnalysis.Substring(0, pos));

                    if (strAnalysis.Substring(pos + 1).IndexOfAny(PR) != -1)
                    {
                        iEnd = strAnalysis.IndexOfAny(PR, pos + 1);
                        p2 = Convert.ToDouble(strAnalysis.Substring(pos + 1, iEnd - pos - 1));
                    }
                    else
                    {
                        iEnd = strAnalysis.Length;
                        p2 = Convert.ToDouble(strAnalysis.Substring(pos + 1));
                    }

                    switch (strAnalysis[pos])
                    {
                        case '+':
                            fResult = p1 + p2;
                            break;

                        case '-':
                            fResult = p1 - p2;
                            break;

                        default:
                            Console.WriteLine("不支持该运算符!");
                            return "";
                    }

                    strTemp = fResult.ToString();

                    strAnalysis = strAnalysis.Remove(0, iEnd);

                    strAnalysis = strAnalysis.Insert(0, strTemp);

                }
                else
                {
                    Console.WriteLine("非法运算式！");
                    return "";
                }
            }

            //	sLog.Format("计算表达式:%s,结果为:%s",strData,strAnalysis);
            //PrintDetail(sLog);

            return strAnalysis;
        }
    }
}
