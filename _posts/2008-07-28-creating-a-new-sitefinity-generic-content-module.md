---
id: 801
title: Creating a new Sitefinity generic content module
date: 2008-07-28T03:39:00+00:00
author: Joseph Guadagno
layout: post
guid: http://www.josephguadagno.net/post.aspx?id=7ecf5c5c-7c22-4e67-bd73-d6c800b6f552
permalink: /2008/07/28/creating-a-new-sitefinity-generic-content-module/
dsq_thread_id:
  - "3621086018"
categories:
  - Articles
---
So, I heard that the <a href="http://www.sitefinity.com/">Sitefinity</a> application had this generic content module that was pretty easy to use to create your own module with. Why do you need to create a new generic content based module you ask?  There a few answers to that question.  I created a new generic content based module because I wanted to track all of the discounts that were offered to the <a href="http://www.sevdnug.org/">Southeast Valley .NET user group</a> and since free time is a something I do not have lately, it was an easy choice.  You might also want to leverage the existing Sitefinity generic content module because you do not have any development resources available to.  As the name implies it is generic, so generic in fact, it is used by the blog feature, news feature and events feature.

After a week’s worth of digging into the code and documentation, I was successful. So that you do not have to go through the pain, I will lay out the instructions for you.  This guide will require virtually no coding, just a little HTML markup, and some web.config changes.

There are few steps involved in creating a new copy of the generic module.  The first step is to BACKUP your web.config file and Sitefinity project, just to be safe. Here is a list of other steps:

<a href="#_Getting_Started">Getting Started</a>
<a href="#_Modify_the_web.config">Modify the web.config file</a>
<a href="#_Create_your_new">Create the new admin section</a>
<a href="#_Create_you_new">Create the new control templates</a>
<a href="#_Add_the_data">Add the data</a>
<a href="#_Create_the_Sitefinity">Create the Sitefinity page to display the content</a>

<a href="#_Summary">Summary</a>
<h2>Document Conventions</h2>
Throughout this document, you will see the text &lt;<em>ModuleName</em>&gt;. Whenever you see this text you should replace the &lt;<em>ModuleName</em>&gt; with the new name of your module. For example, I created a discount module and whenever I saw &lt;<em>ModuleName</em>&gt; I replaced it with Discount.
<h2><a name="_Getting_Started"></a>Getting Started</h2>
There are two bugs in Sitefinity 3.2 Service Pack 2 hotfix 1616 that cause potential problems with using multiple generic control providers and the ContentView control.  Here are the posted fixes for them.
<h3>Multiple Providers Fix</h3>
This bug does not allow for you to select multiple generic content providers.

To fix this issue, check out the Sitefinity knowledgebase article titled <a href="http://www.sitefinity.com/support/knowledge-base/kb-article/b1154K-bach-b1154T-cmm.aspx">Adding a custom provider for Generic Content</a>
<h3>The Settings for ContentView controls are reset fix</h3>
To fix this issue, check out the Sitefinity knowledgebase article titled <a href="http://www.sitefinity.com/support/knowledge-base/kb-article/b1154K-bace-b1154T-cmm.aspx">Settings applied to the Content View based controls are reset</a>
<h3>Resource Files</h3>
Sitefinity is built on top of the .NET framework, and this coding technology can localize text properties (and other attributes, such as tooltips) Within an ASP.NET page, you will see the string <span style="background: yellow;">&lt;%</span>$Resources:SearchItemsBy <span style="background: yellow;">%&gt;</span>. This code tells the ASP.NET engine to get the resource file text in the key SearchItemsBy. This language is based on the page’s locale. If this text was on the ControlPanelInsert.ascx control, ASP.NET would look within the ControlPanelInsert.ascx.resx file, unless you had localized versions then it would look in ControlPanelInsert.ascx.&lt;<em>locale</em>&gt;.resx.

For more information, please read <a href="https://msdn.microsoft.com/en-us/library/fw69ke6f.aspx" target="_blank" rel="noopener">Walkthrough: Using Resources for Localization with ASP.NET</a> from MSDN.

Keep this in mind while editing your Sitefinity controls later on.
<h3><a name="_ContentView_Control_Overview"></a>ContentView Control Overview</h3>
The ContentView control in Sitefinity does most of the work for displaying generic content on a control or page. The ContentView control displays data on the web control by "looking" for control names that match the Meta field names within the provider. If you have a Meta field called <strong>"Product"</strong> then the ContentView control will look for a control on the page with the name "Product" and populate the control with the value of the Meta field.

