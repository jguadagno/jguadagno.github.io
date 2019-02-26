---
title: T-Mobile WiFi Calling
date: 2008-08-25T19:47:13+00:00
author: Joseph Guadagno
permalink: /2008/08/25/t-mobile-wifi-calling/
dsq_thread_id:
  - "3663731864"
categories:
  - Articles
---
A month or so ago I signed up for this new [T-Mobile](http://www.t-mobile.com/) plan that allows you to use your cell/mobile phone to make unlimited calls from almost any WiFi connection.  The reason I say almost is that there are two types of WiFi connections it will not make, a secured WiFi network that you do not have the security key for and any "free" WiFi connections that require you to accept the terms of use (most public access points).  When I saw this deal I signed up almost immediately. The idea that you can be on the road using your normal cell phone tower and they walk into your house and seamlessly have the call transferred to your wireless network was awesome. So I purchased four [Samsung Katalyst T-739](http://www.t-mobile.com/shop/Phones/Cell-Phone-Detail.aspx?cell-phone=Samsung-Katalyst) phones which have WiFI / [UMA](http://en.wikipedia.org/wiki/Generic_Access_Network) calling built in and my journey began. Since then I have had two months of unreliable WiFi calling connectivity. My first connection attempts were with my [AirLink AR430W SuperG Wireless router](http://www.airlink101.com/products/ar430w.php) that I purchased for $15.00 dollars at a local Frys Electronic store. With this router, I would get sporadic WiFi/UMA connectivity on all four phones.  Some of them would connect, some of them would not. I would get one of a few T-Mobile errors; W002 and W010.  After googling for days and weeks, there was not a lot of information about these errors on the Internet. Most of the errors pointed to Blackberry connectivity issues and that errors W002 and W010 means that the device could not get an IP address which was quite strange because of both laptops, my Wii and Xbox 360 all connected fine.  So I began my troubleshooting... First I tried to connect to a friend's un-secure router, every connection attempt was successful and I was making calls but this was not legal. So I tried to un-secure my wireless network, this worked for some of the phones some of the time. I tried changing the network beacon timeout, this worked for some of the phones some of the times.  The phones would sometimes connect after rebooting the router but this was unacceptable.  After about a month I decided it was my cheap $15 dollar router, so I went out and purchased a [TrendNET TEW-631BRP 300Mbps Wireless N Broadband Router](http://trendnet.com/products/proddetail.asp?prod=110_TEW-631BRP&cat=66). I continued to have the same issues as above so I went back to Google and found a few sites that suggested to turn off MAC filtering, this was not applicable to me, or to try to assign static IP addresses to the phone so I tried this but no dice.  After about six weeks of troubleshooting and phone tag with the T-Mobile WiFi calling help des,k we came up with a solution.

## The solution

It turned out that the sporadic access was because I had the router set to automatically determine a channel.  The T-Mobile WiFi/UMA service will only work with channels 1,6, or 11, which I why it connected to my neighbor's router (channel 6). Here are all of the settings that you can apply to the router to make it function similarly to the T-Mobile branded LinkSys router.

|Setting|Value|
|--- |--- |
|Beacon Period|100|
|RTS Threshold|2347|
|Fragmentation Threshold|2346|
|DTIM Interval|1|
|Wireless Channel (try in this order)|11, 6, 1|
|For a secure network|WPA 2 is preferred over WEP|

I hope this helps solve some of your problems and that T-Mobile documents this somewhere.