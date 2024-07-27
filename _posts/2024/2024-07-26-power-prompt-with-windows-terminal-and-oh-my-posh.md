---
title: "Power Prompt with Windows Terminal and Oh My Prompt"
header:
    og_image: /assets/images/posts/header/power-prompt.png
date: 2024-07-26 21:55:00 -0700
categories:
- Articles
tags:
- Terminal
- PowerShell
- git
- oh-my-posh
- Productivity
---
In this post, I'll show you how you can "power-up" your PowerShell shell prompt terminal window with Windows Terminal, PowerShell Core, and Oh-My-Posh to improve your day to day command line activity.

## Getting Started

### Install Windows Terminal

If you don't have Windows Terminal installed, you can download it from the [Microsoft Store](https://apps.microsoft.com/detail/9n0dx20hk701?rtc=1&hl=en-us&gl=US){:target="_blank"} (recommended by Microsoft), or you can download it from the [Windows Terminal GitHub repository](https://github.com/microsoft/terminal/releases){:target="_blank"}.

Another option is to install it using the [Windows Package Manager](https://github.com/microsoft/winget-cli){:target="_blank"}.

```powershell
winget install --id Microsoft.WindowsTerminal --exact
```

### Install PowerShell

You can install PowerShell using the Windows Package Manager.

```powershell
winget install --id Microsoft.PowerShell --source winget
```

If you want, you can install the latest preview version of PowerShell with the following command.

```powershell
winget install --id Microsoft.PowerShell.Preview --source winget
```

### Install Oh-My-Posh

[Oh-My-Posh](https://ohmyposh.dev/){:target="_blank"} is a prompt theming engine for PowerShell. You can install it using the Windows Package Manager with the following command.

```powershell
winget install --id JanDeDobbeleer.OhMyPosh --exact
```

### Installing with UniGetUI

If you are using [UniGetUI](https://www.marticliment.com/unigetui/){:target="_blank"}, which I highly recommend, you can install all three packages as a bundle.  

* Save this *json* locally on your machine.
* In UniGetUI, click on *Package Bundles*
* Click on *Open existing bundle*, select the recently saved *json* file.
* Click on *Install selection*

```json
{
  "export_version": 2,
  "packages": [
    {
      "Id": "JanDeDobbeleer.OhMyPosh",
      "Name": "Oh My Posh",
      "Version": "23.0.2",
      "Source": "winget",
      "ManagerName": "Winget",
      "InstallationOptions": {
        "SkipHashCheck": false,
        "InteractiveInstallation": false,
        "RunAsAdministrator": false,
        "Architecture": "",
        "InstallationScope": "",
        "CustomParameters": [],
        "PreRelease": false,
        "CustomInstallLocation": "",
        "Version": ""
      },
      "Updates": {
        "UpdatesIgnored": false,
        "IgnoredVersion": ""
      }
    },
    {
      "Id": "Microsoft.PowerShell",
      "Name": "PowerShell",
      "Version": "7.4.4.0",
      "Source": "winget",
      "ManagerName": "Winget",
      "InstallationOptions": {
        "SkipHashCheck": false,
        "InteractiveInstallation": false,
        "RunAsAdministrator": false,
        "Architecture": "",
        "InstallationScope": "",
        "CustomParameters": [],
        "PreRelease": false,
        "CustomInstallLocation": "",
        "Version": ""
      },
      "Updates": {
        "UpdatesIgnored": false,
        "IgnoredVersion": ""
      }
    },
    {
      "Id": "Microsoft.WindowsTerminal",
      "Name": "Windows Terminal",
      "Version": "1.20.11781.0",
      "Source": "winget",
      "ManagerName": "Winget",
      "InstallationOptions": {
        "SkipHashCheck": false,
        "InteractiveInstallation": false,
        "RunAsAdministrator": false,
        "Architecture": "",
        "InstallationScope": "",
        "CustomParameters": [],
        "PreRelease": false,
        "CustomInstallLocation": "",
        "Version": ""
      },
      "Updates": {
        "UpdatesIgnored": false,
        "IgnoredVersion": "1.19.10573.0"
      }
    }
  ],
  "incompatible_packages_info": "Incompatible packages cannot be installed from WingetUI, but they have been listed here for logging purposes.",
  "incompatible_packages": []
}
```

## Getting Started with Oh-My-Posh

Oh-My-Posh allows you to customize your prompts with different [themes](https://ohmyposh.dev/docs/themes){:target="_blank"} and [segments](https://ohmyposh.dev/docs/configuration/segment){:target="_blank"}. A sample prompt looks like this.

![Oh-My-Posh - Sample Prompt](/assets/images/posts/2024/power-prompt-with-windows-terminal-and-oh-my-posh/oh-my-posh-hero.png){: .align-center}

If you just installed, Windows Terminal, Powershell, or Oh-My-Posh, I recommend you restart your terminal so that oh-my-posh is included in the path.

### Font Installation

After restarting your terminal, you can install a [font](https://ohmyposh.dev/docs/installation/fonts){:target="_blank"}. You'll typically want to install a Nerd Font, which includes the icons used in the prompt. Run the following command to install the `Meslo LGM NF` font.

```powershell
oh-my-posh font install meslo
```

#### Register the font with Windows Terminal

You will need to tell Windows Terminal to use this font. To do this, open up the *Settings* in Windows Terminal (`CTRL+,`)

* Click on the *Defaults* profile.
* Under the *Additional settings* section, click *Appearance*
* Under the *Fonts* section, select the `MesloLGM Nerd Font` font for the *Font face* property, or whatever font you installed.

You can also do this by editing the Windows Terminal `settings.json` file. Add the following to the `defaults` profile.

```json
{
    "profiles":
    {
        "defaults":
        {
            "font":
            {
                "face": "MesloLGM Nerd Font"
            }
        }
    }
}
```

### Initializing Oh-My-Posh

In Windows Terminal, with the PowerShell prompt loaded, you will need to edit your `$PROFILE` file. You can do this by running the following command.

```powershell
notepad $PROFILE
```

Add the following lines to the `$PROFILE` file.

```powershell
oh-my-posh init pwsh | Invoke-Expression
```

This will initialize Oh-My-Posh with the default theme.

Save the file and either restart the terminal or run the following command to reload the profile.

```powershell
. $PROFILE
```

## Customizing the Prompt

There are many ways to customize the prompt. You can change the theme, add segments, or create your own theme. You can find more information on the customizing Oh-My-Posh in their [documentation](https://ohmyposh.dev/docs/){:target="_blank"}.  I'll show you the customizations I made to my prompt.  Once done, your prompt will look like this.

![Oh-My-Posh - Joe's Terminal](/assets/images/posts/2024/power-prompt-with-windows-terminal-and-oh-my-posh/full-terminal.png){: .align-center}

First step is to choose a theme. Themes in Oh-My-Posh are more then just colors, they include segments, which are the different parts of the prompt. I chose the *[PowerLevel10k Modern](https://ohmyposh.dev/docs/themes#powerlevel10k_modern){:target="_blank"}* theme.  You can set the theme by editing your `oh-my-posh` initialization command in your `$PROFILE` file.

```powershell
oh-my-posh init pwsh --config "$env:POSH_THEMES_PATH\powerlevel10k_modern.omp.json" | Invoke-Expression
```

This will load the theme from the `powerlevel10k_modern.omp.json` file.  You can find the theme files in the `%POSH_THEMES_PATH%` folder. This is likely in the following folder: `C:\Users\<username>\AppData\Local\Programs\oh-my-posh\themes` directory. There are many [themes](https://ohmyposh.dev/docs/themes){:target="_blank"} to choose from, and you can create your own.

![Oh-My-Posh - Joe's Prompt (PowerLevel10K Modern Theme)](/assets/images/posts/2024/power-prompt-with-windows-terminal-and-oh-my-posh/joe-powerlevel10k-modern-prompt.png){: .align-center}

***Note***: You will not see the `main` portion of the prompt unless you install the `posh-git` module.  I'll show you how to do that later.
{: .notice}

If you want to customize the theme, you can create your own theme file.  You can find more information in the [Oh-My-Posh configuration documentation](https://ohmyposh.dev/docs/configuration/general){:target="_blank"}.

### Add Additional PowerShell Modules

You can add additional PowerShell modules to your prompt to further customize it.  I added the `posh-git`, `PSReadLine`, and `Terminal-Icons` modules to my prompt.

#### Posh-Git Module

[Posh-git](https://github.com/dahlbyk/posh-git){:target="_blank"} provides prompt with Git status summary information and tab completion for Git commands, parameters, remotes and branch names.

You can install it as a PowerShell module. In your terminal, run the following command.

```powershell
Install-Module posh-git -Scope CurrentUser
```

After installed, open your `$PROFILE` file and add the following line after your `oh-my-posh` initialization.

```powershell
Import-Module posh-git
```

#### PSReadLine Module

[PSReadLine](https://github.com/PowerShell/PSReadLine){:target="_blank"} enhances the PowerShell command line editing environment. It provides syntax coloring, multi-line editing, and more.

You can install it as a PowerShell module. In your terminal, run the following command.

```powershell
Install-Module PSReadLine -Scope CurrentUser
```

After installed, open your `$PROFILE` file and add the following line after your `oh-my-posh` initialization.

```powershell
Import-Module PSReadLine
```

I also added the following lines to my `$PROFILE` file to customize the PSReadLine module after all of the imports.

```powershell
Set-PSReadLineOption -PredictionSource History
Set-PSReadLineOption -PredictionViewStyle ListView
Set-PSReadLineOption -EditMode Windows
```

| Option | Description |
|--------|-------------|
| PredictionSource | The source of the prediction data.  In this case, it is the history. |
| PredictionViewStyle | The style of the prediction view.  In this case, it is a list view. |
| EditMode | The edit mode.  In this case, it is Windows. |

With these options, you can use the up and down arrow keys to cycle through your command history. As shown in the image below.

![PSReadLine - Command History](/assets/images/posts/2024/power-prompt-with-windows-terminal-and-oh-my-posh/psreadline-options.png){: .align-center}

Check out the [Set-PSReadLineOption](https://learn.microsoft.com/en-us/powershell/module/psreadline/set-psreadlineoption?view=powershell-7.4&WT.mc_id=AZ-MVP-4024623#parameters){:target="_blank"} documentation for more options.

#### Terminal-Icons Module

[Terminal Icons](https://github.com/devblackops/Terminal-Icons){:target="_blank"} that adds file and folder icons when displaying items in the terminal.

You can install it as a PowerShell module. In your terminal, run the following command.

```powershell
Install-Module Terminal-Icons -Scope CurrentUser
```

After installed, open your `$PROFILE` file and add the following line after your `oh-my-posh` initialization.

```powershell
Import-Module Terminal-Icons
```

After installing and importing the modules, your prompt will look like this when executing a `dir` command.

![Oh-My-Posh - Joe's Prompt dir with Terminal-Icons](/assets/images/posts/2024/power-prompt-with-windows-terminal-and-oh-my-posh/prompt-with-terminal-icons.png){: .align-center}

### Complete $PROFILE File

Here is what my `$PROFILE` file looks like, with respect to the *oh-my-posh* configuration, after adding all of the modules.

```powershell
oh-my-posh init pwsh --config "$env:POSH_THEMES_PATH\powerlevel10k_modern.omp.json" | Invoke-Expression
Import-Module posh-git
Import-Module PSReadLine
Import-Module Terminal-Icons
Set-PSReadLineOption -PredictionSource History
Set-PSReadLineOption -PredictionViewStyle ListView
Set-PSReadLineOption -EditMode Windows
```

## Wrap up

Now you have a customized PowerShell prompt with Windows Terminal and Oh-My-Posh.  You can customize the prompt further by creating your own theme or adding additional segments.  You can also add additional PowerShell modules to enhance your command line experience.

## References

* [Windows Terminal](https://learn.microsoft.com/en-us/windows/terminal/install?WT.mc_id=AZ-MVP-4024623){:target="_blank"}
* [Oh-My-Posh](https://ohmyposh.dev/){:target="_blank"}
* Oh-My-Posh [Themes](https://ohmyposh.dev/docs/themes){:target="_blank"}
* [Posh-git](https://github.com/dahlbyk/posh-git){:target="_blank"}
* [PSReadLine](https://github.com/PowerShell/PSReadLine){:target="_blank"}
* [Terminal Icons](https://github.com/devblackops/Terminal-Icons){:target="_blank"}
* [Set-PSReadLineOption](https://learn.microsoft.com/en-us/powershell/module/psreadline/set-psreadlineoption?view=powershell-7.4&WT.mc_id=AZ-MVP-4024623#parameters){:target="_blank"}
