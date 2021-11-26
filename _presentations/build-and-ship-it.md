---
title: Build and Ship It!
isKeynote: false
isRetired: false
sourceUrl: https://gist.github.com/jguadagno/b99bec48d4ecde8b4cec72b119fbdcfa
powerPointUrl: https://onedrive.live.com/embed?cid=406EE4C95978C038&resid=406EE4C95978C038%2180218&authkey=ADoNOI1w81OXGt4&em=2
sessionizeUrl: build_and_ship_it/28595
youTubeId: D5aEDPt0ZTs
youTubeCaption: Build and Ship It! at Cloud Summit Live
level: 300
---
If you are like me, you have many libraries, helpers, utilities that you have built over time that you use for multiple projects. You've thought about publishing them to NuGet so you can share them with other projects or your team but didn't because they contain secrets, intellectual property, or aren't well documented. With Azure DevOps, you can set up an Azure DevOps Artifact repository, private to you or your team, to securely store your packages and make them available to other projects and teams.

In this talk, we'll take a small .NET library, and it doesn't just work with .NET, and build an Azure DevOps Pipeline to publish it in our Artifact directory.  With this pipeline, we will build the library, execute unit tests, sign the code using a Code Signing certificate, and deploy it to our Artifact repository.

And at the end of the talk, you'll have a pipeline that you can add to the library, utility, and helper packages with some minor tweaks, when you are ready, to NuGet.