When the ContentView control sees a control with one of these names it will populate them with special functions.
<table class="table table-striped table-bordered">
<thead>
<tr>
<th>Control name</th>
<th>Purpose</th>
</tr>
</thead>
<tbody>
<tr>
<td>fullContent1</td>
<td>This will be used to create a hyperlink to the details or “SingleItem” version of this content item.</td>
</tr>
<tr>
<td>fullContent2</td>
<td>This is the same as fullContent1.</td>
</tr>
<tr>
<td>content</td>
<td>This will be used to display your generic content.</td>
</tr>
<tr>
<td>CommentsLink</td>
<td>This will be used to create a hyperlink to view the comments of the content</td>
</tr>
<tr>
<td>CommentsCount</td>
<td>This will be used to display the total number of comments on this content.</td>
</tr>
<tr>
<td>Category</td>
<td>This will be used to display the category of the content. If this is a hyperlink control, the contentview control,
will place a hyperlink on the page that will allow you to view all of the content classified in that category.</td>
</tr>
<tr>
<td>Tags</td>
<td>For this you will need an ASP.NET Repeater control and the content view control will place the tags used for
that content</td>
</tr>
<tr>
<td>Bookmarks</td>
<td>For this you will need an ASP.NET Repeater control and the content view control will place the tags used for
that content</td>
</tr>
</tbody>
</table>
The ContentView control has two properties under the appearance section that tell it what control to display on the web page when you are in List mode or Single Item mode. These two properties are ItemListTemplatePath and SingleItemTemplatePath, respectively.
<h2><a name="_Modify_the_web.config"></a>Modify the web.config file</h2>
<div class="alert alert-danger" role="alert"><strong>Warning</strong> Before you begin, <strong>BACKUP</strong> your web.config. The smallest error or unclosed angle bracket will cause your Sitefinity application to stop working.</div>
<h3>Add the new provider</h3>
Locate the section in your web.cofig file that is titled cmsProvider. It looks something like this

<script src="https://gist.github.com/jguadagno/f938e25c199652bab3994b4f11043670.js"></script>

Copy the element (section) whose name is “Generic_Content”. It should look something like this

<script src="https://gist.github.com/jguadagno/9b6bed404ca585ae658c13cdc00cc25b.js"></script>

Paste this element onto the next line of the web config.

Change the following attributes.
<table class="table table-striped table-bordered">
<thead>
<tr>
<th>Attribute</th>
<th>Value</th>
</tr>
</thead>
<tbody>
<tr>
<td>name</td>
<td>&lt;ModuleName&gt;</td>
</tr>
<tr>
<td>urlRewriteFormat</td>
<td>The way you would like your URLs to look.</td>
</tr>
<tr>
<td>defaultMetaField</td>
<td>The name of the default meta field. Note: This must match a value in the meta field that you create later; otherwise you will get a difficult to debug "<em>The given key is not present in the dictionary</em>" exception.</td>
</tr>
</tbody>
</table>
The urlRewriteFormat field can comprise of any of your Meta field names.  It my case, I created the following.
<script src="https://gist.github.com/jguadagno/0ec7596f1ec91748882b5e54983a37ce.js"></script>

All of the other fields you are free to do with as you choose.  Here is the sample Discount provider.

<script src="https://gist.github.com/jguadagno/618179e8efb7b47d6b8917b415682f73.js"></script>
<h3>Add the new Meta fields</h3>
Further down in the web.config file, you should find an element, add Meta keys for each field for your new module. For the discount module, here is what I added:

<script src="https://gist.github.com/jguadagno/1b07d95a4f7c3c1ed5723087c30c8578.js"></script>

Please note that the name of the module and the word before the period must match the module name. For the Discounts Module provider I discussed, the name should be Discounts as shown below this sentence:

The important part is for each property/field you want you to need to add a line. You will notice the format is "PropertyName". For more information on the attributes, check out the Sitefinity developer’s documentation at <a href="http://www.sitefinity.com/help/developer-manual/telerik.cms.engine-telerik.cms.engine.metainfo_members.html" target="_blank" rel="noopener">http://www.sitefinity.com/help/developer-manual/telerik.cms.engine-telerik.cms.engine.metainfo_members.html</a>.

