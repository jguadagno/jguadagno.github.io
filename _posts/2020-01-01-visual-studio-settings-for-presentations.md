---
title: "Visual Studio Settings for Presentations"
date: 2020-01-11 07:30:00 -0700
categories:
  - Articles
tags:
  - Visual Studio
  - Settings
  - Presentation
  - Presentations
  - presenting
excerpt: "There was a twitter conversation around building an extension to make it easier for presenters/twitchers and others to quickly switch between settings in Visual Studio.  I decided to blog about how I do it."
---

There was a twitter conversation, started by [@julielerman](https://twitter.com/julielerman?s=20) around building an extension would quickly disable the **Quick Info** feature for C# to make it easier for presenters/twitchers and others when recording demos or showing code.  

<blockquote class="twitter-tweet"><p lang="en" dir="ltr">Quick Info in <a href="https://twitter.com/VisualStudio?ref_src=twsrc%5Etfw">@visualstudio</a> is *slaying* me. Methods with really really long descriptions cover up code you try to read add to. I&#39;ve found many complaints about it by googling but for C# , no way to disable it. Oddly, you can only disable it for C++. Help?</p>&mdash; Julie Lerman (@julielerman) <a href="https://twitter.com/julielerman/status/1206932076940972032?ref_src=twsrc%5Etfw">December 17, 2019</a></blockquote> <script async src="https://platform.twitter.com/widgets.js" charset="utf-8"></script>

It quickly changed to building an extension to quickly switch between settings in Visual Studio.  

<blockquote class="twitter-tweet"><p lang="en" dir="ltr">👍 In general I&#39;d love to see a &quot;Presentation mode&quot; that sets a set of settings like fontsize, disables quick info etc, and is quickly undone again once you&#39;re done presenting.</p>&mdash; .Morten (@dotMorten) <a href="https://twitter.com/dotMorten/status/1207151902074425345?ref_src=twsrc%5Etfw">December 18, 2019</a></blockquote> <script async src="https://platform.twitter.com/widgets.js" charset="utf-8"></script>

I chimed in a couple of times about how I accomplish this without a Visual Studio extension so I decided to blog about it.  Luckily, the master of Visual Studio extensions, [@mkristensen](https://twitter.com/mkristensen), and Program Manager for Visual Studio Extensibility, chimed in that he has a solution in mind to make it easier.  In either case, let's get to it.

## Tools Needed

The list is simple Visual Studio (any edition) and something that syncs folders/drives (optional).  I use [OneDrive](https://onedrive.live.com?invref=406ee4c95978c038&invscr=90) for synchronizing/backing up key files but you can use whatever is easier for you.

## The Process

### Step 1: Save your 'Default' settings

If you are unsure how to save your settings, check out [Environment Setting for Visual Studio](https://docs.microsoft.com/en-us/visualstudio/ide/environment-settings?view=vs-2019&WT.mc_id=AZ-MVP-4024623) in the MSDN docs. Feel free to call the settings whatever you wish, I use '*default*' because these are my day to day, or week to week settings lately :smile:, for Visual Studio.  

### Step 1a: Save your files to OneDrive

Again, you can save these to where ever you want, I chose OneDrive because a have a few different machines I use for presentations, both work and personal, but I like my settings to be the same. So save off your '*default*' settings to a OneDrive folder.  Mine are saved off to [Presentations\Settings](https://1drv.ms/u/s!AjjAeFnJ5G5AhKAMUjfhuvgrMKMDkA?e=gqYODh).

### Step 2a: Create your Presentation settings

There are probably 3,000,000 opinions on what makes a good set of settings for presentations.  There are a couple of things I change with mine, the Font, the Font Size, and the Current Line.

For the font, I was using [Source Code Pro](https://github.com/adobe-fonts/source-code-pro) for a while. Lately, I have been switching between Monaco and Menlo. Pick whatever font you like. There is a pretty good blog post that author shows their [Top 11 Programming Fonts](https://itnext.io/11-best-programming-fonts-724283a9ed57) for editing source code.

For the font size, I chose *16*, which is normally good for most screens.

I also change the **Current Statement** display item.  I modify the *item background* to *yellow* so that it is easier to follow along.

While most of us only change the fonts, colors, etc for the *Text Editor*, depending on what you are showing, you might want to change others like *Editor Tooltip*, *Immediate Window*, *Output Window*, *Data Tips*, and more. Take a look at the **Show setting for:** drop down for more options. You can see the settings I use for presentations in this [folder](https://1drv.ms/u/s!AjjAeFnJ5G5AhKAMUjfhuvgrMKMDkA?e=gqYODh) or directly '[presentations.vssettings](https://1drv.ms/u/s!AjjAeFnJ5G5Ag-Qb_N_MaeQ1671klw?e=dNbv1H)'

### Step 2b: Save your Presentation settings

Now save your new presentation settings to the same folder as before.  This is not required. It just makes it easier to find the settings later.

## Conclusion

Now you have two different settings that you can load based on your needs at the time.  To switch between them import the setting you want. Just be sure to chose **No, just import new settings, overwriting my current settings** when you do.

Hopefully Mads and team come up with a solution to make it a little bit easier to swap between settings for those of us that do it a little more often.
