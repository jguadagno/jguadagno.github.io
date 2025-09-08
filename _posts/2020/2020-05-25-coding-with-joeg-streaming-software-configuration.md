---
title: "Coding with JoeG - Streaming Software Configuration"
date: 2020-05-25 04:05:00 -0700
last_modified_at: 2020-12-25 09:30:00 -0700
categories:
  - Articles
tags:
  - Twitch
  - Stream
  - CodingWithJoeG
  - Archive
---
***NOTE*** Since I have a new hardware configuration as outlined in '[Stream Hardware Configuration - December 2020]({% post_url 2020/2020-12-20-coding-with-joeg-streaming-hardware-configuration-december-2020-update %}), I've updated the software configuration in the post [Stream Software Configuration - December 2020]({% post_url 2020/2020-12-25-coding-with-joeg-streaming-software-configuration-december-2020-update %}). Check it out!
{: .notice--info}

In a previous post, I covered the [hardware]({% post_url 2020/2020-05-20-coding-with-joeg-streaming-hardware-configuration %}) I use for the stream.  In this post, I'll cover the software and settings to 'produce' the stream and artifacts. Please keep in mind, this is a guide based on some of my searchings, my playing around, and my hardware, your needs may be different. Another thing to keep in mind, is these are my settings for streaming live coding not live gaming.

## Streamlabs OBS Configuration

Streamlabs OBS is a free reliable streaming app with the fastest setup process on the market. We have developed an all-in-one application making streaming easy for everyone. Whether you're a novice or experienced streamer, Streamlabs OBS will provide you the best streaming experience, with tools built to engage, grow, and monetize your channel.