Save your web.config and this completes all necessary changes to the file.
<h2><a name="_Create_your_new"></a>Create your new admin section</h2>
<h3>Create the folder structure</h3>
So you can interface with the Discounts Module, you will now need to create the template files by following these steps:
<ol style="margin-top: 0in;" type="1">
 	<li>Open the Windows Explorer (or within Visual Studio).</li>
 	<li>Navigate to your website’s root directory.</li>
 	<li>Go to <strong>~/Sitefinity/Admin/ControlTemplates</strong> folder.</li>
 	<li>Select the <strong>Generic_Content</strong> folder and paste it into the <strong>~/Sitefinity/Admin/ControlTemplates</strong> directory.</li>
 	<li>Rename that folder to &lt;<em>ModuleName</em>&gt;. In my example, I renamed it to Discounts.</li>
</ol>
<h4>File List</h4>
<table class="table table-striped table-bordered">
<thead>
<tr>
<th>Old name</th>
<th>New Name</th>
</tr>
</thead>
<tbody>
<tr>
<td>App_LocalResources</td>
<td>All of the application resource files are found here. These files contain most notably the text properties for
all of the controls on the template.  There should be one .resx for each .ascx file.  This is how .NET allows
you to create localized versions of your applications.</td>
</tr>
<tr>
<td>CategoriesField.ascx</td>
<td>Provides a drop down list of categories to choose from.</td>
</tr>
<tr>
<td>CategoriesManagement.ascx</td>
<td>Provides the ability to add, remove and modify categories that are available to this generic content.</td>
</tr>
<tr>
<td>CategoriesSelector.ascx</td>
<td>A control to select the categories to filter your records by.</td>
</tr>
<tr>
<td>CommandPanel.ascx</td>
<td>This control is what is displayed on the left hand side of the Sitefinity administration console.  You should
not need to modify this.</td>
</tr>
<tr>
<td>CommentsEdit.ascx</td>
<td>A control that provides the ability to edit the comments of your generic content.</td>
</tr>
<tr>
<td>CommentsList.ascx</td>
<td>A control that lists the comments for your generic content.</td>
</tr>
<tr>
<td>CommentsView.ascx</td>
<td>A control that displays the individual comment of your generic content from the comments list control.</td>
</tr>
<tr>
<td>ContentSelector.ascx</td>
<td>This control provides a means to let you select generic content.</td>
</tr>
<tr>
<td>ContentVersionView.aspx</td>
<td>This is the control that will display the version history when you click on the version tab.</td>
</tr>
<tr>
<td>ControlPanelEdit.ascx</td>
<td>This is the admin control that allows you to edit your generic content.</td>
</tr>
<tr>
<td>ControlPanelInsert.ascx</td>
<td>This is the admin control that allows you to insert your generic content.</td>
</tr>
<tr>
<td>ControlPanelList.ascx</td>
<td>This is the admin control that displays the generic content available.</td>
</tr>
<tr>
<td>ControlPanelPermissions.ascx</td>
<td>This control provides the security controls for your generic content.</td>
</tr>
<tr>
<td>Design</td>
<td>Folder for the designer templates. I do not think these are used yet.</td>
</tr>
<tr>
<td>EditorTemplate.ascx</td>
<td>Not sure of purpose.  Not sure of use.</td>
</tr>
<tr>
<td>NewContentDialog.ascx</td>
<td>When you are creating page and you drag the Generic Content Module onto it, this is the dialog when you click
“Share this Content”</td>
</tr>
<tr>
<td>SelectContentDialog.ascx</td>
<td>Same idea as above, but this is when you click on “Select Shared Content”</td>
</tr>
<tr>
<td>TagEditor.ascx</td>
<td>This control allows you to edit an individual tag</td>
</tr>
<tr>
<td>TagsManagement.ascx</td>
<td>This control allows you to edit the tags available for your content.</td>
</tr>
</tbody>
</table>
<h3>Modify the admin files</h3>
There are three files that you are going to want to modify to accommodate your new Meta fields. They are ControlPanelList.ascx, ControlPanelInsert.ascx, and ControlPanelEdit.ascx.  I listed them in the order that they should be modified for testing.
<h4>ControlPanelList.ascx</h4>
As mentioned previously, the ControlPanelList.ascx control is used to display the generic content in the admin panel. Of the three controls, the List control is the least likely to need modification. This control has two divs called “ToolsAll” and “workArea,” which break up the workspace for listing the generic content.

