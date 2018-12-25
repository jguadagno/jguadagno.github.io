---
id: 601
title: Using the Bing Maps Web Services for Geocoding Addresses
date: 2010-02-04T16:06:53+00:00
author: Joseph Guadagno
layout: post
guid: http://www.josephguadagno.net/post.aspx?id=9e335cce-d734-4c7b-9980-363f5379a152
permalink: /2010/02/04/using-the-bing-maps-web-services-for-geocoding-addresses/
dsq_thread_id:
  - "3570874323"
categories:
  - Articles
  - Web
tags:
  - Bing
  - Bing Maps
---
For the <a href="http://www.mvpsummitevents.com/" target="_blank">MVPSummitEvents</a> and <a href="http://www.visitmixevents.info" target="_blank">Mix10Events</a> site I wanted to create a map of all of the events listed on the site. In order to do that I needed to <a href="http://en.wikipedia.org/wiki/Geocoding" target="_blank">Geocode</a> all of the addresses for the events.  There are several services out there for geocoding an address, <a href="http://msdn.microsoft.com/en-us/library/cc966793.aspx" target="_blank">Microsoft</a>, <a href="http://developer.yahoo.com/maps/rest/V1/geocode.html" target="_blank">Yahoo</a>, and <a href="http://code.google.com/apis/maps/documentation/geocoding/" target="_blank">Google</a> provide this service as well as others.  I decided to go with the Microsoft Bing services, being a <a href="	https://mvp.support.microsoft.com/profile=4C0083AE-C0DE-4F05-A179-D9072AF2EA2B" target="_blank">Microsoft MVP</a>.
<h3>Getting Started</h3>
Let’s get started. MSDN has just about everything you need to <a href="http://msdn.microsoft.com/en-us/library/cc966926.aspx" target="_blank">get started</a> with using the Bing Map Web Services.

Step 1: The first step is to get a key or token to use in your application for the Bing Maps Web Services application. This can be done by visiting the <a href="https://www.bingmapsportal.com" target="_blank">Bing Maps Account center</a> and clicking on <strong>Create a Bing Maps account</strong>.

Step 2: If you are using Visual Studio, add a service reference to one or more Bing Maps Web Services that provide the features you need. See the <a href="http://msdn.microsoft.com/en-us/library/cc980833.aspx">Generating Client Proxy Classes</a> topic and the <a href="http://msdn.microsoft.com/en-us/library/cc966738.aspx">Bing Maps Web Services Metadata</a> topic.

<a href="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/VirtualEarthWebServices.png"><img style="display: inline; margin-left: 0px; margin-right: 0px; border-width: 0px;" title="VirtualEarthWebServices" src="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/VirtualEarthWebServices_thumb.png" alt="VirtualEarthWebServices" width="204" height="306" align="right" border="0" /></a>Whether you used Visual Studio or the svcutil application you should have one file, most likely named VirtualEarthWebServices.cs. The file will contain a bunch of wrapper classes around the Bing Maps Web Services, and the required Windows Communication Foundation (WCF) classes. You will also see the generated configuration settings for the app or web config files.

Step 3: Set every Bing Maps Web Services request a valid Credentials property. You will see more on this in a bit.
<h3>Geocoding an Address</h3>
There are two properties that are required to successfully request a GeoCode for an address.
<ol>
	<li><span style="color: #35383d;">1) Set the <a href="http://msdn.microsoft.com/en-us/library/cc966923.aspx" target="_blank">Credential</a> Property of the <a href="http://msdn.microsoft.com/en-us/library/cc980924.aspx" target="_blank">GeoCodeRequest</a> object</span></li>
	<li><span style="color: #35383d;">2) Set either the <a href="http://msdn.microsoft.com/en-us/library/cc981130.aspx" target="_blank">Query</a> property or <a href="http://msdn.microsoft.com/en-us/library/cc966788.aspx" target="_blank">Address</a> property of the GeoCodeRequest object.</span></li>
</ol>
Here is a helper function that wraps the call to GeoCodeRequest.

<script src="https://gist.github.com/jguadagno/30b818e2495235d208cf74a5e1708a2b.js"></script>

This method will return a <a href="http://msdn.microsoft.com/en-us/library/cc980928.aspx" target="_blank">GeocodeResponse</a> object. The GeocodeResponse object contains three properties that are populated based on the query.
<table class="table table-striped table-bordered">
<thead>
<tr>
<th>Name</td>
<th>Description</td>
</tr>
</thead>
<tbody>
<tr>
<td><a href="http://msdn.microsoft.com/en-us/library/ee692183.aspx">BrandLogoUri</a></td>
<td>The <strong>System.Uri</strong> of the Bing Maps brand logo image. (Inherited from the <a href="http://msdn.microsoft.com/en-us/library/cc981076.aspx">ResponseBase Class</a>.)</td>
</tr>
<tr>
<td><a href="http://msdn.microsoft.com/en-us/library/cc980964.aspx">ResponseSummary</a></td>
<td>A <a href="http://msdn.microsoft.com/en-us/library/cc980902.aspx">ResponseSummary Class</a> object describing the response that was returned by the service. (Inherited from the <a href="http://msdn.microsoft.com/en-us/library/cc981076.aspx">ResponseBase Class</a>.) This class returns any exceptions that we raised during the request.</td>
</tr>
<tr>
<td><a href="http://msdn.microsoft.com/en-us/library/cc980800.aspx">Results</a></td>
<td>A <a href="http://msdn.microsoft.com/en-us/library/cc980950.aspx">GeocodeResult Class</a> array, where each element is a possible match returned by the Geocode Service.</td>
</tr>
</tbody>
</table>

<p>To keep this article short(er) I will just cover the Results object. Depending on the Confidence filter and Geocode options that were set in the call you could receive more than one result.</p>

<p>Let’s assume that we only want to work with the first result and get the Geocode for “1 Microsoft Way, Redmond, WA”. We simply call the static method of GetGeocodeResponse and pass in the Bing Maps API key and the address to search for.</p>

<script src="https://gist.github.com/jguadagno/02618151c37530de544016a93df84b62.js"></script>

<p>Assuming the address was found we can now work with the properties of the GeocodeResult class to find out the Geocode.  The Geocode is located in the <a href="http://msdn.microsoft.com/en-us/library/cc966919.aspx" target="_blank">Locations</a> property which is an array of <a href="http://msdn.microsoft.com/en-us/library/cc966778.aspx" target="_blank">GeocodeLocation</a> objects. If the Count of the Locations is greater than one, let’s just take the first one and update the txtLatitude and txtLongitude objects.</p>

<script src="https://gist.github.com/jguadagno/22564b9e6bbe41f354843b8b4a0c1488.js"></script>

<p>That’s it. Next up, using the Bing Maps Web Services for getting map images.</p>