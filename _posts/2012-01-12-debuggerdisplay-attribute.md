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
Have you ever tried to debug an application and wish the Visual Studio debugger did not display {<em>Namespace</em>.<em>ObjectName</em>} when you wanted to see some of the details of the objects?

<a href="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/image_5.png"><img style="display: inline; border-width: 0px;" title="image" src="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/image_thumb_4.png" alt="image" width="389" height="160" border="0" /></a>

Visual Studio has an attribute that you can add to a class to inform the debugger what to display when it is displaying that class in the debugger. As you probably guessed the attribute is called <a href="http://msdn.microsoft.com/en-us/library/system.diagnostics.debuggerdisplayattribute.aspx" target="_blank">DebuggerDisplay</a>.
<h2>How to Implement</h2>
Let’s say we have a simple class called Person, the Person class has 4 properties; FirstName, MiddleName, LastName and FullName. Here is the definition:
[csharp]
public class Person
{
	public string FirstName { get; set; }
	public string MiddleName { get; set; }
	public string LastName { get; set; }    
	public string FullName
  	{
    	get
		{
			return string.Format(&quot;{0} {1}{2}&quot;, 
				FirstName, 
				(string.IsNullOrEmpty(MiddleName)) ? string.Empty : MiddleName + &quot; &quot;, 
				LastName);
    	}
	}
}
[/csharp]

Next, let’s assume we want to display the first and last name of the person when debugging. We first need to add the DebuggerDisplay attribute to our class. The DebuggerDisplay attribute can be found in the <a href="http://msdn.microsoft.com/en-us/library/15t15zda.aspx" target="_blank">System.Diagnosis</a> class of the .NET framework. The DebuggerDisplay works almost like the string.Format method, except you replace the numbers with the property / method names you want to display.

Example:
[csharp]
[DebuggerDisplay(&quot;FirstName={FirstName} LastName={LastName}&quot;)]
[/csharp]
This will tell the debugger to display the string <em>FirstName=</em> with the value of the <strong>FirstName</strong> field in double quotes followed by <em>LastName=</em> with the value of the <strong>LastName</strong> field in double quotes every time it needs to display a person object. Here is our new class:
[csharp]
[DebuggerDisplay(&quot;FirstName={FirstName} LastName={LastName}&quot;)]
public class Person
{
  public string FirstName { get; set; }
  public string MiddleName { get; set; }
  public string LastName { get; set; }    
  public string FullName
  {
    get
    {
      return string.Format(&quot;{0} {1}{2}&quot;, FirstName,
          (string.IsNullOrEmpty(MiddleName)) ? string.Empty : MiddleName + &quot;&quot;, 
          LastName);
    }
  }
}
[/csharp]

This will display like so:

<a href="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/image_6.png"><img style="display: inline; border-width: 0px;" title="image" src="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/image_thumb_5.png" alt="image" width="417" height="121" border="0" /></a>

You’ll notice this makes it easier to see what you are looking at. It also works in the immediate window.

<a href="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/image_7.png"><img style="display: inline; border-width: 0px;" title="image" src="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/image_thumb_6.png" alt="image" width="426" height="157" border="0" /></a>
<h2>Summary</h2>
You can use more than just field names. Method calls can be done (although probably not the best) and some calculations. Take a look at the MSDN documentation for the <a href="http://msdn.microsoft.com/en-us/library/system.diagnostics.debuggerdisplayattribute.aspx" target="_blank">DebuggerDisplay</a> attribute for more information.

There is also an article titled <a href="http://blogs.msdn.com/b/jaredpar/archive/2011/03/18/debuggerdisplay-attribute-best-practices.aspx" target="_blank">DebuggerDisplay attribute best practices</a> that you should read also.