ToolsAll contains the <strong>createNewButton</strong>, which allows you to create a new generic content item and the <strong>searchInputs </strong>section which allows you to search for generic content. The choices for the search criteria depend on whether you make the Meta data “searchable” in the web.config file. Here is an example:

<script src="https://gist.github.com/jguadagno/e00f94e57fdc6b82bea65545c57da91a.js"></script>

The div named “workArea” is broken up into three sections; <strong>gridTitle</strong> which provides the title for the grid, the <strong>GridView1</strong> which will display the grid of generic content items, and an ASP.NET PlaceHolder control named <strong>emptyWindow</strong>, which displays text when there are no content items in this provider.

If you would like to add a new provider with additional Meta fields, then you would need to add additional columns to <strong>GridView1 </strong>because this grid displays the meta fields.  These additional columns would help you narrow down the generic content that you want to modify.

<script src="https://gist.github.com/jguadagno/31f7721bd0af444b641fcbf8be3279d6.js"></script>

To add a column to the grid control looks the <strong>Columns</strong> element, use the sample below this sentence:

<script src="https://gist.github.com/jguadagno/d5291f24b039482b329ba2f643761387.js"></script>

In this sample, I removed the Description field because I am not using it. I added a Company_Name column because this was a new meta field I added to the web.config file. Be sure to remove any unused Meta data fields or else you will get a runtime exception.
<h4>ControlPanelList.ascx.resx</h4>
Here are the contents of the resource file with some modifications.
<table class="table table-striped table-bordered">
<thead>
<tr>
<th>Name</th>
<th>Value</th>
</tr>
</thead>
<tbody>
<tr>
<td>AllContentItems</td>
<td>All &lt;<em>ModuleName</em>&gt;</td>
</tr>
<tr>
<td>Author</td>
<td>Author</td>
</tr>
<tr>
<td>CheckGenericContentFAQ</td>
<td>Check &lt;<em>ModuleName</em>&gt; FAQs</td>
</tr>
<tr>
<td>Company_Name</td>
<td>Company name</td>
</tr>
<tr>
<td>CreateNewItem</td>
<td>Create a &lt;<em>ModuleName</em>&gt;</td>
</tr>
<tr>
<td>CreateYourFirstContent</td>
<td>Create your first &lt;<em>ModuleName</em>&gt;</td>
</tr>
<tr>
<td>CreateYourFirstContentTooltip</td>
<td>&lt;<em>ModuleName</em>&gt;</td>
</tr>
<tr>
<td>Delete</td>
<td>Delete</td>
</tr>
<tr>
<td>Description</td>
<td>Description</td>
</tr>
<tr>
<td>Edit</td>
<td>Edit</td>
</tr>
<tr>
<td>For</td>
<td>for</td>
</tr>
<tr>
<td>Name</td>
<td>Name</td>
</tr>
<tr>
<td>NoContent</td>
<td>No &lt;<em>ModuleName</em>&gt; have been created yet.</td>
</tr>
<tr>
<td>Or</td>
<td>or</td>
</tr>
<tr>
<td></td>
<td>Permissions FAQ</td>
</tr>
<tr>
<td>Product</td>
<td>Product name</td>
</tr>
<tr>
<td>Search</td>
<td>Search</td>
</tr>
<tr>
<td>SearchItemsBy</td>
<td>Search &lt;<em>ModuleName</em>&gt; by</td>
</tr>
<tr>
<td>Status</td>
<td>Status</td>
</tr>
</tbody>
</table>
<h4>ControlPanelInsert.ascx</h4>
As mentioned previously, the ControlPanelInsert control is used to insert new generic content items for this provider.

Just like the ControlPanelList control, this control is broken up into two divs, “ToolsAll” and “divWorkArea.” The ToolsAll contains the “back to …” link and the divWorkArea contains everything else.

There are three parts to the “divWorkArea,” the <span style="font-size: 10pt; line-height: 115%; font-family: Consolas; color: #a31515;">sfMsg</span><span style="font-size: 10pt; line-height: 115%; font-family: Consolas; color: blue;">:</span><span style="font-size: 10pt; line-height: 115%; font-family: Consolas; color: #a31515;">MessageControl</span> control which displays messages based on the success or failure of saving the content, the mainForm which provides the editing surface, and the info div, which displays the FAQ text.

