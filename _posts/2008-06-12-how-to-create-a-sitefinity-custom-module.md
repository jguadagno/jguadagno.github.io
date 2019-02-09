---
id: 821
title: How to create a Sitefinity custom module
date: 2008-06-12T04:56:05+00:00
author: Joseph Guadagno
guid: http://www.josephguadagno.net/post.aspx?id=d99e4a13-6cb7-4462-9b10-11d8d2b2dde1
permalink: /2008/06/12/how-to-create-a-sitefinity-custom-module/
dsq_thread_id:
  - "3615253834"
categories:
  - Articles
---
<!-- TODO: Clean up HTML -->

<p>&nbsp;Download this document: <a href="http://sevdnug.org/Libraries/Sitefinity_Modules/SiteFinity%20Custom%20Module%20Creation.sflb" target="_blank">How to create a Sitefinity custom module</a></p>
<p>Download the source: <a href="http://sevdnug.org/Libraries/Sitefinity_Modules/SEVDNUG.Contacts.sflb" target="_blank">SEVDNUG.Contact.zip</a></p>

<!--[if !mso]>
<style>
v\:* {behavior:url(#default#VML);}
o\:* {behavior:url(#default#VML);}
w\:* {behavior:url(#default#VML);}
.shape {behavior:url(#default#VML);}
</style>
<![endif]-->
<p>
<link rel="themeData" href="file:///C:\DOCUME~1\JOSEPH~1.GUA\LOCALS~1\Temp\msohtmlclip1\01\clip_themedata.thmx" />
<link rel="colorSchemeMapping" href="file:///C:\DOCUME~1\JOSEPH~1.GUA\LOCALS~1\Temp\msohtmlclip1\01\clip_colorschememapping.xml" /></p>
<!--[if gte mso 9]><xml>
<w:WordDocument>
<w:View>Normal</w:View>
<w:Zoom>0</w:Zoom>
<w:TrackMoves />
<w:TrackFormatting />
<w:PunctuationKerning />
<w:ValidateAgainstSchemas />
<w:SaveIfXMLInvalid>false</w:SaveIfXMLInvalid>
<w:IgnoreMixedContent>false</w:IgnoreMixedContent>
<w:AlwaysShowPlaceholderText>false</w:AlwaysShowPlaceholderText>
<w:DoNotPromoteQF />
<w:LidThemeOther>EN-US</w:LidThemeOther>
<w:LidThemeAsian>X-NONE</w:LidThemeAsian>
<w:LidThemeComplexScript>X-NONE</w:LidThemeComplexScript>
<w:Compatibility>
<w:BreakWrappedTables />
<w:SnapToGridInCell />
<w:WrapTextWithPunct />
<w:UseAsianBreakRules />
<w:DontGrowAutofit />
<w:SplitPgBreakAndParaMark />
<w:DontVertAlignCellWithSp />
<w:DontBreakConstrainedForcedTables />
<w:DontVertAlignInTxbx />
<w:Word11KerningPairs />
<w:CachedColBalance />
</w:Compatibility>
<w:BrowserLevel>MicrosoftInternetExplorer4</w:BrowserLevel>
<m:mathPr>
<m:mathFont m:val="Cambria Math" />
<m:brkBin m:val="before" />
<m:brkBinSub m:val="&#45;-" />
<m:smallFrac m:val="off" />
<m:dispDef />
<m:lMargin m:val="0" />
<m:rMargin m:val="0" />
<m:defJc m:val="centerGroup" />
<m:wrapIndent m:val="1440" />
<m:intLim m:val="subSup" />
<m:naryLim m:val="undOvr" />
</m:mathPr></w:WordDocument>
</xml><![endif]--><!--[if gte mso 9]><xml>
<w:LatentStyles DefLockedState="false" DefUnhideWhenUsed="true"
DefSemiHidden="true" DefQFormat="false" DefPriority="99"
LatentStyleCount="267">
<w:LsdException Locked="false" Priority="0" SemiHidden="false"
UnhideWhenUsed="false" QFormat="true" Name="Normal" />
<w:LsdException Locked="false" Priority="0" SemiHidden="false"
UnhideWhenUsed="false" QFormat="true" Name="heading 1" />
<w:LsdException Locked="false" Priority="0" QFormat="true" Name="heading 2" />
<w:LsdException Locked="false" Priority="0" QFormat="true" Name="heading 3" />
<w:LsdException Locked="false" Priority="0" QFormat="true" Name="heading 4" />
<w:LsdException Locked="false" Priority="9" QFormat="true" Name="heading 5" />
<w:LsdException Locked="false" Priority="9" QFormat="true" Name="heading 6" />
<w:LsdException Locked="false" Priority="9" QFormat="true" Name="heading 7" />
<w:LsdException Locked="false" Priority="9" QFormat="true" Name="heading 8" />
<w:LsdException Locked="false" Priority="9" QFormat="true" Name="heading 9" />
<w:LsdException Locked="false" Priority="39" Name="toc 1" />
<w:LsdException Locked="false" Priority="39" Name="toc 2" />
<w:LsdException Locked="false" Priority="39" Name="toc 3" />
<w:LsdException Locked="false" Priority="39" Name="toc 4" />
<w:LsdException Locked="false" Priority="39" Name="toc 5" />
<w:LsdException Locked="false" Priority="39" Name="toc 6" />
<w:LsdException Locked="false" Priority="39" Name="toc 7" />
<w:LsdException Locked="false" Priority="39" Name="toc 8" />
<w:LsdException Locked="false" Priority="39" Name="toc 9" />
<w:LsdException Locked="false" Priority="0" Name="header" />
<w:LsdException Locked="false" Priority="0" Name="footer" />
<w:LsdException Locked="false" Priority="35" QFormat="true" Name="caption" />
<w:LsdException Locked="false" Priority="0" Name="endnote reference" />
<w:LsdException Locked="false" Priority="0" Name="endnote text" />
<w:LsdException Locked="false" Priority="10" SemiHidden="false"
UnhideWhenUsed="false" QFormat="true" Name="Title" />
<w:LsdException Locked="false" Priority="1" Name="Default Paragraph Font" />
<w:LsdException Locked="false" Priority="11" SemiHidden="false"
UnhideWhenUsed="false" QFormat="true" Name="Subtitle" />
<w:LsdException Locked="false" Priority="22" SemiHidden="false"
UnhideWhenUsed="false" QFormat="true" Name="Strong" />
<w:LsdException Locked="false" Priority="20" SemiHidden="false"
UnhideWhenUsed="false" QFormat="true" Name="Emphasis" />
<w:LsdException Locked="false" Priority="59" SemiHidden="false"
UnhideWhenUsed="false" Name="Table Grid" />
<w:LsdException Locked="false" UnhideWhenUsed="false" Name="Placeholder Text" />
<w:LsdException Locked="false" Priority="1" SemiHidden="false"
UnhideWhenUsed="false" QFormat="true" Name="No Spacing" />
<w:LsdException Locked="false" Priority="60" SemiHidden="false"
UnhideWhenUsed="false" Name="Light Shading" />
<w:LsdException Locked="false" Priority="61" SemiHidden="false"
UnhideWhenUsed="false" Name="Light List" />
<w:LsdException Locked="false" Priority="62" SemiHidden="false"
UnhideWhenUsed="false" Name="Light Grid" />
<w:LsdException Locked="false" Priority="63" SemiHidden="false"
UnhideWhenUsed="false" Name="Medium Shading 1" />
<w:LsdException Locked="false" Priority="64" SemiHidden="false"
UnhideWhenUsed="false" Name="Medium Shading 2" />
<w:LsdException Locked="false" Priority="65" SemiHidden="false"
UnhideWhenUsed="false" Name="Medium List 1" />
<w:LsdException Locked="false" Priority="66" SemiHidden="false"
UnhideWhenUsed="false" Name="Medium List 2" />
<w:LsdException Locked="false" Priority="67" SemiHidden="false"
UnhideWhenUsed="false" Name="Medium Grid 1" />
<w:LsdException Locked="false" Priority="68" SemiHidden="false"
UnhideWhenUsed="false" Name="Medium Grid 2" />
<w:LsdException Locked="false" Priority="69" SemiHidden="false"
UnhideWhenUsed="false" Name="Medium Grid 3" />
<w:LsdException Locked="false" Priority="70" SemiHidden="false"
UnhideWhenUsed="false" Name="Dark List" />
<w:LsdException Locked="false" Priority="71" SemiHidden="false"
UnhideWhenUsed="false" Name="Colorful Shading" />
<w:LsdException Locked="false" Priority="72" SemiHidden="false"
UnhideWhenUsed="false" Name="Colorful List" />
<w:LsdException Locked="false" Priority="73" SemiHidden="false"
UnhideWhenUsed="false" Name="Colorful Grid" />
<w:LsdException Locked="false" Priority="60" SemiHidden="false"
UnhideWhenUsed="false" Name="Light Shading Accent 1" />
<w:LsdException Locked="false" Priority="61" SemiHidden="false"
UnhideWhenUsed="false" Name="Light List Accent 1" />
<w:LsdException Locked="false" Priority="62" SemiHidden="false"
UnhideWhenUsed="false" Name="Light Grid Accent 1" />
<w:LsdException Locked="false" Priority="63" SemiHidden="false"
UnhideWhenUsed="false" Name="Medium Shading 1 Accent 1" />
<w:LsdException Locked="false" Priority="64" SemiHidden="false"
UnhideWhenUsed="false" Name="Medium Shading 2 Accent 1" />
<w:LsdException Locked="false" Priority="65" SemiHidden="false"
UnhideWhenUsed="false" Name="Medium List 1 Accent 1" />
<w:LsdException Locked="false" UnhideWhenUsed="false" Name="Revision" />
<w:LsdException Locked="false" Priority="0" SemiHidden="false"
UnhideWhenUsed="false" QFormat="true" Name="List Paragraph" />
<w:LsdException Locked="false" Priority="29" SemiHidden="false"
UnhideWhenUsed="false" QFormat="true" Name="Quote" />
<w:LsdException Locked="false" Priority="30" SemiHidden="false"
UnhideWhenUsed="false" QFormat="true" Name="Intense Quote" />
<w:LsdException Locked="false" Priority="66" SemiHidden="false"
UnhideWhenUsed="false" Name="Medium List 2 Accent 1" />
<w:LsdException Locked="false" Priority="67" SemiHidden="false"
UnhideWhenUsed="false" Name="Medium Grid 1 Accent 1" />
<w:LsdException Locked="false" Priority="68" SemiHidden="false"
UnhideWhenUsed="false" Name="Medium Grid 2 Accent 1" />
<w:LsdException Locked="false" Priority="69" SemiHidden="false"
UnhideWhenUsed="false" Name="Medium Grid 3 Accent 1" />
<w:LsdException Locked="false" Priority="70" SemiHidden="false"
UnhideWhenUsed="false" Name="Dark List Accent 1" />
<w:LsdException Locked="false" Priority="71" SemiHidden="false"
UnhideWhenUsed="false" Name="Colorful Shading Accent 1" />
<w:LsdException Locked="false" Priority="72" SemiHidden="false"
UnhideWhenUsed="false" Name="Colorful List Accent 1" />
<w:LsdException Locked="false" Priority="73" SemiHidden="false"
UnhideWhenUsed="false" Name="Colorful Grid Accent 1" />
<w:LsdException Locked="false" Priority="60" SemiHidden="false"
UnhideWhenUsed="false" Name="Light Shading Accent 2" />
<w:LsdException Locked="false" Priority="61" SemiHidden="false"
UnhideWhenUsed="false" Name="Light List Accent 2" />
<w:LsdException Locked="false" Priority="62" SemiHidden="false"
UnhideWhenUsed="false" Name="Light Grid Accent 2" />
<w:LsdException Locked="false" Priority="63" SemiHidden="false"
UnhideWhenUsed="false" Name="Medium Shading 1 Accent 2" />
<w:LsdException Locked="false" Priority="64" SemiHidden="false"
UnhideWhenUsed="false" Name="Medium Shading 2 Accent 2" />
<w:LsdException Locked="false" Priority="65" SemiHidden="false"
UnhideWhenUsed="false" Name="Medium List 1 Accent 2" />
<w:LsdException Locked="false" Priority="66" SemiHidden="false"
UnhideWhenUsed="false" Name="Medium List 2 Accent 2" />
<w:LsdException Locked="false" Priority="67" SemiHidden="false"
UnhideWhenUsed="false" Name="Medium Grid 1 Accent 2" />
<w:LsdException Locked="false" Priority="68" SemiHidden="false"
UnhideWhenUsed="false" Name="Medium Grid 2 Accent 2" />
<w:LsdException Locked="false" Priority="69" SemiHidden="false"
UnhideWhenUsed="false" Name="Medium Grid 3 Accent 2" />
<w:LsdException Locked="false" Priority="70" SemiHidden="false"
UnhideWhenUsed="false" Name="Dark List Accent 2" />
<w:LsdException Locked="false" Priority="71" SemiHidden="false"
UnhideWhenUsed="false" Name="Colorful Shading Accent 2" />
<w:LsdException Locked="false" Priority="72" SemiHidden="false"
UnhideWhenUsed="false" Name="Colorful List Accent 2" />
<w:LsdException Locked="false" Priority="73" SemiHidden="false"
UnhideWhenUsed="false" Name="Colorful Grid Accent 2" />
<w:LsdException Locked="false" Priority="60" SemiHidden="false"
UnhideWhenUsed="false" Name="Light Shading Accent 3" />
<w:LsdException Locked="false" Priority="61" SemiHidden="false"
UnhideWhenUsed="false" Name="Light List Accent 3" />
<w:LsdException Locked="false" Priority="62" SemiHidden="false"
UnhideWhenUsed="false" Name="Light Grid Accent 3" />
<w:LsdException Locked="false" Priority="63" SemiHidden="false"
UnhideWhenUsed="false" Name="Medium Shading 1 Accent 3" />
<w:LsdException Locked="false" Priority="64" SemiHidden="false"
UnhideWhenUsed="false" Name="Medium Shading 2 Accent 3" />
<w:LsdException Locked="false" Priority="65" SemiHidden="false"
UnhideWhenUsed="false" Name="Medium List 1 Accent 3" />
<w:LsdException Locked="false" Priority="66" SemiHidden="false"
UnhideWhenUsed="false" Name="Medium List 2 Accent 3" />
<w:LsdException Locked="false" Priority="67" SemiHidden="false"
UnhideWhenUsed="false" Name="Medium Grid 1 Accent 3" />
<w:LsdException Locked="false" Priority="68" SemiHidden="false"
UnhideWhenUsed="false" Name="Medium Grid 2 Accent 3" />
<w:LsdException Locked="false" Priority="69" SemiHidden="false"
UnhideWhenUsed="false" Name="Medium Grid 3 Accent 3" />
<w:LsdException Locked="false" Priority="70" SemiHidden="false"
UnhideWhenUsed="false" Name="Dark List Accent 3" />
<w:LsdException Locked="false" Priority="71" SemiHidden="false"
UnhideWhenUsed="false" Name="Colorful Shading Accent 3" />
<w:LsdException Locked="false" Priority="72" SemiHidden="false"
UnhideWhenUsed="false" Name="Colorful List Accent 3" />
<w:LsdException Locked="false" Priority="73" SemiHidden="false"
UnhideWhenUsed="false" Name="Colorful Grid Accent 3" />
<w:LsdException Locked="false" Priority="60" SemiHidden="false"
UnhideWhenUsed="false" Name="Light Shading Accent 4" />
<w:LsdException Locked="false" Priority="61" SemiHidden="false"
UnhideWhenUsed="false" Name="Light List Accent 4" />
<w:LsdException Locked="false" Priority="62" SemiHidden="false"
UnhideWhenUsed="false" Name="Light Grid Accent 4" />
<w:LsdException Locked="false" Priority="63" SemiHidden="false"
UnhideWhenUsed="false" Name="Medium Shading 1 Accent 4" />
<w:LsdException Locked="false" Priority="64" SemiHidden="false"
UnhideWhenUsed="false" Name="Medium Shading 2 Accent 4" />
<w:LsdException Locked="false" Priority="65" SemiHidden="false"
UnhideWhenUsed="false" Name="Medium List 1 Accent 4" />
<w:LsdException Locked="false" Priority="66" SemiHidden="false"
UnhideWhenUsed="false" Name="Medium List 2 Accent 4" />
<w:LsdException Locked="false" Priority="67" SemiHidden="false"
UnhideWhenUsed="false" Name="Medium Grid 1 Accent 4" />
<w:LsdException Locked="false" Priority="68" SemiHidden="false"
UnhideWhenUsed="false" Name="Medium Grid 2 Accent 4" />
<w:LsdException Locked="false" Priority="69" SemiHidden="false"
UnhideWhenUsed="false" Name="Medium Grid 3 Accent 4" />
<w:LsdException Locked="false" Priority="70" SemiHidden="false"
UnhideWhenUsed="false" Name="Dark List Accent 4" />
<w:LsdException Locked="false" Priority="71" SemiHidden="false"
UnhideWhenUsed="false" Name="Colorful Shading Accent 4" />
<w:LsdException Locked="false" Priority="72" SemiHidden="false"
UnhideWhenUsed="false" Name="Colorful List Accent 4" />
<w:LsdException Locked="false" Priority="73" SemiHidden="false"
UnhideWhenUsed="false" Name="Colorful Grid Accent 4" />
<w:LsdException Locked="false" Priority="60" SemiHidden="false"
UnhideWhenUsed="false" Name="Light Shading Accent 5" />
<w:LsdException Locked="false" Priority="61" SemiHidden="false"
UnhideWhenUsed="false" Name="Light List Accent 5" />
<w:LsdException Locked="false" Priority="62" SemiHidden="false"
UnhideWhenUsed="false" Name="Light Grid Accent 5" />
<w:LsdException Locked="false" Priority="63" SemiHidden="false"
UnhideWhenUsed="false" Name="Medium Shading 1 Accent 5" />
<w:LsdException Locked="false" Priority="64" SemiHidden="false"
UnhideWhenUsed="false" Name="Medium Shading 2 Accent 5" />
<w:LsdException Locked="false" Priority="65" SemiHidden="false"
UnhideWhenUsed="false" Name="Medium List 1 Accent 5" />
<w:LsdException Locked="false" Priority="66" SemiHidden="false"
UnhideWhenUsed="false" Name="Medium List 2 Accent 5" />
<w:LsdException Locked="false" Priority="67" SemiHidden="false"
UnhideWhenUsed="false" Name="Medium Grid 1 Accent 5" />
<w:LsdException Locked="false" Priority="68" SemiHidden="false"
UnhideWhenUsed="false" Name="Medium Grid 2 Accent 5" />
<w:LsdException Locked="false" Priority="69" SemiHidden="false"
UnhideWhenUsed="false" Name="Medium Grid 3 Accent 5" />
<w:LsdException Locked="false" Priority="70" SemiHidden="false"
UnhideWhenUsed="false" Name="Dark List Accent 5" />
<w:LsdException Locked="false" Priority="71" SemiHidden="false"
UnhideWhenUsed="false" Name="Colorful Shading Accent 5" />
<w:LsdException Locked="false" Priority="72" SemiHidden="false"
UnhideWhenUsed="false" Name="Colorful List Accent 5" />
<w:LsdException Locked="false" Priority="73" SemiHidden="false"
UnhideWhenUsed="false" Name="Colorful Grid Accent 5" />
<w:LsdException Locked="false" Priority="60" SemiHidden="false"
UnhideWhenUsed="false" Name="Light Shading Accent 6" />
<w:LsdException Locked="false" Priority="61" SemiHidden="false"
UnhideWhenUsed="false" Name="Light List Accent 6" />
<w:LsdException Locked="false" Priority="62" SemiHidden="false"
UnhideWhenUsed="false" Name="Light Grid Accent 6" />
<w:LsdException Locked="false" Priority="63" SemiHidden="false"
UnhideWhenUsed="false" Name="Medium Shading 1 Accent 6" />
<w:LsdException Locked="false" Priority="64" SemiHidden="false"
UnhideWhenUsed="false" Name="Medium Shading 2 Accent 6" />
<w:LsdException Locked="false" Priority="65" SemiHidden="false"
UnhideWhenUsed="false" Name="Medium List 1 Accent 6" />
<w:LsdException Locked="false" Priority="66" SemiHidden="false"
UnhideWhenUsed="false" Name="Medium List 2 Accent 6" />
<w:LsdException Locked="false" Priority="67" SemiHidden="false"
UnhideWhenUsed="false" Name="Medium Grid 1 Accent 6" />
<w:LsdException Locked="false" Priority="68" SemiHidden="false"
UnhideWhenUsed="false" Name="Medium Grid 2 Accent 6" />
<w:LsdException Locked="false" Priority="69" SemiHidden="false"
UnhideWhenUsed="false" Name="Medium Grid 3 Accent 6" />
<w:LsdException Locked="false" Priority="70" SemiHidden="false"
UnhideWhenUsed="false" Name="Dark List Accent 6" />
<w:LsdException Locked="false" Priority="71" SemiHidden="false"
UnhideWhenUsed="false" Name="Colorful Shading Accent 6" />
<w:LsdException Locked="false" Priority="72" SemiHidden="false"
UnhideWhenUsed="false" Name="Colorful List Accent 6" />
<w:LsdException Locked="false" Priority="73" SemiHidden="false"
UnhideWhenUsed="false" Name="Colorful Grid Accent 6" />
<w:LsdException Locked="false" Priority="19" SemiHidden="false"
UnhideWhenUsed="false" QFormat="true" Name="Subtle Emphasis" />
<w:LsdException Locked="false" Priority="21" SemiHidden="false"
UnhideWhenUsed="false" QFormat="true" Name="Intense Emphasis" />
<w:LsdException Locked="false" Priority="31" SemiHidden="false"
UnhideWhenUsed="false" QFormat="true" Name="Subtle Reference" />
<w:LsdException Locked="false" Priority="32" SemiHidden="false"
UnhideWhenUsed="false" QFormat="true" Name="Intense Reference" />
<w:LsdException Locked="false" Priority="33" SemiHidden="false"
UnhideWhenUsed="false" QFormat="true" Name="Book Title" />
<w:LsdException Locked="false" Priority="37" Name="Bibliography" />
<w:LsdException Locked="false" Priority="39" QFormat="true" Name="TOC Heading" />
</w:LatentStyles>
</xml><![endif]-->
<p><style type="text/css">
<!--
 /* Font Definitions */
 @font-face
	{font-family:Wingdings;
	panose-1:5 0 0 0 0 0 0 0 0 0;
	mso-font-charset:2;
	mso-generic-font-family:auto;
	mso-font-pitch:variable;
	mso-font-signature:0 268435456 0 0 -2147483648 0;}
@font-face
	{font-family:"Cambria Math";
	panose-1:2 4 5 3 5 4 6 3 2 4;
	mso-font-charset:0;
	mso-generic-font-family:roman;
	mso-font-pitch:variable;
	mso-font-signature:-1610611985 1107304683 0 0 159 0;}
@font-face
	{font-family:Cambria;
	panose-1:2 4 5 3 5 4 6 3 2 4;
	mso-font-charset:0;
	mso-generic-font-family:roman;
	mso-font-pitch:variable;
	mso-font-signature:-1610611985 1073741899 0 0 159 0;}
@font-face
	{font-family:Calibri;
	panose-1:2 15 5 2 2 2 4 3 2 4;
	mso-font-charset:0;
	mso-generic-font-family:swiss;
	mso-font-pitch:variable;
	mso-font-signature:-1610611985 1073750139 0 0 159 0;}
 /* Style Definitions */
 p.MsoNormal, li.MsoNormal, div.MsoNormal
	{mso-style-unhide:no;
	mso-style-qformat:yes;
	mso-style-parent:"";
	margin-top:0in;
	margin-right:0in;
	margin-bottom:10.0pt;
	margin-left:0in;
	line-height:115%;
	mso-pagination:widow-orphan;
	font-size:11.0pt;
	font-family:"Calibri","sans-serif";
	mso-fareast-font-family:Calibri;
	mso-bidi-font-family:"Times New Roman";}
h1
	{mso-style-unhide:no;
	mso-style-qformat:yes;
	mso-style-link:"Heading 1 Char";
	mso-style-next:Normal;
	margin-top:12.0pt;
	margin-right:0in;
	margin-bottom:3.0pt;
	margin-left:0in;
	line-height:115%;
	mso-pagination:widow-orphan;
	page-break-after:avoid;
	mso-outline-level:1;
	font-size:16.0pt;
	font-family:"Cambria","serif";
	mso-fareast-font-family:"Times New Roman";
	mso-font-kerning:16.0pt;}
h2
	{mso-style-unhide:no;
	mso-style-qformat:yes;
	mso-style-link:"Heading 2 Char";
	mso-style-next:Normal;
	margin-top:12.0pt;
	margin-right:0in;
	margin-bottom:3.0pt;
	margin-left:0in;
	line-height:115%;
	mso-pagination:widow-orphan;
	page-break-after:avoid;
	mso-outline-level:2;
	font-size:14.0pt;
	font-family:"Cambria","serif";
	mso-fareast-font-family:"Times New Roman";
	font-style:italic;}
h3
	{mso-style-unhide:no;
	mso-style-qformat:yes;
	mso-style-link:"Heading 3 Char";
	mso-style-next:Normal;
	margin-top:12.0pt;
	margin-right:0in;
	margin-bottom:3.0pt;
	margin-left:0in;
	line-height:115%;
	mso-pagination:widow-orphan;
	page-break-after:avoid;
	mso-outline-level:3;
	font-size:13.0pt;
	font-family:"Cambria","serif";
	mso-fareast-font-family:"Times New Roman";}
h4
	{mso-style-unhide:no;
	mso-style-qformat:yes;
	mso-style-link:"Heading 4 Char";
	mso-style-next:Normal;
	margin-top:12.0pt;
	margin-right:0in;
	margin-bottom:3.0pt;
	margin-left:0in;
	line-height:115%;
	mso-pagination:widow-orphan;
	page-break-after:avoid;
	mso-outline-level:4;
	font-size:14.0pt;
	font-family:"Calibri","sans-serif";
	mso-fareast-font-family:"Times New Roman";}
p.MsoHeader, li.MsoHeader, div.MsoHeader
	{mso-style-noshow:yes;
	mso-style-link:"Header Char";
	margin-top:0in;
	margin-right:0in;
	margin-bottom:10.0pt;
	margin-left:0in;
	line-height:115%;
	mso-pagination:widow-orphan;
	tab-stops:center 3.25in right 6.5in;
	font-size:11.0pt;
	font-family:"Calibri","sans-serif";
	mso-fareast-font-family:Calibri;
	mso-bidi-font-family:"Times New Roman";}
p.MsoFooter, li.MsoFooter, div.MsoFooter
	{mso-style-noshow:yes;
	mso-style-link:"Footer Char";
	margin-top:0in;
	margin-right:0in;
	margin-bottom:10.0pt;
	margin-left:0in;
	line-height:115%;
	mso-pagination:widow-orphan;
	tab-stops:center 3.25in right 6.5in;
	font-size:11.0pt;
	font-family:"Calibri","sans-serif";
	mso-fareast-font-family:Calibri;
	mso-bidi-font-family:"Times New Roman";}
span.MsoEndnoteReference
	{mso-style-noshow:yes;
	vertical-align:super;}
p.MsoEndnoteText, li.MsoEndnoteText, div.MsoEndnoteText
	{mso-style-noshow:yes;
	mso-style-link:"Endnote Text Char";
	margin-top:0in;
	margin-right:0in;
	margin-bottom:10.0pt;
	margin-left:0in;
	line-height:115%;
	mso-pagination:widow-orphan;
	font-size:10.0pt;
	font-family:"Calibri","sans-serif";
	mso-fareast-font-family:Calibri;
	mso-bidi-font-family:"Times New Roman";}
a:link, span.MsoHyperlink
	{mso-style-priority:99;
	color:blue;
	text-decoration:underline;
	text-underline:single;}
a:visited, span.MsoHyperlinkFollowed
	{mso-style-noshow:yes;
	mso-style-priority:99;
	color:purple;
	mso-themecolor:followedhyperlink;
	text-decoration:underline;
	text-underline:single;}
p.MsoListParagraph, li.MsoListParagraph, div.MsoListParagraph
	{mso-style-unhide:no;
	mso-style-qformat:yes;
	margin-top:0in;
	margin-right:0in;
	margin-bottom:10.0pt;
	margin-left:.5in;
	mso-add-space:auto;
	line-height:115%;
	mso-pagination:widow-orphan;
	font-size:11.0pt;
	font-family:"Calibri","sans-serif";
	mso-fareast-font-family:Calibri;
	mso-bidi-font-family:"Times New Roman";}
p.MsoListParagraphCxSpFirst, li.MsoListParagraphCxSpFirst, div.MsoListParagraphCxSpFirst
	{mso-style-unhide:no;
	mso-style-qformat:yes;
	mso-style-type:export-only;
	margin-top:0in;
	margin-right:0in;
	margin-bottom:0in;
	margin-left:.5in;
	margin-bottom:.0001pt;
	mso-add-space:auto;
	line-height:115%;
	mso-pagination:widow-orphan;
	font-size:11.0pt;
	font-family:"Calibri","sans-serif";
	mso-fareast-font-family:Calibri;
	mso-bidi-font-family:"Times New Roman";}
p.MsoListParagraphCxSpMiddle, li.MsoListParagraphCxSpMiddle, div.MsoListParagraphCxSpMiddle
	{mso-style-unhide:no;
	mso-style-qformat:yes;
	mso-style-type:export-only;
	margin-top:0in;
	margin-right:0in;
	margin-bottom:0in;
	margin-left:.5in;
	margin-bottom:.0001pt;
	mso-add-space:auto;
	line-height:115%;
	mso-pagination:widow-orphan;
	font-size:11.0pt;
	font-family:"Calibri","sans-serif";
	mso-fareast-font-family:Calibri;
	mso-bidi-font-family:"Times New Roman";}
p.MsoListParagraphCxSpLast, li.MsoListParagraphCxSpLast, div.MsoListParagraphCxSpLast
	{mso-style-unhide:no;
	mso-style-qformat:yes;
	mso-style-type:export-only;
	margin-top:0in;
	margin-right:0in;
	margin-bottom:10.0pt;
	margin-left:.5in;
	mso-add-space:auto;
	line-height:115%;
	mso-pagination:widow-orphan;
	font-size:11.0pt;
	font-family:"Calibri","sans-serif";
	mso-fareast-font-family:Calibri;
	mso-bidi-font-family:"Times New Roman";}
span.Heading1Char
	{mso-style-name:"Heading 1 Char";
	mso-style-unhide:no;
	mso-style-locked:yes;
	mso-style-link:"Heading 1";
	mso-ansi-font-size:16.0pt;
	mso-bidi-font-size:16.0pt;
	font-family:"Cambria","serif";
	mso-ascii-font-family:Cambria;
	mso-fareast-font-family:"Times New Roman";
	mso-hansi-font-family:Cambria;
	mso-font-kerning:16.0pt;
	font-weight:bold;}
span.Heading2Char
	{mso-style-name:"Heading 2 Char";
	mso-style-unhide:no;
	mso-style-locked:yes;
	mso-style-link:"Heading 2";
	mso-ansi-font-size:14.0pt;
	mso-bidi-font-size:14.0pt;
	font-family:"Cambria","serif";
	mso-ascii-font-family:Cambria;
	mso-fareast-font-family:"Times New Roman";
	mso-hansi-font-family:Cambria;
	font-weight:bold;
	font-style:italic;}
span.Heading3Char
	{mso-style-name:"Heading 3 Char";
	mso-style-unhide:no;
	mso-style-locked:yes;
	mso-style-link:"Heading 3";
	mso-ansi-font-size:13.0pt;
	mso-bidi-font-size:13.0pt;
	font-family:"Cambria","serif";
	mso-ascii-font-family:Cambria;
	mso-fareast-font-family:"Times New Roman";
	mso-hansi-font-family:Cambria;
	font-weight:bold;}
span.Heading4Char
	{mso-style-name:"Heading 4 Char";
	mso-style-unhide:no;
	mso-style-locked:yes;
	mso-style-link:"Heading 4";
	mso-ansi-font-size:14.0pt;
	mso-bidi-font-size:14.0pt;
	font-family:"Times New Roman","serif";
	mso-fareast-font-family:"Times New Roman";
	font-weight:bold;}
span.EndnoteTextChar
	{mso-style-name:"Endnote Text Char";
	mso-style-noshow:yes;
	mso-style-unhide:no;
	mso-style-locked:yes;
	mso-style-link:"Endnote Text";}
span.HeaderChar
	{mso-style-name:"Header Char";
	mso-style-noshow:yes;
	mso-style-unhide:no;
	mso-style-locked:yes;
	mso-style-link:Header;
	mso-ansi-font-size:11.0pt;
	mso-bidi-font-size:11.0pt;}
span.FooterChar
	{mso-style-name:"Footer Char";
	mso-style-noshow:yes;
	mso-style-unhide:no;
	mso-style-locked:yes;
	mso-style-link:Footer;
	mso-ansi-font-size:11.0pt;
	mso-bidi-font-size:11.0pt;}
.MsoChpDefault
	{mso-style-type:export-only;
	mso-default-props:yes;
	font-size:10.0pt;
	mso-ansi-font-size:10.0pt;
	mso-bidi-font-size:10.0pt;
	mso-ascii-font-family:Calibri;
	mso-fareast-font-family:Calibri;
	mso-hansi-font-family:Calibri;}
 /* Page Definitions */
 @page
	{mso-footnote-separator:url("file:///C:/DOCUME~1/JOSEPH~1.GUA/LOCALS~1/Temp/msohtmlclip1/01/clip_header.htm") fs;
	mso-footnote-continuation-separator:url("file:///C:/DOCUME~1/JOSEPH~1.GUA/LOCALS~1/Temp/msohtmlclip1/01/clip_header.htm") fcs;
	mso-endnote-separator:url("file:///C:/DOCUME~1/JOSEPH~1.GUA/LOCALS~1/Temp/msohtmlclip1/01/clip_header.htm") es;
	mso-endnote-continuation-separator:url("file:///C:/DOCUME~1/JOSEPH~1.GUA/LOCALS~1/Temp/msohtmlclip1/01/clip_header.htm") ecs;}
@page Section1
	{size:8.5in 11.0in;
	margin:1.0in 1.0in 1.0in 1.0in;
	mso-header-margin:.5in;
	mso-footer-margin:.5in;
	mso-paper-source:0;}
div.Section1
	{page:Section1;}
 /* List Definitions */
 @list l0
	{mso-list-id:36899437;
	mso-list-type:hybrid;
	mso-list-template-ids:1360801336 67698689 67698691 67698693 67698689 67698691 67698693 67698689 67698691 67698693;}
@list l0:level1
	{mso-level-number-format:bullet;
	mso-level-text:;
	mso-level-tab-stop:none;
	mso-level-number-position:left;
	text-indent:-.25in;
	font-family:Symbol;}
@list l1
	{mso-list-id:46148716;
	mso-list-type:hybrid;
	mso-list-template-ids:1239155510 67698689 67698691 67698693 67698689 67698691 67698693 67698689 67698691 67698693;}
@list l1:level1
	{mso-level-number-format:bullet;
	mso-level-text:;
	mso-level-tab-stop:none;
	mso-level-number-position:left;
	text-indent:-.25in;
	font-family:Symbol;}
@list l1:level2
	{mso-level-number-format:bullet;
	mso-level-text:o;
	mso-level-tab-stop:none;
	mso-level-number-position:left;
	text-indent:-.25in;
	font-family:"Courier New";}
@list l2
	{mso-list-id:376201284;
	mso-list-type:hybrid;
	mso-list-template-ids:-1325109222 67698689 67698691 67698693 67698689 67698691 67698693 67698689 67698691 67698693;}
@list l2:level1
	{mso-level-number-format:bullet;
	mso-level-text:;
	mso-level-tab-stop:none;
	mso-level-number-position:left;
	text-indent:-.25in;
	font-family:Symbol;}
@list l3
	{mso-list-id:542521604;
	mso-list-type:hybrid;
	mso-list-template-ids:653280118 67698689 67698691 67698693 67698689 67698691 67698693 67698689 67698691 67698693;}
@list l3:level1
	{mso-level-number-format:bullet;
	mso-level-text:;
	mso-level-tab-stop:none;
	mso-level-number-position:left;
	text-indent:-.25in;
	font-family:Symbol;}
@list l3:level2
	{mso-level-number-format:bullet;
	mso-level-text:o;
	mso-level-tab-stop:none;
	mso-level-number-position:left;
	text-indent:-.25in;
	font-family:"Courier New";}
@list l3:level3
	{mso-level-number-format:bullet;
	mso-level-text:;
	mso-level-tab-stop:none;
	mso-level-number-position:left;
	text-indent:-.25in;
	font-family:Wingdings;}
@list l3:level4
	{mso-level-number-format:bullet;
	mso-level-text:;
	mso-level-tab-stop:none;
	mso-level-number-position:left;
	text-indent:-.25in;
	font-family:Symbol;}
@list l3:level5
	{mso-level-number-format:bullet;
	mso-level-text:o;
	mso-level-tab-stop:none;
	mso-level-number-position:left;
	text-indent:-.25in;
	font-family:"Courier New";}
@list l3:level6
	{mso-level-number-format:bullet;
	mso-level-text:;
	mso-level-tab-stop:none;
	mso-level-number-position:left;
	text-indent:-.25in;
	font-family:Wingdings;}
@list l4
	{mso-list-id:974945841;
	mso-list-type:hybrid;
	mso-list-template-ids:116654920 67698689 67698691 67698693 67698689 67698691 67698693 67698689 67698691 67698693;}
@list l4:level1
	{mso-level-number-format:bullet;
	mso-level-text:;
	mso-level-tab-stop:none;
	mso-level-number-position:left;
	text-indent:-.25in;
	font-family:Symbol;}
@list l4:level2
	{mso-level-number-format:bullet;
	mso-level-text:o;
	mso-level-tab-stop:none;
	mso-level-number-position:left;
	text-indent:-.25in;
	font-family:"Courier New";}
@list l5
	{mso-list-id:1084299460;
	mso-list-type:hybrid;
	mso-list-template-ids:2001787630 67698689 67698691 67698693 67698689 67698691 67698693 67698689 67698691 67698693;}
@list l5:level1
	{mso-level-number-format:bullet;
	mso-level-text:;
	mso-level-tab-stop:none;
	mso-level-number-position:left;
	text-indent:-.25in;
	font-family:Symbol;}
@list l5:level2
	{mso-level-number-format:bullet;
	mso-level-text:o;
	mso-level-tab-stop:none;
	mso-level-number-position:left;
	text-indent:-.25in;
	font-family:"Courier New";}
@list l5:level3
	{mso-level-number-format:bullet;
	mso-level-text:;
	mso-level-tab-stop:none;
	mso-level-number-position:left;
	text-indent:-.25in;
	font-family:Wingdings;}
@list l6
	{mso-list-id:1127895365;
	mso-list-type:hybrid;
	mso-list-template-ids:956705976 67698689 67698691 67698693 67698689 67698691 67698693 67698689 67698691 67698693;}
@list l6:level1
	{mso-level-number-format:bullet;
	mso-level-text:;
	mso-level-tab-stop:none;
	mso-level-number-position:left;
	text-indent:-.25in;
	font-family:Symbol;}
@list l6:level2
	{mso-level-number-format:bullet;
	mso-level-text:o;
	mso-level-tab-stop:none;
	mso-level-number-position:left;
	text-indent:-.25in;
	font-family:"Courier New";}
@list l7
	{mso-list-id:1333222913;
	mso-list-type:hybrid;
	mso-list-template-ids:-827426934 67698689 67698691 67698693 67698689 67698691 67698693 67698689 67698691 67698693;}
@list l7:level1
	{mso-level-number-format:bullet;
	mso-level-text:;
	mso-level-tab-stop:none;
	mso-level-number-position:left;
	text-indent:-.25in;
	font-family:Symbol;}
@list l8
	{mso-list-id:1601378270;
	mso-list-type:hybrid;
	mso-list-template-ids:-879845426 67698689 67698691 67698693 67698689 67698691 67698693 67698689 67698691 67698693;}
@list l8:level1
	{mso-level-number-format:bullet;
	mso-level-text:;
	mso-level-tab-stop:none;
	mso-level-number-position:left;
	text-indent:-.25in;
	font-family:Symbol;}
@list l9
	{mso-list-id:1630477372;
	mso-list-type:hybrid;
	mso-list-template-ids:-458567252 67698689 67698691 67698693 67698689 67698691 67698693 67698689 67698691 67698693;}
@list l9:level1
	{mso-level-number-format:bullet;
	mso-level-text:;
	mso-level-tab-stop:none;
	mso-level-number-position:left;
	text-indent:-.25in;
	font-family:Symbol;}
@list l10
	{mso-list-id:2032485536;
	mso-list-type:hybrid;
	mso-list-template-ids:-808151160 67698689 67698691 67698693 67698689 67698691 67698693 67698689 67698691 67698693;}
@list l10:level1
	{mso-level-number-format:bullet;
	mso-level-text:;
	mso-level-tab-stop:none;
	mso-level-number-position:left;
	text-indent:-.25in;
	font-family:Symbol;}
@list l10:level2
	{mso-level-number-format:bullet;
	mso-level-text:o;
	mso-level-tab-stop:none;
	mso-level-number-position:left;
	text-indent:-.25in;
	font-family:"Courier New";}
ol
	{margin-bottom:0in;}
ul
	{margin-bottom:0in;}
-->
</style></p>
<!--[if gte mso 10]>
<style>
/* Style Definitions */
table.MsoNormalTable
{mso-style-name:"Table Normal";
mso-tstyle-rowband-size:0;
mso-tstyle-colband-size:0;
mso-style-noshow:yes;
mso-style-priority:99;
mso-style-qformat:yes;
mso-style-parent:"";
mso-padding-alt:0in 5.4pt 0in 5.4pt;
mso-para-margin:0in;
mso-para-margin-bottom:.0001pt;
mso-pagination:widow-orphan;
font-size:10.0pt;
font-family:"Calibri","sans-serif";}
</style>
<![endif]-->
<p class="MsoNormal">This document outlines how to create a custom Sitefinity module by modifying the SEVDNUG.Contacts module.<span style="">&nbsp; </span>The SEVDNUG.Contacts module was based on the Samples.Contacts module found on the Sitefinity blog.<span style="">&nbsp; </span>This document gives you step by step directions on how to modify/tweak this SEVDNUG.Contacts module to implement your new custom module.<span style="">&nbsp; </span>In addition, I attempt to explain what each file is used for. This sample module is constructed in a very similar to the way the modules of Sitefinity application are constructed. As a result, you should be able to use parts of this document to figure out how to customize certain features of Sitefinity modules. After completing the &ldquo;First Steps&rdquo; and &ldquo;Modify the Code&rdquo; sections of this document, your new module will be available on your Sitefinity site.</p>
<p class="MsoNormal">If you have any questions or issues, feel free to contact me at jguadagno [at] hotmail.com</p>
<h2>Document conventions</h2>
<p class="MsoNormal"><span style="">&nbsp;</span>Text enclosed in &lt;&gt; brackets should be replaced by the type of text listed. So if you see &lt;CompanyName&gt;.&lt;ModuleName&gt;, the &lt;ModuleName&gt; should be replaced by whatever you want to call your module, and the &lt;CompanyName&gt; should be replaced by your company name like SEVDNUG.Vendors.</p>
<h2>Contents</h2>
<ul type="disc" style="margin-top: 0in;">
    <li class="MsoNormal" style=""><!--[if supportFields]><span
    style='mso-element:field-begin'></span><span
    style='mso-spacerun:yes'> </span>REF _Ref200941315 \h <span
    style='mso-element:field-separator'></span><![endif]-->First Steps<!--[if gte mso 9]><xml>
    <w:data>08D0C9EA79F9BACE118C8200AA004BA90B02000000080000000E0000005F005200650066003200300030003900340031003300310035000000</w:data>
    </xml><![endif]--><!--[if supportFields]><span style='mso-element:field-end'></span><![endif]--></li>
    <li class="MsoNormal" style=""><!--[if supportFields]><span
    style='mso-element:field-begin'></span><span
    style='mso-spacerun:yes'> </span>REF _Ref200941319 \h <span
    style='mso-element:field-separator'></span><![endif]-->Modify the Code<!--[if gte mso 9]><xml>
    <w:data>08D0C9EA79F9BACE118C8200AA004BA90B02000000080000000E0000005F005200650066003200300030003900340031003300310039000000</w:data>
    </xml><![endif]--><!--[if supportFields]><span style='mso-element:field-end'></span><![endif]-->
    <ul type="circle" style="margin-top: 0in;">
        <li class="MsoNormal" style=""><!--[if supportFields]><span
        style='mso-element:field-begin'></span><span
        style='mso-spacerun:yes'> </span>REF _Ref200941334 \h <span
        style='mso-element:field-separator'></span><![endif]-->&lt;CompanyName&gt;.&lt;ModuleName&gt;       Project<!--[if gte mso 9]><xml>
        <w:data>08D0C9EA79F9BACE118C8200AA004BA90B02000000080000000E0000005F005200650066003200300030003900340031003300330034000000</w:data>
        </xml><![endif]--><!--[if supportFields]><span style='mso-element:field-end'></span><![endif]--></li>
        <li class="MsoNormal" style=""><!--[if supportFields]><span
        style='mso-element:field-begin'></span><span
        style='mso-spacerun:yes'> </span>REF _Ref200941365 \h <span
        style='mso-element:field-separator'></span><![endif]-->&lt;CompanyName&gt;.&lt;ModuleName&gt;.Data       Project<!--[if gte mso 9]><xml>
        <w:data>08D0C9EA79F9BACE118C8200AA004BA90B02000000080000000E0000005F005200650066003200300030003900340031003300360035000000</w:data>
        </xml><![endif]--><!--[if supportFields]><span style='mso-element:field-end'></span><![endif]--></li>
        <li class="MsoNormal" style=""><!--[if supportFields]><span
        style='mso-element:field-begin'></span><span
        style='mso-spacerun:yes'> </span>REF _Ref200941421 \h <span
        style='mso-element:field-separator'></span><![endif]-->&lt;CompanyName&gt;.&lt;ModuleName&gt;.Web       Project<!--[if gte mso 9]><xml>
        <w:data>08D0C9EA79F9BACE118C8200AA004BA90B02000000080000000E0000005F005200650066003200300030003900340031003400320031000000</w:data>
        </xml><![endif]--><!--[if supportFields]><span style='mso-element:field-end'></span><![endif]--></li>
    </ul>
    </li>
    <li class="MsoNormal" style=""><!--[if supportFields]><span
    style='mso-element:field-begin'></span><span
    style='mso-spacerun:yes'> </span>REF _Ref200941374 \h <span
    style='mso-element:field-separator'></span><![endif]-->Sample Solution      Structure<!--[if gte mso 9]><xml>
    <w:data>08D0C9EA79F9BACE118C8200AA004BA90B02000000080000000E0000005F005200650066003200300030003900340031003300370034000000</w:data>
    </xml><![endif]--><!--[if supportFields]><span style='mso-element:field-end'></span><![endif]--><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></li>
</ul>
<h1><a name="_Ref200941315">First Steps</a></h1>
<ul type="disc" style="margin-top: 0in;">
    <li class="MsoNormal" style="">Rename the solution file      to &lt;CompanyName&gt;.&lt;ModuleName&gt;.sln</li>
    <li class="MsoNormal" style="">Rename the folders
    <ul type="circle" style="margin-top: 0in;">
        <li class="MsoNormal" style="">SEVDNUG.Contacts to       &lt;CompanyName&gt;.&lt;ModuleName&gt;</li>
        <li class="MsoNormal" style="">SEVDNUG.Contacts.Data to       &lt;CompanyName&gt;.&lt;ModuleName&gt;.Data</li>
        <li class="MsoNormal" style="">SEVDNUG.Contacts.Web to       &lt;CompanyName&gt;.&lt;ModuleName&gt;.Web</li>
    </ul>
    </li>
    <li class="MsoNormal" style="">Rename the Visual Studio      project files
    <ul type="circle" style="margin-top: 0in;">
        <li class="MsoNormal" style="">&lt;CompanyName&gt;.&lt;ModuleName&gt;\SEVDNUG.Contacts.csproj       to       &lt;CompanyName&gt;.&lt;ModuleName&gt;\&lt;CompanyName&gt;.&lt;ModuleName&gt;</li>
        <li class="MsoNormal" style="">&lt;CompanyName&gt;.&lt;ModuleName&gt;.Data\SEVDNUG.Contacts.Data.csproj       to       &lt;CompanyName&gt;.&lt;ModuleName&gt;.Data\&lt;CompanyName&gt;.&lt;ModuleName&gt;.Data</li>
    </ul>
    </li>
    <li class="MsoNormal" style="">Open up the solution in a      text editor like Notepad, search and replace SEVDNUG.Contacts to      &lt;CompanyName&gt;.&lt;ModuleName&gt;</li>
    <li class="MsoNormal" style="">Open up the      &lt;CompanyName&gt;.&lt;ModuleName&gt;.sln solution file in Visual Studio.</li>
    <li class="MsoNormal" style="">Search and replace the      text<span style="">&nbsp; </span>SEVDNUG.Contacts with      &lt;CompanyName&gt;.&lt;ModuleName&gt;</li>
    <li class="MsoNormal" style="">Rename solution (optional)</li>
</ul>
<p class="MsoNormal">At the end of this article you will find a sample of what the solution would like.</p>
<h1><a name="_Ref200941319">Modify the Code</a></h1>
<h2><a name="_Ref200941334">&lt;CompanyName&gt;.&lt;ModuleName&gt; Project</a></h2>
<p class="MsoNormal">Please follow these steps for this project prior to modifying the files.</p>
<ul type="disc" style="margin-top: 0in;">
    <li class="MsoNormal" style="">Rename all of the      Contacts*.cs files to &lt;ModuleName&gt;*.cs.</li>
    <li class="MsoNormal" style="">Rename IContact.cs to      I&lt;ModuleName&gt;.cs</li>
    <li class="MsoNormal" style="">Rename      WebControls\Contacts*.cs to WebControls\&lt;ModuleName&gt;*.cs</li>
    <li class="MsoNormal" style="">Rename      WebControls\SingleContact*.cs to WebControls\Single&lt;ModuleName&gt;.cs</li>
    <li class="MsoNormal" style="">Rename the references to      Contact object and IContact to &lt;ModuleName&gt;, if necessary.</li>
</ul>
<h3>I&lt;ModuleName&gt;.cs</h3>
<ul type="disc" style="margin-top: 0in;">
    <li class="MsoNormal" style="">Add whatever properties      will make up the &lt;ModuleName&gt; object, these properties should match      what you plan on storing in the database.</li>
</ul>
<h3>&lt;ModuleName&gt;Module.cs</h3>
<p class="MsoNormal">This file contains the Name, Title, and Description of your module, as well as the security for your module.</p>
<ul type="disc" style="margin-top: 0in;">
    <li class="MsoNormal" style="">Update the Description,      Title and Name properties to whatever you want to be displayed.</li>
    <li class="MsoNormal" style="">Rename the text, Contact      to &lt;ModuleName&gt;</li>
    <li class="MsoNormal" style="">Note that nothing else      needs to be changed, other than description, title and name properties</li>
</ul>
<h3>&lt;ModuleName&gt;Provider.cs</h3>
<p class="MsoNormal">This class contains the &ldquo;definition&rdquo; of what your module provider implementation needs to support.</p>
<ul type="disc" style="margin-top: 0in;">
    <li class="MsoNormal" style="">Rename the text, Contact      to &lt;ModuleName&gt;</li>
    <li class="MsoNormal" style="">Replace the content of      the region &ldquo;Contact Methods&rdquo; with methods the fit your desired      functionality.<span style="">&nbsp; </span>Most of the contact      methods should be a good starting point.</li>
    <li class="MsoNormal" style="">Add whatever additional      methods you think your provider will need. Some examples are:
    <ul type="circle" style="margin-top: 0in;">
        <li class="MsoNormal" style="">Get&lt;ModuleName&gt;</li>
        <li class="MsoNormal" style="">Save&lt;ModuleName&gt;</li>
        <li class="MsoNormal" style="">Delete&lt;ModuleName&gt;</li>
        <li class="MsoNormal" style="">Get&lt;ModuleName&gt;s</li>
    </ul>
    </li>
    <li class="MsoNormal" style="">Under the properties      section, add properties to the template files that your module will use.      If you are making new templates, such as controls for the public facing      side of the site such as the blog posts control, you would want to add      them here. Here is an example:</li>
</ul>
<p class="MsoNormal"><o:p>&nbsp;</o:p></p>
<p class="MsoNormal" style="margin: 0in 0in 0.0001pt 49.5pt; line-height: normal;"><span style="font-size: 10pt; font-family: &quot;Courier New&quot;; color: gray;">///</span><span style="font-size: 10pt; font-family: &quot;Courier New&quot;; color: green;"> </span><span style="font-size: 10pt; font-family: &quot;Courier New&quot;; color: gray;">&lt;summary&gt;<o:p></o:p></span></p>
<p class="MsoNormal" style="margin: 0in 0in 0.0001pt 49.5pt; line-height: normal;"><span style="font-size: 10pt; font-family: &quot;Courier New&quot;; color: gray;">///</span><span style="font-size: 10pt; font-family: &quot;Courier New&quot;; color: green;"> Returns the path of external template for ControlPanel control in insert/edit mode<o:p></o:p></span></p>
<p class="MsoNormal" style="margin: 0in 0in 0.0001pt 49.5pt; line-height: normal;"><span style="font-size: 10pt; font-family: &quot;Courier New&quot;; color: gray;">///</span><span style="font-size: 10pt; font-family: &quot;Courier New&quot;; color: green;"> </span><span style="font-size: 10pt; font-family: &quot;Courier New&quot;; color: gray;">&lt;/summary&gt;<o:p></o:p></span></p>
<p class="MsoNormal" style="margin: 0in 0in 0.0001pt 49.5pt; line-height: normal;"><span style="font-size: 10pt; font-family: &quot;Courier New&quot;; color: blue;">public</span><span style="font-size: 10pt; font-family: &quot;Courier New&quot;;"> <span style="color: blue;">string</span> ControlPanelInsertEditTemplate<o:p></o:p></span></p>
<p class="MsoNormal" style="margin-bottom: 0.0001pt; line-height: normal;"><span style="font-size: 10pt; font-family: &quot;Courier New&quot;;"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>{<o:p></o:p></span></p>
<p class="MsoNormal" style="margin-bottom: 0.0001pt; line-height: normal;"><span style="font-size: 10pt; font-family: &quot;Courier New&quot;;"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span><span style="color: blue;">get<o:p></o:p></span></span></p>
<p class="MsoNormal" style="margin-bottom: 0.0001pt; line-height: normal;"><span style="font-size: 10pt; font-family: &quot;Courier New&quot;;"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>{<o:p></o:p></span></p>
<p class="MsoNormal" style="margin-bottom: 0.0001pt; line-height: normal;"><span style="font-size: 10pt; font-family: &quot;Courier New&quot;;"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span><span style="color: blue;">return</span> <span style="color: blue;">this</span>.controlPanelInsertEditTemplate;<o:p></o:p></span></p>
<p class="MsoNormal" style="margin-bottom: 0.0001pt; line-height: normal;"><span style="font-size: 10pt; font-family: &quot;Courier New&quot;;"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>}<o:p></o:p></span></p>
<p class="MsoNormal"><span style="font-size: 10pt; line-height: 115%; font-family: &quot;Courier New&quot;;"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>}</span></p>
<h3>&lt;ModuleName&gt;Manager.cs</h3>
<p class="MsoNormal">This class provides is present in most Provider model patterns. It contain methods to interact with the provider.</p>
<ul type="disc" style="margin-top: 0in;">
    <li class="MsoNormal" style="">Rename the text, Contact      to &lt;ModuleName&gt;</li>
    <li class="MsoNormal" style="">Replace the content of      the region &ldquo;Contact Methods&rdquo; with methods the fit your desired      functionality.<span style="">&nbsp; </span>Most of the contact      methods should be a good starting point. This should closely mirror the      Provider methods.</li>
    <li class="MsoNormal" style="">Add whatever additional      methods you think your manager class will need.</li>
</ul>
<h3>WebControls/*</h3>
<p class="MsoNormal">These classes provide the functionality to edit or display the data within Sitefinity.</p>
<ul type="disc" style="margin-top: 0in;">
    <li class="MsoNormal" style="">Replace the text, Contact      to &lt;ModuleName&gt;</li>
    <li class="MsoNormal" style="">Note, you probably will      have to manually change the Resources/Messages.resx content. TODO: Add reference      to new localization article.</li>
</ul>
<h4>Single&lt;ModuleName&gt;.cs</h4>
<p class="MsoNormal">This is used to display a single item (&lt;ModuleName&gt;). This file provides the code behind to the Single&lt;ModuleName&gt;.ascx file.<span style=""><o:p></o:p></span></p>
<ul type="disc" style="margin-top: 0in;">
    <li class="MsoNormal" style="">Replace the text, Contact      to &lt;ModuleName&gt;</li>
    <li class="MsoNormal" style="">Modify the      Single&lt;ModuleName&gt;Container to include the fields defined in I&lt;ModuleName&gt;.cs      file.</li>
    <li class="MsoNormal" style="">Modify the      CreateChildControls to reflect the controls that are available in the      layoutContainer</li>
</ul>
<h4>&lt;ModuleName&gt;Lists.cs</h4>
<p class="MsoNormal">This is used to display a list of items (&lt;ModuleName&gt;s)</p>
<ul type="disc" style="margin-top: 0in;">
    <li class="MsoNormal" style="">Replace the text, Contact      to &lt;ModuleName&gt;</li>
    <li class="MsoNormal" style="">Modify the <span style="">&lt;ModuleName&gt;Repeater_ItemDataBound method      to display the properties of the object.<o:p></o:p></span></li>
</ul>
<h4>Admin\&lt;ModuleName&gt;Editor.cs</h4>
<p class="MsoNormal">This control is used for inserting new &lt;ModuleName&gt; objects or editing existing ones.</p>
<ul type="disc" style="margin-top: 0in;">
    <li class="MsoNormal" style="">Replace the text, Contact      to &lt;ModuleName&gt;</li>
    <li class="MsoNormal" style="">Update the      CreateChildControls method of the &lt;ModuleName&gt;Editor class to match      the properties available within your new module class.</li>
    <li class="MsoNormal" style="">Update the      CreateNew&lt;ModuleName&gt; method of the &lt;ModuleName&gt;Editor class to      match the properties available within your new module class.</li>
    <li class="MsoNormal" style="">Update the      Update&lt;ModuleName&gt; method of the &lt;ModuleName&gt;Editor class to      match the properties available within your new module class.</li>
    <li class="MsoNormal" style="">Update the      &lt;ModuleName&gt;EditorContainer class to the match the properties within      your new module class. This should most likely match the      Single&lt;ModuleName&gt;.cs class.</li>
</ul>
<p class="MsoNormal">Essentially, any properties that are available in your I&lt;ModuleName&gt; interface should have a line in the CreateChildControls, CreateNew&lt;ModuleName&gt;, Update&lt;ModuleName&gt; methods, as wells as properties in the &lt;ModuleName&gt;EditorContainer class.</p>
<h4>Admin\CommandPanel.cs</h4>
<p class="MsoNormal">This module is used to display the side content in the Sitefinity admin interface. Other than changing its name, you do not need to change this control.</p>
<ul type="disc" style="margin-top: 0in;">
    <li class="MsoNormal" style="">Replace the text, Contact      to &lt;ModuleName&gt;</li>
</ul>
<h4>Admin\ControlPanel.cs</h4>
<p class="MsoNormal">This module is used to display the side content in the Sitefinity admin interface. Other than changing its name, you do not need to change this control.</p>
<ul type="disc" style="margin-top: 0in;">
    <li class="MsoNormal" style="">Replace the text, Contact      to &lt;ModuleName&gt;</li>
</ul>
<h2><a name="_Ref200941365">&lt;CompanyName&gt;.&lt;ModuleName&gt;.Data Project</a></h2>
<p class="MsoNormal">This assembly is responsible for all of the data access. At minimum it will have three classes, with this implementation, DefaultProvider.cs, Variable.dbclass, and &lt;ModuleName&gt;.dbclass. Optionally, you can add &lt;ModuleName&gt;.cs and &lt;ModuleNames&gt;s.cs to add additional data access methods. Any file with the extension &ldquo;.dbclass&rdquo; makes a table in your database.</p>
<p class="MsoNormal">Please follow these steps for this project prior to modifying the files.</p>
<ul type="disc" style="margin-top: 0in;">
    <li class="MsoNormal" style="">Rename Contact.* to      &lt;ModuleName&gt;*.cs</li>
    <li class="MsoNormal" style="">Search and replace Contact      with &lt;ModuleName&gt;.</li>
    <li class="MsoNormal" style="">Add a reference to the new      &lt;CompanyName&gt;.&lt;ModuleName&gt; project.</li>
</ul>
<h3>DefaultProvider.cs</h3>
<p class="MsoNormal">This class provides the implementation of the provider for the &lt;ModuleName&gt;. The private fields and following methods should not need to be changed; SetVariable, GetVariable, and Initialize. The first step to do is to replace the Contact with &lt;ModuleName&gt;. The next step is to implement any of the other methods required by &lt;ModuleName&gt;Provider.</p>
<h3>Variable.dbclass</h3>
<p class="MsoNormal">This file generates the database table for the variables table. This should not change.</p>
<h3>&lt;ModuleName&gt;.dbclass</h3>
<p class="MsoNormal">This class generates the database for the &lt;ModuleName&gt; table.<span style="">&nbsp; </span>This file should change according to the way you want your database table. The Nolics library will create the table for you. Example:</p>
<p class="MsoNormal" style="margin: 0in 0in 0.0001pt 0.5in; line-height: normal;"><span style="font-size: 10pt; font-family: &quot;Courier New&quot;; color: blue;">dbclass</span><span style="font-size: 10pt; font-family: &quot;Courier New&quot;;"> ModuleName [TableName=<span style="color: rgb(163, 21, 21);">&quot;SEVDNUG_ModuleName&quot;</span>]{<o:p></o:p></span></p>
<p class="MsoNormal" style="margin: 0in 0in 0.0001pt 0.5in; line-height: normal;"><span style="font-size: 10pt; font-family: &quot;Courier New&quot;;"><span style="">&nbsp;&nbsp;&nbsp; </span><span style="color: blue;">primary</span> <span style="color: blue;">key</span> string Application [50], guid ID[AutoGenGUID = true];<o:p></o:p></span></p>
<p class="MsoNormal" style="margin: 0in 0in 0.0001pt 0.5in; line-height: normal;"><span style="font-size: 10pt; font-family: &quot;Courier New&quot;;"><span style="">&nbsp;&nbsp;&nbsp; </span>string Name[Length=100];<o:p></o:p></span></p>
<p class="MsoNormal" style="margin: 0in 0in 0.0001pt 0.5in; line-height: normal;"><span style="font-size: 10pt; font-family: &quot;Courier New&quot;;"><span style="">&nbsp;&nbsp;&nbsp; </span>string Url[Length=255];<o:p></o:p></span></p>
<p class="MsoNormal" style="margin: 0in 0in 0.0001pt 0.5in; line-height: normal;"><span style="font-size: 10pt; font-family: &quot;Courier New&quot;;"><span style="">&nbsp;&nbsp;&nbsp; </span>string LogoUrl[Length=255];<o:p></o:p></span></p>
<p class="MsoNormal" style="margin: 0in 0in 0.0001pt 0.5in; line-height: normal;"><span style="font-size: 10pt; font-family: &quot;Courier New&quot;;"><span style="">&nbsp;&nbsp;&nbsp; </span><span style="color: blue;">modified</span> date ModifiedOn;<o:p></o:p></span></p>
<p class="MsoNormal" style="margin-left: 0.5in;"><span style="font-size: 10pt; line-height: 115%; font-family: &quot;Courier New&quot;;"><span style="">&nbsp;&nbsp;&nbsp; </span><span style="color: blue;">created</span> date CreatedOn;<o:p></o:p></span></p>
<p class="MsoNormal"><span style="">For more info on modifying the dbclass library or how to modify this file, check the Nolics documentation at <a href="http://www.nolics.net/Docs4_2/Ref_dbclass.html">http://www.nolics.net/Docs4_2/Ref_dbclass.html</a>.<o:p></o:p></span></p>
<p class="MsoNormal">Where is the tutorial that tells you how to make tables?</p>
<h3>&lt;ModuleName&gt;.cs</h3>
<p class="MsoNormal">This class will allow you to add additional properties and methods to the Nolics generated class.</p>
<h3>&lt;ModuleName&gt;s.cs</h3>
<p class="MsoNormal">This class creates a dynamic query around the module table. Dynamic queries are typically used when there are custom table joins that you want to be available to any calling class. For more information on creating or using dynamic queries with Nolics please check out the Nolics documentation at http://www.nolics.com/Material2005/WT10_Queries.doc.</p>
<p class="MsoNormal" style="margin: 0in 0in 0.0001pt 40.5pt; line-height: normal;"><span style="font-size: 10pt; font-family: &quot;Courier New&quot;; color: blue;">public</span><span style="font-size: 10pt; font-family: &quot;Courier New&quot;;"> <span style="color: blue;">class</span> <span style="color: rgb(43, 145, 175);">ModuleNames</span>: <span style="color: rgb(43, 145, 175);">Query</span>&lt;<span style="color: rgb(43, 145, 175);">ModuleName</span>&gt;<o:p></o:p></span></p>
<p class="MsoNormal" style="margin: 0in 0in 0.0001pt 0.5in; line-height: normal;"><span style="font-size: 10pt; font-family: &quot;Courier New&quot;;">{<o:p></o:p></span></p>
<p class="MsoNormal" style="margin: 0in 0in 0.0001pt 0.5in; line-height: normal;"><span style="font-size: 10pt; font-family: &quot;Courier New&quot;;"><o:p>&nbsp;</o:p></span></p>
<p class="MsoNormal" style="margin-left: 0.5in;"><span style="font-size: 10pt; line-height: 115%; font-family: &quot;Courier New&quot;;">}</span></p>
<h2><a name="_Ref200941421">&lt;CompanyName&gt;.&lt;ModuleName&gt;.Web Project</a></h2>
<p class="MsoNormal">Please follow these steps for this project prior to modifying the files.</p>
<ul type="disc" style="margin-top: 0in;">
    <li class="MsoNormal" style="">Rename the      /Sitefinity/ControlTemplates/Contacts folder to /Sitefinity/ControlTemplates/&lt;ModuleName&gt;</li>
    <li class="MsoNormal" style="">Rename the file      /Sitefinity/ControlTemplates/&lt;ModuleName&gt;/ContactsListTemplate.ascx      to &lt;ModuleName&gt;ListTemplate.ascx</li>
    <li class="MsoNormal" style="">Rename the file      /Sitefinity/ControlTemplates/&lt;ModuleName&gt;/ContactsListTemplate.ascx      to Single&lt;ModuleName&gt;Template.ascx</li>
</ul>
<h3>Web.Config</h3>
<p class="MsoNormal">The web.config file for your Sitefinity installation will need to be modified to inform Sitefinity of the new module.<span style="">&nbsp; </span>Please note: this section of the document requires that you modify your existing Sitefinity web.config. PLEASE BACK UP YOU WEB.CONFIG FILE BEFORE YOU CHANGE IT.</p>
<p class="MsoNormal">There are three parts of the web.config file that need to be modified. They include the modules section, section group, and the meta fields section. The web.config provided in this example has a <span style="font-size: 10pt; line-height: 115%; font-family: &quot;Courier New&quot;; color: blue;">&lt;!-- </span><span style="font-size: 10pt; line-height: 115%; font-family: &quot;Courier New&quot;; color: green;">START REPLACE : Step # </span><span style="font-size: 10pt; line-height: 115%; font-family: &quot;Courier New&quot;; color: blue;">--&gt; </span>tag followed by a <span style="font-size: 10pt; line-height: 115%; font-family: &quot;Courier New&quot;; color: blue;">&lt;!&mdash; </span><span style="font-size: 10pt; line-height: 115%; font-family: &quot;Courier New&quot;; color: green;">END REPLACE : Step # </span><span style="font-size: 10pt; line-height: 115%; font-family: &quot;Courier New&quot;; color: blue;">--&gt; </span>tag where text needs to be replaced or modified.<span style="">&nbsp; </span></p>
<h4>Notify ASP.NET of the new section group</h4>
<p class="MsoNormal">Search for <span style="font-size: 10pt; line-height: 115%; font-family: &quot;Courier New&quot;; color: blue;">&lt;!-- </span><span style="font-size: 10pt; line-height: 115%; font-family: &quot;Courier New&quot;; color: green;">START REPLACE : Step 1 </span><span style="font-size: 10pt; line-height: 115%; font-family: &quot;Courier New&quot;; color: blue;">--&gt;</span>.<span style="">&nbsp; </span>This section needs to be placed after the closing tag of the Telerik section group of your existing Sitefinity web.config file.</p>
<ul type="disc" style="margin-top: 0in;">
    <li class="MsoNormal" style="">Replace the text of      SEVDNUG with your company name. This should be what every use used for      &lt;CompanyName&gt;.</li>
    <li class="MsoNormal" style="">Replace the text of      Contacts with your module name. This should be what every use used for      &lt;ModuleName&gt;.</li>
</ul>
<h4>Tell Sitefinity about your new module</h4>
<p class="MsoNormal">Search for <span style="font-size: 10pt; line-height: 115%; font-family: &quot;Courier New&quot;; color: blue;">&lt;!-- </span><span style="font-size: 10pt; line-height: 115%; font-family: &quot;Courier New&quot;; color: green;">START REPLACE : Step 2 </span><span style="font-size: 10pt; line-height: 115%; font-family: &quot;Courier New&quot;; color: blue;">--&gt;</span>.<span style="">&nbsp; </span>The line following this tag needs to be added to you telerik/framework/modules/ section of your existing Sitefinity web.config file.</p>
<ul type="disc" style="margin-top: 0in;">
    <li class="MsoNormal" style="">Replace the text of SEVDNUG      with your company name. This should be what every use used for      &lt;CompanyName&gt;.</li>
    <li class="MsoNormal" style="">Replace the text of      Contacts with your module name. This should be what every use used for      &lt;ModuleName&gt;.</li>
</ul>
<p class="MsoNormal"><o:p>&nbsp;</o:p></p>
<h4>Add the new section group</h4>
<p class="MsoNormal">Search <span style="font-size: 10pt; line-height: 115%; font-family: &quot;Courier New&quot;; color: blue;">&lt;!-- </span><span style="font-size: 10pt; line-height: 115%; font-family: &quot;Courier New&quot;; color: green;">START REPLACE : Step 3 </span><span style="font-size: 10pt; line-height: 115%; font-family: &quot;Courier New&quot;; color: blue;">--&gt;</span>.<span style="">&nbsp; </span>Everything between this tag and the <span style="font-size: 10pt; line-height: 115%; font-family: &quot;Courier New&quot;; color: blue;">&lt;!-- </span><span style="font-size: 10pt; line-height: 115%; font-family: &quot;Courier New&quot;; color: green;">END REPLACE : Step 3 </span><span style="font-size: 10pt; line-height: 115%; font-family: &quot;Courier New&quot;; color: blue;">--&gt; </span>tag should be added to the end your exist web.config.</p>
<ul type="disc" style="margin-top: 0in;">
    <li class="MsoNormal" style="">Replace the text of      SEVDNUG with your company name. This should be what every use used for      &lt;CompanyName&gt;.</li>
    <li class="MsoNormal" style="">Replace the text of      Contacts with your module name. This should be what every use used for      &lt;ModuleName&gt;.</li>
    <li class="MsoNormal" style="">Replace the text of      contact with the &lt;ModuleName&gt; for the following lines.</li>
</ul>
<p class="MsoNormal" style="margin: 0in 0in 0.0001pt 0.5in; line-height: normal;"><span style="font-size: 10pt; font-family: &quot;Courier New&quot;; color: red;">contactsPermissionsTemplate</span><span style="font-size: 10pt; font-family: &quot;Courier New&quot;; color: blue;">=</span><span style="font-size: 10pt; font-family: &quot;Courier New&quot;;">&quot;<span style="color: blue;">~/Sitefinity/Admin/ControlTemplates/Contacts/ContactsPermissionsTemplate.ascx</span>&quot;<o:p></o:p></span></p>
<p class="MsoNormal" style="margin: 0in 0in 0.0001pt 0.5in; line-height: normal;"><span style="font-size: 10pt; font-family: &quot;Courier New&quot;; color: red;">contactEditorTemplate</span><span style="font-size: 10pt; font-family: &quot;Courier New&quot;; color: blue;">=</span><span style="font-size: 10pt; font-family: &quot;Courier New&quot;;">&quot;<span style="color: blue;">~/Sitefinity/Admin/ControlTemplates/Contacts/ContactEditorTemplate.ascx</span>&quot;<o:p></o:p></span></p>
<p class="MsoNormal" style="margin: 0in 0in 0.0001pt 0.5in; line-height: normal;"><span style="font-size: 10pt; font-family: &quot;Courier New&quot;; color: red;">contactsListTemplate</span><span style="font-size: 10pt; font-family: &quot;Courier New&quot;; color: blue;">=</span><span style="font-size: 10pt; font-family: &quot;Courier New&quot;;">&quot;<span style="color: blue;">~/Sitefinity/ControlTemplates/Contacts/ContactsListTemplate.ascx</span>&quot;<o:p></o:p></span></p>
<p class="MsoNormal" style="margin-left: 0.5in;"><span style="font-size: 10pt; line-height: 115%; font-family: &quot;Courier New&quot;; color: red;">singleContactTemplate</span><span style="font-size: 10pt; line-height: 115%; font-family: &quot;Courier New&quot;; color: blue;">=</span><span style="font-size: 10pt; line-height: 115%; font-family: &quot;Courier New&quot;;">&quot;<span style="color: blue;">~/Sitefinity/ControlTemplates/Contacts/SingleContactTemplate.ascx</span>&quot;<o:p></o:p></span></p>
<p class="MsoNormal"><span style="">Note, these xml attributes map to the properties that you defined in the &lt;ModuleName&gt;Provider class. Here is an example:<o:p></o:p></span></p>
<p class="MsoNormal" style="margin: 0in 0in 0.0001pt 0.5in; line-height: normal;"><span style="font-size: 10pt; font-family: &quot;Courier New&quot;; color: gray;">///</span><span style="font-size: 10pt; font-family: &quot;Courier New&quot;; color: green;"> </span><span style="font-size: 10pt; font-family: &quot;Courier New&quot;; color: gray;">&lt;summary&gt;<o:p></o:p></span></p>
<p class="MsoNormal" style="margin: 0in 0in 0.0001pt 0.5in; line-height: normal;"><span style="font-size: 10pt; font-family: &quot;Courier New&quot;; color: gray;">///</span><span style="font-size: 10pt; font-family: &quot;Courier New&quot;; color: green;"> Returns the path of external template for ContactsPermission<o:p></o:p></span></p>
<p class="MsoNormal" style="margin: 0in 0in 0.0001pt 0.5in; line-height: normal;"><span style="font-size: 10pt; font-family: &quot;Courier New&quot;; color: green;">/// view set in web.config<o:p></o:p></span></p>
<p class="MsoNormal" style="margin: 0in 0in 0.0001pt 0.5in; line-height: normal;"><span style="font-size: 10pt; font-family: &quot;Courier New&quot;; color: gray;">///</span><span style="font-size: 10pt; font-family: &quot;Courier New&quot;; color: green;"> </span><span style="font-size: 10pt; font-family: &quot;Courier New&quot;; color: gray;">&lt;/summary&gt;<o:p></o:p></span></p>
<p class="MsoNormal" style="margin: 0in 0in 0.0001pt 0.5in; line-height: normal;"><span style="font-size: 10pt; font-family: &quot;Courier New&quot;; color: blue;">public</span><span style="font-size: 10pt; font-family: &quot;Courier New&quot;;"> <span style="color: blue;">string</span> ContactsPermissionsTemplate<o:p></o:p></span></p>
<p class="MsoNormal" style="margin: 0in 0in 0.0001pt 0.5in; line-height: normal;"><span style="font-size: 10pt; font-family: &quot;Courier New&quot;;">{<o:p></o:p></span></p>
<p class="MsoNormal" style="margin: 0in 0in 0.0001pt 0.5in; text-indent: 0.5in; line-height: normal;"><span style="font-size: 10pt; font-family: &quot;Courier New&quot;; color: blue;">get<o:p></o:p></span></p>
<p class="MsoNormal" style="margin: 0in 0in 0.0001pt 1in; text-indent: 0.5in; line-height: normal;"><span style="font-size: 10pt; font-family: &quot;Courier New&quot;;">{<o:p></o:p></span></p>
<p class="MsoNormal" style="margin: 0in 0in 0.0001pt 0.5in; line-height: normal;"><span style="font-size: 10pt; font-family: &quot;Courier New&quot;;"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span><span style="color: blue;">return</span> <span style="color: blue;">this</span>.contactsPermissionsTemplate;<o:p></o:p></span></p>
<p class="MsoNormal" style="margin: 0in 0in 0.0001pt 0.5in; line-height: normal;"><span style="font-size: 10pt; font-family: &quot;Courier New&quot;;"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>}<o:p></o:p></span></p>
<h4 style="margin-left: 0.5in;"><span style="font-size: 10pt; line-height: 115%; font-family: &quot;Courier New&quot;;"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>}<o:p></o:p></span></h4>
<h4><span style="">Add the new meta fields<o:p></o:p></span></h4>
<p class="MsoNormal"><span style="">So Sitefinity can recognize the database columns that your module will make, you must declare them in the meta fields section of your web.config. Here is an example from the blogs module:<o:p></o:p></span></p>
<p class="MsoNormal"><span style="font-size: 10pt; line-height: 115%; font-family: &quot;Courier New&quot;; color: blue;">&lt;</span><span style="font-size: 10pt; line-height: 115%; font-family: &quot;Courier New&quot;; color: rgb(163, 21, 21);">metafields</span><span style="font-size: 10pt; line-height: 115%; font-family: &quot;Courier New&quot;; color: blue;">&gt;</span><span style=""><o:p></o:p></span></p>
<p class="MsoNormal" style="margin-bottom: 0.0001pt; line-height: normal;"><span style="font-size: 10pt; font-family: &quot;Courier New&quot;; color: blue;">&lt;</span><span style="font-size: 10pt; font-family: &quot;Courier New&quot;; color: rgb(163, 21, 21);">add</span><span style="font-size: 10pt; font-family: &quot;Courier New&quot;; color: blue;"> </span><span style="font-size: 10pt; font-family: &quot;Courier New&quot;; color: red;">key</span><span style="font-size: 10pt; font-family: &quot;Courier New&quot;; color: blue;">=</span><span style="font-size: 10pt; font-family: &quot;Courier New&quot;;">&quot;<span style="color: blue;">&lt;ModuleName&gt;.Title</span>&quot;<span style="color: blue;"> </span><span style="color: red;">valueType</span><span style="color: blue;">=</span>&quot;<span style="color: blue;">ShortText</span>&quot;<span style="color: blue;"> </span><span style="color: red;">visible</span><span style="color: blue;">=</span>&quot;<span style="color: blue;">True</span>&quot;<span style="color: blue;"> </span><span style="color: red;">searchable</span><span style="color: blue;">=</span>&quot;<span style="color: blue;">True</span>&quot;<span style="color: blue;"> </span><span style="color: red;">sortable</span><span style="color: blue;">=</span>&quot;<span style="color: blue;">True</span>&quot;<span style="color: blue;"> </span><span style="color: red;">defaultValue</span><span style="color: blue;">=</span>&quot;&quot;<span style="color: blue;">/&gt;<o:p></o:p></span></span></p>
<p class="MsoNormal" style="margin-bottom: 0.0001pt; line-height: normal;"><span style="font-size: 10pt; font-family: &quot;Courier New&quot;; color: blue;">&lt;</span><span style="font-size: 10pt; font-family: &quot;Courier New&quot;; color: rgb(163, 21, 21);">add</span><span style="font-size: 10pt; font-family: &quot;Courier New&quot;; color: blue;"> </span><span style="font-size: 10pt; font-family: &quot;Courier New&quot;; color: red;">key</span><span style="font-size: 10pt; font-family: &quot;Courier New&quot;; color: blue;">=</span><span style="font-size: 10pt; font-family: &quot;Courier New&quot;;">&quot;<span style="color: blue;">&lt;ModuleName&gt;.Author</span>&quot;<span style="color: blue;"> </span><span style="color: red;">valueType</span><span style="color: blue;">=</span>&quot;<span style="color: blue;">ShortText</span>&quot;<span style="color: blue;"> </span><span style="color: red;">visible</span><span style="color: blue;">=</span>&quot;<span style="color: blue;">True</span>&quot;<span style="color: blue;"> </span><span style="color: red;">searchable</span><span style="color: blue;">=</span>&quot;<span style="color: blue;">True</span>&quot;<span style="color: blue;"> </span><span style="color: red;">sortable</span><span style="color: blue;">=</span>&quot;<span style="color: blue;">True</span>&quot;<span style="color: blue;"> </span><span style="color: red;">defaultValue</span><span style="color: blue;">=</span>&quot;&quot;<span style="color: blue;">/&gt;<o:p></o:p></span></span></p>
<p class="MsoNormal" style="margin-bottom: 0.0001pt; line-height: normal;"><span style="font-size: 10pt; font-family: &quot;Courier New&quot;; color: blue;">&lt;</span><span style="font-size: 10pt; font-family: &quot;Courier New&quot;; color: rgb(163, 21, 21);">add</span><span style="font-size: 10pt; font-family: &quot;Courier New&quot;; color: blue;"> </span><span style="font-size: 10pt; font-family: &quot;Courier New&quot;; color: red;">key</span><span style="font-size: 10pt; font-family: &quot;Courier New&quot;; color: blue;">=</span><span style="font-size: 10pt; font-family: &quot;Courier New&quot;;">&quot;<span style="color: blue;">&lt;ModuleName&gt;.Publication_Date</span>&quot;<span style="color: blue;"> </span><span style="color: red;">valueType</span><span style="color: blue;">=</span>&quot;<span style="color: blue;">DateTime</span>&quot;<span style="color: blue;"> </span><span style="color: red;">visible</span><span style="color: blue;">=</span>&quot;<span style="color: blue;">True</span>&quot;<span style="color: blue;"> </span><span style="color: red;">searchable</span><span style="color: blue;">=</span>&quot;<span style="color: blue;">True</span>&quot;<span style="color: blue;"> </span><span style="color: red;">sortable</span><span style="color: blue;">=</span>&quot;<span style="color: blue;">True</span>&quot;<span style="color: blue;"> </span><span style="color: red;">defaultValue</span><span style="color: blue;">=</span>&quot;<span style="color: blue;">#Now</span>&quot;<span style="color: blue;">/&gt;<o:p></o:p></span></span></p>
<p class="MsoNormal" style="margin-bottom: 0.0001pt; line-height: normal;"><span style="font-size: 10pt; font-family: &quot;Courier New&quot;; color: blue;">&lt;</span><span style="font-size: 10pt; font-family: &quot;Courier New&quot;; color: rgb(163, 21, 21);">add</span><span style="font-size: 10pt; font-family: &quot;Courier New&quot;; color: blue;"> </span><span style="font-size: 10pt; font-family: &quot;Courier New&quot;; color: red;">key</span><span style="font-size: 10pt; font-family: &quot;Courier New&quot;; color: blue;">=</span><span style="font-size: 10pt; font-family: &quot;Courier New&quot;;">&quot;<span style="color: blue;">&lt;ModuleName&gt;.BlogID</span>&quot;<span style="color: blue;"> </span><span style="color: red;">valueType</span><span style="color: blue;">=</span>&quot;<span style="color: blue;">Guid</span>&quot;<span style="color: blue;"> </span><span style="color: red;">visible</span><span style="color: blue;">=</span>&quot;<span style="color: blue;">False</span>&quot;<span style="color: blue;"> </span><span style="color: red;">searchable</span><span style="color: blue;">=</span>&quot;<span style="color: blue;">True</span>&quot;<span style="color: blue;"> </span><span style="color: red;">sortable</span><span style="color: blue;">=</span>&quot;<span style="color: blue;">True</span>&quot;<span style="color: blue;"> </span><span style="color: red;">defaultValue</span><span style="color: blue;">=</span>&quot;&quot;<span style="color: blue;">/&gt;<o:p></o:p></span></span></p>
<p class="MsoNormal"><span style="font-size: 10pt; line-height: 115%; font-family: &quot;Courier New&quot;; color: blue;">&lt;</span><span style="font-size: 10pt; line-height: 115%; font-family: &quot;Courier New&quot;; color: rgb(163, 21, 21);">add</span><span style="font-size: 10pt; line-height: 115%; font-family: &quot;Courier New&quot;; color: blue;"> </span><span style="font-size: 10pt; line-height: 115%; font-family: &quot;Courier New&quot;; color: red;">key</span><span style="font-size: 10pt; line-height: 115%; font-family: &quot;Courier New&quot;; color: blue;">=</span><span style="font-size: 10pt; line-height: 115%; font-family: &quot;Courier New&quot;;">&quot;<span style="color: blue;">&lt;ModuleName&gt;.Category</span>&quot;<span style="color: blue;"> </span><span style="color: red;">valueType</span><span style="color: blue;">=</span>&quot;<span style="color: blue;">ShortText</span>&quot;<span style="color: blue;"> </span><span style="color: red;">visible</span><span style="color: blue;">=</span>&quot;<span style="color: blue;">True</span>&quot;<span style="color: blue;"> </span><span style="color: red;">searchable</span><span style="color: blue;">=</span>&quot;<span style="color: blue;">True</span>&quot;<span style="color: blue;"> </span><span style="color: red;">sortable</span><span style="color: blue;">=</span>&quot;<span style="color: blue;">True</span>&quot;<span style="color: blue;"> </span><span style="color: red;">defaultValue</span><span style="color: blue;">=</span>&quot;&quot;<span style="color: blue;">&gt;&lt;/</span><span style="color: rgb(163, 21, 21);">add</span><span style="color: blue;">&gt;</span></span><span style=""><o:p></o:p></span></p>
<p class="MsoNormal"><span style="font-size: 10pt; line-height: 115%; font-family: &quot;Courier New&quot;; color: blue;">&lt;/</span><span style="font-size: 10pt; line-height: 115%; font-family: &quot;Courier New&quot;; color: rgb(163, 21, 21);">metafields</span><span style="">&gt;<o:p></o:p></span></p>
<p class="MsoNormal"><span style="">Here is a breakdown of the properties:<o:p></o:p></span></p>
<p class="MsoNormal"><span style="">Key: This is the name of your module, then a period, then the name of the field. <o:p></o:p></span></p>
<p class="MsoNormal"><span style="">ValueType: This property will depend on the type you set in your I&lt;ModuleName&gt;.cs file. If you set the type to GUID, then the value type will be GUID. This property should be short text for a paragraph under 256 characters and long text if it is above 256 characters. <o:p></o:p></span></p>
<p class="MsoNormal"><span style="">Visible: This property should be true, unless this field is an ID column which should not be edited. If the valueType property is GUID, then the visible property should be false.<o:p></o:p></span></p>
<p class="MsoNormal"><span style="">Searchable: If you would like your end user to search this property in the admin when in this module, then set this property to true. In the blogs module, as an example, you can search blogs by title.<o:p></o:p></span></p>
<p class="MsoNormal"><span style="">Sortable: In the grid for the module in the admin, this will make the field sortable.<o:p></o:p></span></p>
<p class="MsoNormal"><span style="">DefaultValue: This property is set to null, unless you want a value to be added all the time<o:p></o:p></span></p>
<h4><span style="">Public and Private Templates<o:p></o:p></span></h4>
<p class="MsoNormal"><span style="">So your end user can use the control on the page, you will need a public template. Generally, this consists of a repeater control with a series of controls inheriting from the ItextControl Interface. Sitefinity mainly uses literal and label controls and binds their ID property to a datafield. In the blogs module, you could bind a label control to the autor field like this:<o:p></o:p></span></p>
<p class="MsoNormal"><span style="">&lt;asp:Label ID=&rdquo;Author&rdquo; runat=&rdquo;server&rdquo;&gt;&lt;/asp:label&gt;<o:p></o:p></span></p>
<p class="MsoNormal"><span style="">When you are in the blogs module, you omit the word blogs and just use the word after the period.<o:p></o:p></span></p>
<p class="MsoNormal"><span style="">The private templates are for users who click on the modules tab in the admin. These templates are used to add content to the modules and set permissions. Generally, you would only want to edit the templates that a person uses to add content. Adding and removing fields in the same as the public templates. Just add a label, as an example, and give its ID property a name from the meta fields section of the web.config. <o:p></o:p></span></p>
<h3><span style="">Copy to Sitefinity<o:p></o:p></span></h3>
<p class="MsoNormal">To deploy your module, you must copy the module theme, the newly created bin files and the templates by following these instructions:</p>
<ul type="disc" style="margin-top: 0in;">
    <li class="MsoNormal" style="">Add a reference in your      Sitefinity web project to the new &lt;CompanyName&gt;.&lt;ModuleName&gt;      and &lt;CompanyName&gt;.&lt;ModuleName&gt;.Data assemblies or projects.</li>
    <li class="MsoNormal" style="">Copy      &lt;CompanyName&gt;.&lt;ModuleName&gt;.Website\Admin\ControlTemplates\&lt;ModuleName&gt;      to your <i style="">Sitefinity directory</i>\Admin\ControlTemplates\&lt;ModuleName&gt;</li>
    <li class="MsoNormal" style="">Copy      &lt;CompanyName&gt;.&lt;ModuleName&gt;.Website\ControlTemplates\&lt;ModuleName&gt;      to your <i style="">Sitefinity directory</i>\      ControlTemplates\&lt;ModuleName&gt;</li>
    <li class="MsoNormal" style="">Copy      &lt;CompanyName&gt;.&lt;ModuleName&gt;.Website\Admin\Themes\Default\ to      your <i style="">Sitefinity directory</i>\Admin\Themes\Default\</li>
</ul>
<h1><a name="_Ref200941374">Sample Solution Structure</a></h1>
<p class="MsoNormal">&lt;CompanyName&gt;.&lt;ModuleName&gt;</p>
<p class="MsoListParagraphCxSpFirst" style="text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: Symbol;"><span style="">&middot;<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><!--[endif]-->Properties</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left: 1in; text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: &quot;Courier New&quot;;"><span style="">o<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp; </span></span></span><!--[endif]-->AssemblyInfo.cs</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: Symbol;"><span style="">&middot;<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><!--[endif]-->References</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left: 1in; text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: &quot;Courier New&quot;;"><span style="">o<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp; </span></span></span><!--[endif]-->RadComboNox.Net2 <a style="" href="#_edn1" name="_ednref1" title=""><span class="MsoEndnoteReference"><span style=""><!--[if !supportFootnotes]--><span class="MsoEndnoteReference"><span style="font-size: 11pt; line-height: 115%; font-family: &quot;Calibri&quot;,&quot;sans-serif&quot;;">[i]</span></span><!--[endif]--></span></span></a></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left: 1in; text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: &quot;Courier New&quot;;"><span style="">o<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp; </span></span></span><!--[endif]-->RadGrid.Net2<a style="" href="#_edn2" name="_ednref2" title=""><span class="MsoEndnoteReference"><span style=""><!--[if !supportFootnotes]--><span class="MsoEndnoteReference"><span style="font-size: 11pt; line-height: 115%; font-family: &quot;Calibri&quot;,&quot;sans-serif&quot;;">[ii]</span></span><!--[endif]--></span></span></a></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left: 1in; text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: &quot;Courier New&quot;;"><span style="">o<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp; </span></span></span><!--[endif]-->RadMenu.Net2<a style="" href="#_edn3" name="_ednref3" title=""><span class="MsoEndnoteReference"><span style=""><!--[if !supportFootnotes]--><span class="MsoEndnoteReference"><span style="font-size: 11pt; line-height: 115%; font-family: &quot;Calibri&quot;,&quot;sans-serif&quot;;">[iii]</span></span><!--[endif]--></span></span></a></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left: 1in; text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: &quot;Courier New&quot;;"><span style="">o<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp; </span></span></span><!--[endif]-->RadTreeView.Net2 <a style="" href="#_edn4" name="_ednref4" title=""><span class="MsoEndnoteReference"><span style=""><!--[if !supportFootnotes]--><span class="MsoEndnoteReference"><span style="font-size: 11pt; line-height: 115%; font-family: &quot;Calibri&quot;,&quot;sans-serif&quot;;">[iv]</span></span><!--[endif]--></span></span></a></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left: 1in; text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: &quot;Courier New&quot;;"><span style="">o<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp; </span></span></span><!--[endif]-->System</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left: 1in; text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: &quot;Courier New&quot;;"><span style="">o<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp; </span></span></span><!--[endif]-->System.configuration</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left: 1in; text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: &quot;Courier New&quot;;"><span style="">o<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp; </span></span></span><!--[endif]-->System.Data</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left: 1in; text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: &quot;Courier New&quot;;"><span style="">o<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp; </span></span></span><!--[endif]-->System.Drawing</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left: 1in; text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: &quot;Courier New&quot;;"><span style="">o<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp; </span></span></span><!--[endif]-->System.Web</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left: 1in; text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: &quot;Courier New&quot;;"><span style="">o<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp; </span></span></span><!--[endif]-->System.Xml</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left: 1in; text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: &quot;Courier New&quot;;"><span style="">o<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp; </span></span></span><!--[endif]-->Telerik.Cms</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left: 1in; text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: &quot;Courier New&quot;;"><span style="">o<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp; </span></span></span><!--[endif]-->Telerik.Cms.Web.UI</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left: 1in; text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: &quot;Courier New&quot;;"><span style="">o<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp; </span></span></span><!--[endif]-->Telerik.Framework</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left: 1in; text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: &quot;Courier New&quot;;"><span style="">o<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp; </span></span></span><!--[endif]-->Telerik.Security</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: Symbol;"><span style="">&middot;<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><!--[endif]-->Configuration</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left: 1in; text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: &quot;Courier New&quot;;"><span style="">o<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp; </span></span></span><!--[endif]-->ConfigurationHelper.cs</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left: 1in; text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: &quot;Courier New&quot;;"><span style="">o<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp; </span></span></span><!--[endif]-->SectionHandler.cs</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: Symbol;"><span style="">&middot;<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><!--[endif]-->Resources</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left: 1in; text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: &quot;Courier New&quot;;"><span style="">o<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp; </span></span></span><!--[endif]-->CommandPanel.js</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left: 1in; text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: &quot;Courier New&quot;;"><span style="">o<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp; </span></span></span><!--[endif]-->Messages.resx</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: Symbol;"><span style="">&middot;<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><!--[endif]-->Security</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left: 1in; text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: &quot;Courier New&quot;;"><span style="">o<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp; </span></span></span><!--[endif]-->GlobalPermission.cs</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left: 1in; text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: &quot;Courier New&quot;;"><span style="">o<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp; </span></span></span><!--[endif]-->GlobalPermissions.cs</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: Symbol;"><span style="">&middot;<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><!--[endif]-->WebControls</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left: 1in; text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: &quot;Courier New&quot;;"><span style="">o<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp; </span></span></span><!--[endif]-->Admin</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left: 1.5in; text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: Wingdings;"><span style="">&sect;<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp; </span></span></span><!--[endif]-->AlphabetLinks.cs <a style="" href="#_edn5" name="_ednref5" title=""><span class="MsoEndnoteReference"><span style=""><!--[if !supportFootnotes]--><span class="MsoEndnoteReference"><span style="font-size: 11pt; line-height: 115%; font-family: &quot;Calibri&quot;,&quot;sans-serif&quot;;">[v]</span></span><!--[endif]--></span></span></a></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left: 1.5in; text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: Wingdings;"><span style="">&sect;<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp; </span></span></span><!--[endif]-->CommandPanel.cs</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left: 1.5in; text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: Wingdings;"><span style="">&sect;<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp; </span></span></span><!--[endif]-->&lt;ModuleName&gt;Editor.cs</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left: 1.5in; text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: Wingdings;"><span style="">&sect;<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp; </span></span></span><!--[endif]-->ControlPanel.cs</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left: 1in; text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: &quot;Courier New&quot;;"><span style="">o<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp; </span></span></span><!--[endif]-->&lt;ModuleName&gt;List.cs</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left: 1in; text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: &quot;Courier New&quot;;"><span style="">o<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp; </span></span></span><!--[endif]-->&lt;ModuleName&gt;ListToolboxItem.cs</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left: 1in; text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: &quot;Courier New&quot;;"><span style="">o<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp; </span></span></span><!--[endif]-->Single&lt;ModuleName&gt;.cs</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left: 1in; text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: &quot;Courier New&quot;;"><span style="">o<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp; </span></span></span><!--[endif]-->Single&lt;ModuleName&gt;ToolboxItem.cs</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: Symbol;"><span style="">&middot;<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><!--[endif]-->&lt;ModuleName&gt;Manager.cs</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: Symbol;"><span style="">&middot;<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><!--[endif]-->&lt;ModuleName&gt;.Module.cs</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: Symbol;"><span style="">&middot;<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><!--[endif]-->&lt;ModuleName&gt;Provider.cs</p>
<p class="MsoListParagraphCxSpLast" style="text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: Symbol;"><span style="">&middot;<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><!--[endif]-->I&lt;ModuleName&gt;.cs</p>
<p class="MsoNormal" style="line-height: normal;">&lt;CompanyName&gt;.&lt;ModuleName&gt;.Data</p>
<p class="MsoListParagraphCxSpFirst" style="text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: Symbol;"><span style="">&middot;<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><!--[endif]-->Properties</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left: 1in; text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: &quot;Courier New&quot;;"><span style="">o<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp; </span></span></span><!--[endif]-->AssemblyInfo.cs</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: Symbol;"><span style="">&middot;<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><!--[endif]-->References</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left: 1in; text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: &quot;Courier New&quot;;"><span style="">o<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp; </span></span></span><!--[endif]-->Nolics.Engine.v4.2 <a style="" href="#_edn6" name="_ednref6" title=""><span class="MsoEndnoteReference"><span style=""><!--[if !supportFootnotes]--><span class="MsoEndnoteReference"><span style="font-size: 11pt; line-height: 115%; font-family: &quot;Calibri&quot;,&quot;sans-serif&quot;;">[vi]</span></span><!--[endif]--></span></span></a></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left: 1in; text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: &quot;Courier New&quot;;"><span style="">o<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp; </span></span></span><!--[endif]-->&lt;CompanyName&gt;.&lt;ModuleName&gt;</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left: 1in; text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: &quot;Courier New&quot;;"><span style="">o<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp; </span></span></span><!--[endif]-->System</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left: 1in; text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: &quot;Courier New&quot;;"><span style="">o<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp; </span></span></span><!--[endif]-->System.configuration</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left: 1in; text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: &quot;Courier New&quot;;"><span style="">o<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp; </span></span></span><!--[endif]-->System.Data</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left: 1in; text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: &quot;Courier New&quot;;"><span style="">o<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp; </span></span></span><!--[endif]-->System.Xml</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left: 1in; text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: &quot;Courier New&quot;;"><span style="">o<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp; </span></span></span><!--[endif]-->Telerik.DataAccess</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left: 1in; text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: &quot;Courier New&quot;;"><span style="">o<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp; </span></span></span><!--[endif]-->Telerik.Framework</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left: 1in; text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: &quot;Courier New&quot;;"><span style="">o<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp; </span></span></span><!--[endif]-->Telerik.Security</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: Symbol;"><span style="">&middot;<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><!--[endif]-->Resources</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left: 1in; text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: &quot;Courier New&quot;;"><span style="">o<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp; </span></span></span><!--[endif]-->Messages.resx</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: Symbol;"><span style="">&middot;<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><!--[endif]-->&lt;ModuleName&gt;.cs<span style="">&nbsp; </span><a style="" href="#_edn7" name="_ednref7" title=""><span class="MsoEndnoteReference"><span style=""><!--[if !supportFootnotes]--><span class="MsoEndnoteReference"><span style="font-size: 11pt; line-height: 115%; font-family: &quot;Calibri&quot;,&quot;sans-serif&quot;;">[vii]</span></span><!--[endif]--></span></span></a></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: Symbol;"><span style="">&middot;<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><!--[endif]-->&lt;TableName&gt;.dbclass</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: Symbol;"><span style="">&middot;<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><!--[endif]-->DefaultProvider.cs</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left: 0in; line-height: normal;">&lt;CompanyName&gt;.&lt;ModuleName&gt;.Website</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: Symbol;"><span style="">&middot;<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><!--[endif]-->Admin</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left: 1in; text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: &quot;Courier New&quot;;"><span style="">o<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp; </span></span></span><!--[endif]-->ControlTemplates</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left: 1.5in; text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: Wingdings;"><span style="">&sect;<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp; </span></span></span><!--[endif]-->&lt;ModuleName&gt;</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left: 2in; text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: Symbol;"><span style="">&middot;<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><!--[endif]-->CommandPanelTemplate.ascx</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left: 2in; text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: Symbol;"><span style="">&middot;<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><!--[endif]-->&lt;ModuleName&gt;EditorTemplate.ascx</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left: 2in; text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: Symbol;"><span style="">&middot;<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><!--[endif]-->&lt;ModuleName&gt;sPermissions.ascx</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left: 2in; text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: Symbol;"><span style="">&middot;<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><!--[endif]-->ControlPanelInsertEditTemplate.ascx</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left: 2in; text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: Symbol;"><span style="">&middot;<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><!--[endif]-->ControlPanelListTemplate.ascx</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left: 2.5in; text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: &quot;Courier New&quot;;"><span style="">o<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp; </span></span></span><!--[endif]-->App_LocalResources</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left: 3in; text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: Wingdings;"><span style="">&sect;<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp; </span></span></span><!--[endif]-->Any resource files</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left: 1in; text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: &quot;Courier New&quot;;"><span style="">o<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp; </span></span></span><!--[endif]-->Themes</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left: 1.5in; text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: Wingdings;"><span style="">&sect;<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp; </span></span></span><!--[endif]-->Default</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left: 2in; text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: Symbol;"><span style="">&middot;<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><!--[endif]-->Modules.css</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: Symbol;"><span style="">&middot;<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><!--[endif]-->ControlTemplates</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left: 1in; text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: &quot;Courier New&quot;;"><span style="">o<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp;&nbsp; </span></span></span><!--[endif]-->&lt;ModuleName&gt;</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left: 1.5in; text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: Wingdings;"><span style="">&sect;<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp; </span></span></span><!--[endif]-->&lt;ModuleName&gt;sListTemplate.ascx</p>
<p class="MsoListParagraphCxSpLast" style="margin-left: 1.5in; text-indent: -0.25in; line-height: normal;"><!--[if !supportLists]--><span style="font-family: Wingdings;"><span style="">&sect;<span style="font-family: &quot;Times New Roman&quot;; font-style: normal; font-variant: normal; font-weight: normal; font-size: 7pt; line-height: normal; font-size-adjust: none; font-stretch: normal;">&nbsp; </span></span></span><!--[endif]-->Single&lt;ModuleName&gt;Template.ascx</p>
<div style=""><!--[if !supportEndnotes]--><br clear="all" />
<hr width="33%" size="1" align="left" />
<!--[endif]-->
<div style="" id="edn1">
<p class="MsoEndnoteText" style="line-height: normal;"><a style="" href="#_ednref1" name="_edn1" title=""><span class="MsoEndnoteReference"><span style=""><!--[if !supportFootnotes]--><span class="MsoEndnoteReference"><span style="font-size: 10pt; line-height: 115%; font-family: &quot;Calibri&quot;,&quot;sans-serif&quot;;">[i]</span></span><!--[endif]--></span></span></a> Optional, only required if you controls/templates use this control and you are licensed to use it.</p>
</div>
<div style="" id="edn2">
<p class="MsoEndnoteText" style="line-height: normal;"><a style="" href="#_ednref2" name="_edn2" title=""><span class="MsoEndnoteReference"><span style=""><!--[if !supportFootnotes]--><span class="MsoEndnoteReference"><span style="font-size: 10pt; line-height: 115%; font-family: &quot;Calibri&quot;,&quot;sans-serif&quot;;">[ii]</span></span><!--[endif]--></span></span></a> Optional, only required if you controls/templates use this control and you are licensed to use it.</p>
</div>
<div style="" id="edn3">
<p class="MsoEndnoteText" style="line-height: normal;"><a style="" href="#_ednref3" name="_edn3" title=""><span class="MsoEndnoteReference"><span style=""><!--[if !supportFootnotes]--><span class="MsoEndnoteReference"><span style="font-size: 10pt; line-height: 115%; font-family: &quot;Calibri&quot;,&quot;sans-serif&quot;;">[iii]</span></span><!--[endif]--></span></span></a> Optional, only required if you controls/templates use this control and you are licensed to use it.</p>
</div>
<div style="" id="edn4">
<p class="MsoEndnoteText" style="line-height: normal;"><a style="" href="#_ednref4" name="_edn4" title=""><span class="MsoEndnoteReference"><span style=""><!--[if !supportFootnotes]--><span class="MsoEndnoteReference"><span style="font-size: 10pt; line-height: 115%; font-family: &quot;Calibri&quot;,&quot;sans-serif&quot;;">[iv]</span></span><!--[endif]--></span></span></a> Optional, only required if you controls/templates use this control and you are licensed to use it.</p>
</div>
<div style="" id="edn5">
<p class="MsoEndnoteText" style="line-height: normal;"><a style="" href="#_ednref5" name="_edn5" title=""><span class="MsoEndnoteReference"><span style=""><!--[if !supportFootnotes]--><span class="MsoEndnoteReference"><span style="font-size: 10pt; line-height: 115%; font-family: &quot;Calibri&quot;,&quot;sans-serif&quot;;">[v]</span></span><!--[endif]--></span></span></a> Optional, only if you wish to implement this command panel control.</p>
</div>
<div style="" id="edn6">
<p class="MsoEndnoteText" style="line-height: normal;"><a style="" href="#_ednref6" name="_edn6" title=""><span class="MsoEndnoteReference"><span style=""><!--[if !supportFootnotes]--><span class="MsoEndnoteReference"><span style="font-size: 10pt; line-height: 115%; font-family: &quot;Calibri&quot;,&quot;sans-serif&quot;;">[vi]</span></span><!--[endif]--></span></span></a> Optional, only if you use the Nolics library for data access.</p>
</div>
<div style="" id="edn7">
<p class="MsoEndnoteText" style="line-height: normal;"><a style="" href="#_ednref7" name="_edn7" title=""><span class="MsoEndnoteReference"><span style=""><!--[if !supportFootnotes]--><span class="MsoEndnoteReference"><span style="font-size: 10pt; line-height: 115%; font-family: &quot;Calibri&quot;,&quot;sans-serif&quot;;">[vii]</span></span><!--[endif]--></span></span></a> Optional, only if you want to add additional data access methods to the Nolics&rsquo; generated class.</p>
</div>
</div>