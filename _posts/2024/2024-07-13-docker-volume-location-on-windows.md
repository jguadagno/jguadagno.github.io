---
title: "Docker Volume Location on Windows"
header:
    og_image: /assets/images/posts/header/docker-volume-location-on-windows.png
date: 2024-07-13 08:40:00 -0700
last_modified_at: 2025-01-11 20:10:00 -0700
categories:
- Articles
tags:
- Containers
- Docker
- Windows11
---
Like a lot of engineers nowadays, I use Docker for my development environment.  I have a Windows 11 machine with [Windows Subsystem for Linux (WSL)](https://learn.microsoft.com/en-us/windows/wsl/about?wt.mc_id=DT-MVP-4024623){:target="_blank"} and I use Docker Desktop for Windows.  I also use Developer Containers with a volume for the source code to work with my blog, which means the files are not stored on the local file system but in a Docker volume.  Occasionally, I need to access the files in the Docker volume for image creation.  This post will show you how to access the files in the Docker volume on Windows.

First off, this post assumes you have Windows, either Windows 10 or Windows 11, with WSL and Docker Desktop installed.  If you don't have Docker Desktop installed, you can download it from [Docker Hub](https://hub.docker.com/){:target="_blank"}.

## Docker Volume Location

**Update**: 2025-01-11: Docker changed the locations of the volumes with release *v26.1.4*.
{: .notice--info}

When you use Docker Desktop on Windows, the Docker volumes are stored in the WSL file system.  The WSL file system is located at `\\wsl$\` on the Windows file system.  

If you want to see what version of docker you are running, you can open a command prompt or Powershell and run the following command.

```bash
docker --version
```

### Current Docker Version (v26.1.4 and Higher)

The Docker volumes are stored in the WSL file system at `\\wsl$\docker-desktop\mnt\docker-desktop-disk\data\docker\volumes`.  You should see a folder for each volume you have created in Docker Desktop. ***Note***: The `wsl.localhost` is no longer used in the path.

### Previous Docker Version (v26.1.3 and Lower)

The Docker volumes are stored in the WSL file system at `\\wsl.localhost\docker-desktop-data\data\docker\volumes`.  You should see a folder for each volume you have created in Docker Desktop.

Here is a screenshot of my Docker Desktop volumes.

![Docker Volume Location](/assets/images/posts/2024/docker-volume-location-on-windows/docker-desktop-volumes.png)

Here is a screenshot of the WSL file system with the Docker volumes.

![Windows Explorer Volume](/assets/images/posts/2024/docker-volume-location-on-windows/windows-volumes.png)

As you can see, there is a one to one mapping between the Docker Desktop volumes and the WSL file system.  If you access these volumes regularly outside of the containers, you might want to rename the folders to something more meaningful.

### Accessing the Volumes

If you do access the volumes a lot, you can create a symbolic link to the volumes folder.  To do this, open a command prompt or Powershell as an administrator and run the following command.

***Note***: You can change the `C:\Volumes` to any folder you want to use.
{: .notice}

#### Command Prompt

Version 26.1.4 and Higher

```bash
mklink /D C:\Volumes \\wsl$\docker-desktop\mnt\docker-desktop-disk\data\docker\volumes
```

Version 26.1.3 and Lower

```bash
mklink /D C:\Volumes \\wsl.localhost\docker-desktop-data\data\docker\volumes
```

#### PowerShell

Version 26.1.4 and Higher

```shell
New-Item -ItemType SymbolicLink -Path "c:\Volumes" -Target "\\wsl$\docker-desktop\mnt\docker-desktop-disk\data\docker\volumes"
```

Version 26.1.3 and Lower

```shell
New-Item -ItemType SymbolicLink -Path "c:\Volumes" -Target "\\wsl.localhost\docker-desktop-data\data\docker\volumes"
```

#### File Explorer

If you open up File Explorer, you should see a folder called `Volumes` in the root of the `C:\` drive.  This folder is a symbolic link to the Docker volumes.

![Windows Explorer - Linux Docker Desktop Volumes](/assets/images/posts/2024/docker-volume-location-on-windows/docker-desktop-folder-highlighted.png)

## Wrap Up

In this post, you learned where the Docker volumes are stored when using Docker Desktop on Windows.  You also learned how to access the Docker volumes from the Windows file system and create shortcuts to them.

## References

* [Stack Overflow](https://stackoverflow.com/questions/61083772/where-are-docker-volumes-located-when-running-wsl-using-docker-desktop){:target="_blank"}.
* [Stack Overflow](https://stackoverflow.com/questions/43181654/locating-data-volumes-in-docker-desktop-windows){:target="_blank"}.
* [Windows Subsystem for Linux (WSL)](https://learn.microsoft.com/en-us/windows/wsl/about?wt.mc_id=DT-MVP-4024623){:target="_blank"}.
