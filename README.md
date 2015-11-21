A url shortner service using ASP.Net WebApi
===========================================

Components:
----------
- Front end : HTML/JS or client console app
  - HTML, JS, jQuery
  - Testing: Fiddler, Chrome debugger
- Mid-tier webservice: ASP.Net Restful WebApi
  - PUT: input: long url, output: short url
  - GET: input: short url, output: using short url redirect to actual url.
  - Validation: validate given inputs are correct.
  - Algorithm/Data Structure:
    - Convert the long url into a key of configured length (withour hash collition)
    - Append the key to the service url (example: https://app.windows.azure.net/urlkey)
    - Add the short key and the long url as key/value pair to the Hashtable data structure.
- Backend: file system or nosql
- Deployment to cloud

API's:
-----
[HttpRequest.PUT]
public string CrunchUrl(string url){
}

[HttpRequest.Get]
public void RedirectUrl(string shortKey){
  // get the long url from hashtable using the input shortKey
  // redirect to the long url
}

