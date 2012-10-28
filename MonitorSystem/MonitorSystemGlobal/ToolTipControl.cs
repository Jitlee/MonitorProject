using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using MonitorSystem.Web.Moldes;
using System.ComponentModel;

namespace MonitorSystem.MonitorSystemGlobal
{
    public partial class ToolTipControl : MonitorControl
    {
        const double POINT_HEIGHT = 12d;
        const double POINT_WIDTH = 16d;

        private Grid _layoutRoot = new Grid();
        private Path _borderPath = new Path();
        private PathGeometry _borderPathGeometry = new PathGeometry();
        private PathFigure _borderPathFigure = new PathFigure();
        public readonly Canvas ToolTipCanvas = new Canvas();
        private readonly Canvas _borderCanvas = new Canvas();

        public PointPlace _pointPlace;

        public MonitorControl Target { get; private set; }

        #region 属性

        //private static readonly DependencyProperty PointPlaceProperty =
        //   DependencyProperty.Register("PointPlace",
        //   typeof(PointPlace), typeof(ToolTipControl), new PropertyMetadata(PointPlacePropertyChanged));

        //public PointPlace PointPlace
        //{
        //    get { return (PointPlace)GetValue(PointPlaceProperty); }
        //    set { SetValue(PointPlaceProperty, value); }
        //}

        //private static void PointPlacePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    var element = d as ToolTipControl;
        //    if (null != element)
        //    {
        //        element.OnPointPlaceChanged();
        //    }
        //}

        //private void OnPointPlaceChanged()
        //{
        //    PaintBorder();
        //}

        public PointPlace PointPlace
        {
            get { return _pointPlace; }
            set { _pointPlace = value; PaintBorder(); }
        }

        #region 是否打开

        private static readonly DependencyProperty IsOpenProperty =
           DependencyProperty.Register("IsOpen",
           typeof(bool), typeof(ToolTipControl), new PropertyMetadata(false, IsOpenPropertyChanged));

        public bool IsOpen
        {
            get { return (bool)GetValue(IsOpenProperty); }
            set { SetValue(IsOpenProperty, value); SetAttrByName("IsOpen", value.ToString()); }
        }

        private static void IsOpenPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = d as ToolTipControl;
            if (null != element)
            {
                element.OnIsOpenChanged((bool)e.OldValue, (bool)e.NewValue);
            }
        }

        private void OnIsOpenChanged(bool oldValue, bool newValue)
        {
            this.Visibility = IsOpen ? Visibility.Visible : Visibility.Collapsed;
            if (null != AdornerLayer)
            {
                AdornerLayer.IsOpen = newValue;
            }
        }

        #endregion

        #region 填充颜色

        private static readonly DependencyProperty FillProperty =
           DependencyProperty.Register("Fill",
           typeof(Color), typeof(ToolTipControl), new PropertyMetadata(Colors.White, FillPropertyChanged));

        [DefaultValue(""), Description("填充颜色"), Category("杂项")]
        public Color Fill
        {
            get { return (Color)GetValue(FillProperty); }
            set { SetValue(FillProperty, value); SetAttrByName("Fill", value.ToString()); }
        }

