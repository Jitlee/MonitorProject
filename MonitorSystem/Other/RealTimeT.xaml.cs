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
using MonitorSystem.MonitorSystemGlobal;
using MonitorSystem.Web.Moldes;
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Threading;
using System.Linq;


namespace MonitorSystem.Other
{
    public partial class RealTimeT : MonitorControl
    {
        /// <summary>
        /// 曲线列表
        /// </summary>
        double LineListWidth = 80;

        // Canvas _Canvas = new Canvas();
        /// <summary>
        /// 背景框
        /// </summary>
        Canvas _CanvasGrid = new Canvas();//用于装背景
        Canvas _CanvasLine = new Canvas();//用于装线
        //Canvas _CanvasZ = new Canvas();//用于存放XZ和YZ

        List<RealTimeLineOR> listRealTimeLine = new List<RealTimeLineOR>();
        public RealTimeT()
        {
            InitializeComponent();
            
            this.Width = 400;
            this.Height = 400;
            _CanvasGrid.SetValue(Canvas.ZIndexProperty, 2);
            _CanvasLine.SetValue(Canvas.ZIndexProperty, 10);
            _Canvas.Children.Add(_CanvasGrid);
            _Canvas.Children.Add(_CanvasLine);
            _Canvas.SizeChanged += new SizeChangedEventHandler(Canvas_SizeChanged);
            this.SizeChanged += new SizeChangedEventHandler(RealTime_SizeChanged);
            PaintBasicInfo();
        }
        private void RealTime_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (!(e.NewSize.Width > 0 && e.NewSize.Height > 0))
                return;

            this.Width = e.NewSize.Width;
            this.Height = e.NewSize.Height;
        }

        private void Canvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (!(e.NewSize.Width > 0 && e.NewSize.Height > 0))
                return;
            _Canvas.Width = e.NewSize.Width;
            _Canvas.Height = e.NewSize.Height;

            _CanvasZ.Width = e.NewSize.Width;
            _CanvasZ.Height = e.NewSize.Height;

