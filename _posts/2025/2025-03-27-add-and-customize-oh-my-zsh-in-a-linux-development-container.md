---
title: "Add and Customize Oh My Zsh in a Linux Development Container"
excerpt: "This article will guide you through the process of adding and customizing Oh My Zsh in a Linux Development Container for a better development experience."
header:
    og_image: /assets/images/posts/header/oh-my-zsh-development-container.png
date: 2025-03-27 08:20:00 -0700

categories:
- Articles
tags:
- Containers
- Docker
---
Lately, I've been creating [Development Containers](https://containers.dev/?wt.mc_id=DT-MVP-4024623){:target="_blank"} for my projects to ensure that my development environment is consistent across different machines and to not "pollute" my primary machine with a bunch of dependencies. One of the things I find missing when I use Development Containers is a powerful shell experience. In this article, we will explore how to add and customize Oh My Zsh in a Linux Development Container for a better development experience.

## Prerequisites

If you are not familiar with Development Containers, I recommend reading my previous article on [Getting Started with Developer Containers]({% post_url /2022/2022-12-10-getting-started-with-developer-containers %}){:target="_blank"} to get a better understanding of what Development Containers are and how to use them.

The rest of this article assumes you have a basic understanding of Development Containers and how to create and use them.

## Adding Oh My Zsh to a Development Container

