---
title: Bootstrap Theme Switcher jQuery plugin
date: 2014-11-16T02:43:00+00:00
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
A few months ago a published an article on a [Bootstrap Theme Switcher]({% link _posts/2014-05-24-bootstrap-theme-switcher.md %}). I've since approved this post and the JavaScript and turned it into a jQuery plugin. This plugin works with the [Bootswatch](http://www.bootswatch.com) {:target="_blank"} [API](http://bootswatch.com/help/#api){:target="_blank"} to provide the user with the following:

* Loads a list of available themes from the API into a SELECT or a UL,
* Dynamically change the site theme to the selected theme
* Manually change the theme
* Save the selected theme to a cookie, requires the jQuery [Cookie](https://github.com/carhartl/jquery-cookie){:target="_blank"} plugin,
* Loads the selected theme from a cookie, requires the jQuery [Cookie](https://github.com/carhartl/jquery-cookie){:target="_blank"} plugin,

The plugin also allows you to load a list of local themes in case you to not want to use the Bootswatch site.

Let me know what you think.

## Downloads

| Download | Link |
|---|---|
|jQuery Plugin page|[http://plugins.jquery.com/bootstrapThemeSwitcher/](http://plugins.jquery.com/bootstrapThemeSwitcher/ "Bootstrap Theme Selector"){:target="_blank"}|
|GitHub Repository|[http://github.com/jguadagno/bootstrapThemeSwitcher](http://github.com/jguadagno/bootstrapThemeSwitcher "http://github.com/jguadagno/bootstrapThemeSwitcher"){:target="_blank"}|
|Demo site|[http://introtobootstrap.azurewebsites.net/](http://introtobootstrap.azurewebsites.net/ "Introduction to Twitter Bootstrap"){:target="_blank"}|

### Next steps

* NuGet Package
* NPM module
* Bower module
