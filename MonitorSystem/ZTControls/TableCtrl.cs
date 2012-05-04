using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Windows.Markup;
using System.Collections;
using System.Collections.ObjectModel;

using MonitorSystem.MonitorSystemGlobal;
using MonitorSystem.Web.Moldes;

using MonitorSystem.Web.Servers;
using MonitorSystem.GetData;

namespace MonitorSystem.ZTControls
{
    /// <summary>
    /// 55	TableCtrl	2	MyButton.jpg	组态控件	表格
    /// </summary>
    public class TableCtrl : MonitorControl
    {
        DataGrid theGrid = new DataGrid();
        public TableCtrl()
        {
            Grid _dataGrid = new Grid();
            
            
            this.Content = theGrid;
            LoadData();
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

        #region 控件公共属性
        public override event EventHandler Selected;
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
            "Translate", "Location", "RealtimeValue", "YmaxValue", "YminValue", "MyScale", "Yupper", "Ylower", "GridHeight" };

        public override string[] BrowsableProperties
        {
            get { return m_BrowsableProperties; }
            set { m_BrowsableProperties = value; }
        }

        public override void SetCommonPropertyValue()
        {
            this.SetValue(Canvas.LeftProperty, (double)ScreenElement.ScreenX);
            this.SetValue(Canvas.TopProperty, (double)ScreenElement.ScreenY);
            Transparent = ScreenElement.Transparent.Value;
        }

        public List<t_ElementProperty> GetProperty()
        {
            return ListElementProp;
        }

        public override object GetRootControl()
        {
            return this;
        }

        public override void SetPropertyValue()
        {
            foreach (t_ElementProperty pro in ListElementProp)
            {
                string name = pro.PropertyName.ToUpper();
                string value = pro.PropertyValue;
            }

        }
        #endregion

        #region 属性
        private static readonly DependencyProperty TransparentProperty =
         DependencyProperty.Register("Transparent",
         typeof(int), typeof(RealTimeCurve), new PropertyMetadata(0));
        private int _Transparent;
        public int Transparent
        {
            get { return _Transparent; }
            set
            {
                _Transparent = value;
                if (value == 1)
                {
                    //_mTxt.Background = new SolidColorBrush();
                    //_mTxt.BorderBrush = new SolidColorBrush();
                }
                else
                {
                    //_mTxt.Background = new SolidColorBrush(Colors.White);

                }
                if (ScreenElement != null)
                    ScreenElement.Transparent = value;
            }
        }
        #endregion

        ObservableCollection<MyDataService.DataTableInfo> _tables;
        IEnumerable _lookup;

        private void GetData(string sql, int pagenumber, int pagesize, object userState)
        {
            var ws = WCF.GetService();

            ws.GetDataSetDataCompleted += new EventHandler<MyDataService.GetDataSetDataCompletedEventArgs>(ws_GetDataSetDataCompleted);
            ws.GetDataSetDataAsync(sql, pagenumber, pagesize, userState);
        }

        #region 从wcf中加载数据
        /// <summary>
        /// 加载数据
        /// </summary>
        private void LoadData()
        {
            string strSql = "SELECT * from t_Screen";
            GetData(strSql, 1, 50, "Data");
        }

        void ws_GetDataSetDataCompleted(object sender, MyDataService.GetDataSetDataCompletedEventArgs e)
        {
            if (e.Error != null)
                System.Windows.Browser.HtmlPage.Window.Alert(e.Error.Message);
            else if (e.ServiceError != null)
                System.Windows.Browser.HtmlPage.Window.Alert(e.ServiceError.Message);
            else
            {
                _tables = e.Result.Tables;
                IEnumerable list = DynamicDataBuilder.GetDataList(e.Result);
                if (e.UserState as string == "Lookup")
                    _lookup = list;
                else
                {
                    theGrid.Columns.Clear();
                    theGrid.ItemsSource = DynamicDataBuilder.GetDataList(e.Result);

                    if (e.Result.Tables.Count > 0)
                    {
                        foreach (MyDataService.DataColumnInfo column in e.Result.Tables[0].Columns)
                        {
                            if (column.DisplayIndex != -1)
                            {
                                DataGridColumn col;
                                DataTemplate dt;
                                if (column.DataTypeName == typeof(bool).FullName)
                                {
                                    DataGridCheckBoxColumn checkBoxColumn = new DataGridCheckBoxColumn();
                                    //checkBoxColumn.Binding = new Binding(column.ColumnName);
                                    col = checkBoxColumn;
                                }
                                else if (column.DataTypeName == typeof(DateTime).FullName)
                                {
                                    DataGridTemplateColumn templateColumn = new DataGridTemplateColumn();
                                    string temp = TemplateManager.DataTemplates["DateTimeCellTemplate"];
                                    temp = temp.Replace("@HorizontalAlignment@", HorizontalAlignment.Left.ToString());
                                    temp = temp.Replace("@Text@", column.ColumnName);
                                    temp = temp.Replace("@DateTimeFormat@", "MM/dd/yyyy");

                                    dt = XamlReader.Load(temp) as DataTemplate;
                                    templateColumn.CellTemplate = dt;

                                    DataTemplate t = new DataTemplate();

                                    temp = TemplateManager.DataTemplates["DateTimeCellEditingTemplate"];
                                    temp = temp.Replace("@HorizontalAlignment@", HorizontalAlignment.Left.ToString());
                                    temp = temp.Replace("@SelectedDate@", column.ColumnName);

                                    dt = XamlReader.Load(temp) as DataTemplate;

                                    templateColumn.CellEditingTemplate = dt;
                                    col = templateColumn;

                                }
                                else
                                {
                                    DataGridTextColumn textColumn = new DataGridTextColumn();
                                    textColumn.Binding = new Binding(column.ColumnName);
                                    textColumn.Binding.ValidatesOnExceptions = true;
                                    col = textColumn;
                                }

                                col.IsReadOnly = column.IsReadOnly;


                                col.Header = column.ColumnTitle;
                                col.SortMemberPath = column.ColumnName;
                            }
                        }
                    }
                    theGrid.CanUserReorderColumns = false;
                    theGrid.FrozenColumnCount = 2;
                    theGrid.HorizontalContentAlignment = HorizontalAlignment.Center;
                }
            }
            
        }
        #endregion

    }
}