The mainForm again provides the area for which you insert your generic content. Some things that you need to know.  All of the Meta data fields need to be within the control <span style="font-size: 10pt; line-height: 115%; font-family: Consolas; color: #a31515;">sfGCn</span><span style="font-size: 10pt; line-height: 115%; font-family: Consolas; color: blue;">:</span><span style="font-size: 10pt; line-height: 115%; font-family: Consolas; color: #a31515;">ContentMetaFields</span> and the <span style="font-size: 10pt; line-height: 115%; font-family: Consolas; color: blue;">&lt;</span><span style="font-size: 10pt; line-height: 115%; font-family: Consolas; color: #a31515;">ItemTemplate</span><span style="font-size: 10pt; line-height: 115%; font-family: Consolas; color: blue;">&gt;</span> sub element otherwise the Sitefinity engine will not save the values. The fieldset classes are used to group the content together. Here is a sample fieldset with the Meta data fields for the discount content provider.

<script src="https://gist.github.com/jguadagno/3727a2513cff61175eba1e2283f0c4a9.js"></script>

Each of the individual field is wrapped in a li HTML tag. There is a label, and a TextBox for each Meta data field.

In order to display the categories for your specific generic content you will need to modify the

<script src="https://gist.github.com/jguadagno/26eec099cc7afee4d3900d4f39837d62.js"></script>

tag.  You will need to add the ProviderName attribute tag and add the name of your generic provider.
<h4>ControlPanelInsert.ascx.resx</h4>
Here are the contents of the ControlPanelInsert.ascx.resx file for the custom module. As you will notice, I created a resource entry for each of the Metadata fields created in the web.config file.
<table class="table table-striped table-bordered">
<thead>
<tr>
<th>Name</th>
<th>Value</th>
</tr>
</thead>
<tbody>
<tr>
<td>AdditionalInfo</td>
<td>Additional Info</td>
</tr>
<tr>
<td>AdditionalInfoNote</td>
<td>This information is not public. It is for your reference only.</td>
</tr>
<tr>
<td>Author</td>
<td>Author</td>
</tr>
<tr>
<td>AuthorInput</td>
<td>Author...</td>
</tr>
<tr>
<td>BackToAllItems</td>
<td>Cancel and go back</td>
</tr>
<tr>
<td>Cancel</td>
<td>Cancel</td>
</tr>
<tr>
<td>Category</td>
<td>Category</td>
</tr>
<tr>
<td>Company_Name</td>
<td>Company name</td>
</tr>
<tr>
<td>Company_Name_Input</td>
<td>enter the company name ...</td>
</tr>
<tr>
<td>Company_Url</td>
<td>Company URL</td>
</tr>
<tr>
<td>Company_Url_Input</td>
<td>enter the company url ...</td>
</tr>
<tr>
<td>Content</td>
<td>Text</td>
</tr>
<tr>
<td>ContentEmpty</td>
<td>The text cannot be empty!</td>
</tr>
<tr>
<td>CreateThisItem</td>
<td>Create this discount</td>
</tr>
<tr>
<td>Description</td>
<td>Description</td>
</tr>
<tr>
<td>DescriptionInput</td>
<td>Description...</td>
</tr>
<tr>
<td>Discount</td>
<td>Discount</td>
</tr>
<tr>
<td>Discount_Code</td>
<td>Discount code</td>
</tr>
<tr>
<td>Discount_Code_Input</td>
<td>enter the discount code ...</td>
</tr>
<tr>
<td>Discount_Input</td>
<td>enter the discount ...</td>
</tr>
<tr>
<td>GenericContentFAQ</td>
<td>Discount FAQ</td>
</tr>
<tr>
<td>MandatoryFields</td>
<td>Mandatory fields</td>
</tr>
<tr>
<td>Or</td>
<td>or</td>
</tr>
<tr>
<td>Product</td>
<td>Product</td>
</tr>
<tr>
<td>Product_Empty</td>
<td>Product cannot be empty!</td>
</tr>
<tr>
<td>Product_Input</td>
<td>enter the product ...</td>
</tr>
<tr>
<td>Product_Label</td>
<td>Product</td>
</tr>
<tr>
<td>Product_Logo_Url</td>
<td>Product Url</td>
</tr>
<tr>
<td>Product_Logo_Url_Input</td>
<td>enter the product url ...</td>
</tr>
<tr>
<td>Save</td>
<td>Save</td>
</tr>
<tr>
<td>Tags</td>
<td>Tags</td>
</tr>
</tbody>
</table>
<h4>ControlPanelEdit.ascx</h4>
As mentioned previously, the ControlPanelEdit control is used to edit existing generic content items for this provider.  You are also redirected to this control once the insert is successful. This control will need to be edited to include controls (textboxes, drop-down list, etc.) to edit the Metadata fields.

