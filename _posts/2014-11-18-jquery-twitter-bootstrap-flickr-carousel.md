---
id: 71
title: jQuery Twitter Bootstrap Flickr Carousel
date: 2014-11-18T16:06:00+00:00
author: Joseph Guadagno
layout: post
guid: http://www.josephguadagno.net/post.aspx?id=b602778e-2882-4348-9931-8c7385e2b733
permalink: /2014/11/18/jquery-twitter-bootstrap-flickr-carousel/
dsq_thread_id:
  - "3582625746"
categories:
  - Web
tags:
  - Bootstrap
  - Carousel
  - Flickr
  - jQuery
  - jQuery Plugin
  - Plugin
  - Twitter Bootstrap
---
A few months ago I built a jQuery plugin that uses the Twitter <a href="http://www.getbootstrap.com" target="_blank">Bootstrap</a> <a href="http://getbootstrap.com/javascript/#carousel" target="_blank">Carousel</a> to cycle through images on <a href="http://www.flickr.com" target="_blank">Flickr</a>. In order to use this plugin you need to get an <a href="https://www.flickr.com/services/api/misc.api_keys.html" target="_blank">Api</a> Key from Flickr and have the following software:
<ul>
	<li>jQuery (v1.8 or higher)</li>
	<li>Twitter Bootstrap (v3.0 or higher)</li>
	<li>Twitter Bootstrap components (v3.0 or higher)</li>
	<li><a href="https://github.com/esimakin/twbs-pagination" target="_blank">twbsPagination</a> (optional)</li>
</ul>
<h3>Sample Usage</h3>

[js]
$('#flickr-carousel').twbsFlickrCarousel(
	{
		tagsToSearchFor: 'mvpsummit,mvp2013,mvp13', 
		flickrApiKey: 'insert your key here', 
		paginationSelector: '#flickr-pagination'
	}
);
[/js]

Download the plugin from GitHub at: <a title="https://github.com/jguadagno/twbs-flickrCarousel" href="https://github.com/jguadagno/twbs-flickrCarousel">https://github.com/jguadagno/twbs-flickrCarousel</a>

See an example of usage at: <a href="http://mvp2014.mvpsummitevents.info/flickr" target="_blank">http://mvp2014.mvpsummitevents.info/flickr</a>