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

namespace MonitorSystem.ZTControls
{
    /// <summary>
    /// 6	DLBiaoPan	2	DLBiaoPan.jpg	组态控件	圆盘
    /// </summary>
    public class DLBiaoPan : MonitorControl
    {
        public override void DesignMode()
        {
            if (!IsDesignMode)
            {
                AdornerLayer = new Adorner(this);
                AdornerLayer.Selected += OnSelected;

                var menu = new ContextMenu();
                var menuItem = new MenuItem() { Header = "属性" };
                menuItem.Click += PropertyMenuItem_Click;
                menu.Items.Add(menuItem);
                AdornerLayer.SetValue(ContextMenuService.ContextMenuProperty, menu);
                AdornerLayer.IsLockScale = true;
            }
        }

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

        private void OnSelected(object sender, EventArgs e)
        {
            if (null != Selected)
            {
                Selected(this, RoutedEventArgs.Empty);
            }
        }

        #region 属性设置
        SetSingleProperty tpp = new SetSingleProperty();
        private void PropertyMenuItem_Click(object sender, RoutedEventArgs e)
        {
            tpp = new SetSingleProperty();

            tpp.Closing += new EventHandler<System.ComponentModel.CancelEventArgs>(tpp_Closing);
            tpp.DeviceID = this.ScreenElement.DeviceID.Value;
            tpp.ChanncelID = this.ScreenElement.ChannelNo.Value;
            tpp.LevelNo = this.ScreenElement.LevelNo.Value;
            tpp.ComputeStr = this.ScreenElement.ComputeStr;
            tpp.Init();
            tpp.Show();
        }

        protected void tpp_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (tpp.IsOK)
            {
                this.ScreenElement.DeviceID = tpp.DeviceID;
                this.ScreenElement.ChannelNo = tpp.ChanncelID;
                this.ScreenElement.LevelNo = tpp.LevelNo;
                this.ScreenElement.ComputeStr = tpp.ComputeStr;
            }
        }

        #endregion

        public override object GetRootControl()
        {
            return this;
        }

        public override event EventHandler Selected;

        public override void SetPropertyValue()
        {
            
        }

        public override void SetCommonPropertyValue()
        {
            this.SetValue(Canvas.LeftProperty, (double)ScreenElement.ScreenX);
            this.SetValue(Canvas.TopProperty, (double)ScreenElement.ScreenY);
            this.Width = (double)ScreenElement.Width;
            this.Height = (double)ScreenElement.Height;
        }

        private string[] _browsableProperties = new[] { "BackColor", "ForeColor", "MinValue", "MaxValue", "CurrenValue", "Title"};
        public override string[] BrowsableProperties
        {
            get { return _browsableProperties; }
            set { _browsableProperties = value; }
        }

        #region 属性

        private static readonly DependencyProperty BackColorProperty =
            DependencyProperty.Register("BackColor",
            typeof(Color), typeof(DLBiaoPan), new PropertyMetadata(Colors.White, new PropertyChangedCallback(BackColor_Changed)));

        public Color BackColor
        {
            get { return (Color)this.GetValue(BackColorProperty); }
            set { this.SetValue(BackColorProperty, value); }
        }

        private static void BackColor_Changed(DependencyObject element, DependencyPropertyChangedEventArgs e)
        {
            DLBiaoPan DLBiaoPan = (DLBiaoPan)element;
            DLBiaoPan.OnBackColorChanged((Color)e.NewValue, (Color)e.OldValue);
        }

        public void OnBackColorChanged(Color oldValue, Color newValue)
        {
            PaintBackground();
        }

        private static readonly DependencyProperty ForeColorProperty =
            DependencyProperty.Register("ForeColor",
            typeof(Color), typeof(DLBiaoPan), new PropertyMetadata(Colors.Black, new PropertyChangedCallback(ForeColor_Changed)));

        public Color ForeColor
        {
            get { return (Color)this.GetValue(ForeColorProperty); }
            set { this.SetValue(ForeColorProperty, value); }
        }

        private static void ForeColor_Changed(DependencyObject element, DependencyPropertyChangedEventArgs e)
        {
            DLBiaoPan DLBiaoPan = (DLBiaoPan)element;
            DLBiaoPan.OnForeColorChanged((Color)e.NewValue, (Color)e.OldValue);
        }

        public void OnForeColorChanged(Color oldValue, Color newValue)
        {
            PaintBackground();
        }

