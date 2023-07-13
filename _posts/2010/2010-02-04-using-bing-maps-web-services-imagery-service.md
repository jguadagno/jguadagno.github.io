---
title: Using Bing Maps Web Services Imagery Service
date: 2010-02-04T18:28:51+00:00
permalink: /2010/02/04/using-bing-maps-web-services-imagery-service/
dsq_thread_id:
  - "3574773621"
categories:
  - Articles
tags:
  - Bing
  - Web
---
In my previous post, [Using the Bing Maps Web Services for Geocoding Addresses]({% post_url 2010/2010-02-04-using-the-bing-maps-web-services-for-geocoding-addresses %}), I talk about geocoding addresses using the Bing Maps Web Services. Now it is time to talk about getting imagery of maps, roads or aerials views for addresses or geocodes. In order to get started using the Bing Maps Web Services, check out the Getting Started section of [Using the Bing Maps Web Services for Geocoding Addresses]({% post_url 2010/2010-02-04-using-the-bing-maps-web-services-for-geocoding-addresses %}).

## Bing Maps Web Services

Bing Maps Web Services is a set of Web services that allow you to add mapping and search functionality to your application, including location finding, map imagery, and routing capabilities. For example, you can: Use the [Imagery Service](https://msdn.microsoft.com/en-us/library/cc981090.aspx?WT.mc_id=DOP-MVP-4024623){:target="_blank"} to:

* Return a link to a map with a pushpin at a specific location
* Provide a road map or bird's eye or aerial imagery to your application

Use the [Route Service](https://msdn.microsoft.com/en-us/library/cc966826.aspx?WT.mc_id=DOP-MVP-4024623){:target="_blank"} to:

* Get directions that include traffic warnings and route hints between multiple locations.
* Get directions from all major roads to a destination (1-click directions, also referred to as a "party map") and then use the Imagery Service to map those routes.

For this post, we will cover the Imagery service. Just like the Geocode Service, there is a request, [MapUriRequest](https://msdn.microsoft.com/en-us/library/cc980912.aspx?WT.mc_id=DOP-MVP-4024623){:target="_blank"}, and response, [MapUriResponse](https://msdn.microsoft.com/en-us/library/cc981042.aspx?WT.mc_id=DOP-MVP-4024623){:target="_blank"}, object for the Imagery Service. In order to get the Uri to display a map in your application, you will need to use the imagery service client, [ImageryServiceClient](https://msdn.microsoft.com/en-us/library/cc980959.aspx?WT.mc_id=DOP-MVP-4024623){:target="_blank"}. The ImageryServiceClient needs to be instantiated with the WCF endpoint to use, by default it should be `BasicHttpBinding_IImageryService`. Then call the [GetMapUri](https://msdn.microsoft.com/en-us/library/cc981108.aspx?WT.mc_id=DOP-MVP-4024623){:target="_blank"} method passing your [MapUriRequest](https://msdn.microsoft.com/en-us/library/cc980912.aspx?WT.mc_id=DOP-MVP-4024623){:target="_blank"} object.

```cs
ImageryServiceClient imageryService =
    new ImageryServiceClient("BasicHttpBinding_IImageryService");
MapUriResponse mapUriResponse = imageryService.GetMapUri(mapUriRequest);
```

### Building the MapUriRequest

The MapUriRequest has two properties that need to be populated; the [Credentials](https://msdn.microsoft.com/en-us/library/cc966923.aspx?WT.mc_id=DOP-MVP-4024623){:target="_blank"} property which should contain you Bing Maps Id and either the [Center](https://msdn.microsoft.com/en-us/library/cc966747.aspx?WT.mc_id=DOP-MVP-4024623){:target="_blank"}, [MajorRoutesDestination](https://msdn.microsoft.com/en-us/library/cc966744.aspx?WT.mc_id=DOP-MVP-4024623){:target="_blank"}, or [Pushpins](https://msdn.microsoft.com/en-us/library/cc980872.aspx?WT.mc_id=DOP-MVP-4024623){:target="_blank"} property.  The code snippet below demonstrates instantiating the MapUriRequest and setting the properties based on values passed into a method (outlined later).

```cs
MapUriRequest mapUriRequest = new MapUriRequest
  {
    Credentials = new Credentials {ApplicationId = appId},
    Pushpins = pushpins,
    Center = new Location {Latitude = latitude, Longitude = longitude}
  };
```

Now you can customize the options for the map using the [MapUriOptions](https://msdn.microsoft.com/en-us/library/cc981074.aspx?WT.mc_id=DOP-MVP-4024623){:target="_blank"} property of the MapUriRequest object. Here is a list of the properties from the MSDN [documentation](https://msdn.microsoft.com/en-us/library/cc981033.aspx?WT.mc_id=DOP-MVP-4024623){:target="_blank"}:

|Property name|Description|Default Value|
|--- |--- |---|
|[DisplayLayers](https://msdn.microsoft.com/en-us/library/cc981085.asp?WT.mc_id=DOP-MVP-4024623x){:target="_blank"}|A `string` array indicating the layer data to display on the map.|`null`|
|[ImageSize](https://msdn.microsoft.com/en-us/library/cc966894.aspx?WT.mc_id=DOP-MVP-4024623){:target="_blank"}|A [SizeOfint Class](https://msdn.microsoft.com/en-us/library/cc981005.aspx?WT.mc_id=DOP-MVP-4024623){:target="_blank"} object specifying the height and width of the image to return.|The default width is 350 and the default height is 350.|
|[ImageType](https://msdn.microsoft.com/en-us/library/cc980869.aspx?WT.mc_id=DOP-MVP-4024623){:target="_blank"}|An [ImageType Enumeration](https://msdn.microsoft.com/en-us/library/cc966755.aspx?WT.mc_id=DOP-MVP-4024623){:target="_blank"} value specifying the format of the image to return.|The default value is `ImageType.Default`, which means the default changes depending on the map style specified.|
|[PreventIconCollision](https://msdn.microsoft.com/en-us/library/cc981009.aspx?WT.mc_id=DOP-MVP-4024623){:target="_blank"}|A `bool` indicating whether or not to separate pushpin icons that are close to each other on the map so that they are more visible.|`false*`|
|[Style](https://msdn.microsoft.com/en-us/library/cc966910.aspx?WT.mc_id=DOP-MVP-4024623){:target="_blank"}|A [MapStyle Enumeration](https://msdn.microsoft.com/en-us/library/cc966745.aspx?WT.mc_id=DOP-MVP-4024623){:target="_blank"} value specifying the map style of the image to return.|`MapStyle.Road*`|
|[UriScheme](https://msdn.microsoft.com/en-us/library/cc981052.aspx?WT.mc_id=DOP-MVP-4024623){:target="_blank"}|A [UriScheme Enumeration](https://msdn.microsoft.com/en-us/library/cc981022.aspx?WT.mc_id=DOP-MVP-4024623){:target="_blank"} value specifying the URI scheme to return.|`UriScheme.Http`|
|[ZoomLevel](https://msdn.microsoft.com/en-us/library/cc966900.aspx?WT.mc_id=DOP-MVP-4024623){:target="_blank"}|An `int*` indicating the zoom level of the map to return. ||

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
|[BrandLogoUri](https://msdn.microsoft.com/en-us/library/ee692183.aspx?WT.mc_id=DOP-MVP-4024623){:target="_blank"}|The `System.Uri` of the Bing Maps brand logo image.|
|[ResponseSummary](https://msdn.microsoft.com/en-us/library/cc980964.aspx?WT.mc_id=DOP-MVP-4024623){:target="_blank"}|A [ResponseSummary Class](https://msdn.microsoft.com/en-us/library/cc980902.aspx?WT.mc_id=DOP-MVP-4024623){:target="_blank"} object describing the response that was returned by the service.|
|[Uri](https://msdn.microsoft.com/en-us/library/cc980931.aspx?WT.mc_id=DOP-MVP-4024623){:target="_blank"}|A `string` that is the URI of the requested map.|

For brevity sake, we will just use the `Uri` property.  You should, though, for good programming practices, check the ResponseSummary property for any exceptions.

```cs
string mapUri = Imagery.GetMapUri("YourAppId", 47.62, -122.2);
imgMap.imageUrl = mapUri;
```

![image-right](/assets/images/posts/image_thumb.png "downtown Bellevue"){: .align-right}

This call retrieves the Uri to use to display a 200x200 road map of the area at latitude 47.62 and longitude -122.2 with a zoom of 14, which is downtown Bellevue, WA. If you want to add pushpins or markers similar to the above image you will need to populate the array of [PushPin](https://msdn.microsoft.com/en-us/library/cc966869.aspx?WT.mc_id=DOP-MVP-4024623){:target="_blank"} objects. A PushPin object has an [IconStyle](https://msdn.microsoft.com/en-us/library/cc980903.aspx?WT.mc_id=DOP-MVP-4024623){:target="_blank"} which is the type of icon to use, a [Label](https://msdn.microsoft.com/en-us/library/cc981045.aspx?WT.mc_id=DOP-MVP-4024623){:target="_blank"} which an optional text to display on the pushpin (only works with certain pushpins) and the [Location](https://msdn.microsoft.com/en-us/library/cc966941.aspx?WT.mc_id=DOP-MVP-4024623){:target="_blank"} which contains the latitude and longitude that the pushpin should be located at. That's it.  It seems like a lot of work for a one-line call.  With the attached [Imagery.cs](/assets/downloads/Imagery.cs_.zip) class, a lot of the overhead work was done for you.
