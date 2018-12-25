---
id: 341
title: Using an ASP.NET DataRepeater ItemTemplate to create a jQuery Mobile Nested List with List Dividers
date: 2012-01-01T00:45:00+00:00
author: Joseph Guadagno
layout: post
guid: http://www.josephguadagno.net/post.aspx?id=22877d2e-666e-4181-ba47-3818bb0c2151
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
The jQuery Mobile framework has a <a href="http://jquerymobile.com/demos/1.0/docs/lists/docs-lists.html" target="_blank">list view widget</a> that displays unordered lists in several different ways.  In the process of converting the <a href="http://mvpsummitevents.info/m/" target="_blank">Microsoft Global MVP Summit mobile</a> site to use jQuery Mobile I wanted to change the way I displayed the events.  The idea was to have a header for each date that there was an event along with some of the details of the event.  Clicking on the event would take you the to event details page.

To accomplish this I used the <a href="http://jquerymobile.com/demos/1.0/docs/lists/lists-count.html" target="_blank">count bubble</a>, <a href="http://jquerymobile.com/demos/1.0/docs/lists/lists-divider.html" target="_blank">list dividers</a>, <a href="http://jquerymobile.com/demos/1.0/docs/lists/lists-formatting.html" target="_blank">content formatting</a> and the <a href="http://jquerymobile.com/demos/1.0/docs/lists/lists-search.html" target="_blank">search filter bar</a> features of jQuery Mobile.

First let’s look at the HTML, for the sake of brevity I removed the ID fields from the HTML.

[xml]
&lt;ul data-role=&quot;listview&quot; data-inset=&quot;true&quot; data-theme=&quot;d&quot; data-filter=&quot;true&quot;&gt;
	&lt;li data-role=&quot;list-divider&quot;&gt;2/25/2012&lt;span id=&quot;EventCount_0&quot; class=&quot;ui-li-count&quot;&gt;1&lt;/span&gt;&lt;/li&gt;
	&lt;li&gt;
		&lt;a href=&quot;/m/e.aspx?Id=45&quot;&gt;
			&lt;h3&gt;&lt;span&gt;Northwest Harvest at MVP Summit 2012&lt;/span&gt;&lt;/h3&gt;
			&lt;p&gt;&lt;strong&gt;&lt;span&gt;Northwest Harvest Warehouse&lt;/span&gt;&lt;/strong&gt;&lt;/p&gt;
			&lt;p class=&quot;ui-li-aside&quot;&gt;&lt;span&gt;from 11:30 AM to 5:00 PM&lt;/span&gt;&lt;/p&gt;
		&lt;/a&gt;
	&lt;/li&gt;
	&lt;li data-role=&quot;list-divider&quot;&gt;2/27/2012&lt;span class=&quot;ui-li-count&quot;&gt;2&lt;/span&gt;&lt;/li&gt;
	&lt;li&gt;
		&lt;a href=&quot;/m/e.aspx?Id=48&quot;&gt;
			&lt;h3&gt;&lt;span&gt;Consumer Camp: Bellevue&lt;/span&gt;&lt;/h3&gt;
			&lt;p&gt;&lt;strong&gt;&lt;span id=&quot;VenueName_0&quot;&gt;Microsoft Store: Bellevue&lt;/span&gt;&lt;/strong&gt;&lt;/p&gt;
			&lt;p class=&quot;ui-li-aside&quot;&gt;&lt;span&gt;from 5:00 PM to 8:00 PM&lt;/span&gt;&lt;/p&gt;
		&lt;/a&gt;
	&lt;/li&gt;
	&lt;li&gt;
		&lt;a href=&quot;/m/e.aspx?Id=46&quot;&gt;
			&lt;h3&gt;&lt;span&gt;First Time MVPs Event&lt;/span&gt;&lt;/h3&gt;
			&lt;p&gt;&lt;strong&gt;&lt;span&gt;Rockbottom - Top of the Rock&lt;/span&gt;&lt;/strong&gt;&lt;/p&gt;
			&lt;p class=&quot;ui-li-aside&quot;&gt;&lt;spa&gt;from 6:00 PM to 9:00 PM&lt;/span&gt;&lt;/p&gt;
		&lt;/a&gt;
	&lt;/li&gt;
&lt;/ul&gt;
[/xml]

From this HTML markup the jQuery Mobile framework will generate a view that looks like this:

<a href="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/image_3.png"><img style="background-image: none; padding-left: 0px; padding-right: 0px; display: inline; padding-top: 0px; border-width: 0px;" title="image" src="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/image_thumb_2.png" alt="image" width="411" height="245" border="0" /></a>

<h2>The jQuery Mobile ListView</h2>

<h3>Creating the ListView</h3>

The start of the unordered list, Line 1, has 4 attributes:
[xml]
&lt;ul data-role=&quot;listview&quot; data-inset=&quot;true&quot; data-theme=&quot;b&quot; data-filter=&quot;true&quot;&gt;
[/xml]
The <strong>data-role</strong> of <em>listview</em> tells the jQuery Mobile framework to use the jQuery Mobile <a href="http://jquerymobile.com/demos/1.0/docs/lists/docs-lists.html" target="_blank">Listview</a> widget. Setting the <strong>data-inset </strong>attribute to <em>true </em>tells the jQuery Mobile framework to indent the list view and add the rounded edges. The <strong>data-theme</strong> attribute tells jQuery Mobile to use the <em>d</em>theme. Setting the <strong>data-filter</strong> equal to <em>true</em> tells the jQuery Mobile framework to add the filter items text box up top. No additional work is needed to add the filter, it will search all of the ListItems that are part of this unordered list who’s <strong>data-role</strong> attribute is not set to <em>list-divider</em> for the text entered.

<h3></h3>

