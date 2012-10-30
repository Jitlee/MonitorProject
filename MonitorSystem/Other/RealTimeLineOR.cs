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
using System.Collections.Generic;
using MonitorSystem.Web.Moldes;
using System.Windows.Threading;

namespace MonitorSystem.Other
{

    #region 定义鼠标X，Y 坐标值，及该点坐标记录值、记录时间
    /// <summary>
    /// 定义鼠标X，Y 坐标值，及该点坐标记录值、记录时间
    /// </summary>
    struct CoordinatesValue
    {
        /// <summary>
        /// 缩放比例
        /// </summary>
        public double SFPer;
        public double X;
        public double Y;
        public double Value;
        public System.DateTime time;
    }
    #endregion

    public class RealTimeLineOR
    {
        t_Element_RealTimeLine _LineInfo;
        /// <summary>
        /// 线参数信息
        /// </summary>
        public t_Element_RealTimeLine LineInfo
        {
            get { return _LineInfo; }
            set { _LineInfo = value; }
        }
        DispatcherTimer timer = new DispatcherTimer();

        public RealTimeLineOR(t_Element_RealTimeLine mLine)
        {
            _LineInfo = mLine;

            _PolyLine.Stroke = new SolidColorBrush(Common.StringToColor(_LineInfo.LineColor));
            _PolyLine.StrokeThickness = 2;
            _PolyLine.Points = pc;
            _PolyLine.SetValue(Canvas.ZIndexProperty, 999);
            _PolyLine.Name = _LineInfo.ID;

            //曲线点
            noteMessages = new CoordinatesValue[maxNote];

            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += (sender, obj) =>
            {
                Random rd = new Random();
                //获取值，刷新
               
                    //AddNewValue(Convert.ToDouble(rd.NextDouble() * int.Parse(LineInfo.MaxValue)));
                    //ShowCurve();
            };
            timer.Start();
        }

       
        double _YValue = 0.0;
        /// <summary>
        /// 当前Y轴值
        /// </summary>
        public double YValue
        {
            get { return _YValue; }
            set { _YValue = value; }
        }

        
        RealLineShow _TitleShowInfo;
        /// <summary>
        /// 实时曲线基本信息显示
        /// </summary>
        public RealLineShow TitleShowInfo
        {
            get { return _TitleShowInfo; }
            set { _TitleShowInfo = value; }
        }

        #region 变量 -X轴信息|函数-设置Text值

        List<TextBlock> _TextList = new List<TextBlock>();
        /// <summary>
        /// X轴文本框显示信息
        /// </summary>
        public List<TextBlock> TextList
        {
            get { return _TextList; }
            set { _TextList = value; }
        }

        //开始时间
        private DateTime _StartTime = DateTime.Now;
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime
        {
            get { return _StartTime; }
            set { _StartTime = value; }
        }

        public void SetTimeLen(int value)
        {
            _LineInfo.TimeLen = value;
            SetPointReMovePx();
        }
        
      
        /// <summary>
        /// 面版可显示点数量,根据取值宽围/采样频率
        /// </summary>
        private int _PicShowPointNumber = 50;
        /// <summary>
        /// 定义曲线移动距离
        /// </summary>
        private double curveRemove = 5;
        /// <summary>
        /// 设置可显示点数，移动宽度
        /// </summary>
        public void SetPointReMovePx()
        {
            int len = GetTimeShowELen();
            _PicShowPointNumber = len / GetCYTimeLen();//取值宽围/采样频率
            curveRemove = _PicCurveWidth / _PicShowPointNumber;
        }

        private int GetCYTimeLen()
        {
            int len = 5;
            int CYZQLent= int.Parse(_LineInfo.LineCYZQLent);
            if (_LineInfo.LineCYZQType == "ss")
            {
                len = CYZQLent;
            }
            else if (_LineInfo.LineCYZQType == "mm")
            {
                len = CYZQLent * 60;
            }
            else if (_LineInfo.LineCYZQLent == "hh")
            {
                len = CYZQLent * 60 * 60;
            }
            return len;
        }

        /// <summary>
        /// 时间显示长度
        /// </summary>
        /// <returns></returns>
        private int  GetTimeShowELen()
        {
            int len = 5;
            if (_LineInfo.TimeLenType == "ss")
            {
                len = _LineInfo.TimeLen;
            }
            else if (_LineInfo.TimeLenType == "mm")
            {
                len = _LineInfo.TimeLen * 60;
            }
            else if (_LineInfo.TimeLenType == "hh")
            {
                len = _LineInfo.TimeLen * 60 * 60;
            }
            return len;
        }

        /// <summary>
        /// 设置X轴TextBox
        /// </summary>
        public void SetXZTextBoxValue()
        {

           _StartTime= DateTime.Now;
           if (_TextList == null)
               return;
           if (_TextList.Count == 0)
               return;

           int len = GetTimeShowELen();

           int timeLenPer = len / (_TextList.Count - 1);
           int txtCount = _TextList.Count;
           for (int i = 0; i < _TextList.Count; i++)
           {
               
               DateTime dt = _StartTime.AddSeconds(-(timeLenPer * (txtCount-i-1)));
               _TextList[i].Text = dt.ToString(_LineInfo.ShowFormat);
           }
           // _StartTime.AddSeconds

        }

        #endregion
        /// <summary>
        /// 鼠标X，Y 坐标值，及该点坐标记录值、记录时间（数组）
        /// </summary>
        private CoordinatesValue[] noteMessages;
        /// <summary>
        /// 当前鼠标 X，Y坐标记录数组下标值
        /// </summary>
        private int noteNow = 0;
        /// <summary>
        /// 曲线节点数据最大存储量
        /// </summary>
        private int maxNote = 1000;
        

