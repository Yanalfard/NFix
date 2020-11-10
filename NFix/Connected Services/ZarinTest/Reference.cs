﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NFix.ZarinTest {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://zarinpal.com/", ConfigurationName="ZarinTest.PaymentGatewayImplementationServicePortType")]
    public interface PaymentGatewayImplementationServicePortType {
        
        [System.ServiceModel.OperationContractAttribute(Action="#PaymentRequest", ReplyAction="*")]
        NFix.ZarinTest.PaymentRequestResponse PaymentRequest(NFix.ZarinTest.PaymentRequestRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="#PaymentRequest", ReplyAction="*")]
        System.Threading.Tasks.Task<NFix.ZarinTest.PaymentRequestResponse> PaymentRequestAsync(NFix.ZarinTest.PaymentRequestRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="#PaymentRequestWithExtra", ReplyAction="*")]
        NFix.ZarinTest.PaymentRequestWithExtraResponse PaymentRequestWithExtra(NFix.ZarinTest.PaymentRequestWithExtraRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="#PaymentRequestWithExtra", ReplyAction="*")]
        System.Threading.Tasks.Task<NFix.ZarinTest.PaymentRequestWithExtraResponse> PaymentRequestWithExtraAsync(NFix.ZarinTest.PaymentRequestWithExtraRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="#PaymentVerification", ReplyAction="*")]
        NFix.ZarinTest.PaymentVerificationResponse PaymentVerification(NFix.ZarinTest.PaymentVerificationRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="#PaymentVerification", ReplyAction="*")]
        System.Threading.Tasks.Task<NFix.ZarinTest.PaymentVerificationResponse> PaymentVerificationAsync(NFix.ZarinTest.PaymentVerificationRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="#PaymentVerificationWithExtra", ReplyAction="*")]
        NFix.ZarinTest.PaymentVerificationWithExtraResponse PaymentVerificationWithExtra(NFix.ZarinTest.PaymentVerificationWithExtraRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="#PaymentVerificationWithExtra", ReplyAction="*")]
        System.Threading.Tasks.Task<NFix.ZarinTest.PaymentVerificationWithExtraResponse> PaymentVerificationWithExtraAsync(NFix.ZarinTest.PaymentVerificationWithExtraRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="#GetUnverifiedTransactions", ReplyAction="*")]
        NFix.ZarinTest.GetUnverifiedTransactionsResponse GetUnverifiedTransactions(NFix.ZarinTest.GetUnverifiedTransactionsRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="#GetUnverifiedTransactions", ReplyAction="*")]
        System.Threading.Tasks.Task<NFix.ZarinTest.GetUnverifiedTransactionsResponse> GetUnverifiedTransactionsAsync(NFix.ZarinTest.GetUnverifiedTransactionsRequest request);
        
        // CODEGEN: Generating message contract since element name MerchantID from namespace http://zarinpal.com/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="#RefreshAuthority", ReplyAction="*")]
        NFix.ZarinTest.RefreshAuthorityResponse RefreshAuthority(NFix.ZarinTest.RefreshAuthorityRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="#RefreshAuthority", ReplyAction="*")]
        System.Threading.Tasks.Task<NFix.ZarinTest.RefreshAuthorityResponse> RefreshAuthorityAsync(NFix.ZarinTest.RefreshAuthorityRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class PaymentRequestRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="PaymentRequest", Namespace="http://zarinpal.com/", Order=0)]
        public NFix.ZarinTest.PaymentRequestRequestBody Body;
        
        public PaymentRequestRequest() {
        }
        
        public PaymentRequestRequest(NFix.ZarinTest.PaymentRequestRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://zarinpal.com/")]
    public partial class PaymentRequestRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string MerchantID;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public int Amount;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string Description;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public string Email;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public string Mobile;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public string CallbackURL;
        
        public PaymentRequestRequestBody() {
        }
        
        public PaymentRequestRequestBody(string MerchantID, int Amount, string Description, string Email, string Mobile, string CallbackURL) {
            this.MerchantID = MerchantID;
            this.Amount = Amount;
            this.Description = Description;
            this.Email = Email;
            this.Mobile = Mobile;
            this.CallbackURL = CallbackURL;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class PaymentRequestResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="PaymentRequestResponse", Namespace="http://zarinpal.com/", Order=0)]
        public NFix.ZarinTest.PaymentRequestResponseBody Body;
        
        public PaymentRequestResponse() {
        }
        
        public PaymentRequestResponse(NFix.ZarinTest.PaymentRequestResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://zarinpal.com/")]
    public partial class PaymentRequestResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int Status;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string Authority;
        
        public PaymentRequestResponseBody() {
        }
        
        public PaymentRequestResponseBody(int Status, string Authority) {
            this.Status = Status;
            this.Authority = Authority;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class PaymentRequestWithExtraRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="PaymentRequestWithExtra", Namespace="http://zarinpal.com/", Order=0)]
        public NFix.ZarinTest.PaymentRequestWithExtraRequestBody Body;
        
        public PaymentRequestWithExtraRequest() {
        }
        
        public PaymentRequestWithExtraRequest(NFix.ZarinTest.PaymentRequestWithExtraRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://zarinpal.com/")]
    public partial class PaymentRequestWithExtraRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string MerchantID;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public int Amount;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string Description;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string AdditionalData;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public string Email;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=5)]
        public string Mobile;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=6)]
        public string CallbackURL;
        
        public PaymentRequestWithExtraRequestBody() {
        }
        
        public PaymentRequestWithExtraRequestBody(string MerchantID, int Amount, string Description, string AdditionalData, string Email, string Mobile, string CallbackURL) {
            this.MerchantID = MerchantID;
            this.Amount = Amount;
            this.Description = Description;
            this.AdditionalData = AdditionalData;
            this.Email = Email;
            this.Mobile = Mobile;
            this.CallbackURL = CallbackURL;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class PaymentRequestWithExtraResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="PaymentRequestWithExtraResponse", Namespace="http://zarinpal.com/", Order=0)]
        public NFix.ZarinTest.PaymentRequestWithExtraResponseBody Body;
        
        public PaymentRequestWithExtraResponse() {
        }
        
        public PaymentRequestWithExtraResponse(NFix.ZarinTest.PaymentRequestWithExtraResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://zarinpal.com/")]
    public partial class PaymentRequestWithExtraResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int Status;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string Authority;
        
        public PaymentRequestWithExtraResponseBody() {
        }
        
        public PaymentRequestWithExtraResponseBody(int Status, string Authority) {
            this.Status = Status;
            this.Authority = Authority;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class PaymentVerificationRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="PaymentVerification", Namespace="http://zarinpal.com/", Order=0)]
        public NFix.ZarinTest.PaymentVerificationRequestBody Body;
        
        public PaymentVerificationRequest() {
        }
        
        public PaymentVerificationRequest(NFix.ZarinTest.PaymentVerificationRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://zarinpal.com/")]
    public partial class PaymentVerificationRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string MerchantID;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string Authority;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public int Amount;
        
        public PaymentVerificationRequestBody() {
        }
        
        public PaymentVerificationRequestBody(string MerchantID, string Authority, int Amount) {
            this.MerchantID = MerchantID;
            this.Authority = Authority;
            this.Amount = Amount;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class PaymentVerificationResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="PaymentVerificationResponse", Namespace="http://zarinpal.com/", Order=0)]
        public NFix.ZarinTest.PaymentVerificationResponseBody Body;
        
        public PaymentVerificationResponse() {
        }
        
        public PaymentVerificationResponse(NFix.ZarinTest.PaymentVerificationResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://zarinpal.com/")]
    public partial class PaymentVerificationResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int Status;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public long RefID;
        
        public PaymentVerificationResponseBody() {
        }
        
        public PaymentVerificationResponseBody(int Status, long RefID) {
            this.Status = Status;
            this.RefID = RefID;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class PaymentVerificationWithExtraRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="PaymentVerificationWithExtra", Namespace="http://zarinpal.com/", Order=0)]
        public NFix.ZarinTest.PaymentVerificationWithExtraRequestBody Body;
        
        public PaymentVerificationWithExtraRequest() {
        }
        
        public PaymentVerificationWithExtraRequest(NFix.ZarinTest.PaymentVerificationWithExtraRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://zarinpal.com/")]
    public partial class PaymentVerificationWithExtraRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string MerchantID;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string Authority;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public int Amount;
        
        public PaymentVerificationWithExtraRequestBody() {
        }
        
        public PaymentVerificationWithExtraRequestBody(string MerchantID, string Authority, int Amount) {
            this.MerchantID = MerchantID;
            this.Authority = Authority;
            this.Amount = Amount;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class PaymentVerificationWithExtraResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="PaymentVerificationWithExtraResponse", Namespace="http://zarinpal.com/", Order=0)]
        public NFix.ZarinTest.PaymentVerificationWithExtraResponseBody Body;
        
        public PaymentVerificationWithExtraResponse() {
        }
        
        public PaymentVerificationWithExtraResponse(NFix.ZarinTest.PaymentVerificationWithExtraResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://zarinpal.com/")]
    public partial class PaymentVerificationWithExtraResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int Status;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public long RefID;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string ExtraDetail;
        
        public PaymentVerificationWithExtraResponseBody() {
        }
        
        public PaymentVerificationWithExtraResponseBody(int Status, long RefID, string ExtraDetail) {
            this.Status = Status;
            this.RefID = RefID;
            this.ExtraDetail = ExtraDetail;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetUnverifiedTransactionsRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetUnverifiedTransactions", Namespace="http://zarinpal.com/", Order=0)]
        public NFix.ZarinTest.GetUnverifiedTransactionsRequestBody Body;
        
        public GetUnverifiedTransactionsRequest() {
        }
        
        public GetUnverifiedTransactionsRequest(NFix.ZarinTest.GetUnverifiedTransactionsRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://zarinpal.com/")]
    public partial class GetUnverifiedTransactionsRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string MerchantID;
        
        public GetUnverifiedTransactionsRequestBody() {
        }
        
        public GetUnverifiedTransactionsRequestBody(string MerchantID) {
            this.MerchantID = MerchantID;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetUnverifiedTransactionsResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetUnverifiedTransactionsResponse", Namespace="http://zarinpal.com/", Order=0)]
        public NFix.ZarinTest.GetUnverifiedTransactionsResponseBody Body;
        
        public GetUnverifiedTransactionsResponse() {
        }
        
        public GetUnverifiedTransactionsResponse(NFix.ZarinTest.GetUnverifiedTransactionsResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://zarinpal.com/")]
    public partial class GetUnverifiedTransactionsResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int Status;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string Authorities;
        
        public GetUnverifiedTransactionsResponseBody() {
        }
        
        public GetUnverifiedTransactionsResponseBody(int Status, string Authorities) {
            this.Status = Status;
            this.Authorities = Authorities;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class RefreshAuthorityRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="RefreshAuthority", Namespace="http://zarinpal.com/", Order=0)]
        public NFix.ZarinTest.RefreshAuthorityRequestBody Body;
        
        public RefreshAuthorityRequest() {
        }
        
        public RefreshAuthorityRequest(NFix.ZarinTest.RefreshAuthorityRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://zarinpal.com/")]
    public partial class RefreshAuthorityRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string MerchantID;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string Authority;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public int ExpireIn;
        
        public RefreshAuthorityRequestBody() {
        }
        
        public RefreshAuthorityRequestBody(string MerchantID, string Authority, int ExpireIn) {
            this.MerchantID = MerchantID;
            this.Authority = Authority;
            this.ExpireIn = ExpireIn;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class RefreshAuthorityResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="RefreshAuthorityResponse", Namespace="http://zarinpal.com/", Order=0)]
        public NFix.ZarinTest.RefreshAuthorityResponseBody Body;
        
        public RefreshAuthorityResponse() {
        }
        
        public RefreshAuthorityResponse(NFix.ZarinTest.RefreshAuthorityResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://zarinpal.com/")]
    public partial class RefreshAuthorityResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int Status;
        
        public RefreshAuthorityResponseBody() {
        }
        
        public RefreshAuthorityResponseBody(int Status) {
            this.Status = Status;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface PaymentGatewayImplementationServicePortTypeChannel : NFix.ZarinTest.PaymentGatewayImplementationServicePortType, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PaymentGatewayImplementationServicePortTypeClient : System.ServiceModel.ClientBase<NFix.ZarinTest.PaymentGatewayImplementationServicePortType>, NFix.ZarinTest.PaymentGatewayImplementationServicePortType {
        
        public PaymentGatewayImplementationServicePortTypeClient() {
        }
        
        public PaymentGatewayImplementationServicePortTypeClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PaymentGatewayImplementationServicePortTypeClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PaymentGatewayImplementationServicePortTypeClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PaymentGatewayImplementationServicePortTypeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        NFix.ZarinTest.PaymentRequestResponse NFix.ZarinTest.PaymentGatewayImplementationServicePortType.PaymentRequest(NFix.ZarinTest.PaymentRequestRequest request) {
            return base.Channel.PaymentRequest(request);
        }
        
        public int PaymentRequest(string MerchantID, int Amount, string Description, string Email, string Mobile, string CallbackURL, out string Authority) {
            NFix.ZarinTest.PaymentRequestRequest inValue = new NFix.ZarinTest.PaymentRequestRequest();
            inValue.Body = new NFix.ZarinTest.PaymentRequestRequestBody();
            inValue.Body.MerchantID = MerchantID;
            inValue.Body.Amount = Amount;
            inValue.Body.Description = Description;
            inValue.Body.Email = Email;
            inValue.Body.Mobile = Mobile;
            inValue.Body.CallbackURL = CallbackURL;
            NFix.ZarinTest.PaymentRequestResponse retVal = ((NFix.ZarinTest.PaymentGatewayImplementationServicePortType)(this)).PaymentRequest(inValue);
            Authority = retVal.Body.Authority;
            return retVal.Body.Status;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<NFix.ZarinTest.PaymentRequestResponse> NFix.ZarinTest.PaymentGatewayImplementationServicePortType.PaymentRequestAsync(NFix.ZarinTest.PaymentRequestRequest request) {
            return base.Channel.PaymentRequestAsync(request);
        }
        
        public System.Threading.Tasks.Task<NFix.ZarinTest.PaymentRequestResponse> PaymentRequestAsync(string MerchantID, int Amount, string Description, string Email, string Mobile, string CallbackURL) {
            NFix.ZarinTest.PaymentRequestRequest inValue = new NFix.ZarinTest.PaymentRequestRequest();
            inValue.Body = new NFix.ZarinTest.PaymentRequestRequestBody();
            inValue.Body.MerchantID = MerchantID;
            inValue.Body.Amount = Amount;
            inValue.Body.Description = Description;
            inValue.Body.Email = Email;
            inValue.Body.Mobile = Mobile;
            inValue.Body.CallbackURL = CallbackURL;
            return ((NFix.ZarinTest.PaymentGatewayImplementationServicePortType)(this)).PaymentRequestAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        NFix.ZarinTest.PaymentRequestWithExtraResponse NFix.ZarinTest.PaymentGatewayImplementationServicePortType.PaymentRequestWithExtra(NFix.ZarinTest.PaymentRequestWithExtraRequest request) {
            return base.Channel.PaymentRequestWithExtra(request);
        }
        
        public int PaymentRequestWithExtra(string MerchantID, int Amount, string Description, string AdditionalData, string Email, string Mobile, string CallbackURL, out string Authority) {
            NFix.ZarinTest.PaymentRequestWithExtraRequest inValue = new NFix.ZarinTest.PaymentRequestWithExtraRequest();
            inValue.Body = new NFix.ZarinTest.PaymentRequestWithExtraRequestBody();
            inValue.Body.MerchantID = MerchantID;
            inValue.Body.Amount = Amount;
            inValue.Body.Description = Description;
            inValue.Body.AdditionalData = AdditionalData;
            inValue.Body.Email = Email;
            inValue.Body.Mobile = Mobile;
            inValue.Body.CallbackURL = CallbackURL;
            NFix.ZarinTest.PaymentRequestWithExtraResponse retVal = ((NFix.ZarinTest.PaymentGatewayImplementationServicePortType)(this)).PaymentRequestWithExtra(inValue);
            Authority = retVal.Body.Authority;
            return retVal.Body.Status;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<NFix.ZarinTest.PaymentRequestWithExtraResponse> NFix.ZarinTest.PaymentGatewayImplementationServicePortType.PaymentRequestWithExtraAsync(NFix.ZarinTest.PaymentRequestWithExtraRequest request) {
            return base.Channel.PaymentRequestWithExtraAsync(request);
        }
        
        public System.Threading.Tasks.Task<NFix.ZarinTest.PaymentRequestWithExtraResponse> PaymentRequestWithExtraAsync(string MerchantID, int Amount, string Description, string AdditionalData, string Email, string Mobile, string CallbackURL) {
            NFix.ZarinTest.PaymentRequestWithExtraRequest inValue = new NFix.ZarinTest.PaymentRequestWithExtraRequest();
            inValue.Body = new NFix.ZarinTest.PaymentRequestWithExtraRequestBody();
            inValue.Body.MerchantID = MerchantID;
            inValue.Body.Amount = Amount;
            inValue.Body.Description = Description;
            inValue.Body.AdditionalData = AdditionalData;
            inValue.Body.Email = Email;
            inValue.Body.Mobile = Mobile;
            inValue.Body.CallbackURL = CallbackURL;
            return ((NFix.ZarinTest.PaymentGatewayImplementationServicePortType)(this)).PaymentRequestWithExtraAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        NFix.ZarinTest.PaymentVerificationResponse NFix.ZarinTest.PaymentGatewayImplementationServicePortType.PaymentVerification(NFix.ZarinTest.PaymentVerificationRequest request) {
            return base.Channel.PaymentVerification(request);
        }
        
        public int PaymentVerification(string MerchantID, string Authority, int Amount, out long RefID) {
            NFix.ZarinTest.PaymentVerificationRequest inValue = new NFix.ZarinTest.PaymentVerificationRequest();
            inValue.Body = new NFix.ZarinTest.PaymentVerificationRequestBody();
            inValue.Body.MerchantID = MerchantID;
            inValue.Body.Authority = Authority;
            inValue.Body.Amount = Amount;
            NFix.ZarinTest.PaymentVerificationResponse retVal = ((NFix.ZarinTest.PaymentGatewayImplementationServicePortType)(this)).PaymentVerification(inValue);
            RefID = retVal.Body.RefID;
            return retVal.Body.Status;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<NFix.ZarinTest.PaymentVerificationResponse> NFix.ZarinTest.PaymentGatewayImplementationServicePortType.PaymentVerificationAsync(NFix.ZarinTest.PaymentVerificationRequest request) {
            return base.Channel.PaymentVerificationAsync(request);
        }
        
        public System.Threading.Tasks.Task<NFix.ZarinTest.PaymentVerificationResponse> PaymentVerificationAsync(string MerchantID, string Authority, int Amount) {
            NFix.ZarinTest.PaymentVerificationRequest inValue = new NFix.ZarinTest.PaymentVerificationRequest();
            inValue.Body = new NFix.ZarinTest.PaymentVerificationRequestBody();
            inValue.Body.MerchantID = MerchantID;
            inValue.Body.Authority = Authority;
            inValue.Body.Amount = Amount;
            return ((NFix.ZarinTest.PaymentGatewayImplementationServicePortType)(this)).PaymentVerificationAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        NFix.ZarinTest.PaymentVerificationWithExtraResponse NFix.ZarinTest.PaymentGatewayImplementationServicePortType.PaymentVerificationWithExtra(NFix.ZarinTest.PaymentVerificationWithExtraRequest request) {
            return base.Channel.PaymentVerificationWithExtra(request);
        }
        
        public int PaymentVerificationWithExtra(string MerchantID, string Authority, int Amount, out long RefID, out string ExtraDetail) {
            NFix.ZarinTest.PaymentVerificationWithExtraRequest inValue = new NFix.ZarinTest.PaymentVerificationWithExtraRequest();
            inValue.Body = new NFix.ZarinTest.PaymentVerificationWithExtraRequestBody();
            inValue.Body.MerchantID = MerchantID;
            inValue.Body.Authority = Authority;
            inValue.Body.Amount = Amount;
            NFix.ZarinTest.PaymentVerificationWithExtraResponse retVal = ((NFix.ZarinTest.PaymentGatewayImplementationServicePortType)(this)).PaymentVerificationWithExtra(inValue);
            RefID = retVal.Body.RefID;
            ExtraDetail = retVal.Body.ExtraDetail;
            return retVal.Body.Status;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<NFix.ZarinTest.PaymentVerificationWithExtraResponse> NFix.ZarinTest.PaymentGatewayImplementationServicePortType.PaymentVerificationWithExtraAsync(NFix.ZarinTest.PaymentVerificationWithExtraRequest request) {
            return base.Channel.PaymentVerificationWithExtraAsync(request);
        }
        
        public System.Threading.Tasks.Task<NFix.ZarinTest.PaymentVerificationWithExtraResponse> PaymentVerificationWithExtraAsync(string MerchantID, string Authority, int Amount) {
            NFix.ZarinTest.PaymentVerificationWithExtraRequest inValue = new NFix.ZarinTest.PaymentVerificationWithExtraRequest();
            inValue.Body = new NFix.ZarinTest.PaymentVerificationWithExtraRequestBody();
            inValue.Body.MerchantID = MerchantID;
            inValue.Body.Authority = Authority;
            inValue.Body.Amount = Amount;
            return ((NFix.ZarinTest.PaymentGatewayImplementationServicePortType)(this)).PaymentVerificationWithExtraAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        NFix.ZarinTest.GetUnverifiedTransactionsResponse NFix.ZarinTest.PaymentGatewayImplementationServicePortType.GetUnverifiedTransactions(NFix.ZarinTest.GetUnverifiedTransactionsRequest request) {
            return base.Channel.GetUnverifiedTransactions(request);
        }
        
        public int GetUnverifiedTransactions(string MerchantID, out string Authorities) {
            NFix.ZarinTest.GetUnverifiedTransactionsRequest inValue = new NFix.ZarinTest.GetUnverifiedTransactionsRequest();
            inValue.Body = new NFix.ZarinTest.GetUnverifiedTransactionsRequestBody();
            inValue.Body.MerchantID = MerchantID;
            NFix.ZarinTest.GetUnverifiedTransactionsResponse retVal = ((NFix.ZarinTest.PaymentGatewayImplementationServicePortType)(this)).GetUnverifiedTransactions(inValue);
            Authorities = retVal.Body.Authorities;
            return retVal.Body.Status;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<NFix.ZarinTest.GetUnverifiedTransactionsResponse> NFix.ZarinTest.PaymentGatewayImplementationServicePortType.GetUnverifiedTransactionsAsync(NFix.ZarinTest.GetUnverifiedTransactionsRequest request) {
            return base.Channel.GetUnverifiedTransactionsAsync(request);
        }
        
        public System.Threading.Tasks.Task<NFix.ZarinTest.GetUnverifiedTransactionsResponse> GetUnverifiedTransactionsAsync(string MerchantID) {
            NFix.ZarinTest.GetUnverifiedTransactionsRequest inValue = new NFix.ZarinTest.GetUnverifiedTransactionsRequest();
            inValue.Body = new NFix.ZarinTest.GetUnverifiedTransactionsRequestBody();
            inValue.Body.MerchantID = MerchantID;
            return ((NFix.ZarinTest.PaymentGatewayImplementationServicePortType)(this)).GetUnverifiedTransactionsAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        NFix.ZarinTest.RefreshAuthorityResponse NFix.ZarinTest.PaymentGatewayImplementationServicePortType.RefreshAuthority(NFix.ZarinTest.RefreshAuthorityRequest request) {
            return base.Channel.RefreshAuthority(request);
        }
        
        public int RefreshAuthority(string MerchantID, string Authority, int ExpireIn) {
            NFix.ZarinTest.RefreshAuthorityRequest inValue = new NFix.ZarinTest.RefreshAuthorityRequest();
            inValue.Body = new NFix.ZarinTest.RefreshAuthorityRequestBody();
            inValue.Body.MerchantID = MerchantID;
            inValue.Body.Authority = Authority;
            inValue.Body.ExpireIn = ExpireIn;
            NFix.ZarinTest.RefreshAuthorityResponse retVal = ((NFix.ZarinTest.PaymentGatewayImplementationServicePortType)(this)).RefreshAuthority(inValue);
            return retVal.Body.Status;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<NFix.ZarinTest.RefreshAuthorityResponse> NFix.ZarinTest.PaymentGatewayImplementationServicePortType.RefreshAuthorityAsync(NFix.ZarinTest.RefreshAuthorityRequest request) {
            return base.Channel.RefreshAuthorityAsync(request);
        }
        
        public System.Threading.Tasks.Task<NFix.ZarinTest.RefreshAuthorityResponse> RefreshAuthorityAsync(string MerchantID, string Authority, int ExpireIn) {
            NFix.ZarinTest.RefreshAuthorityRequest inValue = new NFix.ZarinTest.RefreshAuthorityRequest();
            inValue.Body = new NFix.ZarinTest.RefreshAuthorityRequestBody();
            inValue.Body.MerchantID = MerchantID;
            inValue.Body.Authority = Authority;
            inValue.Body.ExpireIn = ExpireIn;
            return ((NFix.ZarinTest.PaymentGatewayImplementationServicePortType)(this)).RefreshAuthorityAsync(inValue);
        }
    }
}