---
id: 361
title: Introduction to jQuery Mobile
date: 2011-12-31T21:46:53+00:00
author: Joseph Guadagno
layout: post
guid: http://www.josephguadagno.net/post.aspx?id=fc1c6126-aa1c-45ca-84de-da5aff516222
permalink: /2011/12/31/introduction-to-jquery-mobile/
dsq_thread_id:
  - "3617238514"
categories:
  - Articles
---
<p>Back in November I sat in on a session by <a href="http://www.hanselman.com/blog/" target="_blank">Scott Hanselman</a> on creating a mobile site on ASP.NET using <a href="http://jquerymobile.com/" target="_blank">jQuery Mobile</a>.&#160; While I was watching this session I could not stop thinking how easy is this, I can do this for the mobile version of the <a href="http://mvpsummitevents.info/m/" target="_blank">Microsoft Global MVP Summit mobile</a> site. So like most of us, it took me a month to get to it. </p>  <p>A few days ago while on vacation and every one was asleep, I started to play around with jQuery mobile and in about an hour I had a sample site created.&#160; Here’s how you can get started.</p>  <h2>Getting started with jQuery Mobile</h2>  <p>According the <a href="http://http://jquerymobile.com/" target="_blank">jQuery Mobile</a> website, jQuery Mobile is…</p>  <blockquote>   <p>A unified, HTML5-based user interface system for all popular mobile device platforms, built on the rock-solid jQuery and jQuery UI foundation. Its lightweight code is built with progressive enhancement, and has a flexible, easily themeable design</p> </blockquote>  <p>To get started with jQuery Mobile you can head over to their <a href="http://jquerymobile.com/demos/1.0/docs/about/getting-started.html" target="_blank">Quick Start Guide</a>.&#160; Here is the minimum HTML document that you need for jQuery Mobile.</p>

<script src="https://gist.github.com/jguadagno/4fa3b6247741da6e44b5735dd576cca4.js"></script>

<p>
The first this you will notice is the simple DOCTYPE.
</p>

<script src="https://gist.github.com/jguadagno/59e7ea3462eb9f1e9fbb1aaa2d7a985d.js"></script>

<p>
Next you will need to include a reference to the jQuery Mobile scripts and css files in the HEAD section of the document.
</p>

<script src="https://gist.github.com/jguadagno/1576dcbe0b809f85f3bdc1f5f3bd24d8.js"></script>

<p>
And then finally in your HTML Body, you need to create a “page”. You do this by creating a DIV and an assigning the role of page to it.
</p>

<script src="https://gist.github.com/jguadagno/b13e7b0f17a5ee296c7b19c000568ef5.js"></script>

</p>
<p>The id is optional and can be used to have more than one page within a document.&#160; For more on the page structure, check out the <a href="http://jquerymobile.com/demos/1.0/docs/pages/page-anatomy.html" target="_blank">Anatomy of a Page</a> in the jQuery Mobile docs. </p>

<p>That’s all you need for the bare minimal jQuery Mobile page.</p>

<h2>jQuery Mobile Page Parts</h2>

<p>jQuery Mobile pages are made up of potentially 3 parts; the header, the content (body) and the footer.&#160; These parts are outlined by creating a div and assigning a role to it.&#160; The roles are <strong>data-role=”header”</strong>, <strong>data-role=”content”</strong>, and <strong>data-role=”footer”</strong>.</p>

<script src="https://gist.github.com/jguadagno/e9ba5e5ced2469987d28d0f39c780558.js"></script>

<h3>Header Part</h3>

<p>Is defined by following markup.</p>

<script src="https://gist.github.com/jguadagno/40e669ddd76468c9ad3a26332e0d1b65.js"></script>

<p>The header part of the document is where you place content that you want as the head or beginning part of the page. This is typically page titles and toolbars.</p>

<h3>Content Part</h3>

<p>Is defined by following markup.</p>

<script src="https://gist.github.com/jguadagno/2d834ca40a128f8713188607038470e3.js"></script>

<p>The content part of the document is where you place the page content.</p>

<h3>Footer Part</h3>

<p>Is defined by following markup.</p>

<script src="https://gist.github.com/jguadagno/fe43de964bd63e507f9aef6b5f4de502.js"></script>

<p>The footer part of the document is where you place the footer content. This is typically navigation, copyright information, etc.</p>

<p>Hopefully, I armed you with enough information to get started with jQuery Mobile. In the next few posts I will talk about how I converted the <a href="http://www.mvpsummitevents.info" target="_blank">Microsoft Global MVP Summit</a> mobile site to use jQuery Mobile.</p>