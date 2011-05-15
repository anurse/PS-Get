﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.225
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PsGet.Helper {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ProgressRecord", Namespace="http://schemas.datacontract.org/2004/07/PsGet.Helper.Serializables")]
    [System.SerializableAttribute()]
    internal partial class ProgressRecord : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ActivityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ActivityIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CurrentOperationField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ParentActivityIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PercentCompleteField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private PsGet.Helper.ProgressRecordType RecordTypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int SecondsRemainingField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StatusDescriptionField;
        
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
        internal string Activity {
            get {
                return this.ActivityField;
            }
            set {
                if ((object.ReferenceEquals(this.ActivityField, value) != true)) {
                    this.ActivityField = value;
                    this.RaisePropertyChanged("Activity");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        internal int ActivityId {
            get {
                return this.ActivityIdField;
            }
            set {
                if ((this.ActivityIdField.Equals(value) != true)) {
                    this.ActivityIdField = value;
                    this.RaisePropertyChanged("ActivityId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        internal string CurrentOperation {
            get {
                return this.CurrentOperationField;
            }
            set {
                if ((object.ReferenceEquals(this.CurrentOperationField, value) != true)) {
                    this.CurrentOperationField = value;
                    this.RaisePropertyChanged("CurrentOperation");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        internal int ParentActivityId {
            get {
                return this.ParentActivityIdField;
            }
            set {
                if ((this.ParentActivityIdField.Equals(value) != true)) {
                    this.ParentActivityIdField = value;
                    this.RaisePropertyChanged("ParentActivityId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        internal int PercentComplete {
            get {
                return this.PercentCompleteField;
            }
            set {
                if ((this.PercentCompleteField.Equals(value) != true)) {
                    this.PercentCompleteField = value;
                    this.RaisePropertyChanged("PercentComplete");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        internal PsGet.Helper.ProgressRecordType RecordType {
            get {
                return this.RecordTypeField;
            }
            set {
                if ((this.RecordTypeField.Equals(value) != true)) {
                    this.RecordTypeField = value;
                    this.RaisePropertyChanged("RecordType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        internal int SecondsRemaining {
            get {
                return this.SecondsRemainingField;
            }
            set {
                if ((this.SecondsRemainingField.Equals(value) != true)) {
                    this.SecondsRemainingField = value;
                    this.RaisePropertyChanged("SecondsRemaining");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        internal string StatusDescription {
            get {
                return this.StatusDescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.StatusDescriptionField, value) != true)) {
                    this.StatusDescriptionField = value;
                    this.RaisePropertyChanged("StatusDescription");
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ProgressRecordType", Namespace="http://schemas.datacontract.org/2004/07/PsGet.Helper.Serializables")]
    internal enum ProgressRecordType : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Processing = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Completed = 1,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://ns.psget.org/helper", ConfigurationName="Helper.INuGetShim", CallbackContract=typeof(PsGet.Helper.INuGetShimCallback))]
    internal interface INuGetShim {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://ns.psget.org/helper/INuGetShim/Install")]
        void Install(string id, System.Version version, string source, string destination);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://ns.psget.org/helper/INuGetShim/Shutdown")]
        void Shutdown();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    internal interface INuGetShimCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://ns.psget.org/helper/INuGetShim/ReportProgress")]
        void ReportProgress(PsGet.Helper.ProgressRecord record);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://ns.psget.org/helper/INuGetShim/Completed")]
        void Completed();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    internal interface INuGetShimChannel : PsGet.Helper.INuGetShim, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    internal partial class NuGetShimClient : System.ServiceModel.DuplexClientBase<PsGet.Helper.INuGetShim>, PsGet.Helper.INuGetShim {
        
        public NuGetShimClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public NuGetShimClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public NuGetShimClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public NuGetShimClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public NuGetShimClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void Install(string id, System.Version version, string source, string destination) {
            base.Channel.Install(id, version, source, destination);
        }
        
        public void Shutdown() {
            base.Channel.Shutdown();
        }
    }
}