The ControlPanelEdit is very similar to the ControlPanelInsert except the ControlPanelEdit editing is wrapped in a <strong>radTS:RadMultiPage</strong> control. This RadMultiPage control allows you to display multiple pages or tabs on a single page by displaying one page and hiding the others.  The RadMultiPage page with the id of <em>ViewPage</em> displays the content and Metadata fields separately in a read-only mode. You will not need to edit this portion of the control or “page”.  The RadMultiPage page with this id of <em>EditPage</em> contains the editable part of the control.  This part of the control needs to be edited to add in the edit controls for each of your Metadata fields.  You will need to edit list similarly to the way the ControlPanelEdit.ascx file was updated.

In order to display the categories for your specific generic content you will need to modify the

<script src="https://gist.github.com/jguadagno/26eec099cc7afee4d3900d4f39837d62.js"></script>

tag.  You will need to add the ProviderName attribute tag and add the name of your generic provider.
<h4>ControlPanelEdit.ascx.resx</h4>
Here are the contents of the ControlPanelEdit.ascx.resx file for the custom module. As you will notice, I created a resource entry for each of the Metadata fields created in the web.config file.
<table class="table table-striped table-bordered">
<thead>
<tr>
<th>Name</th>
<th>Values</th>
</tr>
</thead>
<tbody>
<tr>
<td>AdditionalInfo</td>
<td>Additional info</td>
</tr>
<tr>
<td>AdditionalInfoNote</td>
<td>This information is not public. It is for your reference only.</td>
</tr>
<tr>
<td>Author</td>
<td>Author</td>
</tr>
<tr>
<td>AuthorInput</td>
<td>Author...</td>
</tr>
<tr>
<td>BackToAllItems</td>
<td>Back to all &lt;
<em>ModuleName</em>&gt;</td>
</tr>
<tr>
<td>Cancel</td>
<td>Cancel</td>
</tr>
<tr>
<td>Category</td>
<td>Category</td>
</tr>
<tr>
<td>ChangeLanguage</td>
<td>Change Language</td>
</tr>
<tr>
<td>Company_Name</td>
<td>Company name</td>
</tr>
<tr>
<td>Company_Url</td>
<td>Company URL</td>
</tr>
<tr>
<td>Content</td>
<td>Text</td>
</tr>
<tr>
<td>ContentEmpty</td>
<td>The text cannot be empty!</td>
</tr>
<tr>
<td>Date</td>
<td>Date</td>
</tr>
<tr>
<td>Description</td>
<td>Description</td>
</tr>
<tr>
<td>DescriptionInput</td>
<td>Description...</td>
</tr>
<tr>
<td>Discount</td>
<td>Discount</td>
</tr>
<tr>
<td>Discount_Code</td>
<td>Discount code</td>
</tr>
<tr>
<td>Edit</td>
<td>Edit</td>
</tr>
<tr>
<td>EditThisItem</td>
<td>Edit this discount</td>
</tr>
<tr>
<td>GenericContentFAQ</td>
<td>Discount FAQ</td>
</tr>
<tr>
<td>History</td>
<td>History</td>
</tr>
<tr>
<td>IsEditingContent</td>
<td>is editing this &lt;<em>ModuleName</em>&gt; now!</td>
</tr>
<tr>
<td>ItemVersions</td>
<td>&lt;<em>ModuleName</em>&gt; Versions</td>
</tr>
<tr>
<td>MandatoryFields</td>
<td>Mandatory fields</td>
</tr>
<tr>
<td>Modifier</td>
<td>Modifier</td>
</tr>
<tr>
<td>Name</td>
<td>Name</td>
</tr>
<tr>
<td>NameEmpty</td>
<td>Name cannot be empty!</td>
</tr>
<tr>
<td>NameInput</td>
<td>Name...</td>
</tr>
<tr>
<td>Or</td>
<td>or</td>
</tr>
<tr>
<td>Product</td>
<td>Product</td>
</tr>
<tr>
<td>Product_Empty</td>
<td>Product name cannot be empty!</td>
</tr>
<tr>
<td>Product_Input</td>
<td>Product...</td>
</tr>
<tr>
<td>Product_Logo_Url</td>
<td>Product Url</td>
</tr>
<tr>
<td>Rollback</td>
<td>Rollback</td>
</tr>
<tr>
<td>Save</td>
<td>Save</td>
</tr>
<tr>
<td>SaveChanges</td>
<td>Save changes</td>
</tr>
<tr>
<td>Tags</td>
<td>Tags</td>
</tr>
<tr>
<td>Version</td>
<td>Version</td>
</tr>
<tr>
<td>VersionDateFormat</td>
<td>{0:dd MMM yyyy, hh:mm}</td>
</tr>
<tr>
<td>View</td>
<td>View</td>
</tr>
</tbody>
</table>
<h2><a name="_Create_you_new"></a>Create the new control templates</h2>
The control templates are used for displaying the generic content on a user-facing page.
<h3>Create the folder structure</h3>
<ul style="margin-top: 0in;" type="disc">
 	<li>Open up Windows Explorer (or within Visual Studio).</li>
 	<li>Navigate to where your website files are.</li>
 	<li>Then navigate to <strong>~/Sitefinity/ ControlTemplates</strong> folder.</li>
 	<li>Select the Generic_Content folder.</li>
 	<li>Copy it</li>
 	<li>Paste it into the~/Sitefinity/ ControlTemplates folder. Windows Explorer will give it a new name.  Rename it to &lt;<em>ModuleName</em>&gt;.</li>
 	<li>Copy the <strong>~/Sitefinity/ControlTemplates/Events/SocialBookmark</strong> folder to ~/Sitefinity/ControlTemplates/&lt;<em>ModuleName</em>&gt; folder. For some reason, this was left out of the Sitefinity Generic_Content folder.</li>
