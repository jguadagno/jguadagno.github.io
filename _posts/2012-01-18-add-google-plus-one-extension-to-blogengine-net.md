---
id: 321
title: Add Google Plus One Extension to BlogEngine.NET
date: 2012-01-18T17:45:00+00:00
author: Joseph Guadagno

guid: http://www.josephguadagno.net/post.aspx?id=bb57812a-9788-488b-a86a-e74b06feb9f8
permalink: /2012/01/18/add-google-plus-one-extension-to-blogengine-net/
dsq_thread_id:
  - "3585868671"
categories:
  - Articles
---
<!-- TODO: Fix HTML, check links -->

A few years ago I built my personal website using [BlogEngine.NET](http://www.dotnetblogengine.net/), every once in a while I tend to pay attention to the site and “freshen it up”.  Back in December of 2011, I upgraded to version 2.5 of BlogEngine.NET and updated the theme.  Last night I added [facebook](http://facebook.com) [like](https://developers.facebook.com/docs/reference/plugins/like/) buttons to all those post and pages courtesy of [isharpnote](http://isharpnote.com/isharpnote/post/2011/03/17/Facebook-Like-Button-Extension-For-BlogEngine-20.aspx "Facebook Like Button Extension For BlogEngine 2.0"). Well I wanted to add a [Google Plus One](http://www.google.com/+1/button/) button to my site also but I could not find any BlogEngine.NET extensions for it, so what does every developer do, create one.  I started with the “[Facebook Like with Google Plus Extension for BlogEngine 2.5](http://isharpnote.com/isharpnote/post/2011/07/24/Facebook-Like-with-Google-Plus-Extension-for-BlogEngine-25.aspx)” extension from isharpnote and tweaked it for my needs.

## Creating the extension

To create a BlogEngine.NET extension you need a class and attribute it with the BlogEngine.Core.Web.Extensions.Extension attribute, like so: {% gist jguadagno/b234ca65fb17145b4318da74d3d3e701 %} Parameters explained

<table class="table table-striped"><caption>Parameters Explained</caption>

<tbody>

<tr>

<th scope="col" abbr="Parameter Name">Parameter Name</th>

<th scope="col" abbr="Used for">Used for</th>

</tr>

<tr>

<th scope="row" abbr="Description">Description</th>

<td>A description of your extension</td>

</tr>

<tr>

<th scope="row" abbr="Version">Version</th>

<td>The version of your extension</td>

</tr>

<tr>

<th scope="row" abbr="Author">Author</th>

<td>A link to the author of the extension</td>

</tr>

<tr>

<th scope="row" abbr="Priority">Priority</th>

<td>The priority of the extension, in relation to others.</td>

</tr>

</tbody>

</table>

This class will need to reside in the _App_Code\Extensions_ folder of your site. Next step, if you want to have settings, you will need to tell the extension manager that you have settings.  You do this by executing code similar to this, in the constructor of your extension or a method that is called in the constructor of your extension. {% gist jguadagno/11ca726636bebbccfd9682134d6cb953 %} In my extension I call a method called InitializeSettings in the constructor {% gist jguadagno/8e920a10e1a2ac7cbbdd6d16b3cdc62c %} You'll notice that I attached two events, Post.Serving and Page.Serving, to the ServingHandler method. This will tell BlogEngine.NET that I want to know when it is serving up pages or blog posts. ### Handling the page and post serving 

{% gist jguadagno/4d90ae7c81b5fb2c9bd7609fd41ce6df %}

On line 3 you'll not the check to see if the extension is enabled.  Believe it or not, people might turn off your extension. Line 4 checks to see if this is in a feed, if so, we do not want to apply the button to the page or post. Line 6 - 10, I get a reference to the page so that I can inject the required JavaScript for the Google Plus One button.

{% gist jguadagno/bfbf2edcd975eaf6e2f13ec5f963c84e %}

Next, I get a reference to the post and append to the body of the post the Google Plus One button.

{% gist jguadagno/69fa32851db96fecfb4037e96e6de692 %}

That's it. You can download the complete extension here [GooglePlusOne.cs](http://1222-7915.el-alt.com/wp-content/uploads/2015/03/GooglePlusOne.cs_.zip)