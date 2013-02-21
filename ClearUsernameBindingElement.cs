﻿using System;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ComponentModel;
using System.ServiceModel.Configuration;
using System.Globalization;


/*
 * Want more WCF tips?
 * Visit http://webservices20.blogspot.com/
 */



namespace WebServices20.BindingExtenions
{
    class ClearUsernameBindingElement : StandardBindingElement
    {
        private ConfigurationPropertyCollection properties;

        protected override void OnApplyConfiguration(Binding binding)
        {
            ClearUsernameBinding b = binding as ClearUsernameBinding;
            b.SetMessageVersion(MessageVersion);
            b.SetEnableUnsecuredResponse(EnableUnsecuredResponse);
            b.SetIncludeTimeStamp(IncludeTimeStamp);
        }

        protected override Type BindingElementType
        {
            get { return typeof(ClearUsernameBinding); }
        }

        protected override ConfigurationPropertyCollection Properties
        {
            get
            {
                if (this.properties == null)
                {
                    ConfigurationPropertyCollection properties = base.Properties;
                    properties.Add(new ConfigurationProperty("messageVersion", typeof(MessageVersion), MessageVersion.Soap11, new MessageVersionConverter(), null, ConfigurationPropertyOptions.None));
                    properties.Add(new ConfigurationProperty("enableUnsecuredResponse", typeof(bool), false, TypeDescriptor.GetConverter(typeof(bool)), null, ConfigurationPropertyOptions.None));
                    properties.Add(new ConfigurationProperty("includeTimeStamp", typeof(bool), true, TypeDescriptor.GetConverter(typeof(bool)), null, ConfigurationPropertyOptions.None));

                    this.properties = properties;
                }
                return this.properties;
            }
        }
        
        public MessageVersion MessageVersion
        {
            get
            {
                return (MessageVersion)base["messageVersion"];
            }
            set
            {
                base["messageVersion"] = value;
            }
        }

        public bool EnableUnsecuredResponse
        {
            get
            {
                return (bool)base["enableUnsecuredResponse"];
            }
            set
            {
                base["enableUnsecuredResponse"] = value;
            }
        }

        public bool IncludeTimeStamp
        {
            get
            {
                return (bool)base["includeTimeStamp"];
            }
            set
            {
                base["includeTimeStamp"] = value;
            }
        }

    }
}
