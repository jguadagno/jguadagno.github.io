---
id: 1121
title: How do I format my GridView bound column differently?
date: 2007-11-06T07:04:33+00:00
author: Joseph Guadagno
layout: post
guid: http://www.josephguadagno.net/post.aspx?id=42dd5660-0792-402d-8c2a-81c5ea7d5582
permalink: /2007/11/06/how-do-i-format-my-gridview-bound-column-differently/
categories:
  - Articles
---
Replace the _ColumnName_ value with the name of your column. Replace DataFormatString property with the format string of your choosing.  A good reference for .NET string formats is available at [http://john-sheehan.com/blog/index.php/net-cheat-sheets/](http://john-sheehan.com/blog/index.php/net-cheat-sheets/)

{% gist jguadagno/dcce8640638a9aa83d17110524f8cb97 %}