            PaintBasicInfo();
        }

        #region 公共
        #region 函数
        public override event EventHandler Selected;
        public override void UnDesignMode()
        {
            if (IsDesignMode)
            {
                AdornerLayer.Selected -= OnSelected;
                AdornerLayer.ClearValue(ContextMenuService.ContextMenuProperty);
                AdornerLayer.Dispose();
                AdornerLayer = null;
            }
        }

        public override void DesignMode()
        {
            if (!IsDesignMode)
            {
                AdornerLayer = new Adorner(this);
                AdornerLayer.Selected += OnSelected;
            }
        }

        private void OnSelected(object sender, EventArgs e)
        {
            if (null != Selected)
            {
                Selected(this, RoutedEventArgs.Empty);
            }
        }


        public override object GetRootControl()
        {
            return this;
        }

        public override void SetChannelValue(float fValue, float dValue)
        {

        }
        #endregion

        #region 属性
        public override void SetPropertyValue()
        {
            foreach (t_ElementProperty pro in ListElementProp)
            {
                string name = pro.PropertyName.ToUpper();
                string value = pro.PropertyValue;

                if (name == "LeftOrNot".ToUpper())
                {

                }
            }
        }

        public override void SetCommonPropertyValue()
        {
            this.SetValue(Canvas.LeftProperty, (double)ScreenElement.ScreenX);
            this.SetValue(Canvas.TopProperty, (double)ScreenElement.ScreenY);
            this.Width = (double)ScreenElement.Width;
            this.Height = (double)ScreenElement.Height;
            Transparent = ScreenElement.Transparent.Value;

            BackColor = Common.StringToColor(ScreenElement.BackColor);
            ForeColor = Common.StringToColor(ScreenElement.ForeColor);
        }



        private string[] m_BrowsableProperties = new string[] { "Left", "Top", "Width", "Height", "FontFamily", "FontSize",
           "BackColor", "ForeColor", "Transparent","Translate"};
        public override string[] BrowsableProperties
        {
            get { return m_BrowsableProperties; }
            set { m_BrowsableProperties = value; }
        }


        private static readonly DependencyProperty BackColorProperty =
           DependencyProperty.Register("BackColor",
           typeof(Color), typeof(RealTimeT), new PropertyMetadata(Colors.White));
        [DefaultValue(""), Description("背景色"), Category("外观")]
        public Color BackColor
        {
            get { return (Color)this.GetValue(BackColorProperty); }
            set
            {
                this.SetValue(BackColorProperty, value);
                if (ScreenElement != null)
                    ScreenElement.BackColor = value.ToString();
            }
        }

        private static readonly DependencyProperty ForeColorProperty =
            DependencyProperty.Register("ForeColor",
            typeof(Color), typeof(RealTimeT), new PropertyMetadata(Colors.Black));
        [DefaultValue(""), Description("前景色"), Category("外观")]
        public Color ForeColor
        {
            get { return (Color)this.GetValue(ForeColorProperty); }
            set
            {
                this.SetValue(ForeColorProperty, value);
                if (ScreenElement != null)
                    ScreenElement.ForeColor = value.ToString();
            }
        }


        private static readonly DependencyProperty TransparentProperty = DependencyProperty.Register("Transparent",
        typeof(int), typeof(RealTimeT), new PropertyMetadata(0));
        private int _Transparent = 0;
        [DefaultValue(""), Description("透明"), Category("杂项")]
        public int Transparent
        {
            get { return _Transparent; }
            set
            {
                _Transparent = value;
                if (ScreenElement != null)
                    ScreenElement.Transparent = value;
            }
        }
        #endregion

        #endregion
        /*
             XISSGShow	--是否X轴栅格显示		
			 XMainNumber	--X主分度数 		
			 XMainColor X主分度颜色 		
			 XPriNumber X次分度数		
			 XPriColor X度次分颜色
		
		--Y轴
		
			 YISSGShow 是否Y轴栅格显示		
			 YMainNumber Y主分度数		
			 YMainColor Y主分度颜色		
			 YPriNumber Y次分度数		
			 YPriColor Y度次分颜色
		--其它颜色		
			 ISShowBorder 显示边框		
			 BorderColor 边框		
			 ISShowGridBack 显示背景		
			 GridBackColor 背景颜色		
			 ISShowCursor 显示游标		
			 CursorColor 游标颜色		
			 ISShowTime 显示时间		
			 TimeColor 时间颜色
		

		
			 UsePerZB 采用百分比坐标		
			 NoUseDataMove 无效数据移出		
			 DoubleClickShowSet 双击显示设置框		
			 RightShowYZB 右显示Y轴坐标		
			 MultiXZShow 多X轴显示		
			 MultiYZShow 多Y轴显示		
			 ShowLegend 显示图例		
			 InfoLWidth 信息栏宽度

		--放缩设置
		
			 MouseDrawEnlare 鼠标拖动放大		
			 XZEnlare X轴放大		
			 YZEnlare Y轴放大		
			 MouseDrawMove 鼠标拖动移动		
			 XZMove X轴移动		
			 YZMove Y轴移动
         * */

        #region X轴
        private bool _XISSGShow = true;
        /// <summary>
        /// 是否X轴栅格显示
        /// </summary>
        public bool XISSGShow
        {
            get { return _XISSGShow; }
            set { _XISSGShow = value; }
        }

        private int _XMainNumber = 3;
        /// <summary>
        /// X主线度数
        /// </summary>
        public int XMainNumber
        {
            get { return _XMainNumber; }
            set { _XMainNumber = value; }
        }

        private Color _XMainColor = Colors.Black;
        /// <summary>
        /// X主线颜色
        /// </summary>
        public Color XMainColor
        {
            get { return _XMainColor; }
            set { _XMainColor = value; }
        }


        private int _XPriNumber = 3;
        /// <summary>
        /// X次分度数
        /// </summary>
        public int XPriNumber
        {
            get { return _XPriNumber; }
            set { _XPriNumber = value; }
        }

        private Color _XPriColor = Colors.Black;
        /// <summary>
        /// X次分颜色
        /// </summary>
        public Color XPriColor
        {
            get { return _XPriColor; }
            set { _XPriColor = value; }
        }

        #endregion Y轴

        #region  Y轴

        private bool _YISSGShow = true;
        /// <summary>
        /// 是否Y轴栅格显示
        /// </summary>
        public bool YISSGShow
        {
            get { return _YISSGShow; }
            set { _YISSGShow = value; }
        }

        private int _YMainNumber = 3;
        /// <summary>
        /// Y主线度数
        /// </summary>
        public int YMainNumber
        {
            get { return _YMainNumber; }
            set { _YMainNumber = value; }
        }

        private Color _YMainColor = Colors.Black;
        /// <summary>
        /// Y主线颜色
        /// </summary>
        public Color YMainColor
        {
            get { return _YMainColor; }
            set { _YMainColor = value; }
        }


        private int _YPriNumber = 3;
        /// <summary>
        /// Y次分度数
        /// </summary>
        public int YPriNumber
        {
            get { return _YPriNumber; }
            set { _YPriNumber = value; }
        }

        private Color _YPriColor = Colors.Black;
        /// <summary>
        /// Y次分颜色
        /// </summary>
        public Color YPriColor
        {
            get { return _YPriColor; }
            set { _YPriColor = value; }
        }

        #endregion

        #region 其它设置
        //ISShowBorder //显示边框		
        //     BorderColor //边框		
        //     ISShowGridBack //显示背景		
        //     GridBackColor //背景颜色		
        //     ISShowCursor //显示游标		
        //     CursorColor //游标颜色		
        //     ISShowTime //显示时间		
        //     TimeColor //时间颜色
        #region 颜色设置

        private bool _ISShowBorder = true;
        /// <summary>
        /// 显示边框
        /// </summary>
        public bool ISShowBorder
        {
            get { return _ISShowBorder; }
            set { _ISShowBorder = value; }
        }


        private Color _BorderColor = Colors.Black;
        /// <summary>
        /// 边框颜色
        /// </summary>
        public Color BorderColor
        {
            get { return _BorderColor; }
            set { _BorderColor = value; }
        }

        private bool _ISShowGridBack = true;
        /// <summary>
        /// 显示背景
        /// </summary>
        public bool ISShowGridBack
        {
            get { return _ISShowGridBack; }
            set { _ISShowGridBack = value; }
        }


        private Color _GridBackColor = Colors.Cyan;
        /// <summary>
        /// 背景颜色
        /// </summary>
        public Color GridBackColor
        {
            get { return _GridBackColor; }
            set { _GridBackColor = value; }
        }

        private bool _ISShowCursor = false;
        /// <summary>
        /// 显示游标
        /// </summary>
        public bool ISShowCursor
        {
            get { return _ISShowCursor; }
            set { _ISShowCursor = value; }
        }

        private Color _CursorColor;
        /// <summary>
        /// 游标颜色
        /// </summary>
        public Color CursorColor
        {
            get { return _CursorColor; }
            set { _CursorColor = value; }
        }

        private bool _ISShowTime = true;
        /// <summary>
        /// 显示时间
        /// </summary>
        public bool ISShowTime
        {
            get { return _ISShowTime; }
            set { _ISShowTime = value; }
        }

        private Color _TimeColor;
        /// <summary>
        /// 时间颜色
        /// </summary>
        public Color TimeColor
        {
            get { return _TimeColor; }
            set { _TimeColor = value; }
        }
        #endregion



        private bool _UsePerZB;
        /// <summary>
        /// 采用百分比坐标
        /// </summary>
        public bool UsePerZB
        {
            get { return _UsePerZB; }
            set { _UsePerZB = value; }
        }

        private bool _NoUseDataMove;
        /// <summary>
        /// 无效数据移出
        /// </summary>
        public bool NoUseDataMove
        {
            get { return _NoUseDataMove; }
            set { _NoUseDataMove = value; }
        }

        private bool _DoubleClickShowSet;
        /// <summary>
        /// 双击显示设置框
        /// </summary>
        public bool DoubleClickShowSet
        {
            get { return _DoubleClickShowSet; }
            set { _DoubleClickShowSet = value; }
        }

        private bool _RightShowYZB;
        /// <summary>
        /// 右轴显示Y轴坐标
        /// </summary>
        public bool RightShowYZB
        {
            get { return _RightShowYZB; }
            set { _RightShowYZB = value; }
        }

        private bool _MultiXZShow = false;
        /// <summary>
        /// 多X轴显示
        /// </summary>
        public bool MultiXZShow
        {
            get { return _MultiXZShow; }
            set { _MultiXZShow = value; }
        }

        private bool _MultiYZShow;
        /// <summary>
        /// 多Y轴显示
        /// </summary>
        public bool MultiYZShow
        {
            get { return _MultiYZShow; }
            set { _MultiYZShow = value; }
        }

        private bool _IsShowLegend;
        /// <summary>
        /// 是否显示图例
        /// </summary>
        public bool IsShowLegend
        {
            get { return _IsShowLegend; }
            set { _IsShowLegend = value; }
        }

        private string _ShowLegend;
        /// <summary>
        /// 显示图例(
        /// 显示数值、显示变量描述、显示表达试、显示变量最大值、
        ///显示变量最小值、显示变量平均值、显示变量统计值、显示时间最小值、
        ///显示时间最大值)
        /// </summary>
        public string ShowLegend
        {
            get { return _ShowLegend; }
            set { _ShowLegend = value; }
        }

        private int _infoLWidth;
        /// <summary>
        /// 信息栏宽度
        /// </summary>
        public int InfoLWidth
        {
            get { return _infoLWidth; }
            set { _infoLWidth = value; }
        }
        #endregion

        #region 放缩设置
        private bool _MouseDrawEnlare;
        /// <summary>
        /// 鼠标移动放大
        /// </summary>
        public bool MouseDrawEnlare
        {
            get { return _MouseDrawEnlare; }
            set { _MouseDrawEnlare = value; }
        }

        private bool _XZEnlare;
        /// <summary>
        /// X轴放大
        /// </summary>
        public bool XZEnlare
        {
            get { return _XZEnlare; }
            set { _XZEnlare = value; }
        }

        private bool _YZEnlare;
        /// <summary>
        /// Y轴放大
        /// </summary>
        public bool YZEnlare
        {
            get { return _YZEnlare; }
            set { _YZEnlare = value; }
        }


        private bool _MouseDrawMove;
        /// <summary>
        /// 鼠标拖动移动
        /// </summary>
        public bool MouseDrawMove
        {
            get { return _MouseDrawMove; }
            set { _MouseDrawMove = value; }
        }

        private bool _XZMove;
        /// <summary>
        /// X轴移动
        /// </summary>
        public bool XZMove
        {
            get { return _XZMove; }
            set { _XZMove = value; }
        }

        private bool _YZMove;
        /// <summary>
        /// Y轴移动
        /// </summary>
        public bool YZMove
        {
            get { return _YZMove; }
            set { _YZMove = value; }
        }

        #endregion





        /// <summary>
        /// 显示基本信息
        /// </summary>
        private void PaintBasicInfo()
        {
            if (double.IsNaN(_Canvas.Width))
                return;
            _Canvas.Children.Clear();
            _Canvas.Children.Add(_CanvasGrid);
            _Canvas.Children.Add(_CanvasLine);
            InitLine();
            //实时线网格
            PainGrid();
            DrawLine();
            ShowValue();
            PainXYZ();
        }

        /// <summary>
        /// 初使化曲线
        /// </summary>
        private void InitLine()
        {
            RealTimeLineOR obj = new RealTimeLineOR();
            obj.LineName = "ll";
            obj.YminValue = 50;
            obj.YmaxValue = 150;

            obj.LineColor = Colors.Red;
            listRealTimeLine.Add(obj);

            RealTimeLineOR obj1 = new RealTimeLineOR();
            obj1.LineName = "lsbee";
            obj1.YminValue = 50;
            obj1.YmaxValue = 150;
            obj.LineColor = Colors.Purple;
            listRealTimeLine.Add(obj1);
        }
        /// <summary>
        /// 显示曲线
        /// </summary>
        private void DrawLine()
        {
            gdLineDefine.RowDefinitions.Clear();
            for (int i = 0; i < listRealTimeLine.Count; i++)
            {
                gdLineDefine.RowDefinitions.Add(new RowDefinition());
            }

            int index = 0;
            //_CanvasLine.Background = new SolidColorBrush(Colors.Cyan);
            foreach (RealTimeLineOR objOR in listRealTimeLine)
            {
                RealLineShow obj = new RealLineShow(objOR);
                objOR.TitleShowInfo = obj;
                objOR.PicCurveShowHeight = LineCanversHeight;
                objOR.PicCurveWidth = LineCanversWidth;
                obj.ChangeLineShow += new EventHandler(RealLineShow_ChangeLineShow);

                gdLineDefine.Children.Add(obj);
                obj.SetValue(Grid.RowProperty, index);
                //添加线到界面                
                _CanvasLine.Children.Add(objOR.PolyLine);
                index++;
            }
        }




        #region 画背景网格

        //Y开始坐标
        double _YStart = 0;
        //X开始坐标
        double _XStart = 100;
        /// <summary>
        /// 网格的宽度
        /// </summary>
        double xGridWidth = 0;
        /// <summary>
        /// 网络的宽度
        /// </summary>
        double yGridHeight = 0;
        /// <summary>
        /// X轴高度
        /// </summary>
        //double XZHeight = 80;

        /// <summary>
        /// 显示曲线的宽度
        /// </summary>
        double LineCanversWidth = 0;
        /// <summary>
        /// 显示曲线的高度
        /// </summary>
        double LineCanversHeight = 0;

        private void PainGridBack()
        {
            _CanvasGrid.Background = new SolidColorBrush(_GridBackColor);
        }
        /// <summary>
        /// 显示背景框，和其它初使值
        /// </summary>
        private void PainGrid()
        {
            //边框
            Line _Line1 = new Line();
            Line _Line3 = new Line();

            PainGridBack();
            _CanvasGrid.Children.Clear();

            SetXYStartPosition();

            LineCanversWidth = _Canvas.Width - _XStart;
            LineCanversHeight = _Canvas.Height - _YStart;

            Rect rect = new Rect();
            rect.Width = LineCanversWidth;
            rect.Height = LineCanversHeight;

            RectangleGeometry r = new RectangleGeometry();
            r.Rect = rect;
            _CanvasLine.Clip = r;

            _CanvasLine.Width = _CanvasGrid.Width = LineCanversWidth;
            _CanvasLine.Height = _CanvasGrid.Height = LineCanversHeight;

            if (_RightShowYZB)
            {
                _CanvasGrid.SetValue(Canvas.LeftProperty, 0d);
                _CanvasLine.SetValue(Canvas.LeftProperty, 0d);
            }
            else
            {
                _CanvasGrid.SetValue(Canvas.LeftProperty, _XStart);
                _CanvasLine.SetValue(Canvas.LeftProperty, _XStart);
            }

            //_CanvasGrid.SetValue(Canvas.TopProperty, _YStart);
            //_CanvasLine.SetValue(Canvas.TopProperty, _YStart);

            xGridWidth = _Canvas.Width - _XStart;
            yGridHeight = _Canvas.Height - _YStart;// -XZHeight;  

            //边框
            _CanvasGrid.Children.Add(_Line1);
            _CanvasGrid.Children.Add(_Line3);
            _Line1.X1 = 0;
            _Line1.Y1 = 0;
            _Line1.X2 = xGridWidth;
            _Line1.Y2 = 0;

            _Line3.X1 = xGridWidth;
            _Line3.X2 = xGridWidth;
            _Line3.Y1 = 0;
            _Line3.Y2 = yGridHeight;
            _Line3.Stroke = _Line1.Stroke = new SolidColorBrush(_BorderColor);
            _Line3.StrokeThickness = _Line1.StrokeThickness = 2;

            //Y轴线
            double _YStartDoble = 0;
            double aYMainSize = xGridWidth / (this._YMainNumber + 1);
            double aYPerSize = aYMainSize / (this._YPriNumber + 1);

            for (int imain = 0; imain < _YMainNumber; imain++)
            {
                PainPriGrid(_YStartDoble, aYPerSize, false);
                double y = _YStartDoble + aYMainSize;
                _YStartDoble = y;
                _CanvasGrid.Children.Add(AddMainLine(y, y, 0, yGridHeight, _YMainColor, 2));
            }
            PainPriGrid(_YStartDoble, aYPerSize, false);

            //X轴线
            double _XStartDoble = 0;
            double aXMainSize = yGridHeight / (this._XMainNumber + 1);
            double aXPerSize = aXMainSize / (this._XPriNumber + 1);

            for (int imain = 0; imain < _XMainNumber; imain++)
            {
                PainPriGrid(_XStartDoble, aXPerSize, true);
                double X = _XStartDoble + aXMainSize;
                _XStartDoble = X;
                _CanvasGrid.Children.Add(AddMainLine(0, xGridWidth, X, X, _XMainColor, 2));
            }
            PainPriGrid(_XStartDoble, aXPerSize, true);
        }

        private void PainPriGrid(double startPosition, double aPerSize, bool ISAddY)
        {
            for (int i = 0; i < this._XPriNumber; i++)
            {
                if (ISAddY)//y轴
                {
                    double priy = startPosition + aPerSize;
                    startPosition = priy;
                    _CanvasGrid.Children.Add(AddPrimLine(0, xGridWidth, priy, priy, _XMainColor, 1));
                }
                else//x轴
                {
                    double priX = startPosition + aPerSize;
                    startPosition = priX;
                    _CanvasGrid.Children.Add(AddPrimLine(priX, priX, 0, yGridHeight, _XMainColor, 1));
                }
            }
        }

        #region 添加线
        private Line AddMainLine(double _x1, double _x2, double _y1, double _y2, Color _Color, double lineSize)
        {
            Line _Line = new Line();
            _Line.X1 = _x1;
            _Line.X2 = _x2;
            _Line.Y1 = _y1;
            _Line.Y2 = _y2;
            _Line.Stroke = new SolidColorBrush(_Color);
            _Line.StrokeThickness = lineSize;
            return _Line;
        }
        private Line AddPrimLine(double _x1, double _x2, double _y1, double _y2, Color _Color, double lineSize)
        {
            Line _Line = new Line();
            _Line.X1 = _x1;
            _Line.X2 = _x2;
            _Line.Y1 = _y1;
            _Line.Y2 = _y2;
            _Line.Stroke = new SolidColorBrush(_Color);
            _Line.StrokeThickness = lineSize;
            _Line.StrokeDashArray = new DoubleCollection { 2.0, 2.0 };
            return _Line;
        }
        #endregion

        #endregion
        #region 画X、Y轴




        /// <summary>
        /// X轴线长度
        /// </summary>
        int XZLineHeight = 8;
        /// <summary>
        /// X轴文本显示高度
        /// </summary>
        int XZTxtHeight = 15;


        /// <summary>
        /// 画X、Y轴
        /// </summary>
        private void PainXYZ()
        {
            _CanvasZ.Children.Clear();
            //X轴处理 
            if (_MultiXZShow)
            {
                foreach (RealTimeLineOR obj in listRealTimeLine)
                {
                    PaintX(obj);
                }
            }
            else
            {
                PaintX(listRealTimeLine.First());
            }
            //画Y轴
            PaintY();
        }

        /// <summary>
        /// 设置XY轴开始位置
        /// </summary>
        private void SetXYStartPosition()
        {
            if (MultiXZShow)
            {
                _YStart = (XZLineHeight + XZTxtHeight) * listRealTimeLine.Count;
            }
            else
            {
                _YStart = XZLineHeight + XZTxtHeight;
            }

            if (MultiXZShow)
            {

                _XStart = (YZLineWidth + YZTxtWidth) * listRealTimeLine.Count;
            }
            else
            {
                _XStart = YZLineWidth + YZTxtWidth;
            }
        }

        /// <summary>
        /// 画X轴
        /// </summary>
        private void PaintX(RealTimeLineOR objOR)
        {
            double axzMainSize = xGridWidth / (this._YMainNumber + 1);
            double xzY = yGridHeight;
            //x轴
            Line mXZ = new Line();
            mXZ.X1 = _XStart;
            mXZ.X2 = _XStart + xGridWidth;
            if (RightShowYZB)
            {
                mXZ.X1 = 0;
                mXZ.X2 = xGridWidth;
            }
            mXZ.Y1 = mXZ.Y2 = xzY;
            mXZ.Stroke = new SolidColorBrush(objOR.LineColor);
            mXZ.StrokeThickness = 2;
            _CanvasZ.Children.Add(mXZ);
            objOR.TextList.Clear();
            for (int imain = 0; imain < _XMainNumber + 2; imain++)
            {
                double _x = _XStart + imain * axzMainSize;
                if (RightShowYZB)
                {
                    _x = imain * axzMainSize;
                }
                Line mkd = new Line();
                mkd.X1 = mkd.X2 = _x;
                mkd.Y1 = xzY;
                mkd.Y2 = xzY + XZLineHeight;
                mkd.Stroke = new SolidColorBrush(objOR.LineColor);
                mkd.StrokeThickness = 2;
                _CanvasZ.Children.Add(mkd);

                //添加X轴标签
                TextBlock tb = new TextBlock();
                //tb.Text = DateTime.Now.ToString("hh:MM:ss");
                objOR.TextList.Add(tb);
                tb.Foreground = new SolidColorBrush(objOR.LineColor);
                tb.SetValue(Canvas.LeftProperty, _x - 24);
                tb.SetValue(Canvas.TopProperty, xzY + XZLineHeight);
                _CanvasZ.Children.Add(tb);
            }
            objOR.SetXZTextBoxValue();
        }
        /// <summary>
        /// X轴线长度
        /// </summary>
        int YZLineWidth = 8;
        /// <summary>
        /// X轴文本显示高度
        /// </summary>
        int YZTxtWidth = 30;
        /// <summary>
        /// 画Y轴
        /// </summary>
        private void PaintY()
        {
            //右边显示Y轴
            double ayzMainSize = yGridHeight / (this._YMainNumber + 1);
            double yzX = _XStart;//yzX坐标
            if (_RightShowYZB)
            {
                yzX = xGridWidth;
            }
            //Y轴
            Line mXZ = new Line();
            mXZ.X2 = mXZ.X1 = _XStart;
            if (RightShowYZB)
                mXZ.X2 = mXZ.X1 = xGridWidth;
            mXZ.Y1 = 0;
            mXZ.Y2 = yGridHeight;
            mXZ.Stroke = new SolidColorBrush(Colors.Black);
            mXZ.StrokeThickness = 4;
            _CanvasZ.Children.Add(mXZ);
            //if (_RightShowYZB)
            //{
            //}
            string[] arrText = GetYText(listRealTimeLine.First());
            for (int imain = 0; imain < _YMainNumber + 2; imain++)
            {
                double _y = imain * ayzMainSize;
                double _X = 0;
                if (_RightShowYZB)
                    _X = yzX + YZLineWidth;
                else
                    _X = yzX - YZLineWidth;

                Line mkd = new Line();
                mkd.X1 = _X;
                mkd.X2 = yzX;
                mkd.Y1 = mkd.Y2 = _y;
                mkd.Stroke = new SolidColorBrush(Colors.Black);
                mkd.StrokeThickness = 4;
                _CanvasZ.Children.Add(mkd);

                //添加Y轴标签
                TextBlock tb = new TextBlock();
                tb.Text = arrText[imain];
                if (!_RightShowYZB)
                    _X = _X - YZTxtWidth + 2;
                tb.SetValue(Canvas.LeftProperty, _X);
                tb.SetValue(Canvas.TopProperty, _y);
                _CanvasZ.Children.Add(tb);
            }
        }

        /// <summary>
        /// 获取Y轴文本值
        /// </summary>
        /// <returns></returns>
        private string[] GetYText(RealTimeLineOR obj)
        {
            string[] ytextArr = new string[_YMainNumber + 2];

            double half = 0;
            if (obj.YZSFPer != 1)
                half = ((obj.YmaxValue - obj.YminValue) * (obj.YZSFPer - 1)) / 2;
            double max = obj.YmaxValue + half;
            double min = obj.YminValue - half;

            double v = max - min;
            double vPer = v / (_YMainNumber + 1);
            ytextArr[0] = max.ToString();
            for (int i = 1; i <= _YMainNumber; i++)
            {
                ytextArr[i] = (max - (i * vPer)).ToString();
            }
            ytextArr[_YMainNumber + 1] = min.ToString();
            return ytextArr;
        }
        #endregion

        private void ShowValue()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += (sender, obj) =>
            {
                Random rd = new Random();
                foreach (RealTimeLineOR objOR in listRealTimeLine)
                {
                    objOR.AddNewValue(Convert.ToDouble(rd.NextDouble() * objOR.YmaxValue));
                    objOR.ShowCurve();
                }
            };
            timer.Start();
        }




        private void button1_Click(object sender, RoutedEventArgs e)
        {
            RealtimeProperty rp = new RealtimeProperty();
            rp.RealTimeData = this;
            rp.Init();
            rp.Show();
            //Random rd = new Random();
            //foreach (RealTimeLineOR objOR in listRealTimeLine)
            //{
            //    objOR.AddNewValue( Convert.ToDouble(txtVal.Text));
            //    objOR.ShowCurve();

            //}
        }

        /// <summary>
        /// 右边显示Y轴信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            //X轴,Y轴换位置
            gdMain.ColumnDefinitions.Clear();
            gdMain.ColumnDefinitions.Add(new ColumnDefinition());
            gdMain.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(LineListWidth, GridUnitType.Auto) });

            _CanvasZ.SetValue(Grid.ColumnProperty, 1);
            _Canvas.SetValue(Grid.ColumnProperty, 1);
            LineList.SetValue(Grid.ColumnProperty, 0);


            _RightShowYZB = true;
            PainGrid();
            PainXYZ();
        }

        #region 缩放处理
        private void HeadSF(double _SFper)
        {
            foreach (RealTimeLineOR obj in listRealTimeLine)
            {
                if (obj.YZSFPer == _SFper)
                    continue;
                PainXYZ();

                obj.YZSFPer = _SFper;
                obj.HeadSFArr();
                obj.ShowCurve();
            }
        }
        /// <summary>
        /// 原始
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnYS_Click(object sender, RoutedEventArgs e)
        {
            HeadSF(1);
        }
        /// <summary>
        /// 2倍
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn2B_Click(object sender, RoutedEventArgs e)
        {
            HeadSF(2);
        }
        /// <summary>
        /// 4倍
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn4B_Click(object sender, RoutedEventArgs e)
        {
            HeadSF(4);
        }
        /// <summary>
        /// 8倍
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn8B_Click(object sender, RoutedEventArgs e)
        {
            HeadSF(8);
        }
        /// <summary>
        /// 缩放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSF_Click(object sender, RoutedEventArgs e)
        {
            double sfPer = Convert.ToDouble(intputSFPer.DataValue);
            if (sfPer <= 0)
            {
                MessageBox.Show("请设置大于“1”的缩放倍数！");
                return;
            }
            HeadSF(sfPer);
        }
        /// <summary>
        /// 恢复
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHF_Click(object sender, RoutedEventArgs e)
        {
            HeadSF(1);
        }
        #endregion

        #region 曲线显示隐藏处理
        private void RealLineShow_ChangeLineShow(object sender, EventArgs e)
        {
            RealLineArgs obj = (RealLineArgs)e;

            if (string.IsNullOrEmpty(obj.Name))
            {
                ShowOrHideAllLine(true);
            }
            else
            {
                ShowOrHideAllLine(false);
                ShowALine(obj.Name);
            }
        }
        /// <summary>
        ///  隐藏曲线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHide_Click(object sender, RoutedEventArgs e)
        {
            if (!HideALine(qxname.DataValue.ToString()))
                MessageBox.Show("找不到曲线：" + qxname.DataValue);
        }

        /// <summary>
        /// 显示指定曲线
        /// </summary>
        /// <param name="LineName"></param>
        /// <returns></returns>
        private bool HideALine(string LineName)
        {
            foreach (RealTimeLineOR obj in listRealTimeLine)
            {
                if (obj.LineName == LineName)
                {
                    _CanvasLine.Children.Remove(obj.PolyLine);
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 显示指定曲线
        /// </summary>
        /// <param name="LineName"></param>
        /// <returns></returns>
        private bool ShowALine(string LineName)
        {
            foreach (RealTimeLineOR obj in listRealTimeLine)
            {
                if (obj.LineName == LineName)
                {
                    if (_CanvasLine.FindName(obj.LineGuid) == null)
                    {
                        _CanvasLine.Children.Add(obj.PolyLine);
                    }
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 显示或隐藏所有曲线
        /// </summary>
        /// <param name="LineName"></param>
        /// <returns></returns>
        private bool ShowOrHideAllLine(bool isShow)
        {
            foreach (RealTimeLineOR obj in listRealTimeLine)
            {
                if (isShow)//显示
                {
                    if (_CanvasLine.FindName(obj.LineGuid) == null)
                    {
                        _CanvasLine.Children.Add(obj.PolyLine);
                    }
                }
                else//隐藏
                {
                    if (_CanvasLine.FindName(obj.LineGuid) != null)
                    {
                        _CanvasLine.Children.Remove(obj.PolyLine);
                    }
                }

            }
            return false;
        }

        /// <summary>
        /// 显示曲线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            if (!ShowALine(qxname.DataValue.ToString()))
            {
                MessageBox.Show("找不到曲线：" + qxname.DataValue);
            }
        }
        #endregion

        #region 处理显示时间长度
        private void HeadTimeLen(int Len, string type)
        {
            foreach (RealTimeLineOR obj in listRealTimeLine)
            {
                if (obj.TimeLen == Len && type == obj.TimeLenType)
                    continue;
                obj.TimeLenType = type;
                obj.TimeLen = Len;
                obj.ChangeXValue();
                obj.ShowCurve();
            }
            PainXYZ();
        }

        private void btnMi1_Click(object sender, RoutedEventArgs e)
        {
            HeadTimeLen(1, "mm");
        }

        private void btnMi5_Click(object sender, RoutedEventArgs e)
        {
            HeadTimeLen(5, "mm");
        }

        private void btnMi15_Click(object sender, RoutedEventArgs e)
        {
            HeadTimeLen(15, "mm");
        }

        private void btnMi30_Click(object sender, RoutedEventArgs e)
        {
            HeadTimeLen(30, "mm");
        }

        private void btnhh1_Click(object sender, RoutedEventArgs e)
        {
            HeadTimeLen(1, "hh");
        }

        private void btnhh6_Click(object sender, RoutedEventArgs e)
        {
            HeadTimeLen(6, "hh");
        }

        private void btnhh24_Click(object sender, RoutedEventArgs e)
        {
            HeadTimeLen(24, "hh");
        }

        #endregion

    }
}
