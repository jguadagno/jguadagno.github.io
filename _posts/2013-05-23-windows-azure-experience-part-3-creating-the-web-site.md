---
id: 201
title: 'Windows Azure Experience–Part 3: Creating the Web Site'
date: 2013-05-23T07:04:00+00:00
author: Joseph Guadagno
layout: post
guid: http://www.josephguadagno.net/post.aspx?id=9a838897-c089-45b0-baa2-1a16a4ae028b
permalink: /2013/05/23/windows-azure-experience-part-3-creating-the-web-site/
dsq_thread_id:
  - "4683673517"
categories:
  - Articles
  - Azure
tags:
  - Azure
  - Microsoft Azure
  - Windows Azure
---
This Part 3 of a <a href="http://1222-7915.el-alt.com/post/2013/05/20/The-Windows-Azure-Experience">series of posts</a> about my “upgrade” to Windows Azure.

Next up in the series is creating the Windows Azure <a href="http://www.windowsazure.com/en-us/manage/services/web-sites/" target="_blank">Web Site</a>. <strong>Note:</strong> <em>This blog post is based on the Preview version of Windows Azure Web Sites and might change in the future.</em>

To get create a new Web Site from the management portal you simply need to click on the <strong>+ New</strong> button.
<h1>Creating the Web Site</h1>
<a href="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/image_12.png"><img style="background-image: none; padding-top: 0px; padding-left: 0px; margin: 0px; display: inline; padding-right: 0px; border: 0px;" title="image" src="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/image_thumb_11.png" alt="image" width="124" height="64" border="0" /></a>

From here a menu will appear. <em>Hint: if you are in the Web Sites section of the Table of Contents, you will get three new web site selections available, otherwise you will have to navigate “Compute" then “Web Site”</em>

<a href="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/image_13.png"><img style="background-image: none; padding-top: 0px; padding-left: 0px; margin: 0px 10px 0px 0px; display: inline; padding-right: 0px; border: 0px;" title="image" src="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/image_thumb_12.png" alt="image" width="645" height="172" border="0" /></a>

You’ll see that I have 3 options

<strong>Quick Create</strong>

Quickly create your web site by specifying a URL. You can perform tasks like deployment and configuration later.

<strong>Custom Create</strong>

Create a web site with additional options, such as a new or existing database, or with continuous deployment from source control.

<strong>From Gallery</strong>

Choose a web application from the gallery. This lets you choose from one of the many preconfigured ASP.NET applications like WordPress.
<h2>Quick Create</h2>
Click on Quick Create and you will be asked to enter a URL and Region for your website like this.

<a href="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/image_14.png"><img style="background-image: none; padding-top: 0px; padding-left: 0px; margin: 0px; display: inline; padding-right: 0px; border: 0px;" title="image" src="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/image_thumb_13.png" alt="image" width="244" height="110" border="0" /></a>

Whether you are choosing a Free, Shared or Reserved web site you must select the subdomain to use with .azurewebsites.net.  The site will do a real time check to see if you have chosen a name that already exists like this.

&nbsp;

<a href="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/image_15.png"><img style="background-image: none; padding-top: 0px; padding-left: 0px; margin: 0px; display: inline; padding-right: 0px; border: 0px;" title="image" src="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/image_thumb_14.png" alt="image" width="244" height="83" border="0" /></a>

If the subdomain you have chosen is valid and available the text box will look like this.

&nbsp;

<a href="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/image_16.png"><img style="background-image: none; padding-top: 0px; padding-left: 0px; margin: 0px; display: inline; padding-right: 0px; border: 0px;" title="image" src="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/image_thumb_15.png" alt="image" width="244" height="114" border="0" /></a>

If you region is good, you can click on Create Web Site.

Unfortunately, I could not get a screen shot to show the status will it was creating but this is what the page looks like after

<a href="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/image_17.png"><img style="background-image: none; padding-top: 0px; padding-left: 0px; margin: 0px 10px 0px 0px; display: inline; padding-right: 0px; border: 0px;" title="image" src="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/image_thumb_16.png" alt="image" width="651" height="171" border="0" /></a>

You’ll notice now that I have a second web site created, in like 10 seconds. with a notification telling me it was complete.
<h2>Custom Create</h2>
For custom complete you are asked for a little bit more information.

&nbsp;

<a href="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/image_18.png"><img style="background-image: none; padding-top: 0px; padding-left: 0px; margin: 0px 10px 0px 0px; display: inline; padding-right: 0px; border: 0px;" title="image" src="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/image_thumb_17.png" alt="image" width="654" height="454" border="0" /></a>

<strong>URL</strong>: Must be a subdomain that is valid an available

<strong>Region:</strong> Chose a region close to where your primary users will be.

<strong>Database: </strong>Select from the following choices

<a href="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/image_19.png"><img style="background-image: none; padding-top: 0px; padding-left: 0px; margin: 0px 10px 0px 0px; display: inline; padding-right: 0px; border: 0px;" title="image" src="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/image_thumb_18.png" alt="image" width="373" height="170" border="0" /></a>

If you have existing databases, you can select one of them.  If you select Create a new SQL Server database or Create a new MySQL database, you will get prompted for more details around that database. <strong>Note:</strong> <em>If the web site region and database region do not match, you will get an alert similar to this.</em>

<a href="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/image_20.png"><img style="background-image: none; padding-top: 0px; padding-left: 0px; margin: 0px 10px 0px 0px; display: inline; padding-right: 0px; border: 0px;" title="image" src="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/image_thumb_19.png" alt="image" width="661" height="56" border="0" /></a>

&nbsp;

<strong>Publish from source control:</strong> If you select this option, you have the ability to chose from one of many options including:
<ul>
	<li>Team Foundation Service</li>
	<li>CodePlex</li>
	<li>GitHub</li>
	<li>DropBox</li>
	<li>Bitbucket</li>
	<li>External repository</li>
	<li>Local Git Repository</li>
</ul>
Each one of these will take to a login page for that service where you can authorize access to the service.
<h2>From Gallery</h2>
For the Gallery, you get to choose from a wide selection of prebuilt sites and templates. These are broken up into categories to make the selection easier.  Here are some (not all) of the out of the cloud templates:
<ul>
	<li>.DotNetNuke</li>
	<li>Acquia Drupal</li>
	<li>ASP.NET Empty Site</li>
	<li>BlogEngine.NET (my favorite)</li>
	<li>DasBlog</li>
	<li>Joomla</li>
	<li>Orchard</li>
	<li>Umbraco</li>
	<li>WordPress</li>
	<li>and many more….</li>
</ul>
Once you choose one, there will be prompts for the specific site you choose to install.