---
id: 171
title: Adding Visual Studio Online to an Windows Azure MSDN Benefit Subscription
date: 2013-11-15T13:21:37+00:00
author: Joseph Guadagno
layout: post
guid: http://www.josephguadagno.net/post.aspx?id=98e9a599-6476-432c-9005-024e520d604b
permalink: /2013/11/15/adding-visual-studio-online-to-an-windows-azure-msdn-benefit-subscription/
dsq_thread_id:
  - "3570155059"
categories:
  - Articles
  - Azure
tags:
  - Azure
  - Microsoft Azure
  - Visual Studio
  - Visual Studio Online
  - Windows Azure
---
In my previous <a href="http://www.josephguadagno.net/post/2013/11/15/Visual-Studio-Online-with-Windows-Azure-MSDN-benefit" target="_blank">post</a>,  I talk about why you can not add Visual Studio Online to an Existing Windows Azure MSDN benefit subscription.  In this post, I will show you how to add and existing Visual Studio Online (formally know as TFS Online) to your existing Windows Azure account.
<h1>Create Your “Pay-As-You-Go” Account</h1>
If you already, have a “Pay-As-You-Go” account you can jump to the “Link <a href="http://www.josephguadagno.net/post/2013/11/15/Adding-Visual-Studio-Online-to-an-Windows-Azure-MSDN-Benefit-Subscription#link" target="_blank">Your Existing Visual Studio Online Account</a>” section

First you have to sign in to your Windows Azure <a href="https://account.windowsazure.com/Subscriptions" target="_blank">account</a>. You should see something like this.

<a href="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/Add_subscription.png"><img style="background-image: none; margin: 0px 10px 0px 0px; padding-left: 0px; padding-right: 0px; display: inline; padding-top: 0px; border-width: 0px;" title="Add subscription" src="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/Add_subscription_thumb.png" alt="Add subscription" width="655" height="294" border="0" /></a>

Click on the Add Subscription button. This will take you to the Add Subscription page. You should see a few choices, scroll down until you see the “Pay-As-You-Go” selection highlighted below.

<a href="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/Select_an_Offer_1.png"><img style="background-image: none; margin: 0px 10px 0px 0px; padding-left: 0px; padding-right: 0px; display: inline; padding-top: 0px; border: 0px;" title="Select an Offer" src="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/Select_an_Offer_thumb_1.png" alt="Select an Offer" width="628" height="623" border="0" /></a>

You should then be brought to the purchase section,

<a href="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/purchase_1.png"><img style="background-image: none; margin: 0px 10px 0px 0px; padding-left: 0px; padding-right: 0px; display: inline; padding-top: 0px; border: 0px;" title="purchase" src="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/purchase_thumb_1.png" alt="purchase" width="658" height="348" border="0" /></a>

<em>Note, you might have to validate your mobile number and/or put in a credit card number</em>.  Click purchase, and after a minute or so, your “Pay-As-You-Go” account is established.  You can view it by clicking on the Portal button or visiting the Windows Azure <a href="https://portal.windowsazure.com/" target="_blank">Portal</a>.
<h1><a href="#" name="link"></a>Linking Your Existing Visual Studio Online Account</h1>
Now that you have the “Pay-As-You-Go” account added to Windows Azure, we can click on the Visual Studio Online tab in the Windows Azure portal <a href="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/Visual_Studio_Online.png"><img style="background-image: none; margin: 0px 10px 0px 0px; padding-left: 0px; padding-right: 0px; display: inline; padding-top: 0px; border-width: 0px;" title="Visual Studio Online" src="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/Visual_Studio_Online_thumb.png" alt="Visual Studio Online" width="203" height="60" border="0" /></a>

&nbsp;

or click the new button.

<a href="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/Link_to_Existing_Account.png"><img style="background-image: none; margin: 0px 10px 0px 0px; padding-left: 0px; padding-right: 0px; display: inline; padding-top: 0px; border-width: 0px;" title="Link to Existing Account" src="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/Link_to_Existing_Account_thumb.png" alt="Link to Existing Account" width="656" height="303" border="0" /></a>

If you click, the new button you will have to navigate to “App Services”, then “Visual Studio Online”, then “Link to Existing”. For me, since my Windows Azure credentials were the same as my Visual Studio Online credentials, it automatically populated the account name.  Click the button and the Link to Existing Account message will appear.

<a href="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/Link_Being_Created.png"><img style="background-image: none; margin: 0px 10px 0px 0px; padding-left: 0px; padding-right: 0px; display: inline; padding-top: 0px; border-width: 0px;" title="Link Being Created" src="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/Link_Being_Created_thumb.png" alt="Link Being Created" width="658" height="37" border="0" /></a>

&nbsp;

Once the account has been linked you will see the account ready screen.

<a href="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/Account_Ready.png"><img style="background-image: none; margin: 0px 10px 0px 0px; padding-left: 0px; padding-right: 0px; display: inline; padding-top: 0px; border-width: 0px;" title="Account Ready" src="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/Account_Ready_thumb.png" alt="Account Ready" width="658" height="388" border="0" /></a>

&nbsp;

Now, from the Windows Azure dashboard, you will see your Visual Studio Online account.

<a href="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/With_Visual_Studio_Online.png"><img style="background-image: none; margin: 0px 10px 0px 0px; padding-left: 0px; padding-right: 0px; display: inline; padding-top: 0px; border-width: 0px;" title="With Visual Studio Online" src="http://1222-7915.el-alt.com/wp-content/uploads/2015/03/With_Visual_Studio_Online_thumb.png" alt="With Visual Studio Online" width="674" height="127" border="0" /></a>