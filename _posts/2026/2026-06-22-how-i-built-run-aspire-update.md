---
title: "How I built Run Aspire Update Script with GitHub Copilot"
excerpt: "A walk though of how I built the script to update Aspire version recursively in all projects and solutions using GitHub Copilot Chat extension for Visual Studio Code."
header:
    og_image: /assets/images/posts/header/run-aspire-update.png
date: 2026-06-22 13:51:00 -0700

categories:
- Articles
tags:
- Aspire
- .NET
- dotnet
- Development
- ASP.NET
- Containers
- GitHub Copilot
- Copilot
---

This is a follow-up post to my previous article, [Update Aspire Version Recursively in All Projects and Solutions]({% post_url 2026/2026-06-22-update-aspire-version-recursively %}){:target="_blank"} where I shared a script that updates the Aspire version in all projects and solutions within a directory. In this post, I want to walk you through the process of how I built the script using GitHub Copilot [Chat](https://code.visualstudio.com/docs/setup/copilot){:target="_blank"} extension for Visual Studio Code.

## Initial Prompt

First I started by asking GitHub Copilot Chat to help me create a script that updates the Aspire version in all projects and solutions within a directory. I provided some context about what I wanted to achieve and asked for a PowerShell script that would accomplish this task.

The initial prompt:

```text
can you create a powershell script that will run the following command `aspire update --yes --non-interactive`
 in each of the child directories of the current directory or one passed as an arguement
```

...and yes I spelled "argument" wrong in the prompt. I didn't notice the typo until after I sent the message. However, GitHub Copilot Chat was still able to understand what I meant and provided me with a script that accomplishes the task.

After some "thinking"...

> I’ll create a PowerShell script that accepts an optional parent directory argument (defaulting to the current directory), iterates each immediate child directory, and runs aspire update --yes --non-interactive in each one with clear logging. I’m going to create the script file now.
>
> I need the current working path so I can place the script in the right location and reference paths safely. I’ll check it now, then write the script there.

GitHub Copilot then created a script file named `run-aspire-update.ps1`:

```powershell
param(
    [Parameter(Position = 0)]
    [string]$ParentPath = (Get-Location).Path
)

$ErrorActionPreference = 'Stop'

try {
    $resolvedParentPath = (Resolve-Path -Path $ParentPath).Path
}
catch {
    Write-Error "Parent path '$ParentPath' does not exist or is not accessible."
    exit 1
}

$childDirectories = Get-ChildItem -Path $resolvedParentPath -Directory

if (-not $childDirectories) {
    Write-Host "No child directories found in '$resolvedParentPath'."
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

After the initial script was generated, GitHub Copilot provided me with a summary of what the script does and how it works.

> How it works:
>
> - Takes an optional first argument for the parent directory.
> - Defaults to the current directory if no argument is provided.
> - Iterates immediate child directories only.
> - Runs aspire update --yes --non-interactive in each child.
> - Prints a summary table and exits with code 1 if any child fails.
>
> Usage examples:
>
> - Run against current directory: `pwsh -File run-aspire-update.ps1`
> - Run against a specific directory: `pwsh -File run-aspire-update.ps1 C:\path\to\parent`

This was a great starting point.

### The "Yes please" Prompt

GitHub Copilot also provided me with some suggestions on how to improve the script, such as adding a recursive option to run the command in all subdirectories.

> If you want, I can also add an option to recurse into nested subdirectories.

I replied with a simple "Yes please" and GitHub Copilot updated the script to include a `-Recurse` switch parameter that allows the script to run the command in all nested child directories.

GitHub Copilot started to "think" again...

>I’ll update the script to support a recurse mode, so it can run in all nested child directories when requested while keeping the current one-level behavior as default. I’m applying that change now.

It added the `-Recurse` switch parameter to the script and updated the logic to use `Get-ChildItem -Recurse` when the switch is provided.

```powershell
param(
    [Parameter(Position = 0)]
    [string]$ParentPath = (Get-Location).Path,

        [switch]$Recurse
)

$ErrorActionPreference = 'Stop'

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

Along with the updated script, GitHub Copilot also provided me with an updated summary of the new functionality.

> Updated. The script now supports recursive traversal.
>
> What changed:
>
> - Added a Recurse switch parameter.
> - Default behavior is unchanged: immediate child directories only.
> - With Recurse enabled, it processes all nested child directories.
>
> How to use:
>
> - Immediate children only: `pwsh -File run-aspire-update.ps1`
> - Immediate children of a specific path: `pwsh -File run-aspire-update.ps1 C:\path\to\parent`
> - All nested directories recursively: `pwsh -File run-aspire-update.ps1 -Recurse`
> - Recursive for a specific path: `pwsh -File run-aspire-update.ps1 C:\path\to\parent -Recurse`
>
> If you want, I can add an Exclude option next (for example to skip .git, bin, obj, node_modules).

I didn't opt to add the `Exclude` option at this time, but it is something that I may consider adding in the future if there is a need for it.

## The Help Prompt

Then, since the script had multiple parameters, and I tend to forget the exact syntax for running scripts with parameters, I asked GitHub Copilot to add a help message that would be displayed when the `--help` switch is provided.

```text
Can you add a --help option that explains the parameters and what they do?
```

After some more "thinking"...

> I’ll add a dedicated Help switch and a usage block so the script can print parameter documentation and exit cleanly when help is requested; after editing, I’ll quickly verify whether --help works as expected in PowerShell for this script.

The script was updated to include a `--help`, and `-h`, switch parameter that, when provided, displays a help message explaining the parameters and their usage.

That created the final version, so far, of the script that I shared in my previous article, [Update Aspire Version Recursively in All Projects and Solutions]({% post_url 2026/2026-06-22-update-aspire-version-recursively %}){:target="_blank"}.

## Wrap Up

Overall, I found GitHub Copilot Chat to be a very helpful tool in quickly generating a script that accomplishes the task I had in mind. It was able to understand my requirements and provide me with a working script in a matter of seconds. The ability to have a conversation with the AI and ask for improvements or additional features made the development process much smoother and more efficient.

Now, if I have the time, I will probably submit a pull request to the [Aspire repository](https://github.com/microsoft/aspire){:target="_blank"} to update the Aspire [CLI](https://aspire.dev/get-started/install-cli/){:target="_blank"} with this functionality, sharing it with the community, as I believe it could be useful for others who are using Aspire and want an easy way to update their projects.

## References

- [Aspire](https://aspire.dev/){:target="_blank"}
- [Aspire Documentation](https://aspire.dev/docs/){:target="_blank"}
- GitHub Copilot [website](https://github.com/features/copilot){:target="_blank"}
- GitHub Copilot [CLI](https://github.com/features/copilot/cli/){:target="_blank"}
- GitHub Copilot [Chat](https://code.visualstudio.com/docs/setup/copilot){:target="_blank"}
- [Aspire repository](https://github.com/microsoft/aspire){:target="_blank"}
- [Update Aspire Version Recursively in All Projects and Solutions]({% post_url 2026/2026-06-22-update-aspire-version-recursively %}){:target="_blank"}
