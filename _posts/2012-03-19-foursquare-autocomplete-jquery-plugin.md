---
id: 311
title: Foursquare Autocomplete jQuery Plugin
date: 2012-03-19T18:09:00+00:00
author: Joseph Guadagno
layout: post
guid: http://www.josephguadagno.net/post.aspx?id=68d6cf39-79f7-452b-afb5-23042da75abe
permalink: /2012/03/19/foursquare-autocomplete-jquery-plugin/
dsq_thread_id:
  - "3569123846"
categories:
  - Articles
  - Web
tags:
  - Foursquare
  - jQuery
  - jQuery Plugin
  - Plugin
---
<em>This post will go over implementing the foursquare Autocomplete jQuery plugin. In the upcoming days (weeks) I will have a few blog posts on using the foursquare API with C#.</em>

A few months ago I was making updates for the <a title="MVP Summit Events" href="http://www.mvpsummitevents.info" target="_blank">MVP Summit Events</a> site, one of the features I wanted to add was <a href="http://www.foursquare.com" target="_blank">foursquare</a> integration to the site. I was thinking that it would be cool for each of the parties listed on the site, to show how many people have checked in to that event (venue) on foursquare. This way you could see what parties to attend and which ones to avoid :).

In order to determine who was checked in at one of the events, I needed to add the foursquare venue id to all of my venues. For the existing venues, I manually added the foursquare venue id but for new venues I was thinking of making the user experience as easy as possible, a user should enter a few characters and get venues in the area with those characters. The first thing that popped into my head was to use an auto complete control and use foursquare as the data source. So after “Googling it with Bing” I found that there was one control that did this but no longer worked. So what does every good developer do, re-invent the wheel :).
<h2>Getting Started with the foursquare API</h2>
Just like most social media sites now, foursquare has a REST based API. Foursquare provides a <a href="https://developer.foursquare.com/overview/" target="_blank">quick start</a> guide to get you started using their API. In order to get started with the foursquare API you will need the following:
<ul>
	<li>A foursquare account (<em>The site does recommend you create a separate foursquare account for your applications.</em>)</li>
	<li>An <a href="https://developer.foursquare.com/overview/auth" target="_blank">access token</a> for the API</li>
	<li><a href="https://foursquare.com/oauth" target="_blank">Register your application</a>.</li>
</ul>
foursquare does have many API <a href="https://developer.foursquare.com/docs/" target="_blank">end points</a> for accessing their data. After checking out several of them I decided to go with the <a href="https://developer.foursquare.com/docs/venues/suggestcompletion" target="_blank">Suggest Completion Venues</a> end point even though (at the time of this writing it was an experimental feature).
<h3>Suggest Completion End Point</h3>
According to the API end point <a href="https://developer.foursquare.com/docs/venues/suggestcompletion" target="_blank">documentation</a> for the Suggest Completion end point, the end point provides a list of mini-venues partially matching the search term, near the location.

