---
id: 591
title: Using Bing Maps Web Services Imagery Service
date: 2010-02-04T18:28:51+00:00
author: Joseph Guadagno
layout: post
guid: http://www.josephguadagno.net/post.aspx?id=831ab94b-55ef-4cb5-b9ce-adde8c9dbc08
permalink: /2010/02/04/using-bing-maps-web-services-imagery-service/
dsq_thread_id:
  - "3574773621"
categories:
  - Articles
  - Web
tags:
  - Bing
---
In my previous post, <a href="http://www.josephguadagno.net/post/Using-the-Bing-Maps-Web-Services-for-Geocoding-Addresses.aspx">Using the Bing Maps Web Services for Geocoding Addresses</a>, I talk about geocoding addresses using the Bing Maps Web Services. Now it is time to talk about getting imagery of maps, roads or aerials views for addresses or geocodes.

In order to get started using the Bing Maps Web Services, check out the previous <a href="http://www.josephguadagno.net/post/Using-the-Bing-Maps-Web-Services-for-Geocoding-Addresses.aspx" target="_blank" rel="noopener">post</a> <strong>Getting Started</strong> section.
<h2>Bing Maps Web Services</h2>
Bing Maps Web Services is a set of Web services that allow you to add mapping and search functionality to your application, including location finding, map imagery, and routing capabilities. For example, you can:

Use the <a href="http://msdn.microsoft.com/en-us/library/cc981090.aspx">Imagery Service</a> to:
<ul>
 	<li>Return a link to a map with a pushpin at a specific location</li>
 	<li>Provide a roadmap or bird’s eye or aerial imagery to your application</li>
</ul>
Use the <a href="http://msdn.microsoft.com/en-us/library/cc966826.aspx">Route Service</a> to:
<ul>
 	<li>Get directions that include traffic warnings and route hints between multiple locations.</li>
 	<li>Get directions from all major roads to a destination (1-click directions, also referred to as a "party map") and then use the Imagery Service to map those routes.</li>
</ul>
For this post, we will cover the Imagery service.

Just like the Geocode Service, there is a request, <a href="http://msdn.microsoft.com/en-us/library/cc980912.aspx" target="_blank" rel="noopener">MapUriRequest</a>, and response, <a href="http://msdn.microsoft.com/en-us/library/cc981042.aspx" target="_blank" rel="noopener">MapUriResponse</a>, object for the Imagery Service.

In order to get the Uri to display a map in your application, you will need to use the imagery service client, <a href="http://msdn.microsoft.com/en-us/library/cc980959.aspx" target="_blank" rel="noopener">ImageryServiceClient</a>. The ImageryServiceClient needs to be instantiated with the WCF endpoint to use, by default it should be ‘<em>BasicHttpBinding_IImageryService’</em>. Then call the <a href="http://msdn.microsoft.com/en-us/library/cc981108.aspx">GetMapUri</a> method passing your <a href="http://msdn.microsoft.com/en-us/library/cc980912.aspx">MapUriRequest</a> object.

<script src="https://gist.github.com/jguadagno/39c9b549d6aa00a379e8e77a613835ec.js"></script>
<h3>Building the MapUriRequest</h3>
The MapUriRequest has two properties that need to be populated; the <a href="http://msdn.microsoft.com/en-us/library/cc966923.aspx">Credentials</a> property which should contain you Bing Maps Id and either the <a href="http://msdn.microsoft.com/en-us/library/cc966747.aspx">Center</a>, <a href="http://msdn.microsoft.com/en-us/library/cc966744.aspx">MajorRoutesDestination</a>, or <a href="http://msdn.microsoft.com/en-us/library/cc980872.aspx">Pushpins</a> property.  The code snippet below demonstrates instantiating the MapUriRequest and setting the properties based on values passed into a method (outlined later).

<script src="https://gist.github.com/jguadagno/e0801cf0401f34894de6baeb860bc1b7.js"></script>

