---
title: Presentations
author: Joseph Guadagno
dsq_thread_id:
  - "3566992649"
permalink: /presentations/
---
If you would like for me to speak at your event please [contact me]({% link _pages/contact.md %}).
{: .notice--info}

To see a list of events that I have spoken at, please visit [Joseph Guadagno's Speaking Engagements]({% link _pages/speaking-engagements.md %})

Below are all of the talks that I have given with links to the slides and any additional resources that I may have.

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