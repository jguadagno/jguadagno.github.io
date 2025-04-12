---
title: Build, Package, Sign, and Publish a .NET Library to NuGet
isKeynote: false
isRetired: false
sourceUrl: https://gist.github.com/jguadagno/b99bec48d4ecde8b4cec72b119fbdcfa
powerPointUrl: https://1drv.ms/p/c/406ee4c95978c038/IQSWHcTH_AAYSLEFiwmVHT_kAdNrZoPmko4aw72VWXH-6o8
sessionizeUrl: build-package-sign-and-publish-a-.net-library-to-n/125125
youTubeId: D5aEDPt0ZTs
youTubeCaption: Build and Ship It! at Cloud Summit Live
level: 300
links:
 - title: Blog Post - Build, Sign, and Deploy NuGet Packages with Azure Pipeline
   url: https://jjg.me/buildit
 - title: Blog Post - Setup Azure Artifacts to Host Your NuGet Packages
   url: https://www.josephguadagno.net/2020/04/04/setup-azure-artifacts-to-host-nuget-packages
 - title: Blog Post - Extended Validation (EV) Code Signing Certificates with Azure Key Vault and digicert
   url: https://www.josephguadagno.net/2024/07/17/ev-code-signing-certificates-with-azure-key-vault-and-digicert
 - title: Blog Post - Setup Azure Artifacts to Host Your NuGet Packages
   url: https://www.josephguadagno.net/2020/04/04/setup-code-signing-certificates-in-azure-key-vault
 - title: VS Code Extension - Azure Pipeline
   url: https://jjg.me/bpsp_vscode_pipelines
---
In the modern development landscape, the use of NuGet packages has become a staple for code sharing and reuse in the .NET ecosystem. This session will provide a detailed exploration of the end-to-end process of building, packaging, and signing NuGet packages.

The session will cover the following key topics:

- **Building NuGet Packages**: Let's see how you can structure your project for NuGet packaging, including best practices for project organization, creating reusable libraries, and incorporating necessary metadata.
- **Packaging with NuGet**: Step-by-step instructions on creating NuGet packages using tools like the .NET CLI and Visual Studio. We will discuss the intricacies of defining package dependencies, versioning strategies, and including relevant documentation and assets.
- **Signing NuGet Packages**: Techniques for digitally signing NuGet packages to ensure authenticity and integrity. We will explore certificate management, obtaining and using code-signing certificates, and automating the signing process in CI/CD pipelines.
- **Publishing NuGet Packages**: Methods for publishing packages to public and private NuGet repositories, managing package visibility, and maintaining version history. We will also cover the setup and use of Azure Artifacts for managing package feeds.

Attendees will see how we can do all this with hands-on demonstrations, showcasing effective strategies for building, packaging, and signing NuGet packages.

This talk is tailored for .NET developers, DevOps engineers, and software architects who are looking to optimize their use of NuGet packages and improve the security and reliability of their code distribution. Participants will leave with actionable knowledge and best practices to elevate their development workflows.
