---
title: "Backing Up Your Laptop Applications, Packages, and Configuration"
excerpt: "I've been thinking about purchasing a new laptop for travel.  This got me thinking about the trauma of setting up a new laptop. In the past, I would spend some time on my existing laptop 'writing down' all the applications, settings, and configurations for my current laptop.  This was a tedious process and I would always forget something.  I would then spend the next few weeks remembering what I had forgotten and making the changes.  This was a very inefficient process."
header:
    og_image: /assets/images/posts/header/backing-up-laptop.png
date: 2025-03-03 16:11:00 -0700

categories:
- Articles
tags:
- Technology
- git
- GitHub
- Settings
---
I've been thinking about purchasing a new laptop for travel.  This got me thinking about the trauma of setting up a new laptop. In the past, I would spend some time on my existing laptop "writing down" all the applications, settings, and configurations for my current laptop.  This was a tedious process and I would always forget something.  I would then spend the next few weeks remembering what I had forgotten and making the changes.  This was a very inefficient process.

For a while now I have been using [UniGetUi](https://www.marticliment.com/unigetui/){:target="_blank"} to install (almost) all of the applications on my laptop.  This has saved me a lot of time since UniGetUi can install and update applications from popular package managers like [Winget](https://learn.microsoft.com/en-us/windows/package-manager/?WT.mc_id=DT-MVP-4024623){:target="_blank"}, [Scoop](https://scoop.sh/){:target="_blank"}, [Chocolatey](https://chocolatey.org/){:target="_blank"}, [Pip](https://pypi.org/){:target="_blank"}, [Npm](https://www.npmjs.com/){:target="_blank"}, [.NET Tool](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-tool-install?WT.mc_id=DT-MVP-4024623){:target="_blank"} and [PowerShell Gallery](https://www.powershellgallery.com/?WT.mc_id=DT-MVP-4024623){:target="_blank"}.  Recently, UniGetUi has added a feature that allows you to backup the list of installed applications/packages to a Json file.  This file can then be used to install all of your applications/packages on a new laptop.

The engineer in me was wondering how I could store this configuration, more so the applications and configuration from this laptop that I use regularly.  I figured I would create a repository on GitHub and store the configuration there.  I could then clone this repository to a new laptop and run the UniGetUi application to install all the applications.  This would save me a lot of time and hassle.  I could also use this repository to store all my settings and configurations.  This would make setting up a new laptop a breeze.  I could also share this repository with others.  This would allow others to easily install all the applications/packages and settings that I use.  This would be a huge time saver for them as well.

## What you will need

* UniGetUi installed on your laptop.  You can download it from [here](https://www.marticliment.com/unigetui/){:target="_blank"}.
* A Git account with a service like GitHub, BitBucket, or GitLab
* PowerShell installed on your laptop. PowerShell is optional, but the script I wrote to refresh the files is written in PowerShell. More on this later.

## The Repository

I started by creating a repository on GitHub.  This particular repository is called [machine-dell5570-config](https://github.com/jguadagno/machine-dell5570-config){:target="_blank"}. Initially, I added some of the common files I need for my configuration, like:

* `.gitignore` - This a common `.gitignore` file that I use across my projects. It also serves a second purpose to make sure I don't commit any secrets to the repository.
* `Microsoft.PowerShell_profile.ps1` - This file is used to store my PowerShell profile.
* `DESKTOP-8IKVGQI installed packages 2025-01-26 07-51-10.ubundle` - This file is used to store the applications/packages installed using UniGetUi.

The `DESKTOP-8IKVGQI installed packages 2025-01-26 07-51-10.ubundle` file is the file that UniGetUi creates as a backup of your installed files. Underneath the hood, it is a json file that describes each application, the version, and the installation source. I can then use this file to install all the applications on a new laptop. However, UniGetUi will generate a new file each time it creates a backup. This would have created a lot of files in the repository and defeat the purpose of using Git. I also wanted to automate this process a little bit. I ended up creating a new PowerShell script to manage this.

## Backing up the Application/Package List with UniGetUi

To back up the application/package lists using UniGetUi, you can utilize the backup feature. This will create a JSON file containing all the installed applications/packages that were installed using UniGetUi, which can be helpful when transferring settings to a new machine. Here's how to do it:

1. Open UniGetUi.
2. Navigate to the settings menu.
3. Scroll down to *Backup installed packages* and expand the section.

![UniGetUi Backup Settings](/assets/images/posts/2025/backing-up-your-laptop-configuration/unigetui-backup-settings.png){: .align-center}

Note: This image was taken from version 3.1.7 of the application. The layout may vary slightly in other versions.
{: .notice--info}

At this point you can configure the backup settings to your needs.  I've accepted the defaults which enabled a backup periodically, adds a timestamp to the filename, and saves the file to the *My Documents*`\UniGetUi` folder.

As I mentioned in the previous section, this will generate a new file each time it creates a backup.  The naming convention seems to be `<COMPUTERNAME> installed packages YYYY-MM-DD HH-MM-SS.ubundle`.  I did not want a Git repository full of these files, so I created a PowerShell script to help me manage this. More on that next.

## The PowerShell Script

As I mentioned before, the engineer wanted to automate this process a little bit.  I created a PowerShell script to automatically copy the latest files I care about to the git repository and commit them. Let's walk through the script.

### UniGetUi Backup File Management

To manage the UniGetUi backup files, I wrote a PowerShell script that automatically renames the latest backup file to a more manageable name and moves it to a designated folder where the git repository resides.

Let's look at the code:

```powershell
# Initial common vairables
$MyDocumentsFolder = [Environment]::GetFolderPath('MyDocuments')

# Get the latest UniGet Bundle
$UniGetFolder = $MyDocumentsFolder + "\UniGetUi"
$UniGetBackupName = "UniGet Installed Packages.json"
$NewestFile = Get-ChildItem -Path $UniGetFolder -Filter "*.ubundle" -File | Sort-Object LastWriteTime -Descending | Select-Object -First 1
Copy-Item -Path $NewestFile.FullName -Destination $UniGetBackupName
git add $UniGetBackupName
```

* Line #2, I get the `My Documents` folder.
* Line #5, I create a variable to store the path to the UniGetUi folder.
* Line #6, I create a variable to store the name of the file I want to use.
* Line #7, I get the newest file in the UniGetUi folder.
* Line #8, I copy the newest file to the new name.
* Line #9, I add the new file to the git repository.

### Getting the latest PowerShell Profile

```powershell
# Get the latest PowerShell_profile
Copy-Item -Path $PROFILE
git add .
```

* Line #2, I copy the latest PowerShell profile to the git repository. ***Note:*** `$PROFILE` is a built-in variable in PowerShell that points to the current user's profile script.
* Line #3, I add the new file to the git repository.

### Committing the Changes

```powershell
# Commit the updated files to git
$gitMessage = "Updated files  $(Get-Date)"
git commit -m $gitMessage
git push
```

* Line #2, I create a variable to store the commit message, which includes the current date and time `$(Get-Date)`.
* Line #3, I commit the changes to the git repository with the commit message.
* Line #4, I push the changes to the remote repository.

### The Full Script

Having these tasks in a single script makes it easier to manage the files, add additional items, and commit them to the repository for safekeeping.

The full source for the PowerShell script can be found at [Refresh-Files.ps1](https://github.com/jguadagno/machine-dell5570-config/blob/main/Refresh-Files.ps1){:target="_blank"}.

## Restore the Applications and Packages

To restore your applications and packages after setting up a new laptop, you can utilize the configuration files stored in your Git repository. Here’s a step-by-step guide:

* **Install UniGetUi**: Start by installing UniGetUi on your new laptop. You can download it from [here](https://www.marticliment.com/unigetui/){:target="_blank"}.
* **Install Git**: If you haven't already, install Git on your new laptop. You can download it from [here](https://git-scm.com/){:target="_blank"}.
* **Open a PowerShell Terminal**: Open a PowerShell terminal on your new laptop.
* **Clone the Repository**: Start by cloning your configuration repository to your new laptop using the following command:

```bash
git clone <Url Repository Url> # Similar to https://github.com/jguadagno/machine-dell5570-config
```

* **Navigate to the Directory**: Change into the cloned repository's directory:

```bash
cd <Path to the cloned repository> # Example: cd machine-dell5570-config
```

* **Install Applications with UniGetUi**: Use the JSON file previously created to install the applications.

1. Open UniGetUi
2. Navigate to the *Package Bundles*
3. Click *Open Existing Bundle*
4. Select the file `UniGet Installed Packages.json` from the cloned repository.
5. Select all of the applications/packages you want to install.
6. Click the *Install selection* button.

* **Restore PowerShell Profile**: Copy the `Microsoft.PowerShell_profile.ps1` file back to your PowerShell profile location. You can do this using:

```powershell
Copy-Item -Path .\Microsoft.PowerShell_profile.ps1 -Destination $PROFILE -Force
```

At this point, you should have successfully restored your applications and settings to your new laptop. This process can save you a lot of time and effort when setting up a new machine.

## Wrap Up

In conclusion, using UniGetUi along with a properly managed Git repository will greatly streamline the process of setting up a new laptop. Remember to regularly commit changes to keep your repository updated and ready for use on a new machine.

## References

* [UniGetUi](https://www.marticliment.com/unigetui/){:target="_blank"}
* [Winget](https://learn.microsoft.com/en-us/windows/package-manager/?WT.mc_id=DT-MVP-4024623){:target="_blank"}
* [Scoop](https://scoop.sh/){:target="_blank"}
* [Chocolatey](https://chocolatey.org/){:target="_blank"}
* [Pip](https://pypi.org/){:target="_blank"}
* [Npm](https://www.npmjs.com/){:target="_blank"}
* [.NET Tool](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-tool-install?WT.mc_id=DT-MVP-4024623){:target="_blank"}
* [PowerShell Gallery](https://www.powershellgallery.com/?WT.mc_id=DT-MVP-4024623){:target="_blank"}
