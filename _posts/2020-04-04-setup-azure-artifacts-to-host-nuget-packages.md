---
title: "Setup Azure Artifacts to Host Your NuGet Packages"
date: 2020-04-04 19:30:00 -0700
categories:
  - Articles
tags:
  - .NET Core
  - NuGet
  - Azure
  - Pipeline
  - Key Vault
  - Azure Artifacts
excerpt_separator: <!--more-->
---
Let's take a look how you can build an Azure pipeline that will build your NuGet package, sign it, then deploy it to Azure Artifacts
<!--more-->

According the Azure Artifacts [site](https://azure.microsoft.com/en-us/services/devops/artifacts/), Azure Artifacts provides a service to "Create and share Maven, npm, NuGet, and Python package feeds from public and private sources". In this post, I'll focus on setting up a repository to host my own private NuGet packages.

Just like most services provided with Azure their maybe a cost to using it.  Azure Artifacts provide both free and paid options, please visit the [pricing for Azure DevOps](https://azure.microsoft.com/en-us/pricing/details/devops/azure-devops-services/) page for the latest on costs for using this service.

## Setup

First step is signing up for Azure Artifacts is to setup an Azure DevOps account/organization. Check out the [Quick Start](https://docs.microsoft.com/en-us/azure/devops/user-guide/sign-up-invite-teammates?view=azure-devops) guide, to get started.

Now that you have an organization you'll need to sign into it. The url should look something like **dev.azure.com/*organization-name***, in my case, it's **dev.azure.com/jguadagno**. 

### Create a Project

Artifacts, in Azure are hosted as part of a project.  Let's go and create a project for this.  You should a '+ New project' button on your organization page.  Highlighted below.

{% include figure image_path="/assets/images/posts/artifacts-new-project.png" alt="Azure Artifacts - New Project" caption="Azure Artifacts - New Project." %}

Click the '+ New Project' button and you will be prompted with the *new project* dialog.

{% include figure image_path="/assets/images/posts/artifacts-create-new-project.png" alt="Azure Artifacts - Create new Project" caption="Azure Artifacts - Create new Project." %}

Enter a `project name`, `description`, and `visibility` for the project.  If you want to change the default version control of *git* and the default work item process of *agile* click the **Advanced** option.

Since I am going to be using this project for future demos, I am going to make it public. I've entered the following for this new project.

| --- | --- |
| Field Name | Value |
| --- | --- |
| Project name | Public |
| Description | This project is used to demonstrate different aspects of Azure DevOps for blog posts and demos at [JosephGuadagno.net](/) |
| Visibility | Public |

And I am leaving the defaults for `version control` and `work item process`.

**NOTE**: The default for an organization is *private*.  You have to edit your organizational security policy to go public.  For most people and organizations that you don't want to be public.  I'm only doing this for the demo.  *Famous last words* :smile:

## Artifacts

After creating the project, Azure DevOps takes you right to the Project home page.  You can access the projects Artifacts section using the table of contents to the left.

{% include figure image_path="/assets/images/posts/artifacts-table-of-contents.png" alt="Azure Artifacts - Project Table of Contents" caption="Azure Artifacts - Project Table of Contents." %}

Earlier I said that Azure Artifacts are as part of a project, while that is partially true, for the most part it isn't.  You can see in the image below that after I clicked on *Artifacts* I see one of my other feeds (*SupportLibraries*).  The separate project for me is so I can separate the repositories for each package.  In theory, you can do that for any project and/or repository. I just like them separate.

{% include figure image_path="/assets/images/posts/artifacts-feeds.png" alt="Azure Artifacts - Feed View" caption="Azure Artifacts - Feed View." %}

### Create the Feed

Let's create a feed.  A feed, in NuGet terms, is your repository.  This is where you put all of your NuGet packages.

Click the '+ Create Feed' button.

{% include figure image_path="/assets/images/posts/artifacts-create-feed.png" alt="Azure Artifacts - Create Feed" caption="Azure Artifacts - Create Feed." %}

I've entered the following for the new feed.  Keep in mind, as the note states beneath the `name` field, this name will appear in the URL for your feed.

| --- | --- |
| Field Name | Value |
| --- | --- |
| Name | SharedPackages |
| Visibility | Public |

**Note**: you can not change the visibility of this feed since it is tied to the public '*Public*' project.

Click 'Create'

Once the creation is done, you are ready to connect to the feed.

{% include figure image_path="/assets/images/posts/artifacts-connect-to-feed.png" alt="Azure Artifacts - Connect to the Feed" caption="Azure Artifacts - Connect to the Feed." %}

## Connect to the Feed

I'm not going to the document how you connect to the feed.  If you click on 'Connect to Feed' you will different options depending on the type of package management tool you are using.

Instructions are provided for

* [NuGet](https://www.jetbrains.com/help/rider/Using_NuGet.html#sources)
  * dotnet
  * NuGet.exe
  * Visual Studio
* [npm](https://docs.microsoft.com/en-us/azure/devops/artifacts/get-started-npm?view=azure-devops&tabs=windows)
  * npm
* [Maven](https://docs.microsoft.com/en-us/azure/devops/artifacts/get-started-maven?view=azure-devops)
  * Maven
  * Gradle
* [Python](https://docs.microsoft.com/en-us/azure/devops/artifacts/quickstarts/python-packages?view=azure-devops)
  * pip
  * twine
* [Universal](https://docs.microsoft.com/en-us/azure/devops/artifacts/quickstarts/universal-packages?view=azure-devops)
  * Universal packages

*Universal* gives you command line instructions for a 'catch all' scenario to get the package(s) onto your machine if the package manager you are using doesn't have instructions on the site.

### JetBrains Rider

Instructions for [JetBrains](https://www.jetbrains.com/) [Rider](https://www.jetbrains.com/rider/) are not included. I could only assume it's not included because it's a competing product to Visual Studio.  In case your google-fu is off.  You can manage your NUGet packages in Rider as documented at [Manage package sources](https://www.jetbrains.com/help/rider/Using_NuGet.html#sources). For the values for `packageSources`, click on 'Connect to Feed', then select 'NuGet.exe'.
