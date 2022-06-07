---
title: Converting an ASP.NET “Mobile” site to use jQuery Mobile
date: 2011-12-31T22:54:55+00:00
permalink: /2011/12/31/converting-an-asp-net-mobile-site-to-use-jquery-mobile/
dsq_thread_id:
  - "3617142059"
categories:
  - Articles
tags:
  - jQuery
  - Web
---
Building upon my previous post [Introduction to jQuery Mobile]({% link _posts/2011-12-31-introduction-to-jquery-mobile.md %}), I wanted to share how I converted the [Microsoft Global MVP Summit mobile](http://www.mvpsummitevents.info/m/default.aspx){:target="_blank"} site to use [jQuery Mobile](http://jquerymobile.com/){:target="_blank"}.

## Getting Started

The first step was to look at the existing ASP.NET Master Page that the site was using and see where I had to make changes.  I included the skeleton mobile master page, prior to jQuery Mobile below.  Please note, I removed parts of the page that do not relate to the blog post.

```html
<%@ Master Language="C#"
  AutoEventWireup="true"
  CodeBehind="Mobile.master.cs"
  Inherits="MVPSummitEvents.Website.Mobile" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
  "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
  <title>MVP Summit Events - Mobile - </title>
  <asp:ContentPlaceHolder ID="head" runat="server">
  </asp:ContentPlaceHolder>
</head>
<body>
  <form id="form1" runat="server">
  <div id="mHead"><h1>MVP Summit Events</h1></div>
  <div id="mMenu">
    <asp:HyperLink runat="server" ID="hlMain"
      NavigateUrl="~/m/default.aspx" Text="Home" ToolTip="Home" /> |
    <asp:HyperLink runat="server" ID="hlMap"
      NavigateUrl="~/m/map.aspx" Text="Map" ToolTip="Map" /> |
    <a href="http://tinyurl.com/4e5mp5p"
      title="Windows Phone 7 App">Window Phone 7</a> App. |
    <a href="http://itunes.apple.com/us/app/mvp-events/id416291827?mt=8">iPhone</a> App.
  </div>
  <div id="mBody">
    <asp:ContentPlaceHolder ID="CphBody" runat="server">
    </asp:ContentPlaceHolder>
  </div>
  </form>
  <div id="mFoot">Copyright ©2009-2012,
    <a href="https://www.josephguadagno.net" title="Joseph Guadagno">Joseph Guadagno</a> |
    <a href="http://twitter.com/jguadagno" title="Follow jguadagno">@jguadagno</a> |
    <a href="mailto:jguadagno@hotmail.com">Contact</a>
  </div>
</body>
</html>
```

## Converting the document head

The first thing I needed to do was to update the DOCTYPE on line 3 to

```html
<!DOCTYPE HTML>
```

Next was to include the jQuery Mobile scripts and CSS files, after that my head section looked like this:

```html
<%@ Master Language="C#"
  AutoEventWireup="true"
  CodeBehind="Mobile.master.cs"
  Inherits="MVPSummitEvents.Website.Mobile" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
  <title>MVP Summit Events - Mobile - </title>
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet"
    href="http://code.jquery.com/mobile/1.0/jquery.mobile-1.0.min.css" />
  <script type="text/javascript"
    src="http://code.jquery.com/jquery-1.6.4.min.js"></script>
  <script type="text/javascript"
    src="http://code.jquery.com/mobile/1.0/jquery.mobile-1.0.min.js"></script>
  <asp:ContentPlaceHolder ID="HeadContent" runat="server" />
  <link id="Link1" rel="stylesheet" runat="server" href="/css/m.css" />
  <script type="text/javascript" src="../js/analytics.js"></script>
  <script type="text/javascript" src="../js/analytics.jqmobile.js"></script>
</head>
```

Again, I removed parts that are not required for this post.

You should notice that line 5 is now different and I added lines 9 - 15\. Line 9 contains the viewport meta tag, the description from the jQuery Mobile docs is …

Note above that there is a meta `viewport` tag in the `head` to specify how the browser should display the page zoom level and dimensions. If this isn't set, many mobile browsers will use a "virtual" page width around 900 pixels to make it work well with existing desktop sites but the screens may look zoomed out and too wide. By setting the viewport attributes to `content="width=device-width, initial-scale=1"`, the width will be set to the pixel width of the device screen.

Lines 10-15 contain the references to the jQuery Mobile style sheet, the jQuery library and the jQuery Mobile library. Line 19, is a workaround for using Google Analytics which is described [here](http://www.jongales.com/blog/2011/01/10/google-analytics-and-jquery-mobile/){:target="_blank"}.

## Converting the Document Body

Looking at the body of Master Page, I was almost ready for the jQuery Mobile conversion.

```html
<div id="mHead"><h1>MVP Summit Events</h1></div>
<div id="mMenu">
  <asp:HyperLink runat="server"
    ID="hlMain"
    NavigateUrl="~/m/default.aspx"
    Text="Home" ToolTip="Home" /> |
  <asp:HyperLink runat="server"
    ID="hlMap" 
    NavigateUrl="~/m/map.aspx"
    Text="Map" ToolTip="Map" /> |
  <a href="http://tinyurl.com/4e5mp5p"
    title="Windows Phone 7 App">Window Phone 7</a> App. |
  <a href="http://itunes.apple.com/us/app/mvp-events/id416291827?mt=8">iPhone</a> App.
</div>
<div id="mBody">
  <asp:ContentPlaceHolder ID="CphBody" runat="server">
  </asp:ContentPlaceHolder>
</div>
<div id="mFoot">Copyright ©2009-2012,
  <a href="http://www.josephguadagno.net" title="Joseph Guadagno">Joseph Guadagno</a> |
  <a href="http://twitter.com/jguadagno" title="Follow jguadagno">@jguadagno</a> |
  <a href="mailto:jguadagno@hotmail.com">Contact</a>
</div>
```

I have my Master Page broken up into a header, menu, body, and footer. All I had to do was assign the jQuery Mobile data-role attributes and I was done. However, I took this time to “tweak” the layout of the mobile site look more like it would on the iPhone and other mobile devices. I still keep the header, but moved the menu to the footer section and moved the existing footer to an about page. The new body of the mobile Master Page looks like this.

```html
<div data-role="page">
  <div data-role="header" data-theme="b">
    <h1><asp:Label runat="server" ID="HeaderLabel"></asp:Label></h1>
  </div>
  <div data-role="content" data-theme="b">
    <asp:ContentPlaceHolder ID="BodyContent" runat="server">
    </asp:ContentPlaceHolder>  
  </div>
  <div data-role="footer" data-theme="b">
    <div data-role="navbar">
      <ul>
        <li><asp:HyperLink runat="server"
          NavigateUrl="~/m/default.aspx" data-icon="home">Home</asp:HyperLink></li>
        <li><asp:HyperLink runat="server"
          NavigateUrl="~/m/map.aspx" data-ajax="false">Map</asp:HyperLink></li>
        <li><asp:HyperLink runat="server"
          NavigateUrl="~/m/Apps.aspx">Apps</asp:HyperLink></li>
        <li><asp:HyperLink runat="server"
        NavigateUrl="~/m/About.aspx" data-icon="info">About</asp:HyperLink></li>
      </ul>
    </div>
  </div>
</div>
```

To me this seems quite readable and clearly identifies what each section (`div`) is responsible for.

Let's break it down.

First, all the previous DIV's in between the FORM tags where placed within a

```html
<div data-role="page"></div>
```

tag. The next step was to convert each of the DIV's that I had into a jQuery Mobile DIV. There is really no ‘jQuery Mobile DIV' just an attribute that tells jQuery what “section” of the document this div is for. I added the `data-role=”header”` to the DIV with the ID of `mHead`, I added the `data-role=”content”` to the DIV with the ID of mBody and I added the `data-role=”footer”` to the DIV with the ID of `mFooter`.

“Ok, but what happened to the mMenu DIV,” you ask. Take a look at line 8 in the code sample above. I moved the “menu” to the footer of the new document and assigned it a `data-role` of the `navbar`. This is a jQuery Mobile widget that creates a simple menu of buttons out of all of the listitem elements of the unordered list. The data-icon attribute is an attribute that allows you to indicate one of the 18 built-in icons for any jQuery Mobile button.

After this, I was done. I now have a jQuery Mobile version of the Microsoft Global MVP Summit site that looks the same on virtually every mobile browser with little to no work.

Up next, how to convert other elements of an ASP.NET mobile site to use jQuery Mobile widgets.