[Download](https://streamlabs.com/streamlabs-obs){:target="_blank}

### Settings

The first thing, from what I remember, is that Streamlabs OBS runs an 'Auto Optimize' function, which you can find on the general tab of settings.  From everything I have seen and read, you really never want to do this, except for maybe the first time.  Most of the time, you will want to 'tweak' the settings to fit your needs.  I've been on streams where the host says "What a minute. I have to tweak something".  It's gonna happen for a while.

First we are going to talk about the Streamlabs OBS settings.  You can get to these by clicking on gear (<i class="fas fa-cog"></i>) icon. Again, some settings might not be applicable depending on your hardware.

#### General Tab

Everything in this tab is according to your preference.  For me, everything is unchecked except for:

* Confirm stream title and game before going live
* In the 'Output' section, Automatically record when streaming
* In the 'Source Alignment Snapping', all 3 checked.

#### Stream Tab

Enable multistream, if you are.  For me, as the writing of this post, I'm only live streaming to [Twitch](https://twitch.tv/jguadagno){:target="_blank"}

#### Output Tab

For this tab, I have a few things tweaked based on my hardware and conditions.  Please select the `Advanced` option for 'Output mode'.

##### Output - Streaming

| --- | --- | --- |
| Setting | Value | Description |
| Audio Track | `1` | Only have one track.  This is helpful if you want to separate music from your voice |
| Encoder | `Hardware (QSV)` | This is set to software, by default, I changed it to hardware because I wanted to offload some of the video encoding to my video chip/card since my PC not fast enough |
| Enforce stream service encoder settings | `Unchecked` | |
| Rescale output | `Unchecked` | I broadcast at the resolution I want. |
| Target Usage | `quality` | |
| Profile  | `high` | |
| Keyframe Interval | `3` | |
| Async Depth | `4` | |
| Rate Control | `VBR` | |
| Bitrate | `2500` | The higher the better |
| B Frames | 3`` | |
| Content Adaptive Quantization | `Checked` | |

##### Output - Recording

| --- | --- | --- |
| Setting | Value | Description |
| Type | `Standard` | |
| Recording Path | *local storage* | If you can, this should be a SSD on a different partition/device than your operating system.  Avoid recording to a network drive |
| Generate File Name without Space | `Checked` | |
| Recording Format | `mp4` | |
| Audio Track | `1` | Only have one track.  This is helpful if you want to separate music from your voice |
| Encoder | `Hardware (QSV)` | This is set to software, by default, I changed it to hardware because I wanted to offload some of the video encoding to my video chip/card since my PC not fast enough |
| Rescale output | `Unchecked` | I broadcast at the resolution I want. |
| Custom Mixer Settings | *empty* | |
| Target Usage | `quality` | |
| Profile  | `high` | |
| Keyframe Interval | `3` | |
| Async Depth | `4` | |
| Rate Control | `VBR` | |
| Bitrate | `2500` | The higher the better |
| Max Bitrate | `3000` | |
| B Frames | 3`` | |
| Content Adaptive Quantization | `Checked` | |

##### Output - Audio

All of these settings are untouched

##### Output - Replay Buffer

| --- | --- | --- |
| Setting | Value | Description |
| Enabled Replay Buffer | `Checked` | This was on by default, I have not changed it |
| Maximum Replay Time (Seconds) | `20` | |

#### Audio

| --- | --- | --- |
| Setting | Value | Description |
| Sample Rate | `48khz` | Set this to the highest value your audio will support! The higher the hertz, the better the audio quality |
| Channels | `Stereo` | Especially if you have music playing |
| Desktop Audio Device 1 | `Default` | |
| Desktop Audio Device 2 | `Disabled` | |
| Mic/Auxiliary Device 1 | *Unselected* | |
| Mic/Auxiliary Device 2 | `Disabled` | |
| Mic/Auxiliary Device 3 | `Disabled` | |

You can select your microphone for either of the *mic/auxiliary* slots if you chose to. Doing so will make your microphone available to all scenes without adding it.

#### Video

| --- | --- | --- |
| Setting | Value | Description |
| Base (Canvas) Resolution | `3840x2160` | **4k**. I have one screen with 4K but I use that for monitoring stuff. I'll probably change this. |
| Output (Scaled) Resolution | `19020x1080` | **HD** |
| Downscale Filter | `Bicubic (Sharpened scaling, 16 samples)` | **Bilateral**, best for CPU. **Lanczos**, is better quality but CPU intensive. **Bicubic**, is the in-between. |
| FPS Type| `Common FPS Values` | This will defaults to Frames per Second based on the resolution |
| Common FPS Values | `60` | You can lower this to 30 if you are seeing an issue with your CPU. For streaming code, 30 is an acceptable value. |

#### Advanced

##### Advanced - General

| --- | --- | --- |
| Setting | Value | Description |
| Process Priority | `High` | I have this set to high because I am using a separate machine for streaming otherwise you should probably chose `normal` |

##### Advanced - Video

| --- | --- | --- |
| Setting | Value | Description |
| Color Format | `NV12` | |
| YUV Color Space | `601` | |
| YUV Color Range | `Partial` | |
| Force CPU as render device | `checked` | I wanted to offload the encoding of video to the video chip |

Some of your default settings for video might be different depending on your locale.

##### Advanced - Audio

I do not have a separate device to 'monitor' the stream audio

| --- | --- | --- |
| Setting | Value | Description |
| Audio Monitoring Device | `Default` | |
| Disable Windows audio ducking | `unchecked` | |

##### Advanced - Recording

| --- | --- | --- |
| Setting | Value | Description |
| Filename Formatting | `%CCYY-%MM-%DD %hh-%mm-%ss` | This is the default value. I kept it because I keep all of the recordings... so far. |
| Overwrite if file exists | `unchecked` | |

##### Advanced - Replay Buffer

These are the default values.  I imagine that if you are streaming your gaming, you might want to provide some replay functionality for a 'sweet kill'.  No one said ever, 'That was a great use of a lambda, let me replay that' :smile:

| --- | --- | --- |
| Setting | Value | Description |
| Replay Buffer Filename Prefix | `Replay` | |
| Replay Buffer Filename Suffix | *empty* | |

##### Advanced - Stream Delay

These are the default values.

| --- | --- | --- |
| Setting | Value | Description |
| Enable | `Unchecked` | |
| Duration | `20` | |
| Preserve cutoff point (increase delay) when reconnection | `checked` | |

##### Advanced - Automatically Reconnect

| --- | --- | --- |
| Setting | Value | Description |
| Enable | `checked` | |
| Retry Delay (seconds) | `10` | |
| Maximum Retries | `20` | |

##### Advanced - Network

If you have more than one Network Interface Card (nic), exampled wired and wireless. You can set Streamlabs OBS to only use one.  If you have a wired connection, you should use that.  Wireless can drop packets.

| --- | --- | --- |
| Setting | Value | Description |
| Bind to IP| `Default` | |
| Dynamically change bitrate when dropping frames while streaming| `unchecked` | If you notice your CPU or internet connection can not handle the load you may want this checked.  Doing so, will drop the frame rate , the number of 'snapshots' that the view sees, which could degrade quality.  If you are later posting the recording, I would keep this unchecked. |
| Enable new networking code| `unchecked` | [Explanation](https://www.reddit.com/r/Twitch/comments/8kwue6/obs_new_network_code_option/){:target="_blank} |
| Low latency mode | `Unchecked` | This should be checked if you are seeing a lot of dropped frames or low/show upload bandwidth from your ISP. |

##### Advanced - Sources

| --- | --- | --- |
| Setting | Value | Description |
| Enable Browser Source Hardware Acceleration| `checked` | |

##### Advanced - Media Files

| --- | --- | --- |
| Setting | Value | Description |
| Enable media file caching | `checked` | |

#### Other settings

All of the other settings, Hotkeys, Game Overlay, Scene Collections, Notifications, Appearance, and Face Masks, I have left the default values.

### Scenes

Scenes in OBS provide a different way to provide content to the viewer. Do you just want to show code? Do you just want to show you?  Scenes are a way to do that, and a preference.  From what I have seen, no two streams are the same.  I have eight scenes registered, three of them are just helper scenes that are reused as part of other scenes.

![Coding with JoeG Scenes](/assets/images/posts/streaming-software-scenes.jpg){: .align-center}

| Scene Name | Use |
| Overlay | Samples, provided by the theme, with some visual UI elements |
| Starting Scene | I use this when I go live, to let the viewers know "I'll be there in a minute" |
| Live Share - Elgato | This is my primary scene. It shares the primary capture from the Elgato card with the video from the webcam |
| Be Right Back Scene | I have not used this one yet.  It's for the times, I might need to run and get the door, or another drink, or something |
| Ending Scene | This signals the users that the stream is ending and provides some social media links for them to continue the conversation.  My mic is still on at this point.  This might be replaced with the *Just Chatting* scene which I am still building. |
| Just Chatting | Work in progress.  This will just be me with some background images for just the conversation. |
| Social Media | A shared scene with all of my social media links |
| Alerts | A shared scene with the OBS/Twitch alerts for new followers, subscribers, etc. |

All of my scenes and alerts use the [Pure](https://www.own3d.tv/product/pure-series-package/){:target="_blank"} theme by [Own3d](https://www.own3d.tv){:target="_blank"} for a consistent look.

### Filters

Filters are like advanced settings that let you tweak your devices (sources) even more.  I'm going to cover some of the Webcam and Microphone filters I use to provide a better experience.

One thing to keep in mind is that the order of the filters matter.  The output of one filter is feed in as the source of the next filter.  So if you have four filters, the input of filter 4 would be the output of the third, not the original source data. So, you might want to play around with the ordering a bit.

To get to the filters in OBS, right-click on a source and chose `Filters`.

#### Webcam Filters

##### Webcam Filter - Crop/Pad

This filter will remove or add pixels to your webcam.  The webcam I use has a wide range, so I crop out a lot of it just so my face and shoulders are available.

| --- | --- | --- |
| Setting | Value | Description |
| Left | `300` | |
| Top | `180` | |
| Right | `300` | |
| Bottom | `50` | |

##### Webcam Filter - Sharpen

Next up is the *Sharpen* filter. This is used to clean up the image a little bit.  For my camera, this is barely needed.

| --- | --- | --- |
| Setting | Value | Description |
| Sharpness | `0.08` | |

##### Webcam Filter - Chroma Key

Chromakeying is used to mask out the background of your camera's field of view.  Think of the weather forecaster on TV standing in front of the weather map.  That image is superimposed by a computer by replacing the Chromakeying color with the computer image.  I have a Green chromakey for my setup.

You will probably mess around with these settings a lot until you get it just right.  The lighting in your room/office/studio is a big contributor to this.

| --- | --- | --- |
| Setting | Value | Description |
| Key Color Type | `Green` | |
| Similarity | `440` | **Note**: I play around with this number a lot depending on the lighting in my room.  I usually don't go under `400` or higher than `450` |
| Smoothness | `80` | |
| Key Color Spill Reduction | `100` | |
| Opacity | `100` | Your personal preference. How much of yourself do you want on the screen? |
| Contrast | `0` | |
| Brightness | `0` | |
| Gamma | `0` | |

**Semi-pro** tip: Don't wear the same color shirt as your Chromakey :smile:

#### Microphone Filters

These filters were based off of a video I watched [Best Microphone Settings for Streamlabs OBS (2020)](https://www.youtube.com/watch?v=JvFw1NsgElQ){:target="_blank}. I recommend you watch this video to learn more about the audio filters.

##### Microphone Filter - Gain

| --- | --- | --- |
| Setting | Value | Description |
| Gain | `13.4` | The more gain, the louder the audio is |

##### Microphone Filter - Noise Suppression

| --- | --- | --- |
| Setting | Value | Description |
| Suppression Level | `-30` | |

##### Microphone Filter - Noise Gate

These settings will require a lot of tweaking to get a clear sound for your recording. I find myself tweaking the Close and Open Thresholds mostly.  The video above does a great job in explaining each of the settings.

| --- | --- | --- |
| Setting | Value | Description |
| Close Threshold | `-51` | |
| Open Threshold | `-26` | |
| Attack Time | `25` | |
| Hold Time | `200` | |
| Release Time | `150` | |

##### Microphone Filter - Compressor

| --- | --- | --- |
| Setting | Value | Description |
| Ratio | `10` | |
| Threshold | `-18` | |
| Attack | `6` | |
| Release | `60` | |
| Output Gain | `0` | |
| Sidechain/Ducking Source| `None` | |

## Wrap Up

That's it!  Again, your mileage may vary.  These are the 'optimal' settings for my hardware, software, and environment.

For details on my hardware, check out this [post]({% post_url 2020/2020-05-20-coding-with-joeg-streaming-hardware-configuration %})
