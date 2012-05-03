﻿using System;
using System.Collections;
using System.Reflection;
using System.Reflection.Emit;
using System.Xml;
using System.Collections.ObjectModel;
using System.Xml.Linq;
using System.Linq;

namespace MonitorSystem.GetData
{
    public class DynamicDataBuilder
    {
        private static System.Type BuildDataObjectType(ObservableCollection<MyDataService.DataColumnInfo> Columns, string DataObjectName)
        {
            AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName("AprimoDynamicData"), AssemblyBuilderAccess.Run);
            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("DataModule");

            TypeBuilder tb = moduleBuilder.DefineType(DataObjectName,
                                                    TypeAttributes.Public |
                                                    TypeAttributes.Class,
                                                    typeof(DataObject));

            ConstructorBuilder constructor = tb.DefineDefaultConstructor(MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName);
            foreach (var col in Columns)
            {
                string propertyName = col.ColumnName.Replace(' ', '_');
                Type dataType = System.Type.GetType(col.DataTypeName, false, true);
                if (dataType != null)
                {
                    FieldBuilder fb = tb.DefineField("_" + propertyName, dataType, FieldAttributes.Private);
                    PropertyBuilder pb = tb.DefineProperty(propertyName, PropertyAttributes.HasDefault, dataType, null);
                    MethodBuilder getMethod = tb.DefineMethod("get_" + propertyName,
                                                                MethodAttributes.Public |
                                                                MethodAttributes.HideBySig |
                                                                MethodAttributes.SpecialName,
                                                                dataType,
                                                                Type.EmptyTypes);

                    ILGenerator ilgen = getMethod.GetILGenerator();
                    //Emit Get property, return _prop
                    ilgen.Emit(OpCodes.Ldarg_0);
                    ilgen.Emit(OpCodes.Ldfld, fb);
                    ilgen.Emit(OpCodes.Ret);
                    pb.SetGetMethod(getMethod);
                    MethodBuilder setMethod = tb.DefineMethod("set_" + propertyName,
                    MethodAttributes.Public |
                    MethodAttributes.HideBySig |
                    MethodAttributes.SpecialName,
                    null,
                    new Type[] { dataType });
                    ilgen = setMethod.GetILGenerator();
                    LocalBuilder localBuilder = ilgen.DeclareLocal(typeof(String[]));
                    //Emit set property, _Prop = value;
                    ilgen.Emit(OpCodes.Ldarg_0);
                    ilgen.Emit(OpCodes.Ldarg_1);
                    ilgen.Emit(OpCodes.Stfld, fb);

                    //Notify Change:
                    Type[] wlParams = new Type[] { typeof(string[]) };
                    MethodInfo notifyMI = typeof(DataObject).GetMethod("NotifyChange",
                    BindingFlags.NonPublic |
                    BindingFlags.Instance,
                    null,
                    CallingConventions.HasThis,
                    wlParams,
                    null);

                    //NotifyChange Property change
                    ilgen.Emit(OpCodes.Ldc_I4_1);
                    ilgen.Emit(OpCodes.Newarr, typeof(String));
                    ilgen.Emit(OpCodes.Stloc_0);
                    ilgen.Emit(OpCodes.Ldloc_0);
                    ilgen.Emit(OpCodes.Ldc_I4_0);
                    ilgen.Emit(OpCodes.Ldstr, propertyName);
                    ilgen.Emit(OpCodes.Stelem_Ref);
                    ilgen.Emit(OpCodes.Ldarg_0);
                    ilgen.Emit(OpCodes.Ldloc_0);
                    ilgen.EmitCall(OpCodes.Call, notifyMI, null); // call nodifyChange function

                    ilgen.Emit(OpCodes.Ret);
                    pb.SetSetMethod(setMethod);
                }
            }
            System.Type rowType = tb.CreateType();
            //assemblyBuilder.Save("DynamicData.dll");
            return rowType;
        }

        public static IEnumerable GetDataList(MyDataService.DataSetData data)
        {
            if (data.Tables.Count == 0)
                return null;
            
            MyDataService.DataTableInfo tableInfo = data.Tables[0];

            System.Type dataType = BuildDataObjectType(tableInfo.Columns, "MyDataObject");

            //ObservableCollection<DataObject> l = new ObservableCollection<DataObject>();

            var listType = typeof(ObservableCollection<>).MakeGenericType(new[] { dataType });
            var list = Activator.CreateInstance(listType);

            XDocument xd = XDocument.Parse(data.DataXML);
            var table = from row in xd.Descendants(tableInfo.TableName)
                        select row.Elements().ToDictionary(r => r.Name, r => r.Value);

            foreach (var r in table)
            {
                var rowData = Activator.CreateInstance(dataType) as DataObject;
                if (rowData != null)
                {
                    foreach (MyDataService.DataColumnInfo col in tableInfo.Columns)
                    {
                        if (r.ContainsKey(col.ColumnName) && col.DataTypeName != typeof(System.Byte[]).FullName && col.DataTypeName != typeof(System.Guid).FullName)
                            rowData.SetFieldValue(col.ColumnName, r[col.ColumnName], true);
                    }
                }
                listType.GetMethod("Add").Invoke(list, new[] { rowData });
            }
            ObservableCollection<DataObject> l = list as ObservableCollection<DataObject>;
            return list as IEnumerable;
        }

        public static MyDataService.DataSetData GetUpdatedDataSet(IEnumerable list, ObservableCollection<MyDataService.DataTableInfo> tables)
        {
            MyDataService.DataSetData data = new MyDataService.DataSetData();
            data.Tables = tables;
            //data.Tables = new ObservableCollection<DataSetInDataGrid.Silverlight.MyDataService.DataTableInfo>();
            //foreach (MyDataService.DataTableInfo t in tables)
            //{
            //    MyDataService.DataTableInfo table = new MyDataService.DataTableInfo { TableName = t.TableName };
            //    table.Columns = new ObservableCollection<DataSetInDataGrid.Silverlight.MyDataService.DataColumnInfo>();
            //    foreach (MyDataService.DataColumnInfo c in t.Columns)
            //    {
            //        table.Columns.Add(new MyDataService.DataColumnInfo{ColumnName= c.ColumnName, DataTypeName
            //    }
            //}

            XElement root = new XElement("DataSet");
            foreach (DataObject d in list)
            {
                if (d.State != DataObject.DataStates.Unchanged)
                {
                    XElement row = new XElement("Data", new XAttribute("RowState", d.State.ToString()));
                    PropertyInfo[] pis = d.GetType().GetProperties();
                    foreach (PropertyInfo pi in pis)
                    {
                        object val = pi.GetValue(d, null);
                        if (val != null)
                            row.Add(new XElement(pi.Name, val.ToString()));
                        else
                            row.Add(new XElement(pi.Name, ""));
                    }
                    root.Add(row);
                }
            }
            XDocument xdoc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), root);
            data.DataXML = xdoc.ToString();

            return data;
        }
	
    }
}
