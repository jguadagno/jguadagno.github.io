---
title: "Windows 11 - A First Look"
date: 2021-07-02 21:35:00 -0700
last_modified_at: 2021-07-05 16:30:00 -07:00
header:
    og_image: /assets/images/posts/header/windows11-a-first-look.png
redirect_from:
    - /2021/07/02/windows-11-a-first-lookk
categories:
  - Articles
tags:
  - Windows11
---
Windows 11 or I am calling it right now, the *Who Moved My Cheese Edition*, was announced and shown to the world a few days ago. Why do you call it the *Who Moved My Cheese Edition*, you ask? Not so much since things were moved around but more so the User Interface has changed a lot. As Microsoft puts it, *A Fresh Perspective*.

> Windows 11 provides a calm and creative space where you can pursue your passions through a fresh experience. From a rejuvenated Start menu to new ways to connect to your favorite people, news, games, and content—Windows 11 is the place to think, express, and create in a natural way.

I was curious as to what the new Windows 11 was going to be like. So I wanted to get it installed.  

At the writing of this posts, Windows 11 is only available to [Windows Insiders](https://insider.windows.com/) in the **Dev** channel.  
{: .notice--info}

I'm a Windows insider but in the *Beta*. So on Thursday, I switched to the **Dev** channel and Windows 11 almost immediately started downloading after I verified the laptop I was planning to install Windows 11 on meet the [minimum hardware requirements](https://www.microsoft.com/en-us/windows/windows-11-specifications).

![Windows 11 Downloading](/assets/images/posts/windows11-devchannel-restart.png){: .align-center}

The download completed in under 30 minutes.  Once I clicked restart, after about 10 minutes and three or four reboots I was presented with a shiny new Windows 11.

Here is what I noticed in the first few hours of using Windows 11.

***NOTE***: Last updated on July 5th, 2021 with the Update/Shutdown estimates.
{: .notice--info}

## User Interface Changes

From what I can tell a lot of work went into creating a new, modern user interface.  The font selection is different, more crisp.  There icons have more color. Windows now have curved corners instead of the rectangular corners.

## Operating Systems Updates

Now when the system has updates to apply and you chose the power icon, you get prompted with estimates as to how long Windows should take to apply the updates and restart or shutdown.

![Windows 11 - Apply Update](/assets/images/posts/windows11-devchannel-shutdown-estimate.png){: .align-center}

Let's just hope it never says '*5 seconds remaining*' :smile:

### Start Menu

The Start menu is one of the biggest and most notable changes.  It's been redone, again :smile:.  There are no more Live Tiles but static icons and text.

![Windows 11 - Start Menu](/assets/images/posts/windows11-devchannel-start-menu.png){: .align-center}

All of the *pinned* applications are on the top.  This is a scrolling list as indicated by the two dots on the right hand side.  The lower half of the Start menu are your *recommended* applications and files. In the image above I have the *Get Started*, a few PowerPoint decks, a Word document, and an Excel spreadsheet. You can click on the *All apps >* button on the top to get an alphabetical list of applications installed. Clicking on the *More >* will take you to a list of your recent files.

### Task Bar

The task bar is probably the first notable change you will see.

![Windows 11 - Task Bar](/assets/images/posts/windows11-devchannel-taskbar-icons.png){: .align-center}

If you are a MacOS user, you will notice some similarity.  The new task bar is centered on your desktop.  It may be possible to move it but I haven't checked yet.  There are dashes or underlines underneath the icons to let you know which ones are open and which is the window with focus.  In the image above, I have Microsoft Edge, Slack, and Windows File Explorer open.  Windows File Explorer was the active window at the time of the snapshot.

There are also some new buttons added to the left of the task bar.

![Windows 11 - Task Bar - Special Icons](/assets/images/posts/windows11-devchannel-taskbar-special-icons.png){: .align-center}

The first icon is the Windows Start Menu, highlighted above.

The second icon is the new Windows Search.

![Windows 11 - Windows Search](/assets/images/posts/windows11-devchannel-search.png){: .align-center}

Not much different with this search page from previous versions.

The third button is the task view. Which if you hover over it brings up a smaller version of what is running on your desktops.

![Windows 11 - Task View - Preview](/assets/images/posts/windows11-devchannel-task-view.png){: .align-center}

If you click on the Task View button, or four finger swipe upwards, you'll get a new task view.  So far, I am not a fan, it currently added and extra title bar to the windows.  This might be to enable the *touch* experience with tablets.

![Windows 11 - Task View](/assets/images/posts/windows11-devchannel-app-view.png){: .align-center}

The fourth button is the new Widget component.  More on that later.

#### Task Tray

The next round of noticeable changes were in the task tray.  The task tray is that area, typically in the lower right hand corner of the screen where the date and time are displayed.

![Windows 11 - Task Tray](/assets/images/posts/windows11-devchannel-task-tray.png){: .align-center}

#### Notification Window

The notification window had some big changes. This is brought up if you click on the network/sound icons.

![Windows 11 - Notification Center](/assets/images/posts/windows11-devchannel-notification-center.png){: .align-center}

Here you will the first set of changes which are more touch friendly.  There is more spacing around the buttons and sliders. In addition, there is easy access to the configuration of the notifications and settings.

## Windows File Explorer

The Windows File Explorer received some new icons and better spacing between objects.

### The Navigation Pane

![Windows 11 - Explorer - Navigation Pane](/assets/images/posts/windows11-devchannel-navigation-pane.png){: .align-center}

You might notice the *Linux* folder item.  This appears because I have Docker on this machine along with [Windows Subsystem for Linux (WSL)](https://docs.microsoft.com/en-us/windows/wsl/install-win10)

![Windows 11 - Explorer - Linux](/assets/images/posts/windows11-devchannel-linux.png){: .align-center}

### Folder Icons

The folder icons received some updates also.

![Windows 11 - Explorer - Folder Icons](/assets/images/posts/windows11-devchannel-folder-icons.png){: .align-center}

## New Functionality

These are the new(ish) items I discovered in the Windows 11

### Clipboard Viewer and then some

What used to the be the Clipboard Viewer (Accessible via the Windows Key + V) not only views the clipboard but allows you to paste, emoticons, GIFs, special characters, and more.  It's almost like its an extra input manager.

![Windows 11 - Clipboard Viewer](/assets/images/posts/windows11-devchannel-clipboard-viewer.png){: .align-center}

### Widgets

This is the biggest, net new, functionality that I've seen.  Widgets seems like the first step in supporting running Android applications and mimicking some of its functionality.

![Windows 11 - Widgets](/assets/images/posts/windows11-devchannel-widget-display.png){: .align-center}

In this very long screenshot you will see there are a lot of Widgets on by default, I will be disabling most of them :smile:

You can add/remove widgets by clicking the **Add Widget** button.  Here are the options that we presented at the time of writing this post.

![Windows 11 - Add/Remove Widgets](/assets/images/posts/windows11-devchannel-add-widgets.png){: .align-center}

### Teams Integration

Having tried it yet, maybe an future update to this post will have something. According to the Windows 11 site.

> With Windows 11, we’re excited to introduce Chat from Microsoft Teams integrated in the taskbar. Now you can instantly connect through text, chat, voice or video with all of your personal contacts, anywhere, no matter the platform or device they’re on, across Windows, Android or iOS. If the person you’re connecting to on the other end hasn’t downloaded the Teams app, you can still connect with them via two-way SMS.

### Android Applications

While this feature is not yet available, the plan is to all you to be able to discover Android application through the Windows store and download them through the Amazon App Store.  And yes, *they will run on the Windows PC*.  This is probably why we see more of the Linux/WSL integration.

## Wrap Up

I'll update this post as I experiment more with Windows 11 over the next few days.

Please remember that this is an early access version, some of the features maybe removed or changed.
{: .notice--info }

More on [Windows 11](https://www.microsoft.com/en-us/windows/windows-11)