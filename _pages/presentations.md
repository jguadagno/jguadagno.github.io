---
title: Presentations
permalink: /presentations/
header:
    og_image: /assets/images/pages/presentations.png
---
If you would like for me to speak at your event, please [contact me]({% link _pages/contact.md %}).
{: .notice--info}

To see a list of events that I have spoken at, please visit [Joseph Guadagno's Speaking Engagements]({% link _pages/speaking-engagements.md %})

Below are all of the talks that I have given. You'll find the content level of talks on each talk page, links to slides, source code, videos (if any), and any additional resources for this talk.

{% assign presentations = site.presentations | where:'isRetired', 'false' %}
{% for presentation in presentations -%}
- [{{presentation.title}}]({{presentation.url}})
{% endfor %}

## Retired Presentations

These presentations are retired and no longer given.  If you wish to have me present them, please reach out to me directly at [contact me]({% link _pages/contact.md %}).
{: .notice--danger}

{% assign presentations = site.presentations | where:'isRetired', 'true' %}
{% for presentation in presentations -%}
- [{{presentation.title}}]({{presentation.url}})
{% endfor %}