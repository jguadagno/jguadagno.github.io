---
id: 841
title: Telerik.Events
date: 2008-04-25T21:57:12+00:00
author: Joseph Guadagno

guid: http://www.josephguadagno.net/post.aspx?id=d8a7d4ff-a840-4965-9d60-cb6f7b25b1c7
permalink: /2008/04/25/telerik-events/
dsq_thread_id:
  - "3618030515"
categories:
  - Articles
---
<!-- TODO: Fix Tables, clean up formatting -->
This module is responsible for adding, removing, deleting events from the Sitefinity system. This guide is meant to supplement the documentation that is available for Sitefinity. This document will cover the following:

* [Files for events module](#files)
* [Creating an event](#create_event)
* [Deleting an event](#delete_event)
* [Adding meta fields to an event](#add_meta)
* [Adding the missing RSS Provider](#add_rss)

As of the time when this was written, development documentation does not exist for the Telerik.Events assembly. The code samples where either "figured out" or derived from other samples. Thanks to Visual Studio®'s Intellisense® feature, Visual Studio®'s Object Browser and [Reflector](http://www.aisto.com/roeder/dotnet/), I figured out most of it. In order to work with events in Sitefinity, you must add a reference to the Telerik.Events assembly. This assembly is already included in the Sitefinity install; it is mentioned in case you want to create a separate assembly for your events customization. The Telerik.Events.EventsManager handles all of the event management. An instance of the EventManager can be created like this. {% gist jguadagno/6885bd80571ec112e6aea3f45f27e9ac %}> After this, the eventsManager object will contain all the methods that you should need.

## <a name="files"></a>Files for events module

Like most (if not all) modules, the templates or user controls are keep in two directories underneath the /Sitefinity folder, the Sitefinity\Admin\ControlTemplates\<ModuleName>, in this case Events and Sitefinity\ControlTemplates\<ModuleName>. Within these directories, you will find a collection of files and one folder App_Resources. The App_Resources folder provides Sitefinity (or any .NET application) the ability to be localized. Keep in mind that if you want to change the text of a field or add a new field you will probably find the string in the corresponding .resx. In other words, if you are modifying CommandPanel.ascx you will find the resources to modify in \App_Resources\CommandPanel.ascx.resx. An example of this can be found in the section [Adding meta field to an event](file:///C:/Development/My/SEVDNUG/Telerik.Events.101.htm#add_meta). The developers of Sitefinity seem to be consistent with the naming of files, they sort of follow this syntax _<object><function>_.ascx. So the insert form for an event can be found in the _ControlPanelInsert.ascx_ file.

### Admin\ControlTemplates\Events Files

This folder contains the files for the administrative portion of the events modules. While in most cases, except for adding meta fields to the event, you will not need to modify these files. However, if you are like me you like to know how things work.

<table class="table table-striped table-bordered">

<thead>

<tr>

<th>Filename</th>

<th>Purpose</th>

</tr>

</thead>

<tbody>

<tr>

<td>CategoriesField.ascx</td>

<td>Contains a list of event categories.</td>

</tr>

<tr>

<td>CategoriesManagement.ascx</td>

<td>Provides functions to manage the categories; add, rename, etc.</td>

</tr>

<tr>

<td>CategoriesSelector.ascx</td>

</tr>

<tr>

<td>CommandPanel.ascx</td>

<td>The command panel contains all of the functions for managing the events modules. This is the list that appears on the left hand side. Command panels load the Control Panels (middle of the interface).</td>

</tr>

<tr>

<td>CommentsEdit.ascx</td>

<td>This control provides the ability to edit comments for an event.</td>

</tr>

<tr>

<td>CommentsList.ascx</td>

<td>This control lists the comments for an event.</td>

</tr>

<tr>

<td>CommentsView.ascx</td>

<td>This control lists a single comment for an event.</td>

</tr>

<tr>

<td>ContentSelector.ascx</td>

</tr>

<tr>

<td>ContentVersionView.aspx</td>

<td>This control is used when viewing the version history of an event (or any generic content item)</td>

</tr>

<tr>

<td>ControlPanelEdit.ascx</td>

<td>This control is used when editing an existing event.</td>

</tr>

<tr>

<td>ControlPanelInsert.ascx</td>

<td>This control is used when adding a new event.</td>

</tr>

<tr>

<td>ControlPanelList.ascx</td>

<td>This control is used to list all of the events.</td>

</tr>

<tr>

<td>ControlPanelPermissions.ascx</td>

<td>This control is used to display / modify the permissions for events. This can be viewed by clicking on "Permissions" in the command panel.</td>

</tr>

<tr>

<td>EditorTemplate.ascx</td>

<td>This control is used to display the RadEditor for the content of the event. This is used for all generic content.</td>

</tr>

<tr>

<td>EventsScheduler.ascx</td>

<td>This is the control used when you first enter the events admin module or click on the "Events" link in the command panel.</td>

</tr>

<tr>

<td>GeomappingEditor.ascx</td>

<td>This control is used to edit the geomappings for an event. This is used in ControlPanelInsert and ControlPanelEdit</td>

</tr>

<tr>

<td>GeomappingSettings.ascx</td>

<td>This control is used to update the mapping API URLs and keys. This can be view by clicking on "Geomapping" settings in the command panel.</td>

</tr>

<tr>

<td>NewContentDialog.ascx</td>

<td>I do not think this is used. This is carried over from the Generic Content controls, to create shared content.</td>

</tr>

<tr>

<td>RecurringIntervalSelector.ascx</td>

<td>This is probably for a future release of the events module which would allow you to select a recurrence pattern.</td>

</tr>

<tr>

<td>SelectContentDialog.ascx</td>

<td>I do not think this is used. This is carried over from the Generic Content controls, to share content.</td>

</tr>

<tr>

<td>TagEditor.ascx</td>

<td>This is used when editing a tag on an event.</td>

</tr>

<tr>

<td>TagsManagement.ascx</td>

<td>This control is used to manage the tags for the events. This can be viewed by clicking on the "Tags" link in the command panel.</td>

</tr>

</tbody>

</table>

### ControlTemplates\Events Files

This folder contains the files for the public/display portion of the events modules. These controls will be used to display the events on the public facing site.

<table class="table table-striped table-bordered">

<thead>

<tr>

<th>Filename</th>

<th>Purpose</th>

</tr>

</thead>

<tbody>

<tr>

<td>ArchiveTemplate.ascx</td>

</tr>

<tr>

<td>CategoriesList.ascx</td>

<td>Displays a list of event categories and the number of events in that category. Not displayed in the "Community" template.</td>

</tr>

<tr>

<td>CommentsList.ascx</td>

<td>Displays the list of comments for an event.</td>

</tr>

<tr>

<td>CommunityContentViewItemList.ascx</td>

<td>This control is used by the Events page in the "Community" template to display a list of events.</td>

</tr>

<tr>

<td>CommunityContentViewSingleItem.ascx</td>

<td>This control is used to display and event that is clicked in the CommunityContentViewItemList control.</td>

</tr>

<tr>

<td>ContentViewItemList.ascx</td>

<td>This control is used by the Upcoming Events page in the "Community" template to display a list of events.</td>

</tr>

<tr>

<td>ContentViewSingleItem.ascx</td>

<td>This control is used to display and event that is clicked in the ContentViewItemList control.</td>

</tr>

<tr>

<td>eventsCommonLayout.css</td>

<td>The Cascading Style Sheet (CSS) used for the event pages.</td>

</tr>

<tr>

<td>EventsScheduleView.ascx</td>

<td>Displays the events in a calendar view.</td>

</tr>

<tr>

<td>HomeContentViewItemList.ascx</td>

<td>This control is used to display the events in on the home page for the "Community" template.</td>

</tr>

<tr>

<td>TagsList.ascx</td>

<td>Displays the lists of tags for an event.</td>

</tr>

</tbody>

</table>

## <a name="create_event"></a>Creating an event

In order to create an event in Sitefinity using the Telerik.Events assembly, you must follow a few steps.

* Create an instance of the EventsManager class with the correct provider... {% gist jguadagno/c3da1eade78cd6a1873d9eda73eeb5da %}>
* Create a new generic content object... {% gist jguadagno/ca22e52afcd1b0840a7ef6ea3302be1d %}>
* Update the meta data... {% gist jguadagno/ea9237d9751aa81d433939e4eb0939ea %}>
* Optionally, get/create an event category, then update the metadata... {% gist jguadagno/b2cc0306608603ad6ec6c6002b731603 %}>
* Save the content... {% gist jguadagno/03261b61134397ba904a15c7244b79ef %}>

### Utility method for creating an event

{% gist jguadagno/6466a351a582c0565d9a03e9e3dd1c97 %}>

## <a name="delete_event"></a>Deleting an event

In order to delete an event using the Telerik.Events assembly, you must get an instance of the Telerik.Events.EventsManager object. As you will see the code sample below, the eventsManager class has one method called DeleteEvent() which has 2 overloads. The first overload requires two parameters, the Event GUID which is the Event.Id and a boolean which indicates if the manager should delete the associated generic content. {% gist jguadagno/bad261126255eb1b1fd496ceace635a7 %}> The second overload requires two parameters, the Event which is the Event.Id and a boolean which indicates if the manager should delete the associated generic content. {% gist jguadagno/78a53de47f4af09a69e1fd3f87d819eb %}>

<div class="alert alert-danger" role="alert">**Warning:** This will **delete all** of the events in Sitefinity</div>

{% gist jguadagno/112b16fe3d962be5a32586ab154a1c9a %}>

## <a name="add_meta"></a>Adding meta fields to an event

Adding meta fields to the events module is a 5 step process which involves editing the web.config file, editing the administration control templates, and the public display templates. For this example, we will add a _Short Text_ meta field call ClickToAttendId that we want to be displayed as part of an HTML hyperlink similar to this http://www.clicktoattend.com/invitation.aspx?code=_ClickToAttendId_

### **Step 1:** Edit the web.config file.

Open the web.config file and search for <span style="color: #0000ff;"><</span><span style="color: #a31515;">metaFields</span><span style="color: #0000ff;">></span>. This is where Sitefinity loads the list of meta tags for each of the generic content modules. You should find a series of "add" XML elements. These "add" elements take 6 attributes, key, valueType, searchable, sortable, and defaultValue.

<table class="table table-striped table-bordered ">

<thead>

<tr>

<th>Element</th>

<th>Purpose</th>

</tr>

</thead>

<tbody>

<tr>

<td>key</td>

<td>The key is made up of two parts, _modulename_._fieldName_. So <span style="color: #0000ff;">Events.Title</span> means the Title meta field of the events module.</td>

</tr>

<tr>

<td>valueType</td>

<td>The type of data that will be stored. The following are valid types:

* Binary
* Boolean
* DateTime
* FloatingPoint
* Guid
* Integer
* LongText
* ShortText

</td>

</tr>

<tr>

<td>visible</td>

<td>Indicates whether it will be shown in the admin section of the events module.</td>

</tr>

<tr>

<td>searchable</td>

<td>Indicates if you can search on this field.</td>

</tr>

<tr>

<td>sortable</td>

<td>Indicates if this field can be sorted on.</td>

</tr>

<tr>

<td>defaultValue</td>

<td>The default value for this field.</td>

</tr>

</tbody>

</table>

Add a XML element to the <span style="color: #0000ff;"><</span><span style="color: #a31515;">metaFields</span><span style="color: #0000ff;">></span> section that looks like this {% gist jguadagno/190abee94bfc04aa8e746838214832b9 %}> Save an close the web.config.

### **Step 2:** Edit the Admin\ControlTemplates\Events\ControlPanelEdit.ascx.

Where you place the HTML markup depends on where you think the control needs to be. At the minimum it needs to be placed after the <span style="color: #0000ff;"><</span><span style="color: #a31515;">p</span> <span style="color: #ff0000;">class</span><span style="color: #0000ff;">="button_area top"></span> code block and before the block... {% gist jguadagno/13110edfd49ef10bfca060fb1c725fef %}> An example of the markup could look like this. {% gist jguadagno/3ecbf4ddceefbe82461fffcb0344b57a %}> The <span style="color: #0000ff;"><</span><span style="color: #a31515;">h3</span><span style="color: #0000ff;">><</span> section is used for the title of grouping of the data. The <span style="color: #0000ff;"><</span><span style="color: #a31515;">fieldset</span> <span style="color: #ff0000;">class</span><span style="color: #0000ff;">="set"></span> element is used to contain the label and text box for the ClickToAttendId. Notice that there is a consistent naming theme for the HTML controls, lbl_fieldName_ for the label (this is optional), the text box must be the _fieldName_ or Sitefinity will not be able to update it. Save the file. Open up App_Resources\ControlPanelEdit.ascx.resx and add in any of the resources that you referred to in this sample, namely ClickToAttendId.

### **Step 3:** Edit the Admin\ControlTemplates\Events\ControlPanelInsert.ascx.

The ControlPanelInsert.ascx should be edited in the same way that the ControlPanelEdit.ascx was edited.

### **Step 4:** Edit the ControlTemplates\Events\CommunityContentViewSingleItem.ascx

The markup can be placed anywhere inside the div block <span style="color: #0000ff;"><</span><span style="color: #a31515;">div</span> <span style="color: #ff0000;">class</span><span style="color: #0000ff;">="sf_eventContent"></span>. A sample of the markup could be. {% gist jguadagno/308e6021e676fccc5184203d91ba7365 %}> Just as in the administrative templates, in order to display the metadata there should be a control on the form that matches the name of the metadata. Save the file. If necessary, open up the App_Resources\ContentViewSingleItem.ascx.resx file and add whatever resources you require.

### **Step 5:** Edit the ControlTemplates\Events\ContentViewSingleItem.ascx

For some reason, the markup of the ContentViewSingleItem is a bit different. The markup can be placed anywhere inside the div block <span style="color: #0000ff;"><</span><span style="color: #a31515;">div</span> <span style="color: #ff0000;">class</span><span style="color: #0000ff;">="sf_eventContent"></span>. A sample of the markup could be. {% gist jguadagno/0bb36656874322ca20f7880c87de3b00 %}> Save the file. If neccessary, open up the App_Resources\ContentViewSingleItem.ascx.resx file and add whatever resources you require.

## <a name="add_rss"></a>Adding the missing RSS Provider

_Coming soon..._