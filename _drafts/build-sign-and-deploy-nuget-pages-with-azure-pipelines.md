---
title: "Build, Sign, and Deploy NuGet Packages with Azure Pipeline"
date: 2020-04-04 11:00:00 -0700
excerpt: "Let's take a look how you can build an Azure pipeline that will build your NuGet package, sign it, then deploy it to Azure Artifacts"
categories:
  - Articles
tags:
  - .NET Core
  - NuGet
  - Azure
  - Pipeline
  - Key Vault
  - Azure Artifacts
---

## What are we doing

## Intro to Yaml

## Setup Pool, .NET version, and NuGet version

## Build project

## Test the project

## Azure Key Vault

There is a little bit of a setup that is required to get certificate signing with Azure Key Vault working.  I broke it down into two blog posts.

TODO: Update these URL with the published URLS

* Step 1: [Setup Code Signing Certificates in Azure Key Vault](https://www.josephguadagno.net))
* Step 2: [Setup an Azure Application with Permissions to Enable Certificate Signing](https://www.josephguadagno.net)

### Pipeline Tasks for Key Vault

#### Download Certificate

#### Save Certificate

## Pack the assembly

## Sign the Package

## Azure Artifact

### Setup

## Publish the Package

