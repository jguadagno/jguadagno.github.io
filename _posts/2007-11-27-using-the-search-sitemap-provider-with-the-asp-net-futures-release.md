---
id: 921
title: Using the Search Sitemap Provider with the ASP.NET Futures release
date: 2007-11-27T06:44:16+00:00
author: Joseph Guadagno
layout: post
guid: http://www.josephguadagno.net/post.aspx?id=5cd08332-cf46-4a84-8d58-257440ed7314
permalink: /2007/11/27/using-the-search-sitemap-provider-with-the-asp-net-futures-release/
dsq_thread_id:
  - "3602488251"
categories:
  - Articles
---
### Sitemaps

First off a quick introduction to what a Sitemap is, according to [http://www.sitemaps.org](http://www.sitemaps.org)...

Sitemaps are an easy way for webmasters to inform search engines about pages on their sites that are available for crawling. In its simplest form, a Sitemap is an XML file that lists URLs for a site along with additional metadata about each URL (when it was last updated, how often it usually changes, and how important it is, relative to other URLs in the site) so that search engines can more intelligently crawl the site.

### ASP.NET Futures Release

The ASP.NET futures release can be found at [http://www.asp.net/downloads/futures/](http://www.asp.net/downloads/futures/ "http://www.asp.net/downloads/futures/"). Just a note, as you will see on the futures site, the content in the futures release might not make it to the official ASP.NET Ajax release. The futures release contains functionality that the team is thinking about incorporating into the main ASP.NET release. So this means that you could play with the code and hope that the team incorporates it into ASP.NET Ajax.  Enough with the disclaimer.

[**Download the ASP.NET Futures**  (July 2007) Release](http://go.microsoft.com/fwlink/?LinkID=89147&clcid=0x409)

### Getting Started Search Sitemap Provider

The ASP.NET team created the [SearchSitemapProvider](http://quickstarts.asp.net/Futures/services/doc/searchsitemaps.aspx) as part of the ASP.NET Futures (July 2007) release. The release contains an HttpHandler to process the calls, SearchSiteMaps.axd, which serves up the Sitemap and two providers, AspNetSiteMapSearchSiteMapProvider and DynamicDataSearchSiteMapProvider. The AspNetSiteMapSearchSiteMapProvider will generate a static Sitemap based on the ASP.NET sitemap. The DynamicDataSearchSiteMap provider provides a way to dynamically generate the Sitemap.

To enable Search Sitemaps in your ASP.NET you need to do the following.

* Edit the web.config to add the searchSiteMap section

{% gist jguadagno/19219d043e7237d01e63431227ad3dd8 %}

* Edit the web.config to add the httpHandlers section

{% gist jguadagno/560fea82c58559ee8bc3415d0e56deed %}

A call to [http://www.josephguadagno.net/SearchSiteMaps.axd](http://www.josephguadagno.net/SearchSiteMaps.axd) will produce something like this.

{% gist jguadagno/c1b32f7d84d3911c564568ad9a1b3aa4 %}

This will instruct the search engine that there are at least four sitemaps that are available.  Now the search engine will crawl these four URLs and get the additional URLs that are available. The four sitemaps point to the four providers that are in the web.config file.  The reason for four of them is that one of them is for the fixed navigation tied to the sitemap file, the other three use the dynamic site map provider, one for each type since the classes and data retrieval are different.

### Using the Search Sitemap Provider

#### AspNetSiteMapSearchSiteMapProvider

This provider is the easiest to use and only requires a valid Asp.Net sitemap file. Adding the following line to the searchSiteMap section of the web config file will instruct the provider to load the default asp.net site map.

{% gist jguadagno/05c75cca333fc9548219a6327d7ac21d %}

#### DynamicDataSearchSiteMapProvider

The DynamicDataSearchSiteMapProvider is used when you have dynamic content that you want to submit to the search engines.  Dynamic content is content that is generated on the fly or does not have a fixed URL. As you see in lines 5 - 19 of my searchSiteMap provider's section, I use three different custom providers, Articles, Books and News.  These providers inherit from the DynamicDataSearchSiteMapProvider class which requires that you implement the DataQuery method which returns an IEnumerable interface. I choose to return a List<SiteEntry> objects.

The SiteEntry class supports the following properties (taken straight from the Asp.Net futures site):

* The `targetUrl` property (required) specifies the URL of the page in the sitemap.
* The `targetUrlseparator` property (optional) specifies the seperator between the URL and the data fields. The default is `?`. You can specifiy characters such as `#` or `/`.
* The `queryStringDataFormatString` property (optional) specifies how the data fields are formatted using syntax like that used by the `String.Format` method. If no format is specified, the provider auto-generates a default format string.
* The `queryStringDataFields` property (optional) specifies which columns you want to bind in `targetUrlFormatString`. If the property is not specified, the provider infers the list of column names from the collection returned by the `DataQuery` method.
* The `lastModifiedDataField` property (optional) specifies the column that contains information about the last time the sitemap was modified. This date should be in W3C DateTime format, which allows you to omit the time portion and provide the date in the format YYYY-MM-DD. If the property is not specified, the provider attempts to read a property named `SiteMapLastModified`.
* The `changeFrequencyDataField` property (optional) specifies how frequently the page is likely to change. Valid values are: always, hourly, daily, weekly, monthly, yearly, never. If the property is not specified, the provider attempts to read a property named `SiteMapChangeFrequency`.
* The `priorityDataField` property (optional) specifies the priority of this URL relative to other URLs on your site. Valid values range from 0.0 to 1.0\. If the property is not specified, the provider attempts to read a property named `SiteMapPriority`.
* Set the `pathInfoFormat` property (optional) to `true` if you want to use only the value in the URL (for example, http://site/page.aspx/1)

These properties are used in conjunction with your properties that you want to display in the sitemap. For my search sitemap I use the following fields:

<table class="table table-striped table-bordered">

<thead>

<tr>

<th>Url</th>

<th>Custom Field</th>

</tr>

</thead>

<tbody>

<tr>

<td>SiteMapLastModified</td>

<td>specifies the last time the content changed</td>

</tr>

<tr>

<td>SiteMapChangeFrequency</td>

<td>specifies how often this page is expected to change</td>

</tr>

<tr>

<td>SiteMapPriority</td>

<td>specifies the priority of this Url verses others</td>

</tr>

<tr>

<td>targetUrl</td>

<td>specifies the url that will be used</td>

</tr>

<tr>

<td>targetUrlseparator</td>

<td>specifies the separator between the query string</td>

</tr>

<tr>

<td>queryStringDataFormatString</td>

<td>specifies how the sitemap provider will format the url</td>

</tr>

<tr>

<td>queryStringDataFields</td>

<td>specifies what properties from the SiteEntry object you will use to pass to the queryStringDataFormatString (similiar to the String.Format)</td>

</tr>

</tbody>

</table>

The Url, SiteMapLastModified, SiteMapChangeFrequency, SiteMapPriority properties are set in code and the targetUrl, targetUrlseparator, queryStrignDataFormatString and queryStringDataFields are set in the web config.

So what do all of the there properties mean and do. Well like I mentioned above the DynamicDataSearchSiteMapProvider expects a DataQuery method to be implemented.  This method is expected to return an IEnumerable (collection) of objects. In my case, I return a List<SiteEntry> objects.  My SiteEntry class looks like this.

TODO: Find Image "image2.png"

The ArticleSiteMapData provider looks like this

{% gist jguadagno/34b337441da13dfeb0b11e4fc7103563 %}

Lines 14 - 21 you would replace with your code get your dynamic data.  Lines 19 and 20 is where the SiteEntry object is created and added to the List.

So how does the List<SiteEntry> tie into the provider configuration?  The answer is in the attributes/properties that are defined for provider. For this sample we have targetUrl ="", targetUrlSeparator="/", queryStringDataFormatString="{0}" and queryStringDataFields="Url" this tells the provide to build a string with the base of targetUrl, then add targetUrlSeparator, followed by calling string.format using queryStringDataFormatString with the parameters equal to the value of the properties listed in queryStringDataFields.  In other words the url will look like this.

http://www.yourdomain.com/<value of url field>

In my site, I generate the Url in code so that it will be consistent between different pages.  A "real" world example might look like this.  
Properties: targetUrl ="BookReviews", targetUrlSeparator="/", queryStringDataFormatString="{0}/{1}.aspx" and queryStringDataFields="Id, Title" which would generate a url similar to this.

http://www.yourdomain.com/1/title.aspx

Notice that I had two field in the queryStringDataFields property.  You can list as many as you want, they just need to be comma separated. This means that the SiteEntry object needs to have at least the two properties of Id and Title.

### For more information

That's about it.  I was a lot to read and digest but hopefully useful. If you have any questions, please feel free to contact me or leave a comment or you can discuss the Sitemap provider in the ASP.net [forums](http://forums.asp.net/1127/ShowForum.aspx).

### Search Engines were you can submit a feed

Here some search engine urls where you can submit you site maps.

Google: [https://www.google.com/webmasters/tools/siteoverview](https://www.google.com/webmasters/tools/siteoverview "https://www.google.com/webmasters/tools/siteoverview")

Yahoo: [https://siteexplorer.search.yahoo.com](https://siteexplorer.search.yahoo.com "https://siteexplorer.search.yahoo.com")

[](http://forums.asp.net/1127/ShowForum.aspx)