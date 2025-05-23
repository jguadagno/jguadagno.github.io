---
title: Building and Deploying a New Cloud App from Scratch
isKeynote: false
isRetired: false
isWorkshop: true
sourceUrl: https://github.com/jguadagno/app-from-scratch
powerPointUrl: https://1drv.ms/p/c/406ee4c95978c038/UQQ4wHhZyeRuIIBA3kABAAAAAJhkZJao3aPnCqk
youTubeId:
youTubeCaption:
sessionizeUrl: building-and-deploying-a-new-cloud-app-from-scratc/51051
level: 100
links:
 - title: My Website
   url: https://www.josephguadagno.net
 - title: Source Code
   url: https://github.com/jguadagno/app-from-scratch
 - title: Azure Portal
   url: https://portal.azure.com
 - title: Microsoft Learn
   url: https://jjg.me/learn-microsoft-learn
 - title: GitHub
   url: https://www.github.com
 - title: Visual Studio
   url: https://visualstudio.microsoft.com/?wt.mc_id=DT-MVP-4024623
 - title: JetBrains Rider
   url: https://jetbrains.com/rider/
 - title: SQL Server
   url: https://www.microsoft.com/sqlserver
---
In this workshop we are going to build and deploy a modern cloud application from scratch!
Using Visual Studio and Azure, you will learn how to build a modern application from the ground up
and deploy it to the cloud using the latest techniques.
We will look at some best practices in designing and building the application,
testing your code, and deploying the application, so you are set up for success later.
After this workshop,
you will have an established pattern to follow for future applications
and in case you need to change the infrastructure of your application.

## What We will Cover

- Introduction to the Integrated Development Environment (IDE) – Visual Studio
- C# Programming Language *Optional*
  - CSS *Optional*
  - HTML *Optional*
- Nuget Packages
- Application Development
  - Designing Models
  - Building the Business (Manager) Layer
  - Building the Data Layer
    - SQL Server
    - Entity Framework
  - User Secrets
- Unit Testing the Application
  - XUnit
- Web Development
  - Creating a REST API
  - Documenting the REST API (Swagger)
  - Creating a Web Client (ASP.NET Core MVC)
    - Bootstrap (mention other clients like Angular, Vue, React, Blazor)
- Deploying the Application
  - Pushing the source code to Git
  - Create the Azure Infrastructure
    - Application Service
    - SQL Server
  - Create the GitHub Action to Deploy
- Monitoring the Application *Optional*
  - Azure Monitor Application Insights
  - Logging (SeriLog)

## Target Audience

This workshop is geared toward individuals just getting started with Microsoft .NET and/or looking to design applications that can easily be changed and/or deployed to Azure. Attendees should have experience in at least one programming language and an understanding of basic web programming paradigms.

Requirements:

- [Visual Studio](https://visualstudio.microsoft.com/?wt.mc_id=DT-MVP-4024623) or [JetBrains Rider](https://jetbrains.com/rider/)
- SQL Server (Developer Edition or LocalDB) [Installation Guide](https://docs.microsoft.com/en-us/sql/database-engine/install-windows/install-sql-server?view=sql-server-ver16&?wt.mc_id=DT-MVP-4024623)
- [Azure Account](https://docs.microsoft.com/en-us/azure/developer/?wt.mc_id=DT-MVP-4024623)