</ul>
Here comes the fun part. Depending on your liking, you can rename some of the files in the ~/Sitefinity/ ControlTemplates/&lt;<em>ModuleName</em>&gt;.  Here is a list of the files that I would rename.
<h4>File List</h4>
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
<td>I think this is a holdover from the original News module.  We will not be using it.</td>
</tr>
<tr>
<td>CategoriesList.ascx</td>
<td>This is the control that will display the categories for your content.</td>
</tr>
<tr>
<td>CommentsList.ascx</td>
<td>This is the control that will display the comments.</td>
</tr>
<tr>
<td>ContentsViewItemList.ascx or &lt;
<em>ModuleName</em>&gt;ItemList.ascx</td>
<td>This is the control that displays the content in a list form (multiple).</td>
</tr>
<tr>
<td>ContentsViewSingleItem.ascx or &lt;
<em>ModuleName</em>&gt;SingleItem.ascx</td>
<td>This is the control that displays the content in a single item (details).</td>
</tr>
<tr>
<td>genericContentCommonLayout.css or &lt;

<em>ModuleName</em>&gt;CommonLayout.css</td>
<td>This file contains the CSS rules for this module.</td>
</tr>
<tr>
<td>socialBookmarkTemplate.xml</td>
<td>This contains the different social bookmarking sites available.</td>
</tr>
<tr>
<td>TagsList.ascx</td>
<td>This control displays all of your tag for the content.</td>
</tr>
</tbody>
</table>
Most of the files do not need to be modified unless you want to.  We will concentrate on the ItemList and SingleItem files.  These files will need to be modified to display your Metadata fields.
<h3><a name="_Add_the_data"></a>Modify the control template files</h3>
<h4>&lt;<em>ModuleName</em>&gt;ItemList.ascx</h4>
As mentioned above in the file list section above, the ItemList control will be used to display the content items in a “repeater” or list view. As a suggestion, I would print out or keep handy the web.config section so you type the Metadata field names.

Let’s get started. If you renamed the genericConentCommonLayout.css you will need to update the FileName attribute of the sfWeb:CssFileLink element to match the new name.  It should look something link this.

<script src="https://gist.github.com/jguadagno/b3775f599453034a1e709571a1012773.js"></script>

The rest of the changes pretty much come in the asp:Repeater control.  You can change the display to look how you wish. If you want to use any of the special fields like Tags or Categories, refer to the ContentView control overview earlier in this document.
<h4>&lt;<em>ModuleName</em>&gt;SingleItem.ascx</h4>
As mentioned above in the file list section above, the SingleItem control will be used to display the content item. As a suggestion, I would print out or keep handy the web.config section so you type the Metadata field names.

