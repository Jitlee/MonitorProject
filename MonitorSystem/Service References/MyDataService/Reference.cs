﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.1
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.Silverlight.ServiceReference, version 4.0.50826.0
// 
namespace MonitorSystem.MyDataService {
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DataSetData", Namespace="http://schemas.datacontract.org/2004/07/")]
    public partial class DataSetData : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string DataXMLField;
        
        private System.Collections.ObjectModel.ObservableCollection<MonitorSystem.MyDataService.DataTableInfo> TablesField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DataXML {
            get {
                return this.DataXMLField;
            }
            set {
                if ((object.ReferenceEquals(this.DataXMLField, value) != true)) {
                    this.DataXMLField = value;
                    this.RaisePropertyChanged("DataXML");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.ObjectModel.ObservableCollection<MonitorSystem.MyDataService.DataTableInfo> Tables {
            get {
                return this.TablesField;
            }
            set {
                if ((object.ReferenceEquals(this.TablesField, value) != true)) {
                    this.TablesField = value;
                    this.RaisePropertyChanged("Tables");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DataTableInfo", Namespace="http://schemas.datacontract.org/2004/07/")]
    public partial class DataTableInfo : object, System.ComponentModel.INotifyPropertyChanged {
        
        private System.Collections.ObjectModel.ObservableCollection<MonitorSystem.MyDataService.DataColumnInfo> ColumnsField;
        
        private string TableNameField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.ObjectModel.ObservableCollection<MonitorSystem.MyDataService.DataColumnInfo> Columns {
            get {
                return this.ColumnsField;
            }
            set {
                if ((object.ReferenceEquals(this.ColumnsField, value) != true)) {
                    this.ColumnsField = value;
                    this.RaisePropertyChanged("Columns");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TableName {
            get {
                return this.TableNameField;
            }
            set {
                if ((object.ReferenceEquals(this.TableNameField, value) != true)) {
                    this.TableNameField = value;
                    this.RaisePropertyChanged("TableName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DataColumnInfo", Namespace="http://schemas.datacontract.org/2004/07/")]
    public partial class DataColumnInfo : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string ColumnNameField;
        
        private string ColumnTitleField;
        
        private string DataTypeNameField;
        
        private int DisplayIndexField;
        
        private string EditControlTypeField;
        
        private bool IsKeyField;
        
        private bool IsReadOnlyField;
        
        private bool IsRequiredField;
        
        private int MaxLengthField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ColumnName {
            get {
                return this.ColumnNameField;
            }
            set {
                if ((object.ReferenceEquals(this.ColumnNameField, value) != true)) {
                    this.ColumnNameField = value;
                    this.RaisePropertyChanged("ColumnName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ColumnTitle {
            get {
                return this.ColumnTitleField;
            }
            set {
                if ((object.ReferenceEquals(this.ColumnTitleField, value) != true)) {
                    this.ColumnTitleField = value;
                    this.RaisePropertyChanged("ColumnTitle");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DataTypeName {
            get {
                return this.DataTypeNameField;
            }
            set {
                if ((object.ReferenceEquals(this.DataTypeNameField, value) != true)) {
                    this.DataTypeNameField = value;
                    this.RaisePropertyChanged("DataTypeName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int DisplayIndex {
            get {
                return this.DisplayIndexField;
            }
            set {
                if ((this.DisplayIndexField.Equals(value) != true)) {
                    this.DisplayIndexField = value;
                    this.RaisePropertyChanged("DisplayIndex");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string EditControlType {
            get {
                return this.EditControlTypeField;
            }
            set {
                if ((object.ReferenceEquals(this.EditControlTypeField, value) != true)) {
                    this.EditControlTypeField = value;
                    this.RaisePropertyChanged("EditControlType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsKey {
            get {
                return this.IsKeyField;
            }
            set {
                if ((this.IsKeyField.Equals(value) != true)) {
                    this.IsKeyField = value;
                    this.RaisePropertyChanged("IsKey");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsReadOnly {
            get {
                return this.IsReadOnlyField;
            }
            set {
                if ((this.IsReadOnlyField.Equals(value) != true)) {
                    this.IsReadOnlyField = value;
                    this.RaisePropertyChanged("IsReadOnly");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsRequired {
            get {
                return this.IsRequiredField;
            }
            set {
                if ((this.IsRequiredField.Equals(value) != true)) {
                    this.IsRequiredField = value;
                    this.RaisePropertyChanged("IsRequired");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int MaxLength {
            get {
                return this.MaxLengthField;
            }
            set {
                if ((this.MaxLengthField.Equals(value) != true)) {
                    this.MaxLengthField = value;
                    this.RaisePropertyChanged("MaxLength");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CustomException", Namespace="http://schemas.datacontract.org/2004/07/")]
    public partial class CustomException : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string MessageField;
        
        private MonitorSystem.MyDataService.CustomException InnerExceptionField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Message {
            get {
                return this.MessageField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageField, value) != true)) {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public MonitorSystem.MyDataService.CustomException InnerException {
            get {
                return this.InnerExceptionField;
            }
            set {
                if ((object.ReferenceEquals(this.InnerExceptionField, value) != true)) {
                    this.InnerExceptionField = value;
                    this.RaisePropertyChanged("InnerException");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="", ConfigurationName="MyDataService.GetData")]
    public interface GetData {
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:GetData/GetDataSetData", ReplyAction="urn:GetData/GetDataSetDataResponse")]
        System.IAsyncResult BeginGetDataSetData(string ConnStr, string SQL, System.AsyncCallback callback, object asyncState);
        
        MonitorSystem.MyDataService.DataSetData EndGetDataSetData(out MonitorSystem.MyDataService.CustomException ServiceError, System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface GetDataChannel : MonitorSystem.MyDataService.GetData, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetDataSetDataCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetDataSetDataCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public MonitorSystem.MyDataService.CustomException ServiceError {
            get {
                base.RaiseExceptionIfNecessary();
                return ((MonitorSystem.MyDataService.CustomException)(this.results[0]));
            }
        }
        
        public MonitorSystem.MyDataService.DataSetData Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((MonitorSystem.MyDataService.DataSetData)(this.results[1]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetDataClient : System.ServiceModel.ClientBase<MonitorSystem.MyDataService.GetData>, MonitorSystem.MyDataService.GetData {
        
        private BeginOperationDelegate onBeginGetDataSetDataDelegate;
        
        private EndOperationDelegate onEndGetDataSetDataDelegate;
        
        private System.Threading.SendOrPostCallback onGetDataSetDataCompletedDelegate;
        
        private BeginOperationDelegate onBeginOpenDelegate;
        
        private EndOperationDelegate onEndOpenDelegate;
        
        private System.Threading.SendOrPostCallback onOpenCompletedDelegate;
        
        private BeginOperationDelegate onBeginCloseDelegate;
        
        private EndOperationDelegate onEndCloseDelegate;
        
        private System.Threading.SendOrPostCallback onCloseCompletedDelegate;
        
        public GetDataClient() {
        }
        
        public GetDataClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public GetDataClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GetDataClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GetDataClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Net.CookieContainer CookieContainer {
            get {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    return httpCookieContainerManager.CookieContainer;
                }
                else {
                    return null;
                }
            }
            set {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    httpCookieContainerManager.CookieContainer = value;
                }
                else {
                    throw new System.InvalidOperationException("无法设置 CookieContainer。请确保绑定包含 HttpCookieContainerBindingElement。");
                }
            }
        }
        
        public event System.EventHandler<GetDataSetDataCompletedEventArgs> GetDataSetDataCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> OpenCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> CloseCompleted;
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult MonitorSystem.MyDataService.GetData.BeginGetDataSetData(string ConnStr, string SQL, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetDataSetData(ConnStr, SQL, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        MonitorSystem.MyDataService.DataSetData MonitorSystem.MyDataService.GetData.EndGetDataSetData(out MonitorSystem.MyDataService.CustomException ServiceError, System.IAsyncResult result) {
            return base.Channel.EndGetDataSetData(out ServiceError, result);
        }
        
        private System.IAsyncResult OnBeginGetDataSetData(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string ConnStr = ((string)(inValues[0]));
            string SQL = ((string)(inValues[1]));
            return ((MonitorSystem.MyDataService.GetData)(this)).BeginGetDataSetData(ConnStr, SQL, callback, asyncState);
        }
        
        private object[] OnEndGetDataSetData(System.IAsyncResult result) {
            MonitorSystem.MyDataService.CustomException ServiceError = this.GetDefaultValueForInitialization<MonitorSystem.MyDataService.CustomException>();
            MonitorSystem.MyDataService.DataSetData retVal = ((MonitorSystem.MyDataService.GetData)(this)).EndGetDataSetData(out ServiceError, result);
            return new object[] {
                    ServiceError,
                    retVal};
        }
        
        private void OnGetDataSetDataCompleted(object state) {
            if ((this.GetDataSetDataCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetDataSetDataCompleted(this, new GetDataSetDataCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetDataSetDataAsync(string ConnStr, string SQL) {
            this.GetDataSetDataAsync(ConnStr, SQL, null);
        }
        
        public void GetDataSetDataAsync(string ConnStr, string SQL, object userState) {
            if ((this.onBeginGetDataSetDataDelegate == null)) {
                this.onBeginGetDataSetDataDelegate = new BeginOperationDelegate(this.OnBeginGetDataSetData);
            }
            if ((this.onEndGetDataSetDataDelegate == null)) {
                this.onEndGetDataSetDataDelegate = new EndOperationDelegate(this.OnEndGetDataSetData);
            }
            if ((this.onGetDataSetDataCompletedDelegate == null)) {
                this.onGetDataSetDataCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetDataSetDataCompleted);
            }
            base.InvokeAsync(this.onBeginGetDataSetDataDelegate, new object[] {
                        ConnStr,
                        SQL}, this.onEndGetDataSetDataDelegate, this.onGetDataSetDataCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginOpen(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(callback, asyncState);
        }
        
        private object[] OnEndOpen(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndOpen(result);
            return null;
        }
        
        private void OnOpenCompleted(object state) {
            if ((this.OpenCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.OpenCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void OpenAsync() {
            this.OpenAsync(null);
        }
        
        public void OpenAsync(object userState) {
            if ((this.onBeginOpenDelegate == null)) {
                this.onBeginOpenDelegate = new BeginOperationDelegate(this.OnBeginOpen);
            }
            if ((this.onEndOpenDelegate == null)) {
                this.onEndOpenDelegate = new EndOperationDelegate(this.OnEndOpen);
            }
            if ((this.onOpenCompletedDelegate == null)) {
                this.onOpenCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnOpenCompleted);
            }
            base.InvokeAsync(this.onBeginOpenDelegate, null, this.onEndOpenDelegate, this.onOpenCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginClose(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginClose(callback, asyncState);
        }
        
        private object[] OnEndClose(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndClose(result);
            return null;
        }
        
        private void OnCloseCompleted(object state) {
            if ((this.CloseCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CloseCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void CloseAsync() {
            this.CloseAsync(null);
        }
        
        public void CloseAsync(object userState) {
            if ((this.onBeginCloseDelegate == null)) {
                this.onBeginCloseDelegate = new BeginOperationDelegate(this.OnBeginClose);
            }
            if ((this.onEndCloseDelegate == null)) {
                this.onEndCloseDelegate = new EndOperationDelegate(this.OnEndClose);
            }
            if ((this.onCloseCompletedDelegate == null)) {
                this.onCloseCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCloseCompleted);
            }
            base.InvokeAsync(this.onBeginCloseDelegate, null, this.onEndCloseDelegate, this.onCloseCompletedDelegate, userState);
        }
        
        protected override MonitorSystem.MyDataService.GetData CreateChannel() {
            return new GetDataClientChannel(this);
        }
        
        private class GetDataClientChannel : ChannelBase<MonitorSystem.MyDataService.GetData>, MonitorSystem.MyDataService.GetData {
            
            public GetDataClientChannel(System.ServiceModel.ClientBase<MonitorSystem.MyDataService.GetData> client) : 
                    base(client) {
            }
            
            public System.IAsyncResult BeginGetDataSetData(string ConnStr, string SQL, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[2];
                _args[0] = ConnStr;
                _args[1] = SQL;
                System.IAsyncResult _result = base.BeginInvoke("GetDataSetData", _args, callback, asyncState);
                return _result;
            }
            
            public MonitorSystem.MyDataService.DataSetData EndGetDataSetData(out MonitorSystem.MyDataService.CustomException ServiceError, System.IAsyncResult result) {
                object[] _args = new object[1];
                MonitorSystem.MyDataService.DataSetData _result = ((MonitorSystem.MyDataService.DataSetData)(base.EndInvoke("GetDataSetData", _args, result)));
                ServiceError = ((MonitorSystem.MyDataService.CustomException)(_args[0]));
                return _result;
            }
        }
    }
}
