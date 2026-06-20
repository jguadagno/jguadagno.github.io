---
title: "Update Aspire Version Recursively in All Projects and Solutions"
excerpt: "Update Aspire version recursively in all projects and solutions within a directory."
header:
    og_image: /assets/images/posts/header/aspire-update.png
date: 2026-06-20 12:35:00 -0700

categories:
- Articles
tags:
- Aspire
- dotnet
- Development
- Containers
- GitHub Copilot
- Copilot
---

I've been working on a workshop to demonstrate Aspire.  The workshop is designed to help developers get started with Aspire, a powerful tool for simplifying local development. As part of the workshop, I build out different labs to focus on different components of Aspire. Each lab is designed to build upon the previous one, and as a result, I have at least 7 different projects and solutions that all depend on Aspire. At least at the time of writing this article, Aspire updates frequently, and I want to ensure that all of my projects are using the latest version of Aspire.  However, updating the Aspire version in each project and solution manually can be time-consuming and error-prone. Fortunately, there are ways to update the Aspire version recursively across all projects and solutions within a directory.

With the help of GitHub Copilot [Chat](https://code.visualstudio.com/docs/setup/copilot){:target="_blank"} extension for Visual Studio Code, I was able to create a script that updates the Aspire version in all projects and solutions within a directory. The script uses the `aspire` [CLI](https://aspire.dev/get-started/install-cli/){:target="_blank"} to update the Aspire version in each project and solution file.

```bash
aspire update --yes --non-interactive
```

***NOTE***: If you want to see how I built the script using GitHub Copilot, you can check out the [post]({% post_url 2026/2026-06-20-how-i-build-run-aspire-update %}) where I walk through the process of creating the script step by step.
{: .notice--info}

Here's the script. You can place the script anywhere you like and run it to update the Aspire version in all projects and solutions within a directory. I might eventually turn this into a command in my PowerShell profile, but for now, you can run it as a standalone script.

```powershell
param(
    [Parameter(Position = 0)]
    [string]$ParentPath = (Get-Location).Path,

        [switch]$Recurse,

        [Alias('h')]
        [switch]$Help
)

$ErrorActionPreference = 'Stop'

if ($Help) {
        @"
Usage:
    run-aspire-update.ps1 [ParentPath] [-Recurse] [-Help]

Parameters:
    ParentPath
        Optional. The directory whose child directories will be processed.
        Default: current directory.

    Recurse
        Optional switch. When provided, process all nested child directories recursively.
        When omitted, only immediate child directories are processed.

    Help
        Optional switch. Shows this help text and exits.

Examples:
    pwsh -File .\run-aspire-update.ps1
    pwsh -File .\run-aspire-update.ps1 C:\repos
    pwsh -File .\run-aspire-update.ps1 -Recurse
    pwsh -File .\run-aspire-update.ps1 C:\repos -Recurse
"@ | Write-Host
        exit 0
}

try {
    $resolvedParentPath = (Resolve-Path -Path $ParentPath).Path
}
catch {
    Write-Error "Parent path '$ParentPath' does not exist or is not accessible."
    exit 1
}

$childDirectories = if ($Recurse) {
    Get-ChildItem -Path $resolvedParentPath -Directory -Recurse
}
else {
    Get-ChildItem -Path $resolvedParentPath -Directory
}

if (-not $childDirectories) {
    if ($Recurse) {
        Write-Host "No child directories found recursively in '$resolvedParentPath'."
    }
    else {
        Write-Host "No child directories found in '$resolvedParentPath'."
    }
    exit 0
}

$results = @()

foreach ($dir in $childDirectories) {
    Write-Host "`n=== Running Aspire update in '$($dir.FullName)' ==="

    Push-Location -Path $dir.FullName
    try {
        & aspire update --yes --non-interactive
        $exitCode = $LASTEXITCODE

        if ($exitCode -eq 0) {
            Write-Host "Success: $($dir.Name)"
            $results += [pscustomobject]@{ Directory = $dir.FullName; Status = 'Success'; ExitCode = $exitCode }
        }
        else {
            Write-Warning "Failed in '$($dir.Name)' with exit code $exitCode"
            $results += [pscustomobject]@{ Directory = $dir.FullName; Status = 'Failed'; ExitCode = $exitCode }
        }
    }
    catch {
        Write-Warning "Error in '$($dir.Name)': $($_.Exception.Message)"
        $results += [pscustomobject]@{ Directory = $dir.FullName; Status = 'Error'; ExitCode = $null }
    }
    finally {
        Pop-Location
    }
}

Write-Host "`n=== Summary ==="
$results | Format-Table -AutoSize

