---
title: "What Was Added To C# 10"
header:
    og_image: /assets/images/posts/header/what-was-added-to-csharp10.png
redirect_from:
  - /2021/12/02/what-was-added-to-c#-10
date: 2021-12-02 21:30:00 -0700
categories:
  - Articles
  - Archive
tags:
  - .NET
  - Namespaces
  - Interpolation
  - CallerArgumentExpression
  - Pattern Matching
  - dotnet
  - csharp
---
**Note:** This post was originally posted on the Telerik [blog](https://www.telerik.com/blogs/what-was-added-csharp-10){:target="_blank"}
{: .notice--info}

In a previous [post](https://www.telerik.com/blogs/what-i-like-about-csharp-9){:target="_blank"}, I talked about all of the new features of C# 9. With the release of .NET 6 recently, I wanted to share some of the new language features of C# 10.

Let's take a look at some of the new language features.

## Saving Time

.NET added quite a few features to the language that can save you a lot of time.  

### File-Scoped Namespaces

In my opinion, file-scoped namespaces are a great way to organize your code. They allow you to organize your code into logical groups and keep your code from being too cluttered.

File-Scoped namespaces allow you to save some keystrokes and indentation in your code. Now, you can declare your namespace at the top of your file, assuming you only have one namespace for your file. Which I believe you should always do.

Old Code:

```csharp
namespace MyNamespace
{
  class MyClass
  {
    public void MyMethod()
    {
        // ...
    }
  }
}
```

Now becomes:

```csharp
namespace MyNamespace;

class MyClass
{
  public void MyMethod()
  {
      // ...
  }
}
```

Now we save 2 curly braces and 1 indentation level. I kind of wish this feature was in .NET 1, since you really should only have one namespace per file :smile:.

### Global Using Directives

How often do you see or type the same namespaces over and over again? `using System;`, for me, is declared in almost every file in my project. With C# 10s {:target="_blank"} you can declare your using directives at the top of your file and then use them throughout your file. Now I can add `global using System;` to one file in my project, and the `using` statement will be *referenced* throughout all my files/classes.

I see myself using the following code in my project regularly now:

```csharp
global using System;
global using System.Collections.Generic;
global using System.Linq;
```

While not required, I recommend that you place all of your global using directives in a standard filename across your projects.  I plan on using `GlobalUsings.cs` but feel free to use whatever you want.

If putting your `global using` directives in a file is not your thing, you can also add then to your `.csproj` file. If I wanted to include the three `global using` directives above in my `.csproj` file, I would add the following to my `.csproj` file:

```csharp
<ItemGroup>
  <Using Include="System" />
  <Using Include="System.Collections.Generic" />
  <Using Include="System.Linq" />
</ItemGroup>
```

Either approach will work, but the `.csproj` approach seems to be easier to discover.

If `global using` is not your or your teams thing, you can disable it by adding the following to your `.csproj` file:

```csharp
<PropertyGroup>
  <ImplicitUsings>disable</ImplicitUsings> // Can also be set to `false`
</PropertyGroup>
```

### Extended Property Patterns

[Pattern Matching](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/patterns?wt.mc_id=DT-MVP-4024623){:target="_blank"} was introduced in C# 7. It allows you to match the properties of an object against a pattern. Pattern matching is a great way to write cleaner code. In C# 8, the [Property Patterns](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/pattern-matching?wt.mc_id=DT-MVP-4024623){:target="_blank"} feature was added, which enabled you to match against properties of an object like this:

```csharp
Person person = new Person {
  FirstName = "Joe",
  LastName = "Guadagno",
  Address = new Address {
    City = "Chandler",
    State = "AZ"
  }
}

// Other code

if (person is Person {Address: {State: "AZ"}})
{
  // Do something
}
```

Now with C# 10, you can reference nested properties of objects with dot notation.  For example, you can match against the `City` and `State` properties of a `Person` object like this:

```csharp
if (person is Person {Address.State: "AZ"})
{
  // Do something
}
```

## String Improvements

C# 10 made improvements to interpolated strings in C# 10. `const` variables can now be used with interpolated strings.

I have trouble finding a "*real world*" example of this, so here is an example of how it works:

```csharp
const string greeting = "Hello";
const string name = "Joe";
const string message = $"{greeting}, {name}!";
```

The `message` variable will be the value of `Hello, Joe!`.

Interpolated has not just been improved for `const`s but for variables that can be determined at compile time.  Let's say you maintain a library, and you decide to obsolete a method named `OldMethod`. In the past, you would have to do something like this:

```cs
public class MyClass
{
    [Obsolete($"Use NewMethod instead", true)]
    public void OldMethod() { }

    public void NewMethod() { }
}
```

But now, you can do this:

```cs
public class MyClass
{
    [Obsolete($"Use {nameof(NewMethod)} instead", true)]
    public void OldMethod() { }

    public void NewMethod() { }
}
```

This makes it easier to update your code when you need to. Now you don't have to remember everywhere you used *hardcoded* name of the method you want to obsolete.

## CallerArgumentExpression

`CallerArgumentExpression` attribute is a new feature of C# 10 that enables you to capture the expression that is passed into a method which is useful for debugging purposes.

Let's say we have a method called `IsValid` that checks and validates assorted properties of a `Person` object.

```csharp
public static class Validation {
  public static book IsValid(Person person)
  {
    Debug.Assert(person != null);
    Debug.Assert(!string.IsNullOrEmpty(person.FirstName));
    Debug.Assert(!string.IsNullOrEmpty(person.LastName));
    Debug.Assert(!string.IsNullOrEmpty(person.Address.City));
    Debug.Assert(person.Age > 18);
    return true;
  }
}
```

Now we have the following code that calls the `IsValid` method:

```csharp
Person person;
var result = Validation.IsValid(person); // Fails: person != null

Person person = new Person{
  FirstName = "Joe",
  LastName = "Guadagno",
  Address = new Address {
    City = "Chandler",
    State = "AZ"
  },  
  Age = 17
};
result = Validation.IsValid(person); // Fails: person.Age > 18
```

Each call to will fail because at least one assertion fails. But which one failed? That is where `CallerArgumentExpression` comes into play. To fix this, we'll create a custom `Assert` method and add the `CallerArgumentExpression` attribute to the method:

```csharp
public static void Assert(bool condition, [CallerArgumentExpression("condition")] string expression = default)
{
  if (!condition)
  {
    Console.WriteLine($"Condition failed: {expression}");
  }
}
```

Now if we call the `Validate` method with the above sample, we'll get the following output

`Condition failed: person != null`

and

`Condition failed: person.Age > 18)`

### Null Argument Checks

The introduction of `CallerArgumentExpression` attribute has enabled a few new extensions methods to the framework. For example, there is now a `ThrowIfNull` extension method that can be used to throw an `ArgumentNullException` if the argument is null.

We no longer have to write this:

```cs
if (argument is null)
{
    throw new ArgumentNullException(nameof(argument));
}
```

We can now write this:

```cs
ArgumentNullException.ThrowIfNull(argument);
```

The method, behind the scenes, looks like this:

```cs
public static void ThrowIfNull(
    [NotNull] object? argument,
    [CallerArgumentExpression("argument")] string? paramName = null)
    {
        if (argument is null)
        {
            throw new ArgumentNullException(paramName);
        }
    }
```

## Wrap Up

This is not an exhaustive list of new language features introduced in C# 10. To see what else was added to C# 10, check out [What's new in C# 10.0](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-10?wt.mc_id=DT-MVP-4024623)
