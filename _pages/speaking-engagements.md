---
title: Speaking Engagements
permalink: /speaking-engagements/
---
If you would like for me to speak at your event please [contact me]({% link _pages/contact.md %}).
{: .notice--info}

To see a list of presentations I speak on, please visit [Joseph Guadagno's Presentations]({% link _pages/presentations.md %})

{% assign sortedCurrentEngagements = site.data.engagements | sort: 'presentation.date' | where:'isCurrent', 'true' %}
{% assign sortedPastEngagements = site.data.engagements | sort: 'presentation.date' | reverse | where:'isCurrent', 'false' %}

## Upcoming Engagements

{% if sortedCurrentEngagements.size > 0 %}
|Event|Location|Presentation|Date|Comments|
|--- |--- |--- |--- |--- |
{% for engagement in sortedCurrentEngagements -%}
|[{{engagement.eventName}}]({{engagement.eventUrl}}){:target="_blank"}|{{engagement.location}}|[{{engagement.presentation.name}}]({{engagement.presentation.url}})|{{engagement.presentation.date}}|{{engagement.presentation.comments }}|
{% endfor %}
{% else %}
I'm currently not scheduled to speak anywhere!
{: .notice--info }
{% endif %}

## Previous Engagements

|Event|Location|Presentation|Date|Comments|
|--- |--- |--- |--- |--- |
{% for engagement in sortedPastEngagements -%}
|[{{engagement.eventName}}]({{engagement.eventUrl}}){:target="_blank"}|{{engagement.location}}|[{{engagement.presentation.name}}]({{engagement.presentation.url}})|{{engagement.presentation.date}}|{{engagement.presentation.comments }}|
{% endfor %}