Now you can customize the options for the map using the <a href="http://msdn.microsoft.com/en-us/library/cc981074.aspx">MapUriOptions</a> property of the MapUriRequest object. Here is a list of the properties from the MSDN <a href="http://msdn.microsoft.com/en-us/library/cc981033.aspx">documentation</a>:
<table class="table table-striped table-bordered">
<thead>
<tr>
<th>Property name</th>
<th>Description</th>
</tr>
</thead>
<tbody>
<tr>
<td><a href="http://msdn.microsoft.com/en-us/library/cc981085.aspx">DisplayLayers</a></td>
<td>A <strong>string</strong> array indicating the layer data to display on the map. Optional. The default value is <strong>null</strong>.</td>
</tr>
<tr>
<td><a href="http://msdn.microsoft.com/en-us/library/cc966894.aspx">ImageSize</a></td>
<td>A <a href="http://msdn.microsoft.com/en-us/library/cc981005.aspx">SizeOfint Class</a> object specifying the height and width of the image to return. Optional. The default width is 350 and the default height is 350.</td>
</tr>
<tr>
<td><a href="http://msdn.microsoft.com/en-us/library/cc980869.aspx">ImageType</a></td>
<td>An <a href="http://msdn.microsoft.com/en-us/library/cc966755.aspx">ImageType Enumeration</a> value specifying the format of the image to return. Optional. The default value is <strong>ImageType.Default</strong>, which means the default changes depending on the map style specified.</td>
</tr>
<tr>
<td><a href="http://msdn.microsoft.com/en-us/library/cc981009.aspx">PreventIconCollision</a></td>
<td>A <strong>bool</strong> indicating whether or not to separate pushpin icons that are close to each other on the map so that they are more visible. Optional. The default value is <strong>false</strong>.</td>
</tr>
<tr>
<td><a href="http://msdn.microsoft.com/en-us/library/cc966910.aspx">Style</a></td>
<td>A <a href="http://msdn.microsoft.com/en-us/library/cc966745.aspx">MapStyle Enumeration</a> value specifying the map style of the image to return. Optional. The default value is <strong>MapStyle.Road</strong>.</td>
</tr>
<tr>
<td><a href="http://msdn.microsoft.com/en-us/library/cc981052.aspx">UriScheme</a></td>
<td>A <a href="http://msdn.microsoft.com/en-us/library/cc981022.aspx">UriScheme Enumeration</a> value specifying the URI scheme to return. Optional. The default value is <strong>UriScheme.Http</strong>.</td>
</tr>
<tr>
<td><a href="http://msdn.microsoft.com/en-us/library/cc966900.aspx">ZoomLevel</a></td>
<td>An <strong>int</strong> indicating the zoom level of the map to return. Optional.</td>
</tr>
</tbody>
</table>
Assigning some of the options:

<script src="https://gist.github.com/jguadagno/74f050a310dedcf0b2fadcb3f656d771.js"></script>

Now you are ready to call the image service client to get the MapUriResponse.

<script src="https://gist.github.com/jguadagno/39c9b549d6aa00a379e8e77a613835ec.js"></script>

Here is a helper class, <a href="https://www.josephguadagno.net/wp-content/uploads/2015/03/Imagery.cs_.zip">Imagery.cs</a>,  which wraps the GetMapUri function with 8 different overloads.
<h4>Working with the MapUriResponse</h4>
The MapUriResponse object has three properties:
<table class="table table-striped table-bordered">
<thead>
<tr>
<th>Name</th>
<th>Description</th>
</tr>
</thead>
<tbody>
<tr>
<td><a href="http://msdn.microsoft.com/en-us/library/ee692183.aspx">BrandLogoUri</a></td>
<td>The <strong>System.Uri</strong> of the Bing Maps brand logo image.</td>
</tr>
<tr>
<td><a href="http://msdn.microsoft.com/en-us/library/cc980964.aspx">ResponseSummary</a></td>
<td>A <a href="http://msdn.microsoft.com/en-us/library/cc980902.aspx">ResponseSummary Class</a> object describing the response that was returned by the service.</td>
</tr>
<tr>
<td><a href="http://msdn.microsoft.com/en-us/library/cc980931.aspx">Uri</a></td>
<td>A <strong>string</strong> that is the URI of the requested map.</td>
</tr>
</tbody>
</table>
For brevity sake, we will just use the Uri property.  You should, though, for good programming practices, check the ResponseSummary property for any exceptions.

<script src="https://gist.github.com/jguadagno/0e2777298a2c9637790307f3cc33bc14.js"></script>

This call retrieves the Uri to use to display a 200x200 road map of the area at latitude 47.62 and longitude -122.2 with a zoom of 14, which is downtown Bellevue, WA.

<a href="https://www.josephguadagno.net/wp-content/uploads/2015/03/image.png"><img style="display: inline; border-width: 0px;" title="image" src="https://www.josephguadagno.net/wp-content/uploads/2015/03/image_thumb.png" alt="image" width="198" height="244" border="0" /></a>

If you want to add pushpins or markers similar to the above image you will need to populate the an array of <a href="http://msdn.microsoft.com/en-us/library/cc966869.aspx">PushPin</a> objects. A PushPin object has an <a href="http://msdn.microsoft.com/en-us/library/cc980903.aspx">IconStyle</a> which is the type of icon to use, a <a href="http://msdn.microsoft.com/en-us/library/cc981045.aspx">Label</a> which an optional text to display on the pushpin (only works with certain pushpins) and the <a href="http://msdn.microsoft.com/en-us/library/cc966941.aspx">Location</a> which contains the latitude and longitude that the pushpin should be located at.

That’s it.  It seems like a lot of work for a one line call.  With the attached <a href="https://www.josephguadagno.net/wp-content/uploads/2015/03/Imagery.cs_.zip">Imagery.cs</a> class, a lot of the overhead work was done for you.