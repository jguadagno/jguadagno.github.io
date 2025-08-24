---
title: "My JetBrains Rider Plugins—August 2025 Edition"
header:
    og_image: /assets/images/posts/header/rider-plugins.png
date: 2025-08-23 17:06:00 -0700

categories:
- Articles
tags:
- JetBrains
- Rider
- Plugin
- presenting
---
I've been using [JetBrains](https://www.jetbrains.com/){:target="_blank"} [Rider](https://www.jetbrains.com/rider/){:target="_blank"} for quite some time now.

I started using JetBrains Rider because I used both a Windows PC and a Mac PC and I wanted a consistent experience between the both.
JetBrains Rider provided that and now I am hooked.

I thought I'd take some time to blog about the plugins I use to help with my day-to-day coding (mostly in Microsoft .NET and Azure), presenting (public speaking), and blogging (using [Jekyll](https://jekyllrb.com/){:target="_blank"}).

All of these plugins can be downloaded from either the JetBrains plugin [Marketplace](https://plugins.jetbrains.com/){:target="_blank"} or directly in the IDE.

This is an updated post from a previous post I wrote in [June 2022]({% post_url 2022/2022-06-23-my-jetbrains-rider-plugins-june-2022-edition %}) and [July 2024]({% post_url 2024/2024-07-12-my-jetbrains-rider-plugins-july-2024-edition %}){:target="_blank"}.
{: .notice}

So here is the list.

## General Development

| Plugin                                                                                                 | What it does                                                                                                                                                                        |
|--------------------------------------------------------------------------------------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| [.env files support](https://plugins.jetbrains.com/plugin/9525--env-files-support){:target="_blank"}   | As the name implies, it provides environment variable completion for `Dockerfile` and `docker-compose.yml` files                                                                    |
| [.ignore](https://plugins.jetbrains.com/plugin/7495--ignore){:target="_blank"}                        | Allows you to manage your `.gitignore` files in a more efficient way                                                                                                              |
| [Big Data Tools](https://plugins.jetbrains.com/bundles/8-big-data-tools){:target="_blank"} | Provides tools for working with big data technologies such as Hadoop and Spark. |
| [Ideolog](https://plugins.jetbrains.com/plugin/9746-ideolog){:target="_blank"} | Provides enhanced log file viewing and analysis capabilities within the IDE. |
| [Key Promoter X](https://plugins.jetbrains.com/plugin/9792-key-promoter-x){:target="_blank"}           | Let's you know if there is a keystroke shortcut for any mouse based IDE commands                                                                                                    |
| [Karma](https://plugins.jetbrains.com/plugin/7287-karma){:target="_blank"} | Provides integration with the Karma test runner for JavaScript and TypeScript projects. |
| [OpenTelemetry](https://plugins.jetbrains.com/plugin/27488-opentelemetry){:target="_blank"} | Provides tools for collecting, processing, and exporting telemetry data from applications. ***Note***: This plugin is currently in a beta|
| [Structured Logging](https://plugins.jetbrains.com/plugin/12832-structured-logging){:target="_blank"}  | Contains some useful analyzers for structured logging. Supports Serilog, NLog, and Microsoft.Extensions.Logging                                                                     |
| [Terraform and HCL](https://plugins.jetbrains.com/plugin/7808-terraform-and-hcl){:target="_blank"} | Improved Terraform and OpenTofu support is tailored for developers, SREs, and DevOps teams, supporting infrastructure management with features like syntax highlighting, code completion, and real-time error checking.|
| [Uno Platform](https://plugins.jetbrains.com/plugin/24653-uno-platform){:target="_blank"}|The Uno Platform plugin for JetBrains Rider enables Hot Reload support for Uno Platform apps, streamlining the development of cross-platform .NET Mobile, Web, and Desktop Apps.|

## AI Tools

| Plugin                                                                                                 | What it does                                                                                                                                                                        |
|--------------------------------------------------------------------------------------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| [GitHub Copilot](https://plugins.jetbrains.com/plugin/17718-github-copilot){:target="_blank"}          | GitHub Copilot uses OpenAI Codex to suggest code and entire functions in real-time right from your editor. ***Note***: This plugin is free but requires a paid subscription service |
| [JetBrains AI Assistant](https://plugins.jetbrains.com/plugin/22282-jetbrains-ai-assistant){:target="_blank"}          | JetBrains AI Assistant provides AI-powered features for software development based on the JetBrains AI Service. The service transparently connects you, as an IDE user, to different large language models (LLMs). ***Note***: This plugin is free but requires a paid subscription service |
| [JetBrains Junie](https://plugins.jetbrains.com/plugin/26104-jetbrains-junie){:target="_blank"} | JetBrains Junie is your coding agent by JetBrains designed to handle tasks autonomously or in collaboration with a developer. |

### Microsoft Specific Development

| Plugin                                                                                                   | What it does                                                                                   |
|----------------------------------------------------------------------------------------------------------|----------------------------------------------------------------------------------------------|
| [.NET Aspire](https://plugins.jetbrains.com/plugin/23289--net-aspire){:target="_blank"}                 | Provides support for .NET Aspire in Rider               |

### Azure Specific Development

| Plugin                                                                                                                                      | What it does                                                                                                                                                              |
|---------------------------------------------------------------------------------------------------------------------------------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| [Application Insights Debug Log Viewer](https://plugins.jetbrains.com/plugin/13984-application-insights-debug-log-viewer){:target="_blank"} | Provides the ability to view Azure Monitor (Application Insights) telemetry in the IDE                                                                                    |
| [Azure Toolkit for Rider](https://plugins.jetbrains.com/plugin/11220-azure-toolkit-for-rider){:target="_blank"}                             | Rider plugin for integration with Azure cloud services. Allow to create, configure, and deploy .Net Core and .Net Web Apps to Azure from Rider on all supported platforms |

## Presenting

| Plugin                                                                                                       | What it does                                                                                     |
|--------------------------------------------------------------------------------------------------------------|--------------------------------------------------------------------------------------------------|
| [Window Arranger](https://plugins.jetbrains.com/plugin/18045-window-arranger){:target="_blank"}                | This plugin helps you easily switch between projects, arrange project windows, and resize them to various predefined dimensions. ***Note***: This plugin used to be called *Window Resizer* |

## Writing

I know longer have anything in this category since I use GitHub Copilot and JetBrains AI Assistant.

## No longer in the list

| Plugin | What it does| Why did it drop |
| [Presentation Assistant](https://plugins.jetbrains.com/plugin/7345-presentation-assistant){:target="_blank"} | This plugin shows name and Win/Mac shortcuts of any action you invoke                            | Built into the IDE now |
| [PowerShell](https://plugins.jetbrains.com/plugin/10249-powershell){:target="_blank"}                  | Provides PowerShell intellisense and script execution support for IntelliJ IDEs       | Turns out I don't edit PowerShell scripts that often |
| [Rainbow Brackets](https://plugins.jetbrains.com/plugin/10080-rainbow-brackets){:target="_blank"}      | Provides colored brackets, parentheses, and lines in the IDE  | Built into the IDE now |
| [String Manipulation](https://plugins.jetbrains.com/plugin/2162-string-manipulation){:target="_blank"} | Case switching, sorting, filtering, incrementing, aligning to columns, grepping, escaping, encoding... Very helpful when working with tabular data                                  | No longer a need for this plugin
| [Azure DevOps](https://plugins.jetbrains.com/plugin/7981-azure-devops){:target="_blank"}                                                    | Azure DevOps is a plugin to enable working with Git and TFVC repositories on Azure DevOps Services or Team Foundation Server (TFS) 2015+ | Built into the IDE now |
| [Grazie](https://plugins.jetbrains.com/plugin/12175-grazie){:target="_blank"}                           | Intelligent spelling and grammar checks for any text you write in the IDE | Between Github CoPilot and JetBrains AI Assistant, it covers what I need |
| [Grazie Professional](https://plugins.jetbrains.com/plugin/16136-grazie-professional){:target="_blank"} | Enhances the base Grazie plugin with advanced writing assistance for English text in your IDE. | Between Github CoPilot and JetBrains AI Assistant, it covers what I need |
| [.NET Core User Secrets](https://plugins.jetbrains.com/plugin/10183--net-core-user-secrets){:target="_blank"} | Provides the ability to create and edit user secrets in .NET projects | Built into the IDE now |

## Wrap Up

You'll also notice that a lot of the plugins I used to use are now built into the IDE.

Do you have a favorite not listed? Let me know.
