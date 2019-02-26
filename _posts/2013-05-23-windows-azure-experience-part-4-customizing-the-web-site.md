---
title: 'Windows Azure Experience–Part 4: Customizing the Web Site'
date: 2013-05-23T07:52:00+00:00
author: Joseph Guadagno
permalink: /2013/05/23/windows-azure-experience-part-4-customizing-the-web-site/
dsq_thread_id:
  - "3615331577"
categories:
  - Articles
  - Azure
tags:
  - Azure
  - Microsoft Azure
  - Windows Azure
---

This Part 4 of a [series of posts]({% link _posts/2013-05-21-the-windows-azure-experience.md %}) about my “upgrade” to Windows Azure. Next up in the series is customizing the Windows Azure [Web Site](http://www.windowsazure.com/en-us/manage/services/web-sites/). **Note:** _This blog post is based on the Preview version of Windows Azure Web Sites and might change in the future._ _Note: There is an [article](http://www.windowsazure.com/en-us/manage/services/web-sites/how-to-configure-websites/) on the Windows Azure site that will cover some of this content._

## Getting Started

When you first come to you web site from the management portal you are presented with a screen similar to this. [![image](/assets/images/posts/image_thumb_20.png "image")](/assets/images/posts/image_21.png) The start page gives you three options:

### Get the tools

WebMatrix is a free, lightweight web development tool that includes everything you need to create web sites and publish applications for Windows Azure. WebMatrix supports the latest web technologies, including ASP.NET, PHP, HTML5, CSS3, Node and more. The Windows Azure SDKs allow you to build applications that take advantage of Windows Azure's scalable cloud computing resources.

#### Web Matrix

Clicking on this link will redirect you to the latest and greatest version of [WebMatrix](http://www.microsoft.com/web/webmatrix/).

#### Install a Windows Azure SDK

Clicking on this link will redirect your to the downloads page for all of the [Windows Azure SDKs](http://www.windowsazure.com/en-us/downloads/?fb=en-us). There are SDKs available for Mobile development, including Andriod, iOS, Windows Phone 8, and Windows Store. Here are some of the others

* .NET: Visual Studio 2010, Visual Studio 2012
* Node.js
* PHP
* Java
* Python
* Ruby
* Media libraries and player frameworks.

### Publish your app

After you set up a web site and dependent resources, such as a database, you can download the generated publish profile, import it into a development tool such as WebMatrix or Visual Web Developer, and deploy your web site to Windows Azure within seconds. You can also publish your web application from FTP directly by setting up deployment credentials in the portal and pushing the application to Windows Azure from your favorite FTP client. There will be more on this in a future blog post.

### Integrate source control

Set up continuous deployment from source control providers like TFS, CodePlex, GitHub, Dropbox, or Bitbucket. You can also deploy from a local Git repository on your machine. There will be more on this in a future blog post.

## Dashboard

### Monitor

The dashboard allows you to see some performance metrics of your site. These are CPU Time, Data In, Data Out, HTTP Server Errors, and Requests. [![image](/assets/images/posts/image_thumb_21.png "image")](/assets/images/posts/image_22.png)  

### Usage Overview

The usage overview shows you where you might be in trouble of hitting the limits of the the type of site you have (free, shared, reserved). [![image](/assets/images/posts/image_thumb_22.png "image")](/assets/images/posts/image_23.png)  

### Quick Glance

This shows you every thing that you will need to connect to your Windows Azure services. [![image](/assets/images/posts/image_thumb_23.png "image")](/assets/images/posts/image_24.png)

## Monitor

The monitor displays the some of the web sites performance counters like CPU time, Data In, Data Out, etc. [![image](/assets/images/posts/image_thumb_24.png "image")](/assets/images/posts/image_25.png)

## Configure

### General

Choose the version of .NET language runtime to use. The current supported version is v.3.5 and v4.5 Choose the version of PHP to use. The current supported versions are 5.3 and 5.4.

### Domain Names

Lists the domain names that are associated with your account. If you have a Shared or Reserved instance, you can click on Manage domains to add or remove domains or subdomains.

### App Diagnostics

You can turn on any of the application diagnostics like application logging to the file system and application logging to a Windows Azure Storage account.

### Site Diagnostics

You can turn on any of the three site wide diagnostics settings like Web Server Logging, Detailed Error Messages, and Failed Request Tracing.

### Monitoring

Endpoint monitoring lets you monitor the availability of HTTP or HTTPS endpoints from geo-distributed locations. You can test an endpoint from up to three geo-distributed locations. A monitoring test fails if the HTTP response code is greater than or equal to 400 or if the response takes more than 30 seconds. An endpoint is considered available if its monitoring tests succeed from all the specified locations.

### App Settings

Specify name/value pairs that will be loaded by your web application when it starts.

### Connection Strings

Show any connection strings associated with linked resources.

### Default Documents

Use this setting to add, remove, or reorder your web site's default documents.

### Handler Mappings

Specify a custom script processor to handle requests for the file extension that you specified. To do this, provide a path for the custom script. The path must be relative to the FTP root directory of the web site. You can use optional arguments.

## Scale

### General

Windows Azure offers three modes for you to run your web sites: Free, Shared, and Reserved. In the Free and Shared modes, all web sites run in a multi-tenant environment and have quotas for usage of CPU, memory, and network resources. You can decide which sites you want to run in Free mode and which sites you want to run in Shared mode. Shared mode employs less stringent resource usage quotas than Free mode. The maximum number of sites you can run in Free mode may vary with your plan. When you choose Reserved mode, all your web sites run in Reserved mode on dedicated virtual machines that correspond to standard Windows Azure compute resources. **Note:** _This can affect the cost of running your web site on Windows Azure._

### Capacity

This count denotes the number of processes dedicated to a web site. By increasing the value for this setting, you can scale your web site for additional throughput and availability. **Note:** _This can affect the cost of running your web site on Windows Azure._

## Linked Resources

This will show you a list of other Windows Azure Services that you have linked or attached to the web site, like a database.