The method uses the HTTP GET verb and has two required parameters; <strong>ll</strong> and <strong>query</strong>. The <strong>ll</strong> parameter which is the latitude and longitude of the users location (or search area) . And the <strong>query</strong> parameter is the string you want to search for. The results that get returned is an array of mini venues (essentially an arrays without a lot of extra properties, just the minimum set required for suggestion.

This was perfect for my needs.
<h2>Creating the plugin</h2>
I decided to go with using the <a href="http://jqueryui.com/demos/autocomplete/" target="_blank">auto complete</a> widget from the <a href="http://jqueryui.com/" target="_blank">jQuery UI</a>, use the suggest completion end point from foursquare and turn it into a jQuery plugin. Unfortunately I have never created a jQuery plugin before, however, I was lucky enough to run across a post from a buddy of mine <a href="http://elijahmanor.com/" target="_blank">Elijah Manor</a> on <a href="http://msdn.microsoft.com/en-us/scriptjunkie/ff608209" target="_blank">How to Create Your Own jQuery Plugin</a>.

After a few hours of fiddling around with the cost from the blog post above I eventually figured it out and got it to work. The resulting control looks like this:

<a href="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/image_8.png"><img style="display: inline; border-width: 0px;" title="image" src="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/image_thumb_7.png" alt="image" width="449" height="286" border="0" /></a>

In order to use the foursquare jQuery auto complete plugin you will need to include on your page, <a href="http://docs.jquery.com/Downloading_jQuery" target="_blank">jQuery</a>, <a href="http://jqueryui.com/download" target="_blank">jQuery UI</a>, one of the jQuery UI <a href="http://jqueryui.com/themeroller/" target="_blank">themes</a> and this plugin.
<div id="scid:F60BB8FA-6F02-4999-8F5E-9DD4E92C4DA7:a480c807-99ec-4f13-a8d1-d5f84cd5d1b4" class="wlWriterEditableSmartContent" style="margin: 0px; display: inline; float: none; padding: 0px;">
<div><a href="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/4sqacplugin.js">4sqacplugin</a></div>
</div>
I’ve also included a sample page to get you started. It has a bunch of styles to make the use of the plugin a little cleaner.

<a href="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/4sqautocomplete.html">4sqautocomplete</a>

Once you have the required files referenced on your page, you can “foursquare auto complete” a textbox by calling the <em>foursquareAutocomplete</em> method as shown here:
[js]
$(&quot;#venue&quot;).foursquareAutocomplete({
  'latitude': 47.22,
  'longitude': -122.2,
  'oauth_token': &quot;your oauth token&quot;,
  'minLength': 3,
  'search': function (event, ui) {
    $('#venue-name').html(ui.item.name);
    $('#venue-id').val(ui.item.id);
    $('#venue-address').html(ui.item.address);
    $('#venue-cityLine').html(ui.item.cityLine);
    $('#venue-icon').attr(&quot;src&quot;, ui.item.photo);
    return false;
  },
  'onError' : function (errorCode, errorType, errorDetail) {
    var message = &quot;Foursquare Error: Code=&quot; + errorCode + 
    &quot;, errorType= &quot; + errorType + 
    &quot;, errorDetail= &quot; + errorDetail;
    log(message);
  }
});
[/js]
<table class="table table-striped"><caption>Properties and Events</caption>
<tbody>
<tr>
<th abbr="Name">Name</th>
<th scope="col" abbr="Description">Description</th>
</tr>
<tr>
<td>latitude</td>
<td>The latitude where you want to look for the venue.</td>
</tr>
<tr>
<td>longitude</td>
<td class="alt">The longitude where you want to look for the venue.</td>
</tr>
<tr>
<td>oauth_token</td>
<td>Your foursquare oauth token.</td>
</tr>
<tr >
<td>minLength</td>
<td class="alt">The minimum length the text should be before you kick off the search.</td>
</tr>
<tr>
<td>search</td>
<td>This event is fired once the user selects a venue from the list.</td>
</tr>
<tr>
<td>onError</td>
<td class="alt">This event is fired if there is an error returned from the foursquare REST API.</td>
</tr>
<tr>
<td>onAjaxError</td>
<td>This event is fired if there is an error making the call to the foursquare REST API.</td>
</tr>
</tbody>
</table>
<h3>Handling the results</h3>
Once a user selects the venue from the list, the search event is raised. The search event has two parameters:
<ul>
	<li>Event: The event</li>
	<li>Item: the foursquare venue that was returned.</li>
</ul>
The item that is returned is a custom object that provides the basic address properties for the venue. The properties combined, will look like a US formatted address and will take into account fields that are not populated in foursquare.

<a href="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/image_9.png"><img style="display: inline; border-width: 0px;" title="image" src="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/image_thumb_8.png" alt="image" width="225" height="84" border="0" /></a>
<table class="table table-striped"><caption>Item properties</caption>
<tbody>
<tr>
<th scope="col" abbr="Property Name">Property Name</th>
<th scope="col" abbr="Description">Description</th>
</tr>
<tr>
<td>name</td>
<td>The name of the venue</td>
</tr>
<tr>
<td>id</td>
<td class="alt">The foursquare venue id</td>
</tr>
<tr>
<td>address</td>
<td>The address line (formatted like a US address) address1, address2</td>
</tr>
<tr>
<td>cityLine</td>
<td class="alt">The city line (formatted like a US address). Chandler, AZ 85286</td>
</tr>
<tr>
<td>photo</td>
<td>The 32 pixel image that foursquare uses for the venue.</td>
</tr>
<tr>
<td>full</td>
<td class="alt">The entire <a href="https://developer.foursquare.com/docs/venues/suggestcompletion" target="_blank">mini-venue</a> response returned from foursquare.</td>
</tr>
</tbody>
</table>
<h2>Conclusion</h2>
It took a while for me to figure out all of the parts needed to create the jQuery plugin but overall I think it was worth it. Again this is my first venture into creating a jQuery plugin, so if it is way off, let me know.