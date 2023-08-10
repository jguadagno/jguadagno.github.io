---
title: "Visual Studio Code File List Sort Order"
header:
    og_image: /assets/images/posts/header/vscode-sort-order.png
date: 2022-12-10 08:50:00 -0700
categories:
- Articles
tags:
- Visual Studio Code
- Visual Studio
- VSCode
---
This morning I was working on a blog post on getting started with Developer Containers.
For this, I opened up [Visual Studio Code](https://code.visualstudio.com/?WT.mc_id=AZ-MVP-4024623){:target="_blank"}  and [JetBrains](https://www.jetbrains.com/){:target="_blank"} [Rider](https://www.jetbrains.com/rider/){:target="_blank"}.
Once I opened them side by side,
I noticed that the files on the file list in their "Explorers'" were in a different sort order.
This confused me because, at least I think,
they have always been in the same order, *dotted* (.) folders first,
then *underscored* (\_) folders, then "*regular*", then files.
That was not the case for Visual Studio Code it was sorted with *underscored* (\_) folders first,
then *dotted* (.) folders, then "*regular*", then files.

![Visual Studio Code - Explorer Sort Order - Default ](/assets/images/posts/vscode-sort-default.png){: .align-center}

Off to Bing, I went to see if I could find a setting to change the sort order.
It turns out that there is a setting to change the sort order.
The setting is `explorer.sortOrderLexicographicOptions` and has 4 options:

- `default` - Default sort order (Uppercase and lowercase names are mixed together)
- `lower` - Lowercase first (Lowercase names are grouped together before uppercase names)
- `upper` - Uppercase first (Uppercase names are grouped together before lowercase names)
- `unicode` - Unicode order (Names are sorted in Unicode order)

![Visual Studio Code - Explorer Sort Order - Options](/assets/images/posts/vscode-sort-options.png){: .align-center}

After changing the order to `Unicode` the file list was sorted the same way as I had it in JetBrains Rider.

![Visual Studio Code - Explorer Sort Order - Unicode](/assets/images/posts/vscode-sort-unicode.png){: .align-center}