        private static readonly DependencyProperty MinValueProperty =
            DependencyProperty.Register("MinValue",
            typeof(int), typeof(DLBiaoPan), new PropertyMetadata(0, new PropertyChangedCallback(MinValue_Changed)));

        public int MinValue
        {
            get { return (int)this.GetValue(MinValueProperty); }
            set { this.SetValue(MinValueProperty, value); }
        }

        private static void MinValue_Changed(DependencyObject element, DependencyPropertyChangedEventArgs e)
        {
            DLBiaoPan DLBiaoPan = (DLBiaoPan)element;
            DLBiaoPan.OnMinValueChanged((int)e.NewValue, (int)e.OldValue);
        }

        public void OnMinValueChanged(int oldValue, int newValue)
        {
            Paint(DesiredSize);
        }

        private static readonly DependencyProperty MaxValueProperty =
            DependencyProperty.Register("MaxValue",
            typeof(int), typeof(DLBiaoPan), new PropertyMetadata(100, new PropertyChangedCallback(MaxValue_Changed)));

        public int MaxValue
        {
            get { return (int)this.GetValue(MaxValueProperty); }
            set { this.SetValue(MaxValueProperty, value); }
        }

        private static void MaxValue_Changed(DependencyObject element, DependencyPropertyChangedEventArgs e)
        {
            DLBiaoPan DLBiaoPan = (DLBiaoPan)element;
            DLBiaoPan.OnMaxValueChanged((int)e.NewValue, (int)e.OldValue);
        }

        public void OnMaxValueChanged(int oldValue, int newValue)
        {
            Paint(DesiredSize);
        }

        private static readonly DependencyProperty CurrenValueProperty =
            DependencyProperty.Register("CurrenValue",
            typeof(int), typeof(DLBiaoPan), new PropertyMetadata(50, new PropertyChangedCallback(CurrenValue_Changed)));

        public int CurrenValue
        {
            get { return (int)this.GetValue(CurrenValueProperty); }
            set { this.SetValue(CurrenValueProperty, value); }
        }

        private static void CurrenValue_Changed(DependencyObject element, DependencyPropertyChangedEventArgs e)
        {
            DLBiaoPan DLBiaoPan = (DLBiaoPan)element;
            DLBiaoPan.OnCurrenValueChanged((int)e.NewValue, (int)e.OldValue);
        }

        public void OnCurrenValueChanged(int oldValue, int newValue)
        {
            PaintPointer();
        }

        private static readonly DependencyProperty TitleProperty =  DependencyProperty.Register("Title",
            typeof(string), typeof(DLBiaoPan), new PropertyMetadata("A", new PropertyChangedCallback(Title_Changed)));

        public string Title
        {
            get { return (string)this.GetValue(TitleProperty); }
            set { this.SetValue(TitleProperty, value); }
        }

        private static void Title_Changed(DependencyObject element, DependencyPropertyChangedEventArgs e)
        {
            DLBiaoPan DLBiaoPan = (DLBiaoPan)element;
            DLBiaoPan.OnTitleChanged((string)e.NewValue, (string)e.OldValue);
        }

        public void OnTitleChanged(string oldValue, string newValue)
        {
            SetText();
        }

        #endregion

        private Canvas _canvas = new Canvas();
        private Rectangle _background = new Rectangle() { Stroke  = new SolidColorBrush(Colors.Black), StrokeThickness = 2d, };
        private Canvas _calibrationCanvas = new Canvas() { };
        private TextBlock _text = new TextBlock() { Foreground = new SolidColorBrush(Colors.Red), };
        private Canvas _pointCanvas = new Canvas();
        private Ellipse _axisInnerEllipse = new Ellipse();
        private Ellipse _axisOuterEllipse = new Ellipse();
        private Path _arcPath = new Path();
        private CompositeTransform _pointerTransform = new CompositeTransform();

        public DLBiaoPan()
        {
            this.Content = _canvas;
            _canvas.Children.Add(_background);
            _canvas.Children.Add(_calibrationCanvas);
            _canvas.Children.Add(_text);
            _canvas.Children.Add(_pointCanvas);
            _canvas.Children.Add(_axisOuterEllipse);
            _canvas.Children.Add(_axisInnerEllipse);
            _canvas.Children.Add(_arcPath);

            _pointCanvas.RenderTransformOrigin = new Point(0.5d, 1d);
            _pointCanvas.RenderTransform = _pointerTransform;

            SetText();
            PaintBackground();
        }

