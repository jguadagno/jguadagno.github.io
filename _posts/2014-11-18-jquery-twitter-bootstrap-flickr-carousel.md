---
title: jQuery Twitter Bootstrap Flickr Carousel
date: 2014-11-18T16:06:00+00:00
permalink: /2014/11/18/jquery-twitter-bootstrap-flickr-carousel/
dsq_thread_id:
  - "3582625746"
categories:
  - Articles
tags:
  - Bootstrap
  - Carousel
  - Flickr
  - jQuery
  - jQuery Plugin
  - Plugin
  - Twitter Bootstrap
  - Web
---
A few months ago I built a jQuery plugin that uses the Twitter [Bootstrap](http://www.getbootstrap.com) [Carousel](http://getbootstrap.com/javascript/#carousel) to cycle through images on [Flickr](http://www.flickr.com). In order to use this plugin you need to get an [Api](https://www.flickr.com/services/api/misc.api_keys.html) Key from Flickr and have the following software:

* jQuery (v1.8 or higher)
* Twitter Bootstrap (v3.0 or higher)
* Twitter Bootstrap components (v3.0 or higher)
* [twbsPagination](https://github.com/esimakin/twbs-pagination) (optional)

## Sample Usage

```js
$('#flickr-carousel').twbsFlickrCarousel(
  {
    tagsToSearchFor: 'mvpsummit,mvp2013,mvp13',
    flickrApiKey: 'insert your key here',
    paginationSelector: '#flickr-pagination'
  }
);
```

Download the plugin from GitHub at: [https://github.com/jguadagno/twbs-flickrCarousel](https://github.com/jguadagno/twbs-flickrCarousel "https://github.com/jguadagno/twbs-flickrCarousel")

See an example of usage at: [http://mvp2014.mvpsummitevents.info/flickr](http://mvp2014.mvpsummitevents.info/flickr)