---
title: Bootstrap Theme Switcher
date: 2014-05-24T04:07:00+00:00
author: Joseph Guadagno
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
**UPDATE**: This is now a jQuery Plugin. See the post [Bootstrap Theme Switcher jQuery Plugin]({% link _posts/2014-11-16-bootstrap-theme-switcher-jquery-plugin.md %}). While creating a Proof of Concept design for a web site I was working on I thought it would be cool to demonstrate the power of themes in Twitter [Bootstrap](http://getbootstrap.com) by providing an option in the Proof of Concept to switch to some of the themes that are on [Bootswatch](http://www.bootswatch.com).  It was a remarkably easy solution, that involved [jQuery](http://www.jquery.com), [jQuery.cookie](https://github.com/carhartl/jquery-cookie) plugin, Twitter Bootstrap [Navbar](http://getbootstrap.com/components/#navbar) and the themes from [Bootswatch](http://www.bootswatch.com). This sample assumes that you are using a CDN for the Twitter Bootstrap and jQuery files and that you downloaded the themes from Bootswatch and copied them to the path of `/css/themes`. The example could easily be modified to use the themes on the Bootstrap [CDN](http://www.bootstrapcdn.com). First, let’s start with a basic template for Twitter Bootstrap

```html
<html lang="en">
    <head>
        <!-- Bootstrap core CSS -->
        <link rel="stylesheet"
            href="http://netdna.bootstrapcdn.com/bootstrap/3.1.1/css/bootstrap.min.css">
        <link rel="stylesheet"
            href="http://netdna.bootstrapcdn.com/bootstrap/3.1.1/css/bootstrap-theme.min.css">
        <link id="bootstrapTheme" rel="stylesheet"
            href="http://netdna.bootstrapcdn.com/bootswatch/3.1.1/cerulean/bootstrap.min.css">
        <link rel="stylesheet"
            href="http://netdna.bootstrapcdn.com/font-awesome/4.1.0/css/font-awesome.min.css">
        <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->   
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    </head>
<body>

<div class="container-fluid">

Your content here!

</div>

<!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"
    type="text/javascript">
</script>
<!-- Include all compiled plugins (below), or include individual files as needed -->
<script src="http://netdna.bootstrapcdn.com/bootstrap/3.1.1/js/bootstrap.min.js"
    type="text/javascript">
</script>
<script src="/js/site.js" type="text/javascript"></script>

</body>
</html>
```

Next, we’ll add the navbar with the theme selector menu.

```html
<div class="container">
  <div class="navbar-header">
    <button class="navbar-toggle"> 
      <span class="sr-only">Toggle navigation</span>
    </button>
      <a class="navbar-brand" href="index.html">Intro to Twitter Bootstrap</a>
    </div>
  <div class="collapse navbar-collapse">
  <ul class="nav navbar-nav">
    <li class="dropdown"><a class="dropdown-toggle" href="#">Bootstrap Site </a>
      <ul class="dropdown-menu">
        <li><a>default</a></li>
        <li><a>amelia</a></li>
        <li><a>cerulean</a></li>
        <li><a>cosmo</a></li>
        <li><a>custom</a></li>
        <li><a>cyborg</a></li>
        <li><a>darkly</a></li>
        <li><a>flatly</a></li>
        <li><a>journal</a></li>
        <li><a>lumen</a></li>
        <li><a>readable</a></li>
        <li><a>shamrock</a></li>
        <li><a>simplex</a></li>
        <li><a>slate</a></li>
        <li><a>spacelab</a></li>
        <li><a>superhero</a></li>
        <li><a>united</a></li>
        <li><a>yeti</a></li>
      </ul>
    </li>
  </ul>
  </div><!--/.nav-collapse -->
</div>
```

Then, the JavaScript

```js
$().ready(function() {
  /* For theme switching */
  var themeName = $.cookie("themeName");
  var themePath = $.cookie("themePath");
  if (themeName !== undefined) {
    setTheme(themeName, themePath);
  }
});

function setTheme(themeName, themePath) {
  var cssLink = "";
  $('#bootstrapTheme').replaceWith(cssLink);

  $.cookie("themeName", themeName, { expires: 7, path: "/" });
  $.cookie("themePath", themePath, { expires: 7, path: "/" });
}
```

Now you are done. But how does it work? In the head section of the template you should notice that we gave one of the stylesheets an id of `bootstrapTheme`. This link will be modified by the `setTheme` function in the JavaScript file to dynamically change the theme and save the theme preference to a cookie to load in the future. In the jQuery `ready` function, we check for the presence of the cookie `themeName`, if present, a call is made to `setTheme` to load the theme. The theme is changed by clicking on one of theme menu items which, in turn, calls `setTheme`.