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

namespace MonitorSystem.GetData
{
    public class GetDataHead
    {
        ObservableCollection<MyDataService.DataTableInfo> _tables;
        IEnumerable _lookup;

        private void GetData(string sql, int pagenumber, int pagesize, object userState)
        {
            var ws = WCF.GetService();
            
            ws.GetDataSetDataCompleted += new EventHandler<MyDataService.GetDataSetDataCompletedEventArgs>(ws_GetDataSetDataCompleted);
            ws.GetDataSetDataAsync(sql, pagenumber, pagesize, userState);
        }
        private void GetData_Click(object sender, RoutedEventArgs e)
        {
            string strSql = string.Empty;
            GetData(strSql, 1, 10, "Data");
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
                    //theGrid.Columns.Clear();
                    //theGrid.ItemsSource = DynamicDataBuilder.GetDataList(e.Result);

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

                                //theGrid.Columns.Add(col);
                            }
                        }
                    }
                    //theGrid.CanUserReorderColumns = false;
                    //theGrid.FrozenColumnCount = 2;
                    //theGrid.HorizontalContentAlignment = HorizontalAlignment.Center;
                }
            }
            //this.Progress.Stop();
        }

        void Update_Click(object sender, RoutedEventArgs e)
        {
            var ws = WCF.GetService();
            ws.UpdateCompleted += new EventHandler<MyDataService.UpdateCompletedEventArgs>(ws_UpdateCompleted);
            //ws.UpdateAsync(DynamicDataBuilder.GetUpdatedDataSet(theGrid.ItemsSource as IEnumerable, _tables));
            //this.Progress.Start();
        }

        void ws_UpdateCompleted(object sender, MyDataService.UpdateCompletedEventArgs e)
        {
            if (e.Error != null)
                System.Windows.Browser.HtmlPage.Window.Alert(e.Error.Message);
            else if (e.ServiceError != null)
                System.Windows.Browser.HtmlPage.Window.Alert(e.ServiceError.Message);
            else
            {
                System.Windows.Browser.HtmlPage.Window.Alert("Data is Saved");
            }
            
        }
    }
}