Oh My Zsh is an open-source framework for managing Zsh configurations. It comes with a vast collection of themes and plugins that can enhance your shell experience. To add Oh My Zsh to your Development Container, you can add the feature called [common-utils](https://github.com/devcontainers/features/tree/main/src/common-utils){:target="_blank"} from the [Development Containers Features](https://containers.dev/features?wt.mc_id=DT-MVP-4024623){:target="_blank"} catalog. The `common-utils` feature will install Zsh, Oh My Zsh, and configure Zsh as the default shell in your Development Container.

Open your `.devcontainer/devcontainer.json` file and add the following configuration to the `features` section:

```yaml
"features": {
    "ghcr.io/devcontainers/features/common-utils": {
        "installZsh": true,
        "installOhMyZsh": true,
        "installOhMyZshConfig": true,
        "configureZshAsDefaultShell": true
    }
}
```

 If you want to add any custom plugins or themes, you can do so by adding the feature of [zsh-plugins](https://github.com/devcontainers-extra/features/tree/main/src/zsh-plugins){:target="_blank"} to the `features` section of the `devcontainer.json`. In the example below, I am going to add the [zsh-autosuggestions](https://github.com/zsh-users/zsh-autosuggestions){:target="_blank"} and the [zsh-syntax-highlighting](https://github.com/zsh-users/zsh-syntax-highlighting){:target="_blank"} plugins.

```yaml
"ghcr.io/devcontainers-extra/features/zsh-plugins:0": {
    "plugins": "zsh-autosuggestions zsh-syntax-highlighting",
    "omzPlugins": "https://github.com/zsh-users/zsh-autosuggestions.git https://github.com/zsh-users/zsh-syntax-highlighting.git"
}
```

* Line 2: in the example above, the `plugins` entry, specifies the plugins to be installed.
* Line 3: the `omzPlugins` entry, specifies the locations to download the plugins from.

Your complete `feature` section should look something like this:

```yaml
"features": {
    "ghcr.io/devcontainers/features/common-utils": {
        "installZsh": true,
        "installOhMyZsh": true,
        "installOhMyZshConfig": true,
        "configureZshAsDefaultShell": true
    },
    "ghcr.io/devcontainers-extra/features/zsh-plugins:0": {
        "plugins": "zsh-autosuggestions zsh-syntax-highlighting",
        "omzPlugins": "https://github.com/zsh-users/zsh-autosuggestions.git https://github.com/zsh-users/zsh-syntax-highlighting.git"
    }
},
```

### The dotfiles

The power of Oh My Zsh comes from the ability to customize your shell experience. Let's take a look at how you can customize your Development Container with Oh My Zsh.

#### Oh My Zsh Configuration

Oh My Zsh comes with a default configuration file called `.zshrc`. You can customize your shell experience by adding your configurations to the `.zshrc` file. You can find the `.zshrc` file in the `~/.oh-my-zsh` directory in your Development Container. You can further customize the `.zshrc` file by using the various themes and plugins available with Oh My Zsh. If you already have a `.zshrc` file that you use on your local machine, you can use that. Or if you don't, you can use the one that use which is hosted on GitHub. My [zshrc](https://github.com/jguadagno/dotnet10-devcontainer/blob/main/.devcontainer/dotfiles/.zshrc){:target="_blank"} file is available on GitHub.

For this sample, you will want to create a directory called `dotfiles` in your `.devcontainer` directory and add the `.zshrc` file to it. We'll copy the files in a few steps ahead.

#### Powerlevel10k Configuration

I use the [Powerlevel10k](https://github.com/romkatv/powerlevel10k){:target="_blank"} theme which has its own configuration file, `p10k.zsh`. Just like the `.zshrc` file, you can customize this file to your needs. This file needs to be in the `~/` directory in your Development Container. If you do not have a `p10k.zsh` file, you can use the one I provide in my GitHub repository. My [.p10k.zsh](https://github.com/jguadagno/dotnet10-devcontainer/blob/main/.devcontainer/dotfiles/.p10k.zsh){:target="_blank"} file is available on GitHub.

Just like the `.zshrc` file, you will want to create a directory called `dotfiles` in your `.devcontainer` directory and add the `.p10k.zsh` file to it for this script to work.

### Copying the dotfiles

The next step will require you to copy the dotfiles to the appropriate directories in your Development Container. For this, I create a script that we will run in the `postCreateCommand` section of the `devcontainer.json` file.

Start by creating a script called `post-create.sh` in the `.devcontainer` directory. I created a `scripts` folder in the `.devcontainer` directory and added the `post-create.sh` file to it. The `post-create.sh` file will look like this:

```bash
#!/bin/bash

#######
# Config ZSH
#######
# powerline fonts for zsh theme
git clone https://github.com/powerline/fonts.git
cd fonts
./install.sh
cd .. && rm -rf fonts

# oh-my-zsh plugins
zsh -c 'git clone --depth=1 https://github.com/romkatv/powerlevel10k.git ${ZSH_CUSTOM:-~/.oh-my-zsh/custom}/themes/powerlevel10k'
cp .devcontainer/dotfiles/.zshrc ~
cp .devcontainer/dotfiles/.p10k.zsh ~
```

Let's break down the script:

* Line 7-10: Clones the fonts repository and installs the fonts, which helps with the Powerlevel10k theme.
* Line 13: Clones the Powerlevel10k theme to the `~/.oh-my-zsh/custom/themes` directory.
* Line 14-15: Copies the `.zshrc` and `.p10k.zsh` files to the `~` *home* directory.

### Running the post-create.sh script

To run the `post-create.sh` script, you need to add it to the `postCreateCommand` section of your `devcontainer.json` file. Here’s how you can do that:

```yaml
"postCreateCommand": ".devcontainer/scripts/post-create.sh",
```

Now this will run the `post-create.sh` script after the container is created. However, we are not done yet. We need to enable the fonts in the terminal. That's next.

### Enabling the Fonts in the VS Code Terminal

To enable the fonts in the VS Code terminal while you are in the Development Container, you will need to update the `customizations` section of the `devcontainer.json` file. Add the following configuration to the `customizations` section:

```yaml
"customizations": {
    "vscode": {
    "settings": {
        "editor.tabSize": 4,
        "terminal.integrated.fontFamily": "MesloLGM Nerd Font",
        "terminal.integrated.fontLigatures.enabled": true,
        "terminal.integrated.defaultProfile.linux": "zsh",
        "terminal.integrated.profiles.linux": {
            "zsh": {
                "path": "/bin/zsh",
                "icon": "terminal-ubuntu"
            }
        }
    }
}
```

Let's break down the configuration:

* Line 5: Sets the font family to `MesloLGM Nerd Font`. You'll want to use a Monospaced font that supports the ligatures characters. Usually any font with `Nerd Font` in the name will work.
* Line 6: Enables font ligatures. This allows the icons to be displayed correctly.
* Line 7: Sets the default profile for the terminal to `zsh`.
* Line 8-12: Configures the `zsh` profile for the terminal. The `path` entry specifies the path to the `zsh` binary, and the `icon` entry specifies the icon to use for the terminal.

### Restart or Rebuild the Development Container

At this point, you are ready to build/rebuild your Development Container. This can be done through the Command Palette in VS Code by selecting **Dev Containers: Rebuild Container**.

## The Final Result

After rebuilding the Development Container, you should see the Powerlevel10k theme in the terminal. If you used my samples, the prompt and terminal will look like this:

![Customized Terminal in a Linux Development Container](/assets/images/posts/2025/add-and-customize-oh-my-zsh-in-a-linux-development-container/terminal-window.png)
{: .align-center}

You can now customize your shell experience by adding your configurations to the `.zshrc` and `.p10k.zsh` files. You can also explore the various themes and plugins available with Oh My Zsh to tailor your environment to your preferences. Just remember to copy the modified files from the container to the `dotfiles` and rebuild the container.

## Wrap Up

In conclusion, customizing your Development Container with Oh My Zsh can significantly enhance your shell experience, making your development process more efficient and enjoyable. I encourage you to explore the various themes and plugins available with Oh My Zsh to tailor your environment to your preferences.

If you don't want to go through all of the steps, you can take a look at this [repository](https://github.com/jguadagno/dotnet10-devcontainer){:target="_blank"} for a complete setup.

## References

* [Getting Started with Developer Containers]({% post_url /2022/2022-12-10-getting-started-with-developer-containers %}){:target="_blank"}
* [Development Containers Overview](https://containers.dev/?wt.mc_id=DT-MVP-4024623){:target="_blank"}
* [Development Containers Template](https://containers.dev/templates?wt.mc_id=DT-MVP-4024623){:target="_blank"}
* [Development Containers Features](https://containers.dev/features?wt.mc_id=DT-MVP-4024623){:target="_blank"}
* [Development Containers Visual Studio Code Extension](https://marketplace.visualstudio.com/items?itemName=ms-vscode-remote.remote-containers&wt.mc_id=DT-MVP-4024623){:target="_blank"}
* [Create a Development Container](https://code.visualstudio.com/docs/devcontainers/create-dev-container?wt.mc_id=DT-MVP-4024623){:target="_blank"}
* [Oh My Zsh](https://ohmyz.sh/){:target="_blank"}
