---
id: 321
title: Add Google Plus One Extension to BlogEngine.NET
date: 2012-01-18T17:45:00+00:00
author: Joseph Guadagno
layout: post
guid: http://www.josephguadagno.net/post.aspx?id=bb57812a-9788-488b-a86a-e74b06feb9f8
permalink: /2012/01/18/add-google-plus-one-extension-to-blogengine-net/
dsq_thread_id:
  - "3585868671"
categories:
  - Articles
---
A few years ago I built my personal website using <a href="http://www.dotnetblogengine.net/" target="_blank">BlogEngine.NET</a>, every once in a while I tend to pay attention to the site and “freshen it up”.  Back in December of 2011, I upgraded to version 2.5 of BlogEngine.NET and updated the theme.  Last night I added <a href="http://facebook.com" target="_blank">facebook</a> <a href="https://developers.facebook.com/docs/reference/plugins/like/" target="_blank">like</a> buttons to all those post and pages courtesy of <a title="Facebook Like Button Extension For BlogEngine 2.0" href="http://isharpnote.com/isharpnote/post/2011/03/17/Facebook-Like-Button-Extension-For-BlogEngine-20.aspx" target="_blank">isharpnote</a>. Well I wanted to add a <a href="http://www.google.com/+1/button/" target="_blank">Google Plus One</a> button to my site also but I could not find any BlogEngine.NET extensions for it, so what does every developer do, create one.  I started with the “<a href="http://isharpnote.com/isharpnote/post/2011/07/24/Facebook-Like-with-Google-Plus-Extension-for-BlogEngine-25.aspx" target="_blank">Facebook Like with Google Plus Extension for BlogEngine 2.5</a>” extension from isharpnote and tweaked it for my needs.
<h2>Creating the extension</h2>
To create a BlogEngine.NET extension you need a class and attribute it with the BlogEngine.Core.Web.Extensions.Extension attribute, like so:
[csharp]
[Extension(
	&quot;Adds the Google Plus One to your blog Posts&quot;, 
	&quot;1.0&quot;, 
	&quot;&lt;a href='http://www.josephguadagno.net'&gt;Joseph Guadagno&lt;/a&gt;&quot;,
	800)]
[/csharp]
Parameters explained
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
<td >The priority of the extension, in relation to others.</td>
</tr>
</tbody>
</table>
This class will need to reside in the <em>App_Code\Extensions</em> folder of your site.

Next step, if you want to have settings, you will need to tell the extension manager that you have settings.  You do this by executing code similar to this, in the constructor of your extension or a method that is called in the constructor of your extension.
[csharp]
var settings = new ExtensionSettings(ExtensionName)
  {Help = &quot;Adds Google Plus One to your Post Home page and Post page&quot;, IsScalar = true};
  settings.AddParameter(&quot;size&quot;, &quot;Size&quot;, 20, false, false, ParameterType.ListBox);
  settings.AddValue(&quot;size&quot;, new[] { &quot;standard&quot;, &quot;small&quot;, &quot;medium&quot;, &quot;tall&quot; }, 'standard');
  ExtensionSettings = ExtensionManager.InitSettings(ExtensionName, settings);
[/csharp]
In my extension I call a method called InitializeSettings in the constructor
[csharp]
public GooglePlusOne()
{
  InitializeSettings();
  Post.Serving += ServingHandler;
  Page.Serving += ServingHandler;
}[/csharp]
You'll notice that I attached two events, Post.Serving and Page.Serving, to the ServingHandler method. This will tell BlogEngine.NET that I want to know when it is serving up pages or blog posts.
<h3>Handling the page and post serving</h3>
[csharp]
void ServingHandler(object sender, ServingEventArgs e)
{
  if (!ExtensionManager.ExtensionEnabled(ExtensionName)) return;
  if (e.Location == ServingLocation.Feed) return;

  HttpContext context = HttpContext.Current;
  if (context != null)
  {
    System.Web.UI.Page page = context.CurrentHandler as System.Web.UI.Page;
    if (page != null)
    {
      ScriptInject(page);
    }
  }
  var post = sender as Post;
  if (post != null)
      e.Body += GetButton(post.AbsoluteLink.AbsoluteUri);
}
[/csharp]
On line 3 you'll not the check to see if the extension is enabled.  Believe it or not, people might turn off your extension.

Line 4 checks to see if this is in a feed, if so, we do not want to apply the button to the page or post.

Line 6 - 10, I get a reference to the page so that I can inject the required JavaScript for the Google Plus One button.
[csharp]
public static void ScriptInject(System.Web.UI.Page page)
{
  HtmlGenericControl googleScript = new HtmlGenericControl(&quot;script&quot;);
  googleScript.Attributes[&quot;type&quot;] = &quot;text/javascript&quot;;
  googleScript.Attributes[&quot;src&quot;] = &quot;https://apis.google.com/js/plusone.js&quot;;
  page.Header.Controls.Add(googleScript);
}
[/csharp]
Next, I get a reference to the post and append to the body of the post the Google Plus One button.
[csharp]
public static string GetButton(string url)
{
  string size = ExtensionSettings.GetSingleValue(&quot;size&quot;) = &quot;standard&quot;;
  string googlebutton = string.Format(&quot;&lt;g:plusone size='{0}' href='{1}'&gt;&lt;/g:plusone&gt;&quot;, size, url);
  return googlebutton;
}
[/csharp]
That's it. You can download the complete extension here <a href="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/GooglePlusOne.cs_.zip">GooglePlusOne.cs</a>