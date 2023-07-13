---
title: 'Sitefinity: Random Generic Content Control'
date: 2009-08-12T18:19:45+00:00
permalink: /2009/08/12/sitefinity-random-generic-content-control/
dsq_thread_id:
  - "3612632845"
categories:
  - Articles
tags:
  - Sitefinity
  - Web
---
Download [RandomGCContent](/assets/downloads/RandomGCContent.zip)

![image-right](/assets/images/posts/sponsor_thumb.png "Sponsor Image"){: .align-right}
One of the many features of [Sitefinity](https://www.sitefinity.com "Sitefinity"){:target="_blank"} is the ability to create custom controls to customize the look and feel of your website. The website for the [Southeast Valley .NET User Group](https://www.sevdnug.org "Southeast Valley .NET User Group"){:target="_blank"} contains several custom controls. In the next few weeks, I will post all of the controls here. On to the Random Generic Content Control. The purpose of the control randomly displays items that are based on a Generic  Content provider. I use this control to randomly pick sponsors of the Southeast Valley .NET User Group to display on the home page. Here is a snapshot of the control in use.

### Installing the Control

Installing the control is a three-part process.

The first step is to add the control to Sitefinity.  This can be done one of three ways.  Which way you choose depends on your technical ability. Here is a list of options in order of least technical to most technical.

1. Add the class `RandomGCControl.cs` in the zip file to the `App_Code` folder of your Sitefinity project.
2. Create a Visual Studio class library project, add the `RandomGCControl.cs` class to it. You will need to add the following references to the project; `Telerik.Cms`, `Telerik.Cms.Engine`, `Telerik.Cms.Web.UI`, `Telerik.Framework`, `Telerik.Personalization`, and `Telerik.Web.UI`. Compile the class, then upload it as documented by the Sitefinity article [Adding Controls](https://www.sitefinity.com/help/developer-manual/controls-adding-controls-to-sitefinity.html "Adding controls to Sitefinity")
3. Create a separate class project as outlined in the step above then add a reference to this project to your Sitefinity project.

The next step is let Sitefinity know about the new control. Note: this step is not required if you compiled the control and uploaded it through the Sitefinity interface. To do this you need to modify the web.config file.  The controls are listed in the cms/toolboxControls section. Add the following:

```xml
<add name="Random Generic Content"
  section="SEVDNUG"
  type="SEVDNUG.Web.Sitefinity.WebControls.RandomGCContent, SEVDNUG.Web.Sitefinity.WebControls"
  description="Displays a random generic content items"
/>
```

If you followed the steps, the next you go to edit a page in Sitefinity you should see the Random Generic Content control available in the SEVDNUG group.

### Configuring the Control

The Random Generic Content control has four properties that you need configure.

|Property name|Function|
|--- |--- |
|Item List Template File (Appearance Section)|Controls the overall look of items that appear. This file dictates the display of the generic content.|
|Generic Content Details Url (Appearance section)|This property points to the single page where you want Sitefinity to navigate to when an item is clicked. This is typically the same page that hosts this generic item.|
|Number Of Items (Data section)|Indicates how many generic items to display.|
|Provider Name (Data Section)|Indicates which generic item provider to use.|

### Customizing the Control

To customize the display of the control, you will need to edit the file that you specified in the Item List Template File property of the control.  There is a sample template in the attached file.

```html
<div class="topSponsorsList">
  <h2 class="sf_listTitle">Random Content</h2>
    <h3>
      <asp:Literal ID="GCTitle" runat="server"></asp:Literal>
    </h3>
    <asp:Repeater ID="GCRepeater" runat="server">
      <HeaderTemplate>
        <ul class="sf_simpleList">
      </HeaderTemplate>
      <ItemTemplate>
        <li class="sf_simpleList">
          <asp:Literal ID="Name" runat="server" />
        </li>
      </ItemTemplate>
      <FooterTemplate></ul></FooterTemplate>
    </asp:Repeater>
</div>
```

The control will look for form field names that match the names of the meta keys for that provider and replace them with the value of the meta key.

Here is an example of the sponsor template used to generate the image above.

```html
<asp:Repeater ID="GCRepeater" runat="server"> 
  <HeaderTemplate><ul class="sponsorList"></HeaderTemplate>
  <ItemTemplate>
    <li class="sponsorList">
      <asp:HyperLink ID="fullContent1" runat="server">
        <img src='<asp:Literal ID="Company_Logo_Url" runat="server" />'
          alt= '<asp:Literal ID="Company_Name" runat="server" />'
          width="120" height="50" onError="img2txt(this)" />
      </asp:HyperLink>
    </li>
  </ItemTemplate>
  <FooterTemplate></ul></FooterTemplate>
</asp:Repeater>
<script>
function img2txt(img) {
  txt = img.alt;
  img.parentNode.innerHTML=txt;
}
</script>
```

Hopefully, you will find this control useful.  Look for some more controls and providers soon.