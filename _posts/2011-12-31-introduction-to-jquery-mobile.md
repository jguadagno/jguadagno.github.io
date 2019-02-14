---
id: 361
title: Introduction to jQuery Mobile
date: 2011-12-31T21:46:53+00:00
author: Joseph Guadagno

guid: http://www.josephguadagno.net/post.aspx?id=fc1c6126-aa1c-45ca-84de-da5aff516222
permalink: /2011/12/31/introduction-to-jquery-mobile/
dsq_thread_id:
  - "3617238514"
categories:
  - Articles
---
<!-- TODO: Remove Gist -->
Back in November, I sat in on a session by [Scott Hanselman](http://www.hanselman.com/blog/) on creating a mobile site on ASP.NET using [jQuery Mobile](http://jquerymobile.com/).  While I was watching this session I could not stop thinking how easy is this, I can do this for the mobile version of the [Microsoft Global MVP Summit mobile](http://mvpsummitevents.info/m/) site. So like most of us, it took me a month to get to it.

A few days ago while on vacation and everyone was asleep, I started to play around with jQuery mobile and in about an hour I had a sample site created.  Here’s how you can get started.

## Getting started with jQuery Mobile

According the [jQuery Mobile](http://http://jquerymobile.com/) website, jQuery Mobile is…

> A unified, HTML5-based user interface system for all popular mobile device platforms, built on the rock-solid jQuery and jQuery UI foundation. Its lightweight code is built with progressive enhancement and has a flexible, easily themeable design

To get started with jQuery Mobile you can head over to their [Quick Start Guide](http://jquerymobile.com/demos/1.0/docs/about/getting-started.html).  Here is the minimum HTML document that you need for jQuery Mobile.

{% gist jguadagno/4fa3b6247741da6e44b5735dd576cca4 %}

The first this you will notice is the simple DOCTYPE.

{% gist jguadagno/59e7ea3462eb9f1e9fbb1aaa2d7a985d %}

Next, you will need to include a reference to the jQuery Mobile scripts and CSS files in the HEAD section of the document.

{% gist jguadagno/1576dcbe0b809f85f3bdc1f5f3bd24d8 %}

And then finally in your HTML Body, you need to create a “page”. You do this by creating a DIV and an assigning the role of the page to it.

{% gist jguadagno/b13e7b0f17a5ee296c7b19c000568ef5 %}

The id is optional and can be used to have more than one page within a document.  For more on the page structure, check out the [Anatomy of a Page](http://jquerymobile.com/demos/1.0/docs/pages/page-anatomy.html) in the jQuery Mobile docs.

That’s all you need for the bare minimal jQuery Mobile page.

## jQuery Mobile Page Parts

jQuery Mobile pages are made up of potentially 3 parts; the header, the content (body) and the footer.  These parts are outlined by creating a div and assigning a role to it.  The roles are **data-role=”header”**, **data-role=”content”**, and **data-role=”footer”**.

{% gist jguadagno/e9ba5e5ced2469987d28d0f39c780558 %}

### Header Part

Is defined by the following markup.

{% gist jguadagno/40e669ddd76468c9ad3a26332e0d1b65 %}

The header part of the document is where you place content that you want as the head or beginning part of the page. This is typically page titles and toolbars.

### Content Part

Is defined by the following markup.

{% gist jguadagno/2d834ca40a128f8713188607038470e3 %}

The content part of the document is where you place the page content.

### Footer Part

Is defined by the following markup.

{% gist jguadagno/fe43de964bd63e507f9aef6b5f4de502 %}

The footer part of the document is where you place the footer content. This is typically navigation, copyright information, etc.

Hopefully, I armed you with enough information to get started with jQuery Mobile. In the next few posts, I will talk about how I converted the [Microsoft Global MVP Summit](http://www.mvpsummitevents.info) mobile site to use jQuery Mobile.