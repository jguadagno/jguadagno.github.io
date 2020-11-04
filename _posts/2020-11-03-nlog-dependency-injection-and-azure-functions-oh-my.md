---
title: "NLog, Dependency Injection, and Azure Functions, Oh My!"
header:
    og_image: /assets/images/posts/header/nlog-di-azure-functions.png
categories:
  - Articles
tags:
  - Azure
  - Azure Functions
  - NLog
  - Dependency Injection
---
I've been working on a side project [JosephGuadagno.Net Broadcasting](https://github.com/jguadagno/jjgnet-broadcast); I know I need a better name :smile:, for a month or so now. The project's goal is to provide a way for me to promote talks, scheduled [streams](https://jjg.me/stream){:target="_blank:}, my YouTube [Videos](https://jjg.me/youtube){:target="_blank:}, and blog content on social media.  This project is a collection of Azure Functions that perform different tasks like query the YouTube Apis, check RSS feeds, post to Facebook feeds, etc.  The project, more so the components that make it up, has started to get quite large. Add the fact that the solution is running in Azure on someone else computer, I wanted to add some logging and telemetry to the components to know what was happening and when. I added [NLog](https://nlog-project.org/){:target="_blank} to the project to help with the logging. [Azure Monitor](https://azure.microsoft.com/en-us/services/monitor/?WT.mc_id=AZ-MVP-4024623#product-overview){:target="_blank}, aka [Application Insights](https://docs.microsoft.com/en-us/azure/azure-monitor/app/app-insights-overview?WT.mc_id=AZ-MVP-4024623){:target="_blank"}, is coming next :smile:. If you need to add logging to your application, I suggest you take a look at NLog, it's pretty easy to use once you get the configuration right.  And here lies the reason for blog posts...

If you haven't used NLog before, like most logging frameworks, it needs a configuration to run, this configuration is typically in a `nlog.config` [file](https://github.com/NLog/NLog/wiki/Tutorial#configure-nlog-targets-for-output){:target="_blank"}, although with some updates to the project, you can use an `appsettings.json` [file](https://github.com/NLog/NLog.Extensions.Logging/wiki/NLog-configuration-with-appsettings.json){:target="_blank"}.  Honestly, I think the project is trying to catch up to the configuration system in ASP.NET Core. The framework looks for the `nlog.config` file in the same folder as the assembly is being executed from.  For Azure Functions, that folder varies depending on where you are running it.  If like me, you are running it through JetBrains Rider, it runs it from a really long directory (the installation directory of the Azure Functions framework/tools). This location is not ideal, in my opinion, for the `nlog.config`.  I would prefer it in the application directory.  So far there really isn't a problem, NLog provides the ability to change the location of the configuration file.  I tried that using the following code in my `Startup.cs`

```cs
public Startup()
{
    LogManager.Setup()
        .SetupExtensions(e => e.AutoLoadAssemblies(false))
        .LoadConfigurationFromFile(Environment.CurrentDirectory + Path.DirectorySeparatorChar + "nlog.config", optional: false)
        .LoadConfiguration(builder => builder.LogFactory.AutoShutdown = false);
}
```

Oh, did I mention, I was using the *new* Azure Functions [Dependency Injection](https://docs.microsoft.com/en-us/azure/azure-functions/functions-dotnet-dependency-injection?WT.mc_id=DOP-MVP-4024623){:target="_blank"}. On line 5, I tell NLog to load the configuration from `Environment.CurrentDirectory + Path.DirectorySeparatorChar + "nlog.config"` which on my local machine translates to something like `c:\MyProjects\FunctionApp\nlog.config`.  Running a few tests locally, everything was working and I was getting logs. Once I committed the code, the code was published to the Azure Function via the [GitHub Action](https://github.com/jguadagno/jjgnet-broadcast/blob/main/.github/workflows/publish-to-azure-function.yml){:target="_blank"}, I noticed I wasn't getting any logs.  In fact, I was getting an error message:

> System.Private.CoreLib: Exception has been thrown by the target of an invocation. NLog: Failed to load NLog LoggingConfiguration. 'D:\Program Files\...'

I've left out the full file path that was provided.

This led me to use the Azure Functions Advanced Tools ([Project Kudo](https://github.com/projectkudu/kudu){:target="_blank"}) to start some directory browsing to make sure I copied the `nlog.config` file to the root of the application.

![Folder List](/assets/images/posts/nlog-di-az-functions-folder-lists.png){: .align-center}

The file is there! What could be the problem? The first clue was the exception thrown about searching in the path 'D:\Program Files...\'. Based on the code sample above, line 5, `Environment.CurrentDirectory + Path.DirectorySeparatorChar + "nlog.config"` I should be pulling the configuration from `D:\home\site\wwwroot` but I wasn't.  Now, I could have hard coded the value on line 5 and stopped there but I didn't.  After some research, it looks like I could get the `ExecutionContext` to get the application directory that the function is running in. But as the [docs](https://docs.microsoft.com/en-us/azure/azure-functions/functions-dotnet-dependency-injection?WT.mc_id=AZ-MVP-4024623#caveats){:target="_blank"} say...

> The dependency injection container only holds explicitly registered types. The only services available as injectable types are what are setup in the Configure method. As a result, Functions-specific types like BindingContext and ExecutionContext aren't available during setup or as injectable types.

Well, that stinks! Back to the drawing board! Now I had to figure out how do I get the current folder based on *where the code is running*, reflection isn't easy to get right, the folder structure varies depending on the tools you are using, Rider, Visual Studio, Visual Studio Code, etc. I needed to map the code locally to something like `C:\MyProjects\FunctionApp` on Windows, `~/Projects/FunctionApp` on Mac, and `d:/Home/site/wwwroot/` for Azure.  There was no Environment variable to do this so this is what I came up with

```cs
var localRoot = Environment.GetEnvironmentVariable("AzureWebJobsScriptRoot");
var azureRoot = $"{Environment.GetEnvironmentVariable("HOME")}/site/wwwroot";

var _applicationDirectory = localRoot ?? azureRoot;
LogManager.Setup()
    .SetupExtensions(e => e.AutoLoadAssemblies(false))
    .LoadConfigurationFromFile(_applicationDirectory + Path.DirectorySeparatorChar + "nlog.config", optional: false)
    .LoadConfiguration(configurationBuilder => configurationBuilder.LogFactory.AutoShutdown = false);
```

Line 1 determines the path if running locally. The environment variable `AzureWebJobsScriptRoot` is `null` when running on Azure.

Line 2 creates the path when running in Azure.  The environment variable `HOME` points to the folder the App Server that is running your Function(s) is running out of.

Line 4 creates the `_applicationDirectory` variable based on whether or not `localroot` is null.

This solved the problem running locally and in Azure.  I hope in version 4 of the Azure Function SDK, the directory, environment variables, and how settings are handled is a little more consistent.

## Wrap Up

Well, I hope this helps you and save you a few hours getting NLog to work in Azure Function and potentially any file/folder work in Azure.

## Bonus

You can declare the `_applicationDirectory` variable as a private variable in the Startup class of your function and then config the Configuration system to load environment-specific settings with the following code.

```cs
var config = new ConfigurationBuilder()
    .SetBasePath(_applicationDirectory)
    .AddJsonFile("local.settings.json", true)
    .AddUserSecrets(Assembly.GetExecutingAssembly(), true)
    .AddEnvironmentVariables()
    .Build();
```

My [Startup.cs](https://github.com/jguadagno/jjgnet-broadcast/blob/main/src/JosephGuadagno.Broadcasting.Functions/Startup.cs){:target="_blank"}