<h3>The List Divider</h3>

Adding the <strong>data-role</strong> of <em>list-divider</em> (Line 2 of the initial example) will make that list item appear as a divider.  You can use this attribute to group items, in my case, I grouped by date.

To establish the count bubble you will need to wrap the count of item around a span tag and give it the class of <em>ui-li-count</em>, as shown in Line 2.

Here’s an annotated image with markup.

<a href="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/image_4.png"><img style="background-image: none; padding-left: 0px; padding-right: 0px; display: inline; padding-top: 0px; border-width: 0px;" title="image" src="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/image_thumb_3.png" alt="image" width="409" height="136" border="0" /></a>

The item in red is the individual list item which will be discussed in the next section.

<h3>The Items</h3>

Each sub item under the list divider needs to be it’s own Anchor element ( A )  wrapped in a ListItem (LI) tag as shown in lines 3-9 and 11-24 above.

[xml]
&lt;li&gt;
  	&lt;a href=&quot;/m/e.aspx?Id=45&quot;&gt;
		&lt;h3&gt;&lt;span&gt;Northwest Harvest at MVP Summit 2012&lt;/span&gt;&lt;/h3&gt;
		&lt;p&gt;&lt;strong&gt;&lt;span&gt;Northwest Harvest Warehouse&lt;/span&gt;&lt;/strong&gt;&lt;/p&gt;
		&lt;p class=&quot;ui-li-aside&quot;&gt;&lt;span&gt;from 11:30 AM to 5:00 PM&lt;/span&gt;&lt;/p&gt;
	&lt;/a&gt;
&lt;/li&gt;
[/xml]

Each LI formatted above will generate a “row” as highlighted in the red boxed image above within your browser.  Clicking on one of those links will take you to the page specified in Anchor tag. In order to get the times to “float” to the left, you will need to use the <em>ui-li-aside</em> class.  Note, the &gt; image will get added automatically by the framework.

<h2>Creating the jQuery ListView with an ASP.NET DataRepeater Control</h2>

In order to accomplish this, I went with a DataRepeater within a DataRepeater .  The first, or outside, DataRepeater (<em>DateRepeater</em>)will get a list of distinct dates from the data store in order to create the List Dividers. The second, or inner, DataRepeater (<em>EventRepeater</em>) will list all of the events for the day specified by the <em>DateRepeater</em>.

Let’s take a look at the code:
[xml]
&lt;asp:Repeater runat=&quot;server&quot; ID=&quot;DateRepeater&quot; DataSourceID=&quot;EventDatesDataSource&quot; OnItemDataBound=&quot;DateRepeaterOnItemDataBound&quot;&gt;
	&lt;HeaderTemplate&gt;
		&lt;ul data-role=&quot;listview&quot; data-inset=&quot;true&quot; data-theme=&quot;d&quot; data-filter=&quot;true&quot;&gt;
	&lt;/HeaderTemplate&gt;
	&lt;ItemTemplate&gt;
		&lt;li data-role=&quot;list-divider&quot;&gt;&lt;%# Container.DataItem %&gt;
			&lt;asp:Label runat=&quot;server&quot; ID=&quot;EventCount&quot; class=&quot;ui-li-count&quot;&gt;&lt;/asp:Label&gt;
		&lt;/li&gt;
		&lt;asp:Repeater runat=&quot;server&quot; ID=&quot;EventRepeater&quot; OnItemDataBound=&quot;EventRepeaterOnItemDataBound&quot;&gt;
			&lt;ItemTemplate&gt;
				&lt;li&gt;
					&lt;asp:HyperLink runat=&quot;server&quot; ID=&quot;EventUrl&quot;&gt;
						&lt;h3&gt;&lt;asp:Label runat=&quot;server&quot; ID=&quot;EventName&quot; /&gt;&lt;/h3&gt;
						&lt;p&gt;&lt;strong&gt;&lt;asp:Label runat=&quot;server&quot; ID=&quot;VenueName&quot;&gt;&lt;/asp:Label&gt;&lt;/strong&gt;&lt;/p&gt;
						&lt;p class=&quot;ui-li-aside&quot;&gt;&lt;asp:Label runat=&quot;server&quot; ID=&quot;EventDate&quot;&gt;&lt;/asp:Label&gt;&lt;/p&gt;
					&lt;/asp:HyperLink&gt;
				&lt;/li&gt;
			&lt;/ItemTemplate&gt;
		&lt;/asp:Repeater&gt;
	&lt;/ItemTemplate&gt;
	&lt;FooterTemplate&gt;
		&lt;/ul&gt;
	&lt;/FooterTemplate&gt;
&lt;/asp:Repeater&gt;
[/xml]

In lines 2-4, using the <strong>HeaderTemplate</strong> property of the <em>DateRepeater</em> DataRepeater control I create the initial ListView. It is then closed in the lines 21-24 using the <strong>FooterTemplate</strong> of the <em>DateRepeater</em> DataRepeater control. Next in the <strong>ItemTemplate</strong> property (Line 6-8) of the <em>DateRepeater</em> DataRepeater control, I create a list divider by adding a ListItem (LI) with the <strong>data-role</strong> of <em>list-divider</em> with a label for the date.  Line 7 has a label control with a class of <em>ul-li-count</em> that holds the count of events that date.

Now within the <strong>ItemTemplate</strong> property of the <em>DateRepeater</em> DataRepeater control I also have another DataRepeater, <em>EventRepeater.</em> This DataRepeater will iterate through all the events for a day and create the individual ListItems (LI) for each event on that day (Lines 11-17). Notice how the ListItem is wrapped in an <strong>ASP:HyperLink</strong> control.  This will provide the hyperlink to the event details page.

That sums up creating jQuery Mobile listview using an ASP.NET DataRepeater control.