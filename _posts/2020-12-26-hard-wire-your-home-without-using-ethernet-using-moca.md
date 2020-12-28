---
title: "Hard Wire your Home without Ethernet using MoCA"
date: 2020-12-26 19:20:00 -0700
last_modified_at: 2020-12-28 10:55:00 -0700
header:
    og_image: /assets/images/posts/header/moca.png
categories:
  - Articles
tags:
  - MoCa
  - Networking
---
There are so many devices that are connected to our home networks nowadays. I have multiple Amazon Fire Sticks, computers, smart TVs, mobile phones, smart appliances, and so much more.  At any given time there are around forty devices connected to my home network. Since working from home, I have three to four devices that are constantly 'on the internet'.  The main house TV, my work computer, my son's computer or Xbox, and the daughter's Fire Stick/YouTube.  These devices are typically streaming in some way shape or form.  All of these devices, plus the other 30 or so that are on, were taxing my router. I currently don't have any CAT5/6/7 wiring in my house so I tried extending my wireless network a few different ways.  

## The Attempts

On the first attempt, I extended my wireless network with a network repeater.  I already had a [NETGEAR Nighthawk X4S WiFi Router (R7800)](https://amzn.to/3rw7NI0) so I added a [NETGEAR WiFi Mesh Range Extender (EX8000)](https://amzn.to/3aOctTt) to offload some of the wireless clients to. This combination had 'FastLane3' technology (Dedicated WiFi Link to the router to avoid halving of bandwidth of extended WiFi signals and innovative antenna design for ultimate coverage). This worked for a bit except when I was on a video call, the wife was streaming, and the son was gaming.  There were packet drops and the latency was spiking.  This did not work for us. So I looked into other solutions.  I wanted to get an ethernet connection in my son's office to reduce or eliminate the network latency and packet drops.

This led to attempt two to resolve the network latency and packet drops.  I updated my router to [ASUS ROG Rapture GT-AX11000 AX11000 Tri-Band 10 Gigabit WiFi 6 Gaming Router](https://amzn.to/2KuU8QR). This router has all kinds of benefits like 3 bands so I could dedicate a separate band to my son's office (his computer and Xbox). This router also can add nodes to the network to create a mesh network using its AIMesh.  I tried just using this device buy itself for a few days and the problems did not go away. I then proceeded to add the NETGEAR EX8000 repeater to the network to extend the network and after a few days, the network latency and packet drops started again.

## Multimedia over Coax Alliance

This led me to research other options. That is when I discovered MoCA. MoCA (stands for [Multimedia over Coax Alliance](https://en.wikipedia.org/wiki/Multimedia_over_Coax_Alliance)) is a technology that uses the existing coaxial cables already in most people’s homes. In essence, MoCA creates a wired Internet home network, but without the headache of drilling holes or running wires. Because MoCA technology is wired, it also delivers a reliable, low-lag, and ultra-high-speed connection. All of these are critical to a good streaming video or online gaming experience.

![Sample MoCA network](/assets/images/posts/moca-example.jpg){: .align-center}

After watching this [video](https://youtu.be/HYya7RrQuJU) and checking out a few diagrams like this one, [diagram 1](https://image.ibb.co/jSsMmT/layout.png), I decided to give this a shot since I have an existing unused Coax network in my home.  I purchased 2 [goCoax MoCA 2.5 Adapter for Ethernet Over Coax](https://amzn.to/34OHKlA) adapters to give it a shot.

## Setup

**Note** You need at least 2 MoCA adapters for this work. In addition, MoCA can support a maximum of 16 adapters on one network.
{: .notice--info}

My setup is based on having the goCoax adapters.  You will need at least 2 coax cables for this setup.  If you are using another MoCA adapter that is not the goCoax one, you may need to purchase [cable splitters](https://amzn.to/2WPmUxP).  The goCoax adapters come with the splitter built-in.

The setup was easy and will vary depending on your home network and internet access. For me, I have the local cable company provide Internet only and through coax. I have the cable modem in my office which is connected via coax.

Step 1: Disconnect the coax cable from the cable modem.

Step 2: Connect the cable that was previous connected to the cable modem to the MOCA port on the goCoax.

Step 3: Connect a new coax cable to the TV port of the goCoax adapter and connect the other end of the cable to your cable modem.

Step 4: Power the goCoax device.

Step 5: Connect an ethernet cable from the LAN port of the goCoax device.

At this point, the 'network traffic' is going to be sent over the coax network.  If you want a hard-wired network connection in another location of the house, as long as there is a coax port nearby, you can install another goCoax adapter and you should be good.

A visual of the setup.

![MoCA network setup](/assets/images/posts/moca-sample-setup.jpg){: .align-center}

## Wrap up

After a week of using this set up there have been no network drops, no latency issue, and virtually no pack loss.

In short, if your wireless network is struggling, you don't have ethernet wiring though out your home, and you have coax wiring, MoCA adapters are a low-cost way to help.

## Security Matters

If you install a MoCA setup, you should check to see if you have a 'Point of Entry' (POE) filter installed where your network connection comes into your home. They look something like this.

![MoCA POE](/assets/images/posts/moca-poe.jpg){: .align-center}

A POE prevents interference between subscriber homes that use MoCA technology. But more importantly, prevents you from leaking your network data back to your provider or anyone/anything else sharing the cable wiring. You can get on [Amazon](https://amzn.to/2JqWGij) for under $10.

**Note** If you click on an Amazon link and purchase a product, I may get a commission from Amazon. The purpose of the links is to avoid much searching and not to make money on the blog post.
{: .notice}
