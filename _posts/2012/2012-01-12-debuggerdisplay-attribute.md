---
title: DebuggerDisplay Attribute
date: 2012-01-12T17:49:00+00:00
permalink: /2012/01/12/debuggerdisplay-attribute/
dsq_thread_id:
  - "3617067418"
categories:
  - Articles
tags:
  - Visual Studio
  - .NET
---
Have you ever tried to debug an application and wish the Visual Studio debugger did not display `{Namespace.ObjectName}` when you wanted to see some of the details of the objects?

[![image](/assets/images/posts/image_thumb_4.png "image")](/assets/images/posts/image_5.png)

Visual Studio has an attribute that you can add to a class to inform the debugger what to display when it is displaying that class in the debugger. As you probably guessed the attribute is called [DebuggerDisplay](https://msdn.microsoft.com/en-us/library/system.diagnostics.debuggerdisplayattribute.aspx?WT.mc_id=DT-MVP-4024623){:target="_blank"}.

## How to Implement

Let's say we have a simple class called `Person`, the Person class has 4 properties; `FirstName`, `MiddleName`, `LastName`, and `FullName`. Here is the definition:

```cs
public class Person
{
  public string FirstName { get; set; }
  public string MiddleName { get; set; }
  public string LastName { get; set; }
  public string FullName
  {
    get
    {
      return string.Format("{0} {1}{2}",
        FirstName,
        (string.IsNullOrEmpty(MiddleName)) ? string.Empty : MiddleName + " ",
        LastName);
    }
  }
}
```

Next, let's assume we want to display the first and last name of the person when debugging. We first need to add the DebuggerDisplay attribute to our class. The DebuggerDisplay attribute can be found in the [System.Diagnosis](https://msdn.microsoft.com/en-us/library/15t15zda.aspx?WT.mc_id=DT-MVP-4024623){:target="_blank"} class of the .NET framework. The DebuggerDisplay works almost like the string.Format method, except you, replace the numbers with the property/method names you want to display. Example:

```cs
[DebuggerDisplay("FirstName={FirstName} LastName={LastName}")]
```

This will tell the debugger to display the string _FirstName=_ with the value of the `FirstName` field in double quotes followed by `LastName=` with the value of the `LastName` field in double-quotes every time it needs to display a person object. Here is our new class:

```cs
[DebuggerDisplay("FirstName={FirstName} LastName={LastName}")]
public class Person
{
  public string FirstName { get; set; }
  public string MiddleName { get; set; }
  public string LastName { get; set; }
  public string FullName
  {
    get
    {
      return string.Format("{0} {1}{2", FirstName,
          (string.IsNullOrEmpty(MiddleName)) ? string.Empty : MiddleName + " ",
          LastName);
    }
  }
}
```

This will display like so:

[![image](/assets/images/posts/image_thumb_5.png "image")](/assets/images/posts/image_6.png)

You'll notice this makes it easier to see what you are looking at. It also works in the immediate window.

[![image](/assets/images/posts/image_thumb_6.png "image")](/assets/images/posts/image_7.png)

## Summary

You can use more than just field names. Method calls can be done (although probably not the best) and some calculations. Take a look at the MSDN documentation for the [DebuggerDisplay](https://msdn.microsoft.com/en-us/library/system.diagnostics.debuggerdisplayattribute.aspx?WT.mc_id=DT-MVP-4024623){:target="_blank"} attribute for more information. There is also an article titled [DebuggerDisplay attribute best practices](https://blogs.msdn.com/b/jaredpar/archive/2011/03/18/debuggerdisplay-attribute-best-practices.aspx){:target="_blank"} that you should read also.
