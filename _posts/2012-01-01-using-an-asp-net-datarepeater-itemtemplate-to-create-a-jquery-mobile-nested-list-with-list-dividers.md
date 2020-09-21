---
title: Using an ASP.NET DataRepeater ItemTemplate to create a jQuery Mobile Nested List with List Dividers
date: 2012-01-01T00:45:00+00:00
permalink: /2012/01/01/using-an-asp-net-datarepeater-itemtemplate-to-create-a-jquery-mobile-nested-list-with-list-dividers/
dsq_thread_id:
  - "3610057336"
categories:
  - Articles
  - Web
tags:
  - DataRepeater
  - jQuery
  - jQuery Mobile
---
The jQuery Mobile framework has a [list view widget](http://jquerymobile.com/demos/1.0/docs/lists/docs-lists.html) that displays unordered lists in several different ways. In the process of converting the [Microsoft Global MVP Summit mobile](http://mvpsummitevents.info/m/) site to use jQuery Mobile, I wanted to change the way I displayed the events. The idea was to have a header for each date that there was an event along with some of the details of the event. Clicking on the event would take you the to event details page. To accomplish this I used the [count bubble](http://jquerymobile.com/demos/1.0/docs/lists/lists-count.html), [list dividers](http://jquerymobile.com/demos/1.0/docs/lists/lists-divider.html), [content formatting](http://jquerymobile.com/demos/1.0/docs/lists/lists-formatting.html) and the [search filter bar](http://jquerymobile.com/demos/1.0/docs/lists/lists-search.html) features of jQuery Mobile. First let’s look at the HTML, for the sake of brevity I removed the ID fields from the HTML.

```html
<ul data-role="listview" data-inset="true" data-theme="d" data-filter="true">
  <li data-role="list-divider">2/25/2012<span id="EventCount_0" class="ui-li-count">1</span></li>
  <li>
    <a href="/m/e.aspx?Id=45">
      <h3><span>Northwest Harvest at MVP Summit 2012</span></h3>
      <p><strong><span>Northwest Harvest Warehouse</span></strong></p>
      <p class="ui-li-aside"><span>from 11:30 AM to 5:00 PM</span></p>
    </a>
  </li>
  <li data-role="list-divider">2/27/2012<span class="ui-li-count">2</span></li>
  <li>
    <a href="/m/e.aspx?Id=48">
      <h3><span>Consumer Camp: Bellevue</span></h3>
      <p><strong><span id="VenueName_0">Microsoft Store: Bellevue</span></strong></p>
      <p class="ui-li-aside"><span>from 5:00 PM to 8:00 PM</span></p>
    </a>
  </li>
  <li>
    <a href="/m/e.aspx?Id=46">
      <h3><span>First Time MVPs Event</span></h3>
      <p><strong><span>Rockbottom – Top of the Rock</span></strong></p>
      <p class="ui-li-aside"><span>from 6:00 PM to 9:00 PM</span></p>
    </a>
  </li>
</ul>
```

From this HTML markup the jQuery Mobile framework will generate a view that looks like this: [![image](/assets/images/posts/image_thumb_2.png "image")](/assets/images/posts/image_3.png)

## The jQuery Mobile ListView

### Creating the ListView

The start of the unordered list, Line 1, has 4 attributes:

```html
<ul data-role="listview" data-inset="true" data-theme="b" data-filter="true">
```

The `data-role` of `listview` tells the jQuery Mobile framework to use the jQuery Mobile [Listview](http://jquerymobile.com/demos/1.0/docs/lists/docs-lists.html) widget. Setting the `data-inset` attribute to `true` tells the jQuery Mobile framework to indent the list view and add the rounded edges. The `data-theme` attribute tells jQuery Mobile to use the `d_theme`. Setting the `data-filter` equal to `true` tells the jQuery Mobile framework to add the filter items text box up top. No additional work is needed to add the filter, it will search all of the ListItems that are part of this unordered list who’s `data-role` attribute is not set to `list-divider` for the text entered.

### The List Divider

Adding the `data-role` of `list-divider` (Line 2 of the initial example) will make that list item appear as a divider. You can use this attribute to group items, in my case, I grouped by date. To establish the count bubble you will need to wrap the count of item around a span tag and give it the class of `ui-li-count`, as shown in Line 2. Here’s an annotated image with markup.

[![image](/assets/images/posts/image_thumb_3.png "image")](/assets/images/posts/image_4.png)

The item in red is the individual list item which will be discussed in the next section.

### The Items

Each sub-item under the list divider needs to be it’s own Anchor element ( `A` ) wrapped in a ListItem (`LI`) tag as shown in lines 3-9 and 11-24 above.

```html
<li>
  <a href="/m/e.aspx?Id=45">
    <h3><span>Northwest Harvest at MVP Summit 2012</span></h3>
    <p><strong><span>Northwest Harvest Warehouse</span></strong></p>
    <p class="ui-li-aside"><span>from 11:30 AM to 5:00 PM</span></p>
  </a>
</li>
```

Each `LI` formatted above will generate a “row” as highlighted in the red boxed image above within your browser. Clicking on one of those links will take you to the page specified in an Anchor tag. In order to get the times to “float” to the left, you will need to use the `ui-li-aside` class. Note, the > image will get added automatically by the framework.

## Creating the jQuery ListView with an ASP.NET DataRepeater Control

In order to accomplish this, I went with a DataRepeater within a DataRepeater. The first, or outside, DataRepeater (`DateRepeater`)will get a list of distinct dates from the data store in order to create the List Dividers. The second, or inner, DataRepeater (`EventRepeater`) will list all of the events for the day specified by the `DateRepeater`. Let’s take a look at the code:

```xml
<asp:Repeater runat="server" ID="DateRepeater" DataSourceID="EventDatesDataSource" OnItemDataBound="DateRepeaterOnItemDataBound">
  <HeaderTemplate>
    <ul data-role="listview" data-inset="true" data-theme="d" data-filter="true">
  </HeaderTemplate>
  <ItemTemplate>
    <li data-role="list-divider"><%# Container.DataItem %>
      <asp:Label runat="server" ID="EventCount" class="ui-li-count"></asp:Label>
    </li>
    <asp:Repeater runat="server" ID="EventRepeater" OnItemDataBound="EventRepeaterOnItemDataBound">
      <ItemTemplate>
        <li>
          <asp:HyperLink runat="server" ID="EventUrl">
            <h3><asp:Label runat="server" ID="EventName" /></h3>
            <p><strong><asp:Label runat="server" ID="VenueName"></asp:Label></strong></p>
            <p class="ui-li-aside"><asp:Label runat="server" ID="EventDate"></asp:Label></p>
          </asp:HyperLink>
        </li>
      </ItemTemplate>
    </asp:Repeater>
  </ItemTemplate>
  <FooterTemplate>
    </ul>
  </FooterTemplate>
</asp:Repeater>
```

In lines 2-4, using the `HeaderTemplate` property of the `DateRepeater` DataRepeater control I create the initial ListView. It is then closed in the lines 21-24 using the `FooterTemplate` of the `DateRepeater` DataRepeater control. Next in the `ItemTemplate` property (Line 6-8) of the `DateRepeater` DataRepeater control, I create a list divider by adding a ListItem (LI) with the `data-role` of `list-divider` with a label for the date. Line 7 has a label control with a class of `ul-li-count` that holds the count of events that date. Now within the `ItemTemplate` property of the `DateRepeater` DataRepeater control I also have another DataRepeater, `EventRepeater.` This DataRepeater will iterate through all the events for a day and create the individual ListItems (LI) for each event on that day (Lines 11-17). Notice how the ListItem is wrapped in an `ASP:HyperLink` control. This will provide the hyperlink to the event details page. That sums up creating jQuery Mobile listview using an ASP.NET DataRepeater control.