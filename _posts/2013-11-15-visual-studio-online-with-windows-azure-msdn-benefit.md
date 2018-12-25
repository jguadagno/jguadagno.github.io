---
id: 181
title: Visual Studio Online with Windows Azure MSDN benefit
date: 2013-11-15T12:52:34+00:00
author: Joseph Guadagno
layout: post
guid: http://www.josephguadagno.net/post.aspx?id=869e8035-9b69-4156-949c-d991032c2b74
permalink: /2013/11/15/visual-studio-online-with-windows-azure-msdn-benefit/
dsq_thread_id:
  - "3570334330"
categories:
  - Articles
  - Azure
  - Visual Studio
tags:
  - Azure
  - Microsoft Azure
  - Visual Studio
  - Visual Studio Online
  - Windows Azure
---
<p>I don’t know about you but when I watched the Visual Studio launch earlier this week I was really excited about some of the cool new features added. The first thing I wanted to try out was <a href="Visual Studio Online" target="_blank">Visual Studio Online</a>. I figured I have a Windows Azure account setup through my MSDN subscription so I’d be set.&#160; Unfortunately, like most people found out when they tried to add their Visual Studio Online account they could not.&#160; We were all getting this message…</p>  <blockquote>   <p>You have no <a href="http://go.microsoft.com/fwLink/?LinkID=317720&amp;clcid=0x409">eligible Windows Azure subscriptions</a>. To buy monthly user licenses or shared resources for your Visual Studio Online account, you’ll need another <a href="http://go.microsoft.com/fwLink/?LinkID=328562&amp;clcid=0x409">Windows Azure subscription</a>.</p> </blockquote>  <p>I went to the Windows Azure account portal to make sure that I did have an active subscription, in fact I have two, but I still could not add or link my existing Visual Studio Online account.&#160; I posted a message on one of the Windows Azure list and after a few hours some one pointed me to this <a href="http://social.msdn.microsoft.com/Forums/vstudio/en-US/1176969f-7389-4e6b-937e-20b17726487f/visual-studio-online-eligibility?forum=TFService" target="_blank">forum post</a>. This forum post explains why you can not add an Visual Studio Online account to an existing Windows Azure MSDN account.&#160; It essentially boils down to billing.&#160; The Windows Azure MSDN benefit has the ability to “cap” the spending in Windows Azure.&#160; This does not work for Visual Studio Online. If you think about it, it makes sense. Do you not want to lose access to your source code because you hit your spending limit? Probably not.&#160; In order to add your Visual Studio Online account you have to get create a Windows Azure “Pay as you Go” subscription.&#160; Don’t worry, you get a bunch of the benefits <a href="http://www.windowsazure.com/en-us/pricing/details/visual-studio-online/" target="_blank">free</a>. </p>  <blockquote>   <p>Within a Visual Studio Online account, you simply pay for user plans for the users who join your account and for resources that are shared amongst all users on the account. The first five users with the Basic plan and all eligible MSDN subscribers (Visual Studio Professional with MSDN and above) can join your account at no charge. <a href="http://go.microsoft.com/fwlink/?linkid=328238&amp;clcid=0x409">Learn more about Visual Studio with MSDN</a>.</p> </blockquote>  <p>Hopefully this helps.&#160; My next post will talk about <a href="http://www.josephguadagno.net/post/2013/11/15/Adding-Visual-Studio-Online-to-an-Windows-Azure-MSDN-Benefit-Subscription" target="_blank">Adding Visual Studio Online to an Windows Azure MSDN benefit</a>.</p>