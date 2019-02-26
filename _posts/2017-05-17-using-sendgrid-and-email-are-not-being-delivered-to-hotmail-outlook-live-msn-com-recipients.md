---
id: 10612
title: Using SendGrid and emails are not being delivered to Hotmail/Outlook/Live/MSN.com recipients?
date: 2017-05-17T17:03:56+00:00
author: Joseph Guadagno
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
> _Me too, or at least I was_... While the problem I was having might not be related to SendGrid exclusively, I am going to talk about the solution.

## The Problem

Before I go into the solution, let's talk about the problem first. Many of you know that I run the Desert Code Camp in Chandler, AZ. Originally, the site ran on the Microsoft stack; it used ASP.NET (Web Forms) and SQL Server. There is an API for mobile apps and future development, but that's another story. The site has 12,000 registered users. A few thousand are SPAM/Bots, a few thousand are "inactive" accounts (opted out or moved), and the other 6000 or so are active users that have an interest in Desert Code Camp or have attended at least one.

And here lies the first problem.

When an announcement email goes out to our attendees or users of the site, we need to send out about 6000 emails. I used to do this by sending the email from a web page through code using `System.Net.SMTP` via `localhost.` At first, it wasn't an issue. After a while, as Desert Code Camp grew, this became more and more of a problem. Typically the page would time out, or IIS would die or something. So I needed to find a solution. Sometime last year, probably around this time, I offloaded the processing of emails to [Azure Queue Storage](https://azure.microsoft.com/en-us/services/storage/queues/) and used [Azure WebJobs](https://docs.microsoft.com/en-us/azure/app-service-web/websites-webjobs-resources) to handle the "logic." But wait, Azure does not support sending stuff via `localhost.` And that is true! This is where [SendGrid](https://www.sendgrid.com/) comes into play. Azure provides, as of the creation of this post, a free 25,000 email per month subscription to SendGrid. For more on that, check out this [post](https://docs.microsoft.com/en-us/azure/app-service-web/sendgrid-dotnet-how-to-send-email).

Now that I implemented the new Azure/SendGrid combination everything was great.

Fast forward a year, to this past weekend; I announced that the next [Desert Code Camp](https://oct2017.desertcodecamp.com) was happening on Twitter and some people started submitting sessions. This is great! But I noticed that I was wasn't getting my emails about the submissions. At first, I thought, "Oh Joe, you forgot something when you 'created' the new event." It happens every time :). However, this was not the case this time. Microsoft decided to [embrace](https://sendgrid.com/docs/Classroom/Deliver/Sender_Authentication/microsoft_dmarc_changes.html) something called [DMARC](http://sendgrid.com/blog/dmarc-domain-based-message-authentication-reporting-conformance/), Domain-based Message Authentication, Reporting & Conformance. In a nutshell, it checks to see if you are sending emails from the domain you claim you are sending them from, which for me was bad. Not because I was trying to be deceitful, but because I was sending emails saying they were from '_@hotmail.com_' and sending them via '_SendGrid_' because I wanted people to reply to my Hotmail address. Well, when Microsoft implemented the DMARC...

**What this means:** As of June 2016, you can no longer send with the From address being anything from a Microsoft address when sending to a domain that checks DMARC before accepting mail.

... it saw my email as not being '_legitimate_' and did not deliver it to my inbox and probably others. 

## The Solution

The answer is '[Whitelist](http://sendgrid.com/blog/dmarc-domain-based-message-authentication-reporting-conformance/)' your domains while using SendGrid. There are more detailed instructions on how to whitelist a domain using SendGrid [here](https://sendgrid.com/docs/Classroom/Basics/Whitelabel/index.html).

### What is Whitelabeling?

Whitelabeling allows you to send through your own custom domain instead of SendGrid's default settings. This will mask the header information of your emails with your data--not theirs--and will improve your email deliverability.

{% include figure image_path="/assets/images/posts/whitelabeling.png" alt="Non-Whitelabeled Example vs. Whitelabeled" caption="Non-Whitelabeled Example vs. Whitelabeled" %}

Example Luckily, SendGrid makes it easy to whitelist your domain(s). Here is how you do it. **Please note:** _You will need access to your domain records, you will be making changes to your TXT or CNAME entries to prove you have rights to the domain_.

* First, log-in to your SendGrid Account
* Click `Settings` (on the left)
* Click `Whitelabels`
* Click [+ Add Domain](#){: .btn .btn--primary .btn--small} button.
* SendGrid will walk you though everything else you need.

### But what about the replies to @Hotmail.com

I'm glad you are still with me :). This part is the easy part. Essentially, I added '_noreply@desertcodecamp.com_' as the ToAddress and added '_jguadagno@hotmail.com_' as the ReplyTo. As shown here.

```cs
string apiKey = ConfigurationManager.AppSettings["SendGrid.ApiKey"];
var sendGrid = new SendGridClient(apiKey);

var msg = new SendGridMessage();
msg.SetFrom(new EmailAddress("noreply@yourdomain.com", "No Reply"));
msg.AddTo(new EmailAddress("reciever@theirdomain.com", "Joe Dirt"));
msg.SetSubject("Hello World");
msg.AddContent(MimeType.Text, "Hello World");
msg.AddContent(MimeType.Html, <html><body>My Body</body></html>);

if (!string.IsNullOrEmpty(emailMessage.ReplyToMailAddress))
{
  msg.SetReplyTo(new EmailAddress("jguadagno@hotmail.com", "Joseph Guadagno"));
}

var response = sendGrid.SendEmailAsync(msg).Result;
```

I hope this saves you some time to troubleshoot mail delivery to @hotmail.com, @outlook.com, @live.com, @msn.com, @yahoo.com, and @gmail.com.