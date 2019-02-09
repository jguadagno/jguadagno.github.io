---
id: 131
title: Bootstrap Theme Switcher
date: 2014-05-24T04:07:00+00:00
author: Joseph Guadagno

guid: http://www.josephguadagno.net/post.aspx?id=658892e8-0406-490a-9ee1-4f822c2ebfe4
permalink: /2014/05/24/bootstrap-theme-switcher/
dsq_thread_id:
  - "3566883633"
categories:
  - Articles
tags:
  - Bootstrap
  - jQuery
  - jQuery Plugin
  - Plugin
  - Twitter Bootstrap
---
**UPDATE**: This is now a jQuery Plugin. See the post [Bootstrap Theme Switcher jQuery Plugin](http://www.josephguadagno.net/post/2014/11/15/Bootstrap-Theme-Switcher-jQuery-plugin). While creating a Proof of Concept design for a web site I was working on I thought it would be cool to demonstrate the power of themes in Twitter [Bootstrap](http://getbootstrap.com) by providing an option in the Proof of Concept to switch to some of the themes that are on [Bootswatch](http://www.bootswatch.com).  It was a remarkably easy solution, that involved [jQuery](http://www.jquery.com), [jQuery.cookie](https://github.com/carhartl/jquery-cookie) plugin, Twitter Bootstrap [Navbar](http://getbootstrap.com/components/#navbar) and the themes from [Bootswatch](http://www.bootswatch.com). This sample assumes that you are using a CDN for the Twitter Bootstrap and jQuery files and that you downloaded the themes from Bootswatch and copied them to the path of **/css/themes**. The example could easily be modified to use the themes on the Bootstrap [CDN](http://www.bootstrapcdn.com). First, let’s start with a basic template for Twitter Bootstrap

{% gist jguadagno/084554ed526d0d489c5baa3577694509 %}

Next, we’ll add the navbar with the theme selector menu.

{% gist jguadagno/8be05abaeadab034a51a0601c4548f1e %}

Then, the JavaScript

{% gist jguadagno/7dc5f2b1d2196a3b2037dad7dd8668bc %}

Now you are done. But how does it work? In the head section of the template you should notice that we gave one of the stylesheets an id of '_bootstrapTheme_'. This link will be modified by the **setTheme** function in the JavaScript file to dynamically change the theme and save the theme preference to a cookie to load in the future. In the jQuery **ready** function, we check for the presence of the cookie '_themeName_', if present, a call is made to **setTheme** to load the theme. The theme is changed by clicking on one of theme menu items which, in turn, calls **setTheme**.