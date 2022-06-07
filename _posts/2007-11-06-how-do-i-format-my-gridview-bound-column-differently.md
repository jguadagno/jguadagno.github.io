---
title: How do I format my GridView bound column differently?
date: 2007-11-06T07:04:33+00:00
permalink: /2007/11/06/how-do-i-format-my-gridview-bound-column-differently/
categories:
  - Articles
---
Replace the _ColumnName_ value with the name of your column. Replace DataFormatString property with the format string of your choosing.  A good reference for .NET string formats is available at [https://john-sheehan.com/blog/index.php/net-cheat-sheets/](https://john-sheehan.com/blog/index.php/net-cheat-sheets/)

```html
<asp:GridView ID="GridView1" runat=“server”>
  <columns>
    <asp:BoundField DataField="ColumnName"
      DataFormatString="{0:M-dd-yyyy}"
      HtmlEncode="false"
      HeaderText="ColumnName" />
  </columns>
</asp:GridView>
```