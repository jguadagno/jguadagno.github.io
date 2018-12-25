---
id: 131
title: Bootstrap Theme Switcher
date: 2014-05-24T04:07:00+00:00
author: Joseph Guadagno
layout: post
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
<strong>UPDATE</strong>: This is now a jQuery Plugin. See the post <a href="http://www.josephguadagno.net/post/2014/11/15/Bootstrap-Theme-Switcher-jQuery-plugin" target="_blank">Bootstrap Theme Switcher jQuery Plugin</a>.

While creating a Proof of Concept design for a web site I was working on I thought it would be cool to demonstrate the power of themes in Twitter <a href="http://getbootstrap.com" target="_blank">Bootstrap</a> by providing an option in the Proof of Concept to switch to some of the themes that are on <a href="http://www.bootswatch.com" target="_blank">Bootswatch</a>.  It was a remarkably easy solution, that involved <a href="http://www.jquery.com" target="_blank">jQuery</a>, <a href="https://github.com/carhartl/jquery-cookie" target="_blank">jQuery.cookie</a> plugin, Twitter Bootstrap <a href="http://getbootstrap.com/components/#navbar" target="_blank">Navbar</a> and the themes from <a href="http://www.bootswatch.com" target="_blank">Bootswatch</a>.

This sample assumes that you are using a CDN for the Twitter Bootstrap and jQuery files and that you downloaded the themes from Bootswatch and copied them to the path of <strong>/css/themes</strong>. The example could easily be modified to use the themes on the Bootstrap <a href="http://www.bootstrapcdn.com" target="_blank">CDN</a>.

First, let’s start with a basic template for Twitter Bootstrap
[xml]
&lt;html lang=&quot;en&quot;&gt;
	&lt;head&gt;
        &lt;!-- Bootstrap core CSS --&gt;
        &lt;link rel=&quot;stylesheet&quot; 
			href=&quot;http://netdna.bootstrapcdn.com/bootstrap/3.1.1/css/bootstrap.min.css&quot;&gt;
		&lt;link rel=&quot;stylesheet&quot; 
			href=&quot;http://netdna.bootstrapcdn.com/bootstrap/3.1.1/css/bootstrap-theme.min.css&quot;&gt;
        &lt;link id=&quot;bootstrapTheme&quot; rel=&quot;stylesheet&quot; 
			href=&quot;http://netdna.bootstrapcdn.com/bootswatch/3.1.1/cerulean/bootstrap.min.css&quot;&gt;
        &lt;link rel=&quot;stylesheet&quot; 
			href=&quot;http://netdna.bootstrapcdn.com/font-awesome/4.1.0/css/font-awesome.min.css&quot;&gt;

        &lt;!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries --&gt;    
        &lt;script src=&quot;https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js&quot;&gt;&lt;/script&gt;
        &lt;script src=&quot;https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js&quot;&gt;&lt;/script&gt;
	&lt;/head&gt;
&lt;body&gt;

&lt;div class=&quot;container-fluid&quot;&gt;

Your content here!

&lt;/div&gt;