        //显示面版，宽
        private double _PicCurveWidth = 200;
        /// <summary>
        /// 显示Canvers宽度
        /// </summary>
        public double PicCurveWidth
        {
            get { return _PicCurveWidth; }
            set { _PicCurveWidth = value;
                SetPointReMovePx();
            }
        }

        private double _picCurveShowHeight = 0;
        /// <summary>
        /// 显示Canvers高度
        /// </summary>
        public double PicCurveShowHeight
        {
            get { return _picCurveShowHeight; }
            set { _picCurveShowHeight = value; }
        }

        private double _YZSFPer=1;
        /// <summary>
        /// Y轴缩放比例
        /// </summary>
        public double YZSFPer
        {
            get { return _YZSFPer; }
            set { _YZSFPer = value; }
        }
        
        private double _MaxValue = 0;
        /// <summary>
        /// 显示值 最大值
        /// </summary>
        public double MaxValue
        {
            get { return _MaxValue; }
            set { _MaxValue = value; }
        }

        private double _MinValue = 0;
        /// <summary>
        /// 显示值 最小值
        /// </summary>
        public double MinValue
        {
            get { return _MinValue; }
            set { _MinValue = value; }
        }
        
        #region 自动将最新采样数值添加到数组、显示
        /// <summary>
        /// 自动将最新采样数值添加到数组
        /// </summary>
        /// <param name="newValue">最新采样数值</param>
        public void AddNewValue(double newValue)
        {
            newValue = Math.Round(newValue, LineInfo.ValueDecimal); 
            //处理最大值，及最小值
            if (newValue > _MaxValue)
                _MaxValue = newValue;

            if (newValue < _MinValue)
                _MinValue = newValue;
            //先判断数组下标
            // newValue = newValue + noteNow;
            if (this.noteNow >= this.maxNote - 1)
            {
                //数组已经存满数值
                for (int i = 0; i < this.noteNow; i++)
                {
                    this.noteMessages[i] = this.noteMessages[i + 1];
                    this.noteMessages[i].X = this.noteMessages[i].X - curveRemove;
                }
                this.noteMessages[this.noteNow].SFPer = _YZSFPer;
                this.noteMessages[this.noteNow].Value = newValue;
                this.noteMessages[this.noteNow].time = System.DateTime.Now;
                this.noteMessages[this.noteNow].X = (int)_PicCurveWidth;
                this.noteMessages[this.noteNow].Y = GetYValue(newValue);
            }
            else
            {
                //数组未存满数值
                for (int i = 0; i < this.noteNow; i++)
                {
                    this.noteMessages[i].X = this.noteMessages[i].X - curveRemove;
                }
                this.noteMessages[this.noteNow].SFPer = _YZSFPer;
                this.noteMessages[this.noteNow].Value = newValue;
                this.noteMessages[this.noteNow].time = System.DateTime.Now;
                this.noteMessages[this.noteNow].X = (int)_PicCurveWidth;

                this.noteMessages[this.noteNow].Y = GetYValue(newValue);

                this.noteNow++;
            }
            if (_TitleShowInfo != null)
                _TitleShowInfo.SetDataValue(newValue);
        }

        /// <summary>
        /// 处理X坐标，处理X轴改变的情况
        /// </summary>
        public void ChangeXValue()
        {
             this.noteMessages[this.noteNow].X= _PicCurveWidth ;
            for (int i = 0; i <= this.noteNow; i++)
            {
                this.noteMessages[this.noteNow - i].X = _PicCurveWidth - (curveRemove*i);
            }
        }
        #endregion
        public double GetHalf()
        {
            double half = 0;
            if (_YZSFPer != 1)
                half = ((int.Parse(_LineInfo.MaxValue) - int.Parse(_LineInfo.MinValue)) * (_YZSFPer - 1)) / 2;
            return half;
        }
        #region 缩放处理
        private int GetYValue(double newValue)
        {
            double half = 0;
            if (_YZSFPer != 1)
                half = ((int.Parse(_LineInfo.MaxValue) -int.Parse(_LineInfo.MinValue)) * (_YZSFPer - 1)) / 2;
            double max = int.Parse(_LineInfo.MaxValue) + half;
            double min = int.Parse(_LineInfo.MinValue) - half;

            double per = (newValue - min) / (max - min);
            double y = _picCurveShowHeight * (1 - per);
            return (int)y;
        }

        /// <summary>
        /// 处理缩放数组中的数据
        /// </summary>
        public void HeadSFArr()
        {
            for (int i = 0; i <= this.noteNow - 1; i++)
            {
                //CoordinatesValue obj = noteMessages[i];
                if (noteMessages[i].SFPer != _YZSFPer)
                {
                    noteMessages[i].SFPer = _YZSFPer;
                    noteMessages[i].Y = GetYValue(noteMessages[i].Value);
                }
            }
        }
        #endregion

        #region 曲线
        Polyline _PolyLine = new Polyline();
        /// <summary>
        /// 画曲线
        /// </summary>
        public Polyline PolyLine
        {
            get { return _PolyLine; }
            set { _PolyLine = value; }
        }

        PointCollection pc = new PointCollection();
        /// <summary>
        /// 刷新背景网格线，显示曲线
        /// </summary>
        public void ShowCurve()
        {
            if (this.noteNow > 1)
            {
                pc.Clear();
                for (int i = 0; i <= this.noteNow - 1; i++)
                {
                    Point p = new Point(this.noteMessages[i].X, this.noteMessages[i].Y);
                    pc.Add(p);
                }
            }
            SetXZTextBoxValue();
        }
        #endregion
    }
}
