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
<!-- TODO: Fix Table, HTML, Links to content -->
In my previous post, [Using the Bing Maps Web Services for Geocoding Addresses](http://www.josephguadagno.net/post/Using-the-Bing-Maps-Web-Services-for-Geocoding-Addresses.aspx), I talk about geocoding addresses using the Bing Maps Web Services. Now it is time to talk about getting imagery of maps, roads or aerials views for addresses or geocodes. In order to get started using the Bing Maps Web Services, check out the previous [post](http://www.josephguadagno.net/post/Using-the-Bing-Maps-Web-Services-for-Geocoding-Addresses.aspx) **Getting Started** section.

## Bing Maps Web Services

Bing Maps Web Services is a set of Web services that allow you to add mapping and search functionality to your application, including location finding, map imagery, and routing capabilities. For example, you can: Use the [Imagery Service](http://msdn.microsoft.com/en-us/library/cc981090.aspx) to:

* Return a link to a map with a pushpin at a specific location
* Provide a roadmap or bird’s eye or aerial imagery to your application

Use the [Route Service](http://msdn.microsoft.com/en-us/library/cc966826.aspx) to:

* Get directions that include traffic warnings and route hints between multiple locations.
* Get directions from all major roads to a destination (1-click directions, also referred to as a "party map") and then use the Imagery Service to map those routes.

For this post, we will cover the Imagery service. Just like the Geocode Service, there is a request, [MapUriRequest](http://msdn.microsoft.com/en-us/library/cc980912.aspx), and response, [MapUriResponse](http://msdn.microsoft.com/en-us/library/cc981042.aspx), object for the Imagery Service. In order to get the Uri to display a map in your application, you will need to use the imagery service client, [ImageryServiceClient](http://msdn.microsoft.com/en-us/library/cc980959.aspx). The ImageryServiceClient needs to be instantiated with the WCF endpoint to use, by default it should be ‘_BasicHttpBinding_IImageryService’_. Then call the [GetMapUri](http://msdn.microsoft.com/en-us/library/cc981108.aspx) method passing your [MapUriRequest](http://msdn.microsoft.com/en-us/library/cc980912.aspx) object.

{% gist jguadagno/39c9b549d6aa00a379e8e77a613835ec %}

### Building the MapUriRequest

The MapUriRequest has two properties that need to be populated; the [Credentials](http://msdn.microsoft.com/en-us/library/cc966923.aspx) property which should contain you Bing Maps Id and either the [Center](http://msdn.microsoft.com/en-us/library/cc966747.aspx), [MajorRoutesDestination](http://msdn.microsoft.com/en-us/library/cc966744.aspx), or [Pushpins](http://msdn.microsoft.com/en-us/library/cc980872.aspx) property.  The code snippet below demonstrates instantiating the MapUriRequest and setting the properties based on values passed into a method (outlined later).

{% gist jguadagno/e0801cf0401f34894de6baeb860bc1b7 %}

Now you can customize the options for the map using the [MapUriOptions](http://msdn.microsoft.com/en-us/library/cc981074.aspx) property of the MapUriRequest object. Here is a list of the properties from the MSDN [documentation](http://msdn.microsoft.com/en-us/library/cc981033.aspx):

<table class="table table-striped table-bordered">

<thead>

<tr>

<th>Property name</th>

<th>Description</th>

</tr>

</thead>

<tbody>

<tr>

<td>[DisplayLayers](http://msdn.microsoft.com/en-us/library/cc981085.aspx)</td>

<td>A **string** array indicating the layer data to display on the map. Optional. The default value is **null**.</td>

</tr>

<tr>

<td>[ImageSize](http://msdn.microsoft.com/en-us/library/cc966894.aspx)</td>

<td>A [SizeOfint Class](http://msdn.microsoft.com/en-us/library/cc981005.aspx) object specifying the height and width of the image to return. Optional. The default width is 350 and the default height is 350.</td>

</tr>

<tr>

<td>[ImageType](http://msdn.microsoft.com/en-us/library/cc980869.aspx)</td>

<td>An [ImageType Enumeration](http://msdn.microsoft.com/en-us/library/cc966755.aspx) value specifying the format of the image to return. Optional. The default value is **ImageType.Default**, which means the default changes depending on the map style specified.</td>

</tr>

<tr>

<td>[PreventIconCollision](http://msdn.microsoft.com/en-us/library/cc981009.aspx)</td>

<td>A **bool** indicating whether or not to separate pushpin icons that are close to each other on the map so that they are more visible. Optional. The default value is **false**.</td>

</tr>

<tr>

<td>[Style](http://msdn.microsoft.com/en-us/library/cc966910.aspx)</td>

<td>A [MapStyle Enumeration](http://msdn.microsoft.com/en-us/library/cc966745.aspx) value specifying the map style of the image to return. Optional. The default value is **MapStyle.Road**.</td>

</tr>

<tr>

<td>[UriScheme](http://msdn.microsoft.com/en-us/library/cc981052.aspx)</td>

<td>A [UriScheme Enumeration](http://msdn.microsoft.com/en-us/library/cc981022.aspx) value specifying the URI scheme to return. Optional. The default value is **UriScheme.Http**.</td>

</tr>

<tr>

<td>[ZoomLevel](http://msdn.microsoft.com/en-us/library/cc966900.aspx)</td>

<td>An **int** indicating the zoom level of the map to return. Optional.</td>

</tr>

</tbody>

</table>

Assigning some of the options: 

{% gist jguadagno/74f050a310dedcf0b2fadcb3f656d771 %}

Now you are ready to call the image service client to get the MapUriResponse.

{ gist jguadagno/39c9b549d6aa00a379e8e77a613835ec %}

Here is a helper class, [Imagery.cs](https://www.josephguadagno.net/wp-content/uploads/2015/03/Imagery.cs_.zip),  which wraps the GetMapUri function with 8 different overloads.

#### Working with the MapUriResponse

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

<td>[BrandLogoUri](http://msdn.microsoft.com/en-us/library/ee692183.aspx)</td>

<td>The **System.Uri** of the Bing Maps brand logo image.</td>

</tr>

<tr>

<td>[ResponseSummary](http://msdn.microsoft.com/en-us/library/cc980964.aspx)</td>

<td>A [ResponseSummary Class](http://msdn.microsoft.com/en-us/library/cc980902.aspx) object describing the response that was returned by the service.</td>

</tr>

<tr>

<td>[Uri](http://msdn.microsoft.com/en-us/library/cc980931.aspx)</td>

<td>A **string** that is the URI of the requested map.</td>

</tr>

</tbody>

</table>

For brevity sake, we will just use the Uri property.  You should, though, for good programming practices, check the ResponseSummary property for any exceptions.

{% gist  jguadagno/0e2777298a2c9637790307f3cc33bc14 %}

This call retrieves the Uri to use to display a 200x200 road map of the area at latitude 47.62 and longitude -122.2 with a zoom of 14, which is downtown Bellevue, WA. [![image](https://www.josephguadagno.net/wp-content/uploads/2015/03/image_thumb.png "image")](https://www.josephguadagno.net/wp-content/uploads/2015/03/image.png) If you want to add pushpins or markers similar to the above image you will need to populate the array of [PushPin](http://msdn.microsoft.com/en-us/library/cc966869.aspx) objects. A PushPin object has an [IconStyle](http://msdn.microsoft.com/en-us/library/cc980903.aspx) which is the type of icon to use, a [Label](http://msdn.microsoft.com/en-us/library/cc981045.aspx) which an optional text to display on the pushpin (only works with certain pushpins) and the [Location](http://msdn.microsoft.com/en-us/library/cc966941.aspx) which contains the latitude and longitude that the pushpin should be located at. That’s it.  It seems like a lot of work for a one-line call.  With the attached [Imagery.cs](https://www.josephguadagno.net/wp-content/uploads/2015/03/Imagery.cs_.zip) class, a lot of the overhead work was done for you.