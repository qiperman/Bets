﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BetsClient.MainService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Account", Namespace="http://schemas.datacontract.org/2004/07/BetsServer")]
    [System.SerializableAttribute()]
    public partial class Account : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal balanceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int codeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nameField;
        
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
        public decimal balance {
            get {
                return this.balanceField;
            }
            set {
                if ((this.balanceField.Equals(value) != true)) {
                    this.balanceField = value;
                    this.RaisePropertyChanged("balance");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int code {
            get {
                return this.codeField;
            }
            set {
                if ((this.codeField.Equals(value) != true)) {
                    this.codeField = value;
                    this.RaisePropertyChanged("code");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                if ((object.ReferenceEquals(this.nameField, value) != true)) {
                    this.nameField = value;
                    this.RaisePropertyChanged("name");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="BetType", Namespace="http://schemas.datacontract.org/2004/07/BetsServer")]
    public enum BetType : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        simple = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        system = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        express = 2,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Bet", Namespace="http://schemas.datacontract.org/2004/07/BetsServer")]
    [System.SerializableAttribute()]
    public partial class Bet : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int accountIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private BetsClient.MainService.Event betEventField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int codeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime dateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private BetsClient.MainService.status resultField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal sumField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private BetsClient.MainService.BetType typeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal winnigSumField;
        
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
        public int accountId {
            get {
                return this.accountIdField;
            }
            set {
                if ((this.accountIdField.Equals(value) != true)) {
                    this.accountIdField = value;
                    this.RaisePropertyChanged("accountId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public BetsClient.MainService.Event betEvent {
            get {
                return this.betEventField;
            }
            set {
                if ((object.ReferenceEquals(this.betEventField, value) != true)) {
                    this.betEventField = value;
                    this.RaisePropertyChanged("betEvent");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int code {
            get {
                return this.codeField;
            }
            set {
                if ((this.codeField.Equals(value) != true)) {
                    this.codeField = value;
                    this.RaisePropertyChanged("code");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime date {
            get {
                return this.dateField;
            }
            set {
                if ((this.dateField.Equals(value) != true)) {
                    this.dateField = value;
                    this.RaisePropertyChanged("date");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public BetsClient.MainService.status result {
            get {
                return this.resultField;
            }
            set {
                if ((this.resultField.Equals(value) != true)) {
                    this.resultField = value;
                    this.RaisePropertyChanged("result");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal sum {
            get {
                return this.sumField;
            }
            set {
                if ((this.sumField.Equals(value) != true)) {
                    this.sumField = value;
                    this.RaisePropertyChanged("sum");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public BetsClient.MainService.BetType type {
            get {
                return this.typeField;
            }
            set {
                if ((this.typeField.Equals(value) != true)) {
                    this.typeField = value;
                    this.RaisePropertyChanged("type");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal winnigSum {
            get {
                return this.winnigSumField;
            }
            set {
                if ((this.winnigSumField.Equals(value) != true)) {
                    this.winnigSumField = value;
                    this.RaisePropertyChanged("winnigSum");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Event", Namespace="http://schemas.datacontract.org/2004/07/BetsServer")]
    [System.SerializableAttribute()]
    public partial class Event : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int codeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal rateField;
        
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
        public int code {
            get {
                return this.codeField;
            }
            set {
                if ((this.codeField.Equals(value) != true)) {
                    this.codeField = value;
                    this.RaisePropertyChanged("code");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                if ((object.ReferenceEquals(this.nameField, value) != true)) {
                    this.nameField = value;
                    this.RaisePropertyChanged("name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal rate {
            get {
                return this.rateField;
            }
            set {
                if ((this.rateField.Equals(value) != true)) {
                    this.rateField = value;
                    this.RaisePropertyChanged("rate");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="status", Namespace="http://schemas.datacontract.org/2004/07/BetsServer")]
    public enum status : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        active = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        win = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        loss = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        draw = 3,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MainService.IMainService")]
    public interface IMainService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMainService/TestConnection", ReplyAction="http://tempuri.org/IMainService/TestConnectionResponse")]
        bool TestConnection();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMainService/TestConnection", ReplyAction="http://tempuri.org/IMainService/TestConnectionResponse")]
        System.Threading.Tasks.Task<bool> TestConnectionAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMainService/GetAccount", ReplyAction="http://tempuri.org/IMainService/GetAccountResponse")]
        BetsClient.MainService.Account GetAccount(int code);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMainService/GetAccount", ReplyAction="http://tempuri.org/IMainService/GetAccountResponse")]
        System.Threading.Tasks.Task<BetsClient.MainService.Account> GetAccountAsync(int code);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMainService/Deposit", ReplyAction="http://tempuri.org/IMainService/DepositResponse")]
        string Deposit(int usercode, decimal sum);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMainService/Deposit", ReplyAction="http://tempuri.org/IMainService/DepositResponse")]
        System.Threading.Tasks.Task<string> DepositAsync(int usercode, decimal sum);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMainService/Withdraw", ReplyAction="http://tempuri.org/IMainService/WithdrawResponse")]
        string Withdraw(int usercode, decimal sum);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMainService/Withdraw", ReplyAction="http://tempuri.org/IMainService/WithdrawResponse")]
        System.Threading.Tasks.Task<string> WithdrawAsync(int usercode, decimal sum);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMainService/MakeBet", ReplyAction="http://tempuri.org/IMainService/MakeBetResponse")]
        string MakeBet(int accountId, decimal sum, int eventCode, BetsClient.MainService.BetType type);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMainService/MakeBet", ReplyAction="http://tempuri.org/IMainService/MakeBetResponse")]
        System.Threading.Tasks.Task<string> MakeBetAsync(int accountId, decimal sum, int eventCode, BetsClient.MainService.BetType type);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMainService/GetBets", ReplyAction="http://tempuri.org/IMainService/GetBetsResponse")]
        BetsClient.MainService.Bet[] GetBets(int code);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMainService/GetBets", ReplyAction="http://tempuri.org/IMainService/GetBetsResponse")]
        System.Threading.Tasks.Task<BetsClient.MainService.Bet[]> GetBetsAsync(int code);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMainService/GetEvents", ReplyAction="http://tempuri.org/IMainService/GetEventsResponse")]
        BetsClient.MainService.Event[] GetEvents();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMainService/GetEvents", ReplyAction="http://tempuri.org/IMainService/GetEventsResponse")]
        System.Threading.Tasks.Task<BetsClient.MainService.Event[]> GetEventsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMainService/GetBet", ReplyAction="http://tempuri.org/IMainService/GetBetResponse")]
        BetsClient.MainService.Bet GetBet(int betCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMainService/GetBet", ReplyAction="http://tempuri.org/IMainService/GetBetResponse")]
        System.Threading.Tasks.Task<BetsClient.MainService.Bet> GetBetAsync(int betCode);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMainServiceChannel : BetsClient.MainService.IMainService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MainServiceClient : System.ServiceModel.ClientBase<BetsClient.MainService.IMainService>, BetsClient.MainService.IMainService {
        
        public MainServiceClient() {
        }
        
        public MainServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MainServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MainServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MainServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool TestConnection() {
            return base.Channel.TestConnection();
        }
        
        public System.Threading.Tasks.Task<bool> TestConnectionAsync() {
            return base.Channel.TestConnectionAsync();
        }
        
        public BetsClient.MainService.Account GetAccount(int code) {
            return base.Channel.GetAccount(code);
        }
        
        public System.Threading.Tasks.Task<BetsClient.MainService.Account> GetAccountAsync(int code) {
            return base.Channel.GetAccountAsync(code);
        }
        
        public string Deposit(int usercode, decimal sum) {
            return base.Channel.Deposit(usercode, sum);
        }
        
        public System.Threading.Tasks.Task<string> DepositAsync(int usercode, decimal sum) {
            return base.Channel.DepositAsync(usercode, sum);
        }
        
        public string Withdraw(int usercode, decimal sum) {
            return base.Channel.Withdraw(usercode, sum);
        }
        
        public System.Threading.Tasks.Task<string> WithdrawAsync(int usercode, decimal sum) {
            return base.Channel.WithdrawAsync(usercode, sum);
        }
        
        public string MakeBet(int accountId, decimal sum, int eventCode, BetsClient.MainService.BetType type) {
            return base.Channel.MakeBet(accountId, sum, eventCode, type);
        }
        
        public System.Threading.Tasks.Task<string> MakeBetAsync(int accountId, decimal sum, int eventCode, BetsClient.MainService.BetType type) {
            return base.Channel.MakeBetAsync(accountId, sum, eventCode, type);
        }
        
        public BetsClient.MainService.Bet[] GetBets(int code) {
            return base.Channel.GetBets(code);
        }
        
        public System.Threading.Tasks.Task<BetsClient.MainService.Bet[]> GetBetsAsync(int code) {
            return base.Channel.GetBetsAsync(code);
        }
        
        public BetsClient.MainService.Event[] GetEvents() {
            return base.Channel.GetEvents();
        }
        
        public System.Threading.Tasks.Task<BetsClient.MainService.Event[]> GetEventsAsync() {
            return base.Channel.GetEventsAsync();
        }
        
        public BetsClient.MainService.Bet GetBet(int betCode) {
            return base.Channel.GetBet(betCode);
        }
        
        public System.Threading.Tasks.Task<BetsClient.MainService.Bet> GetBetAsync(int betCode) {
            return base.Channel.GetBetAsync(betCode);
        }
    }
}
