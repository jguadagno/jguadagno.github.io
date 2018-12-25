---
id: 191
title: 'Windows Azure Experience–Part 4: Customizing the Web Site'
date: 2013-05-23T07:52:00+00:00
author: Joseph Guadagno
layout: post
guid: http://www.josephguadagno.net/post.aspx?id=36ecf272-2c6a-42db-84d8-dffb8336a855
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
This Part 4 of a <a href="http://1222-7915.el-alt.com/post/2013/05/20/The-Windows-Azure-Experience">series of posts</a> about my “upgrade” to Windows Azure.

Next up in the series is customizing the Windows Azure <a href="http://www.windowsazure.com/en-us/manage/services/web-sites/" target="_blank">Web Site</a>. <strong>Note:</strong> <em>This blog post is based on the Preview version of Windows Azure Web Sites and might change in the future. </em>

<em>Note: There is an <a href="http://www.windowsazure.com/en-us/manage/services/web-sites/how-to-configure-websites/" target="_blank">article</a> on the Windows Azure site that will cover some of this content.</em>
<h1>Getting Started</h1>
When you first come to you web site from the management portal you are presented with a screen similar to this.

<a href="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/image_21.png"><img style="background-image: none; padding-top: 0px; padding-left: 0px; margin: 0px 10px 0px 0px; display: inline; padding-right: 0px; border-width: 0px;" title="image" src="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/image_thumb_20.png" alt="image" width="643" height="486" border="0" /></a>

The start page gives you three options:
<h2>Get the tools</h2>
WebMatrix is a free, lightweight web development tool that includes everything you need to create web sites and publish applications for Windows Azure. WebMatrix supports the latest web technologies, including ASP.NET, PHP, HTML5, CSS3, Node and more. The Windows Azure SDKs allow you to build applications that take advantage of Windows Azure's scalable cloud computing resources.
<h3>Web Matrix</h3>
Clicking on this link will redirect you to the latest and greatest version of <a href="http://www.microsoft.com/web/webmatrix/" target="_blank">WebMatrix</a>.
<h3>Install a Windows Azure SDK</h3>
Clicking on this link will redirect your to the downloads page for all of the <a href="http://www.windowsazure.com/en-us/downloads/?fb=en-us" target="_blank">Windows Azure SDKs</a>. There are SDKs available for Mobile development, including Andriod, iOS, Windows Phone 8, and Windows Store. Here are some of the others
<ul>
	<li>.NET: Visual Studio 2010, Visual Studio 2012</li>
	<li>Node.js</li>
	<li>PHP</li>
	<li>ava</li>
	<li>Python</li>
	<li>Ruby</li>
	<li>Media libraries and player frameworks.</li>
</ul>
<h2>Publish your app</h2>
After you set up a web site and dependent resources, such as a database, you can download the generated publish profile, import it into a development tool such as WebMatrix or Visual Web Developer, and deploy your web site to Windows Azure within seconds. You can also publish your web application from FTP directly by setting up deployment credentials in the portal and pushing the application to Windows Azure from your favorite FTP client.

There will be more on this in a future blog post.
<h2>Integrate source control</h2>
Set up continuous deployment from source control providers like TFS, CodePlex, GitHub, Dropbox, or Bitbucket. You can also deploy from a local Git repository on your machine.

There will be more on this in a future blog post.
<h1>Dashboard</h1>
<h2>Monitor</h2>
The dashboard allows you to see some performance metrics of your site. These are CPU Time, Data In, Data Out, HTTP Server Errors, and Requests.

<a href="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/image_22.png"><img style="background-image: none; padding-top: 0px; padding-left: 0px; margin: 0px 10px 0px 0px; display: inline; padding-right: 0px; border-width: 0px;" title="image" src="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/image_thumb_21.png" alt="image" width="640" height="176" border="0" /></a>

&nbsp;
<h2>Usage Overview</h2>
The usage overview shows you where you might be in trouble of hitting the limits of the the type of site you have (free, shared, reserved).

<a href="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/image_23.png"><img style="background-image: none; padding-top: 0px; padding-left: 0px; margin: 0px 10px 0px 0px; display: inline; padding-right: 0px; border-width: 0px;" title="image" src="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/image_thumb_22.png" alt="image" width="652" height="404" border="0" /></a>

&nbsp;
<h2>Quick Glance</h2>
This shows you every thing that you will need to connect to your Windows Azure services.

<a href="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/image_24.png"><img style="background-image: none; padding-top: 0px; padding-left: 0px; margin: 0px 10px 0px 0px; display: inline; padding-right: 0px; border: 0px;" title="image" src="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/image_thumb_23.png" alt="image" width="201" height="652" border="0" /></a>
<h1>Monitor</h1>
The monitor displays the some of the web sites performance counters like CPU time, Data In, Data Out, etc.

<a href="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/image_25.png"><img style="background-image: none; padding-top: 0px; padding-left: 0px; margin: 0px 10px 0px 0px; display: inline; padding-right: 0px; border: 0px;" title="image" src="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/image_thumb_24.png" alt="image" width="645" height="351" border="0" /></a>
<h1>Configure</h1>
<h2>General</h2>
Choose the version of .NET language runtime to use. The current supported version is v.3.5 and v4.5

Choose the version of PHP to use. The current supported versions are 5.3 and 5.4.
<h2>Domain Names</h2>
Lists the domain names that are associated with your account. If you have a Shared or Reserved instance, you can click on Manage domains to add or remove domains or subdomains.
<h2>App Diagnostics</h2>
You can turn on any of the application diagnostics like application logging to the file system and application logging to a Windows Azure Storage account.
<h2>Site Diagnostics</h2>
You can turn on any of the three site wide diagnostics settings like Web Server Logging, Detailed Error Messages, and Failed Request Tracing.
<h2>Monitoring</h2>
Endpoint monitoring lets you monitor the availability of HTTP or HTTPS endpoints from geo-distributed locations. You can test an endpoint from up to three geo-distributed locations. A monitoring test fails if the HTTP response code is greater than or equal to 400 or if the response takes more than 30 seconds. An endpoint is considered available if its monitoring tests succeed from all the specified locations.
<h2>App Settings</h2>
Specify name/value pairs that will be loaded by your web application when it starts.
<h2>Connection Strings</h2>
Show any connection strings associated with linked resources.
<h2>Default Documents</h2>
Use this setting to add, remove, or reorder your web site's default documents.
<h2>Handler Mappings</h2>
Specify a custom script processor to handle requests for the file extension that you specified. To do this, provide a path for the custom script. The path must be relative to the FTP root directory of the web site. You can use optional arguments.
<h1>Scale</h1>
<h2>General</h2>
Windows Azure offers three modes for you to run your web sites: Free, Shared, and Reserved. In the Free and Shared modes, all web sites run in a multi-tenant environment and have quotas for usage of CPU, memory, and network resources. You can decide which sites you want to run in Free mode and which sites you want to run in Shared mode. Shared mode employs less stringent resource usage quotas than Free mode. The maximum number of sites you can run in Free mode may vary with your plan. When you choose Reserved mode, all your web sites run in Reserved mode on dedicated virtual machines that correspond to standard Windows Azure compute resources.

<strong>Note:</strong> <em>This can affect the cost of running your web site on Windows Azure.</em>
<h2>Capacity</h2>
This count denotes the number of processes dedicated to a web site. By increasing the value for this setting, you can scale your web site for additional throughput and availability.

<strong>Note:</strong> <em>This can affect the cost of running your web site on Windows Azure.</em>
<h1>Linked Resources</h1>
This will show you a list of other Windows Azure Services that you have linked or attached to the web site, like a database.