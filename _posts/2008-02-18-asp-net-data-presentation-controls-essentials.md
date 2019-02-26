---
title: ASP.NET Data Presentation Controls Essentials
date: 2008-02-18T16:00:00+00:00
author: Joseph Guadagno
permalink: /2008/02/18/asp-net-data-presentation-controls-essentials/
categories:
  - Books
---
The book is a good starting point for people that was to learn the different ways of binding data from supported sources to ASP.NET controls.  The author does a pretty good job of explaining the basics of some of the data bindable controls like ListBox, DropDownList, etc.  There are whole chapters dedicated to the Repeater, DataList, DataGrid and DataView controls.

Unfortunately there are a few things that I did not like about the book. The first was the code, there were quite a few places where the code was not correct there were typos or incorrect characters to delimited strings. There where several locations in the code where double angle brackets (« ») where used for strings instead of double quotes (").  Some of the code samples provided for the DataManager class were susceptible to SQL Injection attacks. Now I understand it is a sample but a little disclaimed should be made to break habits.  One last thing, some of code could benefit from some refactoring.

Overall, I think this books would be could a good reference point for data binding in Microsoft ASP.NET.

The website for the book: [http://www.packtpub.com/asp-net-data-presentation-controls/book](http://www.packtpub.com/asp-net-data-presentation-controls/book)