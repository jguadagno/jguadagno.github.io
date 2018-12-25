---
id: 701
title: Add an iCal feed to Sitefinity
date: 2009-09-08T15:22:34+00:00
author: Joseph Guadagno
layout: post
guid: http://www.josephguadagno.net/post.aspx?id=4c6a504b-2a6f-46e7-be86-534dae04114c
permalink: /2009/09/08/add-an-ical-feed-to-sitefinity/
dsq_thread_id:
  - "3617303793"
categories:
  - Articles
  - Web
tags:
  - Sitefinity
---
<p><a title="iCal on Wikipedia" href="http://en.wikipedia.org/wiki/Ical" target="_blank">iCal</a> feeds let you share your and/or import your events that are stored in Sitefinity.  Here is a library that will let you generate an iCal feed from Sitefinity. Future versions of this library might have us filtering by categories or date.<p>
<p>iCal feed for Sitefinity <a href="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/CalendarHandler_2.zip">CalendarHandler_2</a></p>
<p>I’ve made a few changes since the last release to include some bug fixes.</p>
<ul>
	<li>Added Google and Outlook friendly fields in the feed file to describe the iCalendar file as well as the publisher.</li>
	<li>Added code to the Location and Description fields to keep them at 75 characters or less to comply with the iCal specifications.</li>
</ul>
<h2>Installation</h2>
<h3>web.config changes</h3>
<p>First you need to tell ASP.NET about your new handler. Open up the web config file and look for the httpHandlers section, it’s parent is system.web and add the following:</p>

<script src="https://gist.github.com/jguadagno/fae0c42b85bb50d4df78d115449eb681.js"></script>

<p>Note: The path name can be changed to any legal value like “feeds/ical.ashx” or “ical.ashx”.</p>

<h3>Files</h3>
<p>Copy the vCalendar.cs and CalendarHandler.cs files to the App_Code directory of your Sitefinity installation.
<h2>Customize</h2>
<p>Getting the event data from Sitefinity and creating the iCalender objects is handled inside the CalendarHandler class.</p>
<p>The class assumes that your events provider is named “<strong>Events</strong>”, if not you will have to change line 25 of the class.</p>
<p>The class maps the following fields to an iCalendar event.</p>

<table class="table table-striped table-bordered">
<thead>
<tr>
<th>iCalendar event</td>
<th>Sitefinity Field</td>
</tr>
</thead>
<tbody>
<tr>
<td>Description</td>
<td>Content</td>
</tr>
<tr>
<td>Location</td>
<td>LocationName (Meta Field)</td>
</tr>
<tr>
<td>Summary</td>
<td>Title (Meta field)</td>
</tr>
<tr>
<td>Url</td>
<td>UrlWithExtension</td>
</tr>
<tr>
<td>DTStart</td>
<td>Start</td>
</tr>
<tr>
<td>DTEnd</td>
<td>End</td>
</tr>
</tbody>
</table>

<p>I believe these meta values are the default meta keys from Sitefinity. If your values differ, you can modify them on lines 64 and 65.</p>