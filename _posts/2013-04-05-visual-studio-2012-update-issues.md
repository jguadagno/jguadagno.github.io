---
id: 251
title: Visual Studio 2012–Update Issues
date: 2013-04-05T16:12:35+00:00
author: Joseph Guadagno
layout: post
guid: http://www.josephguadagno.net/post.aspx?id=9d0f0ed8-776d-45ab-92cd-4f3dbcac72b8
permalink: /2013/04/05/visual-studio-2012-update-issues/
dsq_thread_id:
  - "3814990096"
categories:
  - Visual Studio
---
<p>Yesterday I decided to re-pave my personal development machine because it was acting crazy.&#160; Since Visual Studio 2012 <a href="http://www.microsoft.com/en-us/download/details.aspx?id=38188">Update 2</a> came out on that day, it was a no brainer for me to install Visual Studio 2012 and then apply Visual Studio 2012 Update 2.&#160; All of the installations when fine until I tried applying the Visual Studio 2012 Update 2.&#160; It keep on failing, and I mean like 15 times.&#160; I tried running under administrative user, with / without anti virus, I tried downloading the “offline” version<sup>1</sup>.&#160;&#160; However, NOTHING worked.&#160; I kept getting an error reporting that the package <strong>vc_runtimeMinimum_x64</strong> was failing.&#160; I tried downloading the lasted version of it from Microsoft downloads but that did not work. After reading a couple of threads on the <a href="http://social.msdn.microsoft.com/Forums/en-US/vssetup/threads">Visual Studio Setup and Installation forums</a> and trying a few things I eventually got it to install. It did complain about a few different items not available but I did not have those products installed.</p>  <p>So what fixed, you asked? Windows Update!&#160; More so I believe it was <a href="http://support.microsoft.com/kb/2781514/en-us">KB2781514</a> that did the trick. So you need to make sure your computer is totally update to date with the latest updates for this to work.</p>  <p><sup>1</sup> Run from the command line <font face="Courier New">vs2012.2.exe /layout</font> to download all of the files at once.</p>