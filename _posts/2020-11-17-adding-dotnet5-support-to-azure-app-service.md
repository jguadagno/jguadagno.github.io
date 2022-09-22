---
title: "Adding .NET 5 Support to Azure App Service"
date: 2020-11-17 10:05:00 -0700
last_modified_at: 2020-11-21 16:23:00 -0700
header:
    og_image: /assets/images/posts/header/app-service-dotnet5.png
categories:
  - Articles
  - Archive
tags:
  - Azure
  - App Service
  - .NET 5
---
Yesterday I updated the [Contacts](https://www.github.com/jguadagno/contacts){:target="_blank"} to .NET 5.  Now the process was pretty easy, you can watch the video [here](https://youtu.be/9eD0WfVizbE){:target="blank"}, however once published to [Azure App Service](https://azure.microsoft.com/en-us/services/app-service/?WT.mc_id=AZ-MVP-4024623){:target="_blank"} I got the following error.

![HTTP Error 500.31](/assets/images/posts/dotnet5-appservice-500-31.png){: .align-center}

> HTTP Error 500.31 - ANCM Failed to Find Native Dependencies  
> Common solutions to this issue:  
> The specified version of Microsoft.NetCore.App or Microsoft.AspNetCore.App was not found.  

This reminded of something that Scott Hunter mentioned at .NET Conf.  Azure App Service supports .NET 5, just not by default.

That reminded me that I had to check the configuration of the App Service to change it to enable support for .NET 5.  It's was pretty easy to do.

* Log in to your portal
* Navigate to your App Service
* Click on *Configuration*

![Configuration Setting](/assets/images/posts/dotnet5-appservice-configuration.png){: .align-center}

Under *Stack Setting*, change the following

| Setting | Value |
| Stack | `.NET` |
| .NET Framework Version | `.NET 5 (Early Access)` |

![.NET 5 App Service Stack Settings](/assets/images/posts/dotnet5-appservice-stack-setting.png){: .align-center}

* Click *Save*
* Then go back to the *Overview* and restart the App Service.

After refreshing your browser, the error should go away and the application load.

## References

* [Deploy .NET 5 Web Apps to Azure App Service Today](https://devblogs.microsoft.com/aspnet/announcing-asp-net-core-in-net-5/#deploy-net-5-web-apps-to-azure-app-service-today?WT.mc_id=AZ-MVP-4024623)
