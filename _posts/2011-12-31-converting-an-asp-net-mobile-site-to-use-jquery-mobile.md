---
id: 351
title: Converting an ASP.NET “Mobile” site to use jQuery Mobile
date: 2011-12-31T22:54:55+00:00
author: Joseph Guadagno

guid: http://www.josephguadagno.net/post.aspx?id=0c056b6f-b6a0-49b2-982e-c9e9e7f5286b
permalink: /2011/12/31/converting-an-asp-net-mobile-site-to-use-jquery-mobile/
dsq_thread_id:
  - "3617142059"
categories:
  - Articles
  - Web
tags:
  - jQuery
---
<!-- TODO: Remove Gist -->
Building upon my previous post [Introduction to jQuery Mobile](http://www.josephguadagno.net/post/Introduction-to-jQuery-Mobile.aspx), I wanted to share how I converted the [Microsoft Global MVP Summit mobile](http://www.mvpsummitevents.info/m/default.aspx) site to use [jQuery Mobile](http://jquerymobile.com/).

## Getting Started

The first step was to look at the existing ASP.NET Master Page that the site was using and see where I had to make changes.  I included the skeleton mobile master page, prior to jQuery Mobile below.  Please note, I removed parts of the page that do not relate to the blog post.

{% gist jguadagno/832748602420afb34ccb4be6fe5e1d13.js %}

## Converting the document head

The first thing I needed to do was to update the DOCTYPE on line 3 to

{% gist jguadagno/ad07ae45276e893d7250b855076f3413 %}

Next was to include the jQuery Mobile scripts and CSS files, after that my head section looked like this:

{% gist jguadagno/c7925618fa37728a9a2b62955bac4ba9 %}

Again, I removed parts that are not required for this post.

You should notice that line 5 is now different and I added lines 9 - 15\. Line 9 contains the viewport meta tag, the description from the jQuery Mobile docs is …

Note above that there is a meta `viewport` tag in the `head` to specify how the browser should display the page zoom level and dimensions. If this isn't set, many mobile browsers will use a "virtual" page width around 900 pixels to make it work well with existing desktop sites but the screens may look zoomed out and too wide. By setting the viewport attributes to `content="width=device-width, initial-scale=1"`, the width will be set to the pixel width of the device screen.

Lines 10-15 contain the references to the jQuery Mobile style sheet, the jQuery library and the jQuery Mobile library. Line 19, is a workaround for using Google Analytics which is described [here](http://www.jongales.com/blog/2011/01/10/google-analytics-and-jquery-mobile/).

## Converting the Document Body

Looking at the body of Master Page, I was almost ready for the jQuery Mobile conversion.

{% gist jguadagno/c4cd7feef9baaa698ea32bd62de605ff %}

I have my Master Page broken up into a header, menu, body, and footer. All I had to do was assign the jQuery Mobile data-role attributes and I was done. However, I took this time to “tweak” the layout of the mobile site look more like it would on the iPhone and other mobile devices. I still keep the header, but moved the menu to the footer section and moved the existing footer to an about page. The new body of the mobile Master Page looks like this.

{% gist jguadagno/6bc81920a45cbcffeacd897b2f724cbf %}

To me this seems quite readable and clearly identifies what each section (div) is responsible for.

Let’s break it down.

First, all the previous DIV’s in between the FORM tags where placed within a

{% gist jguadagno/b729c1eb71c4fe48d812ba4113c2d447 %}

tag. The next step was to convert each of the DIV’s that I had into a jQuery Mobile DIV. There is really no ‘jQuery Mobile DIV’ just an attribute that tells jQuery what “section” of the document this div is for. I added the data-role=”header” to the DIV with the ID of mHead, I added the data-role=”content” to the DIV with the ID of mBody and I added the data-role=”footer” to the DIV with the ID of mFooter.

“Ok, but what happened to the mMenu DIV,” you ask. Take a look at line 8 in the code sample above. I moved the “menu” to the footer of the new document and assigned it a data-role of the navbar. This is a jQuery Mobile widget that creates a simple menu of buttons out of all of the listitem elements of the unordered list. The data-icon attribute is an attribute that allows you to indicate one of the 18 built-in icons for any jQuery Mobile button.

After this, I was done. I now have a jQuery Mobile version of the Microsoft Global MVP Summit site that looks the same on virtually every mobile browser with little to no work.

Up next, how to convert other elements of an ASP.NET mobile site to use jQuery Mobile widgets.