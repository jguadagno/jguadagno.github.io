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
<h3>Sitemaps</h3>

<p>First off a quick introduction to what a Sitemap is, according to <a href="http://www.sitemaps.org">http://www.sitemaps.org</a>...</p>

<p>Sitemaps are an easy way for webmasters to inform search engines about pages on their sites that are available for crawling. In its simplest form, a Sitemap is an XML file that lists URLs for a site along with additional metadata about each URL (when it was last updated, how often it usually changes, and how important it is, relative to other URLs in the site) so that search engines can more intelligently crawl the site.</p>

<h3>ASP.NET Futures Release</h3>

<p>The ASP.NET futures release can be found at <a title="http://www.asp.net/downloads/futures/" href="http://www.asp.net/downloads/futures/">http://www.asp.net/downloads/futures/</a>. Just a note, as you will see on the futures site, the content in the futures release might not make it to the official ASP.NET Ajax release. The futures release contains functionality that the team is thinking about incorporating into the main ASP.NET release. So this means that you could play with the code and hope that the team incorporates it into ASP.NET Ajax.&#xA0; Enough with the disclaimer.</p>

<p><a href="http://go.microsoft.com/fwlink/?LinkID=89147&amp;clcid=0x409"><strong>Download the ASP.NET Futures</strong>&#xA0; (July 2007) Release</a></p>

<h3>Getting Started Search Sitemap Provider</h3>

<p>The ASP.NET team created the <a href="http://quickstarts.asp.net/Futures/services/doc/searchsitemaps.aspx" target="_blank">SearchSitemapProvider</a> as part of the ASP.NET Futures (July 2007) release. The release contains a HttpHandler to process the calls, SearchSiteMaps.axd, which serves up the Sitemap and two providers, AspNetSiteMapSearchSiteMapProvider and DynamicDataSearchSiteMapProvider. The AspNetSiteMapSearchSiteMapProvider will generate a static Sitemap based on the ASP.NET sitemap. The DynamicDataSearchSiteMap provider provides a way to dynamically generate the Sitemap.</p>

<p>To enable Search Sitemaps in your ASP.NET you need to do the following.</p>

<ul>
  <li>Edit the web.config to add the searchSiteMap section </li>
</ul>

<script src="https://gist.github.com/jguadagno/19219d043e7237d01e63431227ad3dd8.js"></script>

<ul>
  <li>Edit the web.config to add the httpHandlers section </li>
</ul>

<script src="https://gist.github.com/jguadagno/560fea82c58559ee8bc3415d0e56deed.js"></script>

<p>A call to <a href="http://www.josephguadagno.net/SearchSiteMaps.axd">http://www.josephguadagno.net/SearchSiteMaps.axd</a> will produce something like this.</p>

<script src="https://gist.github.com/jguadagno/c1b32f7d84d3911c564568ad9a1b3aa4.js"></script>

<p>This will instruct the search engine that there are at least four sitemaps that are available.&#xA0; Now the search engine will crawl these four URLs and get the additional URLs that are available. The four sitemaps point to the four providers that are in the web.config file.&#xA0; The reason for four of them is that one of them is for the fixed navigation tied to the sitemap file, the other three use the dynamic site map provider, one for each type since the classes and data retrieval are different.</p>
<h3>Using the Search Sitemap Provider</h3>

<h4>AspNetSiteMapSearchSiteMapProvider</h4>

<p>This provider is the easiest to use and only requires a valid Asp.Net sitemap file. Adding the following line to the searchSiteMap section of the web config file will instruct the provider to load the default asp.net site map.</p>

<script src="https://gist.github.com/jguadagno/05c75cca333fc9548219a6327d7ac21d.js"></script>

<h4>DynamicDataSearchSiteMapProvider</h4>

<p>The DynamicDataSearchSiteMapProvider is used when you have dynamic content that you want to submit to the search engines.&#xA0; Dynamic content is content that is generated on the fly or does not have a fixed URL. As you see in lines 5 - 19 of my searchSiteMap provider's section, I use three different custom providers, Articles, Books and News.&#xA0; These providers inherit from the DynamicDataSearchSiteMapProvider class which requires that you implement the DataQuery method which returns an IEnumerable interface. I choose to return a List&lt;SiteEntry&gt; objects.</p>

<p>The SiteEntry class supports the following properties (taken straight from the Asp.Net futures site):</p>

