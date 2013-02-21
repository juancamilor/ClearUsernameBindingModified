using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Xml;

/*
 * Want more WCF tips?
 * Visit http://webservices20.blogspot.com/
 * http://webservices20.blogspot.ca/2008/11/introducing-wcf-clearusernamebinding.html
 */


namespace WebServices20.BindingExtenions
{
    public class ClearUsernameBinding : CustomBinding
    {
        private MessageVersion messageVersion = MessageVersion.None;
        private bool enableUnsecuredResponse = false;
        private bool includeTimeStamp = true;

        public void SetMessageVersion(MessageVersion value)
        {
            this.messageVersion = value;
        }

        public void SetEnableUnsecuredResponse(bool value)
        {
            this.enableUnsecuredResponse = value;
        }

        public void SetIncludeTimeStamp(bool value)
        {
            this.includeTimeStamp = value;
        }

        /// <summary>
        /// Support for configurable security parameters in binding. Changed default reader quotas and message size limits
        /// </summary>
        /// <returns></returns>
        public override BindingElementCollection CreateBindingElements()
        {
            var res = new BindingElementCollection();
            XmlDictionaryReaderQuotas rqMax = XmlDictionaryReaderQuotas.Max;
            TextMessageEncodingBindingElement tb = new TextMessageEncodingBindingElement() 
            { 
                MessageVersion = this.messageVersion 
            };
            rqMax.CopyTo(tb.ReaderQuotas);
            res.Add(tb);

            TransportSecurityBindingElement security = SecurityBindingElement.CreateUserNameOverTransportBindingElement();
            security.IncludeTimestamp = this.includeTimeStamp;
            if (this.enableUnsecuredResponse)
            {
                security.EnableUnsecuredResponse = true;
                security.MessageSecurityVersion = MessageSecurityVersion.WSSecurity11WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11BasicSecurityProfile10;
            }
            res.Add(security);
            res.Add(new AutoSecuredHttpTransportElement());
            return res;
        }

        public override string Scheme
        {
            get
            {
                return "http";
            }
        }
    }
}
