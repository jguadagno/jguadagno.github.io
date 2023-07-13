---
title: "Dynamic Blog Posts with Jekyll"
date: 2019-08-12 06:30:00 -0700
categories:
  - Articles
tags:
  - Jekyll
---

Well "dynamic-ish". The [Speaking Engagements]({% link _pages/speaking-engagements.md %}) page on this site uses [data files](https://jekyllrb.com/docs/datafiles/){:target="_blank"} to generate the list of upcoming and previous speaking engagements. Which generates the content shown here.

![image-center](/assets/images/posts/data-files-speaking-engagements.png "Speaking Engagements"){: .align-center}

Setting up the data files and corresponding markdown files are pretty easy.  First, let's get started with the data file. Jekyll supports loading data from [YAML](https://yaml.org){:target="_blank"}, [JSON](https://www.json.org){:target="_blank"}, [CSV](https://en.wikipedia.org/wiki/Comma-separated_values){:target="_blank"}, and [TSV](https://en.wikipedia.org/wiki/Tab-separated_values){:target="_blank"} files located in the `_data` directory. **Note**, if you use a CSV or TSV files, there must be a header row in the file.  I used a Json file for this examples and named it `engagements.json`. You can view the full [engagements.json](https://github.com/jguadagno/jguadagno.github.io/blob/master/_data/engagements.json){:target="_blank"} on Github. Below is a excerpt of the file for sake a brevity.

### Engagements.json

```json
[
    {
        "eventName" : "Southeast Valley .NET User Group",
        "eventUrl" : "https://www.meetup.com/sevdnug/events/263472581",
        "location" : "Chandler, AZ ",
        "presentation" :
        {
            "name" : "Look into your Application with Azure Application Insights",
            "url": "/presentations/look-into-your-application-with-application-insights",
            "date" : "2019-08-22",
            "comments": ""
        },
        "isCurrent" : true
    },
    {
        "eventName" : "Northwest Valley .NET User Group",
        "eventUrl" : "https://www.meetup.com/NWVDNUG/events/263472395/",
        "location" : "Glendale, AZ ",
        "presentation" :
        {
            "name" : "Look into your Application with Azure Application Insights",
            "url": "/presentations/look-into-your-application-with-application-insights",
            "date" : "2019-08-21",
            "comments": ""
        },
        "isCurrent" : true
    }
]
```

There is nothing special with this json file. The only "*requirement*", is that the json file is an array of objects. All of the properties can be in the root object (lines 2-14). However, I chose to break up the object a bit more and add a child property of the engagement called `presentation`, which has 4 properties: `name`, `url`, `date`, and `comments`.

Let's take a look at how we use this data file to make the [Speaking Engagements]({% link _pages/speaking-engagements.md %}) page "dynamic". While technically it is not dynamic, I only need to edit and commit the file and Jekyll will generate a new page.

### Speaking-Engagements.md

Once you create the data file and place it in the `_data` directory, Jekyll makes it available on the `site.data` tag in your site markdown.  Since our file was named `engagements` we can access it like so, `site.data.engagements`. This will be an array of `engagement` objects.

Since I wanted to manipulate the lists of engagements, separate current engagements from past engagements and do some sorting, I created a variable, `sortedCurrentEngagements`.  This variable will hold a sorted, by `presentation.date`, list of engagements where the `isCurrent` property is `true`. The syntax for the assign is:

```markdown
{% raw %}
{% assign sortedCurrentEngagements = site.data.engagements | sort: 'presentation.date' | where:'isCurrent', 'true' %}
{% endraw %}
```

The next step is to iterate/loop through all of the engagements in the `sortedCurrentEngagements`.  This is where the flexibility of Jekyll and the [Liquid](https://shopify.github.io/liquid/){:target="_blank"} template engine come to play. We'll use the [Iteration](https://shopify.github.io/liquid/tags/iteration/){:target="_blank"} tag within the Liquid templates to iterate through the engagements.

```markdown
{% raw %}
{% for engagement in sortedCurrentEngagements -%}
|[{{engagement.eventName}}]({{engagement.eventUrl}}){:target="_blank"}|{{engagement.location}}|[{{engagement.presentation.name}}]({{engagement.presentation.url}})|{{engagement.presentation.date}}|{{engagement.presentation.comments }}|
{% endfor %}
{% endraw %}
```

The code is a little messy because I have it inside a table. Line 1 and 3, performs the iteration. Line 2 is where we write out all of the data want to. As you can see, to access any of the properties, you need wrap them in double curly braces {% raw %}`{{}}` {% endraw %}

For the previous engagements, we just create another variable, similar to `sortedCurrentEngagements` but set `isCurrent` to `false`.

```markdown
{% raw %}
{% assign sortedPastEngagements = site.data.engagements | sort: 'presentation.date' | reverse | where:'isCurrent', 'false' %}
{% endraw %}
```

You can see the entire [speaking-engagements.md](https://github.com/jguadagno/jguadagno.github.io/blob/master/_pages/speaking-engagements.md){:target="_blank"} file on Github.

For more info on this, check out the [data files](https://jekyllrb.com/docs/datafiles/){:target="_blank"} documentation on the [Jekyll](https://jekyllrb.com/){:target="_blank"} [docs](https://jekyllrb.com/docs/){:target="_blank"} site.
