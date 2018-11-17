# Introduction 
Vantive XML Express for .NET (VXEN) is a .NET based SDK for interacting with the [Vantive XML Express API](https://developer.vantiv.com/community/enterprise/blog/2016/05/11/getting-started-with-vantivs-express-api).

## VXEN.Models   

This namespace is the core value proposition of VXEN.  It provides an object model for interacting with Vantive Express API.

For security and maintainability purposes, the models contain no hand written source code. Instead they are completely generated programatically by downloading XSD schemas from Vantive / WorldPay,  calling XSD.exe to genereate the CS sourse and using CodeDom  to clean up some issues found in the XSD.   This makes it easier to maintain the models and easier to examine the code for security concerns.

More information regarding the API model can be found in the [Express Interface API] documentation
(https://developer.vantiv.com/docs/DOC-1353)

### VXEN.Models.Transaction

This namespace contains classes for the Transaction API.  Examples: typeCreditCardSales and typeCheckSale

### VXEN.Models.Reporting

This namespace contains classes for the Reporting API.  Examples: typeTransactionQuery

### VXEN.Models.Services

This namespace contains classes for the Services API.  Examples: typePaymentAccountCreate typeScheduledTask

## VXEN.Services

VXEN Services is an optional library that provides several classes to assist in developing your application

### VXEN.Services.Session 

Session.Instance() is a static method that provides a Session singleton for easy access to application, credentials, terminal and api URL information anywhere in your application. For security purposes the API URL can only be set once.   Any attempt to change the URL during the life of the application will throw a SecurityException.  While Uri is required to be configured the other properties may be ignored if you are concerned this will make them too exposed within your application.

### VXEN.Services.Serialization

This class provides simple and easy to use Serialize<T> and Deserialize<T> methods for converting your objects to XML and back to objects.   You may end up not using Deserialize<T>() because the Vantive Express API XSD do not contain definitions for the various response messages.    You may end up generating your own classes from XML and in that case you could use Deserialize<T>().  Sanitized XML responses could be contributed back to VXEN for inclusion in dynamically generating additional response classes.    The author of VXEN has not done this because it would be too time consuming  to obtain every possible XML response from the Vantive API.

### VXEN.Services.ResponseHelper

Due to the reponse handling issues detailed in the previous paragraph, a simple LINQ XDocument extension method called GetElementValueFromResponse( string elementName)  was created.  This allows the developer to easily parse out response message fields such as ExpressResponseCode  and ExpressResponseMessage.  

### VXEN.Services.Server

This class provides two methods for posting data to the Vantive Express API.  The SendToAPI method uses synchronous  (System.Net.WebClient) and the SendToAPIAsync uses asynchronous (System.Net.Http.HttpClient) techniques.   Each of those methods have overloads that support both string XML data or <T> generic types with automatic serialization to XML using the Serialization class.     These methods do not require an API Uri as this is automatically obtained from the Session singleton.

## Library Security

Every effort has been made to ensure this library is 100% safe and secure.   A minimalist approach using model generation and no dependencies on other libraries has been used.   While precompiled and digitally signed binaries are easily available from Nuget the consumer of this library is encouraged  to fork this repos, code review every line of source and compile that source to ensure 100% confidence that this library is safe to use.    Developers are also heavily encouraged to file issues to report any concerns or improvements suggestions.    Per the license terms,  use of this software is 100% at your risk. 

Please see our [tutorials](https://github.com/iswix-llc/vxen-tutorials) for more information. (WORK IN PROGRESS)
