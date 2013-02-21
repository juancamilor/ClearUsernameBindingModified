
This project extends the excellent clearusernamebinding project developed by Yaron Navehs
http://webservices20.blogspot.ca/2008/11/introducing-wcf-clearusernamebinding.html

After manually having to adjust the code in different projects connecting to web services implemented in Java, I decided to 
add some minor changes (which some are suggested in Yaron's blog as well) to support:
- enable unsecure responses (configurable)
- include timestamp (configurable)
- set the XmlDictionaryReaderQuotas to the maximum in the code. 

The bindings can be configured:

    <bindings>
      <clearUsernameBinding>
        <binding name=clearUsernameBinding" 
			messageVersion="Soap11" enableUnsecuredResponse="true" includeTimeStamp="true">
        </binding>
      </clearUsernameBinding>
    </bindings>