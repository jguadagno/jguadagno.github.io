---
title: "What I Like About C# 9"
header:
    og_image: /assets/images/posts/header/what-i-like-about-csharp9.png
date: 2021-08-23 07:30:00 -0700
categories:
  - Articles
tags:
  - .NET
  - Record
  - Init
---

**Note:** This post was originally posted on the Telerik [blog](https://www.telerik.com/blogs/what-i-like-about-csharp-9){:target="_blank"}.
{: .notice--info}

I've been a software engineer for 20+ years, and as the adage goes, *You can't teach an old dog new tricks*. However, if there is one thing I learned in the 20+ years is that I am ***ALWAYS learning***. There are always new technologies coming out, new languages, and new products to solve complex problems. .NET 5 introduced C# 9, which had many new language features. So it was time for me to learn some new tricks and I dove into .NET 5's C# 9 language additions.

After using these new language features, keywords, and syntax, I noticed that they started to save me keystrokes and time. Since these language additions helped me I wanted to share them with you.

Let's take a look at some of the new language features.

## Records

The new `record` keyword defines a reference type that provides some built-in functionality for representing data. You might be thinking that this sounds a lot like a `class`, and you would be correct. It does. However, the intent is to provide smaller and more concise types to represent immutable data. I like to think of them as a type used primarily to transfer data and not have a lot of methods or data manipulation.

More on C# 9 [records](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9#record-types?WT.mc_id=AZ-MVP-4024623){:target="_blank"}.

### Defining a Record

There are a few different ways to define a `record`. The simplest form is:

```cs
public record Person(string FirstName, string LastName);
```

At first glance, at least for me, that seemed weird.  It has a method look and feel.  There is even a semicolon at the end.  But, the above line creates a *Person* type with the read/write properties of `FirstName` and `LastName`. You can access the *Person* as follows:

```cs
var person = new Person("Joseph", "Guadagno");
Console.WriteLine(person.FirstName); // Outputs Joseph
Console.WriteLine(person.LastName); // Outputs Guadagno
```

So far, this looks very `class`-like. Well, it is, except for the declaration. We already saved a bunch of keystrokes.  But let's dig more into it.

Another way to define the *Person* `record` is more `class`-like:

```cs
public record Person
{
    public string FirstName { get; set;}
    public string LastName { get; set;}
}
```

### Creating Records by Position

You can further reduce some typing and remove some boilerplate code using the new positional syntax for records. For example, if you wanted to declare a variable with the class approach and initialize it with data, you would do something like this.

```cs
var person = new Person { FirstName = "Joseph", LastName="Guadagno"};
```

With positional syntax, that would look like this.

```cs
Person person = new ("Joseph", "Guadagno");
```

That's 26 fewer characters. Behind the scenes the compiling is creating a lot of the *boilerplate* code for you. The compiler creates a constructor that matches the position of the record declaration.  Since the `FirstName` property was the first property declared when we defined the method, it assumes that the *Joseph* value should be the value of the `FirstName` property. The compiler also generated all the properties as init-only, more on that [later](#defining-set-once-properties), meaning the properties can not get set after initialization making them read only.

### Value Equality

One set of built-in functionality that records provide is value equality. When checking to see if two records are equal, it will look at the values of each of the properties and not the reference.

Assuming the definition of.

```cs
public record Person(string FirstName, string LastName);
```

When comparing records

```cs
Person person1 = new ("Joseph", "Guadagno");
Person person2 = new ("Joseph", "Guadagno");

Console.WriteLine(person1 == person2); // outputs True
Console.WriteLine(ReferenceEquals(person1, person2)); // outputs False
```

Since `person2` has the same `FirstName` and `LastName` of `person2` they are equal, although the references are not.

### Improved ToString()

Using the `record` keyword, gets you another built in method.  What a deal!  An improved `ToString` method.  I really wish this was opt-in standard for classes to.

The `ToString` method outputs the following format.

```txt
<record type name> { <property name> = <value>, <property name> = <value>, ...}
```

For a record defined as

```cs
public record Person(string FirstName, string LastName);
```

and initialized as

```cs
Person person = new {"Joseph", "Guadagno"};
```

the `ToString` method would output a string like

```txt
Person { FirstName = Joseph, LastName = Guadagno }
```

If there is a reference type as one of the properties of the record, the records `ToString` implementation will output the type name of it.

***NOTE*** Don't try to use the `ToString` method to determine the records properties.

### Inheriting Records

Records can be inherited the same way classes are except for the following:

* Records can't inherit from a class
* Class can't inherit from a record
* When comparing records, the type of record is used as part of the comparison and not just the values.

### Copying Records

Copying records is pretty easy. As an added bonus, the syntax makes the code easier to read.

Let's say I had a *Person* record defined as.

```cs
public record Person
{
    string FirstName { get; set;}
    string LastName { get; set;}
    string HomeState { get; set;}
}
```

Let's also say I want to create one *Person* and make multiple copies and just change a few properties. As if I was to create variables for the whole family.  In our case, the `LastName` and `HomeState` properties are the same and using records along with the `with` keyword makes this easier.

```cs
var me = new Person("Joseph", "Guadagno", "Arizona");
var wife = me with {FirstName = "Deidre"};
var son = me with {FirstName = "Joseph Jr."};
var daughter = me with {FirstName = "Emily"};
```

Now, the `wife`, `son`, and `daughter` objects have the property of `LastName` set to *Guadagno* and `HomeState` set to *Arizona*.

## Defining Set Once Properties

You can also use the new `init` keyword to make certain properties settable on initialization only. The `init` keyword works with properties or indexers in `struct`, `class`, or `record`.

Let's say with want to define a *Person* `record` with `FirstName`, `LastName`, and `CreateOnDate` properties.  The `CreatedOnDate` should not be editable after the record is initialized. We would declare the `record` like this.

```cs
public record Person 
{
    public string FirstName { get; set;}
    public string LastName { get; set;}
    public DateTime CreatedOnDate { get; init;}
}
```

You see on line 5, we have the keyword `init` instead of `set`.  This means the `CreatedOnDate` can only be set when initialized.

```cs
var person = new Person("Joseph", "Guadagno", DateTime.Now());
```

After declaring this record, we are limited as to what properties we can change.

```cs
person.FirstName = "Joe"; // valid
person.CreatedOnDate = DateTime.Now(); // You will get a compile error
```

Line 2, will cause a compilation error because the property `CreatedOnDate` was set to init-only.

### Alternative declaration

You can also declare the setter of a property with a backing field as init-only.

```cs
public class Person
{
    private readonly DateTime _dateOfBirth;
    public DateTime DateOfBirth 
    {
        get => _dateOfBirth;
        init => (value ?? throw new ArgumentNullException(nameof(DateOfBirth)));
    }
    public string FirstName { get; set;}
    public string LastName { get; set;}
}
```

On line 7, we define the class *Person* with an init only property `DateOfBirth` that must be set at initialization or you will get a compile error or runtime exception depending on the implementation.

This is valid (assuming the definition above).

```cs
var person = new Person{FirstName="Joseph", LastName="Guadagno", DateOfBirth=DateTime.Now()};
```

This is not (assuming the definition above).

```cs
var person = new Person{FirstName="Joseph", LastName="Guadagno"};
```

Based on the above definition, this code sample will throw a runtime exception.

## Top Level Statements

I started out this post introducing the notion that C# 9's language features help you be more productive and reduce keystrokes. Top Level statements is another one of the features.  To be honest, you probably won't use this feature a lot.  In fact, you can only have one file in your application that uses this feature.  It's generally helpful for demonstrating some functionality and removing all of the extra ceremony around the application startup.  I see myself using it when I am creating presentations.

Let's take the typical "Hello World" sample.

```cs
using System;

namespace CSharp9Features.ConsoleApp
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
```

It's 12 lines long using the default .NET C# console app template.  Now with top level statements, this can reduced to.

```cs
System.Console.WriteLine("Hello World");
```

Now "*we*" reduced the code from 12 lines and 210 characters to 1 line and 40 characters.

Behind the scenes the compiler essentially created the 12 lines and 210 characters for you.  But again, C#9 is trying to make things easier for you so why type those lines when the compiler knows that is what you want.

In a more "realistic" example, let's say for an ASP.NET Core WebAPI project.  The typical template would have a `Program.cs` file that looks something like this.

```cs
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Contacts.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); })
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.SetMinimumLevel(LogLevel.Trace);
                });
    }
}
```

Now with C# 9, I can remove some of the noise and ceremony and have my code just be what my API needs to start.

```cs
using Contacts.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

CreateHostBuilder(args).Build().Run();

IHostBuilder CreateHostBuilder(string[] args) =>
Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); })
    .ConfigureLogging(logging =>
    {
        logging.ClearProviders();
        logging.SetMinimumLevel(LogLevel.Trace);
    });
```

This code now clearly states what the intent of the `program.cs` is without the *extra* `namespace` or `Main` method.

## New Pattern Matching

While [pattern matching](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/patterns?WT.mc_id=AZ-MVP-4024623){:target="_blank"} is not new to C# 9, C# 9 did add a few more patterns.

Logical patterns:

* `and`
* `or`
* `not`

Relations patterns:

* `<`
* `>`
* `<=`
* `>=`

These patterns help add readability to code. My favorite addition to this is the `not` pattern matcher.  Now I can take all the instances of

```cs
if (!person is null)
```

and make them more readable with

```cs
if (person is not null)
```

While this one is more keystrokes, the extra couple of characters makes it more readable to me than the `!` operator.

## Omitting the type

The compiler is getting smarter. It's not necessarily getting more intelligent, but getting better at understanding what you are trying to do and, again, reducing the keystrokes. The C# 9 feature of target-typed new expressions demonstrates that the compiler is getting smarter. Now, based on the variable declaration or method signature, you can omit the type in variable declarations or usage.

Here we are declaring a variable `_people` of type `List<Person>`

```cs
private List<Person> _people = new();
```

You no longer have to initialize the variable of `_people` with `new List<Person>()`. The compiler can assume that you want a new List of Person.

The same goes for methods. In the sample below, the method `CalculateSalary` expects a parameter of type  `PerformanceRating`.

```cs
public Person CalculateSalary(PerformanceRating rating) 
{  
    // Omitted
}
```

If I wanted to initialize an new `PerformanceRating` object for the method without creating a variable, I can now.

```cs
var person = person.CalculateSalary(new ());
```

or, I can pass in a new `PerformanceRating` object with one or more of it's properties initialized.

```cs
var person = person.CalculateSalary(new () {Rating ="Rock Star"});
```

This syntax does take some getting used to. I think in the long it leads to code that is easier to use.  However, it might add more fuel to the `var` vs. typed variable declaration debate. :)

## Wrap Up

Wow, that was a lot. C#9 added [Record Types](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9#record-types?WT.mc_id=AZ-MVP-4024623){:target="_blank"}, [Init Only](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9#init-only-setters?WT.mc_id=AZ-MVP-4024623){:target="_blank"} setters, [Top-Level](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9#top-level-statements?WT.mc_id=AZ-MVP-4024623){:target="_blank"} programs, enhancements to [pattern matching](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9#pattern-matching-enhancements?WT.mc_id=AZ-MVP-4024623){:target="_blank"}, and [more](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9?WT.mc_id=AZ-MVP-4024623){:target="_blank"}.  

I hope you take some time and play around with these new language features.  Doing so will reduce your keystrokes and help your code to be readable in the long run.

## Bonus: Coming Soon - C# 10

While not set in stone... As of the writing of this post, .NET 6 preview 5 is planing on adding the following to C# 10.

* Allow `const` interpolated strings.
* Record types can seal `ToString()`.
* Allow both assignment and declaration in the same deconstruction.
* Allow `AsyncMethodBuilder` attribute on methods.

For more, check out [What's new in C# 10.0](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-10?WT.mc_id=AZ-MVP-4024623)
