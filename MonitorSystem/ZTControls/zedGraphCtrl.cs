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
using System.Collections.Generic;
using System.Windows.Controls.DataVisualization.Charting;
using System.Collections;
using MonitorSystem.GetData;
using System.Collections.ObjectModel;

namespace MonitorSystem.ZTControls
{
    /// <summary>
    /// 58	zedGraphCtrl	2	Text.jpg	组态控件	柱状图
    /// </summary>
    public class zedGraphCtrl : MonitorControl
    {
        Chart _Chart = new Chart();
        public zedGraphCtrl()
        {
            this.Content = _Chart;

            _Chart.Background = new SolidColorBrush(Colors.White);
            _Chart.Width = 100;
            _Chart.Height = 100;

            this.SizeChanged += new SizeChangedEventHandler(zedGraphCtrl_SizeChanged);
        }
        private void zedGraphCtrl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
           this.Width= _Chart.Width = e.NewSize.Width;
           this.Height= _Chart.Height = e.NewSize.Height;
        }
        #region 控件公共属性
        public override event EventHandler Selected;
        public override void DesignMode()
        {
            if (!IsDesignMode)
            {
                AdornerLayer = new Adorner(this);
                AdornerLayer.Selected += OnSelected;
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

        private string[] m_BrowsableProperties = new string[] { "Left", "Top", "Width", "Height", "FontFamily", "FontSize",
            "Translate", "ConnectString","TalbeName","TitleName","XaxisName","YaxisName"};

        public override string[] BrowsableProperties
        {
            get { return m_BrowsableProperties; }
            set { m_BrowsableProperties = value; }
        }

        public override void SetCommonPropertyValue()
        {
            if (ScreenElement != null)
            {
                this.SetValue(Canvas.LeftProperty, (double)ScreenElement.ScreenX);
                this.SetValue(Canvas.TopProperty, (double)ScreenElement.ScreenY);
                Transparent = ScreenElement.Transparent.Value;

                this.Width = _Chart.Width = (double)ScreenElement.Width.Value;
                this.Height = _Chart.Height = (double)ScreenElement.Height.Value;
            }
        }

        public List<t_ElementProperty> GetProperty()
        {
            return ListElementProp;
        }

        public override object GetRootControl()
        {
            return this;
        }

        #endregion        

        #region 属性
        public override void SetPropertyValue()
        {
            foreach (t_ElementProperty pro in ListElementProp)
            {
                string name = pro.PropertyName.ToUpper();
                string value = pro.PropertyValue;
                if (name == "ConnectString".ToUpper())
                {
                    _ConnectString = value;
                }
                else if (name == "TalbeName".ToUpper())
                {
                    _TalbeName = value;
                }
                else if (name == "TitleName".ToUpper())
                {
                    _TitleName = value;
                }
                else if (name == "XaxisName".ToUpper())
                {
                    _XaxisName = value;
                }
                else if (name == "YaxisName".ToUpper())
                {
                    _YaxisName = value;
                }
            }
            LoadData();
        }

        private static readonly DependencyProperty TransparentProperty =
         DependencyProperty.Register("Transparent",
         typeof(int), typeof(zedGraphCtrl), new PropertyMetadata(0));
        private int _Transparent;
        public int Transparent
        {
            get { return _Transparent; }
            set
            {
                _Transparent = value;
                if (value == 1)
                {
                   
                }
                else
                {

                }
                if (ScreenElement != null)
                    ScreenElement.Transparent = value;
            }
        }

     
        private static readonly DependencyProperty ConnectStringProperty =
       DependencyProperty.Register("ConnectString",
       typeof(string), typeof(zedGraphCtrl), new PropertyMetadata(""));

        private string _ConnectString;
        public string ConnectString
        {
            get { return _ConnectString; }
            set
            {
                SetAttrByName("ConnectString", value);
                _ConnectString = value;
                LoadData();
            }
        }

        private static readonly DependencyProperty TableNameProperty =
      DependencyProperty.Register("TalbeName",
      typeof(string), typeof(zedGraphCtrl), new PropertyMetadata(""));

        private string _TalbeName;
        public string TalbeName
        {
            get { return _TalbeName; }
            set
            {
                SetAttrByName("TalbeName", value);
                _TalbeName = value;
                LoadData();
            }
        }

        private static readonly DependencyProperty TitleNameProperty =
       DependencyProperty.Register("TitleName",
       typeof(string), typeof(zedGraphCtrl), new PropertyMetadata(""));

        private string _TitleName;
        public string TitleName
        {
            get { return _TitleName; }
            set
            {
                SetAttrByName("TitleName", value);
                _TitleName = value;
                LoadData();
            }
        }


        private static readonly DependencyProperty XaxisNameProperty =
       DependencyProperty.Register("XaxisName",
       typeof(string), typeof(zedGraphCtrl), new PropertyMetadata(""));

        private string _XaxisName;
        public string XaxisName
        {
            get { return _XaxisName; }
            set
            {
                SetAttrByName("XaxisName", value);
                _XaxisName = value;
                LoadData();
            }
        }


        private static readonly DependencyProperty YaxisNameProperty =
       DependencyProperty.Register("YaxisName",
       typeof(string), typeof(zedGraphCtrl), new PropertyMetadata(""));

        private string _YaxisName;
        public string YaxisName
        {
            get { return _YaxisName; }
            set
            {
                SetAttrByName("YaxisName", value);
                _YaxisName = value;
                LoadData();
            }
        }
        #endregion

        #region 从wcf中加载数据
        /// <summary>
        /// 加载数据
        /// </summary>
        private void LoadData()
        {
            string _TalbeName = "t_Station";
            string _ColumnsName = "StationID as [站点ID],StationName as [站点名称]";


            string strSql = @"select t.StationName,count(*) as Number from t_Device d 
inner join t_Station t on t.stationid=d.stationid group by t.StationName";// string.Format("select {0} from {1}", _ColumnsName, _TalbeName);

            GetData(strSql, "Data");
        }

        ObservableCollection<MyDataService.DataTableInfo> _tables;
        private void GetData(string sql, object userState)
        {
            var ws = WCF.GetService();
            string _ConnectString = "server=.;database=MonitorDemo2;uid=sa;pwd=sa";
            ws.GetDataSetDataCompleted += new EventHandler<MyDataService.GetDataSetDataCompletedEventArgs>(ws_GetDataSetDataCompleted);
            ws.GetDataSetDataAsync(_ConnectString, sql, userState);
        }


        void ws_GetDataSetDataCompleted(object sender, MyDataService.GetDataSetDataCompletedEventArgs e)
        {
            if (e.Error != null)
                return;
            else if (e.ServiceError != null)
                return;
        
            _tables = e.Result.Tables;
            //IEnumerable list = DynamicDataBuilder.GetDataList(e.Result);
            
            var column = new ColumnSeries();
            column.ItemsSource = DynamicDataBuilder.GetDataList(e.Result);
            column.DependentValuePath = "Number";
            column.IndependentValuePath = "StationName";
            column.Title = "啥子名字";

            _Chart.Series.Clear();
            _Chart.Title = "标题";

            _Chart.Series.Add(column);

            //_Chart.LegendItems.Clear();
          
        }
        #endregion
    }
}
