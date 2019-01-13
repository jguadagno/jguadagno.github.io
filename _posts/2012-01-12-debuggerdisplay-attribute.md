---
id: 331
title: DebuggerDisplay Attribute
date: 2012-01-12T17:49:00+00:00
author: Joseph Guadagno
layout: post
guid: http://www.josephguadagno.net/post.aspx?id=a420932e-458e-4ad1-be7f-5a1eddc75c53
permalink: /2012/01/12/debuggerdisplay-attribute/
dsq_thread_id:
  - "3617067418"
categories:
  - Articles
---
Have you ever tried to debug an application and wish the Visual Studio debugger did not display {_Namespace_._ObjectName_} when you wanted to see some of the details of the objects? [![image](http://1222-7915.el-alt.com/wp-content/uploads/2015/03/image_thumb_4.png "image")](http://1222-7915.el-alt.com/wp-content/uploads/2015/03/image_5.png) Visual Studio has an attribute that you can add to a class to inform the debugger what to display when it is displaying that class in the debugger. As you probably guessed the attribute is called [DebuggerDisplay](http://msdn.microsoft.com/en-us/library/system.diagnostics.debuggerdisplayattribute.aspx).

## How to Implement

Let’s say we have a simple class called Person, the Person class has 4 properties; FirstName, MiddleName, LastName, and FullName. Here is the definition:

{% gist jguadagno/47701ab9f7ee89827e451b0083c5fc45 %}

Next, let’s assume we want to display the first and last name of the person when debugging. We first need to add the DebuggerDisplay attribute to our class. The DebuggerDisplay attribute can be found in the [System.Diagnosis](http://msdn.microsoft.com/en-us/library/15t15zda.aspx) class of the .NET framework. The DebuggerDisplay works almost like the string.Format method, except you, replace the numbers with the property/method names you want to display. Example: 

{% gist jguadagno/c13c6c87e6886e077083eec0a47026df %}

This will tell the debugger to display the string _FirstName=_ with the value of the **FirstName** field in double quotes followed by _LastName=_ with the value of the **LastName** field in double quotes every time it needs to display a person object. Here is our new class:

{% gist jguadagno/ae4a5f9470c81254ca23eaa7b0c04e57 %}

This will display like so: [![image](http://1222-7915.el-alt.com/wp-content/uploads/2015/03/image_thumb_5.png "image")](http://1222-7915.el-alt.com/wp-content/uploads/2015/03/image_6.png) You’ll notice this makes it easier to see what you are looking at. It also works in the immediate window. [![image](http://1222-7915.el-alt.com/wp-content/uploads/2015/03/image_thumb_6.png "image")](http://1222-7915.el-alt.com/wp-content/uploads/2015/03/image_7.png)

## Summary

You can use more than just field names. Method calls can be done (although probably not the best) and some calculations. Take a look at the MSDN documentation for the [DebuggerDisplay](http://msdn.microsoft.com/en-us/library/system.diagnostics.debuggerdisplayattribute.aspx) attribute for more information. There is also an article titled [DebuggerDisplay attribute best practices](http://blogs.msdn.com/b/jaredpar/archive/2011/03/18/debuggerdisplay-attribute-best-practices.aspx) that you should read also.