---
title: Creating a new Sitefinity generic content module
date: 2008-07-28T03:39:00+00:00
author: Joseph Guadagno
permalink: /2008/07/28/creating-a-new-sitefinity-generic-content-module/
dsq_thread_id:
  - "3621086018"
categories:
  - Articles
---
So, I heard that the [Sitefinity](http://www.sitefinity.com/) application had this generic content module that was pretty easy to use to create your own module with. Why do you need to create a new generic content based module you ask?  There a few answers to that question.  I created a new generic content based module because I wanted to track all of the discounts that were offered to the [Southeast Valley .NET user group](http://www.sevdnug.org/) and since free time is a something I do not have lately, it was an easy choice.  You might also want to leverage the existing Sitefinity generic content module because you do not have any development resources available to.  As the name implies it is generic, so generic in fact, it is used by the blog feature, news feature and events feature. After a week’s worth of digging into the code and documentation, I was successful. So that you do not have to go through the pain, I will lay out the instructions for you.  This guide will require virtually no coding, just a little HTML markup, and some web.config changes. There are few steps involved in creating a new copy of the generic module.  

The first step is to BACKUP your web.config file and Sitefinity project, just to be safe.
{: .notice--danger}

Here is a list of other steps:

- [Getting Started](#_Getting_Started)
- [Modify the web.config file](#_Modify_the_web.config)
- [Create the new admin section](#_Create_your_new)
- [Create the new control templates](#_Create_you_new)
- [Add the data](#_Add_the_data)
- [Create the Sitefinity page to display the content](#_Create_the_Sitefinity)
- [Summary](#_Summary)

## Document Conventions

Throughout this document, you will see the text `<ModuleName>`. Whenever you see this text you should replace the `<ModuleName>` with the new name of your module. For example, I created a discount module and whenever I saw `<ModuleName>` I replaced it with _Discount_.

## Getting Started

There are two bugs in Sitefinity 3.2 Service Pack 2 hotfix 1616 that cause potential problems with using multiple generic control providers and the ContentView control.  Here are the posted fixes for them.

### Multiple Providers Fix

This bug does not allow for you to select multiple generic content providers. To fix this issue, check out the Sitefinity knowledge base article titled [Adding a custom provider for Generic Content](http://www.sitefinity.com/support/knowledge-base/kb-article/b1154K-bach-b1154T-cmm.aspx)

### The Settings for ContentView controls are reset fix

To fix this issue, check out the Sitefinity knowledge base article titled [Settings applied to the Content View based controls are reset](http://www.sitefinity.com/support/knowledge-base/kb-article/b1154K-bace-b1154T-cmm.aspx)

### Resource Files

Sitefinity is built on top of the .NET framework, and this coding technology can localize text properties (and other attributes, such as tooltips) Within an ASP.NET page, you will see the string

```cs
<% $Resources:SearchItemsBy %>
```

This code tells the ASP.NET engine to get the resource file text in the key SearchItemsBy. This language is based on the page’s locale. If this text was on the `ControlPanelInsert.ascx` control, ASP.NET would look within the `ControlPanelInsert.ascx.resx` file, unless you had localized versions then it would look in `ControlPanelInsert.ascx.<_locale_>.resx`. For more information, please read [Walkthrough: Using Resources for Localization with ASP.NET](https://msdn.microsoft.com/en-us/library/fw69ke6f.aspx) from MSDN. Keep this in mind while editing your Sitefinity controls later on.

### ContentView Control Overview

The `ContentView` control in Sitefinity does most of the work for displaying generic content on a control or page. The `ContentView` control displays data on the web control by "looking" for control names that match the Meta field names within the provider. If you have a Meta field called **Product** then the ContentView control will look for a control on the page with the name **Product** and populate the control with the value of the Meta field. When the ContentView control sees a control with one of these names it will populate them with special functions.

|Control name|Purpose|
|--- |--- |
|fullContent1|This will be used to create a hyperlink to the details or "SingleItem" version of this content item.|
|fullContent2|This is the same as fullContent1.|
|content|This will be used to display your generic content.|
|CommentsLink|This will be used to create a hyperlink to view the comments of the content|
|CommentsCount|This will be used to display the total number of comments on this content.|
|Category|This will be used to display the category of the content. If this is a hyperlink control, the contentview control, will place a hyperlink on the page that will allow you to view all of the content classified in that category.|
|Tags|For this you will need an ASP.NET Repeater control and the content view control will place the tags used for that content|
|Bookmarks|For this you will need an ASP.NET Repeater control and the content view control will place the tags used for that content|

The `ContentView` control has two properties under the appearance section that tell it what control to display on the web page when you are in List mode or Single Item mode. These two properties are `ItemListTemplatePath` and `SingleItemTemplatePath`, respectively.

## Modify the web.config file

**Warning** Before you begin, **BACKUP** your `web.config`. The smallest error or unclosed angle bracket will cause your Sitefinity application to stop working.
{: .notice--danger}

### Add the new provider

Locate the section in your `web.config` file that is titled **cmsProvider**. It looks something like this

```xml
<cmsEngine defaultProvider="Generic_Content">
```

Copy the element (section) whose name is `Generic_Content`. It should look something like this

```xml
<add name="Generic_Content"
  urlRewriteFormat="[Publication_Date]/[Title].aspx"
  urlDateTimeFormat="yy-MM-dd"
  urlWhitespaceChar="_"
  visible="True"
  defaultMetaField="Name"
  securityProviderName=""
  allowLocalization="False"
  allowVersioning="True"
  allowWorkflow="False"
  allowComments="false"
  commentsModeration="true"
  versioningProviderName=""
  connectionStringName="GenericContentConnection"
  type="Telerik.Cms.Engine.Data.Providers.DefaultProvider, Telerik.Cms.Engine.Data"/>
```

Paste this element onto the next line of the web config. Change the following attributes.

|Attribute|Value|
|--- |--- |
|name|`<ModuleName>`|
|urlRewriteFormat|The way you would like your URLs to look.|
|defaultMetaField|The name of the default meta field. Note: This must match a value in the meta field that you create later; otherwise you will get a difficult to debug "_The given key is not present in the dictionary_" exception.|

The `urlRewriteFormat` field can comprise of any of your Meta field names.  It my case, I created the following.

```xml
urlRewriteFormat="/[Company_Name]/[Product].aspx"
```

All of the other fields you are free to do with as you choose.  Here is the sample Discount provider.

```xml
<add name="Discounts"
  urlRewriteFormat="/[Company_Name]/[Product].aspx"
  urlDateTimeFormat="yy-MM-dd"
  urlWhitespaceChar="_"
  visible="True"
  applicationName="/Discounts"
  defaultMetaField="Product"
  securityProviderName=""
  allowLocalization="False"
  allowVersioning="True"
  allowWorkflow="False"
  allowComments="false"
  commentsModeration="true"
  versioningProviderName=""
  connectionStringName="GenericContentConnection"
  type="Telerik.Cms.Engine.Data.Providers.DefaultProvider, Telerik.Cms.Engine.Data"/>
```

### Add the new Meta fields

Further down in the web.config file, you should find an element, add Meta keys for each field for your new module. For the discount module, here is what I added:

```xml
<add key="Discounts.Product" valueType="ShortText" visible="True" searchable="True" sortable="True" defaultValue=""/>
<add key="Discounts.Company_Name" valueType="ShortText" visible="True" searchable="True" sortable="True" defaultValue=""/>
<add key="Discounts.Company_Url" valueType="ShortText" visible="True" searchable="False" sortable="False" defaultValue=""/>
<add key="Discounts.Product_Logo_Url" valueType="ShortText" visible="True" searchable="False" sortable="True" defaultValue=""/>
<add key="Discounts.Discount" valueType="ShortText" visible="True" searchable="False" sortable="False" defaultValue=""/>
<add key="Discounts.Discount_Code" valueType="ShortText" visible="True" searchable="False" sortable="True" defaultValue=""/>
<add key="Discounts.Category" valueType="ShortText" visible="True" searchable="True" sortable="True" defaultValue=""/>
<add key="Discounts.Author" valueType="ShortText" visible="True" searchable="True" sortable="True" defaultValue="Joseph Guadagno"/>
```

Please note that the name of the module and the word before the period must match the module name. For the Discounts Module provider I discussed, the name should be Discounts as shown below this sentence: The important part is for each property/field you want you to need to add a line. You will notice the format is "PropertyName". For more information on the attributes, check out the [Sitefinity developer’s documentation](http://www.sitefinity.com/help/developer-manual/telerik.cms.engine-telerik.cms.engine.metainfo_members.html). Save your `web.config` and this completes all necessary changes to the file.

## Create your new admin section

### Create the folder structure

So you can interface with the Discounts Module, you will now need to create the template files by following these steps:

1. Open the Windows Explorer (or within Visual Studio).
2. Navigate to your website’s root directory.
3. Go to `~/Sitefinity/Admin/ControlTemplates` folder.
4. Select the `Generic_Content` folder and paste it into the `~/Sitefinity/Admin/ControlTemplates` directory.
5. Rename that folder to `<ModuleName>`. In my example, I renamed it to Discounts.

#### File List

|Old name|New Name|
|--- |--- |
|App_LocalResources|All of the application resource files are found here. These files contain most notably the text properties for all of the controls on the template.  There should be one .resx for each .ascx file.  This is how .NET allows you to create localized versions of your applications.|
|CategoriesField.ascx|Provides a drop down list of categories to choose from.|
|CategoriesManagement.ascx|Provides the ability to add, remove and modify categories that are available to this generic content.|
|CategoriesSelector.ascx|A control to select the categories to filter your records by.|
|CommandPanel.ascx|This control is what is displayed on the left hand side of the Sitefinity administration console.  You should not need to modify this.|
|CommentsEdit.ascx|A control that provides the ability to edit the comments of your generic content.|
|CommentsList.ascx|A control that lists the comments for your generic content.|
|CommentsView.ascx|A control that displays the individual comment of your generic content from the comments list control.|
|ContentSelector.ascx|This control provides a means to let you select generic content.|
|ContentVersionView.aspx|This is the control that will display the version history when you click on the version tab.|
|ControlPanelEdit.ascx|This is the admin control that allows you to edit your generic content.|
|ControlPanelInsert.ascx|This is the admin control that allows you to insert your generic content.|
|ControlPanelList.ascx|This is the admin control that displays the generic content available.|
|ControlPanelPermissions.ascx|This control provides the security controls for your generic content.|
|Design|Folder for the designer templates. I do not think these are used yet.|
|EditorTemplate.ascx|Not sure of purpose.  Not sure of use.|
|NewContentDialog.ascx|When you are creating page and you drag the Generic Content Module onto it, this is the dialog when you click "Share this Content"|
|SelectContentDialog.ascx|Same idea as above, but this is when you click on "Select Shared Content"|
|TagEditor.ascx|This control allows you to edit an individual tag|
|TagsManagement.ascx|This control allows you to edit the tags available for your content.|

### Modify the admin files

There are three files that you are going to want to modify to accommodate your new Meta fields. They are `ControlPanelList.ascx`, `ControlPanelInsert.ascx`, and `ControlPanelEdit.ascx`.  I listed them in the order that they should be modified for testing.

#### ControlPanelList.ascx

As mentioned previously, the ControlPanelList.ascx control is used to display the generic content in the admin panel. Of the three controls, the List control is the least likely to need modification. This control has two divs called `ToolsAll` and `workArea`, which break up the workspace for listing the generic content. 

ToolsAll contains the `createNewButton`, which allows you to create a new generic content item and the `searchInputs` section which allows you to search for generic content. The choices for the search criteria depend on whether you make the Meta data "searchable" in the `web.config` file. Here is an example:

```xml
<add key="Discounts.Product" searchable="True">
```

The div named "workArea" is broken up into three sections; `gridTitle` which provides the title for the grid, the `GridView1` which will display the grid of generic content items, and an ASP.NET PlaceHolder control named `emptyWindow`, which displays text when there are no content items in this provider. If you would like to add a new provider with additional Meta fields, then you would need to add additional columns to `GridView1` because this grid displays the meta fields.  These additional columns would help you narrow down the generic content that you want to modify.

```html
<asp:GridView ID="GridView1">
```

To add a column to the grid control looks the `Columns` element, use the sample below this sentence: 

```html
<asp:BoundField DataField="Company_Name"
  SortExpression="Company_Name"
  HeaderText="<%$Resources:Company_Name %>"
  HeaderStyle-CssClass="GridHeader_SiteFinity" />
<asp:BoundField DataField="Author"
  SortExpression="Author"
  HeaderText="<%$Resources:Author %>"
  HeaderStyle-CssClass="GridHeader_SiteFinity" />
```

In this sample, I removed the `Description` field because I am not using it. I added a `Company_Name` column because this was a new meta field I added to the `web.config` file. Be sure to remove any unused Meta data fields or else you will get a runtime exception.

#### ControlPanelList.ascx.resx

Here are the contents of the resource file with some modifications.

|Name|Value|
|--- |--- |
|AllContentItems|All `<ModuleName>`|
|Author|Author|
|CheckGenericContentFAQ|Check `<ModuleName>` FAQs|
|Company_Name|Company name|
|CreateNewItem|Create a `<ModuleName>`|
|CreateYourFirstContent|Create your first `<ModuleName>`|
|CreateYourFirstContentTooltip|`<ModuleName>`|
|Delete|Delete|
|Description|Description|
|Edit|Edit|
|For|for|
|Name|Name|
|NoContent|No `<ModuleName>` have been created yet.|
|Or|or|
||Permissions FAQ|
|Product|Product name|
|Search|Search|
|SearchItemsBy|Search `<ModuleName>` by|
|Status|Status|

#### ControlPanelInsert.ascx

As mentioned previously, the `ControlPanelInsert` control is used to insert new generic content items for this provider.

Just like the `ControlPanelList` control, this control is broken up into two divs, `ToolsAll` and `divWorkArea`. The `ToolsAll` contains the "back to …" link and the `divWorkArea` contains everything else.

There are three parts to the "divWorkArea," the `sfMsg:MessageControl` control which displays messages based on the success or failure of saving the content, the mainForm which provides the editing surface, and the info div, which displays the FAQ text.

The mainForm again provides the area for which you insert your generic content. Some things that you need to know.  All of the Meta data fields need to be within the control `sfGCn:ContentMetaFields` and the `<ItemTemplate>` sub element otherwise the Sitefinity engine will not save the values. The fieldset classes are used to group the content together. Here is a sample fieldset with the Meta data fields for the discount content provider.

```html
<h3><asp:Literal runat="server" Text="<%$Resources:Discount %>"></asp:Literal></h3>
<fieldset class="set">
  <div class="setIn">
    <ol>
      <li class="author">
        <asp:Label ID="Label5″ AssociatedControlID="Company_Name" runat="server">
        <asp:Literal ID="Literal7″ runat="server" Text="<%$Resources:Company_Name %>"></asp:Literal>
        <em id="Em2″ runat="server"></em></asp:Label>
        <asp:TextBox ID="Company_Name" Text="<%$Resources:Company_Name_Input %>" runat="server"></asp:TextBox>
      </li>
      <li class="author">
        <asp:Label ID="Label6″ AssociatedControlID="Company_Url" runat="server">
        <asp:Literal ID="Literal8″ runat="server" Text="<%$Resources:Company_Url %>"></asp:Literal>
        <em id="Em3″ runat="server"></em></asp:Label>
        <asp:TextBox ID="Company_Url" Text="<%$Resources:Company_Url_Input %>" runat="server"></asp:TextBox>
      </li>
      <li class="author">
        <asp:Label ID="Label10″ AssociatedControlID="Product_Logo_Url" runat="server">
        <asp:Literal ID="Literal12″ runat="server" Text="<%$Resources:Product_Logo_Url %>"></asp:Literal>
        <em id="Em7″ runat="server"></em></asp:Label>
        <asp:TextBox ID="Product_Logo_Url" Text="<%$Resources:Product_Logo_Url_Input %>" runat="server"/>
      </li>
      <li class="author">
        <asp:Label ID="Label8″ AssociatedControlID="Discount" runat="server">
        <asp:Literal ID="Literal10″ runat="server" Text="<%$Resources:Discount %>"></asp:Literal>
        <em id="Em5″ runat="server"></em></asp:Label>
        <asp:TextBox ID="Discount" Text="<%$Resources:Discount_Input %>" runat="server"></asp:TextBox>
      </li>
      <li class="author">
        <asp:Label ID="Label9″ AssociatedControlID="Discount_Code" runat="server">
        <asp:Literal ID="Literal11″ runat="server" Text="<%$Resources:Discount_Code %>"></asp:Literal>
        <em id="Em6″ runat="server"></em></asp:Label>
        <asp:TextBox ID="Discount_Code" Text="<%$Resources:Discount_Code_Input %>" runat="server />
      </li>
    </ol>
  </div>
</fieldset>
```

Each of the individual field is wrapped in a `li` HTML tag. There is a `label`, and a `TextBox` for each Meta data field. 

In order to display the categories for your specific generic content you will need to modify the

```html
<sfCtg:CategoriesField ProviderName="<ModuleName>" ID="Category" runat="server" />
```

tag.  You will need to add the ProviderName attribute tag and add the name of your generic provider.

#### ControlPanelInsert.ascx.resx

Here are the contents of the ControlPanelInsert.ascx.resx file for the custom module. As you will notice, I created a resource entry for each of the Metadata fields created in the web.config file.

|Name|Value|
|--- |--- |
|AdditionalInfo|Additional Info|
|AdditionalInfoNote|This information is not public. It is for your reference only.|
|Author|Author|
|AuthorInput|Author...|
|BackToAllItems|Cancel and go back|
|Cancel|Cancel|
|Category|Category|
|Company_Name|Company name|
|Company_Name_Input|enter the company name ...|
|Company_Url|Company URL|
|Company_Url_Input|enter the company url ...|
|Content|Text|
|ContentEmpty|The text cannot be empty!|
|CreateThisItem|Create this discount|
|Description|Description|
|DescriptionInput|Description...|
|Discount|Discount|
|Discount_Code|Discount code|
|Discount_Code_Input|enter the discount code ...|
|Discount_Input|enter the discount ...|
|GenericContentFAQ|Discount FAQ|
|MandatoryFields|Mandatory fields|
|Or|or|
|Product|Product|
|Product_Empty|Product cannot be empty!|
|Product_Input|enter the product ...|
|Product_Label|Product|
|Product_Logo_Url|Product Url|
|Product_Logo_Url_Input|enter the product url ...|
|Save|Save|
|Tags|Tags|

#### ControlPanelEdit.ascx

As mentioned previously, the ControlPanelEdit control is used to edit existing generic content items for this provider.  You are also redirected to this control once the insert is successful. This control will need to be edited to include controls (textboxes, drop-down list, etc.) to edit the Metadata fields.

The `ControlPanelEdit` is very similar to the `ControlPanelInsert` except the `ControlPanelEdit` editing is wrapped in a `radTS:RadMultiPage` control. This `RadMultiPage` control allows you to display multiple pages or tabs on a single page by displaying one page and hiding the others.  The `RadMultiPage` page with the id of `ViewPage` displays the content and Metadata fields separately in a read-only mode. You will not need to edit this portion of the control or "page".  The `RadMultiPage` page with this id of `EditPage` contains the editable part of the control.  This part of the control needs to be edited to add in the edit controls for each of your Metadata fields.  You will need to edit list similarly to the way the `ControlPanelEdit.ascx` file was updated.

In order to display the categories for your specific generic content you will need to modify the

```html
<sfCtg:CategoriesField ProviderName="<ModuleName>" ID="Category" runat="server" />
```

tag.  You will need to add the ProviderName attribute tag and add the name of your generic provider.

#### ControlPanelEdit.ascx.resx

Here are the contents of the ControlPanelEdit.ascx.resx file for the custom module. As you will notice, I created a resource entry for each of the Metadata fields created in the web.config file.

|Name|Values|
|--- |--- |
|AdditionalInfo|Additional info|
|AdditionalInfoNote|This information is not public. It is for your reference only.|
|Author|Author|
|AuthorInput|Author...|
|BackToAllItems|Back to all `<ModuleName>`|
|Cancel|Cancel|
|Category|Category|
|ChangeLanguage|Change Language|
|Company_Name|Company name|
|Company_Url|Company URL|
|Content|Text|
|ContentEmpty|The text cannot be empty!|
|Date|Date|
|Description|Description|
|DescriptionInput|Description...|
|Discount|Discount|
|Discount_Code|Discount code|
|Edit|Edit|
|EditThisItem|Edit this discount|
|GenericContentFAQ|Discount FAQ|
|History|History|
|IsEditingContent|is editing this `` now!|
|ItemVersions|`<ModuleName>` Versions|
|MandatoryFields|Mandatory fields|
|Modifier|Modifier|
|Name|Name|
|NameEmpty|Name cannot be empty!|
|NameInput|Name...|
|Or|or|
|Product|Product|
|Product_Empty|Product name cannot be empty!|
|Product_Input|Product...|
|Product_Logo_Url|Product Url|
|Rollback|Rollback|
|Save|Save|
|SaveChanges|Save changes|
|Tags|Tags|
|Version|Version|
|VersionDateFormat|{0:dd MMM yyyy, hh:mm}|
|View|View|

## Create the new control templates

The control templates are used for displaying the generic content on a user-facing page.

### Create the folder structure

- Open up Windows Explorer (or within Visual Studio).
- Navigate to where your website files are.
- Then navigate to `~/Sitefinity/` `ControlTemplates` folder.
- Select the `Generic_Content` folder.
- Copy it
- Paste it into the `~/Sitefinity/` `ControlTemplates` folder. Windows Explorer will give it a new name.  Rename it to `<ModuleName>`.
- Copy the `~/Sitefinity/ControlTemplates/Events/SocialBookmark` folder to `~/Sitefinity/ControlTemplates/<ModuleName>` folder. For some reason, this was left out of the Sitefinity `Generic_Content` folder.

Here comes the fun part. Depending on your liking, you can rename some of the files in the ~/Sitefinity/ ControlTemplates/`<ModuleName>`.  Here is a list of the files that I would rename.

#### File List

|Filename|Purpose|
|--- |--- |
|`ArchiveTemplate.ascx`|I think this is a holdover from the original News module.  We will not be using it.|
|`CategoriesList.ascx`|This is the control that will display the categories for your content.|
|`CommentsList.ascx`|This is the control that will display the comments.|
|`ContentsViewItemList.ascx` or `<ModuleName>ItemList.ascx`|This is the control that displays the content in a list form (multiple).|
|`ContentsViewSingleItem.ascx` or `<ModuleName>SingleItem.ascx`|This is the control that displays the content in a single item (details).|
|`genericContentCommonLayout.css` or `<ModuleName>CommonLayout.css`|This file contains the CSS rules for this module.|
|`socialBookmarkTemplate.xml`|This contains the different social bookmarking sites available.|
|`TagsList.ascx`|This control displays all of your tag for the content.|

Most of the files do not need to be modified unless you want to.  We will concentrate on the ItemList and SingleItem files.  These files will need to be modified to display your Metadata fields.Modify the control template files

### `<ModuleName>ItemList.ascx`

As mentioned above in the file list section above, the `ItemList` control will be used to display the content items in a "repeater" or list view. As a suggestion, I would print out or keep handy the web.config section so you type the Metadata field names.

Let’s get started. If you renamed the `genericContentCommonLayout.css` you will need to update the FileName attribute of the `sfWeb:CssFileLink` element to match the new name.  It should look something link this.

```html
<sfWeb:CssFileLink ID="CssFileLink1"
  FileName="~/Sitefinity/ControlTemplates/Discounts/discountsCommonLayout.css"
  Media="screen"
  runat="server" />
```

The rest of the changes pretty much come in the `asp:Repeater` control.  You can change the display to look how you wish. If you want to use any of the special fields like Tags or Categories, refer to the `ContentView `control overview earlier in this document.

### '<ModuleName>SingleItem.ascx'

As mentioned above in the file list section above, the SingleItem control will be used to display the content item. As a suggestion, I would print out or keep handy the `web.config` section so you type the Metadata field names.

Let’s get started. If you renamed the `genericConentCommonLayout.css` you will need to update the FileName attribute of the sfWeb:CssFileLink element to match the new name.  It should look something like this.

```html
<sfWeb:CssFileLink ID="CssFileLink1"
  FileName="~/Sitefinity/ControlTemplates/Discounts/discountsCommonLayout.css"
  Media="screen"
  runat="server" />
```

Everything will display within the first div.  You can change the display to look how you wish. If you want to use any of the special fields like Tags or Categories, refer to the ContentView control overview earlier in this document.

## Add the Data

With all of the pages saved you should be able to load the Sitefinity administration section, click on the Generic Content section to start your work.

Click the change group dropdown list and you should see the new content group available. Select the new `<ModuleName>` item and you will see the ControlPanelList.ascx control displayed to the right.

Click on the "Create a new content item", the name might be different if you changed the CreateNewItem item in the `ControlPanelList.ascx.resx` file. You will then be displayed with the `ControlPanelInsert.ascx` control which will allow you to add the content.

## Create the Sitefinity page to display the content

Please refer to the Sitefinity user guide section titled "Working with Web Pages" for details on how to add a page to Sitefinity.  This section will cover the `ContentView` control specific changes, please review the Sitefinity use guide section "Working with user controls" for more information on adding controls to a page.  In my sample, I created a page called `<ModuleName>.aspx` and added a `ContentView` control to the page, which can be found on the left-hand side of the Add Controls toolbox typically in the section named Generic Content.  Once you do this click the Edit hyperlink to set the properties of the `ContentView` control.

|Category|Property|Value|
|---|---|---|
|Appearance|ItemListTemplatePath|This should point to the ContentViewItemList.ascx file that you modified earlier.<br />Example:<br />`~/Sitefinity/ControlTemplates/<ModuleName>/ContentViewItemList.ascx`|
|Appearance|SingleItemListTemplatePath|This should point to the ContentViewSingleItem.ascx file that you modified earlier.<br />Example:<br />`~/Sitefinity/ControlTemplates/<ModuleName>/ContentViewSingleItem.ascx`|
|Data|ProviderName|`<ModuleName>`|
|Explicit Links|SingleItemUrl|This should point to the name of the page that the control is on.<br />`~/<ModuleName>.aspx`|
|Social Bookmarks|SocialBookmarkImageFolder|`~/Sitefinity/ControlTemplates/<ModuleName>/SocialBookmark/`
|Social Bookmarks|SocialBookmarkTemplate|`~/Sitefinity/ControlTemplates/<ModuleName>/socialBookmarkTemplate.xml`|

All of the other properties you can set to your liking.

## Summary

As you can see, building your own generic content provider using the Sitefinity generic content module is easy.  Follow this guide and you could have your new module like Sponsors, Products, or Books built. This should be everything that you need to get started expanding the generic content module of the Sitefinity product to meet your needs.

If there are any questions or comments, shoot me an email at [jguadagno@hotmail.com](mailto:jguadagno@hotmail.com).

Thanks to Joseph Anderson of Telerik for providing some helpful comments on this document.