﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1008
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.1008.
// 
#pragma warning disable 1591

namespace ERP.WSPANWS {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="WorldSpanwsSoapBinding", Namespace="http://action.span.world")]
    public partial class WorldSpanwsService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback createSessionOperationCompleted;
        
        private System.Threading.SendOrPostCallback closeSessionOperationCompleted;
        
        private System.Threading.SendOrPostCallback executeOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public WorldSpanwsService() {
            this.Url = global::ERP.Properties.Settings.Default.ERP_WSPANWS_WorldSpanwsService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event createSessionCompletedEventHandler createSessionCompleted;
        
        /// <remarks/>
        public event closeSessionCompletedEventHandler closeSessionCompleted;
        
        /// <remarks/>
        public event executeCompletedEventHandler executeCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace="http://action.span.world", ResponseNamespace="http://action.span.world", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("createSessionReturn")]
        public string createSession(string sid) {
            object[] results = this.Invoke("createSession", new object[] {
                        sid});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void createSessionAsync(string sid) {
            this.createSessionAsync(sid, null);
        }
        
        /// <remarks/>
        public void createSessionAsync(string sid, object userState) {
            if ((this.createSessionOperationCompleted == null)) {
                this.createSessionOperationCompleted = new System.Threading.SendOrPostCallback(this.OncreateSessionOperationCompleted);
            }
            this.InvokeAsync("createSession", new object[] {
                        sid}, this.createSessionOperationCompleted, userState);
        }
        
        private void OncreateSessionOperationCompleted(object arg) {
            if ((this.createSessionCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.createSessionCompleted(this, new createSessionCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace="http://action.span.world", ResponseNamespace="http://action.span.world", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("closeSessionReturn")]
        public string closeSession(string sessionNumber, string sid) {
            object[] results = this.Invoke("closeSession", new object[] {
                        sessionNumber,
                        sid});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void closeSessionAsync(string sessionNumber, string sid) {
            this.closeSessionAsync(sessionNumber, sid, null);
        }
        
        /// <remarks/>
        public void closeSessionAsync(string sessionNumber, string sid, object userState) {
            if ((this.closeSessionOperationCompleted == null)) {
                this.closeSessionOperationCompleted = new System.Threading.SendOrPostCallback(this.OncloseSessionOperationCompleted);
            }
            this.InvokeAsync("closeSession", new object[] {
                        sessionNumber,
                        sid}, this.closeSessionOperationCompleted, userState);
        }
        
        private void OncloseSessionOperationCompleted(object arg) {
            if ((this.closeSessionCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.closeSessionCompleted(this, new closeSessionCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace="http://action.span.world", ResponseNamespace="http://action.span.world", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("executeReturn")]
        public string execute(string commandText, string sessionnumber, string sid) {
            object[] results = this.Invoke("execute", new object[] {
                        commandText,
                        sessionnumber,
                        sid});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void executeAsync(string commandText, string sessionnumber, string sid) {
            this.executeAsync(commandText, sessionnumber, sid, null);
        }
        
        /// <remarks/>
        public void executeAsync(string commandText, string sessionnumber, string sid, object userState) {
            if ((this.executeOperationCompleted == null)) {
                this.executeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnexecuteOperationCompleted);
            }
            this.InvokeAsync("execute", new object[] {
                        commandText,
                        sessionnumber,
                        sid}, this.executeOperationCompleted, userState);
        }
        
        private void OnexecuteOperationCompleted(object arg) {
            if ((this.executeCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.executeCompleted(this, new executeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void createSessionCompletedEventHandler(object sender, createSessionCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class createSessionCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal createSessionCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void closeSessionCompletedEventHandler(object sender, closeSessionCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class closeSessionCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal closeSessionCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void executeCompletedEventHandler(object sender, executeCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class executeCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal executeCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591