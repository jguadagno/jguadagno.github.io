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
A few years ago I built my personal website using [BlogEngine.NET](http://www.dotnetblogengine.net/), every once in a while I tend to pay attention to the site and “freshen it up”.  Back in December of 2011, I upgraded to version 2.5 of BlogEngine.NET and updated the theme.  Last night I added [facebook](http://facebook.com) [like](https://developers.facebook.com/docs/reference/plugins/like/) buttons to all those post and pages courtesy of [isharpnote](http://isharpnote.com/isharpnote/post/2011/03/17/Facebook-Like-Button-Extension-For-BlogEngine-20.aspx "Facebook Like Button Extension For BlogEngine 2.0"). Well I wanted to add a [Google Plus One](http://www.google.com/+1/button/) button to my site also but I could not find any BlogEngine.NET extensions for it, so what does every developer do, create one.  I started with the “[Facebook Like with Google Plus Extension for BlogEngine 2.5](http://isharpnote.com/isharpnote/post/2011/07/24/Facebook-Like-with-Google-Plus-Extension-for-BlogEngine-25.aspx)” extension from isharpnote and tweaked it for my needs.

## Creating the extension

To create a BlogEngine.NET extension you need a class and attribute it with the BlogEngine.Core.Web.Extensions.Extension attribute, like so:

```cs
[Extension(
"Adds the Google Plus One to your blog Posts",
"1.0",
"<a href=’https://www.josephguadagno.net’>Joseph Guadagno</a>",
800)]
```

Parameters explained

|Parameter Name|Used for|
|--- |--- |
|Description|A description of your extension|
|Version|The version of your extension|
|Author|A link to the author of the extension|
|Priority|The priority of the extension, in relation to others.|

This class will need to reside in the `App_Code\Extensions` folder of your site. Next step, if you want to have settings, you will need to tell the extension manager that you have settings.  You do this by executing code similar to this, in the constructor of your extension or a method that is called in the constructor of your extension.

```cs
var settings = new ExtensionSettings(ExtensionName)
  {Help = "Adds Google Plus One to your Post Home page and Post page", IsScalar = true};
  settings.AddParameter("size", "Size", 20, false, false, ParameterType.ListBox);
  settings.AddValue("size", new[] { "standard", "small", "medium", "tall" }, 'standard');
  ExtensionSettings = ExtensionManager.InitSettings(ExtensionName, settings);
```

In my extension I call a method called InitializeSettings in the constructor

```cs
public GooglePlusOne()
{
  InitializeSettings();
  Post.Serving += ServingHandler;
  Page.Serving += ServingHandler;
}
```

You'll notice that I attached two events, Post.Serving and Page.Serving, to the ServingHandler method. This will tell BlogEngine.NET that I want to know when it is serving up pages or blog posts.

### Handling the page and post serving.

```cs
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
```

On line 3 you'll not the check to see if the extension is enabled.  Believe it or not, people might turn off your extension. Line 4 checks to see if this is in a feed, if so, we do not want to apply the button to the page or post. Line 6 - 10, I get a reference to the page so that I can inject the required JavaScript for the Google Plus One button.

```cs
public static void ScriptInject(System.Web.UI.Page page)
{
  HtmlGenericControl googleScript = new HtmlGenericControl("script");
  googleScript.Attributes["type"] = "text/javascript";
  googleScript.Attributes["src"] = "https://apis.google.com/js/plusone.js";
  page.Header.Controls.Add(googleScript);
}
```

Next, I get a reference to the post and append to the body of the post the Google Plus One button.

```cs
public static string GetButton(string url)
{
  string size = ExtensionSettings.GetSingleValue("size") = "standard";
  string googleButton = string.Format("<g:plusone size='{0}' href='{1}'></g:plusone>", size, url);
  return googleButton;
}
```

That's it. You can download the complete extension here [GooglePlusOne.cs](/assets/downloads/GooglePlusOne.cs_.zip)