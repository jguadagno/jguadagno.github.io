---
title: Using the Bing Maps Web Services for Geocoding Addresses
date: 2010-02-04T16:06:53+00:00
permalink: /2010/02/04/using-the-bing-maps-web-services-for-geocoding-addresses/
dsq_thread_id:
  - "3570874323"
categories:
  - Articles
tags:
  - Bing
  - Bing Maps
  - Web
---
For the [MVPSummitEvents](https://www.mvpsummitevents.com/){:target="_blank"} and [Mix10Events](https://www.visitmixevents.info){:target="_blank"} site, I wanted to create a map of all of the events listed on the site. In order to do that I needed to [Geocode](https://en.wikipedia.org/wiki/Geocoding){:target="_blank"} all of the addresses for the events.  There are several services out there for geocoding an address, [Microsoft](https://msdn.microsoft.com/en-us/library/cc966793.aspx?WT.mc_id=DT-MVP-4024623){:target="_blank"}, [Yahoo](https://developer.yahoo.com/maps/rest/V1/geocode.html){:target="_blank"}, and [Google](https://code.google.com/apis/maps/documentation/geocoding/){:target="_blank"} provide this service as well as others.  I decided to go with the Microsoft Bing services, being a [Microsoft MVP](https://mvp.support.microsoft.com/profile=4C0083AE-C0DE-4F05-A179-D9072AF2EA2B){:target="_blank"}.

### Getting Started

Let's get started. MSDN has just about everything you need to [get started](https://msdn.microsoft.com/en-us/library/cc966926.aspx?WT.mc_id=DT-MVP-4024623){:target="_blank"} with using the Bing Map Web Services. Step 1: The first step is to get a key or token to use in your application for the Bing Maps Web Services application. This can be done by visiting the [Bing Maps Account center](https://www.bingmapsportal.com){:target="_blank"} and clicking on **Create a Bing Maps account**. Step 2: If you are using Visual Studio, add a service reference to one or more Bing Maps Web Services that provide the features you need. See the [Generating Client Proxy Classes](https://msdn.microsoft.com/en-us/library/cc980833.aspx?WT.mc_id=DT-MVP-4024623){:target="_blank"} topic and the [Bing Maps Web Services Metadata](https://msdn.microsoft.com/en-us/library/cc966738.aspx?WT.mc_id=DT-MVP-4024623){:target="_blank"} topic.

[![VirtualEarthWebServices](/assets/images/posts/VirtualEarthWebServices_thumb.png "VirtualEarthWebServices")](/assets/images/posts/VirtualEarthWebServices.png)

Whether you used Visual Studio or the `svcutil` application you should have one file, most likely named VirtualEarthWebServices.cs. The file will contain a bunch of wrapper classes around the Bing Maps Web Services, and the required Windows Communication Foundation (WCF) classes. You will also see the generated configuration settings for the app or web config files. Step 3: Set every Bing Maps Web Services request a valid Credentials property. You will see more on this in a bit.

### Geocoding an Address

There are two properties that are required to successfully request a GeoCode for an address.

1. Set the [Credential](https://msdn.microsoft.com/en-us/library/cc966923.aspx?WT.mc_id=DT-MVP-4024623){:target="_blank"} Property of the [GeoCodeRequest](https://msdn.microsoft.com/en-us/library/cc980924.aspx?WT.mc_id=DT-MVP-4024623){:target="_blank"} object
2. Set either the [Query](https://msdn.microsoft.com/en-us/library/cc981130.aspx?WT.mc_id=DT-MVP-4024623){:target="_blank"} property or [Address](https://msdn.microsoft.com/en-us/library/cc966788.aspx?WT.mc_id=DT-MVP-4024623){:target="_blank"} property of the `GeoCodeRequest` object.

Here is a helper function that wraps the call to GeoCodeRequest. This method will return a [GeocodeResponse](https://msdn.microsoft.com/en-us/library/cc980928.aspx?WT.mc_id=DT-MVP-4024623){:target="_blank"} object. The `GeocodeResponse` object contains three properties that are populated based on the query.

|Name|Description|
|--- |--- |
|[BrandLogoUri](https://msdn.microsoft.com/en-us/library/ee692183.aspx?WT.mc_id=DT-MVP-4024623){:target="_blank"}|The `System.Uri` of the Bing Maps brand logo image. (Inherited from the [ResponseBase Class](https://msdn.microsoft.com/en-us/library/cc981076.aspx?WT.mc_id=DT-MVP-4024623){:target="_blank"}.)|
|[ResponseSummary](https://msdn.microsoft.com/en-us/library/cc980964.aspx?WT.mc_id=DT-MVP-4024623){:target="_blank"}|A [ResponseSummary Class](https://msdn.microsoft.com/en-us/library/cc980902.aspx?WT.mc_id=DT-MVP-4024623){:target="_blank"} object describing the response that was returned by the service. (Inherited from the [ResponseBase Class](https://msdn.microsoft.com/en-us/library/cc981076.aspx?WT.mc_id=DT-MVP-4024623){:target="_blank"}.) This class returns any exceptions that we raised during the request.|
|[Results](https://msdn.microsoft.com/en-us/library/cc980800.aspx?WT.mc_id=DT-MVP-4024623){:target="_blank"}|A [GeocodeResult Class](https://msdn.microsoft.com/en-us/library/cc980950.aspx?WT.mc_id=DT-MVP-4024623){:target="_blank"} array, where each element is a possible match returned by the Geocode Service.|

To keep this article short(er) I will just cover the `Results` object. Depending on the Confidence filter and Geocode options that were set in the call you could receive more than one result.

Let's assume that we only want to work with the first result and get the Geocode for “1 Microsoft Way, Redmond, WA”. We simply call the static method of `GetGeocodeResponse` and pass in the Bing Maps API key and the address to search for.

Assuming the address was found we can now work with the properties of the GeocodeResult class to find out the Geocode.  The Geocode is located in the [Locations](https://msdn.microsoft.com/en-us/library/cc966919.aspx?WT.mc_id=DT-MVP-4024623){:target="_blank"} property which is an array of [GeocodeLocation](https://msdn.microsoft.com/en-us/library/cc966778.aspx?WT.mc_id=DT-MVP-4024623){:target="_blank"} objects. If the Count of the Locations is greater than one, let's just take the first one and update the txtLatitude and txtLongitude objects.

That's it. Next up, using the Bing Maps Web Services for getting map images.