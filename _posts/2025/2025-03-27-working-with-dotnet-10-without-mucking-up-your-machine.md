---
title: "Working with dotnet 10 Without Mucking Up Your Machine"
excerpt: "This article provides insights on how to work with dotnet 10 effectively using Development Containers without affecting your local machine setup."
header:
    og_image: /assets/images/posts/header/dotnet10-development-container.png
date: 2025-03-27 11:57:00 -0700

categories:
- Articles
tags:
- Containers
- Docker
- .NET
- ASP.NET Core
---
I've been wanting to start working with .NET 10, but I didn't want yet another version of .NET on my laptop. Although, I could cleanup the clutter like in this post, [Clean Up Some .NET Clutter]({% post_url 2022/2022-06-15-clean-up-some-dot-net-clutter %}){:target="_blank"}, I wanted to use a Development Container. This posts will show you how to work with dotnet 10 effectively using Development Containers without affecting your local machine setup.

## Prerequisites

If you are not familiar with Development Containers, I recommend reading my previous article on [Getting Started with Developer Containers]({% post_url /2022/2022-12-10-getting-started-with-developer-containers %}){:target="_blank"} to get a better understanding of what Development Containers are and how to use them.

The rest of this article assumes you have a basic understanding of Development Containers and how to create and use them.

## Create a Development Container

Normally, you would use the Command Pallette in Visual Studio Code to create a new Development Container. However, I'm going to use a `devcontainer.json` file to create a new Development Container because, as of the writing of this posts, there is not a .NET 10 image.

To start, create a folder on your machine, something like `dotnet10`. Within that folder create a `.devcontainer` folder.  Inside that folder, create a `devcontainer.json` file with the following content:

```json
{
    "build": {
        "dockerfile": "./Dockerfile",
        "context": "."
    }
}
```

This instructs Visual Studio Code to use the `Dockerfile` in the current folder to build the Development Container.  Let's now create the `Dockerfile` with the following content:

```dockerfile
# Use the most recent .NET LTS as the base image
FROM mcr.microsoft.com/devcontainers/dotnet:1-8.0

# Install the current .NET STS release on top of that
COPY --from=mcr.microsoft.com/dotnet/sdk:9.0 /usr/share/dotnet /usr/share/dotnet

# Finally install the most recent .NET 10.0 preview using the dotnet-install script
COPY --from=mcr.microsoft.com/dotnet/nightly/sdk:10.0.100-preview.2 /usr/share/dotnet /usr/share/dotnet
```

This `Dockerfile` will add version 8, 9, and 10 of .NET to the Development Container. It starts with the based image of .NET 8, which is the most recent LTS version. It then adds .NET 9 on top of that. Finally, it adds .NET 10.0 Preview 2.

Using this `Dockerfile` will allow you to pull the current version of .NET 10.0 Preview 2. If you want the nightly build, you would just need to rebuild the container and the latest 10.0 Preview 2 will be installed.  For future versions, you would just need to change the version number in the `Dockerfile`.

Save the `Dockerfile` and `devcontainer.json` files.  Now, open the folder in Visual Studio Code.  You should see a prompt to reopen the folder in a Development Container.  Ignore that prompt for now.

### Add VS Code Extensions

Next, we will want to add some extensions to Visual Studio Code.  I recommend the following extensions to aid in development:

* [Stoplight Spectral Extension](https://marketplace.visualstudio.com/items?itemName=stoplight.spectral&WT.mc_id=DT-MVP-4024623){:target="_blank"}
* [OpenAPI (Swagger) Editor Extension](https://marketplace.visualstudio.com/items?itemName=42Crunch.vscode-openapi&WT.mc_id=DT-MVP-4024623){:target="_blank"}
* [VS Code Icons](https://marketplace.visualstudio.com/items?itemName=vscode-icons-team.vscode-icons&WT.mc_id=DT-MVP-4024623){:target="_blank"}
* [REST Client](https://marketplace.visualstudio.com/items?itemName=humao.rest-client&WT.mc_id=DT-MVP-4024623){:target="_blank"}

To do this, edit the `.devcontainer/devcontainer.json` file to include the following:

```json
{
    "customizations": {
        "vscode": {
            "extensions": [
                "ms-dotnettools.csdevkit",
                "ms-dotnettools.dotnet-interactive-vscode",
                "vscode-icons-team.vscode-icons",
                "humao.rest-client",
                "42Crunch.vscode-openapi",
                "stoplight.spectral"
            ]
        }
    }
}
```

### Startup script

Finally, we will want to add a startup script to the `.devcontainer` folder. I generally would create a `scripts` folder within the `.devcontainer` folder. This script will be run when the Development Container starts. Create a `scripts/postCreateCommand.sh` file with the following content:

```bash
#!/bin/bash

# Update the workloads
sudo dotnet workload update

# EF Tools
dotnet tool install -g dotnet-ef
```

This will update all the workloads and install the Entity Framework tools. Save the file.  You can add any other commands you want to run when the Development Container starts.

Go back to the `devcontainer.json` file and add the following:

```json
{
    "postCreateCommand": ".devcontainer/scripts/postCreateCommand.sh"
}
```

Save the changes to the `devcontainer.json` file.

## Build the Development Container

Now that we have the `Dockerfile`, `devcontainer.json`, and the startup script, we can build the Development Container.  Open the Command Pallette in Visual Studio Code and type **Dev Containers: Rebuild and Reopen in Container**.  This will build the Development Container and open the folder in the Development Container.

Once the Development Container is built, you can start working with .NET 10.  You can create a new project, run tests, and do anything you would normally do with .NET from the Terminal in Visual Studio Code.

## Wrap Up

Using Development Containers is a great way to work with different versions of .NET without cluttering up your local machine.  You can easily switch between versions by changing the `Dockerfile` and rebuilding the Development Container.  You can also add extensions and scripts to make your development environment more productive.

If you want to see a completed example, check out the [dotnet10-devcontainer repository](https://github.com/jguadagno/dotnet10-devcontainer){:target="_blank"}.

If you want to customize the Terminal prompt, you can use the steps in this post, [Add and Customize Oh My Zsh in a Linux Development Container]({% post_url 2025/2025-03-27-add-and-customize-oh-my-zsh-in-a-linux-development-container %}){:target="_blank"}.

## References

* [.NET in a DevContainer](https://devblogs.microsoft.com/dotnet/dotnet-in-dev-container/?WT.mc_id=DT-MVP-4024623){:target="_blank"}
* [Add and Customize Oh My Zsh in a Linux Development Container]({% post_url 2025/2025-03-27-add-and-customize-oh-my-zsh-in-a-linux-development-container %}){:target="_blank"}
* [Stoplight Spectral Extension](https://marketplace.visualstudio.com/items?itemName=stoplight.spectral&WT.mc_id=DT-MVP-4024623){:target="_blank"}
* [OpenAPI (Swagger) Editor Extension](https://marketplace.visualstudio.com/items?itemName=42Crunch.vscode-openapi&WT.mc_id=DT-MVP-4024623){:target="_blank"}
* [VS Code Icons](https://marketplace.visualstudio.com/items?itemName=vscode-icons-team.vscode-icons&WT.mc_id=DT-MVP-4024623){:target="_blank"}
* [REST Client](https://marketplace.visualstudio.com/items?itemName=humao.rest-client&WT.mc_id=DT-MVP-4024623){:target="_blank"}
