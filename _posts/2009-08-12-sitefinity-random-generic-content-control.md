---
id: 711
title: 'Sitefinity: Random Generic Content Control'
date: 2009-08-12T18:19:45+00:00
author: Joseph Guadagno
layout: post
guid: http://www.josephguadagno.net/post.aspx?id=6ffa2a6a-fffa-4b6d-bb7c-64d87e81119c
permalink: /2009/08/12/sitefinity-random-generic-content-control/
dsq_thread_id:
  - "3612632845"
categories:
  - Articles
  - Web
tags:
  - Sitefinity
---
<div id="scid:fb3a1972-4489-4e52-abe7-25a00bb07fdf:9efd1a4d-f480-4279-984c-4d9c0ca71649" class="wlWriterEditableSmartContent" style="display: inline; float: none; margin: 0px; padding: 0px;">

<a href="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/RandomGCContent.zip">RandomGCContent</a>

</div>
One of the many features of <a title="Sitefinity" href="http://www.sitefinity.com" target="_blank">Sitefinity</a> is the ability to create custom controls to customize the look and feel of your website. The website for the <a title="Southeast Valley .NET User Group" href="http://www.sevdnug.org" target="_blank">Southeast Valley .NET User Group</a> contains several custom controls. In the next few weeks I will post all of the controls here.

<a href="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/sponsor.png"><img style="display: inline; margin: 0px 0px 0px 5px; border-width: 0px;" title="Sponsor Image" src="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/sponsor_thumb.png" alt="Sponsor Image" width="174" height="240" align="right" border="0" /></a>On to the Random Generic Content Control. The purpose of the control is randomly display items that are based on a Generic  Content provider. I use this control to randomly pick sponsors of the Southeast Valley .NET User Group to display on the home page. Here is a snapshot of the control in use.
<h3>Installing the Control</h3>
Installing the control is a three part process.

<p>The first step is to add the control to Sitefinity.  This can be done one of three ways.  Which way you choose depends on your technical ability. Here is a list of options in order of least technical to most technical.</p>
<ol>
	<li>Add the class RandomGCControl.cs in the zip file to the App_Code folder of your Sitefinity project.</li>
	<li>Create a Visual Studio class library project, add the RandomGCControl.cs class to it. You will need to add the following references to the project; Telerik.Cms, Telerik.Cms.Engine, Telerik.Cms.Web.UI, Telerik.Framework, Telerik.Personalization, and Telerik.Web.UI. Compile the class, then upload it as documented by the Sitefinity article “<a title="Adding controls to Sitefinity" href="http://www.sitefinity.com/help/developer-manual/controls-adding-controls-to-sitefinity.html" target="_blank">Adding Controls</a>”</li>
	<li>Create a separate class project as outlined in the step above  then add a reference to this project to your Sitefinity project.</li>
</ol>
The next step is let Sitefinity know about the new control. Note: this step is not required if you compiled the control and uploaded it through the Sitefinity interface. To do this you need to modify the web.config file.  The controls are listed in the cms/toolboxControls section. Add the following:

<script src="https://gist.github.com/jguadagno/ac74faebc41ae02f184f6c968b625d58.js"></script>

If you followed the steps, the next you go to edit a page in Sitefinity you should see the Random Generic Content control available in the SEVDNUG group.
<h3>Configuring the Control</h3>
<p>The Random Generic Content control has four properties that you need configure.</p>

<table class="table table-striped table-bordered">
<thead>
<tr>
<th>Property name</td>
<th>Function</td>
</tr>
</thead>
<tbody>
<tr>
<td>Item List Template File (Appearance Section)</td>
<td>Controls the overall look of items that appear. This file dictates the display of the generic content.</td>
</tr>
<tr>
<td>Generic Content Details Url (Appearance section)</td>
<td>This property points to the single page where you want Sitefinity to navigate to when an item is clicked.  This is typically the same page that hosts this generic item.</td>
</tr>
<tr>
<td>Number Of Items (Data section)</td>
<td>Indicates how many generic items to display.</td>
</tr>
<tr>
<td>Provider Name (Data Section)</td>
<td>Indicates which generic item provider to use.</td>
</tr>
</tbody>
</table>

<h3>Customizing the Control</h3>
To customize the display of the control, you will need to edit the file that you specified in the Item List Template File property of the control.  There is a sample template in the attached file.

<script src="https://gist.github.com/jguadagno/1efaf087b734d5aebca231aa3668b50a.js"></script>

<p>The control will look for form field names that match the names of the meta keys for that provider and replace them with the value of the meta key.</p>
<p>Here is an example of the sponsor template used to generate the image above.</p>

<script src="https://gist.github.com/jguadagno/22da985c248576ae34abaf6ecc00a46e.js"></script>

Hopefully, you will find this control useful.  Look for some more controls and providers soon.