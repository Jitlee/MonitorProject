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
using System.ComponentModel;

namespace MonitorSystem.MonitorSystemGlobal
{
    public class temp : UserControl
    {

        private const double PADDING_LEFT = 50.0;
        private const double PADDING_RIGHT = 50.0;
        private const double PADDING_TOP = 10.0;
        private const double PADDING_BOTTOM = 40.0;
        //private const double TITLE_SIZE = 16.0;
        private const double TITLE_SIZE = 0.0;
        private const double MAX_X_AXIS_SCALE = 50.0;
        private const double NORMAL_X_AXIS_SCALE = 10.0;
        private const double NORMAL_Y_AXIS_SCALE = 20.0;
        private const double CALIBRATION_WIDTH = 4.0;
        private const int Y_AXIS_INTERVALS = 5;

        private Canvas _RootLayout = new Canvas();
        private Canvas _Canvas = new Canvas();
        //private Canvas _BackCanvas = new Canvas();
        private Canvas _LegendCanvas = new Canvas();
        private Border _Border = new Border();
        private Button _ClearButton = new Button();

        private Canvas _InfoCanvas = new Canvas();
        private Line _InfoLine = new Line();
        private Border _InfoBorder = new Border();
        private Grid _InfoGrid = new Grid();
        private List<Ellipse> _InfoEllipseList = new List<Ellipse>();
        private List<TextBlock> _InfoDataList = new List<TextBlock>();
        private List<TextBlock> _InfoTimeList = new List<TextBlock>();
        private TextBlock _InfoTime = new TextBlock();

        private double _MaxValue;
        private double _MinValue;
        private double _PlotEreaLeft;
        private double _PlotEreaHeight;
        private double _PlotEreaTop;
        private double _PlotEreaWidth;
        private double _LegendHeight;
        private double _XAxisIntervalScale;
        private double _YAxisIntervalScale;
        private int _XAxisTickCount;
        private int _YAxisTickCount;
        //private double _XAxisDiscountRate;
        private double _YAxisDiscountRate;
        //private double _Current = -1.0;
        private double _Stretch;
        private Size _Size;
        //private Canvas _Canvas;
        //private TextBox _TxtFocus;
        private BackgroundWorker _BackgroundWorker = new BackgroundWorker();
       
        private bool IsShowInfo = false;
        public DateTime Time { get; set; }

