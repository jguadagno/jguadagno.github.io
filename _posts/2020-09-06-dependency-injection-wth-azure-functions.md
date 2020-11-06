---
title: "Dependency Injection with Azure Functions"
header:
    og_image: /assets/images/posts/header/di-with-azure-function.png
date: 2020-09-06 18:50:00 -0700
last_modified_date: 2020-11-06 16:16:00 -0700
categories:
  - Articles
tags:
  - Azure
  - Functions
---
I got bit by the dependency injection bug a few months ago and want to use it when I can, and it makes sense. Within a month or so of writing this post, Azure Functions started to support dependency injection in functions. It uses the .NET Core Dependency Injection system, so if you are used to that, this should mostly look familiar to you, except for what you have to do to wire up the Azure Functions SDK.

## Getting Started

To get started, you need to add a reference to `Microsoft.Azure.Functions.Extensions` package in your Azure Functions project.

```bash
Install-Package Microsoft.Azure.Functions.Extensions -Version 1.0.0
```

Now you need a class to register your services.  I use `Startup` to be consistent with ASP.NET Core.  You can create whatever class name you want.  

In that class, you need to inform the Azure Function SDK that this class is the startup class. To do this, add the assembly attribute `FunctionsStartup` to the class file.

```csharp
[assembly: FunctionsStartup(typeof(Startup))]
```

This will require the following using statement.

```csharp
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
```

Have your class inherit from `FunctionsStartup`. Doing so requires your class to override the `Configure` method. The `Configure` method is where you register the services that you would like to inject. Since Azure Functions relies on the .NET Core Dependency Injection features, you can choose any supported [service lifetimes](https://docs.microsoft.com/en-us/azure/azure-functions/functions-dotnet-dependency-injection?WT.mc_id=DOP-MVP-4024623#service-lifetimes){:target="_blank"}.

```csharp
using MyFunctions.Samples;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

[assembly: FunctionsStartup(typeof(Startup))]
namespace MyFunctions.Samples
{
    public class Startup: FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.TryAddSingleton<ISettings>(s => new Settings());
        }
    }
}
```

In this example, I am registering the `ISettings` class as a singleton class within the dependency injection system.

Now navigate to the class with your function.

***NOTE*** You'll have to remove the `static` modifier from the class and your function.
{: .notice--info}

At this point, you can use directly inject the registered services.

```csharp
private readonly ISettings _settings;

// Class Constructor
public MyFunctionApplication(ISettings settings)
{
    _settings = settings;
}
```

Then you can use `_settings` anywhere in your code. Like this example:

```csharp
log.LogInformation($"Value from Settings class='{_settings.MySetting}'");
```

## Wrap Up

That’s it. Pretty easy. I’ve included links to the Azure Function documentation and a sample repository that I used it below.

## References

* [Use dependency injection in .NET Azure Functions](https://docs.microsoft.com/en-us/azure/azure-functions/functions-dotnet-dependency-injection?WT.mc_id=DOP-MVP-4024623){:target="_blank"}
* Sample code before Dependency Injection: [Code](https://github.com/jguadagno/Contacts/blob/28349f06d2ead5282381895feb975b2b1d6a4171/src/Contacts.Functions.ThumbnailCreator/CreateThumbnailImage.cs){:target="_blank"}
* Sample code after Dependency Injection: [Code](https://github.com/jguadagno/Contacts/blob/main/src/Contacts.Functions.ThumbnailCreator/CreateThumbnailImage.cs){:target="_blank"}