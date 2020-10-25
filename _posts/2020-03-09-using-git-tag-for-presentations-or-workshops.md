---
title: "Using git tag for Presentations or Workshops"
date: 2020-03-09 18:30:00 -0700
excerpt: "While we hope it never happens, demo failures happen when presenting talks or doing workshops. I do not know of a speaker that has not had a demo go bad while up on stage or live streams. Many of us have a back up plan... After searching around for solutions for this, I decided to use git tagging to solve this for me."
categories:
  - Articles
tags:
  - git
  - presentation
  - workshop
---

While we hope it never happens, demo failures happen when presenting talks or doing workshops.  I do not know of a speaker that has not had a demo go bad while up on stage or live streams. Many of us have a back up plan.  Some record screenshots or videos of the code, some create multiple copies of the code (ie: Start, Step 1, Step2, etc, End), some use assorted version control (git, TFS, SVN, etc), or even just USB drives. I, myself, have been a 'create multiple copies of the code' kind of presenter.  While that has worked for me in the past, it has some challenges.  The folders can be large, especially with Node projects or a lot of packages. Sharing between laptops is a pain. And backing up the solutions/demos.  After searching around for solutions for this, I decided to use git [tag](https://git-scm.com/book/en/v2/Git-Basics-Tagging)ging to solve this for me.

In a nutshell, git tagging provides the ability to 'tag' a specific commit with a message similar to [label](https://docs.microsoft.com/en-us/azure/devops/repos/tfvc/label-command-team-foundation-version-control?view=azure-devops) in TFS. Some might be saying, but you can do the same with a branch, and while yes you can, a branch is also subjected to changes if you are not careful, a tag is associated with an individual commit id.

> [How is a tag different from a branch in Git? Which should I use, here?](https://stackoverflow.com/questions/1457103/how-is-a-tag-different-from-a-branch-in-git-which-should-i-use-here)
>
> -Stack Overflow

## The How

For my planned presentations or workshops, I generally have a script that I use. The script contains setup info for the talk (tools, software, versions, etc), prep work (how to get ready), then the actual talk.  The talk is usually bullet points with the code snippets I want to run/type/copy&paste/etc.  Sometimes, as we all know, code does not always run the first time or you type something and things break and you have to recover.  The good presenters, typically recover without the attendees even knowing. This is where the *tagging* comes in. Now, instead of multiple copies of the different 'stages' or 'steps' in a demo, I commit the step and then `git *tag*` the commit.

### The Steps

First step is to start with a git repository for your presentation or demo. The provider, [GitHub](https://github.com/), [Azure](https://azure.microsoft.com/en-us/products/github/?WT.mc_id=AZ-MVP-4024623), [GitLab](https://about.gitlab.com/) or others does not matter. I chose GitHub because it's free and more people use it.

Second step is in `git init` your folder where your code is going to be. Don't forget to add a `.gitignore`!

The third step is where we 'track' or store our presentations '*steps*'. For me, I get the code to a starting point, aka 'File New' stage, this is where I typically start the presentation or workshop, then perform the first **commit**. This is a combination of 4 git commands.

1. `git add .` - This will add all of the files since the last commit
2. `git commit -m "Your commit message"` - Replace `"Your commit message"` with a meaningful message. For me, these have been the step names, like '*Demo-Start*', '*Demo-Database Complete*'
3. `git push origin master` - This may vary for you and is based on my understanding of git :smile:
4. `git tag "Tag Message/Name"` - Replace `"Tag Message/Name"` with the name for the tag. This is the name you want call the commit. I use the same name as the commit message.

After I `tag` the commit, I am ready to repeat step 3 until all of the steps are done.

So an example of running through the steps would be something like this.

```bash
gittag "Demo-Start"
gittag "Demo-FileNewComplete"
gittag "Demo-DatabaseComplete"
#...
gittag "Demo-Complete"
```

**Note**: I talk about the `gittag` below.

The fourth step is a 'final' commit and tag for 'completed demo'.

Step five, this is an **important** step.  You must commit your tags to the repo! Tags, by nature, are local to your machine.  This step is only required if you are sharing the repository, for instance, a workshop, or want the ability to 'pull down' the tags or steps from another machine, which is something I do :smile:.  To do that, execute `git push origin --tags` from the command line.

You can run the individual commands if you want but I created a bash and windows script to execute the commands for me which I included [below](#helper-scripts) which I called `gittag`.

## Reverting Back to a Step

Let's say your in the middle of demo at step 3 and all the sudden it's no longer working.  What do you do?  For me, I used to run back to the hotel room, cry and run through the demo a few more times to see why it didn't work.  Well I don't need to do that anymore, now I just execute `git checkout *step/tag name*` and the code is right where I left it.  So if I wanted to start fresh, I would run `git checkout Demo-Start` and be ready to go.

**Note** If you are using a package manager like npm or NuGet, you will have to restore those packages after running this command.

**Note** This does not account for any database changes, or web services call, or anything but the files on the file system that you are controlling with git.

## Summary

That's it. Follow steps 1-4 [above](#the-steps) to record/backup your steps and [revert back](#reverting-back-to-a-step) if need be.

I hope this helps!

## Helper Scripts

### Linux (Mac iOS)

```bash
#!/bin/zsh
commitMessage=$1
commitTag=$2
if [ -z "$commitMessage" ]; then
 echo "syntax: gittag 'message'"
 exit;
fi
if [ -z "$commitTag" ]; then
 $commitTag=$commitMessage
fi
git add .
git commit -m $commitMessage
git push origin master
git tag $commitTag
```

### Windows

```batch
@ECHO OFF
if "%1"=="" GOTO MissingArg1
SET commitMessage=%1

if "%2"=="" (SET commitTag=%commitMessage%) else (SET commitTag=%2)

git add .
git commit -m %commitMessage%
git push origin master
git tag %commitTag%
exit 0

:MissingArg1
echo syntax: gittag 'message' 'tag'
echo   tag is optional
exit 1
```
