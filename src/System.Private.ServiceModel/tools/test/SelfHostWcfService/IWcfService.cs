﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace WcfService
{
    [ServiceContract]
    internal interface IWcfService
    {
        [OperationContract]
        String EchoWithTimeout(String message, TimeSpan serviceOperationTimeout);

        [OperationContract]
        Message MessageRequestReply(Message message);

        [OperationContract(Action = "http://tempuri.org/IWcfService/Echo")]
        String Echo(String message);

        [OperationContract]
        ComplexCompositeType EchoComplex(ComplexCompositeType message);

        [OperationContract]
        [FaultContract(typeof(FaultDetail), Action = "http://tempuri.org/IWcfService/TestFaultFaultDetailFault", Name = "FaultDetail", Namespace = "http://www.contoso.com/wcfnamespace")]
        void TestFault(String faultMsg);

        [OperationContract]
        [FaultContract(typeof(int), Action = "http://tempuri.org/IWcfService/TestFaultIntFault", Name = "IntFault", Namespace = "http://www.contoso.com/wcfnamespace")]
        void TestFaultInt(int faultCode);

        [OperationContract]
        void ThrowInvalidOperationException(string message);

        [OperationContract(Action = "http://tempuri.org/IWcfService/GetDataUsingDataContract")]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract(Action = "http://tempuri.org/IWcfService/ValidateMessagePropertyHeaders")]
        Dictionary<string, string> ValidateMessagePropertyHeaders();

        [OperationContract(Action = "http://tempuri.org/IWcfService/UserGetAuthToken")]
        MahojongTypes.ResultObject<string> UserGetAuthToken(string liveId);

        [OperationContract(Action = "http://tempuri.org/IWcfService/MessageContractRequestReply")]
        ReplyBankingData MessageContractRequestReply(RequestBankingData bt);

        [OperationContract(Action = "http://tempuri.org/IWcfService/MessageContractRequestReplyNotWrapped")]
        ReplyBankingDataNotWrapped MessageContractRequestReplyNotWrapped(RequestBankingData bt);

        [OperationContract(Action = "http://tempuri.org/IWcfService/MessageContractRequestReplyWithMessageHeader")]
        ReplyBankingDataWithMessageHeader MessageContractRequestReplyWithMessageHeader(RequestBankingData bt);

        [OperationContract(Action = "http://tempuri.org/IWcfService/MessageContractRequestReplyWithMessageHeaderNotNecessaryUnderstood")]
        ReplyBankingDataWithMessageHeaderNotNecessaryUnderstood MessageContractRequestReplyWithMessageHeaderNotNecessaryUnderstood(RequestBankingData bt);

        [OperationContract(Action = "http://tempuri.org/IWcfService/EchoHttpMessageProperty")]
        TestHttpRequestMessageProperty EchoHttpRequestMessageProperty();

        [OperationContract(Action = "http://tempuri.org/IWcfService/GetRestartServiceEndpoint")]
        string GetRestartServiceEndpoint();

        [OperationContract(Action = "http://tempuri.org/IWcfService/GetRequestCustomHeader", ReplyAction = "*")]
        string GetRequestCustomHeader(string customHeaderName, string customHeaderNamespace);

        [OperationContract(Action = "http://tempuri.org/IWcfService/GetIncomingMessageHeaders", ReplyAction = "*")]
        Dictionary<string, string> GetIncomingMessageHeaders();

        [OperationContract(Action = "http://tempuri.org/IWcfService/EchoXmlSerializerFormat"), XmlSerializerFormat]
        string EchoXmlSerializerFormat(string message);

        [OperationContract(Action = "http://tempuri.org/IWcfService/EchoXmlSerializerFormatSupportFaults"), XmlSerializerFormat(SupportFaults = true)]
        string EchoXmlSerializerFormatSupportFaults(string message, bool pleaseThrowException);

        [OperationContract(Action = "http://tempuri.org/IWcfService/EchoXmlSerializerFormatUsingRpc"), XmlSerializerFormat(Style = OperationFormatStyle.Rpc)]
        string EchoXmlSerializerFormatUsingRpc(string message);

        [OperationContract(Action = "http://tempuri.org/IWcfService/GetDataUsingXmlSerializer"), XmlSerializerFormat]
        XmlCompositeType GetDataUsingXmlSerializer(XmlCompositeType composite);

        [OperationContract(Action = "http://www.contoso.com/MtcRequest/loginRequest", ReplyAction = "http://www.contoso.com/MtcRequest/loginResponse")]
        [XmlSerializerFormat]
        LoginResponse Login(LoginRequest request);

        [OperationContract]
        Stream GetStreamFromString(string data);

        [OperationContract]
        string GetStringFromStream(Stream stream);

        [OperationContractAttribute(Action = "http://tempuri.org/IWcfService/EchoStream", ReplyAction = "http://tempuri.org/IWcfService/EchoStreamResponse")]
        Stream EchoStream(Stream stream);

        [OperationContract(Action = "http://tempuri.org/IWcfService/EchoMessageParameter")]
        [return: System.ServiceModel.MessageParameterAttribute(Name = "result")]
        string EchoMessageParameter(string name);

        [OperationContract(Action = "http://tempuri.org/IWcfService/EchoItems")]
        [ServiceKnownType(typeof(Widget0))]
        [ServiceKnownType(typeof(Widget1))]
        object[] EchoItems(object[] objects);

        [OperationContract(Action = "http://tempuri.org/IWcfService/EchoItemsXml")]
        [ServiceKnownType(typeof(Widget2))]
        [ServiceKnownType(typeof(Widget3))]
        [XmlSerializerFormat]
        object[] EchoItems_Xml(object[] objects);

        [OperationContract(Action = "http://tempuri.org/IWcfService/EchoXmlVeryComplexType"), XmlSerializerFormat]
        XmlVeryComplexType EchoXmlVeryComplexType(XmlVeryComplexType complex);

        [OperationContract]
        void ReturnContentType(string contentType);
    }
}
