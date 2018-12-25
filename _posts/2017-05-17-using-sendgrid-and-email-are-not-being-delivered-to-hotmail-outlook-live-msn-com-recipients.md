---
id: 10612
title: Using SendGrid and emails are not being delivered to Hotmail/Outlook/Live/MSN.com recipients?
date: 2017-05-17T17:03:56+00:00
author: Joseph Guadagno
layout: post
guid: https://www.josephguadagno.net/?p=10612
permalink: /2017/05/17/using-sendgrid-and-email-are-not-being-delivered-to-hotmail-outlook-live-msn-com-recipients/
categories:
  - Articles
  - Azure
  - Web
tags:
  - Azure
  - gmail.com
  - Hotmail.com
  - Live.com
  - msn.com
  - Outlook.com
  - SendGrid
  - yahoo.com
---
[lead] <em>Me too, or at least I was</em>... While the problem I was having might not be related to SendGrid exclusively, I am going to talk about the solution.[/lead]<br>

<h2>The Problem</h2>
<p class="text-justify">Before I go into the solution, let's talk about the problem first. Many of you know that I run Desert Code Camp in Chandler, AZ. Originally, the site ran on the Microsoft stack, it used ASP.NET (Web Forms) and SQL Server. There is an API for mobile apps and future development but that's another story. The site has 12,000 registered users. A few thousand are SPAM/Bots, a few thousand are "inactive" accounts (opted out or moved), and the other 6000 or so are active users that have an interest in Desert Code Camp or have attended at least one.</p>
<p class="text-justify">And here lies the first problem.</p>
<p class="text-justify">When an announcement email goes out to our attendees or users of the site, we need to send out about 6000 emails. I used to do this by sending the email from a web page through code using <code>System.Net.SMTP</code> via <code>localhost</code>. At first, it wasn't an issue. After a while, as Desert Code Camp grew, this became more and more of a problem. Typically the page would time out or IIS would die or something. So I needed to find a solution. Sometime last year, probably around this time, I offloaded the processing of emails to <a href="https://azure.microsoft.com/en-us/services/storage/queues/" target="_blank" rel="noopener noreferrer">Azure Queue Storage</a> and used <a href="https://docs.microsoft.com/en-us/azure/app-service-web/websites-webjobs-resources" target="_blank" rel="noopener noreferrer">Azure WebJobs</a> to handle the "logic". But wait, Azure does not support sending stuff via <code>localhost</code>. And that is true! This is where <a href="https://www.sendgrid.com/" target="_blank" rel="noopener noreferrer">SendGrid</a> comes into play. Azure provides, as of the creation of this post, a free 25,000 email per month subscription to SendGrid. For more on that, check out this <a href="https://docs.microsoft.com/en-us/azure/app-service-web/sendgrid-dotnet-how-to-send-email" target="_blank" rel="noopener noreferrer">post</a>.</p>
<p class="text-justify">Now that I implemented the new Azure/SendGrid combination everything was great.</p>
<p class="text-justify">Fast forward a year, to this past weekend, I announced that the next <a href="https://oct2017.desertcodecamp.com">Desert Code Camp</a> was happening on Twitter and some people started submitting sessions. This is great! But I noticed that I was wasn't getting my emails about the submissions.  At first, I thought, "Oh Joe, you forgot something when you 'created' the new event".  It happens every time :). However, this was not the case this time. Microsoft decided to <a href="https://sendgrid.com/docs/Classroom/Deliver/Sender_Authentication/microsoft_dmarc_changes.html" target="_blank" rel="noopener noreferrer">embrace</a> something called <a href="http://sendgrid.com/blog/dmarc-domain-based-message-authentication-reporting-conformance/" target="_blank" rel="noopener noreferrer">DMARC</a>, Domain-based Message Authentication, Reporting &amp; Conformance. In a nutshell, it checks to see if you are sending emails from the domain you claim you are sending them from, which for me was bad.  Not because I was trying to be deceitful, but because I was sending emails saying they were from '<em>@hotmail.com</em>' and sending them via '<em>SendGrid</em>' because I wanted people to reply to my Hotmail address. Well, when Microsoft implemented the DMARC...</p>
<div class="shadow-none p-3 mb-5 bg-light rounded"><strong>What this means:</strong> As of June 2016, you can no longer send with the From address being anything from a Microsoft address when sending to a domain that checks DMARC before accepting mail.</div>
<p class="text-justify">... it saw my email as not being '<em>legitimate</em>' and did not deliver it to my inbox and probably others.</p>

<h2>The Solution</h2>
<p class="text-justify">The answer is '<a href="http://sendgrid.com/blog/dmarc-domain-based-message-authentication-reporting-conformance/" target="_blank" rel="noopener noreferrer">Whitelist</a>' your domains while using SendGrid. There are more detailed instructions on how to whitelist a domain using SendGrid </a><a href="https://sendgrid.com/docs/Classroom/Basics/Whitelabel/index.html" target="_blank" rel="noopener noreferrer">here</a><a href="http://sendgrid.com/blog/dmarc-domain-based-message-authentication-reporting-conformance/" target="_blank" rel="noopener noreferrer">. </a></p>

<h3>What is Whitelabeling?</h3>
<p class="text-justify">Whitelabeling allows you to send through your own custom domain instead of SendGrid's default settings. This will mask the header information of your emails with your data--not theirs--and will improve your email deliverability.</p>

[caption id="attachment_10614" align="aligncenter" width="896"]<a href="https://www.josephguadagno.net/wp-content/uploads/2017/05/whitelabeling.png"><img class="wp-image-10614 size-full" src="https://www.josephguadagno.net/wp-content/uploads/2017/05/whitelabeling.png" alt="" width="896" height="330" /></a> Non-Whitelabeled Example vs. Whitelabeled Example[/caption]
<p class="text-justify">Luckily, SendGrid makes it easy to whitelist your domain(s). Here is how you do it. <strong>Please note:</strong> <em>You will need access to your domain records, you will be making changes to your TXT or CNAME entries to prove you have rights to the domain</em>.</p>

<ul>
 	<li>First, log-in to your SendGrid Account</li>
 	<li>Click 'Settings' (on the left)</li>
 	<li>Click 'Whitelabels'</li>
 	<li>Click [button type="primary" size="sm" link="#"] + Add Domain [/button] button.</li>
 	<li>SendGrid will walk you though everything else you need.</li>
</ul>

<h3>But what about the replies to @Hotmail.com</h3>
<p class="text-justify">I'm glad you are still with me :).  This part is the easy part.  Essentially, I added '<em>noreply@desertcodecamp.com</em>' as the ToAddress and added '<em>jguadagno@hotmail.com</em>' as the ReplyTo. As shown in this gist.</p>

<script src="https://gist.github.com/jguadagno/c81dc63e703278db5a78ad81fd5e659e.js"></script>

I hope this saves you some time to troubleshoot mail delivery to @hotmail.com, @outlook.com, @live.com, @msn.com, @yahoo.com, and @gmail.com.