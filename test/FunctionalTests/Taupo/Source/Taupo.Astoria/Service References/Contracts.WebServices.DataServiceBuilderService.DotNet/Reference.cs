﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Microsoft.Test.Taupo.Astoria.Contracts.WebServices.DataServiceBuilderService.DotNet {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ServiceBuilderParameter", Namespace="http://schemas.datacontract.org/2004/07/Microsoft.Test.Taupo.WebServices")]
    [System.SerializableAttribute()]
    public partial class ServiceBuilderParameter : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ValueField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Value {
            get {
                return this.ValueField;
            }
            set {
                if ((object.ReferenceEquals(this.ValueField, value) != true)) {
                    this.ValueField = value;
                    this.RaisePropertyChanged("Value");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="AstoriaWorkspaceInfo", Namespace="http://schemas.datacontract.org/2004/07/Microsoft.Test.Taupo.WebServices", IsReference=true)]
    [System.SerializableAttribute()]
    public partial class AstoriaWorkspaceInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.Dictionary<string, string> AdditionalProviderInfoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ServiceUriField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.Dictionary<string, string> AdditionalProviderInfo {
            get {
                return this.AdditionalProviderInfoField;
            }
            set {
                if ((object.ReferenceEquals(this.AdditionalProviderInfoField, value) != true)) {
                    this.AdditionalProviderInfoField = value;
                    this.RaisePropertyChanged("AdditionalProviderInfo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ServiceUri {
            get {
                return this.ServiceUriField;
            }
            set {
                if ((object.ReferenceEquals(this.ServiceUriField, value) != true)) {
                    this.ServiceUriField = value;
                    this.RaisePropertyChanged("ServiceUri");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Contracts.WebServices.DataServiceBuilderService.DotNet.IDataServiceBuilderService" +
        "")]
    public interface IDataServiceBuilderService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataServiceBuilderService/CreateCustomDataService", ReplyAction="http://tempuri.org/IDataServiceBuilderService/CreateCustomDataServiceResponse")]
        Microsoft.Test.Taupo.Astoria.Contracts.WebServices.DataServiceBuilderService.DotNet.AstoriaWorkspaceInfo CreateCustomDataService(out string errorLog, string[] csdlContent, string dataProviderKind, string deployerKind, Microsoft.Test.Taupo.Astoria.Contracts.WebServices.DataServiceBuilderService.DotNet.ServiceBuilderParameter[] parameters);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IDataServiceBuilderService/CreateCustomDataService", ReplyAction="http://tempuri.org/IDataServiceBuilderService/CreateCustomDataServiceResponse")]
        System.IAsyncResult BeginCreateCustomDataService(string[] csdlContent, string dataProviderKind, string deployerKind, Microsoft.Test.Taupo.Astoria.Contracts.WebServices.DataServiceBuilderService.DotNet.ServiceBuilderParameter[] parameters, System.AsyncCallback callback, object asyncState);
        
        Microsoft.Test.Taupo.Astoria.Contracts.WebServices.DataServiceBuilderService.DotNet.AstoriaWorkspaceInfo EndCreateCustomDataService(out string errorLog, System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataServiceBuilderService/GenerateClientLayerCode", ReplyAction="http://tempuri.org/IDataServiceBuilderService/GenerateClientLayerCodeResponse")]
        string GenerateClientLayerCode(out string errorLog, string dataServiceUri, string designVersion, string clientVersion, string fileExtension);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IDataServiceBuilderService/GenerateClientLayerCode", ReplyAction="http://tempuri.org/IDataServiceBuilderService/GenerateClientLayerCodeResponse")]
        System.IAsyncResult BeginGenerateClientLayerCode(string dataServiceUri, string designVersion, string clientVersion, string fileExtension, System.AsyncCallback callback, object asyncState);
        
        string EndGenerateClientLayerCode(out string errorLog, System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataServiceBuilderService/UninstallDataService", ReplyAction="http://tempuri.org/IDataServiceBuilderService/UninstallDataServiceResponse")]
        [return: System.ServiceModel.MessageParameterAttribute(Name="errorLog")]
        string UninstallDataService(string dataServiceUri);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IDataServiceBuilderService/UninstallDataService", ReplyAction="http://tempuri.org/IDataServiceBuilderService/UninstallDataServiceResponse")]
        System.IAsyncResult BeginUninstallDataService(string dataServiceUri, System.AsyncCallback callback, object asyncState);
        
        [return: System.ServiceModel.MessageParameterAttribute(Name="errorLog")]
        string EndUninstallDataService(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDataServiceBuilderServiceChannel : Microsoft.Test.Taupo.Astoria.Contracts.WebServices.DataServiceBuilderService.DotNet.IDataServiceBuilderService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CreateCustomDataServiceCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public CreateCustomDataServiceCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public string errorLog {
            get {
                base.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
        
        public Microsoft.Test.Taupo.Astoria.Contracts.WebServices.DataServiceBuilderService.DotNet.AstoriaWorkspaceInfo Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((Microsoft.Test.Taupo.Astoria.Contracts.WebServices.DataServiceBuilderService.DotNet.AstoriaWorkspaceInfo)(this.results[1]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GenerateClientLayerCodeCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GenerateClientLayerCodeCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public string errorLog {
            get {
                base.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
        
        public string Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((string)(this.results[1]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UninstallDataServiceCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public UninstallDataServiceCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public string Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DataServiceBuilderServiceClient : System.ServiceModel.ClientBase<Microsoft.Test.Taupo.Astoria.Contracts.WebServices.DataServiceBuilderService.DotNet.IDataServiceBuilderService>, Microsoft.Test.Taupo.Astoria.Contracts.WebServices.DataServiceBuilderService.DotNet.IDataServiceBuilderService {
        
        private BeginOperationDelegate onBeginCreateCustomDataServiceDelegate;
        
        private EndOperationDelegate onEndCreateCustomDataServiceDelegate;
        
        private System.Threading.SendOrPostCallback onCreateCustomDataServiceCompletedDelegate;
        
        private BeginOperationDelegate onBeginGenerateClientLayerCodeDelegate;
        
        private EndOperationDelegate onEndGenerateClientLayerCodeDelegate;
        
        private System.Threading.SendOrPostCallback onGenerateClientLayerCodeCompletedDelegate;
        
        private BeginOperationDelegate onBeginUninstallDataServiceDelegate;
        
        private EndOperationDelegate onEndUninstallDataServiceDelegate;
        
        private System.Threading.SendOrPostCallback onUninstallDataServiceCompletedDelegate;
        
        public DataServiceBuilderServiceClient() {
        }
        
        public DataServiceBuilderServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DataServiceBuilderServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DataServiceBuilderServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DataServiceBuilderServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public event System.EventHandler<CreateCustomDataServiceCompletedEventArgs> CreateCustomDataServiceCompleted;
        
        public event System.EventHandler<GenerateClientLayerCodeCompletedEventArgs> GenerateClientLayerCodeCompleted;
        
        public event System.EventHandler<UninstallDataServiceCompletedEventArgs> UninstallDataServiceCompleted;
        
        public Microsoft.Test.Taupo.Astoria.Contracts.WebServices.DataServiceBuilderService.DotNet.AstoriaWorkspaceInfo CreateCustomDataService(out string errorLog, string[] csdlContent, string dataProviderKind, string deployerKind, Microsoft.Test.Taupo.Astoria.Contracts.WebServices.DataServiceBuilderService.DotNet.ServiceBuilderParameter[] parameters) {
            return base.Channel.CreateCustomDataService(out errorLog, csdlContent, dataProviderKind, deployerKind, parameters);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginCreateCustomDataService(string[] csdlContent, string dataProviderKind, string deployerKind, Microsoft.Test.Taupo.Astoria.Contracts.WebServices.DataServiceBuilderService.DotNet.ServiceBuilderParameter[] parameters, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginCreateCustomDataService(csdlContent, dataProviderKind, deployerKind, parameters, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public Microsoft.Test.Taupo.Astoria.Contracts.WebServices.DataServiceBuilderService.DotNet.AstoriaWorkspaceInfo EndCreateCustomDataService(out string errorLog, System.IAsyncResult result) {
            return base.Channel.EndCreateCustomDataService(out errorLog, result);
        }
        
        private System.IAsyncResult OnBeginCreateCustomDataService(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string[] csdlContent = ((string[])(inValues[0]));
            string dataProviderKind = ((string)(inValues[1]));
            string deployerKind = ((string)(inValues[2]));
            Microsoft.Test.Taupo.Astoria.Contracts.WebServices.DataServiceBuilderService.DotNet.ServiceBuilderParameter[] parameters = ((Microsoft.Test.Taupo.Astoria.Contracts.WebServices.DataServiceBuilderService.DotNet.ServiceBuilderParameter[])(inValues[3]));
            return this.BeginCreateCustomDataService(csdlContent, dataProviderKind, deployerKind, parameters, callback, asyncState);
        }
        
        private object[] OnEndCreateCustomDataService(System.IAsyncResult result) {
            string errorLog = this.GetDefaultValueForInitialization<string>();
            Microsoft.Test.Taupo.Astoria.Contracts.WebServices.DataServiceBuilderService.DotNet.AstoriaWorkspaceInfo retVal = this.EndCreateCustomDataService(out errorLog, result);
            return new object[] {
                    errorLog,
                    retVal};
        }
        
        private void OnCreateCustomDataServiceCompleted(object state) {
            if ((this.CreateCustomDataServiceCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CreateCustomDataServiceCompleted(this, new CreateCustomDataServiceCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void CreateCustomDataServiceAsync(string[] csdlContent, string dataProviderKind, string deployerKind, Microsoft.Test.Taupo.Astoria.Contracts.WebServices.DataServiceBuilderService.DotNet.ServiceBuilderParameter[] parameters) {
            this.CreateCustomDataServiceAsync(csdlContent, dataProviderKind, deployerKind, parameters, null);
        }
        
        public void CreateCustomDataServiceAsync(string[] csdlContent, string dataProviderKind, string deployerKind, Microsoft.Test.Taupo.Astoria.Contracts.WebServices.DataServiceBuilderService.DotNet.ServiceBuilderParameter[] parameters, object userState) {
            if ((this.onBeginCreateCustomDataServiceDelegate == null)) {
                this.onBeginCreateCustomDataServiceDelegate = new BeginOperationDelegate(this.OnBeginCreateCustomDataService);
            }
            if ((this.onEndCreateCustomDataServiceDelegate == null)) {
                this.onEndCreateCustomDataServiceDelegate = new EndOperationDelegate(this.OnEndCreateCustomDataService);
            }
            if ((this.onCreateCustomDataServiceCompletedDelegate == null)) {
                this.onCreateCustomDataServiceCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCreateCustomDataServiceCompleted);
            }
            base.InvokeAsync(this.onBeginCreateCustomDataServiceDelegate, new object[] {
                        csdlContent,
                        dataProviderKind,
                        deployerKind,
                        parameters}, this.onEndCreateCustomDataServiceDelegate, this.onCreateCustomDataServiceCompletedDelegate, userState);
        }
        
        public string GenerateClientLayerCode(out string errorLog, string dataServiceUri, string designVersion, string clientVersion, string fileExtension) {
            return base.Channel.GenerateClientLayerCode(out errorLog, dataServiceUri, designVersion, clientVersion, fileExtension);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGenerateClientLayerCode(string dataServiceUri, string designVersion, string clientVersion, string fileExtension, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGenerateClientLayerCode(dataServiceUri, designVersion, clientVersion, fileExtension, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public string EndGenerateClientLayerCode(out string errorLog, System.IAsyncResult result) {
            return base.Channel.EndGenerateClientLayerCode(out errorLog, result);
        }
        
        private System.IAsyncResult OnBeginGenerateClientLayerCode(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string dataServiceUri = ((string)(inValues[0]));
            string designVersion = ((string)(inValues[1]));
            string clientVersion = ((string)(inValues[2]));
            string fileExtension = ((string)(inValues[3]));
            return this.BeginGenerateClientLayerCode(dataServiceUri, designVersion, clientVersion, fileExtension, callback, asyncState);
        }
        
        private object[] OnEndGenerateClientLayerCode(System.IAsyncResult result) {
            string errorLog = this.GetDefaultValueForInitialization<string>();
            string retVal = this.EndGenerateClientLayerCode(out errorLog, result);
            return new object[] {
                    errorLog,
                    retVal};
        }
        
        private void OnGenerateClientLayerCodeCompleted(object state) {
            if ((this.GenerateClientLayerCodeCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GenerateClientLayerCodeCompleted(this, new GenerateClientLayerCodeCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GenerateClientLayerCodeAsync(string dataServiceUri, string designVersion, string clientVersion, string fileExtension) {
            this.GenerateClientLayerCodeAsync(dataServiceUri, designVersion, clientVersion, fileExtension, null);
        }
        
        public void GenerateClientLayerCodeAsync(string dataServiceUri, string designVersion, string clientVersion, string fileExtension, object userState) {
            if ((this.onBeginGenerateClientLayerCodeDelegate == null)) {
                this.onBeginGenerateClientLayerCodeDelegate = new BeginOperationDelegate(this.OnBeginGenerateClientLayerCode);
            }
            if ((this.onEndGenerateClientLayerCodeDelegate == null)) {
                this.onEndGenerateClientLayerCodeDelegate = new EndOperationDelegate(this.OnEndGenerateClientLayerCode);
            }
            if ((this.onGenerateClientLayerCodeCompletedDelegate == null)) {
                this.onGenerateClientLayerCodeCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGenerateClientLayerCodeCompleted);
            }
            base.InvokeAsync(this.onBeginGenerateClientLayerCodeDelegate, new object[] {
                        dataServiceUri,
                        designVersion,
                        clientVersion,
                        fileExtension}, this.onEndGenerateClientLayerCodeDelegate, this.onGenerateClientLayerCodeCompletedDelegate, userState);
        }
        
        public string UninstallDataService(string dataServiceUri) {
            return base.Channel.UninstallDataService(dataServiceUri);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginUninstallDataService(string dataServiceUri, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginUninstallDataService(dataServiceUri, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public string EndUninstallDataService(System.IAsyncResult result) {
            return base.Channel.EndUninstallDataService(result);
        }
        
        private System.IAsyncResult OnBeginUninstallDataService(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string dataServiceUri = ((string)(inValues[0]));
            return this.BeginUninstallDataService(dataServiceUri, callback, asyncState);
        }
        
        private object[] OnEndUninstallDataService(System.IAsyncResult result) {
            string retVal = this.EndUninstallDataService(result);
            return new object[] {
                    retVal};
        }
        
        private void OnUninstallDataServiceCompleted(object state) {
            if ((this.UninstallDataServiceCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.UninstallDataServiceCompleted(this, new UninstallDataServiceCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void UninstallDataServiceAsync(string dataServiceUri) {
            this.UninstallDataServiceAsync(dataServiceUri, null);
        }
        
        public void UninstallDataServiceAsync(string dataServiceUri, object userState) {
            if ((this.onBeginUninstallDataServiceDelegate == null)) {
                this.onBeginUninstallDataServiceDelegate = new BeginOperationDelegate(this.OnBeginUninstallDataService);
            }
            if ((this.onEndUninstallDataServiceDelegate == null)) {
                this.onEndUninstallDataServiceDelegate = new EndOperationDelegate(this.OnEndUninstallDataService);
            }
            if ((this.onUninstallDataServiceCompletedDelegate == null)) {
                this.onUninstallDataServiceCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnUninstallDataServiceCompleted);
            }
            base.InvokeAsync(this.onBeginUninstallDataServiceDelegate, new object[] {
                        dataServiceUri}, this.onEndUninstallDataServiceDelegate, this.onUninstallDataServiceCompletedDelegate, userState);
        }
    }
}
