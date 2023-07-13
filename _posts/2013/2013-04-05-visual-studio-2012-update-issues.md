---
title: Visual Studio 2012–Update Issues
date: 2013-04-05T16:12:35+00:00
permalink: /2013/04/05/visual-studio-2012-update-issues/
dsq_thread_id:
  - "3814990096"
categories:
  - Articles
tags:
  - Visual Studio
---
Yesterday I decided to re-pave my personal development machine because it was acting crazy.  Since Visual Studio 2012 [Update 2](https://www.microsoft.com/en-us/download/details.aspx?id=38188){:target="_blank"} came out on that day, it was a no brainer for me to install Visual Studio 2012 and then apply Visual Studio 2012 Update 2.  All of the installations when fine until I tried applying the Visual Studio 2012 Update 2.  It keeps on failing, and I mean like 15 times.  I tried running under administrative user, with/without antivirus, I tried downloading the “offline” version 1 .   However, NOTHING worked.  I kept getting an error reporting that the package **vc_runtimeMinimum_x64** was failing.  I tried downloading the lasted version of it from Microsoft downloads but that did not work. After reading a couple of threads on the [Visual Studio Setup and Installation forums](https://social.msdn.microsoft.com/Forums/en-US/vssetup/threads?WT.mc_id=DOP-MVP-4024623){:target="_blank"} and trying a few things I eventually got it to install. It did complain about a few different items not available but I did not have those products installed.

So what fixed, you asked? Windows Update!  More so I believe it was [KB2781514](https://support.microsoft.com/kb/2781514/en-us){:target="_blank"} that did the trick. So you need to make sure your computer is totally updated to date with the latest updates for this to work.

Run from the command line vs2012.2.exe /layout to download all of the files at once.
