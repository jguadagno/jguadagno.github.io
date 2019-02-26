---
title: Bootstrap Theme Switcher jQuery plugin
date: 2014-11-16T02:43:00+00:00
author: Joseph Guadagno
permalink: /2014/11/16/bootstrap-theme-switcher-jquery-plugin/
dsq_thread_id:
  - "3591475275"
categories:
  - Articles
tags:
  - Bootstrap
  - jQuery
  - jQuery Plugin
  - Plugin
  - Theme
  - Twitter Bootstrap
---
A few months ago a published an article on a [Bootstrap Theme Switcher](https://www.josephguadagno.net/post/2014/05/23/Bootstrap-Theme-Switcher). I’ve since approved this post and the JavaScript and turned it into a jQuery plugin. This plugin works with the [Bootswatch](http://www.bootswatch.com) [API](http://bootswatch.com/help/#api) to provide the user with the following:

* Loads a list of available themes from the API into a SELECT or a UL,
* Dynamically change the site theme to the selected theme
* Manually change the theme
* Save the selected theme to a cookie, requires the jQuery [Cookie](https://github.com/carhartl/jquery-cookie) plugin,
* Loads the selected theme from a cookie, requires the jQuery [Cookie](https://github.com/carhartl/jquery-cookie) plugin,

The plugin also allows you to load a list of local themes in case you to not want to use the Bootswatch site.

Let me know what you think.

## Downloads

| Download | Link |
|---|---|
|jQuery Plugin page|[http://plugins.jquery.com/bootstrapThemeSwitcher/](http://plugins.jquery.com/bootstrapThemeSwitcher/ "Bootstrap Theme Selector")|
|GitHub Repository|[http://github.com/jguadagno/bootstrapThemeSwitcher](http://github.com/jguadagno/bootstrapThemeSwitcher "http://github.com/jguadagno/bootstrapThemeSwitcher")|
|Demo site|[http://introtobootstrap.azurewebsites.net/](http://introtobootstrap.azurewebsites.net/ "Introduction to Twitter Bootstrap")|

### Next steps

* NuGet Package
* NPM module
* Bower module