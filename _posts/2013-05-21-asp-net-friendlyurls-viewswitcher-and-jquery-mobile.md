---
id: 241
title: ASP.NET FriendlyUrls ViewSwitcher and jQuery Mobile
date: 2013-05-21T01:55:27+00:00
author: Joseph Guadagno
layout: post
guid: http://www.josephguadagno.net/post.aspx?id=534766bc-7513-45b8-ba02-5aad82a32ca8
permalink: /2013/05/21/asp-net-friendlyurls-viewswitcher-and-jquery-mobile/
dsq_thread_id:
  - "3581937283"
categories:
  - Articles
---
<p>Sometime ago, September of 2012, <a href="http://www.hanselman.com/" target="_blank">Scott Hanselman</a> blogged about a cool new library written for ASP.NET WebForms called <a href="https://aspnetfriendlyurls.codeplex.com/" target="_blank">ASP.NET Friendly URLs</a>. The ASP.NET Friendly URLs library makes it easy to enable extensionless URLs for file-based handlers (e.g. ASPX, ASHX) in ASP.NET applications.&#160; The library itself is very cool. In a nutshell, you, with two lines of code, can have extensionless URLs in ASP.NET web forms and have different pages served up for mobile devices.&#160; Scott Hanselman’s blog post covers all of the details on features and implementation. I wanted to show you a problem that I had with using the library, namely the ViewSwitcher control, with <a href="http://www.jquerymobile.com" target="_blank">jQuery Mobile</a>. </p>  <p>I followed the thorough instructions on Scott Hanselman’s blog post about how to enable or create the mobile version of the site. Essentially you have to create a <em>&lt;MasterPageName&gt;</em>.Mobile.Master and then a <em>&lt;PageName&gt;</em>.Mobile.aspx for each content page that you want a mobile version for.&#160; So in my case I created a SiteMaster.Mobile.aspx, a Default.Mobile.aspx and a EventInfo.Mobile.aspx.&#160; Now when anyone browses the default or EventInfo page of my site with a Mobile device that ASP.NET detects, it will show that page instead and keep the URL the same.&#160; If you want to see it action, visit <a href="http://teched2013.techedevents.info">http://teched2013.techedevents.info</a> from a desktop or mobile device.&#160; The creators of the ASP.NET Friendly URL library also created a helpful little control called ViewSwitcher.&#160; The ViewSwitcher control allows the end user of the site to switch between the “desktop” view of a page and the “mobile” view of the page.&#160; To add it, all you have to do is register the control on the page, and place it where you want on the page.</p>  <h4>Site.Master and Site.Mobile.Master</h4>  
[xml]
&lt;%@ Register Src=&quot;~/ViewSwitcher.ascx&quot; TagPrefix=&quot;friendlyUrls&quot; TagName=&quot;ViewSwitcher&gt;
&lt;!-- Add this where you want the control displayed --/&gt;
&lt;friendlyUrls:ViewSwitcher ID=&quot;ViewSwitcher1&quot; runat=&quot;server&quot; /&gt;
[/xml]

<p>Once these two lines of markup are on your Master Page, the FriendlyUrls library will generate a block of HTML enabling the user to switch views, if the page has an alternate view.</p>

<p>This works great out of the box if you are not using jQuery Mobile and the reason for it is not the FriendlyUrls library but the way jQuery Mobile tries to load pages via <a href="http://jquerymobile.com/demos/1.2.0/docs/pages/page-navmodel.html" target="_blank">Ajax</a>. If you run your application “out of the box” while on a jQuery Mobile based view, and try to switch to Desktop view you will get redirected to <a href="http://domainname/__FriendlyUrls_SwitchView?ReturnUrl=/"><em>http://domainname/__FriendlyUrls_SwitchView?ReturnUrl=/</em></a><em>, </em>or something similar. This is because the FriendlyUrl libraries changes the view using a cookie and the jQuery Mobile framework only attempts to load the changes for the page (not the entire page) so there is a little trouble.&#160; No worries there is a quick fix. If you open up the ViewSwitcher.ascx control and add the following attribute to the anchor tag</p>

[xml]data-ajax=&quot;false&quot;[/xml]

<p>This tells jQuery Mobile to not load that page with Ajax and load the entire page.</p>

<p>Ideally when the library hits the ASP.NET open source stack (its on its way), I or someone else will contribute this to the control to implement this small fix.</p>