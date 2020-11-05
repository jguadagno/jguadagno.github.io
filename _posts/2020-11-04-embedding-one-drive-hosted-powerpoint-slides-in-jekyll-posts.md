---
title: "Embedding OneDrive Hosted PowerPoint slides in Jekyll Posts"
header:
    og_image: /assets/images/posts/header/embed-powerpoint-jekyll.png
categories:
  - Articles
tags:
  - Jekyll
  - OneDrive
  - PowerPoint
---
I was chatting with Dave Brock ([@daveabrock](https://twitter.com/daveabrock){:target="_blank"}) about our .NET 5 presentations today ([.NET 5 - What is it?]({% link _presentations/dotnet5-what-is-it.md %})). He mentioned that he wanted to "steal" my PowerPoint embed feature.  Dave's a nice guy and all but is it really stealing if you ask for it? :smile:

Here is what the page looks like on my site.

![Screen shot](/assets/images/posts/embed-powerpoint-example.png){: .align-center}

I host all of my presentations decks on OneDrive and make them available to all the attendees of my talks.  This allows me to embed the links in any emails or sites that I want to. I embed all the talks, code links, and sample videos on each of the talks' respective pages on my [site]({% link _pages/presentations.md %}). With my site is built using [Jekyll](https://jekyllrb.com/){:target="_blank"} and hosted on GitHub pages, embedding the slide decks was quite simple. Now here is the how?

## Get the Embed Code from OneDrive

First, navigate to the file you want to embed in your online (this needs to be done via the web client) OneDrive file lists and select it.

![Screen shot](/assets/images/posts/embed-powerpoint-select-file.png){: .align-center}

Next, you will see on the toolbar, an `</>Embed` button. I encased it in red. Click on the `</>Embed` button and you will see something like this.

![Screen shot](/assets/images/posts/embed-powerpoint-embed.png){: .align-center}

Copy out the HTML, although for this to work, you only need the `src` value.  In this example, it is `https://onedrive.live.com/embed?cid=406EE4C95978C038&resid=406EE4C95978C038%2179191&authkey=AFFYuImKsNsScF4&em=2`

That's it from OneDrive.

## Updating Jekyll

Initially, this is going to be a two-part process. It's two-part because I have my *presentations* pages as a separate [layout](https://jekyllrb.com/docs/layouts/){:target="_blank"} in Jekyll. It is built as a presentation layout.

### Setup up the Layout

First I created a [collection](https://jekyllrb.com/docs/collections/){:target="_blank"} for the presentation layout.  Here is the section of my `_config.yml`.

```yml
collections:
  presentations:
    output: true
    permalink: /presentations/:name
```

Then, further down in the `_config.yml` I added a `default` section to handle the pages for the presentations. This is so I don't have to add the `layout` front matter to every presentation.

```yml
# Defaults
defaults:
  # _presentations
  - scope:
      path: ""
      type: presentations
    values:
      layout: presentation
      share: true
      classes : wide
      author_profile: true
```

[Full _config.yml](https://github.com/jguadagno/jguadagno.github.io/blob/master/_config.yml){:target="_blank"}

Next up is creating the layout.  Create a folder in the root of your Jekyll site, I called mine `_layout`.  The underscore is important for Jekyll as it won't 'publish' folders with an underscore. Then in that folder create a file and name it `presentation.html`. ***Note***: This name should match the name in the `values.layout` that is defined in the defaults, without the `.html`

I hide some of the other parts of the HTML so that we can focus on the PowerPoint embedding.

```html
{% raw %}{{ content }}

{% if page.powerPointUrl %}
<h3>Slide Deck</h3>
<iframe src="{{page.powerPointUrl}}" width="610px" height="367px" frameborder="0"></iframe>
{% endif %}{% endraw %}
```

Line 1 is where the content of the presentation is displayed. More on that later.

Line 3 checks to see if there is a page attribute of `powerPointUrl` that is present. To do this, we'll create some [Front Matter](https://jekyllrb.com/docs/front-matter/){:target="_blank"} for our presentation. Again, more on that later.

Line 4 and 5 is where I *embed* the PowerPoint. I recreate the HTML that OneDrive provided.

Line 6 closes the conditional statement of line 1.

***Bonus*** If you look at the [full source](https://github.com/jguadagno/jguadagno.github.io/blob/master/_layouts/presentation.html){:target="_blank"} code, you can embed YouTube videos also.
{:.notice--info}

### Presentation Pages

Now that we have created the layout for the Presentation page, in this example, let's look at a sample presentation.

```yml
---
title: .NET 5 - What is it?
isKeynote: false
isRetired: false
sourceUrl:
powerPointUrl: https://onedrive.live.com/embed?cid=406EE4C95978C038&resid=406EE4C95978C038%2179191&authkey=AFFYuImKsNsScF4&em=2
---
We have the .NET Framework, .NET Standard, .NET Core, ASP.NET, ASP.NET Core ... do not get me started on Classic ASP or other platforms :). Where are we going with .NET? What is .NET 5? What is going to happen to these 'legacy' frameworks? Let us take a look at the past, the present, and the future of .NET. After this talk, you will have a good understanding of where Microsoft is taking the platform and where you can focus your development efforts.
```

Line 6 we provide the Url for the PowerPoint presentation.

You can see a more 'complex' sample by checking out [Typescript for the Microsoft Developer](https://github.com/jguadagno/jguadagno.github.io/blob/master/_presentations/typescript-for-the-microsoft-developer.md){:target="_blank"}

## Want More

You can check out all of the 'source code' for the site on the GitHub [repo](https://github.com/jguadagno/jguadagno.github.io).

If you want to see how I 'dynamically' generate the [presentations]({% link _pages/presentations.md %}) page, checkout [_pages/presentations.md](https://github.com/jguadagno/jguadagno.github.io/blob/master/_pages/presentations.md)
