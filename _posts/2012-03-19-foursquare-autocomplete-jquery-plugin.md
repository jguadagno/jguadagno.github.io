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
_This post will go over implementing the foursquare Autocomplete jQuery plugin. In the upcoming days (weeks) I will have a few blog posts on using the foursquare API with C#._ A few months ago I was making updates for the [MVP Summit Events](http://www.mvpsummitevents.info "MVP Summit Events") site, one of the features I wanted to add was [foursquare](http://www.foursquare.com) integration to the site. I was thinking that it would be cool for each of the parties listed on the site, to show how many people have checked in to that event (venue) on foursquare. This way you could see what parties to attend and which ones to avoid :). In order to determine who was checked in at one of the events, I needed to add the foursquare venue id to all of my venues. For the existing venues, I manually added the foursquare venue id but for new venues I was thinking of making the user experience as easy as possible, a user should enter a few characters and get venues in the area with those characters. The first thing that popped into my head was to use an auto complete control and use foursquare as the data source. So after “Googling it with Bing” I found that there was one control that did this but no longer worked. So what does every good developer do, re-invent the wheel :).

## Getting Started with the foursquare API

Just like most social media sites now, foursquare has a REST based API. Foursquare provides a [quick start](https://developer.foursquare.com/overview/) guide to get you started using their API. In order to get started with the foursquare API you will need the following:

* A foursquare account (_The site does recommend you create a separate foursquare account for your applications._)
* An [access token](https://developer.foursquare.com/overview/auth) for the API
* [Register your application](https://foursquare.com/oauth).

foursquare does have many API [end points](https://developer.foursquare.com/docs/) for accessing their data. After checking out several of them I decided to go with the [Suggest Completion Venues](https://developer.foursquare.com/docs/venues/suggestcompletion) end point even though (at the time of this writing it was an experimental feature).

### Suggest Completion End Point

According to the API end point [documentation](https://developer.foursquare.com/docs/venues/suggestcompletion) for the Suggest Completion end point, the end point provides a list of mini-venues partially matching the search term, near the location. The method uses the HTTP GET verb and has two required parameters; **ll** and **query**. The **ll** parameter which is the latitude and longitude of the users location (or search area) . And the **query** parameter is the string you want to search for. The results that get returned is an array of mini venues (essentially an arrays without a lot of extra properties, just the minimum set required for suggestion. This was perfect for my needs.

## Creating the plugin

I decided to go with using the [auto complete](http://jqueryui.com/demos/autocomplete/) widget from the [jQuery UI](http://jqueryui.com/), use the suggest completion end point from foursquare and turn it into a jQuery plugin. Unfortunately I have never created a jQuery plugin before, however, I was lucky enough to run across a post from a buddy of mine [Elijah Manor](http://elijahmanor.com/) on [How to Create Your Own jQuery Plugin](http://msdn.microsoft.com/en-us/scriptjunkie/ff608209). After a few hours of fiddling around with the cost from the blog post above I eventually figured it out and got it to work. The resulting control looks like this: [![image](http://1222-7915.el-alt.com/wp-content/uploads/2015/03/image_thumb_7.png "image")](http://1222-7915.el-alt.com/wp-content/uploads/2015/03/image_8.png) In order to use the foursquare jQuery auto complete plugin you will need to include on your page, [jQuery](http://docs.jquery.com/Downloading_jQuery), [jQuery UI](http://jqueryui.com/download), one of the jQuery UI [themes](http://jqueryui.com/themeroller/) and this plugin.

<div id="scid:F60BB8FA-6F02-4999-8F5E-9DD4E92C4DA7:a480c807-99ec-4f13-a8d1-d5f84cd5d1b4" class="wlWriterEditableSmartContent" style="margin: 0px; display: inline; float: none; padding: 0px;">

<div>[4sqacplugin](http://1222-7915.el-alt.com/wp-content/uploads/2015/03/4sqacplugin.js)</div>

</div>

I’ve also included a sample page to get you started. It has a bunch of styles to make the use of the plugin a little cleaner. [4sqautocomplete](http://1222-7915.el-alt.com/wp-content/uploads/2015/03/4sqautocomplete.html) Once you have the required files referenced on your page, you can “foursquare auto complete” a textbox by calling the _foursquareAutocomplete_ method as shown here: 

{% gist jguadagno/7085cd501a06de41197578b827628cd8 %}

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

<tr>

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

### Handling the results

Once a user selects the venue from the list, the search event is raised. The search event has two parameters:

* Event: The event
* Item: the foursquare venue that was returned.

The item that is returned is a custom object that provides the basic address properties for the venue. The properties combined, will look like a US formatted address and will take into account fields that are not populated in foursquare. [![image](http://1222-7915.el-alt.com/wp-content/uploads/2015/03/image_thumb_8.png "image")](http://1222-7915.el-alt.com/wp-content/uploads/2015/03/image_9.png)

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

<td class="alt">The entire [mini-venue](https://developer.foursquare.com/docs/venues/suggestcompletion) response returned from foursquare.</td>

</tr>

</tbody>

</table>

## Conclusion

It took a while for me to figure out all of the parts needed to create the jQuery plugin but overall I think it was worth it. Again this is my first venture into creating a jQuery plugin, so if it is way off, let me know.