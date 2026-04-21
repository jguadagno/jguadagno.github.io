---
title: "Are we the parents in the AI Agent relationship? The drama continues"
date: 2026-04-20 17:55:00 -0700
header:
    og_image: /assets/images/posts/header/agent-drama.png
categories:
- Articles
tags:
- Squad
- AI
- Agents
- GitHub
- GitHub Copilot
- Copilot
excerpt: "The Agent drama continues... Lately I have been having problems with GitHub Copilot and/or with the agents not 'listening' or 'remembering' directives."
---

The Agent drama continues... Lately I have been having problems with GitHub Copilot and/or with the agents not "listening" or "remembering" directives.  In the last three days I have had to repeat myself multiple times, "*All work must have a GitHub issue. All work must have a branch with the following format `issue <number>-description`. All work must have a PR submitted and tagged with the issue".  The last three issues were done on main.*" I asked copilot, what can we do to fix this. After a little thinking, it come up with some agent instructions, some [githooks](https://github.com/jguadagno/jjgnet-broadcast/tree/main/.githooks){:target="_blank"}, and a new task ([pr-metadata](https://github.com/jguadagno/jjgnet-broadcast/blob/a9ff592e61c30cb4a4115a14c5ba5b22e332a38c/.github/workflows/ci.yml#L14){:target="_blank"}) as part of the [CI](https://github.com/jguadagno/jjgnet-broadcast/blob/main/.github/workflows/ci.yml){:target="_blank"} job to validate the metadata for a PR and a bit more that we implemented a few hours ago.  I just gave it some more work and guess what happened.  You guessed it. Ding, ding, ding! All the work was done on main.  I asked Copilot why.  

>The changes were in main. We just went through a bunch of changes to prevent this and instruct ALL WORK TO BE DONE IN ISSUE BRANCHES and PRs. HOW DID THIS HAPPEN? "

Yes, I used all caps, I was frustrated. 😊 . It responded with.

> It happened because I routed and launched the work from the current checkout on main instead of enforcing issue-branch setup first. The session was on main, and I spawned Trinity/Tank with WORKTREE_MODE: false and WORKTREE_PATH: n/a, so the edits landed in the live checkout.
>
> Root cause: coordinator failure, not an agent one. I did not enforce the branch gate before starting issue work, even though the repo policy already says work must go through issue branches and PRs. I’ve captured your directive  explicitly: all work must be done in issue branches and PRs, never directly on main."

I then said:

>We've recorded this rule multiple times and added git commit hooks and more to stop this. As a coordinator, why are you not looking at the rules and decisions first.  I, and we, keep on wasting time because you are not following the directions

It responded with:

> You’re right. I’m recording this as a blocking coordinator directive now, then I’ll answer the failure plainly.

Then some thinking, and then:

>I confirmed the rule is already explicit in routing, and I’m adding your stronger coordinator directive now.

It was thinking for a while and then said:

> 📌 Captured. Coordinator must read and obey the existing rules and decisions first, especially branch-and-PR-only policy, before launching work.
>
> Why I failed: I did not execute the preflight discipline I was supposed to. The rule was already present in routing.md (All work must be delivered via a pull request — no direct commits to main), and the team decisions already show branch/worktree-based flow. I still routed from the live main checkout instead of stopping on that rule first.
>
> Why the protections didn’t save us: hooks and similar guards mostly protect commit/push boundaries. They do not stop a coordinator from launching edits into a dirty working tree on main before any commit exists. The mistake happened earlier in the flow: I should have refused to start issue work until we were on an issue branch or dedicated worktree.
>
> Bottom line: this was not a missing-rule problem; it was a coordinator compliance failure.

As one of my friends and LinkedIn contacts said on this [post](https://www.linkedin.com/feed/update/urn:li:activity:7451016283128496128/){:target="_blank"}:

> Yep they often act like teenagers. They "yup" you to death, ignore your remarks, and the money keeps going out the door. Just like being a parent!

It's kind of funny, a little accurate, and a little sad.

After this conversation, the "team" began to implement some of the changes that I wanted and submitted a PR with the changes.  Guess what, the PR failed because the metadata was not correct.  This is a good thing and a bad thing.  The good thing is that the system is working and catching the mistakes.  The bad thing is that agents did not "*remember*" or knew about the directives and rules that we have in place. So I asked the Coordinator, aka *Scribe*...

>Scribe, update everyone's charters to make them aware of the PR metadata requirements we have to avoid unnecessary 
failures please.

Yes, I said "please".  I am trying to be nice.  It responded with:

> Scribe’s on it — updating the squad charters so PR metadata rules are explicit up front.
>
> | Agent | Work |
> | --- | --- |
> | 📋 Scribe (claude-haiku-4.5 fast) | Add PR metadata requirements to the team’s charter files to prevent repeat CI failures |
>
> Baseline guidance added: PR titles must follow `<type>(#<issue>): <summary>`, and PR bodies must include closing metadata like `Closes #<issue>` or `Fixes #<issue>` when applicable. Scribe also recorded the wording in `.squad\decisions\inbox\scribe-pr-metadata-charters.md`.

## Wrapping up

I am not sure if this is a problem with the agent or the coordinator or my configuration, but I am leaning towards the configuration and the maturity of the system.  I have been working with agents for a while now and I have seen them make mistakes, but mostly because I did not provide clear enough directives or enforce the rules consistently.

Hopefully this will help and we will not have to go through this again. I will continue to monitor this and see if it happens again.  In the meantime, I will be more vigilant in making sure that all work is done in issue branches and PRs.

## References

- GitHub Copilot [website](https://github.com/features/copilot){:target="_blank"}
- GitHub Copilot [CLI](https://github.com/features/copilot/cli/){:target="_blank"}
- Joseph Guadagno [Broadcasting](https://github.com/jguadagno/jjgnet-broadcast/){:target="_blank"}