<ul>
  <li>The <code>targetUrl</code> property (required) specifies the URL of the page in the sitemap. </li>

  <li>The <code>targetUrlseparator</code> property (optional) specifies the seperator between the URL and the data fields. The default is <code>?</code>. You can specifiy characters such as <code>#</code> or <code>/</code>. </li>

  <li>The <code>queryStringDataFormatString</code> property (optional) specifies how the data fields are formatted using syntax like that used by the <code>String.Format</code> method. If no format is specified, the provider auto-generates a default format string. </li>

  <li>The <code>queryStringDataFields</code> property (optional) specifies which columns you want to bind in <code>targetUrlFormatString</code>. If the property is not specified, the provider infers the list of column names from the collection returned by the <code>DataQuery</code> method. </li>

  <li>The <code>lastModifiedDataField</code> property (optional) specifies the column that contains information about the last time the sitemap was modified. This date should be in W3C DateTime format, which allows you to omit the time portion and provide the date in the format YYYY-MM-DD. If the property is not specified, the provider attempts to read a property named <code>SiteMapLastModified</code>. </li>

  <li>The <code>changeFrequencyDataField</code> property (optional) specifies how frequently the page is likely to change. Valid values are: always, hourly, daily, weekly, monthly, yearly, never. If the property is not specified, the provider attempts to read a property named <code>SiteMapChangeFrequency</code>. </li>

  <li>The <code>priorityDataField</code> property (optional) specifies the priority of this URL relative to other URLs on your site. Valid values range from 0.0 to 1.0. If the property is not specified, the provider attempts to read a property named <code>SiteMapPriority</code>. </li>

  <li>Set the <code>pathInfoFormat</code> property (optional) to <code>true</code> if you want to use only the value in the URL (for example, http://site/page.aspx/1) </li>
</ul>

<p>These properties are used in conjunction with your properties that you want to display in the sitemap. For my search sitemap I use the following fields:</p>

<table class="table table-striped table-bordered">
    <thead>
    <tr>
      <th>Url</th>
      <th>Custom Field</th>
    </tr>
    </thead>
</tbody>
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
</table>

<p>The Url, SiteMapLastModified, SiteMapChangeFrequency, SiteMapPriority properties are set in code and the targetUrl, targetUrlseparator, queryStrignDataFormatString and queryStringDataFields are set in the web config.</p>

<p>So what do all of the there properties mean and do. Well like I mentioned above the DynamicDataSearchSiteMapProvider expects a DataQuery method to be implemented.&#xA0; This method is expected to return an IEnumerable (collection) of objects. In my case, I return a List&lt;SiteEntry&gt; objects.&#xA0; My SiteEntry class looks like this.</p>

<p>TODO: Find Image "image2.png"</p>

<p>The ArticleSiteMapData provider looks like this</p>

<script src="https://gist.github.com/jguadagno/34b337441da13dfeb0b11e4fc7103563.js"></script>

<p>Lines 14 - 21 you would replace with your code get your dynamic data.&#xA0; Lines 19 and 20 is where the SiteEntry object is created and added to the List.</p>

<p>So how does the List&lt;SiteEntry&gt; tie into the provider configuration?&#xA0; The answer is in the attributes/properties that are defined for provider. For this sample we have targetUrl =&quot;&quot;, targetUrlSeparator=&quot;/&quot;, queryStringDataFormatString=&quot;{0}&quot; and queryStringDataFields=&quot;Url&quot; this tells the provide to build a string with the base of targetUrl, then add targetUrlSeparator, followed by calling string.format using queryStringDataFormatString with the parameters equal to the value of the properties listed in queryStringDataFields.&#xA0; In other words the url will look like this.</p>

<p>http://www.yourdomain.com/&lt;value of url field&gt;</p>

<p>In my site, I generate the Url in code so that it will be consistent between different pages.&#xA0; A &quot;real&quot; world example might look like this. 
  <br />Properties: targetUrl =&quot;BookReviews&quot;, targetUrlSeparator=&quot;/&quot;, queryStringDataFormatString=&quot;{0}/{1}.aspx&quot; and queryStringDataFields=&quot;Id, Title&quot; which would generate a url similar to this. </p>

<p>http://www.yourdomain.com/1/title.aspx </p>

<p>Notice that I had two field in the queryStringDataFields property.&#xA0; You can list as many as you want, they just need to be comma separated. This means that the SiteEntry object needs to have at least the two properties of Id and Title.</p>

<h3>For more information</h3>

<p>That's about it.&#xA0; I was a lot to read and digest but hopefully useful. If you have any questions, please feel free to contact me or leave a comment or you can discuss the Sitemap provider in the ASP.net <a href="http://forums.asp.net/1127/ShowForum.aspx" target="_blank">forums</a>. </p>

<h3>Search Engines were you can submit a feed</h3>

<p>Here some search engine urls where you can submit you site maps.</p>
<p>Google: <a title="https://www.google.com/webmasters/tools/siteoverview" href="https://www.google.com/webmasters/tools/siteoverview">https://www.google.com/webmasters/tools/siteoverview</a></p>
<p>Yahoo: <a title="https://siteexplorer.search.yahoo.com" href="https://siteexplorer.search.yahoo.com">https://siteexplorer.search.yahoo.com</a></p>
<p><a href="http://forums.asp.net/1127/ShowForum.aspx"></a></p>