        private void SetText()
        {
            _text.Text = string.Format("{0}{1}", CurrenValue, Title);

            var width = DesiredSize.Width;
            var height = DesiredSize.Height;
            var widthSpan = 40d;
            var heightSpan = 20d;
            var centerX = (width - widthSpan) / 2d + heightSpan;
            var centerY = height - heightSpan + 10d;

            _text.SetValue(Canvas.LeftProperty, centerX - _text.ActualWidth / 2d);
            _text.SetValue(Canvas.TopProperty, centerY - (height - heightSpan - _text.ActualHeight) / 2d);
        }

        private void PaintBackground()
        {
            _background.Fill = new SolidColorBrush(BackColor);
        }

        private void Paint(Size finalSize)
        {
            //maxValue = 100;
            var circleWidth = 4d;
            var pointWidth = 4d;
            var keduWidth = 1d;
            var keduLength = 5d;
            var standWidth = 3d;

            var startDegree = 290d;
            var standLength = 10d;
            var minValue = MinValue;
            var maxValue = MaxValue;
            if (minValue >= maxValue)
                return;
            //if (currenValue < minValue || currenValue > maxValue)
            //{
            //    currenValue = (minValue + maxValue) / 2;
            //}
            var widthSpan = 40d;
            var heightSpan = 20d;
            var width = finalSize.Width;
            var height = finalSize.Height;
            var centerX = (width - widthSpan) / 2d + heightSpan;
            var centerY = height - heightSpan + 10d;

            //Single MyWidth, MyHeight;
            //MyWidth = Width - widthSpan;
            //MyHeight = Height - heightSpan;
            //Single DI = 2 * MyHeight;
            //if (MyWidth < MyHeight)
            //{
            //    DI = MyWidth;
            //}

            var degreePerStandKeDu = (720d - 2d * startDegree) / 5d;  //计算出每个标准大刻度之间的角度
            var degreePerKeDu = degreePerStandKeDu / 5d;
            var valuePerKeDu = (maxValue - minValue) / 5;  //每个大刻度之间的值
          
            //Rectangle MyRect;
            //g = e.Graphics;
            //g.Clear(this.BackColor);
            //g.DrawRectangle(new Pen(Color.Black, 2), 2, 2, this.Width - 4, this.Height - 4);
            _background.SetValue(WidthProperty, width);
            _background.SetValue(HeightProperty, height);


            //MyRect = new Rectangle(0, 0, this.Width, this.Height);
            //g.SmoothingMode = SmoothingMode.AntiAlias;
            ////将绘图平面的坐标原点移到窗口中心
            //g.TranslateTransform(MyWidth / 2 + heightSpan, MyHeight + 10);
            //绘制表盘
            //g.FillEllipse(Brushes.Black,MyRect);
            //string word = currenValue.ToString().Trim() + title;
            //int len = ((word.Trim().Length) * (myFont.Height)) / 2;
            //g.DrawString(word.Trim(), myFont, Brushes.Red, new PointF(-len / 2, -MyHeight / 2 - myFont.Height / 2));
            _text.SetValue(Canvas.LeftProperty, centerX- _text.ActualWidth / 2d);
            _text.SetValue(Canvas.TopProperty, centerY - (height - heightSpan - _text.ActualHeight) / 2d);

            //g.RotateTransform(startDegree);
            //绘制刻度标记
            _calibrationCanvas.Children.Clear();
            var calibrationBrush = new SolidColorBrush(Colors.Green);
            _calibrationCanvas.Background = calibrationBrush;
            var calibrationLeft = centerX - 2d;
            var calibrationTop = centerY + 2d - height + heightSpan;
            var calibrationDegree = startDegree;
            var origin = new Point(0.5d, (centerY - calibrationTop) / keduLength);
            for (int x = 0; x < 26; x++)
            {
                //g.FillRectangle(Brushes.Green, new Rectangle(-2, (System.Convert.ToInt16(DI) / 2 - 2) * (-1), keduWidth, keduLength));
                //g.RotateTransform(degreePerKeDu);
                var calibrationLine = new Rectangle();
                calibrationLine.SetValue(Canvas.LeftProperty, calibrationLeft);
                calibrationLine.SetValue(Canvas.TopProperty, calibrationTop);
                calibrationLine.SetValue(WidthProperty, keduWidth);
                calibrationLine.SetValue(HeightProperty, keduLength);
                calibrationLine.Fill = calibrationBrush;
                calibrationLine.RenderTransformOrigin = origin;
                calibrationLine.RenderTransform = new CompositeTransform() { Rotation = calibrationDegree, };
                _calibrationCanvas.Children.Add(calibrationLine);
                calibrationDegree += degreePerKeDu;
            }
            ////重置绘图平面的坐标变换
            //g.ResetTransform();
            //g.TranslateTransform(MyWidth / 2 + heightSpan, MyHeight + 10);
            //g.RotateTransform(startDegree);
            //mySpeed = minValue;
            ////绘制刻度值
            var speed = minValue;
            var labelBrush = new SolidColorBrush(Colors.Red);
            var lableLineLeft = centerX - 3d;
            var lableLineTop = centerY + 2d - height + heightSpan;
            var labelTop = centerY - (height - heightSpan) + 26d;
            var lableLineDegree = startDegree;
            var lableLineOrigin = new Point(0.5d, (centerY - lableLineTop) / standLength);
            for (int x = 0; x < 6; x++)
            {
                //myString = mySpeed.ToString();
                ////绘制红色刻度
                //g.FillRectangle(Brushes.Red, new Rectangle(-3, (System.Convert.ToInt16(DI) / 2 - 2) * (-1), standWidth, standLength));
                ////绘制数值
                //g.DrawString(myString, myFont, Brushes.Green, new PointF(myString.Length * (-6), -MyHeight + 26));
                ////旋转45度
                //g.RotateTransform(degreePerStandKeDu);
                //mySpeed = mySpeed + valuePerKeDu;

                var lableLine = new Rectangle();
                lableLine.SetValue(Canvas.LeftProperty, lableLineLeft);
                lableLine.SetValue(Canvas.TopProperty, lableLineTop);
                lableLine.SetValue(WidthProperty, standWidth);
                lableLine.SetValue(HeightProperty, standLength);
                lableLine.Fill = labelBrush;
                lableLine.RenderTransformOrigin = lableLineOrigin;
                lableLine.RenderTransform = new CompositeTransform() { Rotation = lableLineDegree, };
                _calibrationCanvas.Children.Add(lableLine);

                //绘制数值
                var grid = new Grid();
                var label = new TextBlock();
                label.Text = speed.ToString();
                label.Foreground = calibrationBrush;

                grid.SetValue(Canvas.LeftProperty, centerX - label.ActualWidth / 2d);
                grid.SetValue(Canvas.TopProperty, labelTop);
                grid.RenderTransformOrigin = new Point(0.5d, (centerY - labelTop) / label.ActualHeight);
                grid.RenderTransform = new CompositeTransform() { Rotation = lableLineDegree, };
                grid.Children.Add(label);
                _calibrationCanvas.Children.Add(grid);

                lableLineDegree += degreePerStandKeDu;

                speed += valuePerKeDu;
            }
            ////重置绘图平面坐标变换
            //g.ResetTransform();
            //g.TranslateTransform(MyWidth / 2 + heightSpan, MyHeight + 10);
            ////绘制指针在speed的情形
            var currenValue = CurrenValue;
            int tureValue = currenValue;
            if (currenValue < minValue)
            {
                tureValue = minValue - 1;
            }
            else
                if (currenValue > maxValue)
                {
                    tureValue = maxValue + 1;
                }

            //g.RotateTransform((float)((tureValue - minValue) * (720 - 2 * startDegree) / (maxValue - minValue) + startDegree));
            ////设置线帽
            //myPen = new Pen(Color.Blue, pointWidth);
            //myPen.EndCap = LineCap.ArrowAnchor;
            ////绘制指针
            //g.DrawLine(myPen, new PointF(0, 0), new PointF((float)0, (float)((-1) * (MyHeight / 1.25))));

            var pointerLine = new Line();
            pointerLine.Stroke = new SolidColorBrush(Colors.Blue);
            pointerLine.StrokeThickness = pointWidth;
            //_pointerLine.X1 = 0;
            //_pointerLine.Y1 = 0;
            //_pointerLine.X2 = 0;
            pointerLine.Y2 = (height - heightSpan) / 1.25d;
            pointerLine.StrokeEndLineCap = PenLineCap.Triangle;
            pointerLine.RenderTransformOrigin = new Point(0.5d, 0d);
            pointerLine.RenderTransform = new CompositeTransform();
            pointerLine.SetValue(Canvas.LeftProperty, centerX);
            pointerLine.SetValue(Canvas.TopProperty, centerY - pointerLine.Y2);

            var arrowFigure = new PathFigure();
            arrowFigure.StartPoint = new Point(centerX, centerY - pointerLine.Y2 - pointWidth);
            arrowFigure.Segments.Add(new LineSegment() { Point = new Point(centerX - pointWidth,centerY- pointerLine.Y2) });
            arrowFigure.Segments.Add(new LineSegment() { Point = new Point(centerX + pointWidth, centerY -pointerLine.Y2) });
            var arrowGeometry = new PathGeometry();
            arrowGeometry.Figures.Add(arrowFigure);

            var arrowPath = new Path();
            arrowPath.Fill = pointerLine.Stroke;
            arrowPath.Stroke = pointerLine.Stroke;
            arrowPath.Data = arrowGeometry;

            _pointCanvas.Children.Clear();
            _pointCanvas.Height = centerY;
            _pointCanvas.Width = width;
            _pointCanvas.Children.Add(arrowPath);
            _pointCanvas.Children.Add(pointerLine);

            PaintPointer();

            _axisOuterEllipse.Fill = new SolidColorBrush(Colors.Black);
            _axisOuterEllipse.SetValue(Canvas.LeftProperty, centerX - 7d);
            _axisOuterEllipse.SetValue(Canvas.TopProperty, centerY - 7d);
            _axisOuterEllipse.SetValue(WidthProperty, 14d);
            _axisOuterEllipse.SetValue(HeightProperty, 14d);

            _axisInnerEllipse.Fill = new SolidColorBrush(Colors.Red);
            _axisInnerEllipse.SetValue(Canvas.LeftProperty, centerX - 5d);
            _axisInnerEllipse.SetValue(Canvas.TopProperty, centerY - 5d);
            _axisInnerEllipse.SetValue(WidthProperty, 10d);
            _axisInnerEllipse.SetValue(HeightProperty, 10d);

            var radian = 7d * Math.PI / 18d;
            var radius = centerY - calibrationTop;
            var offsetX = radius * Math.Sin(radian);
            var offsetY = radius * Math.Cos(radian);
            var arcSegment = new ArcSegment();
            arcSegment.IsLargeArc = false;
            arcSegment.SweepDirection = SweepDirection.Clockwise;
            arcSegment.Point = new Point(centerX + offsetX, centerY - offsetY);
            arcSegment.Size = new Size(radius, radius);
            var figure = new PathFigure();
            figure.StartPoint = new Point(centerX - offsetX, centerY - offsetY);
            figure.Segments.Add(arcSegment);
            var pathGeometry = new PathGeometry();
            pathGeometry.Figures.Add(figure);

            _arcPath.Stroke = new SolidColorBrush(Color.FromArgb(0xff, 0xBC,0x8F,0x8F));
            _arcPath.StrokeThickness = circleWidth;
            _arcPath.Data = pathGeometry;
            //_arcPath.SetValue(Canvas.LeftProperty, centerX - 100d);
            //_arcPath.SetValue(Canvas.TopProperty, centerY);

            //g.ResetTransform();
            //g.TranslateTransform(MyWidth / 2 + heightSpan, MyHeight + 10);
            ////绘制中心点
            //g.FillEllipse(Brushes.Black, -7, -7, 14, 14);
            //g.FillEllipse(Brushes.Red, -5, -5, 10, 10);
            ////绘制外圆
            //myPen = new Pen(Color.RosyBrown, circleWidth);
            //g.DrawArc(myPen, -MyWidth / 2, -MyHeight, MyWidth, 2 * MyHeight, 200, 140);
            ////g.DrawEllipse(myPen, -MyWidth / 2, -MyHeight, MyWidth, 2 * MyHeight);
        }

        private void PaintPointer()
        {
            var startDegree = 290d;
            var minValue = MinValue;
            var maxValue = MaxValue;
            if (minValue >= maxValue)
                return;
            var currenValue = CurrenValue;
            int tureValue = currenValue;
            if (currenValue < minValue)
            {
                tureValue = minValue - 1;
            }
            else
                if (currenValue > maxValue)
                {
                    tureValue = maxValue + 1;
                }

            var angle = (tureValue - minValue) * (720d - 2d * startDegree) / (maxValue - minValue) + startDegree;
            _pointerTransform.Rotation = angle;
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            Paint(availableSize);
            return base.MeasureOverride(availableSize);
        }
    }
}
