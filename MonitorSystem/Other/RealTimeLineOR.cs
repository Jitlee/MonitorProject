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
        public RealTimeLineOR()
        {
            _PolyLine.Stroke = new SolidColorBrush(_LineColor);
            _PolyLine.StrokeThickness = 2;
            _PolyLine.Points = pc;
            _PolyLine.SetValue(Canvas.ZIndexProperty, 999);
            _PolyLine.Name = _LineGuid;

            //曲线点
            noteMessages = new CoordinatesValue[maxNote];
        }

        /// <summary>
        /// 实使化参数
        /// </summary>
        public void InitPara()
        {

        }

        private string _LineName;
        /// <summary>
        /// 线名称
        /// </summary>
        public string LineName
        {
            get { return _LineName; }
            set { _LineName = value; }
        }

        private string _LineGuid = Guid.NewGuid().ToString();
        /// <summary>
        /// 线ID
        /// </summary>
        public string LineGuid
        {
            get { return _LineGuid; }
            set { _LineGuid = value; }
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


        private Color _LineColor= Colors.Blue;
        /// <summary>
        /// 实时曲线颜色
        /// </summary>
        public Color LineColor
        {
            get { return _LineColor; }
            set {
                _LineColor = value;
                _PolyLine.Stroke = new SolidColorBrush(_LineColor);
            }
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

        int _TimeLen =8;
        /// <summary>
        /// 时间长度|取值范围 
        /// </summary>
        public int TimeLen
        {
            get { return _TimeLen; }
            set { _TimeLen = value;
            SetPointReMovePx();
            }
        }
        
        private string _TimeLenType="s";
        /// <summary>
        /// 时间长度类型
        /// </summary>
        public string TimeLenType
        {
            get { return _TimeLenType; }
            set { _TimeLenType = value; }
        }


        int _CYZQ = 1;
        /// <summary>
        /// 采样周期
        /// </summary>
        public int CYZQ
        {
            get { return _CYZQ; }
            set { _CYZQ = value;
                SetPointReMovePx();
            }
        }

        string _CYZQType = "ss";//秒
        /// <summary>
        /// 采样周期类型
        /// </summary>
        public string CYZQType
        {
            get { return _CYZQType; }
            set { _CYZQType = value; }
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
            int len = GetTimeUSELen();
            _PicShowPointNumber = len / _CYZQ;//取值宽围/采样频率
            curveRemove = _PicCurveWidth / _PicShowPointNumber;
        }

        private int  GetTimeUSELen()
        {
            int len = 5;
            if (_TimeLenType == "ss")
            {
                len = _TimeLen;
            }
            else if (_TimeLenType == "mm")
            {
                len = _TimeLen * 60;
            }
            else if (TimeLenType == "hh")
            {
                len = _TimeLen * 60 * 60;
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

           int len = GetTimeUSELen();

           int timeLenPer = len / (_TextList.Count - 1);
           int txtCount = _TextList.Count;
           for (int i = 0; i < _TextList.Count; i++)
           {
               DateTime dt = _StartTime.AddSeconds(-(timeLenPer * (txtCount-i-1)));
               _TextList[i].Text = dt.ToString("dd HH:mm:ss");
           }
           // _StartTime.AddSeconds

        }

        #endregion

        /// <summary>
        /// 最小值
        /// </summary>
        private double _YminValue = 0;
        /// <summary>
        /// 最小值
        /// </summary>
        public double YminValue
        {
            get { return _YminValue; }
            set { _YminValue = value; }
        }
        /// <summary>
        /// 最大值
        /// </summary>
        private double _YmaxValue = 100;
        /// <summary>
        /// 最小值
        /// </summary>
        public double YmaxValue
        {
            get { return _YmaxValue; }
            set { _YmaxValue = value; }
        }

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
        /// 最大值
        /// </summary>
        public double MaxValue
        {
            get { return _MaxValue; }
            set { _MaxValue = value; }
        }

        private double _MinValue = 0;
        /// <summary>
        /// 最小值
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

        #region 缩放处理
        private int GetYValue(double newValue)
        {
            double half = 0;
            if (_YZSFPer != 1)
                half = ((_YmaxValue - _YminValue) * (_YZSFPer - 1)) / 2;
            double max = this._YmaxValue + half;
            double min = this._YminValue - half;

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
