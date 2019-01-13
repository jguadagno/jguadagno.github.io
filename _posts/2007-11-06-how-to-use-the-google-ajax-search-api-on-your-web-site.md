---
id: 1091
title: How to use the Google AJAX Search API on your web site.
date: 2007-11-06T07:04:33+00:00
author: Joseph Guadagno
layout: post
guid: http://www.josephguadagno.net/post.aspx?id=38589012-f1d6-49c6-b815-76ffe0f3e667
permalink: /2007/11/06/how-to-use-the-google-ajax-search-api-on-your-web-site/
dsq_thread_id:
  - "3618310716"
categories:
  - Articles
  - Web
tags:
  - Google
---
## The Google AJAX Search API

The [Google AJAX Search API](http://code.google.com/apis/ajaxsearch/) is a Javascript library that allows you to embed Google Search in your web pages and other web applications. To use the API, you will first need to sign up for an [API key](http://code.google.com/apis/ajaxsearch/signup.html). The Google AJAX Search API provides simple web objects that perform inline searches over a number of Google services (Web Search, Local Search, Video Search, Blog Search, News Search, Book Search, and Image Search). If your web page is designed to help users create content (e.g. message boards, blogs, etc.), the API is designed to support these activities by allowing them to copy search results directly into their messages.

## If so, then why wrap it?

I wrapped the Google API up into a separate component so that I can use the Google API in more than one web page without having to recreate all of the objects over and over again. Most of the setup of the Google API is repetitive across multiple instances of it. The way the Google API was wrapped should all others to use the object with only a small modification. See the Samples section below.

## The MyGSearch object

Download the MyGSearch JavaScript and HTML files [here](http://www.josephguadagno.net/documents/MyGSearch.zip).

### Properties

<table class="table table-striped table-bordered">

<thead>

<tr>

<th>Property Name</th>

<th>**Property Type**</th>

<th>**Purpose**</th>

<th>**Default Value**</th>

</tr>

</thead>

<tbody>

<tr>

<td>HideMainContent</td>

<td>boolean</td>

<td>Indicated whether or not the Main Content should be shown while the search results are visible</td>

<td>true</td>

</tr>

<tr>

<td>SearchControl</td>

<td>google.SearchControl</td>

<td>This is a reference to the google.SearchControl</td>

<td>null</td>

</tr>

<tr>

<td>WatermarkText</td>

<td>string</td>

<td>This is the text to be displayed as the watermark. The watermark text will be visible if the search input in empty</td>

<td>Search for ...</td>

</tr>

<tr>

<td>IsInitialized</td>

<td>boolean</td>

<td>Indicates if the MyGSearch is initialized, this value is set after the Initialize function is completed.</td>

<td>false</td>

</tr>

<tr>

<td>Divs</td>

<td>object</td>

<td>Contains all of the divs that are used for the MyGSearch object</td>

<td>new Object()</td>

</tr>

<tr>

<td>CSS</td>

<td>object</td>

<td>Contains all of the CSS classes used for the MyGSearch object</td>

<td>new Object()</td>

</tr>

</tbody>

</table>

#### Divs object

<table class="table table-striped table-bordered">

<thead>

<tr>

<th>Property Name</th>

<th>Property Type</th>

<th>Purpose</th>

<th>Default Value</th>

</tr>

</thead>

<tbody>

<tr>

<td>SearchResults</td>

<td>DOM object (DIV)</td>

<td>This is the DIV tag that the Google API will replace the contents of the search results.</td>

<td>null</td>

</tr>

<tr>

<td>SearchInputBox</td>

<td>DOM object (INPUT)</td>

<td>This is the INPUT control that the Google API will use to execute searches.</td>

<td>null</td>

</tr>

<tr>

<td>SearchBranding</td>

<td>DOM object (DIV)</td>

<td>This is the DIV that the Google API will place the required "powered by Google" branding.</td>

<td>null</td>

</tr>

<tr>

<td>SearchStarting</td>

<td>DOM object (DIV)</td>

<td>This is the DIV tag that will be shown while the searching is happening.</td>

<td>null</td>

</tr>

<tr>

<td>SearchClose</td>

<td>DOM object (DIV)</td>

<td>This is the DIV tag that will display the "Close Search Results" content. This is used to reset the page back to its normal state.</td>

<td>null</td>

</tr>

<tr>

<td>MainContent</td>

<td>DOM object (DIV)</td>

<td>This is the DIV of your main content. This will be hidden while searching if the HideMainContent property is true until the ClearResults is called.</td>

<td>null</td>

</tr>

</tbody>

</table>

#### CSS Object

<table class="table table-striped table-bordered">

<thead>

<tr>

<th>Property Name</th>

<th>Property Type</th>

<th>Purpose</th>

<th>Default Value</th>

</tr>

<tr>

<td>Watermark</td>

<td>string</td>

<td>The CSS style to use when the search box input control needs to display the watermark</td>

<td>""</td>

</tr>

<tr>

<td>InputBox</td>

<td>string</td>

<td>The CSS style when the search box input control is being edited or not displaying the watermark</td>

<td>""</td>

</tr>

</thead>

</table>

### Methods

#### Initialize

Initializes the all of the properties and google.search object.

<table class="table table-striped table-bordered">

<tbody>

<tr>

<th>Parameter</th>

<th>Property Type</th>

<th>Purpose</th>

</tr>

<tr>

<td>resultsDiv</td>

<td>DOM object (DOM object)</td>

<td>This is where all of the results will be replaced by the Google API. This parameter will update the Divs.SearchResults property.</td>

</tr>

<tr>

<td>inputBox</td>

<td>DOM object (INPUT type="text")</td>

<td>This is the text box that the Google API will hook to execute the searches. This parameter will update the Divs.SearchInputBox property.</td>

</tr>

<tr>

<td>brandingDiv</td>

<td>DOM object (DIV)</td>

<td>This is the div that the Google API will place the required "Powered by Google" branding. This parameter will update the Divs.SearchBranding property.</td>

</tr>

<tr>

<td>mainDiv</td>

<td>DOM object (DIV)</td>

<td>This is the DIV that contains you main content. This DIV will be hidden while searching if the HideMainContent property is set to _true_. This parameter will update the Divs.MainContent property.</td>

</tr>

<tr>

<td>startSearchingDiv</td>

<td>DOM object (DIV)</td>

<td>This DIV will be displayed while the Google API is executing the search. It will be hidden when the search is complete. This parameter will update the Divs.StartSearching property.</td>

</tr>

<tr>

<td>closeDiv</td>

<td>DOM object (DIV)</td>

<td>This DIV will be displayed after the Google API has completed the search. This DIV allows you to provide a mechanism to close the search results, which can be done by calling the _ClearResults_ methods. This parameter will update the Divs.SearchClose property.</td>

</tr>

</tbody>

</table>

#### ClearResults

This method performs the following:

*   Clears the search results
*   Hides the Divs.SearchClose DIV
*   Calls the onInputBlur method
*   Hides the Divs.SearchResults DIV
*   Shows the Divs.MainContent DIV

<table class="table table-striped table-bordered">

<tbody>

<tr>

<th>Parameter</th>

<th>Property Type</th>

<th>Purpose</th>

</tr>

<tr>

<td>none</td>

<td></td>

<td></td>

</tr>

</tbody>

</table>

#### Execute

Executes a Google search based on the value specified in the query parameter.

<table class="table table-striped table-bordered">

<tbody>

<tr>

<th>Parameter</th>

<th>Property Type</th>

<th>Purpose</th>

</tr>

<tr>

<td>query</td>

<td>string</td>

<td>The value to search google for.</td>

</tr>

</tbody>

</table>

#### onSearchComplete

This method is called by the Google API when the search is complete. This method does the following.

* Hides the SearchStarting DIV
* Shows the SearchResults DIV
* Shows the SearchClose DIV
* Hides or Shows the MainContent DIV based on the value of the _HideMainContent_ property.

<table class="table table-striped table-bordered">

<tbody>

<tr>

<th>Parameter</th>

<th>Property Type</th>

<th>Purpose</th>

</tr>

<tr>

<td>searchControl</td>

<td>google.searchControl</td>

<td>The Google search control that is calling this method.</td>

</tr>

<tr>

<td>searcher</td>

<td>google.searcher</td>

<td>The Google searcher that is complete.</td>

</tr>

</tbody>

</table>

#### onStartSearching

This event is raised by the google.search component. In it we will Hide the Main Content and show the SearchStarting Div

<table class="table table-striped table-bordered">

<tbody>

<tr>

<th>Parameter</th>

<th>Property Type</th>

<th>Purpose</th>

</tr>

<tr>

<td>searchControl</td>

<td>google.searchControl</td>

<td>The Google search control that is calling this method.</td>

</tr>

<tr>

<td>searcher</td>

<td>google.searcher</td>

<td>The Google search that has started searching.</td>

</tr>

<tr>

<td>query</td>

<td>string</td>

<td>The text that is being searched for.</td>

</tr>

</tbody>

</table>

#### onInputBlur

This mimics the Ajax ASP.NET watermark extender control by changing the CSS class of the input box based on the value of it. This is called when the focus leaves the input box.

<table class="table table-striped table-bordered">

<tbody>

<tr>

<th>Parameter</th>

<th>Property Type</th>

<th>Purpose</th>

</tr>

<tr>

<td>gSearch</td>

<td>A MyGSearch object</td>

<td>A reference to the myGSearch object that you want to blur.</td>

</tr>

</tbody>

</table>

#### onInputFocus

This mimics the Ajax ASP.NET watermark extender control by changing the CSS class of the input box based on the value of it. This is called when the input box has focus.

<table class="table table-striped table-bordered">

<tbody>

<tr>

<th>Parameter</th>

<th>Property Type</th>

<th>Purpose</th>

</tr>

<tr>

<td>gSearch</td>

<td>A MyGSearch object</td>

<td>A reference to the myGSearch object that you want to blur.</td>

</tr>

</tbody>

</table>

## Using the MyGSearch object

There are two easy steps to using the MyGSearch objects. This, of course, assumes that you have obtained a Google API key from [http://code.google.com/apis/ajaxsearch/signup.html](http://code.google.com/apis/ajaxsearch/signup.html).

### Step 1: Create the HTML content

In order for you to use the MyGSearch control, you must create 5 DIVs and one input box. The five Divs map to the five Divs object properties, SearchResults, SearchBranding, MainContent, SearchStarting, and SearchClose. The input box will be used for the Google API to execute the search. 

The HTML content will exist in two parts, the first the HEAD section.

{% gist jguadagno/3856a4b511b85fd173f7f174aed1b188 %}

Remember to replace YOUR_KEY_HERE with your Google API key. Then in the body of the HTML page you add in the required DIVs and input box.

{% gist jguadagno/036287e71e259729275fee6029248fe5 %}

When you are done you should have something like this, which is the google.html example file. 

{% gist jguadagno/c986a68f4ea546edf80503f17fc14afc %}

On line 3, we create a global JavaScript variable to hold a reference to the MyGSearch object. The InitializeMyGSearch function starts on line 9. Line 11 checks to see if the object already exists and is initialized if so exits the function. Line 14 - 21 initialize the MyGSearch object and sets the basic properties of it. Lines 24 - 26, hide the search related divs. Line 28 we get a reference to the input box so that we can add our OnBlur and OnFocus events to the control. Line 34, we call the onInputBlur methods of the MyGSearch to set the watermark. Line 38 loads all of the Google Search APIs. Line 41 calls a Google helper function to call InitializeMyGSearch once the form loads. That's it.

## Samples

Within the ZIP file I included two HTML pages that demonstrate how to use the MyGSearch object. The first sample ([google.html](http://www.josephguadagno.net/test/google.html)) provides the required code for a simple search. The required Google branding div is present as well as the search results, search close, search start and main divs.

The second example ([page404.html](http://www.josephguadagno.net/test/page404.html)) is a page that shows what would be required to use the Google AJAX Search API to query google when a user tries to access a page that does not exist on your server. In addition, this example demonstrates how you can automatically search for some text when the page loads. 

{% gist jguadagno/f85dd88c16825be63e165158a3e1fac3 %}

Here you would change lines 4 and 6 to match whatever domain you want. Line 4 is the label for the tab within the results and line 6 is the domain you want to search. 

Other possible modifications include adding additional Google searchers to search other domains or other file types like Images, Video or Blogs. You could also change the Google draw objects to draw the search results in a result set.

# References

* Get your Google API Key: [http://code.google.com/apis/ajaxsearch/signup.html](http://code.google.com/apis/ajaxsearch/signup.html)
* Google AJAX API: [http://code.google.com/apis/ajaxsearch/](http://code.google.com/apis/ajaxsearch/)
* Google AJAX API Documentation: [http://code.google.com/apis/ajaxsearch/documentation/](http://code.google.com/apis/ajaxsearch/documentation/)
* Google AJAX API User Group: [http://groups-beta.google.com/group/Google-AJAX-Search-API](http://groups-beta.google.com/group/Google-AJAX-Search-API)