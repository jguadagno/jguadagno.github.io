---
title: "What's New with Visual Studio 2022"
header:
    og_image: /assets/images/posts/header/whats-new-with-visual-studio-2022.png
date: 2021-12-05 17:30:00 -0700
categories:
  - Articles
tags:
  - .NET
  - Visual Studio
  - Visual Studio 2022
  - dotnet
---

Visual Studio has had its first major release in about 18 months (depending on how you look at it) :smile:. This release adds a ton of new features and capabilities to the IDE. Now, is a great time to start learning about them.

## Updated User Interface

The user experience of the IDE has been updated to be more consistent and more user friendly. This includes new icons, new fonts, new personalization, and more.

- [Cascadia Code](https://github.com/microsoft/cascadia-code#welcome) font is now the default font for the editor.
- Visual Studio now integrates with [Accessibility Insights](https://accessibilityinsights.io/) to help you find accessibility issues in your code.

### New Icons

The icons have been updated to be consistent across different icons while remaining legible and familiar to the user.

![Visual Studio 2022 - Icon Refresh](/assets/images/posts/vs2022-icon-refresh.png){: .align-center}

### Theme Support

You've probably noticed in the image above that there are icons for a light and dark theme. While themes are not new to Visual Studio, Visual Studio now offers you the ability to sync your Visual Studio theme with your operating system theme.

The dark theme has been updated also to better align with the Microsoft design guidelines and improve accessibility.

Visual Studio now includes a [Theme Converter](https://github.com/microsoft/theme-converter-for-vs) which converts Visual Studio Code themes to Visual Studio themes.

### Inlay Hints

Visual Studio now includes inlay hints for code completion, code lens, and more. Inlay hints can display parameter name hints for literals, function calls, and more.

![Visual Studio 2022 - Inlay Hints](/assets/images/posts/vs2022-inlay-hints.png){: .align-center}

In this image, you can see that Visual Studio tells you that the type for variable `imageUrl` is `string` and `contact` is of type `Contact`.  Further down the image, the `RedirectToAction` method has a parameter named `actionName` which this sample is using the `Details` action.

Note, this feature is not on by default. You can enable it by going to the **Tools > Options > Text Editor > C# or Basic > Advanced** then select **Inlay Hints**.

![Visual Studio 2022 - Inlay Options](/assets/images/posts/vs2022-inlay-options.png){: .align-center}

## Speeding up Visual Studio

You might be saying that all these user interfaces are nice but Visual Studio is slow enough already. Well, that might have been the case for earlier versions of Visual Studio but that is not the case for Visual Studio 2022.  It's faster in part that Visual Studio 2022 is now a 64-bit application. This means that the main process (devenv.exe) is no longer limited to 4GB of memory. Now Visual Studio can load larger projects and load more projects at once. You'll also avoid the "Out of memory" errors that Visual Studio was seeing before when opening large solutions, files, or objects into memory.

Solution loading and file searching is now faster as well. Visual Studio now stores additional information about the solution in the .sln file. This information is used to speed up the loading of the solution. This information is also used to speed up the file searching.

To continue on the speeding up Visual Studio theme, Microsoft also improved the *[Fast up to date](https://github.com/dotnet/project-system/blob/main/docs/up-to-date-check.md)* feature to better check to see if a project or it's dependencies are up to date or need to be rebuilt.

## New Debugging Features

Visual Studio 2022 has added and enhanced the debugging features of Visual Studio. 

### Breakpoints

Let's talk about breakpoints first. There are two new breakpoints that you can set in Visual Studio, temporary and dependent breakpoints, as shown in the image below.

![Visual Studio 2022 - Debug Breakpoint Menu](/assets/images/posts/vs2022-debug-menu.png){: .align-center}

The [Temporary breakpoint](https://docs.microsoft.com/en-us/visualstudio/debugger/using-breakpoints?view=vs-2022#BKMK_set_a_temporary_breakpoint?WT.mc_id=AZ-MVP-4024623) is used to set a breakpoint that will only break once.  Once Visual Studio hits that breakpoint, it deletes it. This is helpful if you want to set a breakpoint only to validate that something is working, and you aren't debugging the code.

The [Dependent breakpoint](https://docs.microsoft.com/en-us/visualstudio/debugger/using-breakpoints?view=vs-2022#BKMK_set_a_dependent_breakpoint?WT.mc_id=AZ-MVP-4024623) is used to set a breakpoint that will only break when another breakpoint is hit.

### Force Run To Cursor

Previous versions of Visual Studio added a feature called "Run to Cursor". This feature was used to execute code up to the code at the cursor.

![Visual Studio 2022 - Run to Cursor](/assets/images/posts/vs2022-run-to-cursor.png){: .align-center}

However, if you had any breakpoints between where you were and where you wanted to run to, Visual Studio would stop at all those breakpoints. Now with *Force Run To Cursor*, you can run to the cursor without hitting any breakpoints. If you hold the shift key down while hovering over the *Run to Cursor* glyph, Visual Studio will change the glyph to a *Force Run To Cursor* glyph and will run to the cursor without hitting any breakpoints.

![Visual Studio 2022 - Force Run to Cursor](/assets/images/posts/vs2022-force-run-to-cursor.png){: .align-center}

The *Force Run to Cursor* is also available in the *Debug* menu.

### Other Debugging Features

For more on breakpoints or debugging tips and tricks in Visual Studio, check out this video:

{% include video id="otR7E-1Vg5s" provider="youtube" %}

## IntelliCode

IntelliCode improves IntelliSense by using AI to help you find the right code completion. IntelliCode is context aware and will help you find the right code completion when you are typing a method call, a property, or a variable.

In the image below, I start to create a new method after the `GetContactsAsync` method. After I type `public async`, IntelliCode is inferring that I want to create a `DeleteContactAsync` method with a parameter of type `contactId`. If that is what I want, I can hit the `Tab` key twice to insert the suggestion.

![Visual Studio 2022 - IntelliCode suggestion](/assets/images/posts/vs2022-intellicode-suggestion.png){: .align-center}

## Git Support

Multiple repository support which includes the ability to track changes across all the repositories in a project. If you open a solution that has multiple Git repositories in it, Visual Studio will connect/activate those repositories. Right now, this is limited to a max of 10 repositories. You will be able to tell if Visual Studio has connected to or activated your different Git repositories by looking at the repository picker on the status bar (located at the lower right corner), which will tell you the number of active repositories you have.

The Git integration with Visual Studio has been improved and include support for multiple repositories, including improvements to both the Solution Explorer and Code Editors.

## Hot Reload

[Hot Reload](https://devblogs.microsoft.com/dotnet/update-on-net-hot-reload-progress-and-visual-studio-2022-highlights/?WT.mc_id=AZ-MVP-4024623) is a feature of Visual Studio that allows you to modify your applications managed code while that application is running with the need to hit a breakpoint or pause the application. This is a cool feature that will save you a lot of time with pausing or stopping your application to see how the source code changes you made changed your application. However, the support for this feature is still in progress.  There are some scenarios and products that are not yet supported.

## Coming soon to the Mac

Visual Studio 2022 for Mac is coming. The Visual Studio team wants to make a modern .NET IDE tailored for the Mac that will look familiar to those using Visual Studio for Windows while using native macOS UI. For more on the Visual Studio 2022 for Mac and/or to join the private beta, please visit [here](https://devblogs.microsoft.com/visualstudio/join-the-visual-studio-2022-for-mac-private-preview).

## Bye Bye .NET 5

While technically not released with Visual Studio 2022, Microsoft released .NET 6 at the same time and includes the .NET 6 SDK in the Visual Studio installation. So now is the time to start migrating your .NET 5, and earlier, projects to .NET 6. As Barry Dorrans [@blowdart](https://twitter.com/blowdart) points [out](https://twitter.com/blowdart/status/1457819844858945537), .NET 5 moves to end of life in May of 2022.

Some more details on the support policy for .NET.

### Supported Versions

| Version | Original Release Date | Latest Patch Version| Patch Release Date| Support Level | End of Support |
| --- | --- | --- | --- | --- | --- |
| .NET 6 | November 08, 2021 | 6.0.0 | November 08, 2021 | LTS | November 08, 2024 |
| .NET 5 | November 10, 2020 | 5.0.12 | November 08, 2021 | Current | May 08, 2022 |
| .NET Core 3.1 | December 3, 2019 | 3.1.21 | November 08, 2021 | LTS | December 3, 2022 |

*Source:* [.NET Support Policy](https://dotnet.microsoft.com/platform/support/policy/dotnet-core)

## Wrap Up

So, what's stopping you from upgrading your IDE and version of .NET?
