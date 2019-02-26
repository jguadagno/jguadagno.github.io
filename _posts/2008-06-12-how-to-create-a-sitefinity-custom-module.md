---
title: How to create a Sitefinity custom module
date: 2008-06-12T04:56:05+00:00
author: Joseph Guadagno
permalink: /2008/06/12/how-to-create-a-sitefinity-custom-module/
dsq_thread_id:
  - "3615253834"
categories:
  - Articles
---
Download this document: [How to create a Sitefinity custom module](http://sevdnug.org/Libraries/Sitefinity_Modules/SiteFinity%20Custom%20Module%20Creation.sflb)

Download the source: [SEVDNUG.Contact.zip](http://sevdnug.org/Libraries/Sitefinity_Modules/SEVDNUG.Contacts.sflb)

This document outlines how to create a custom Sitefinity module by modifying the `SEVDNUG.Contacts` module.  The `SEVDNUG.Contacts` module was based on the `Samples.Contacts` module found on the Sitefinity blog.  This document gives you step by step directions on how to modify/tweak this `SEVDNUG.Contacts` module to implement your new custom module.  In addition, I attempt to explain what each file is used for. This sample module is constructed in a very similar to the way the modules of Sitefinity application are constructed. As a result, you should be able to use parts of this document to figure out how to customize certain features of Sitefinity modules. After completing the [First Steps](#first-steps) and [Modify the Code](#modify-the-code) sections of this document, your new module will be available on your Sitefinity site.

If you have any questions or issues, feel free to contact me at jguadagno [at] hotmail.com

## Document conventions <!-- omit in toc -->

Text enclosed in `<>` brackets should be replaced by the type of text listed. So if you see `<CompanyName>`.`<ModuleName>`, the `<ModuleName>` should be replaced by whatever you want to call your module, and the `<CompanyName>` should be replaced by your company name like `SEVDNUG.Vendors`.

## Contents

- [Contents](#contents)
- [First Steps](#first-steps)
- [Modify the Code](#modify-the-code)
	- [`<CompanyName>.<ModuleName> Project`](#companynamemodulename-project)
	- [`<CompanyName>.<ModuleName>.Data Project`](#companynamemodulenamedata-project)
	- [`<CompanyName>.<ModuleName>.Web Project`](#companynamemodulenameweb-project)
- [Sample Solution Structure](#sample-solution-structure)
	- [`<CompanyName>.<ModuleName>`](#companynamemodulename)
	- [`<CompanyName>.<ModuleName>.Data`](#companynamemodulenamedata)
	- [`<CompanyName>.<ModuleName>.Website`](#companynamemodulenamewebsite)
- [Footnotes](#footnotes)

## First Steps

- Rename the solution file to `<companyname>.<modulename>.sln`
- Rename the folders
  - SEVDNUG.Contacts to `<companyname>.<modulename>`
  - SEVDNUG.Contacts.Data to `<companyname>.<modulename>.Data`
  - SEVDNUG.Contacts.Web to `<companyname>.<modulename>.Web`
- Rename the Visual Studio project files
  - `<companyname>.<modulename>\SEVDNUG.Contacts.csproj` to `<companyname>.<modulename>\<companyname>.<modulename>`
  - `<companyname>.<modulename>.Data\SEVDNUG.Contacts.Data.csproj` to `<companyname>.<modulename>.Data\<companyname>.<modulename>.Data`
- Open up the solution in a text editor like Notepad, search and replace `SEVDNUG.Contacts` to `<companyname>.<modulename>`
- Open up the `<companyname>.<modulename>.sln` solution file in Visual Studio.
- Search and replace the text `SEVDNUG.Contacts` with `<companyname>.<modulename>`
- Rename solution (optional)

At the end of this article you will find a sample of what the solution would like.

## Modify the Code

### `<CompanyName>.<ModuleName> Project`

Please follow these steps for this project prior to modifying the files.

- Rename all of the `Contacts*.cs` files to `<ModuleName>*.cs`.
- Rename `IContact.cs` to `I<ModuleName>.cs`
- Rename `WebControls\Contacts*.cs` to `WebControls\<ModuleName>*.cs`
- Rename `WebControls\SingleContact*.cs` to `WebControls\Single<ModuleName>.cs`
- Rename the references to Contact object and `IContact` to `<ModuleName>`, if necessary.

#### `I<ModuleName>.cs` <!-- omit in toc -->

- Add whatever properties will make up the `<ModuleName>` object, these properties should match what you plan on storing in the database.

#### `<ModuleName>Module.cs` <!-- omit in toc -->

This file contains the `Name`, `Title`, and `Description` of your module, as well as the security for your module.

- Update the Description, Title and Name properties to whatever you want to be displayed.
- Rename the text, `Contact` to `<ModuleName>`
- _Note_: that nothing else needs to be changed, other than description, title and name properties

#### `<ModuleName>Provider.cs` <!-- omit in toc -->

This class contains the “definition” of what your module provider implementation needs to support.

- Rename the text, Contact to `<ModuleName>`
- Replace the content of the region “Contact Methods” with methods the fit your desired functionality.  Most of the contact - methods should be a good starting point.
- Add whatever additional methods you think your provider will need. Some examples are:
  - `Get<ModuleName>`
  - `Save<ModuleName>`
  - `Delete<ModuleName>`
  - `Get<ModuleName>s`
- Under the properties section, add properties to the template files that your module will use. If you are making new templates, such as controls for the public facing side of the site such as the blog posts control, you would want to add them here. Here is an example:

```cs
/// <summary>
/// Returns the path of external template for ControlPanel control in insert/edit mode
/// </summary>
public string ControlPanelInsertEditTemplate
{
  get
  {
    return this.controlPanelInsertEditTemplate;
  }
}
```

#### `<ModuleName>Manager.cs` <!-- omit in toc -->

This class provides is present in most Provider model patterns. It contain methods to interact with the provider.

- Rename the text, `Contact` to `<ModuleName>`
- Replace the content of the region “**Contact Methods**” with methods the fit your desired functionality.  Most of the contact - methods should be a good starting point. This should closely mirror the Provider methods.
- Add whatever additional methods you think your manager class will need.

#### WebControls/* <!-- omit in toc -->

These classes provide the functionality to edit or display the data within Sitefinity.

- Replace the text, `Contact` to `<ModuleName>`
- _Note_, you probably will have to manually change the Resources/Messages.resx content. TODO: Add reference to new localization article.

#### `Single<ModuleName>.cs` <!-- omit in toc -->

This is used to display a single item (`<ModuleName>`). This file provides the code behind to the `Single<ModuleName>.ascx` file.

- Replace the text, `Contact` to `<ModuleName>`
- Modify the `Single<ModuleName>Container` to include the fields defined in `I<ModuleName>.cs` file.
- Modify the `CreateChildControls` to reflect the controls that are available in the `layoutContainer`

#### `<ModuleName>Lists.cs` <!-- omit in toc -->

This is used to display a list of items (`<ModuleName>s`)

- Replace the text, `Contact` to `<ModuleName>`
- Modify the `<ModuleName>Repeater_ItemDataBound` method to display the properties of the object.

#### `Admin\<ModuleName>Editor.cs` <!-- omit in toc -->

This control is used for inserting new `<ModuleName>` objects or editing existing ones.

- Replace the text, Contact to `<ModuleName>`
- Update the `CreateChildControls` method of the `<ModuleName>Editor` class to match the properties available within your new module class.
- Update the `CreateNew<ModuleName>` method of the `<ModuleName>Editor` class to match the properties available within your new module class.
- Update the `Update<ModuleName>` method of the `<ModuleName>Editor` class to match the properties available within your new module class.
- Update the `<ModuleName>EditorContainer` class to the match the properties within your new module class. This should most likely match the `Single<ModuleName>.cs` class.

Essentially, any properties that are available in your `I<ModuleName>` interface should have a line in the `CreateChildControls`, `CreateNew<ModuleName>`, `Update<ModuleName> methods`, as wells as properties in the `<ModuleName>EditorContainer` class.

#### `Admin\CommandPanel.cs` <!-- omit in toc -->

This module is used to display the side content in the Sitefinity admin interface. Other than changing its name, you do not need to change this control.

- Replace the text, `Contact` to `<ModuleName>`

#### `Admin\ControlPanel.cs` <!-- omit in toc -->

This module is used to display the side content in the Sitefinity admin interface. Other than changing its name, you do not need to change this control.

- Replace the text, `Contact` to `<ModuleName>`
  
### `<CompanyName>.<ModuleName>.Data Project`

This assembly is responsible for all of the data access. At minimum it will have three classes, with this implementation, `DefaultProvider.cs`, `Variable.dbclass`, and `<ModuleName>.dbclass`. Optionally, you can add `<ModuleName>.cs` and `<ModuleNames>s.cs` to add additional data access methods. Any file with the extension "`.dbclass`" makes a table in your database.

Please follow these steps for this project prior to modifying the files.

- Rename `Contact.*` to `<ModuleName>*.cs`
- Search and replace `Contact` with `<ModuleName>`.
- Add a reference to the new `<CompanyName>.<ModuleName>` project.

#### `DefaultProvider.cs` <!-- omit in toc -->

This class provides the implementation of the provider for the `<ModuleName>`. The private fields and following methods should not need to be changed; `SetVariable`, `GetVariable`, and `Initialize`. The first step to do is to replace the `Contact` with `<ModuleName>`. The next step is to implement any of the other methods required by `<ModuleName>Provider`.

#### `Variable.dbclass` <!-- omit in toc -->

This file generates the database table for the variables table. This should not change.

#### `<ModuleName>.dbclass` <!-- omit in toc -->

This class generates the database for the `<ModuleName>` table.  This file should change according to the way you want your database table. The Nolics library will create the table for you. Example:

```sql
dbclass ModuleName [TableName="SEVDNUG_ModuleName"]{
    primary key string Application [50], guid ID[AutoGenGUID = true];
    string Name[Length=100];
    string Url[Length=255];
    string LogoUrl[Length=255];
    modified date ModifiedOn;
    created date CreatedOn;
```

For more info on modifying the dbclass library or how to modify this file, check the Nolics [documentation](http://www.nolics.net/Docs4_2/Ref_dbclass.html).

Where is the tutorial that tells you how to make tables?

#### `<ModuleName>.cs` <!-- omit in toc -->

This class will allow you to add additional properties and methods to the Nolics generated class.

#### `<ModuleName>s.cs` <!-- omit in toc -->

This class creates a dynamic query around the module table. Dynamic queries are typically used when there are custom table joins that you want to be available to any calling class. For more information on creating or using dynamic queries with Nolics please check out the Nolics [documentation](http://www.nolics.com/Material2005/WT10_Queries.doc).

```cs
public class ModuleNames: Query<ModuleName>
{

}
```

### `<CompanyName>.<ModuleName>.Web Project`

Please follow these steps for this project prior to modifying the files.

- Rename the `/Sitefinity/ControlTemplates/Contacts` folder to `/Sitefinity/ControlTemplates/<ModuleName>`
- Rename the file `/Sitefinity/ControlTemplates/<ModuleName>/ContactsListTemplate.ascx` to `<ModuleName>ListTemplate.ascx`
- Rename the file `/Sitefinity/ControlTemplates/<ModuleName>/SingleContactTemplate.ascx` to `Single<ModuleName>Template.ascx`

#### `Web.Config` <!-- omit in toc -->

The `web.config` file for your Sitefinity installation will need to be modified to inform Sitefinity of the new module.  _Please note_: this section of the document requires that you modify your existing Sitefinity `web.config`.

Please back up your `web.config` file before you change it!
{: .notice--danger}

There are three parts of the web.config file that need to be modified. They include the modules section, section group, and the meta fields section. The web.config provided in this example has a

```html
<!-- START REPLACE : Step # -->
```

tag followed by a

```xml
<!-- END REPLACE : Step # -->
```

tag where text needs to be replaced or modified.

#### Notify ASP.NET of the new section group <!-- omit in toc -->

Search for

```xml
<!-- START REPLACE : Step 1 -->
```

This section needs to be placed after the closing tag of the Telerik section group of your existing Sitefinity `web.config` file.

- Replace the text of `SEVDNUG` with your company name. This should be what every use used for `<CompanyName>`.
- Replace the text of `Contacts` with your module name. This should be what every use used for `<ModuleName>`.

#### Tell Sitefinity about your new module <!-- omit in toc -->

Search for

```xml
<!-- START REPLACE : Step 2 -->
```

The line following this tag needs to be added to you telerik/framework/modules/ section of your existing Sitefinity web.config file.

- Replace the text of `SEVDNUG` with your company name. This should be what every use used for `<CompanyName>`.
- Replace the text of `Contacts` with your module name. This should be what every use used for `<ModuleName>`.

#### Add the new section group <!-- omit in toc -->

Search

```xml
<!-- START REPLACE : Step 3 -->
```

Everything between this tag and the

```xml
<!-- END REPLACE : Step 3 -->

```

tag should be added to the end your exist web.config.

- Replace the text of `SEVDNUG` with your company name. This should be what every use used for `<CompanyName>`.
- Replace the text of `Contacts` with your module name. This should be what every use used for `<ModuleName>`.
- Replace the text of contact with the `<ModuleName>` for the following lines.

```xml
contactsPermissionsTemplate="~/Sitefinity/Admin/ControlTemplates/Contacts/ContactsPermissionsTemplate.ascx"
contactEditorTemplate="~/Sitefinity/Admin/ControlTemplates/Contacts/ContactEditorTemplate.ascx"
contactsListTemplate="~/Sitefinity/ControlTemplates/Contacts/ContactsListTemplate.ascx"
singleContactTemplate="~/Sitefinity/ControlTemplates/Contacts/SingleContactTemplate.ascx"
```

Note, these xml attributes map to the properties that you defined in the `<ModuleName>Provider` class. Here is an example:

```cs
/// <summary>
/// Returns the path of external template for ContactsPermission
/// view set in web.config
/// </summary>
public string ContactsPermissionsTemplate
{
  get
  {
    return this.contactsPermissionsTemplate;
  }
}
```

#### Add the new meta fields <!-- omit in toc -->

So Sitefinity can recognize the database columns that your module will make, you must declare them in the meta fields section of your web.config. Here is an example from the blogs module:

```xml
<metafields>
  <add key="<ModuleName>.Title" valueType="ShortText" visible="True" searchable="True"sortable="True" defaultValue=""/>
  <add key="<ModuleName>.Author" valueType="ShortText" visible="True" searchable="True"sortable="True" defaultValue=""/>
  <add key="<ModuleName>.Publication_Date" valueType="DateTime" visible="True"searchable="True" sortable="True"   defaultValue="#Now"/>
  <add key="<ModuleName>.BlogID" valueType="Guid" visible="False" searchable="True"sortable="True" defaultValue=""/>
  <add key="<ModuleName>.Category" valueType="ShortText" visible="True"searchable="True" sortable="True" defaultValue=""></add>
</metafields>
```

Here is a breakdown of the properties:

|Property|Description|
|Key|This is the name of your module, then a period, then the name of the field.|
|ValueType|This property will depend on the type you set in your `I<ModuleName>.cs` file. If you set the type to GUID, then the value type will be GUID. This property should be short text for a paragraph under 256 characters and long text if it is above 256 characters.|
|Visible|This property should be true, unless this field is an ID column which should not be edited. If the valueType property is GUID, then the visible property should be false.|
|Searchable|If you would like your end user to search this property in the admin when in this module, then set this property to true. In the blogs module, as an example, you can search blogs by title.|
|Sortable|In the grid for the module in the admin, this will make the field sortable.|
|DefaultValue|This property is set to `null`, unless you want a value to be added all the time|

#### Public and Private Templates <!-- omit in toc -->

So your end user can use the control on the page, you will need a public template. Generally, this consists of a repeater control with a series of controls inheriting from the `ItextControl` Interface. Sitefinity mainly uses literal and label controls and binds their ID property to a data field. In the blogs module, you could bind a label control to the author field like this:

```html
<asp:Label ID=”Author” runat=”server”></asp:label>
```

When you are in the blogs module, you omit the word blogs and just use the word after the period.
The private templates are for users who click on the modules tab in the admin. These templates are used to add content to the modules and set permissions. Generally, you would only want to edit the templates that a person uses to add content. Adding and removing fields in the same as the public templates. Just add a label, as an example, and give its ID property a name from the meta fields section of the `web.config`.

#### Copy to Sitefinity <!-- omit in toc -->

To deploy your module, you must copy the module theme, the newly created bin files and the templates by following these instructions:

- Add a reference in your Sitefinity web project to the new `<CompanyName>.<ModuleName>` and `<CompanyName>.<ModuleName>.Data` assemblies or projects.
- Copy `<CompanyName>.<ModuleName>.Website\Admin\ControlTemplates\<ModuleName>` to your Sitefinity directory`\Admin\ControlTemplates\<ModuleName>`
- Copy `<CompanyName>.<ModuleName>.Website\ControlTemplates\<ModuleName>` to your Sitefinity directory\` ControlTemplates\<ModuleName>`
- Copy `<CompanyName>.<ModuleName>.Website\Admin\Themes\Default\` to your Sitefinity directory`\Admin\Themes\Default\`

## Sample Solution Structure

### `<CompanyName>.<ModuleName>`

- Properties
  - AssemblyInfo.cs
- References
  - RadComboNox.Net2 [i](#i)
  - RadGrid.Net2 [ii](#ii)
  - RadMenu.Net2 [iii](#iii)
  - RadTreeView.Net2 [iv](#iv)
  - System
  - System.configuration
  - System.Data
  - System.Drawing
  - System.Web
  - System.Xml
  - Telerik.Cms
  - Telerik.Cms.Web.UI
  - Telerik.Framework
  - Telerik.Security
    - Configuration
  - `ConfigurationHelper.cs`
  - `SectionHandler.cs`
    - Resources
  - `CommandPanel.js`
  - `Messages.resx`
    - Security
  - `GlobalPermission.cs`
  - `GlobalPermissions.cs`
    - WebControls
      - Admin
        - `AlphabetLinks.cs` [v](#v)
        - `CommandPanel.cs`
        - `<ModuleName>Editor.cs`
        - `ControlPanel.cs`
      - `<ModuleName>List.cs`
      - `<ModuleName>ListToolboxItem.cs`
      - `Single<ModuleName>.cs`
      - `Single<ModuleName>ToolboxItem.cs`
    - `<ModuleName>Manager.cs`
    - `<ModuleName>.Module.cs`
    - `<ModuleName>Provider.cs`
    - `I<ModuleName>.cs`

### `<CompanyName>.<ModuleName>.Data`

- Properties
  - AssemblyInfo.cs
- References
  - Nolics.Engine.v4.2 [vi](#vi)
  - `<CompanyName>.<ModuleName>`
  - System
  - System.configuration
  - System.Data
  - System.Xml
  - Telerik.DataAccess
  - Telerik.Framework
  - Telerik.Security
- Resources
  - `Messages.resx`
- `<ModuleName>.cs`  [vii](#vii)
- `<TableName>.dbclass`
- `DefaultProvider.cs`

### `<CompanyName>.<ModuleName>.Website`

- Admin
  - ControlTemplates
    - `<ModuleName>`
      - `CommandPanelTemplate.ascx`
      - `<ModuleName>EditorTemplate.ascx`
      - `<ModuleName>sPermissions.ascx`
      - `ControlPanelInsertEditTemplate.ascx`
      - `ControlPanelListTemplate.ascx`
        - `App_LocalResources`
          - Any resource files
  - Themes
    - Default
      - `Modules.css`
  - ControlTemplates
    - `<ModuleName>`
      - `<ModuleName>sListTemplate.ascx`
      - `Single<ModuleName>Template.ascx`

## Footnotes

|||
|---|---|
|<a id="i">i</a>|Optional, only required if you controls/templates use this control and you are licensed to use it.|
|<a id="ii">ii</a>|Optional, only required if you controls/templates use this control and you are licensed to use it.|
|<a id="iii">iii</a>|Optional, only required if you controls/templates use this control and you are licensed to use it.|
|<a id="iv">iv</a>|Optional, only required if you controls/templates use this control and you are licensed to use it.|
|<a id="v">v</a>|Optional, only if you wish to implement this command panel control.|
|<a id="vi">vi</a>|Optional, only if you use the Nolics library for data access.|
|<a id="vii">vii</a>|Optional, only if you want to add additional data access methods to the Nolics’ generated class.|