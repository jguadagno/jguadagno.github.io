---
title: Using Bing Maps Web Services Imagery Service
date: 2010-02-04T18:28:51+00:00
permalink: /2010/02/04/using-bing-maps-web-services-imagery-service/
dsq_thread_id:
  - "3574773621"
categories:
  - Articles
  - Web
tags:
  - Bing
---
In my previous post, [Using the Bing Maps Web Services for Geocoding Addresses]({% post_url 2010-02-04-using-the-bing-maps-web-services-for-geocoding-addresses %}), I talk about geocoding addresses using the Bing Maps Web Services. Now it is time to talk about getting imagery of maps, roads or aerials views for addresses or geocodes. In order to get started using the Bing Maps Web Services, check out the Getting Started section of [Using the Bing Maps Web Services for Geocoding Addresses]({% post_url 2010-02-04-using-the-bing-maps-web-services-for-geocoding-addresses %}).

## Bing Maps Web Services

Bing Maps Web Services is a set of Web services that allow you to add mapping and search functionality to your application, including location finding, map imagery, and routing capabilities. For example, you can: Use the [Imagery Service](http://msdn.microsoft.com/en-us/library/cc981090.aspx) to:

* Return a link to a map with a pushpin at a specific location
* Provide a road map or bird’s eye or aerial imagery to your application

Use the [Route Service](http://msdn.microsoft.com/en-us/library/cc966826.aspx) to:

* Get directions that include traffic warnings and route hints between multiple locations.
* Get directions from all major roads to a destination (1-click directions, also referred to as a "party map") and then use the Imagery Service to map those routes.

For this post, we will cover the Imagery service. Just like the Geocode Service, there is a request, [MapUriRequest](http://msdn.microsoft.com/en-us/library/cc980912.aspx), and response, [MapUriResponse](http://msdn.microsoft.com/en-us/library/cc981042.aspx), object for the Imagery Service. In order to get the Uri to display a map in your application, you will need to use the imagery service client, [ImageryServiceClient](http://msdn.microsoft.com/en-us/library/cc980959.aspx). The ImageryServiceClient needs to be instantiated with the WCF endpoint to use, by default it should be `BasicHttpBinding_IImageryService`. Then call the [GetMapUri](http://msdn.microsoft.com/en-us/library/cc981108.aspx) method passing your [MapUriRequest](http://msdn.microsoft.com/en-us/library/cc980912.aspx) object.

```cs
ImageryServiceClient imageryService =
    new ImageryServiceClient("BasicHttpBinding_IImageryService");
MapUriResponse mapUriResponse = imageryService.GetMapUri(mapUriRequest);
```

### Building the MapUriRequest

The MapUriRequest has two properties that need to be populated; the [Credentials](http://msdn.microsoft.com/en-us/library/cc966923.aspx) property which should contain you Bing Maps Id and either the [Center](http://msdn.microsoft.com/en-us/library/cc966747.aspx), [MajorRoutesDestination](http://msdn.microsoft.com/en-us/library/cc966744.aspx), or [Pushpins](http://msdn.microsoft.com/en-us/library/cc980872.aspx) property.  The code snippet below demonstrates instantiating the MapUriRequest and setting the properties based on values passed into a method (outlined later).

```cs
MapUriRequest mapUriRequest = new MapUriRequest
  {
    Credentials = new Credentials {ApplicationId = appId},
    Pushpins = pushpins,
    Center = new Location {Latitude = latitude, Longitude = longitude}
  };
```

Now you can customize the options for the map using the [MapUriOptions](http://msdn.microsoft.com/en-us/library/cc981074.aspx) property of the MapUriRequest object. Here is a list of the properties from the MSDN [documentation](http://msdn.microsoft.com/en-us/library/cc981033.aspx):

|Property name|Description|Default Value|
|--- |--- |---|
|[DisplayLayers](http://msdn.microsoft.com/en-us/library/cc981085.aspx)|A `string` array indicating the layer data to display on the map.|`null`|
|[ImageSize](http://msdn.microsoft.com/en-us/library/cc966894.aspx)|A [SizeOfint Class](http://msdn.microsoft.com/en-us/library/cc981005.aspx) object specifying the height and width of the image to return.|The default width is 350 and the default height is 350.|
|[ImageType](http://msdn.microsoft.com/en-us/library/cc980869.aspx)|An [ImageType Enumeration](http://msdn.microsoft.com/en-us/library/cc966755.aspx) value specifying the format of the image to return.|The default value is `ImageType.Default`, which means the default changes depending on the map style specified.|
|[PreventIconCollision](http://msdn.microsoft.com/en-us/library/cc981009.aspx)|A `bool` indicating whether or not to separate pushpin icons that are close to each other on the map so that they are more visible.|`false*`|
|[Style](http://msdn.microsoft.com/en-us/library/cc966910.aspx)|A [MapStyle Enumeration](http://msdn.microsoft.com/en-us/library/cc966745.aspx) value specifying the map style of the image to return.|`MapStyle.Road*`|
|[UriScheme](http://msdn.microsoft.com/en-us/library/cc981052.aspx)|A [UriScheme Enumeration](http://msdn.microsoft.com/en-us/library/cc981022.aspx) value specifying the URI scheme to return.|`UriScheme.Http`|
|[ZoomLevel](http://msdn.microsoft.com/en-us/library/cc966900.aspx)|An `int*` indicating the zoom level of the map to return. ||

Assigning some of the options:

```cs
// Set the map options
MapUriOptions mapUriOptions = new MapUriOptions();
mapUriOptions.Style = MapStyle.Road;
mapUriOptions.ZoomLevel = zoom;
mapUriOptions.ImageSize = new SizeOfint {Height = height, Width = width};
// Set the options property of the request.
mapUriRequest.Options = mapUriOptions;
```

Now you are ready to call the image service client to get the MapUriResponse.

``` cs
ImageryServiceClient imageryService =
    new ImageryServiceClient("BasicHttpBinding_IImageryService");
MapUriResponse mapUriResponse = imageryService.GetMapUri(mapUriRequest);
```

Here is a helper class, [Imagery.cs](/assets/downloads/Imagery.cs_.zip),  which wraps the GetMapUri function with 8 different overloads.

#### Working with the MapUriResponse

The MapUriResponse object has three properties:

|Name|Description|
|--- |--- |
|[BrandLogoUri](http://msdn.microsoft.com/en-us/library/ee692183.aspx)|The `System.Uri` of the Bing Maps brand logo image.|
|[ResponseSummary](http://msdn.microsoft.com/en-us/library/cc980964.aspx)|A [ResponseSummary Class](http://msdn.microsoft.com/en-us/library/cc980902.aspx) object describing the response that was returned by the service.|
|[Uri](http://msdn.microsoft.com/en-us/library/cc980931.aspx)|A `string` that is the URI of the requested map.|

For brevity sake, we will just use the `Uri` property.  You should, though, for good programming practices, check the ResponseSummary property for any exceptions.

```cs
string mapUri = Imagery.GetMapUri("YourAppId", 47.62, -122.2);
imgMap.imageUrl = mapUri;
```

![image-right](/assets/images/posts/image_thumb.png "downtown Bellevue"){: .align-right}

This call retrieves the Uri to use to display a 200x200 road map of the area at latitude 47.62 and longitude -122.2 with a zoom of 14, which is downtown Bellevue, WA. If you want to add pushpins or markers similar to the above image you will need to populate the array of [PushPin](http://msdn.microsoft.com/en-us/library/cc966869.aspx) objects. A PushPin object has an [IconStyle](http://msdn.microsoft.com/en-us/library/cc980903.aspx) which is the type of icon to use, a [Label](http://msdn.microsoft.com/en-us/library/cc981045.aspx) which an optional text to display on the pushpin (only works with certain pushpins) and the [Location](http://msdn.microsoft.com/en-us/library/cc966941.aspx) which contains the latitude and longitude that the pushpin should be located at. That’s it.  It seems like a lot of work for a one-line call.  With the attached [Imagery.cs](/assets/downloads/Imagery.cs_.zip) class, a lot of the overhead work was done for you.