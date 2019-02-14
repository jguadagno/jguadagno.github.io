---
id: 701
title: Add an iCal feed to Sitefinity
date: 2009-09-08T15:22:34+00:00
author: Joseph Guadagno

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
<!-- TODO: Remove Gist -->
[iCal](http://en.wikipedia.org/wiki/Ical "iCal on Wikipedia") feeds let you share your and/or import your events that are stored in Sitefinity.  Here is a library that will let you generate an iCal feed from Sitefinity. Future versions of this library might have us filtering by categories or date.

iCal feed for Sitefinity [CalendarHandler_2](https://www.josephguadagno.net/wp-content/uploads/2015/03/CalendarHandler_2.zip)

I’ve made a few changes since the last release to include some bug fixes.

* Added Google and Outlook friendly fields in the feed file to describe the iCalendar file as well as the publisher.
* Added code to the Location and Description fields to keep them at 75 characters or less to comply with the iCal specifications.

## Installation

### web.config changes

First, you need to tell ASP.NET about your new handler. Open up the web config file and look for the httpHandlers section, it’s the parent is system.web and add the following:

{% gist jguadagno/fae0c42b85bb50d4df78d115449eb681 %}

Note: The path name can be changed to any legal value like “feeds/ical.ashx” or “ical.ashx”.

### Files

Copy the vCalendar.cs and CalendarHandler.cs files to the App_Code directory of your Sitefinity installation.

## Customize

Getting the event data from Sitefinity and creating the iCalender objects is handled inside the CalendarHandler class.

The class assumes that your events provider is named “**Events**”, if not you will have to change line 25 of the class.

The class maps the following fields to an iCalendar event.

|iCalendar event|Sitefinity Field|
|--- |--- |
|Description|Content|
|Location|LocationName (Meta Field)|
|Summary|Title (Meta field)|
|Url|UrlWithExtension|
|DTStart|Start|
|DTEnd|End|

I believe these meta values are the default meta keys from Sitefinity. If your values differ, you can modify them on lines 64 and 65.