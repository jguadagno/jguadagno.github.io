---
title: "Prevent GitHub Copilot from going to sleep"
date: 2026-05-30 12:30:00 -0700
header:
    og_image: /assets/images/posts/header/github-copilot-keep-alive.png
categories:
- Articles
tags:
- AI
- Agents
- GitHub
- GitHub Copilot
- Copilot
excerpt: "Recently, I discovered an option in GitHub Copilot Cli that prevents the computer from going to sleep..."
---

Computers nowadays have aggressive power settings to conserve energy. On my laptop, Windows recommends to put the monitor and computer to sleep after 3 minutes of inactivity. Normally this is fine. However, in the days of AI and agents, a lot of times I give [GitHub Copilot Cli](https://github.com/features/copilot/cli/){:target="_blank"} a task and then walk away from the computer. Based on my current configuration, the task would basically stop at 3 minutes in, then resume when I come back.  Recently, I discovered an option in GitHub Copilot Cli that prevents the computer from going to sleep.  There used to be a slash command called `caffeinate`, now it's called `keep-alive`, although `caffeinate` still works.

## How to use it

The slash command is pretty simple to use.  While in the interactive interface, just type `/keep-alive` and hit enter.  This will show you the current keep-alive status. If you want to prevent the computer from going to sleep until you exit the interactive interface, you can use the command `/keep-alive on`.  If you want to allow the computer to go to sleep based on the power settings, you can use the command `/keep-alive off`.  You can also specify a duration in minutes, for example `/keep-alive 60` will prevent the computer from going to sleep for 60 minutes. You can use minutes, hours or days. If no unit is specified, minutes are assumed. For example, `/keep-alive 2h` will prevent the computer from going to sleep for 2 hours, and `/keep-alive 1d` will prevent the computer from going to sleep for 1 day.

If you want to prevent the computer from going to sleep while there is an active task running in the background, you can use the command `/keep-alive busy`. This will keep the computer awake as long as there is an active task running in the background, and will allow it to go to sleep when there are no active tasks.

Syntax:

```bash
/keep-alive [on|off|busy|[DURATION]]
```

| Option | Description |
| --- | --- |
| *nothing* | if no option is provided, copilot will return the current keep-alive status. |
| on | Prevents the computer from going to sleep until you exit the interactive interface. |
| off | Turns off the keep-alive and allows the computer to go to sleep based on the power settings. |
| busy | Prevents the computer from going to sleep while there is an active task running in the background. |
| [DURATION] | Prevents the computer from going to sleep for the specified duration in minutes. For example, `/keep-alive 60` will prevent the computer from going to sleep for 60 minutes. You can use minutes, hours or days. If no unit is specified, minutes are assumed. |

## Wrapping up

As you can see, the `/keep-alive` command is a very useful command to prevent the computer from going to sleep while you are working on a task with GitHub Copilot Cli.  This is especially useful when you have long-running tasks that may take more than a few minutes to complete.  By using this command, you can ensure that your tasks will not be interrupted by the computer going to sleep, and you can walk away from your computer without worrying about it.  Just remember to turn off the keep-alive when you are done with your tasks to allow your computer to conserve energy.

## References

- GitHub Copilot [website](https://github.com/features/copilot){:target="_blank"}
- GitHub Copilot [CLI](https://github.com/features/copilot/cli/){:target="_blank"}
- GitHub Copilot CLI [Slash Commands](https://docs.github.com/en/copilot/reference/copilot-cli-reference/cli-command-reference#slash-commands-in-the-interactive-interface){:target="_blank"}
