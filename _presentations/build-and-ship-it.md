---
title: Build and Ship It!
isKeynote: false
isRetired: false
sourceUrl:
powerPointUrl: 
sessionizeUrl: build_and_ship_it/28595
---
If you are like me, you have a lot of libraries, helpers, utilities that you have built over time that you use for multiple projects. You've thought about publishing them to NuGet so you can share them with other projects or your team but didn't because they contain secrets, intellectual property, or aren't well documented. This is where Azure DevOps comes in.  You can set up an Azure DevOps Artifact repository, private to you or your team, to securely store your packages and make them available to other projects and teams.

In this talk, we'll take a small .NET library, it doesn't just work with .NET, and build an Azure DevOps Pipeline to publish it in our Artifact directory.  With this pipeline, we will build the library, execute unit tests, sign the code using a Code Signing certificate, and finally deploy it to our own Artifact repository.

And at the end of the talk, you'll have a pipeline, that you can add to the library, utility, and helper packages... with some small tweaks, when you are ready, to NuGet.
