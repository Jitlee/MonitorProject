﻿using System;
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
        //ScrollViewer sv = new ScrollViewer();
        public TableCtrl()
        {
            //sv.Content = theGrid;
            //sv.Width = 300;
            //sv.Height = 200;
            theGrid.Background = new SolidColorBrush(Colors.White);
            this.Content = theGrid;

            LoadData();
            this.SizeChanged += new SizeChangedEventHandler(TableCtrl_SizeChanged);
        }
        private void TableCtrl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            theGrid.Width = e.NewSize.Width;
            theGrid.Height = e.NewSize.Height;
        }
        #region 属性设置
        //SetSingleProperty tpp = new SetSingleProperty();
        //private void PropertyMenuItem_Click(object sender, RoutedEventArgs e)
        //{
        //    tpp = new SetSingleProperty();

        //    tpp.Closing += new EventHandler<System.ComponentModel.CancelEventArgs>(tpp_Closing);
        //    tpp.DeviceID = this.ScreenElement.DeviceID.Value;
        //    tpp.ChanncelID = this.ScreenElement.ChannelNo.Value;
        //    tpp.LevelNo = this.ScreenElement.LevelNo.Value;
        //    tpp.ComputeStr = this.ScreenElement.ComputeStr;
        //    tpp.Init();
        //    tpp.Show();
        //}

        //protected void tpp_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        //{
        //    if (tpp.IsOK)
        //    {
        //        this.ScreenElement.DeviceID = tpp.DeviceID;
        //        this.ScreenElement.ChannelNo = tpp.ChanncelID;
        //        this.ScreenElement.LevelNo = tpp.LevelNo;
        //        this.ScreenElement.ComputeStr = tpp.ComputeStr;
        //    }
        //}

        #endregion

        #region 控件公共属性
        public override event EventHandler Selected;
        public override void DesignMode()
        {
            if (!IsDesignMode)
            {
                AdornerLayer = new Adorner(this);
                AdornerLayer.Selected += OnSelected;

                //var menu = new ContextMenu();
                //var menuItem = new MenuItem() { Header = "属性" };
                //menuItem.Click += PropertyMenuItem_Click;
                //menu.Items.Add(menuItem);
                //AdornerLayer.SetValue(ContextMenuService.ContextMenuProperty, menu);
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

        private string[] m_BrowsableProperties = new string[] { "Left", "Top", "Width", "Height", "FontFamily", "FontSize","Transparent",
            "Translate", "Location", "ConnectString" ,"TalbeName", "ColumnsName", "RefreshRate"};

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

            theGrid.Width = this.Width = (double)ScreenElement.Width;
            theGrid.Height = this.Height = (double)ScreenElement.Height;
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
                //"ConnectString" ,"TableName", "ColumnsName", "RefreshRate"
                if (name == "ConnectString".ToUpper())
                {
                    _ConnectString = value;
                }
                else if (name == "TalbeName".ToUpper())
                {
                    _TalbeName = value;
                }
                else if (name == "ColumnsName".ToUpper())
                {
                    ColumnsName = value;
                }
                else if (name == "RefreshRate".ToUpper())
                {
                    _RefreshRate = int.Parse(value);
                }
            }
            LoadData();
        }
        #endregion

        #region 属性
        private static readonly DependencyProperty TransparentProperty =
         DependencyProperty.Register("Transparent",
         typeof(int), typeof(TableCtrl), new PropertyMetadata(0));
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

        //"ConnectString" ,"TableName", "ColumnsName", "RefreshRate"

        private static readonly DependencyProperty ConnectStringProperty =
        DependencyProperty.Register("ConnectString",
        typeof(string), typeof(TableCtrl), new PropertyMetadata(""));

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
       typeof(string), typeof(TableCtrl), new PropertyMetadata(""));

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

        private static readonly DependencyProperty ColumnsNameProperty =
       DependencyProperty.Register("ColumnsName",
       typeof(string), typeof(TableCtrl), new PropertyMetadata(""));

         private string _ColumnsName;
         public string ColumnsName
        {
            get { return _ColumnsName; }
            set
            {
                string Col=string.Empty;
                if(value != "")
                {
                 string[] strArr = value.Split(';');
                 if (strArr.Length > 0)
                 {
                     foreach (string str in strArr)
                     {
                         if (!string.IsNullOrEmpty(str))
                         {
                             Col = str;
                         }
                         else
                         {
                             Col += "," + str;
                         }
                     }
                 }
                }
                _ColumnsName = Col;
                SetAttrByName("ColumnsName", Col);
                LoadData();
            }
        }

         private static readonly DependencyProperty RefreshRateProperty =
     DependencyProperty.Register("RefreshRate",
     typeof(Int32), typeof(TableCtrl), new PropertyMetadata(30000));

         private Int32 _RefreshRate;
         public int RefreshRate
         {
             get { return _RefreshRate; }
             set
             {
                 _RefreshRate = value;
                 SetAttrByName("RefreshRate", value);
             }
         }

        #endregion

      #region 从wcf中加载数据
         //ObservableCollection<MyDataService.DataTableInfo> _tables;
        //IEnumerable _lookup;

        private void GetData(string sql, object userState)
        {
            var ws = WCF.GetService();

            ws.GetDataSetDataCompleted += new EventHandler<MyDataService.GetDataSetDataCompletedEventArgs>(ws_GetDataSetDataCompleted);
            ws.GetDataSetDataAsync( _ConnectString, sql , userState);
        }


        /// <summary>
        /// 加载数据
        /// </summary>
        private void LoadData()
        {
            if (string.IsNullOrEmpty(_ConnectString))
                return;
            if (string.IsNullOrEmpty(_TalbeName))
                return;
            if (string.IsNullOrEmpty(_ColumnsName))
                return;

            string strSql = string.Format("select top 1000 {0} from {1}", _ColumnsName, _TalbeName);

            GetData(strSql,  "Data");
        }

        void ws_GetDataSetDataCompleted(object sender, MyDataService.GetDataSetDataCompletedEventArgs e)
        {
            if (e.Error != null)
                return;
            else if (e.ServiceError != null)
                return;
            //else
            //{
            // _tables = e.Result.Tables;
            IEnumerable list = DynamicDataBuilder.GetDataList(e.Result);

            theGrid.Columns.Clear();
            theGrid.ItemsSource = DynamicDataBuilder.GetDataList(e.Result);

           
          
            theGrid.HorizontalContentAlignment = HorizontalAlignment.Center;



        }
        #endregion

    }
}