&lt;!-- jQuery (necessary for Bootstrap's JavaScript plugins) --&gt;
&lt;script src=&quot;https://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js&quot; 
	type=&quot;text/javascript&quot;&gt;
&lt;/script&gt;
&lt;!-- Include all compiled plugins (below), or include individual files as needed --&gt;
&lt;script src=&quot;http://netdna.bootstrapcdn.com/bootstrap/3.1.1/js/bootstrap.min.js&quot; 
	type=&quot;text/javascript&quot;&gt;
&lt;/script&gt;
&lt;script src=&quot;/js/site.js&quot; type=&quot;text/javascript&quot;&gt;&lt;/script&gt;

&lt;/body&gt; 
&lt;/html&gt;
[/xml]

<p>Next, we’ll add the navbar with the theme selector menu.</p>

[xml]
&lt;div class=&quot;container&quot;&gt;
	&lt;div class=&quot;navbar-header&quot;&gt;
		&lt;button class=&quot;navbar-toggle&quot;&gt; 
  			&lt;span class=&quot;sr-only&quot;&gt;Toggle navigation&lt;/span&gt;
  		&lt;/button&gt; 
  		&lt;a class=&quot;navbar-brand&quot; href=&quot;index.html&quot;&gt;Intro to Twitter Bootstrap&lt;/a&gt;
  	&lt;/div&gt;
	&lt;div class=&quot;collapse navbar-collapse&quot;&gt;
	&lt;ul class=&quot;nav navbar-nav&quot;&gt;
		&lt;li class=&quot;dropdown&quot;&gt;&lt;a class=&quot;dropdown-toggle&quot; href=&quot;#&quot;&gt;Bootstrap Site &lt;/a&gt;
			&lt;ul class=&quot;dropdown-menu&quot;&gt;
				&lt;li&gt;&lt;a&gt;default&lt;/a&gt;&lt;/li&gt;
				&lt;li&gt;&lt;a&gt;amelia&lt;/a&gt;&lt;/li&gt;
				&lt;li&gt;&lt;a&gt;cerulean&lt;/a&gt;&lt;/li&gt;
				&lt;li&gt;&lt;a&gt;cosmo&lt;/a&gt;&lt;/li&gt;
				&lt;li&gt;&lt;a&gt;custom&lt;/a&gt;&lt;/li&gt;
				&lt;li&gt;&lt;a&gt;cyborg&lt;/a&gt;&lt;/li&gt;
				&lt;li&gt;&lt;a&gt;darkly&lt;/a&gt;&lt;/li&gt;
				&lt;li&gt;&lt;a&gt;flatly&lt;/a&gt;&lt;/li&gt;
				&lt;li&gt;&lt;a&gt;journal&lt;/a&gt;&lt;/li&gt;
				&lt;li&gt;&lt;a&gt;lumen&lt;/a&gt;&lt;/li&gt;
				&lt;li&gt;&lt;a&gt;readable&lt;/a&gt;&lt;/li&gt;
				&lt;li&gt;&lt;a&gt;shamrock&lt;/a&gt;&lt;/li&gt;
				&lt;li&gt;&lt;a&gt;simplex&lt;/a&gt;&lt;/li&gt;
				&lt;li&gt;&lt;a&gt;slate&lt;/a&gt;&lt;/li&gt;
				&lt;li&gt;&lt;a&gt;spacelab&lt;/a&gt;&lt;/li&gt;
				&lt;li&gt;&lt;a&gt;superhero&lt;/a&gt;&lt;/li&gt;
				&lt;li&gt;&lt;a&gt;united&lt;/a&gt;&lt;/li&gt;
				&lt;li&gt;&lt;a&gt;yeti&lt;/a&gt;&lt;/li&gt;
			&lt;/ul&gt;
		&lt;/li&gt;
	&lt;/ul&gt;
	&lt;/div&gt;&lt;!--/.nav-collapse --&gt;
&lt;/div&gt; 
[/xml]

<p>Then, the JavaScript</p>
[js]$().ready(function() {
	/* For theme switching */    
	var themeName = $.cookie(&quot;themeName&quot;);
	var themePath = $.cookie(&quot;themePath&quot;);
	if (themeName !== undefined) {
		setTheme(themeName, themePath);
	}
});

function setTheme(themeName, themePath) {
	var cssLink = &quot;&quot;;
	$('#bootstrapTheme').replaceWith(cssLink);

	$.cookie(&quot;themeName&quot;, themeName, { expires: 7, path: &quot;/&quot; });
	$.cookie(&quot;themePath&quot;, themePath, { expires: 7, path: &quot;/&quot; });
}[/js]
Now you are done. But how does it work?

In the head section of the template you should notice that we gave one of the stylesheets an id of '<em>bootstrapTheme</em>'. This link will be modified by the <strong>setTheme</strong> function in the JavaScript file to dynamically change the theme and save the theme preference to a cookie to load in the future. In the jQuery <strong>ready</strong> function, we check for the presence of the cookie '<em>themeName</em>', if present, a call is made to <strong>setTheme</strong> to load the theme. The theme is changed by clicking on one of theme menu items which, in turn, calls <strong>setTheme</strong>.