---
title: Speaking Engagements
permalink: /speaking-engagements/
header:
    og_image: /assets/images/pages/speaking-engagements.png
# strfTime: http://strftime.net/
# liquid date filter: https://shopify.github.io/liquid/filters/date/
---
If you would like for me to speak at your event please [contact me]({% link _pages/contact.md %}).
{: .notice--info}

To see a list of presentations I speak on, please visit [Joseph Guadagno's Presentations]({% link _pages/presentations.md %})

{% assign sortedCurrentEngagements = site.data.engagements | sort: 'eventStart' | where:'isCurrent', 'true' %}
{% assign sortedPastEngagements = site.data.engagements | sort: 'eventStart' | reverse | where:'isCurrent', 'false' %}

## Upcoming Engagements

{% if sortedCurrentEngagements.size > 0 %}
{% for engagement in sortedCurrentEngagements -%}

### Event

[{{ engagement.eventName }}]({{engagement.eventUrl}})
: Taking place in {{ engagement.location}} {% if engagement.timezone %}({{engagement.timezone }}){% endif %} - {{ engagement.eventStart | date: '%B %d, %Y' }} to {{ engagement.eventEnd | date: '%B %d, %Y' }} {% if engagement.inPerson %} and is **{{ engagement.inPerson }}**{% endif %}
{% if engagement.isCanceled- %}
This event has been canceled.
{: .notice--danger}
{% if engagement.comments -%}{{ engagement.comments }}{% endif %}
{% else %}

{% if engagement.presentation.size > 0 -%}

#### Presentations

{% for presentation in engagement.presentation -%}
{% capture presentationTime %}{{ presentation.date | date: "%R" }}{% endcapture %}
[{{presentation.name}}]({{presentation.url}})
{% if presentation.date == "" %}
: The schedule has *not* been released yet.
{% else %}
: Scheduled on {{ presentation.date | date: "%a, %F" }}{% if presentationTime !="00:00" %} at {{presentation.date | date: "%R" }} ({{engagement.timezone}}){% endif %} {% if presentation.room.size > 0 %} in room **{{presentation.room }}** {% endif %}
{% endif %}
{% if presentation.isWorkshop -%}***Workshop***{% endif %}
{% if presentation.comments.size > 0 -%}
:  {{ presentation.comments}}
{% endif %}
{% if presentation.isCanceled -%}
This session has been canceled.
{: .notice--danger}
{% endif %}
{% endfor %}
{% endif %}
{% if engagement.comments -%}{{ engagement.comments }}{% endif %}
{% endif %}
{% endfor %}
{% else %}
I'm currently not scheduled to speak anywhere!
{: .notice--info }
{% endif %}

## Previous Engagements

|Event|Location|Date|Presentations|
|--- |--- |--- |--- |
{% for engagement in sortedPastEngagements -%}
|[{{engagement.eventName}}]({{engagement.eventUrl}}){:target="_blank"}|{{engagement.location}}|{{engagement.eventStart | date: "%F" }}|{% for presentation in engagement.presentation -%}- [{{presentation.name}}]({{presentation.url}})<br />{% endfor %}|
{% endfor %}
