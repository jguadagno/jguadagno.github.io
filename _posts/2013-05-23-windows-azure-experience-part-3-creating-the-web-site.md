---
title: 'Windows Azure Experience–Part 3: Creating the Web Site'
date: 2013-05-23T07:04:00+00:00
author: Joseph Guadagno
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

This Part 3 of a [series of posts]({% link _posts/2013-05-21-the-windows-azure-experience.md %}) about my “upgrade” to Windows Azure. Next up in the series is creating the Windows Azure [Web Site](http://www.windowsazure.com/en-us/manage/services/web-sites/). **Note:** _This blog post is based on the Preview version of Windows Azure Web Sites and might, change in the future._ To get create a new Web Site from the management portal you simply need to click on the **+ New** button.

## Creating the Web Site

[![image](/assets/images/posts/image_thumb_11.png "image")](/assets/images/posts/image_12.png) From here a menu will appear. _Hint: if you are in the Web Sites section of the Table of Contents, you will get three new web site selections available, otherwise you will have to navigate “Compute" then “Web Site”_ [![image](/assets/images/posts/image_thumb_12.png "image")](/assets/images/posts/image_13.png) You’ll see that I have 3 options **Quick Create** Quickly create your web site by specifying a URL. You can perform tasks like deployment and configuration later. **Custom Create** Create a web site with additional options, such as a new or existing database, or with continuous deployment from source control. **From Gallery** Choose a web application from the gallery. This lets you choose from one of the many preconfigured ASP.NET applications like WordPress.

### Quick Create

Click on Quick Create and you will be asked to enter a URL and Region for your website like this.

[![image-center](/assets/images/posts/image_thumb_13.png "image")](/assets/images/posts/image_14.png){: .align-center}

Whether you are choosing a Free, Shared or Reserved web site you must select the subdomain to use with .azurewebsites.net.  The site will do a real time check to see if you have chosen a name that already exists like this.

[![image-center](/assets/images/posts/image_thumb_14.png "image")](/assets/images/posts/image_15.png){: .align-center}

If the subdomain you have chosen is valid and available the text box will look like this.

[![image-center](/assets/images/posts/image_thumb_15.png "image")](/assets/images/posts/image_16.png){: .align-center} If your region is good, you can click on Create Web Site. Unfortunately, I could not get a screenshot to show the status will it was creating but this is what the page looks like after.

[![image-center](/assets/images/posts/image_thumb_16.png "image")](/assets/images/posts/image_17.png){: .align-center}

You’ll notice now that I have a second web site created, in like 10 seconds. with a notification telling me it was complete.

### Custom Create

For custom complete, you are asked for a little bit more information. [![image](/assets/images/posts/image_thumb_17.png "image")](/assets/images/posts/image_18.png)

**URL**: Must be a subdomain that is valid an available

**Region:** Chose a region close to where your primary users will be.

**Database:** Select from the following choices [![image-right](/assets/images/posts/image_thumb_18.png "image")](/assets/images/posts/image_19.png){: .align-right} If you have existing databases, you can select one of them.  If you select Create a new SQL Server database or Create a new MySQL database, you will get prompted for more details around that database. **Note:** _If the web site region and database region do not match, you will get an alert similar to this._
[![image](/assets/images/posts/image_thumb_19.png "image")](/assets/images/posts/image_20.png)

**Publish from source control:** If you select this option, you have the ability to chose from one of many options including:

* Team Foundation Service
* CodePlex
* GitHub
* DropBox
* Bitbucket
* External repository
* Local Git Repository

Each one of these will take to a login page for that service where you can authorize access to the service.

### From the Gallery

For the Gallery, you get to choose from a wide selection of prebuilt sites and templates. These are broken up into categories to make the selection easier.  Here are some (not all) of the out of the cloud templates:

* DotNetNuke
* Acquia Drupal
* ASP.NET Empty Site
* BlogEngine.NET (my favorite)
* DasBlog
* Joomla
* Orchard
* Umbraco
* WordPress
* and many more….

Once you choose one, there will be prompts for the specific site you choose to install.