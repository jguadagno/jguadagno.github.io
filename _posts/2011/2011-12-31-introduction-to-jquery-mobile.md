---
title: Introduction to jQuery Mobile
date: 2011-12-31T21:46:53+00:00
permalink: /2011/12/31/introduction-to-jquery-mobile/
dsq_thread_id:
  - "3617238514"
categories:
  - Articles
tags:
  - jQuery
  - Web
---
Back in November, I sat in on a session by [Scott Hanselman](https://www.hanselman.com/blog/){:target="_blank"} on creating a mobile site on ASP.NET using [jQuery Mobile](https://jquerymobile.com/){:target="_blank"}.  While I was watching this session I could not stop thinking how easy is this, I can do this for the mobile version of the [Microsoft Global MVP Summit mobile](https://mvpsummitevents.info/m/){:target="_blank"} site. So like most of us, it took me a month to get to it.

A few days ago while on vacation and everyone was asleep, I started to play around with jQuery mobile and in about an hour I had a sample site created.  Here's how you can get started.

## Getting started with jQuery Mobile

According the [jQuery Mobile](https://https://jquerymobile.com/){:target="_blank"} website, jQuery Mobile is…

> A unified, HTML5-based user interface system for all popular mobile device platforms, built on the rock-solid jQuery and jQuery UI foundation. Its lightweight code is built with progressive enhancement and has a flexible, easily themeable design

To get started with jQuery Mobile you can head over to their [Quick Start Guide](https://jquerymobile.com/demos/1.0/docs/about/getting-started.html){:target="_blank"}.  Here is the minimum HTML document that you need for jQuery Mobile.

```html
<!DOCTYPE html>
<html>
<head>
  <title>My Page</title> 
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet"
    href="https://code.jquery.com/mobile/1.0/jquery.mobile-1.0.min.css" />
  <script type="text/javascript"
    src="https://code.jquery.com/jquery-1.6.4.min.js"></script>
  <script type="text/javascript"
    src="https://code.jquery.com/mobile/1.0/jquery.mobile-1.0.min.js"></script>
</head>
<body>
  <div data-role="page">
    <div data-role="header">
     <h1>My Title</h1>
    </div><!-- /header -->
    <div data-role="content">
      <p>Hello world</p>
    </div><!-- /content -->
  </div><!-- /page -->
</body>
</html>
```

The first this you will notice is the simple DOCTYPE.

```html
<!DOCTYPE html>
```

Next, you will need to include a reference to the jQuery Mobile scripts and CSS files in the HEAD section of the document.

```html
<link rel="stylesheet" 
  href="https://code.jquery.com/mobile/1.0/jquery.mobile-1.0.min.css" />
<script type="text/javascript" 
  src="https://code.jquery.com/jquery-1.6.4.min.js"></script>
<script type="text/javascript" 
  src="https://code.jquery.com/mobile/1.0/jquery.mobile-1.0.min.js"></script>
```

And then finally in your HTML Body, you need to create a “page”. You do this by creating a DIV and an assigning the role of the page to it.

```html
<div id="#default" data-role="page">
...
</div>
```

The id is optional and can be used to have more than one page within a document.  For more on the page structure, check out the [Anatomy of a Page](https://jquerymobile.com/demos/1.0/docs/pages/page-anatomy.html){:target="_blank"} in the jQuery Mobile docs.

That's all you need for the bare minimal jQuery Mobile page.

## jQuery Mobile Page Parts

jQuery Mobile pages are made up of potentially 3 parts; the header, the content (body) and the footer.  These parts are outlined by creating a div and assigning a role to it.  The roles are `data-role=”header”`, `data-role=”content”`, and `data-role=”footer”`.

```html
<div data-role="page">
  <div data-role="header">...</div>
  <div data-role="content">...</div>
  <div data-role="footer">...</div>
</div>
```

### Header Part

Is defined by the following markup.

```html
<div data-role="header">...</div>
```

The header part of the document is where you place content that you want as the head or beginning part of the page. This is typically page titles and toolbars.

### Content Part

Is defined by the following markup.

```html
<div data-role="content">...</div>
```

The content part of the document is where you place the page content.

### Footer Part

Is defined by the following markup.

```html
<div data-role="footer">...</div>
```

The footer part of the document is where you place the footer content. This is typically navigation, copyright information, etc.

Hopefully, I armed you with enough information to get started with jQuery Mobile. In the next few posts, I will talk about how I converted the [Microsoft Global MVP Summit](https://www.mvpsummitevents.info){:target="_blank"} mobile site to use jQuery Mobile.
