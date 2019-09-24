---
title: "Migrate my .Net Framework Configuration to use Microsoft.Configuration.ConfigurationBuilders Classes"
date: 2019-09-17 13:30:00 -0700
categories:
  - Articles
tags:
  - .NET Framework
  - Migrate
  - Configuration
---
Migrate my .Net Framework Configuration to use Microsoft.Configuration.ConfigurationBuilders Classes

## Local/Dev setup

First - Add Microsoft.Configuration.ConfigurationBuilders classes
Require .NET Framework 4.7.1

Microsoft.Configuration.ConfigurationBuilders.Base
Microsoft.Configuration.ConfigurationBuilders.Json
Microsoft.Configuration.ConfigurationBuilders.UserSecrets
Microsoft.Configuration.ConfigurationBuilders.Azure

Modify App.Config/Web.Config

- configSections
- configBuilders
- appSettings

BL.Tests.App.Config

Create the new secrets
c:\Users\...\ secrets.xml, secrets.json

Modify calls to Configuration.AppSettings...

## Azure Key Vault