        public temp()
        {
            this.IsTabStop = true;
            this.Content = this._RootLayout;
            this._RootLayout.Children.Add(_Canvas);
            _Canvas.Width = 200;
            _Canvas.Height = 200;
            _Canvas.Background = new SolidColorBrush(Colors.Blue);
            _RootLayout.Width = 500;
            _RootLayout.Height = 500;
            _RootLayout.Background = new SolidColorBrush(Colors.Black);

            this._RootLayout.Children.Add(_Border);
            this._RootLayout.Children.Add(_LegendCanvas);
            this._RootLayout.Children.Add(_ClearButton);
            this._RootLayout.Children.Add(_InfoBorder);
            this._RootLayout.Children.Add(_InfoLine);
            this._RootLayout.Children.Add(_InfoCanvas);
            this._InfoBorder.Child = _InfoGrid;
            _Canvas.SetValue(Canvas.ZIndexProperty, 999);
            _ClearButton.SetValue(Canvas.ZIndexProperty, 1000);
            _InfoBorder.SetValue(Canvas.ZIndexProperty, 1000);

            this.MinWidth = 300.0;
            this.MinHeight = 200.0;
            Time = DateTime.Now;
            //_Current = 0.0;
            _Stretch = NORMAL_X_AXIS_SCALE;


            _Border.BorderBrush = new SolidColorBrush(Colors.Red);
            _Border.BorderThickness = new Thickness(1.0);
            _Border.Background = new SolidColorBrush(Colors.Transparent);
            _ClearButton.Content = "清除";
            _ClearButton.Opacity = 0.0;
            //_ClearButton.Click += new RoutedEventHandler(_ClearButton_Click);
            //_ClearButton.MouseEnter += new MouseEventHandler(_ClearButton_MouseEnter);
            //_ClearButton.MouseLeave += new MouseEventHandler(_ClearButton_MouseLeave);
            _InfoLine.Stroke = new SolidColorBrush(Colors.White);
            _InfoLine.StrokeThickness = 1.0;
            _InfoTime.Foreground = new SolidColorBrush(Colors.White);
            _InfoBorder.BorderBrush = new SolidColorBrush(Colors.Red);
            _InfoBorder.BorderThickness = new Thickness(1.0);
            _InfoBorder.Background = new SolidColorBrush(Color.FromArgb(0x4c, 0xff, 0xff, 0xff));
            _InfoGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0.5, GridUnitType.Star) });
            _InfoGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0.5, GridUnitType.Star) });
            _InfoBorder.Visibility = _InfoLine.Visibility = Visibility.Collapsed;
            _InfoTime.SetValue(Grid.ColumnSpanProperty, 2);
            _InfoTime.Margin = new Thickness(5.0);
            _InfoTime.FontSize = 14.0;

            DrawYCalibration();
            DrawXCalibration();
        }

        private void DrawXCalibration()
        {
            double x1 = _PlotEreaLeft + _XAxisIntervalScale;
            double y1 = _PlotEreaTop + _PlotEreaHeight;
            double y2 = y1 + CALIBRATION_WIDTH;
            //for (int i = 0; i < _XAxisTickCount; i++)
            //{
            //    Line line = new Line();
            //    line.Stroke = new SolidColorBrush(Colors.Black);
            //    line.StrokeThickness = 1.0;
            //    line.X1 = line.X2 = x1 + i * _XAxisIntervalScale;
            //    line.Y1 = y1;
            //    line.Y2 = y2;
            //    _Canvas.Children.Add(line);
            //}

            double offset = Math.Round(85.0 / _XAxisIntervalScale);
            x1 = _PlotEreaLeft + _XAxisIntervalScale;
            y1 = _PlotEreaTop + _PlotEreaHeight;
            y2 = y1 + 2.0 * CALIBRATION_WIDTH;
            SolidColorBrush brush = new SolidColorBrush(Color.FromArgb(0xff, 0x19, 0x72, 0xc9));
            SolidColorBrush redBrush = new SolidColorBrush(Colors.Red);
            List<int> yearList = new List<int>();
            List<string> monthList = new List<string>();
            List<string> dateList = new List<string>();
            for (double d = 0; d < _XAxisTickCount; d += offset)
            {
                Line line = new Line();
                line.Stroke = redBrush;
                line.StrokeThickness = 1.0;
                line.X1 = line.X2 = x1 + d * _XAxisIntervalScale;
                line.Y1 = y1;
                line.Y2 = y2;
                _Canvas.Children.Add(line);
                //Line line = new Line();
                //line.StrokeThickness = 0.5;
                //line.StrokeDashArray = new DoubleCollection() { 2.0, 2.0 };
                //line.Stroke = new SolidColorBrush(Colors.LightGray);
                //line.X1 = line.X2 = x1 + d * _XAxisIntervalScale;
                //line.Y1 = y1;
                //line.Y2 = y2;
                //_Canvas.Children.Add(line);

                TextBlock txt = new TextBlock();
                txt.Foreground = brush;
                // txt.Text = times[times.Length - _XAxisTickCount - _Current + i].ToString("HH:mm");
                DateTime dt = Time.AddMinutes((-_XAxisTickCount + d) * 5.0);
                txt.Text = dt.ToString("HH:mm");
                txt.SetValue(Canvas.LeftProperty, x1 + d * _XAxisIntervalScale - txt.ActualWidth / 2.0);
                txt.SetValue(Canvas.TopProperty, y2);
                _Canvas.Children.Add(txt);


                string month = dt.ToString("yyyyMM");
                string date = dt.ToString("yyyyMMdd");
                string text = string.Empty;
                if (!yearList.Contains(dt.Year))
                {
                    yearList.Add(dt.Year);
                    monthList.Add(month);
                    dateList.Add(date);
                    text = dt.ToString("dddd,yyyy年M月d日");
                }
                else if (!monthList.Contains(month))
                {
                    monthList.Add(month);
                    dateList.Add(date);
                    text = dt.ToString("dddd,M月d日");
                }
                else if (!dateList.Contains(date))
                {
                    dateList.Add(date);
                    text = dt.ToString("dddd,d日");
                }
                if (text.Length > 0)
                {
                    TextBlock txtDate = new TextBlock();
                    txtDate.Foreground = brush;
                    txtDate.Text = text;
                    txtDate.SetValue(Canvas.LeftProperty, x1 + d * _XAxisIntervalScale - txtDate.ActualWidth / 2.0);
                    txtDate.SetValue(Canvas.TopProperty, y2 + txt.ActualHeight);
                    _Canvas.Children.Add(txtDate);
                }

            }
        }

        private void DrawYCalibration()
        {
            _YAxisIntervalScale = 1.0;
            double x1, y1;
            SolidColorBrush brush = new SolidColorBrush(Color.FromArgb(0xff, 0x19, 0x72, 0xc9));
            SolidColorBrush redBrush = new SolidColorBrush(Colors.Red);
            if (_YAxisIntervalScale == 1.0)
            {
                double yAxisFstMacScaVal = _MaxValue;

                x1 = _PlotEreaLeft - 2.0 * CALIBRATION_WIDTH;
                double x2 = _PlotEreaWidth + _PlotEreaLeft + 2.0 * CALIBRATION_WIDTH;
                while (yAxisFstMacScaVal >= _MinValue)
                {
                    y1 = _PlotEreaTop + _PlotEreaHeight - (yAxisFstMacScaVal - _MinValue) * _YAxisDiscountRate;

                    // 刻度线
                    Line line = new Line();
                    line.StrokeThickness = 0.5;
                    line.StrokeDashArray = new DoubleCollection() { 2.0, 2.0 };
                    line.Stroke = redBrush;
                    line.X1 = _PlotEreaLeft + 1.0;
                    line.X2 = _PlotEreaLeft + _PlotEreaWidth - 1.0;
                    line.Y1 = line.Y2 = y1;
                    _Canvas.Children.Add(line);

                    TextBlock txtLeft = new TextBlock();
                    txtLeft.Foreground = brush;
                    txtLeft.Text = yAxisFstMacScaVal.ToString();
                    txtLeft.SetValue(Canvas.LeftProperty, x1 - txtLeft.ActualWidth);
                    txtLeft.SetValue(Canvas.TopProperty, y1 - txtLeft.ActualHeight / 2.0);
                    _Canvas.Children.Add(txtLeft);

                 

                    TextBlock txtRight = new TextBlock();
                    txtRight.Foreground = brush;
                    txtRight.Text = yAxisFstMacScaVal.ToString();
                    txtRight.SetValue(Canvas.LeftProperty, _PlotEreaLeft + _PlotEreaWidth + 2.0 * CALIBRATION_WIDTH);
                    txtRight.SetValue(Canvas.TopProperty, y1 - txtLeft.ActualHeight / 2.0);
                    _Canvas.Children.Add(txtRight);

                    yAxisFstMacScaVal--;
                }

            }
            else
            {
                double yAxisFstMacScaVal = Y_AXIS_INTERVALS * _YAxisIntervalScale * Math.Floor(_MaxValue / (_YAxisIntervalScale * Y_AXIS_INTERVALS));
                double yAxisFstMicScaVal = _YAxisIntervalScale * Math.Floor(_MaxValue / _YAxisIntervalScale);

                x1 = _PlotEreaLeft - 2.0 * CALIBRATION_WIDTH;
                double x2 = _PlotEreaWidth + _PlotEreaLeft + 2.0 * CALIBRATION_WIDTH;
                while (yAxisFstMacScaVal >= _MinValue)
                {
                    y1 = _PlotEreaTop + _PlotEreaHeight - (yAxisFstMacScaVal - _MinValue) * _YAxisDiscountRate;

                    // 刻度线
                    Line line = new Line();
                    line.StrokeThickness = 0.5;
                    line.StrokeDashArray = new DoubleCollection() { 2.0, 2.0 };
                    line.Stroke = redBrush;
                    line.X1 = _PlotEreaLeft + 1.0;
                    line.X2 = _PlotEreaLeft + _PlotEreaWidth - 1.0;
                    line.Y1 = line.Y2 = y1;
                    _Canvas.Children.Add(line);

                    TextBlock txtLeft = new TextBlock();
                    txtLeft.Foreground = brush;
                    txtLeft.Text = yAxisFstMacScaVal.ToString();
                    txtLeft.SetValue(Canvas.LeftProperty, x1 - txtLeft.ActualWidth);
                    txtLeft.SetValue(Canvas.TopProperty, y1 - txtLeft.ActualHeight / 2.0);
                    _Canvas.Children.Add(txtLeft);

                   

                    TextBlock txtRight = new TextBlock();
                    txtRight.Foreground = brush;
                    txtRight.Text = yAxisFstMacScaVal.ToString();
                    txtRight.SetValue(Canvas.LeftProperty, _PlotEreaLeft + _PlotEreaWidth + 2.0 * CALIBRATION_WIDTH);
                    txtRight.SetValue(Canvas.TopProperty, y1 - txtLeft.ActualHeight / 2.0);
                    _Canvas.Children.Add(txtRight);

                    yAxisFstMacScaVal -= _YAxisIntervalScale * Y_AXIS_INTERVALS;
                }
            }
        }
    }
}