$failedCount = ($results | Where-Object { $_.Status -ne 'Success' }).Count
if ($failedCount -gt 0) {
    exit 1
}

exit 0
```

The script takes three parameters:

```powershell
run-aspire-update.ps1 [ParentPath] [-Recurse] [-Help]
```

Parameters:

| Name       | Required | Description                                                                                                                                        |
| ---------- | -------- | -------------------------------------------------------------------------------------------------------------------------------------------------- |
| ParentPath | No       | The directory whose child directories will be processed. Default is the current directory.                                                         |
| Recurse    | No       | When provided, the script will process all nested child directories recursively. When omitted, only immediate child directories will be processed. |
| Help       | No       | Shows help text and exits.                                                                                                                         |

The script will iterate through each child directory of the specified parent directory and run the following command in each directory: `aspire update --yes --non-interactive`. The results of each update attempt are collected and displayed in a summary table at the end. If any updates fail, the script will exit with a non-zero exit code.

Here is a sample output of the script when run in a directory with multiple projects:

```text
=== Running Aspire update in 'D:\Projects\aspire-workshop\section-02\lab-03-add-redis-cache' ===
Finding AppHosts...
CloudStore\CloudStore.AppHost\CloudStore.AppHost.csproj
Checking for updates...
Analyzing project...
✅ Project is up to date! (no updates necessary)
Success: lab-03-add-redis-cache

=== Running Aspire update in 'D:\Projects\aspire-workshop\section-02\lab-04-add-database' ===
Finding AppHosts...
CloudStore\CloudStore.AppHost\CloudStore.AppHost.csproj
Checking for updates...
Analyzing project...

📁 CloudStore.AppHost.csproj:
📦 Aspire.AppHost.Sdk 13.4.5 to 13.4.6
📦 Aspire.Hosting.Redis 13.4.5 to 13.4.6
📦 Aspire.Hosting.SqlServer 13.4.5 to 13.4.6

📁 CloudStore.ProductsApi.csproj:
📦 Aspire.Microsoft.EntityFrameworkCore.SqlServer 13.4.5 to 13.4.6
📦 Aspire.StackExchange.Redis.OutputCaching 13.4.5 to 13.4.6

No changes detected in NuGet.config

Applying updates...
Executing: Update package Aspire.AppHost.Sdk from 13.4.5 to 13.4.6
Executing: Update package Aspire.Hosting.Redis from 13.4.5 to 13.4.6
Executing: Update package Aspire.Hosting.SqlServer from 13.4.5 to 13.4.6
Executing: Update package Aspire.Microsoft.EntityFrameworkCore.SqlServer from 13.4.5 to 13.4.6
Executing: Update package Aspire.StackExchange.Redis.OutputCaching from 13.4.5 to 13.4.6
Restoring packages...

... (others were omitted for brevity) ...

=== Summary ===

Directory                                                          Status  ExitCode
---------                                                          ------  --------
D:\Projects\aspire-workshop\section-02\lab-01-first-aspire-app     Success        0
D:\Projects\aspire-workshop\section-02\lab-02-app-host-resources   Success        0
D:\Projects\aspire-workshop\section-02\lab-03-add-redis-cache      Success        0
D:\Projects\aspire-workshop\section-02\lab-04-add-database         Success        0
D:\Projects\aspire-workshop\section-02\lab-05-dashboard-deep-dive  Success        0
D:\Projects\aspire-workshop\section-02\lab-06-custom-health-checks Success        0
```

## Wrap Up

Updating the Aspire version recursively across all projects and solutions within a directory can save time and reduce the risk of errors. By using a script like the one I created, you can ensure that all of your projects are using the latest version of Aspire with just a few commands. If you're interested in seeing how I built the script using GitHub Copilot, be sure to check out the [post]({% post_url 2026/2026-06-20-how-i-build-run-aspire-update %}) where I walk through the process step by step.

## References

- [Aspire](https://aspire.dev/){:target="_blank"}
- [Aspire Documentation](https://aspire.dev/docs/){:target="_blank"}
- GitHub Copilot [website](https://github.com/features/copilot){:target="_blank"}
- GitHub Copilot [CLI](https://github.com/features/copilot/cli/){:target="_blank"}
- GitHub Copilot [Chat](https://code.visualstudio.com/docs/setup/copilot){:target="_blank"}
- [Simplify Your .NET Development with Aspire]({% post_url 2025/2025-07-08-simplify-your-dot-net-development-with-aspire %}){:target="_blank"}
- [How I Built and Ran the Aspire Update Script with GitHub Copilot]({% post_url 2026/2026-06-20-how-i-build-run-aspire-update %}){:target="_blank"}
