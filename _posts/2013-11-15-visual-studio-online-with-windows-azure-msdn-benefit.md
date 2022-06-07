---
title: Visual Studio Online with Windows Azure MSDN benefit
date: 2013-11-15T12:52:34+00:00
permalink: /2013/11/15/visual-studio-online-with-windows-azure-msdn-benefit/
dsq_thread_id:
  - "3570334330"
categories:
  - Articles
tags:
  - Azure
  - Microsoft Azure
  - Visual Studio
  - Visual Studio Online
  - Windows Azure
---
I don't know about you but when I watched the Visual Studio launch earlier this week I was really excited about some of the cool new features added. The first thing I wanted to try out was [Visual Studio Online](Visual Studio Online). I figured I have a Windows Azure account set up through my MSDN subscription so I'd be set.  Unfortunately, like most people found out when they tried to add their Visual Studio Online account they could not.  We were all getting this message…

You have no [eligible Windows Azure subscriptions](https://go.microsoft.com/fwLink/?LinkID=317720&clcid=0x409){:target="_blank"}. To buy monthly user licenses or shared resources for your Visual Studio Online account, you'll need another [Windows Azure subscription](https://go.microsoft.com/fwLink/?LinkID=328562&clcid=0x409){:target="_blank"}.

I went to the Windows Azure account portal to make sure that I did have an active subscription, in fact, I have two, but I still could not add or link my existing Visual Studio Online account.  I posted a message on one of the Windows Azure list and after a few hours someone pointed me to this [forum post](https://social.msdn.microsoft.com/Forums/vstudio/en-US/1176969f-7389-4e6b-937e-20b17726487f/visual-studio-online-eligibility?forum=TFService&WT.mc_id=DOP-MVP-4024623){:target="_blank"}. This forum post explains why you can not add a Visual Studio Online account to an existing Windows Azure MSDN account.  It essentially boils down to billing.  The Windows Azure MSDN benefit has the ability to “cap” the spending in Windows Azure.  This does not work for Visual Studio Online. If you think about it, it makes sense. Do you not want to lose access to your source code because you hit your spending limit? Probably not.  In order to add your Visual Studio Online account, you have to get create a Windows Azure “Pay as you Go” subscription.  Don't worry, you get a bunch of the benefits [free](https://www.windowsazure.com/en-us/pricing/details/visual-studio-online/){:target="_blank"}.

> Within a Visual Studio Online account, you simply pay for user plans for the users who join your account and for resources that are shared amongst all users on the account. The first five users with the Basic plan and all eligible MSDN subscribers (Visual Studio Professional with MSDN and above) can join your account at no charge. [Learn more about Visual Studio with MSDN](https://go.microsoft.com/fwlink/?linkid=328238&clcid=0x409){:target="_blank"}.

Hopefully, this helps.  My next post will talk about [Adding Visual Studio Online to a Windows Azure MSDN benefit]({% link _posts/2013-11-15-visual-studio-online-with-windows-azure-msdn-benefit.md %}).