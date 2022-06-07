---
title: "This post was written with GitHub Copilot"
header:
    og_image: /assets/images/posts/header/github-copilot-writing.png
date: 2022-01-13 18:15:00 -0700
categories:
  - Articles
tags:
  - GitHub
  - CoPilot
  - blog
---
In this post, I will be writing about how I used GitHub Copilot to write this post. You might be thinking that GitHub Copilot is a for writing code and you would right. However, it is a tool for writing content also.

This post is based on the following products:

| Product | Version | Download Link |
| ------- | ------- | ------------- |
| Visual Studio Code | 1.67.0 | [Download](https://code.visualstudio.com/Download){:target="_blank"} |
| GitHub Copilot | 1.7.4421 | [Sign up](https://copilot.github.com/){:target="_blank"} |
| GitHub Copilot Extension | 1.7.4421 | [Install](https://marketplace.visualstudio.com/items?itemName=GitHub.copilot){:target="_blank"} |

Note: Github Copilot is in Technical Preview when this post was written and is subject to change.
{: .notice--info}

Now some of the suggestions that GitHub Copilot makes are a little *freaky* as to how good the predictions are. I'll cover some of them in this post.

Before I show you some off them, I wanted to show you that GitHub pilot started working on the post before I even write the first word. When I start writing a post, I first start out with file name which is typically formatted `yyyy-mm-dd-title-of-post.md`, which by the way this was suggested by GitHub Copilot. :smile: The file name for this post is `this-post-was-written-with-github-copilot.md`. After the file is created I start working on the header or metadata for the post. Once I started typing `title: :` for the header or metadata of this post, GitHub Copilot suggested the title of the post.

![Title Suggestion](/assets/images/posts/github-copilot-title.png)

This is what a typical header looks like:

```yaml
---
title: "This post was written with GitHub Copilot"
header:
    og_image: /assets/images/posts/header/github-copilot-writing.png
date: 2022-01-13 17:30:00 -0700
categories:
  - Articles
tags:
  - GitHub
  - CoPilot
  - blog
---
```

I recorded a [video](https://www.youtube.com/watch?v=-xK215uA6QI){:target="_blank"} while I was writing this post so you can see, if you wish, how I use GitHub CoPilot to write this posts. If you watch the video, you will see my typing errors but more so how GitHub Copilot suggests the text for this post.

Now let's look at some of the suggestions that GitHub Copilot has made.

## Tip 1: Lists in Markdown

This blog is written using Markdown, more on this in a future post. In a previous post, I created a list of items I wanted to cover.  Sample list below:

```markdown
## Presentation

C# 10 language features
ASP.NET Changes
Maui, no, not the beach
Performance improvements
New APIs
Other enhancements
```

Once I added the list above and start typing `###` to create a new heading Github Copilot is going to suggest the next item in the list.

```markdown
### C# 10 language features
### ASP.NET Changes
### Maui, no, not the beach
```

![Clipboard](/assets/images/posts/github-copilot-lists.gif)

Minute marker: 3:21 to 6:38

## Tip 2: Clipboard

Github Copilot is going to suggest items from the clipboard that make sense. I am going to copy the url to this blog `josephguadagno.net` to the clipboard, then create a link in the document.

Link to the blog: [josephguadagno.net](https://josephguadagno.net)

That's pretty cool.

![Clipboard](/assets/images/posts/github-copilot-clipboard.gif)

Minute Marker: 8:28 to 8:40

## Tip 3: Markdown Headers

After I typed the `##` to indicate a H2 heading, Github copilot suggested that I name it `Tip 3: Markdown Preview` but if I have labeled my headers as `Tip 1`, `Tip 2`, etc is I had in the draft of this post all I would have had to do is hit `Tab` and `Enter`.

![Headers](/assets/images/posts/github-copilot-headers.gif)

Minute Marker: 8:55 to 9:07

## Tip 4: Patterns

Github Copilot is going to suggest patterns that make sense. I am going to create a pattern in the document.

`DistinctBy/InsertBy/RemoveBy/UpdateBy/WhereBy`

After I typed `DistinctBy/InsertBy/`, after I type `Remove` the `By/` was added. Github Copilot recognized the `*By/` pattern and suggested the next item in the list.

![Headers](/assets/images/posts/github-copilot-headers.gif)

Minute Marker: 12:10 to 12:35

## Things to Note

Validate URLs, it makes assumptions based on previous URLs or patterns that might not match the actual URL.

## Wrap Up

As I discover more about the features of GitHub Copilot, I will add to this post.
