---
title: "Clean up some .NET Clutter"
header:
    og_image: /assets/images/posts/header/dot-net-cleanup.png
date: 2022-06-15 14:55:00 -0700
categories:
  - Articles
tags:
  - dotnet
  - sdk
  - runtime
  - csharp
  - vb
  - visualbasic
  - .NET Core
  - .NET
---
As some of you know, I do a lot of public speaking and blogging, 
although the blogging seems to have taken a vacation lately :smile:.
One of the side effects of blogging and speaking is that I have a lot of versions of .NET on my machine, along with other software.
Today, after installing the latest version of [.NET](https://devblogs.microsoft.com/dotnet/announcing-dotnet-7-preview-5/){:target="_blank"}, I took a look at what versions of the SDK and runtime I have on my machine.
I was a bit surprised to see that as to how many versions of .NET were on my machine.

I had around 20 versions of .NET SDKs on my machine.

![.NET SDKs Before Cleanup](/assets/images/posts/dot-net-cleanup-sdk-before.png)

And close to 20 versions of .NET Runtime on my machine.

![.NET Runtimes Before Cleanup](/assets/images/posts/dot-net-cleanup-runtime-before.png)

I decided to clean up some older versions of .NET SDKs and Runtime.
This is where the [.NET Uninstall Tool](https://docs.microsoft.com/en-us/dotnet/core/additional-tools/uninstall-tool?tabs=windowsapplication&WT.mc_id=AZ-MVP-4024623) comes in handy. This tool allows you to see older versions of .NET SDKs and Runtime and uninstall them.

You can download the tool [here](https://github.com/dotnet/cli-lab/releases){:target="_blank"}.
There are instructions for installation for both Windows and macOS.

## Using the Uninstall Tool

### See the Versions of .NET SDKs and Runtime

Once the tool is installed,
you can use it to see the versions of .NET SDKs and Runtime that are installed on your machine by executing the following command:

```powershell
./dotnet-core-uninstall list
```

This will show you a list similar to the images above.

If you are not ready to uninstall a particular version of the .NET SDK or Runtime, you can use the following command to see what would happen if you were to uninstall that version:

```powershell
./dotnet-core-install dry-run
```

### Uninstall the .NET SDKs and Runtime

There are quite a few different ways to uninstall the .NET SDKs and Runtime's.
For each option you need to choose either the `sdk`, `runtime`, `aspnet-runtime`, or `hosting-bundle`.
You then need to specify which versions you want to uninstall.
There are options for `all`, `all-but-latest`, `latest`, and many more.
You can see the full list of options [here](https://docs.microsoft.com/en-us/dotnet/core/additional-tools/uninstall-tool?tabs=windows&application?WT.mc_id=AZ-MVP-4024623#options-1){:target="_blank"}.

I chose to use the `all-previews-but-latest` option, this will uninstall all the previews .NET SDKs and Runtime versions except the latest version of the specific preview.
And the `all-but-latest` option, which will uninstall all the .NET SDKs and Runtime versions except the latest version of the major version.

After running each of the commands, my machine will look like the image below.

![.NET SDKs and Runtime After Cleanup](/assets/images/posts/dot-net-cleanup-after.png)

### Script to Uninstall .NET SDKs and Runtime

Here is the script I used to uninstall the .NET SDKs and Runtime.

Note: the script requires elevated permissions to run.
{: .notice--info }

#### macOS

```powershell
sudo ./dotnet-core-uninstall remove --all-previews-but-latest --sdk
sudo ./dotnet-core-uninstall remove --all-previews-but-latest --runtime
sudo ./dotnet-core-uninstall remove --all-lower-patches --sdk
sudo ./dotnet-core-uninstall remove --all-lower-patches --runtime
```

#### Windows

```powershell
./dotnet-core-uninstall remove --all-previews-but-latest --sdk
./dotnet-core-uninstall remove --all-previews-but-latest --runtime
./dotnet-core-uninstall remove --all-lower-patches --sdk
./dotnet-core-uninstall remove --all-lower-patches --runtime
```

## Wrap Up

It was pretty easy to unclutter my machine of the older versions of .NET SDKs and Runtime
once I had the Uninstall Tool installed and ran the script.
Now, I have to remember to run this script every once in a while.
