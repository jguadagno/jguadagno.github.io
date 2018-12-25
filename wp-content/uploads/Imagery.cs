using dev.virtualearth.net.webservices.v1.common;
using dev.virtualearth.net.webservices.v1.imagery;

namespace MVPSummitEvents.Web
{
    /// <summary>
    /// Contains helper methods to interact with the Bing Maps Imagery service.
    /// </summary>
    public static class Imagery
    {
        private const double _latitude = 47.62;
        private const double _longitude = -122.2;
        private const int _defaultZoom = 14;
        private const string _defaultMapStyle = "ROAD";
        private const int _defaultWidth = 200;
        private const int _defaultHeight = 200;

        public static string GetMapUri(string appId, double latitude, double longitude, int zoom, string mapStyle, int width, int height, Pushpin[] pushpins)
        {

            MapUriRequest mapUriRequest = new MapUriRequest
                                              {
                                                  Credentials = new Credentials {ApplicationId = appId},
                                                  Pushpins = pushpins,
                                                  Center = new Location {Latitude = latitude, Longitude = longitude}
                                              };

            // Set the map style and zoom level
            MapUriOptions mapUriOptions = new MapUriOptions();

            switch (mapStyle.ToUpper())
            {
                case "HYBRID":
                    mapUriOptions.Style = MapStyle.AerialWithLabels;
                    break;
                case "ROAD":
                    mapUriOptions.Style = MapStyle.Road;
                    break;
                case "AERIAL":
                    mapUriOptions.Style = MapStyle.Aerial;
                    break;
                default:
                    mapUriOptions.Style = MapStyle.Road;
                    break;
            }

            mapUriOptions.ZoomLevel = zoom;

            // Set the size of the requested image to match the size of the image control
            mapUriOptions.ImageSize = new SizeOfint {Height = height, Width = width};

            mapUriRequest.Options = mapUriOptions;

            ImageryServiceClient imageryService = new ImageryServiceClient("BasicHttpBinding_IImageryService");
            MapUriResponse mapUriResponse = imageryService.GetMapUri(mapUriRequest);

            return mapUriResponse.Uri;
        }

        public static string GetMapUri(string appId, double latitude, double longitude, int zoom, string mapStyle, int width, int height)
        {
            return GetMapUri(appId, latitude, longitude, zoom, mapStyle, width, height, null);
        }

        public static string GetMapUri(string appId, int zoom, string mapStyle, int width, int height, Pushpin[] pushpins)
        {
            if (pushpins.Length > 0)
                return GetMapUri(appId, 0, 0, zoom, mapStyle, width, height, pushpins);
            return GetMapUri(appId, _latitude, _longitude, zoom, mapStyle, width, height, pushpins);
        }

        public static string GetMapUri(string appId, Pushpin[] pushpins)
        {
            
            if (pushpins.Length > 0)
                return GetMapUri(appId, pushpins[0].Location.Latitude, pushpins[0].Location.Longitude, _defaultZoom, _defaultMapStyle, _defaultWidth, _defaultHeight, pushpins);
            return GetMapUri(appId, _latitude, _longitude, _defaultZoom, _defaultMapStyle, _defaultWidth, _defaultHeight, pushpins);
        }

        public static string GetMapUri(string appId, double latitude, double longitude)
        {
            return GetMapUri(appId, latitude, longitude, _defaultZoom, _defaultMapStyle, _defaultWidth, _defaultHeight, null);
        }
        
        public static string GetMapUri(string appId, double latitude, double longitude, Pushpin[] pushpins)
        {
            return GetMapUri(appId, latitude, longitude, _defaultZoom, _defaultMapStyle, _defaultWidth, _defaultHeight, pushpins);
        }

        public static string GetMapUri(string appId, double latitude, double longitude, int width, int height, Pushpin[] pushpins)
        {
            return GetMapUri(appId, latitude, longitude, _defaultZoom, _defaultMapStyle, width, height, pushpins);
        }
    }
}