        private static void FillPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = d as ToolTipControl;
            if (null != element)
            {
                element.OnFillChanged((Color)e.OldValue, (Color)e.NewValue);
            }
        }

        private void OnFillChanged(Color oldValue, Color newValue)
        {
            this._borderPath.Fill = new SolidColorBrush(newValue);
        }

        #endregion

        #region 边线颜色

        private static readonly DependencyProperty StrokeProperty =
           DependencyProperty.Register("Stroke",
           typeof(Color), typeof(ToolTipControl), new PropertyMetadata(Colors.Black, StrokePropertyChanged));


        [DefaultValue(""), Description("边线颜色"), Category("杂项")]
        public Color Stroke
        {
            get { return (Color)GetValue(StrokeProperty); }
            set { SetValue(StrokeProperty, value); SetAttrByName("Stroke", value.ToString()); }
        }

        private static void StrokePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = d as ToolTipControl;
            if (null != element)
            {
                element.OnStrokeChanged((Color)e.OldValue, (Color)e.NewValue);
            }
        }

        private void OnStrokeChanged(Color oldValue, Color newValue)
        {
            this._borderPath.Stroke = new SolidColorBrush(newValue);
        }

        #endregion

        #region 边线粗细

        private static readonly DependencyProperty StrokeThicknessProperty =
           DependencyProperty.Register("StrokeThickness",
           typeof(double), typeof(ToolTipControl), new PropertyMetadata(1d, StrokeThicknessPropertyChanged));

        [DefaultValue(""), Description("边线粗细"), Category("杂项")]
        public double StrokeThickness
        {
            get { return (double)GetValue(StrokeThicknessProperty); }
            set { SetValue(StrokeThicknessProperty, value); SetAttrByName("StrokeThickness", value.ToString()); }
        }

        private static void StrokeThicknessPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = d as ToolTipControl;
            if (null != element)
            {
                element.OnStrokeThicknessChanged((double)e.OldValue, (double)e.NewValue);
            }
        }

        private void OnStrokeThicknessChanged(double oldValue, double newValue)
        {
            this._borderPath.StrokeThickness = newValue;
            PaintBorder();
        }

        #endregion

        #region 圆角度

        private static readonly DependencyProperty CornerRadiusProperty =
           DependencyProperty.Register("CornerRadius",
           typeof(double), typeof(ToolTipControl), new PropertyMetadata(10d, CornerRadiusPropertyChanged));

        [DefaultValue(""), Description("圆角度"), Category("杂项")]
        public double CornerRadius
        {
            get { return (double)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); SetAttrByName("CornerRadius", value.ToString()); }
        }

        private static void CornerRadiusPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = d as ToolTipControl;
            if (null != element)
            {
                element.OnCornerRadiusChanged();
            }
        }

        private void OnCornerRadiusChanged()
        {
            PaintBorder();
        }

        #endregion

        #region 圆角度

        private static readonly DependencyProperty TransparentProperty =
           DependencyProperty.Register("Transparent",
           typeof(double), typeof(ToolTipControl), new PropertyMetadata(100d, TransparentPropertyChanged));

        [DefaultValue(""), Description("透明度(0~100)"), Category("杂项")]
        public double Transparent
        {
            get { return (double)GetValue(TransparentProperty); }
            set { SetValue(TransparentProperty, value); SetAttrByName("Transparent", value.ToString()); }
        }

        private static void TransparentPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = d as ToolTipControl;
            if (null != element)
            {
                element.OnTransparentChanged((double)e.OldValue, (double)e.NewValue);
            }
        }

        private void OnTransparentChanged(double oldValue, double newValue)
        {
            this.Translate = newValue;
        }

        #endregion

        #endregion

        public ToolTipControl(MonitorControl target)
        {
            Target = target;
            _borderPathFigure.IsClosed = true;
            _borderPathGeometry.Figures.Add(_borderPathFigure);
            _borderPath.IsHitTestVisible = false;
            _borderPath.Data = _borderPathGeometry;
            _borderPath.Fill = new SolidColorBrush(Fill);
            _borderPath.Stroke = new SolidColorBrush(Stroke);
            _borderPath.StrokeThickness = StrokeThickness;
            _borderCanvas.Children.Add(_borderPath);
            _layoutRoot.Children.Add(_borderCanvas);
            _layoutRoot.Children.Add(ToolTipCanvas);
            Content = _layoutRoot;
            this.ToolTipCanvas.SizeChanged += ToolTipCanvas_SizeChanged;
            this.Selected += ToolTipControl_Selected;
            base.IsToolTip = true;
        }

        private void ToolTipControl_Selected(object sender, EventArgs e)
        {
            PropertyMain.Instance.ControlPropertyGrid.SelectedObject = null;
            PropertyMain.Instance.ControlPropertyGrid.BrowsableProperties = this.BrowsableProperties;
            PropertyMain.Instance.ControlPropertyGrid.SelectedObject = this.GetRootControl(); 
        }

        private void ToolTipCanvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //ToolTipCanvas.Clip = new RectangleGeometry() { Rect = new Rect(new Point(), e.NewSize) };
            PaintBorder();
        }

        public bool Contains(double left, double top)
        {
            var margin = (Thickness)ToolTipCanvas.GetValue(MarginProperty);
            var x = Canvas.GetLeft(this) + margin.Left;
            var y = Canvas.GetTop(this) + margin.Top;
            var w = this.Width - margin.Left - margin.Right;
            var h = this.Height - margin.Top - margin.Bottom;
            return new Rect(x, y, w, h).Contains(new Point(left, top));
        }

        public Point GetPosition()
        {
            var margin = (Thickness)ToolTipCanvas.GetValue(MarginProperty);
            return new Point(Canvas.GetLeft(this) + margin.Left, Canvas.GetTop(this) + margin.Top);
        }

        public void SetPosition()
        {
            var parent = this.Parent as Canvas;
            if (null != Target && null != parent)
            {
                var targetLeft = Canvas.GetLeft(Target);
                var targetTop = Canvas.GetTop(Target);
                var targetWidth = Target.Width;
                var targetHeight = Target.Height;
                var tipWidth = this.Width;
                var tipHeight = this.Height;
                var parentWidth = parent.ActualWidth;
                var parentHeight = parent.ActualHeight;

                // 先确定纵坐标
                if (tipHeight < targetTop)    // 上
                {
                    this.SetValue(Canvas.TopProperty, targetTop - tipHeight);
                    SetTipLeft(true, targetLeft, tipWidth, targetWidth, parentWidth);
                }
                else if (targetTop + targetHeight + tipHeight < parentHeight)   // 下
                {
                    this.SetValue(Canvas.TopProperty, targetTop + targetHeight);
                    SetTipLeft(false, targetLeft, tipWidth, targetWidth, parentWidth);
                }
                else if (targetLeft + targetWidth + tipWidth < parentWidth) // 右
                {
                    SetTipTop(false, targetTop, tipHeight, targetHeight, parentHeight);
                    this.SetValue(Canvas.LeftProperty, targetLeft + targetWidth);
                }
                else if (tipWidth < targetLeft) // 左
                {
                    SetTipTop(true, targetTop, tipHeight, targetHeight, parentHeight);
                    this.SetValue(Canvas.LeftProperty, targetLeft - tipWidth);
                }
                else
                {
                    this.SetValue(Canvas.TopProperty, targetTop - tipHeight);
                    SetTipLeft(true, targetLeft, tipWidth, targetWidth, parentWidth);
                }

                if (IsDesignMode && null != this.AdornerLayer)
                {
                    var x = Canvas.GetLeft(this);
                    var y = Canvas.GetTop(this);
                    this.AdornerLayer.SynchroHost(x, y);
                }
            }
        }

        private void SetTipLeft(bool isTop, double targetLeft, double tipWidth, double targetWidth, double parentWidth)
        {
            if (targetLeft + targetWidth / 2d - tipWidth / 2d < 0d)
            {
                this.SetValue(Canvas.LeftProperty, targetLeft + targetWidth);
                this.PointPlace = isTop ? PointPlace.LeftBottom : PointPlace.TopLeft;
            }
            else if (targetLeft + targetWidth / 2d + tipWidth > parentWidth)
            {
                this.SetValue(Canvas.LeftProperty, targetLeft - tipWidth);
                this.PointPlace = isTop ? PointPlace.BottomRight : PointPlace.RightTop;
            }
            else
            {
                this.SetValue(Canvas.LeftProperty, targetLeft + targetWidth / 2d - tipWidth / 2d);
                this.PointPlace = isTop ? PointPlace.BottomMiddle : PointPlace.TopMiddle;
            }
        }

        private void SetTipTop(bool isLeft, double targetTop, double tipHeight, double targetHeight, double parentHeight)
        {
            if (targetTop + targetHeight / 2d - tipHeight / 2d < 0d)
            {
                this.SetValue(Canvas.TopProperty, targetTop + targetHeight);
                this.PointPlace = isLeft ? PointPlace.RightTop : PointPlace.TopLeft;
            }
            else if (targetTop + targetHeight / 2d + tipHeight / 2d > parentHeight)
            {
                this.SetValue(Canvas.TopProperty, targetTop - tipHeight);
                this.PointPlace = isLeft ? PointPlace.BottomRight : PointPlace.LeftBottom;
            }
            else
            {
                this.SetValue(Canvas.TopProperty, targetTop + targetHeight / 2d - tipHeight / 2d);
                this.PointPlace = isLeft ? PointPlace.RightMiddle : PointPlace.LeftMiddle;
            }
        }

        private void PaintBorder()
        {
            _borderPathFigure.Segments.Clear();
            var pointPlace = PointPlace;
            var cornerRadius = CornerRadius;
            var width = this.Width;
            var height = this.Height;
            var size = new Size(cornerRadius, cornerRadius);
            switch (pointPlace)
            {
                case MonitorSystemGlobal.PointPlace.TopLeft:
                    _borderPathFigure.StartPoint = new Point();
                    _borderPathFigure.Segments.Add(new LineSegment() { Point = new Point(POINT_WIDTH * 2d / 3d + POINT_HEIGHT, POINT_HEIGHT * 0.75d) });
                    _borderPathFigure.Segments.Add(new LineSegment() { Point = new Point(width - cornerRadius, POINT_HEIGHT * 0.75d) });
                    _borderPathFigure.Segments.Add(new ArcSegment() { Point = new Point(width, POINT_HEIGHT * 0.75d + cornerRadius), Size = size, SweepDirection = SweepDirection.Clockwise });
                    _borderPathFigure.Segments.Add(new LineSegment() { Point = new Point(width, height - cornerRadius) });
                    _borderPathFigure.Segments.Add(new ArcSegment() { Point = new Point(width - cornerRadius, height), Size = size, SweepDirection = SweepDirection.Clockwise });
                    _borderPathFigure.Segments.Add(new LineSegment() { Point = new Point(POINT_WIDTH / 3d + cornerRadius, height) });
                    _borderPathFigure.Segments.Add(new ArcSegment() { Point = new Point(POINT_WIDTH / 3d, height - cornerRadius), Size = size, SweepDirection = SweepDirection.Clockwise });
                    _borderPathFigure.Segments.Add(new LineSegment() { Point = new Point(POINT_WIDTH / 3d, POINT_HEIGHT * 1.25d) });
                    ToolTipCanvas.Clip = new RectangleGeometry() { RadiusX = cornerRadius, RadiusY = cornerRadius, Rect = new Rect(0, 0, width - POINT_WIDTH / 3d, height - POINT_HEIGHT * 0.75d) };
                    ToolTipCanvas.Margin = new Thickness(POINT_WIDTH / 3d, POINT_HEIGHT * 0.75d, 0d, 0d);
                    break;
                case MonitorSystemGlobal.PointPlace.TopMiddle:
                    _borderPathFigure.StartPoint = new Point(cornerRadius, POINT_HEIGHT);
                    _borderPathFigure.Segments.Add(new LineSegment() { Point = new Point((width - POINT_WIDTH) / 2d, POINT_HEIGHT) });
                    _borderPathFigure.Segments.Add(new LineSegment() { Point = new Point(width / 2d, 0d) });
                    _borderPathFigure.Segments.Add(new LineSegment() { Point = new Point((width + POINT_WIDTH) / 2d, POINT_HEIGHT) });
                    _borderPathFigure.Segments.Add(new LineSegment() { Point = new Point(width - cornerRadius, POINT_HEIGHT) });
                    _borderPathFigure.Segments.Add(new ArcSegment() { Point = new Point(width, POINT_HEIGHT + cornerRadius), Size = size, SweepDirection = SweepDirection.Clockwise });
                    _borderPathFigure.Segments.Add(new LineSegment() { Point = new Point(width, height - cornerRadius) });
                    _borderPathFigure.Segments.Add(new ArcSegment() { Point = new Point(width - cornerRadius, height), Size = size, SweepDirection = SweepDirection.Clockwise });
                    _borderPathFigure.Segments.Add(new LineSegment() { Point = new Point(cornerRadius, height) });
                    _borderPathFigure.Segments.Add(new ArcSegment() { Point = new Point(0d, height - cornerRadius), Size = size, SweepDirection = SweepDirection.Clockwise });
                    _borderPathFigure.Segments.Add(new LineSegment() { Point = new Point(0d, cornerRadius + POINT_HEIGHT) });
                    _borderPathFigure.Segments.Add(new ArcSegment() { Point = new Point(cornerRadius, POINT_HEIGHT), Size = size, SweepDirection = SweepDirection.Clockwise });
                    ToolTipCanvas.Clip = new RectangleGeometry() { RadiusX = cornerRadius, RadiusY = cornerRadius, Rect = new Rect(0d, 0d, width, height - POINT_HEIGHT) };
                    ToolTipCanvas.Margin = new Thickness(0, POINT_HEIGHT, 0d, 0d);
                    break;
                case MonitorSystemGlobal.PointPlace.RightTop:
                    _borderPathFigure.StartPoint = new Point(cornerRadius, POINT_HEIGHT * 0.75d);
                    _borderPathFigure.Segments.Add(new LineSegment() { Point = new Point(width - POINT_WIDTH * 2d / 3d - POINT_HEIGHT, POINT_HEIGHT * 0.75d) });
                    _borderPathFigure.Segments.Add(new LineSegment() { Point = new Point(width, 0d) });
                    //BorderPathFigure.Segments.Add(new ArcSegment() { Point = new Point(width - POINT_WIDTH / 3d, POINT_HEIGHT * 0.75 + cornerRadius), Size = size, SweepDirection = SweepDirection.Clockwise });
                    _borderPathFigure.Segments.Add(new LineSegment() { Point = new Point(width - POINT_WIDTH / 3d, POINT_HEIGHT * 1.25d) });
                    _borderPathFigure.Segments.Add(new LineSegment() { Point = new Point(width - POINT_WIDTH / 3d, height - cornerRadius) });
                    _borderPathFigure.Segments.Add(new ArcSegment() { Point = new Point(width - cornerRadius - POINT_WIDTH / 3d, height), Size = size, SweepDirection = SweepDirection.Clockwise });
                    _borderPathFigure.Segments.Add(new LineSegment() { Point = new Point(cornerRadius, height) });
                    _borderPathFigure.Segments.Add(new ArcSegment() { Point = new Point(0d, height - cornerRadius), Size = size, SweepDirection = SweepDirection.Clockwise });
                    _borderPathFigure.Segments.Add(new LineSegment() { Point = new Point(0d, cornerRadius + POINT_HEIGHT * 0.75d) });
                    _borderPathFigure.Segments.Add(new ArcSegment() { Point = new Point(cornerRadius, POINT_HEIGHT * 0.75d), Size = size, SweepDirection = SweepDirection.Clockwise });
                    ToolTipCanvas.Clip = new RectangleGeometry() { RadiusX = cornerRadius, RadiusY = cornerRadius, Rect = new Rect(0d, 0d, width - POINT_WIDTH / 3d, height - POINT_HEIGHT * 0.75d) };
                    ToolTipCanvas.Margin = new Thickness(0d, POINT_HEIGHT * 0.75d, 0d, 0d);
                    break;
                case MonitorSystemGlobal.PointPlace.RightMiddle:
                    _borderPathFigure.StartPoint = new Point(cornerRadius, 0d);
                    _borderPathFigure.Segments.Add(new LineSegment() { Point = new Point(width - POINT_HEIGHT - cornerRadius, 0d) });
                    _borderPathFigure.Segments.Add(new ArcSegment() { Point = new Point(width - POINT_HEIGHT, cornerRadius), Size = size, SweepDirection = SweepDirection.Clockwise });
                    _borderPathFigure.Segments.Add(new LineSegment() { Point = new Point(width - POINT_HEIGHT, (height - POINT_WIDTH) / 2d) });
                    _borderPathFigure.Segments.Add(new LineSegment() { Point = new Point(width, height / 2d) });
                    _borderPathFigure.Segments.Add(new LineSegment() { Point = new Point(width - POINT_HEIGHT, (height + POINT_WIDTH) / 2d) });
                    _borderPathFigure.Segments.Add(new LineSegment() { Point = new Point(width - POINT_HEIGHT, height - cornerRadius) });
                    _borderPathFigure.Segments.Add(new ArcSegment() { Point = new Point(width - cornerRadius - POINT_HEIGHT, height), Size = size, SweepDirection = SweepDirection.Clockwise });
                    _borderPathFigure.Segments.Add(new LineSegment() { Point = new Point(cornerRadius, height) });
                    _borderPathFigure.Segments.Add(new ArcSegment() { Point = new Point(0d, height - cornerRadius), Size = size, SweepDirection = SweepDirection.Clockwise });
                    _borderPathFigure.Segments.Add(new LineSegment() { Point = new Point(0d, cornerRadius) });
                    _borderPathFigure.Segments.Add(new ArcSegment() { Point = new Point(cornerRadius, 0), Size = size, SweepDirection = SweepDirection.Clockwise });
                    ToolTipCanvas.Clip = new RectangleGeometry() { RadiusX = cornerRadius, RadiusY = cornerRadius, Rect = new Rect(0d, 0d, width - POINT_HEIGHT, height) };
                    ToolTipCanvas.Margin = new Thickness(0d, 0d, POINT_HEIGHT, 0d);
                    break;
                case MonitorSystemGlobal.PointPlace.BottomRight:
                    _borderPathFigure.StartPoint = new Point(cornerRadius, 0d);
                    _borderPathFigure.Segments.Add(new LineSegment() { Point = new Point(width - cornerRadius - POINT_WIDTH / 3d, 0d) });
                    _borderPathFigure.Segments.Add(new ArcSegment() { Point = new Point(width - POINT_WIDTH / 3d, cornerRadius), Size = size, SweepDirection = SweepDirection.Clockwise });
                    _borderPathFigure.Segments.Add(new LineSegment() { Point = new Point(width - POINT_WIDTH / 3d, height - POINT_HEIGHT * 1.25d) });
                    _borderPathFigure.Segments.Add(new LineSegment() { Point = new Point(width, height) });
                    _borderPathFigure.Segments.Add(new LineSegment() { Point = new Point(width - POINT_WIDTH * 2d / 3d - POINT_HEIGHT, height - POINT_HEIGHT * 0.75d) });
                    _borderPathFigure.Segments.Add(new LineSegment() { Point = new Point(cornerRadius, height - POINT_HEIGHT * 0.75d) });
                    _borderPathFigure.Segments.Add(new ArcSegment() { Point = new Point(0d, height - cornerRadius - POINT_HEIGHT * 0.75d), Size = size, SweepDirection = SweepDirection.Clockwise });
                    _borderPathFigure.Segments.Add(new LineSegment() { Point = new Point(0d, cornerRadius) });
                    _borderPathFigure.Segments.Add(new ArcSegment() { Point = new Point(cornerRadius, 0), Size = size, SweepDirection = SweepDirection.Clockwise });
                    ToolTipCanvas.Clip = new RectangleGeometry() { RadiusX = cornerRadius, RadiusY = cornerRadius, Rect = new Rect(0d, 0d, width - POINT_WIDTH / 3d, height - POINT_HEIGHT * 0.75d) };
                    ToolTipCanvas.Margin = new Thickness(0d, 0d, 0d, 0d);
                    break;
                case MonitorSystemGlobal.PointPlace.BottomMiddle:
                    _borderPathFigure.StartPoint = new Point(cornerRadius, 0d);
                    _borderPathFigure.Segments.Add(new LineSegment() { Point = new Point(width - cornerRadius, 0d) });
                    _borderPathFigure.Segments.Add(new ArcSegment() { Point = new Point(width, cornerRadius), Size = size, SweepDirection = SweepDirection.Clockwise });
                    _borderPathFigure.Segments.Add(new LineSegment() { Point = new Point(width, height - cornerRadius - POINT_HEIGHT) });
                    _borderPathFigure.Segments.Add(new ArcSegment() { Point = new Point(width - cornerRadius, height - POINT_HEIGHT), Size = size, SweepDirection = SweepDirection.Clockwise });
                    _borderPathFigure.Segments.Add(new LineSegment() { Point = new Point((width + POINT_WIDTH) / 2d, height - POINT_HEIGHT) });
                    _borderPathFigure.Segments.Add(new LineSegment() { Point = new Point(width / 2d, height) });
                    _borderPathFigure.Segments.Add(new LineSegment() { Point = new Point((width - POINT_WIDTH) / 2d, height - POINT_HEIGHT) });
                    _borderPathFigure.Segments.Add(new LineSegment() { Point = new Point(cornerRadius, height - POINT_HEIGHT) });
                    _borderPathFigure.Segments.Add(new ArcSegment() { Point = new Point(0d, height - cornerRadius - POINT_HEIGHT), Size = size, SweepDirection = SweepDirection.Clockwise });
                    _borderPathFigure.Segments.Add(new LineSegment() { Point = new Point(0d, cornerRadius) });
                    _borderPathFigure.Segments.Add(new ArcSegment() { Point = new Point(cornerRadius, 0), Size = size, SweepDirection = SweepDirection.Clockwise });
                    ToolTipCanvas.Clip = new RectangleGeometry() { RadiusX = cornerRadius, RadiusY = cornerRadius, Rect = new Rect(0d, 0d, width, height - POINT_HEIGHT) };
                    ToolTipCanvas.Margin = new Thickness(0d, 0d, 0d, 0d);
                    break;
                case MonitorSystemGlobal.PointPlace.LeftBottom:
                    _borderPathFigure.StartPoint = new Point(cornerRadius + POINT_WIDTH / 3d, 0d);
                    _borderPathFigure.Segments.Add(new LineSegment() { Point = new Point(width - cornerRadius, 0d) });
                    _borderPathFigure.Segments.Add(new ArcSegment() { Point = new Point(width, cornerRadius), Size = size, SweepDirection = SweepDirection.Clockwise });
                    _borderPathFigure.Segments.Add(new LineSegment() { Point = new Point(width, height - cornerRadius - POINT_HEIGHT * 0.75d) });
                    _borderPathFigure.Segments.Add(new ArcSegment() { Point = new Point(width - cornerRadius, height - POINT_HEIGHT * 0.75d), Size = size, SweepDirection = SweepDirection.Clockwise });
                    _borderPathFigure.Segments.Add(new LineSegment() { Point = new Point(POINT_WIDTH * 2d / 3d + POINT_HEIGHT, height - POINT_HEIGHT * 0.75d) });
                    _borderPathFigure.Segments.Add(new LineSegment() { Point = new Point(0d, height) });
                    _borderPathFigure.Segments.Add(new LineSegment() { Point = new Point(POINT_WIDTH / 3d, height - POINT_HEIGHT * 1.25d) });
                    _borderPathFigure.Segments.Add(new LineSegment() { Point = new Point(POINT_WIDTH / 3d, cornerRadius) });
                    _borderPathFigure.Segments.Add(new ArcSegment() { Point = new Point(cornerRadius + POINT_WIDTH / 3d, 0d), Size = size, SweepDirection = SweepDirection.Clockwise });
                    ToolTipCanvas.Clip = new RectangleGeometry() { RadiusX = cornerRadius, RadiusY = cornerRadius, Rect = new Rect(0, 0, width - POINT_WIDTH / 3d, height - POINT_HEIGHT * 0.75d) };
                    ToolTipCanvas.Margin = new Thickness(POINT_WIDTH / 3d, 0d, 0d, 0d);
                    break;
                case MonitorSystemGlobal.PointPlace.LeftMiddle:
                    _borderPathFigure.StartPoint = new Point(cornerRadius + POINT_HEIGHT, 0d);
                    _borderPathFigure.Segments.Add(new LineSegment() { Point = new Point(width - cornerRadius, 0d) });
                    _borderPathFigure.Segments.Add(new ArcSegment() { Point = new Point(width, cornerRadius), Size = size, SweepDirection = SweepDirection.Clockwise });
                    _borderPathFigure.Segments.Add(new LineSegment() { Point = new Point(width, height - cornerRadius) });
                    _borderPathFigure.Segments.Add(new ArcSegment() { Point = new Point(width - cornerRadius, height), Size = size, SweepDirection = SweepDirection.Clockwise });
                    _borderPathFigure.Segments.Add(new LineSegment() { Point = new Point(cornerRadius + POINT_HEIGHT, height) });
                    _borderPathFigure.Segments.Add(new ArcSegment() { Point = new Point(POINT_HEIGHT, height - cornerRadius), Size = size, SweepDirection = SweepDirection.Clockwise });
                    _borderPathFigure.Segments.Add(new LineSegment() { Point = new Point(POINT_HEIGHT, (height + POINT_WIDTH) / 2d) });
                    _borderPathFigure.Segments.Add(new LineSegment() { Point = new Point(0, height / 2d) });
                    _borderPathFigure.Segments.Add(new LineSegment() { Point = new Point(POINT_HEIGHT, (height - POINT_WIDTH) / 2d) });
                    _borderPathFigure.Segments.Add(new LineSegment() { Point = new Point(POINT_HEIGHT, cornerRadius) });
                    _borderPathFigure.Segments.Add(new ArcSegment() { Point = new Point(cornerRadius + POINT_HEIGHT, 0), Size = size, SweepDirection = SweepDirection.Clockwise });
                    ToolTipCanvas.Clip = new RectangleGeometry() { RadiusX = cornerRadius, RadiusY = cornerRadius, Rect = new Rect(0d, 0d, width - POINT_HEIGHT, height) };
                    ToolTipCanvas.Margin = new Thickness(POINT_HEIGHT, 0d, 0d, 0d);
                    break;
            }
        }

        #region 重载

        //protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        //{
        //    if (IsDesignMode && null != AdornerLayer)
        //    {
        //        AdornerLayer.IsSelected = true;
        //        AdornerLayer.OnSelected();
        //    }
        //    e.Handled = true;
        //    base.OnMouseLeftButtonDown(e);
        //}

        public override void DesignMode()
        {
            if (!IsDesignMode)
            {
                AdornerLayer = new Adorner(this);
                //AdornerLayer.AllowMove = false;
                AdornerLayer.Selected += OnSelected;
                AdornerLayer.AllToolTip = false;
                AdornerLayer.IsOpen = IsOpen;

                //var children = ToolTipCanvas.Children.ToArray();
                //foreach (var child in children)
                //{
                //    var monitor = child as MonitorControl;
                //    if (null != monitor)
                //    {
                //        monitor.DesignMode();
                //        monitor.AllowToolTip = false;
                //        if (null != monitor.AdornerLayer)
                //        {
                //            monitor.AdornerLayer.AllToolTip = false;
                //            monitor.AdornerLayer.SynchroHost();
                //        }
                //    }
                //}
            }
        }

        public override void UnDesignMode()
        {
            if (IsDesignMode)
            {
                AdornerLayer.Selected -= OnSelected;
                AdornerLayer.Dispose();
                AdornerLayer = null;

                var children = ToolTipCanvas.Children.ToArray();
                foreach (var child in children)
                {
                    var monitor = child as MonitorControl;
                    if (null != monitor && monitor.IsDesignMode)
                    {
                        monitor.UnDesignMode();
                    }
                }
            }
        }

        private void OnSelected(object sender, EventArgs e)
        {
            if (null != Selected)
            {
                Selected(this, RoutedEventArgs.Empty);
                //foreach (var child in ToolTipCanvas.Children)
                //{
                //    if (child is MonitorControl)
                //    {
                //        (child as MonitorControl).DesignMode();
                //    }
                //}
            }
        }

        public override object GetRootControl()
        {
            return this;
        }

        public override event EventHandler Selected;
		
		public override event EventHandler Unselected;

		private void OnUnselected(object sender, EventArgs e)
		{
			if(null != Unselected)
			{
				Unselected(this, RoutedEventArgs.Empty);
			}
		}


        public override void SetPropertyValue()
        {
            foreach (t_ElementProperty pro in ListElementProp)
            {
                string name = pro.PropertyName.ToUpper();
                string value = pro.PropertyValue;

                if (name == "Fill".ToUpper())
                {
                    this._borderPath.Fill = new SolidColorBrush(Common.StringToColor(value));
                }
                else if (name == "Stroke".ToUpper())
                {
                    this._borderPath.Stroke = new SolidColorBrush(Common.StringToColor(value));
                }
                else if (name == "StrokeThickness".ToUpper())
                {
                    this._borderPath.StrokeThickness = Convert.ToDouble(value);
                }
                //else if (name == "CornerRadius".ToUpper())
                //{

                //}
                PaintBorder();
            }
        }

        public override void SetCommonPropertyValue()
        {
            //this.SetValue(Canvas.LeftProperty, (double)ScreenElement.ScreenX);
            //this.SetValue(Canvas.TopProperty, (double)ScreenElement.ScreenY);
            Transparent = ScreenElement.Transparent.HasValue ? ScreenElement.Transparent.Value : 100d;
            this.Width = (double)ScreenElement.Width;
            this.Height = (double)ScreenElement.Height;
        }

        private string[] m_BrowsableProperties = new string[] { "Width", "Height", "Fill", "Stroke", "StrokeThickness", "Transparent", "CornerRadius" };
        public override string[] BrowsableProperties
        {
            get
            {
                return m_BrowsableProperties;
            }
            set
            {
                m_BrowsableProperties = value;
            }
        }

        #endregion
    }

    public enum PointPlace
    {
        TopLeft,
        TopHalfLeft,
        TopMiddle,
        TopHalfRight,
        RightTop,
        RightHalfTop,
        RightMiddle,
        RightHalfBottom,
        BottomRight,
        BottomHalfRight,
        BottomMiddle,
        BottomHalfLeft,
        LeftBottom,
        LeftHalfBottom,
        LeftMiddle,
        LeftHalfTop
    }
}
