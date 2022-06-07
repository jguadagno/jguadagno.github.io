---
title: Telerik.Events
date: 2008-04-25T21:57:12+00:00
permalink: /2008/04/25/telerik-events/
dsq_thread_id:
  - "3618030515"
categories:
  - Articles
---
This module is responsible for adding, removing, deleting events from the Sitefinity system. This guide is meant to supplement the documentation that is available for Sitefinity. This document will cover the following:

* [Files for events module](#files-for-events-module)
* [Creating an event](#creating-an-event)
* [Deleting an event](#deleting-an-event)
* [Adding meta fields to an event](#adding-meta-fields-to-an-event)
* [Adding the missing RSS Provider](#adding-the-missing-rss-provider)

As of the time when this was written, development documentation does not exist for the Telerik.Events assembly. The code samples where either "figured out" or derived from other samples. Thanks to Visual Studio®'s Intellisense® feature, Visual Studio®'s Object Browser and [Reflector](http://www.aisto.com/roeder/dotnet/){:target="_blank"}, I figured out most of it. In order to work with events in Sitefinity, you must add a reference to the Telerik.Events assembly. This assembly is already included in the Sitefinity install; it is mentioned in case you want to create a separate assembly for your events customization. The Telerik.Events.EventsManager handles all of the event management. An instance of the EventManager can be created like this. 

``` cs
string providerName = "Events";
EventsManager eventsManager = new Telerik.Events.EventsManager(providerName);
```

After this, the eventsManager object will contain all the methods that you should need.

## Files for events module

Like most (if not all) modules, the templates or user controls are keep in two directories underneath the `/Sitefinity` folder, the `Sitefinity\Admin\ControlTemplates\<ModuleName>`, in this case Events and `Sitefinity\ControlTemplates\<ModuleName>`. Within these directories, you will find a collection of files and one folder `App_Resources`. The `App_Resources` folder provides Sitefinity (or any .NET application) the ability to be localized. Keep in mind that if you want to change the text of a field or add a new field you will probably find the string in the corresponding .resx. In other words, if you are modifying `CommandPanel.ascx` you will find the resources to modify in `\App_Resources\CommandPanel.ascx.resx`. An example of this can be found in the section [Adding meta field to an event](#adding-the-missing-rss-provider). The developers of Sitefinity seem to be consistent with the naming of files, they sort of follow this syntax `_<object><function>_.ascx`. So the insert form for an event can be found in the `_ControlPanelInsert.ascx_` file.

### Admin\ControlTemplates\Events Files

This folder contains the files for the administrative portion of the events modules. While in most cases, except for adding meta fields to the event, you will not need to modify these files. However, if you are like me you like to know how things work.

### ControlTemplates\Events Files

This folder contains the files for the public/display portion of the events modules. These controls will be used to display the events on the public facing site.

|Filename|Purpose|
|--- |--- |
|ArchiveTemplate.ascx||
|CategoriesList.ascx|Displays a list of event categories and the number of events in that category. Not displayed in the "Community" template.|
|CommentsList.ascx|Displays the list of comments for an event.|
|CommunityContentViewItemList.ascx|This control is used by the Events page in the "Community" template to display a list of events.|
|CommunityContentViewSingleItem.ascx|This control is used to display and event that is clicked in the CommunityContentViewItemList control.|
|ContentViewItemList.ascx|This control is used by the Upcoming Events page in the "Community" template to display a list of events.|
|ContentViewSingleItem.ascx|This control is used to display and event that is clicked in the ContentViewItemList control.|
|eventsCommonLayout.css|The Cascading Style Sheet (CSS) used for the event pages.|
|EventsScheduleView.ascx|Displays the events in a calendar view.|
|HomeContentViewItemList.ascx|This control is used to display the events in on the home page for the "Community" template.|
|TagsList.ascx|Displays the lists of tags for an event.|

## Creating an event

In order to create an event in Sitefinity using the Telerik.Events assembly, you must follow a few steps.

* Create an instance of the EventsManager class with the correct provider... 

```cs
EventsManager eventsManager = new Telerik.Events.EventsManager(providerName);
```

* Create a new generic content object...

```cs
IContent newEvent = eventsManager.Content.CreateContent("text/html");
```

* Update the meta data...

```cs
newEvent.SetMetaData("Title", eventTitle);
newEvent.SetMetaData("Content", eventDescription);
```

Optionally, get/create an event category, then update the metadata...

```cs
// If the categoryName is not null or empty, update the category field.
if (string.IsNullOrEmpty(categoryName) == false)
{
  // See if this event category exists
  ICategory category = eventsManager.Content.GetCategory(categoryName);
  if (category == null)
  {
    // Create the category
    category = eventsManager.Content.CreateCategory(categoryName);
    eventsManager.Content.SaveCategory(category);
  }
  // Update the meta data
  newEvent.SetMetaData("Category", categoryName);
}
```

* Save the content...

```cs
eventsManager.Content.SaveContent(newEvent);
```

### Utility method for creating an event

```cs
protected void CreateEvent(
  string eventTitle, 
  string eventDescription,
  string contactName,
  string contactEmail,
  string contactPhone,
  string contactCell,
  string contactWeb,
  string street,
  string city,
  string state,
  string country,
  DateTime eventStartDate, 
  DateTime eventEndDate,
  DateTime eventExpirationDate,
  DateTime publicationDate,
  string geomappingData,
  string categoryName
  
  {
    string providerName = "Events";
    EventsManager eventsManager = new Telerik.Events.EventsManager(providerName);
    IContent newEvent = eventsManager.Content.CreateContent("text/html");

    // Set the Generic Content Meta Data
    newEvent.SetMetaData("Title", eventTitle);
    newEvent.SetMetaData("Content", eventDescription);
    newEvent.SetMetaData("Street", street);
    newEvent.SetMetaData("City", city);
    newEvent.SetMetaData("State", state);
    newEvent.SetMetaData("Country", country);
    newEvent.SetMetaData("Contact_Name", contactName);
    newEvent.SetMetaData("Contact_Email", contactEmail);
    newEvent.SetMetaData("Contact_Phone", contactPhone);
    newEvent.SetMetaData("Contact_Cell", contactCell);
    newEvent.SetMetaData("Contact_Web", contactWeb);
    newEvent.SetMetaData("Event_Start", eventStartDate);
    newEvent.SetMetaData("Event_End", eventEndDate);
    newEvent.SetMetaData("Publication_Date", publicationDate);
    newEvent.SetMetaData("Expiration_Date", eventExpirationDate);
    newEvent.SetMetaData("Geomapping_Data", geomappingData);

    // If the categoryName is not null or empty, update the category field.
    if (string.IsNullOrEmpty(categoryName) == false)
    {
      // See if this event category exists
      ICategory category = eventsManager.Content.GetCategory(categoryName);
      if (category == null)
      {
        // Create the category
        category = eventsManager.Content.CreateCategory(categoryName);
        eventsManager.Content.SaveCategory(category);
      }
      // Update the meta data
      newEvent.SetMetaData("Category", categoryName);
    }
  
    // Save the Generic content
    eventsManager.Content.SaveContent(newEvent);
}
```

## Deleting an event

In order to delete an event using the Telerik.Events assembly, you must get an instance of the `Telerik.Events.EventsManager` object. As you will see the code sample below, the eventsManager class has one method called `DeleteEvent()` which has 2 overloads. The first overload requires two parameters, the Event GUID which is the Event.Id and a boolean which indicates if the manager should delete the associated generic content.

```cs
public void DeleteEvent(Guid ID, bool deleteContentItem)
```

The second overload requires two parameters, the Event which is the Event.Id and a boolean which indicates if the manager should delete the associated generic content.

```cs
public void DeleteEvent(IEvent _event, bool deleteContentItem);
```

**Warning:** This will **delete all** of the events in Sitefinity
{: .notice--danger}

```cs
string providerName = "Events";
EventsManager eventsManager = new Telerik.Events.EventsManager(providerName);

IList events = eventsManager.GetEvents();
foreach (IEvent eventItem in events)
{
  eventsManager.DeleteEvent(eventItem.ID, true);
}
```

## Adding meta fields to an event

Adding meta fields to the events module is a 5 step process which involves editing the web.config file, editing the administration control templates, and the public display templates. 

For this example, we will add a _Short Text_ meta field call `ClickToAttendId` that we want to be displayed as part of an HTML hyperlink similar to this http://www.clicktoattend.com/invitation.aspx?code=_ClickToAttendId_

### **Step 1:** Edit the web.config file.

Open the web.config file and search for

```xml
<metaFields>
```

This is where Sitefinity loads the list of meta tags for each of the generic content modules. You should find a series of "add" XML elements. These "add" elements take 6 attributes, `key`, `valueType`, `searchable`, `sortable`, and `defaultValue`.

|Element|Purpose|
|--- |--- |
|key|The key is made up of two parts, _modulename_._fieldName_. So Events.Title means the Title meta field of the events module.|
|valueType|The type of data that will be stored. The following are valid types: `Binary`, `Boolean`, `DateTime`, `FloatingPoint`, `Guid`, `Integer`, `LongText`, and `ShortText`|
|visible|Indicates whether it will be shown in the admin section of the events module.|
|searchable|Indicates if you can search on this field.|
|sortable|Indicates if this field can be sorted on.|
|defaultValue|The default value for this field.|

Add a XML element to the

```xml
<metaFields>
```

section that looks like this

```xml
<add key="Events.ClickToAttendId"
  valueType="ShortText"
  visible="True"
  searchable="False"
  sortable="True"
  defaultValue=""/>
```

Save an close the web.config.

### **Step 2:** Edit the Admin\ControlTemplates\Events\ControlPanelEdit.ascx.

Where you place the HTML markup depends on where you think the control needs to be. At the minimum it needs to be placed after the

``` html
<p class=”button_area top”>
```

code block and before the block...

```xml
  </ItemTemplate>
</sfGCn:ContentMetaFields>
```

An example of the markup could look like this. 

```html
<h3>
  <asp:Literal ID="ltrClickToAttend" runat="server" Text="<%$Resources:ClickToAttend %>">
  </asp:Literal>
</h3>
<fieldset class="set">
  <div class="setIn">
    <asp:Label ID="lblClickToAttendId" runat="server" 
      Text='<%$Resources:ClickToAttendId %>' AssociatedControlID="ClickToAttendId">
    </asp:Label>
    <asp:TextBox ID="ClickToAttendId" runat="server"></asp:TextBox>
  </div>
</fieldset>
<div class="bottom">
  <div>
    <!-- -->
  </div>
</div>
```

The

```html
<h3>
```

section is used for the title of grouping of the data.

```html
<fieldset class=”set”>
```

element is used to contain the label and text box for the ClickToAttendId. Notice that there is a consistent naming theme for the HTML controls, lbl_fieldName_ for the label (this is optional), the text box must be the _fieldName_ or Sitefinity will not be able to update it. Save the file. Open up `App_Resources\ControlPanelEdit.ascx.resx` and add in any of the resources that you referred to in this sample, namely ClickToAttendId.

### **Step 3:** Edit the Admin\ControlTemplates\Events\ControlPanelInsert.ascx.

The `ControlPanelInsert.ascx` should be edited in the same way that the `ControlPanelEdit.ascx` was edited.

### **Step 4:** Edit the ControlTemplates\Events\CommunityContentViewSingleItem.ascx

The markup can be placed anywhere inside the div block

```html
<div class="sf_eventContent">
```

A sample of the markup could be.

```html
<h4>Event Registration</h4>
  <p>This event requires registration, please register
  <a href='http://www.ImComing.com/id.aspx?code=<asp:Literal ID="ClickToAttendId" runat="server"></asp:Literal>'>
  here</a>.
</p>
```

Just as in the administrative templates, in order to display the metadata there should be a control on the form that matches the name of the metadata. Save the file. If necessary, open up the `App_Resources\ContentViewSingleItem.ascx.resx` file and add whatever resources you require.

### **Step 5:** Edit the ControlTemplates\Events\ContentViewSingleItem.ascx

For some reason, the markup of the ContentViewSingleItem is a bit different. The markup can be placed anywhere inside the div block

```html
<div class="sf_eventContent">
```

A sample of the markup could be.

```html
<asp:PlaceHolder ID="plClickToAttendId" runat="server">
  <h2>Event Registration</h2>
  <p>Please click
    <asp:HyperLink ID="ClickToAttendId" runat="server" 
      NavigateUrl='<% "http://www.clicktoattend.com/invitation.aspx?code=" + this.Text %>'>
    </asp:HyperLink>
    to complete the registration for this event.
  </p>
</asp:PlaceHolder>
```

Save the file. If necessary, open up the `App_Resources\ContentViewSingleItem.ascx.resx` file and add whatever resources you require.

## Adding the missing RSS Provider

_Coming soon..._