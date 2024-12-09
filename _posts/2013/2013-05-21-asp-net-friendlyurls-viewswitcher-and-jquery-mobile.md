---
title: ASP.NET FriendlyUrls ViewSwitcher and jQuery Mobile
date: 2013-05-21T01:55:27+00:00
permalink: /2013/05/21/asp-net-friendlyurls-viewswitcher-and-jquery-mobile/
dsq_thread_id:
  - "3581937283"
categories:
  - Articles
tags:
  - Technology
  - ASP.NET
  - jQuery Mobile
---

Sometime ago, September of 2012, [Scott Hanselman](https://www.hanselman.com/){:target="_blank"} blogged about a cool new library written for ASP.NET WebForms called [ASP.NET Friendly URLs](https://aspnetfriendlyurls.codeplex.com/){:target="_blank"}. The ASP.NET Friendly URLs library makes it easy to enable extensionless URLs for file-based handlers (e.g. ASPX, ASHX) in ASP.NET applications.  The library itself is very cool. In a nutshell, you, with two lines of code, can have extensionless URLs in ASP.NET web forms and have different pages served up for mobile devices.  Scott Hanselman's blog post covers all of the details on features and implementation. I wanted to show you a problem that I had with using the library, namely the ViewSwitcher control, with [jQuery Mobile](https://www.jquerymobile.com){:target="_blank"}.

I followed the thorough instructions on Scott Hanselman's blog post about how to enable or create the mobile version of the site. Essentially you have to create a `**<MasterPageName>**.Mobile.Master` and then a `**<PageName>**.Mobile.aspx` for each content page that you want a mobile version for.  So in my case I created a SiteMaster.Mobile.aspx, a Default.Mobile.aspx and a EventInfo.Mobile.aspx.  Now when anyone browses the default or EventInfo page of my site with a Mobile device that ASP.NET detects, it will show that page instead and keep the URL the same.  If you want to see it action, visit [https://teched2013.techedevents.info](https://teched2013.techedevents.info){:target="_blank"} from a desktop or mobile device.  The creators of the ASP.NET Friendly URL library also created a helpful little control called ViewSwitcher.  The ViewSwitcher control allows the end user of the site to switch between the “desktop” view of a page and the “mobile” view of the page.  To add it, all you have to do is register the control on the page, and place it where you want on the page.

## Site.Master and Site.Mobile.Master

```html
<%@ Register Src="~/ViewSwitcher.ascx" TagPrefix="friendlyUrls" TagName="ViewSwitcher>
<!– Add this where you want the control displayed –/>
<friendlyUrls:ViewSwitcher ID="ViewSwitcher1" runat="server" />
```

Once these two lines of markup are on your Master Page, the FriendlyUrls library will generate a block of HTML enabling the user to switch views, if the page has an alternate view.

This works great out of the box if you are not using jQuery Mobile and the reason for it is not the FriendlyUrls library but the way jQuery Mobile tries to load pages via [Ajax](https://jquerymobile.com/demos/1.2.0/docs/pages/page-navmodel.html){:target="_blank"}. If you run your application “out of the box” while on a jQuery Mobile based view, and try to switch to Desktop view you will get redirected to [https://domainname/_FriendlyUrls_SwitchView?ReturnUrl=/](https://domainname/_FriendlyUrls_SwitchView?ReturnUrl=/){:target="_blank"},_ or something similar. This is because the FriendlyUrl libraries changes the view using a cookie and the jQuery Mobile framework only attempts to load the changes for the page (not the entire page) so there is a little trouble.  No worries there is a quick fix. If you open up the ViewSwitcher.ascx control and add the following attribute to the anchor tag

```js
data-ajax="false"
```

This tells jQuery Mobile to not load that page with Ajax and load the entire page.

Ideally when the library hits the ASP.NET open source stack (its on its way), I or someone else will contribute this to the control to implement this small fix.