Let’s get started. If you renamed the genericConentCommonLayout.css you will need to update the FileName attribute of the sfWeb:CssFileLink element to match the new name.  It should look something link this.

<script src="https://gist.github.com/jguadagno/b3775f599453034a1e709571a1012773.js"></script>

Everything will display within the first div.  You can change the display to look how you wish. If you want to use any of the special fields like Tags or Categories, refer to the ContentView control overview earlier in this document.
<h2>Add the data</h2>
With all of the pages saved you should be able to load the Sitefinity administration section, click on the Generic Content section to start your work.

Click the change group dropdown list and you should see the new content group available. Select the new &lt;<em>ModuleName</em>&gt; item and you will see the ControlPanelList.ascx control displayed to the right.

Click on the “Create a new content item”, the name might be different if you changed the CreateNewItem item in the ControlPanelList.ascx.resx file. You will then be displayed with the ControlPanelInsert.ascx control which will allow you to add the content.
<h2><a name="_Create_the_Sitefinity"></a>Create the Sitefinity page to display the content</h2>
Please refer to the Sitefinity user guide section titled “Working with Web Pages” for details on how to add a page to Sitefinity.  This section will cover the ContentView control specific changes, please review the Sitefinity use guide section “Working with user controls” for more information on adding controls to a page.  In my sample, I created a page called &lt;<em>ModuleName</em>&gt;.aspx and added a ContentView control to the page, which can be found on the left-hand side of the Add Controls toolbox typically in the section named Generic Content.  Once you do this click the Edit hyperlink to set the properties of the ContentView control.
<table class="table table-striped table-bordered">
<thead>
<tr>
<th>Category</th>
<th>Property</th>
<th>Value</th>
</tr>
</thead>
<tbody>
<tr>
<td>Appearance</td>
<td>ItemListTemplatePath</td>
<td>This should point to the ContentViewItemList.ascx file that you modified earlier.

Example:

~/Sitefinity/ControlTemplates/&lt;<em>ModuleName</em>&gt;/ContentViewItemList.ascx</td>
</tr>
<tr>
<td>Appearance</td>
<td>SingleItemListTemplatePath</td>
<td>This should point to the ContentViewSingleItem.ascx file that you modified earlier.

Example:

~/Sitefinity/ControlTemplates/&lt;<em>ModuleName</em>&gt;/ContentViewSingleItem.ascx</td>
</tr>
<tr>
<td>Data</td>
<td>ProviderName</td>
<td>&lt;<em>ModuleName</em>&gt;</td>
</tr>
<tr>
<td>Explicit Links</td>
<td>SingleItemUrl</td>
<td>This should point to the name of the page that the control is on.

~/&lt;<em>ModuleName</em>&gt;.aspx</td>
</tr>
<tr>
<td>Social Bookmarks</td>
<td>SocialBookmarkImageFolder</td>
<td>~/Sitefinity/ControlTemplates/&lt;<em>ModuleName</em>&gt;/SocialBookmark/</td>
</tr>
<tr>
<td>Social Bookmarks</td>
<td>SocialBookmarkTemplate</td>
<td>~/Sitefinity/ControlTemplates/&lt;<em>ModuleName</em>&gt;/socialBookmarkTemplate.xml</td>
</tr>
</tbody>
</table>
All of the other properties you can set to your liking.
<h2><a name="_Summary"></a>Summary</h2>
As you can see, building your own generic content provider using the Sitefinity generic content module is easy.  Follow this guide and you could have your new module like Sponsors, Products, or Books built. This should be everything that you need to get started expanding the generic content module of the Sitefinity product to meet your needs.

If there are any questions or comments, shoot me an email at <a href="mailto:jguadagno@hotmail.com">jguadagno@hotmail.com</a>.

The source can be downloaded at <a href="http://www.josephguadagno.net/documents/NewGenericContentSource.zip">http://www.josephguadagno.net/documents/NewGenericContentSource.zip</a>

This document can be downloaded at <a href="http://www.josephguadagno.net/documents/CreatingANewGenericContentModule.doc">http://www.josephguadagno.net/documents/CreatingANewGenericContentModule.doc</a> <ins cite="mailto:Joseph%20J.%20Guadagno" datetime="2008-08-07T13:49"></ins>

Thanks to Joseph Anderson of Telerik for providing some helpful comments on this document.