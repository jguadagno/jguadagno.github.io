---
id: 351
title: Converting an ASP.NET “Mobile” site to use jQuery Mobile
date: 2011-12-31T22:54:55+00:00
author: Joseph Guadagno
layout: post
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
<p>Building upon my previous post <a href="http://www.josephguadagno.net/post/Introduction-to-jQuery-Mobile.aspx" target="_blank">Introduction to jQuery Mobile</a>, I wanted to share how I converted the <a href="http://www.mvpsummitevents.info/m/default.aspx" target="_blank">Microsoft Global MVP Summit mobile</a> site to use <a href="http://jquerymobile.com/" target="_blank">jQuery Mobile</a>.</p>  <h2>Getting Started</h2>  <p>The first step was to look at the existing ASP.NET Master Page that the site was using and see where I had to make changes.&#160; I included the skeleton mobile master page, prior to jQuery Mobile below.&#160; Please note, I removed parts of the page that do not relate to the blog post.</p>  

<script src="https://gist.github.com/jguadagno/832748602420afb34ccb4be6fe5e1d13.js"></script>

<h2>Converting the document head</h2>

<p>The first thing I needed to do was to update the DOCTYPE on line 3 to</p>

<script src="https://gist.github.com/jguadagno/ad07ae45276e893d7250b855076f3413.js"></script>

<p>Next was to include the jQuery Mobile scripts and css files, after that my head section looked like this:</p>

<script src="https://gist.github.com/jguadagno/c7925618fa37728a9a2b62955bac4ba9.js"></script>

<p>Again, I removed parts that are not required for this post.</p>

<p>You should notice that line 5 is now different and I added lines 9 - 15. Line 9 contains the viewport meta tag, the description from the jQuery Mobile docs is …</p>

<blockquote>
  <p>Note above that there is a meta <code>viewport</code> tag in the <code>head</code> to specify how the browser should display the page zoom level and dimensions. If this isn't set, many mobile browsers will use a &quot;virtual&quot; page width around 900 pixels to make it work well with existing desktop sites but the screens may look zoomed out and too wide. By setting the viewport attributes to <code>content=&quot;width=device-width, initial-scale=1&quot;</code>, the width will be set to the pixel width of the device screen. 
</p>
</blockquote>

<p>Lines 10-15 contain the references to jQuery Mobile style sheet, the jQuery library and the jQuery Mobile library. Line 19, is a work around for using Google Analytics which is described <a href="http://www.jongales.com/blog/2011/01/10/google-analytics-and-jquery-mobile/" target="_blank">here</a>.</p>

<h2>Converting the Document Body</h2>

<p>Looking at the body of the Master Page, I was almost ready for the jQuery Mobile conversion.</p>

<script src="https://gist.github.com/jguadagno/c4cd7feef9baaa698ea32bd62de605ff.js"></script>

<p>I have my Master Page broken up into a header, menu, body, and footer. All I had to do was assign the jQuery Mobile data-role attributes and I was done.  However, I took this time to “tweak” the layout of the mobile site look more like it would on the iPhone and other mobile devices.  I still keep the header, but moved the menu to the footer section and moved the existing footer to an about page.  The new body of the mobile Master Page looks like this.</p>

<script src="https://gist.github.com/jguadagno/6bc81920a45cbcffeacd897b2f724cbf.js"></script>

<p>To me this seems quite readable and clearly identifies what each section (div) is responsible for.</p>

<p>Let’s break it down.</p>

<p>First all the previous DIV’s in between the FORM tags where placed within a</p>

<script src="https://gist.github.com/jguadagno/b729c1eb71c4fe48d812ba4113c2d447.js"></script>

<p>
tag. The next step was to convert each of the DIV’s that I had into a jQuery Mobile DIV. There is really no ‘jQuery Mobile DIV’ just an attribute that tells jQuery what “section” of the document this div is for.  I added the data-role=”header” to the DIV with the ID of mHead, I added the data-role=”content” to the DIV with the ID of mBody and I added the data-role=”footer” to the DIV with the ID of mFooter.</p>
<p>“Ok but what happened to the mMenu DIV” you ask.  Take a look at line 8 in the code sample above.  I moved the “menu” to the footer of the new document and assigned it a data-role of navbar. This is a jQuery Mobile widget that creates a simple menu of buttons out of all of the listitem elements of the unordered list. The data-icon attribute is an attribute that allows you to indicate one of the 18 built-in icons for any jQuery Mobile button.</p>

<p>After this, I was done.  I now have a jQuery Mobile version of the Microsoft Global MVP Summit site that looks the same on virtually every mobile browser with little to no work.</p>

<p>Up next, how to convert other elements of an ASP.NET mobile site to use jQuery Mobile widgets.</p>
