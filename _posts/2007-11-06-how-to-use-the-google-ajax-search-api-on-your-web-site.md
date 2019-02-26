---
title: How to use the Google AJAX Search API on your web site.
date: 2007-11-06T07:04:33+00:00
author: Joseph Guadagno
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

|Property Name|**Property Type**|**Purpose**|**Default Value**|
|--- |--- |--- |--- |
|HideMainContent|boolean|Indicated whether or not the Main Content should be shown while the search results are visible|true|
|SearchControl|google.SearchControl|This is a reference to the google.SearchControl|null|
|WatermarkText|string|This is the text to be displayed as the watermark. The watermark text will be visible if the search input in empty|Search for ...|
|IsInitialized|boolean|Indicates if the MyGSearch is initialized, this value is set after the Initialize function is completed.|false|
|Divs|object|Contains all of the divs that are used for the MyGSearch object|new Object()|
|CSS|object|Contains all of the CSS classes used for the MyGSearch object|new Object()|

#### Divs object

|Property Name|Property Type|Purpose|Default Value|
|--- |--- |--- |--- |
|SearchResults|DOM object (DIV)|This is the DIV tag that the Google API will replace the contents of the search results.|null|
|SearchInputBox|DOM object (INPUT)|This is the INPUT control that the Google API will use to execute searches.|null|
|SearchBranding|DOM object (DIV)|This is the DIV that the Google API will place the required "powered by Google" branding.|null|
|SearchStarting|DOM object (DIV)|This is the DIV tag that will be shown while the searching is happening.|null|
|SearchClose|DOM object (DIV)|This is the DIV tag that will display the "Close Search Results" content. This is used to reset the page back to its normal state.|null|
|MainContent|DOM object (DIV)|This is the DIV of your main content. This will be hidden while searching if the HideMainContent property is true until the ClearResults is called.|null|

#### CSS Object

|Property Name|Property Type|Purpose|Default Value|
|--- |--- |--- |--- |
|Watermark|string|The CSS style to use when the search box input control needs to display the watermark||
|InputBox|string|The CSS style when the search box input control is being edited or not displaying the watermark||

### Methods

#### Initialize

Initializes the all of the properties and google.search object.

|Parameter|Property Type|Purpose|
|--- |--- |--- |
|resultsDiv|DOM object (DOM object)|This is where all of the results will be replaced by the Google API. This parameter will update the Divs.SearchResults property.|
|inputBox|DOM object (INPUT type="text")|This is the text box that the Google API will hook to execute the searches. This parameter will update the Divs.SearchInputBox property.|
|brandingDiv|DOM object (DIV)|This is the div that the Google API will place the required "Powered by Google" branding. This parameter will update the Divs.SearchBranding property.|
|mainDiv|DOM object (DIV)|This is the DIV that contains you main content. This DIV will be hidden while searching if the HideMainContent property is set to _true_. This parameter will update the Divs.MainContent property.|
|startSearchingDiv|DOM object (DIV)|This DIV will be displayed while the Google API is executing the search. It will be hidden when the search is complete. This parameter will update the Divs.StartSearching property.|
|closeDiv|DOM object (DIV)|This DIV will be displayed after the Google API has completed the search. This DIV allows you to provide a mechanism to close the search results, which can be done by calling the _ClearResults_ methods. This parameter will update the Divs.SearchClose property.|


#### ClearResults

This method performs the following:

* Clears the search results
* Hides the Divs.SearchClose DIV
* Calls the onInputBlur method
* Hides the Divs.SearchResults DIV
* Shows the Divs.MainContent DIV

|Parameter|Property Type|Purpose|
|--- |--- |--- |
|none|||

#### Execute

Executes a Google search based on the value specified in the query parameter.

|Parameter|Property Type|Purpose|
|--- |--- |--- |
|query|string|The value to search google for.|

#### onSearchComplete

This method is called by the Google API when the search is complete. This method does the following.

* Hides the SearchStarting DIV
* Shows the SearchResults DIV
* Shows the SearchClose DIV
* Hides or Shows the MainContent DIV based on the value of the _HideMainContent_ property.

|Parameter|Property Type|Purpose|
|--- |--- |--- |
|searchControl|google.searchControl|The Google search control that is calling this method.|
|searcher|google.searcher|The Google searcher that is complete.|

#### onStartSearching

This event is raised by the google.search component. In it we will Hide the Main Content and show the SearchStarting Div

|Parameter|Property Type|Purpose|
|--- |--- |--- |
|searchControl|google.searchControl|The Google search control that is calling this method.|
|searcher|google.searcher|The Google search that has started searching.|
|query|string|The text that is being searched for.|

#### onInputBlur

This mimics the Ajax ASP.NET watermark extender control by changing the CSS class of the input box based on the value of it. This is called when the focus leaves the input box.

|Parameter|Property Type|Purpose|
|--- |--- |--- |
|gSearch|A MyGSearch object|A reference to the myGSearch object that you want to blur.|

#### onInputFocus

This mimics the Ajax ASP.NET watermark extender control by changing the CSS class of the input box based on the value of it. This is called when the input box has focus.

|Parameter|Property Type|Purpose|
|--- |--- |--- |
|gSearch|A MyGSearch object|A reference to the myGSearch object that you want to blur.|

## Using the MyGSearch object

There are two easy steps to using the MyGSearch objects. This, of course, assumes that you have obtained a Google API key from [http://code.google.com/apis/ajaxsearch/signup.html](http://code.google.com/apis/ajaxsearch/signup.html).

### Step 1: Create the HTML content

In order for you to use the MyGSearch control, you must create 5 DIVs and one input box. The five Divs map to the five Divs object properties, SearchResults, SearchBranding, MainContent, SearchStarting, and SearchClose. The input box will be used for the Google API to execute the search. 

The HTML content will exist in two parts, the first the HEAD section.

```html

<img src="data:image/gif;base64,R0lGODlhAQABAIAAAAAAAP///yH5BAEAAAAALAAAAAABAAEAAAIBRAA7"
  data-wp-preserve="%3Cscript%20src%3D%22http%3A%2F%2Fwww.google.com%2Fjsapi%3Fkey%3DYOUR_KEY_HERE%22%20type%3D%22text%2Fjavascript%22%3E%3C%2Fscript%3E"
  data-mce-resize="false"
  data-mce-placeholder="1"
  class="mce-object"
  width="20" height="20" alt="&lt;script&gt;"
  title="&lt;script&gt;" />
<img src="data:image/gif;base64,R0lGODlhAQABAIAAAAAAAP///yH5BAEAAAAALAAAAAABAAEAAAIBRAA7"
  data-wp-preserve="%3Cscript%20src%3D%22MyGSearch.js%22%20type%3D%22text%2Fjavascript%22%3E%3C%2Fscript%3E"
  data-mce-resize="false"
  data-mce-placeholder="1"
  class="mce-object"
  width="20" height="20" alt="&lt;script&gt;"
  title="&lt;script&gt;" />
<img src="data:image/gif;base64,R0lGODlhAQABAIAAAAAAAP///yH5BAEAAAAALAAAAAABAAEAAAIBRAA7"
  data-wp-preserve="%3Cscript%20src%3D%22Util.js%22%20type%3D%22text%2Fjavascript%22%3E%3C%2Fscript%3E"
  data-mce-resize="false"
  data-mce-placeholder="1"
  class="mce-object" width="20" height="20" alt="&lt;script&gt;"
  title="&lt;script&gt;" />
```

Remember to replace YOUR_KEY_HERE with your Google API key. Then in the body of the HTML page you add in the required DIVs and input box.

```html
<div id="divSearchClose">
  <a href="javascript:ClearResults();" id="searchCloseLink">Close Search Results</a>
</div>
<div>
  <input type="text" id="txtSearchInput" />
  <input type="submit" value="Search" id="Search" onClick="Search();"/>
  <input type="submit" value="Clear" id="btnClear" onClick="ClearResults();"/>
</div>
<div id="divGoogleBranding"></div>
<div id="divMainContent">
  This is where your main text goes.  
</div>
<div id="divSearchStarting">
  Searching for data...
</div>
<div id="divSearchResults"></div>
```

When you are done you should have something like this, which is the google.html example file. 

``` html
<HTML>
<head>
  <title>Google AJAX Search API test</title>
  <img src="data:image/gif;base64,R0lGODlhAQABAIAAAAAAAP///yH5BAEAAAAALAAAAAABAAEAAAIBRAA7"
    data-wp-preserve="%3Cscript%20src%3D%22http%3A%2F%2Fwww.google.com%2Fjsapi%3Fkey%3DYOUR_API_KEY%22%20type%3D%22text%2Fjavascript%22%3E%3C%2Fscript%3E"
    data-mce-resize="false"
    data-mce-placeholder="1"
    class="mce-object" width="20" height="20" alt="&lt;script&gt;"
    title="&lt;script&gt;" />
  <script src="Util.js" type="text/javascript" />
  <script src="MyGSearch.js" type="text/javascript" />
  <script src="GoogleSearch.js" type="text/javascript" />

<img src="data:image/gif;base64,R0lGODlhAQABAIAAAAAAAP///yH5BAEAAAAALAAAAAABAAEAAAIBRAA7"
  data-wp-preserve="%3Cstyle%20type%3D%22text%2Fcss%22%3E%0A%09%09.watermark%0A%09%09%7B%0A%09%09%09height%3A22px%3B%0A%09%09%09width%3A150px%3B%0A%09%09%09padding%3A2px%200%200%202px%3B%0A%09%09%09border%3A1px%20solid%20%23BEBEBE%3B%0A%09%09%09background-color%3A%23F0F8FF%3B%0A%09%09%09color%3Agray%3B%0A%09%09%09font-style%3A%20italic%3B%0A%09%09%7D%0A%09%09.search%0A%09%09%7B%0A%09%09%09height%3A22px%3B%0A%09%09%09width%3A150px%3B%0A%09%09%09padding%3A2px%200%200%202px%3B%0A%09%09%09border%3A1px%20solid%20%23BEBEBE%3B%0A%09%09%09background-color%3Awhite%3B%0A%09%09%09color%3Ablack%3B%0A%09%09%7D%0A%09%3C%2Fstyle%3E"
  data-mce-resize="false"
  data-mce-placeholder="1"
  class="mce-object" width="20" height="20" alt="&lt;style&gt;"
  title="&lt;style&gt;" />
</head>
<body>
  Google Ajax Search API Test
  <div id="divSearchClose">
    <a href="javascript:ClearResults();" id="searchCloseLink">
      Close Search Results
    </a>
  </div>
  <div>
    <input type="text" id="txtSearchInput" />
    <input type="submit" value="Search" id="Search" onClick="Search();"/>
    <input type="submit" value="Clear" id="btnClear" onClick="ClearResults();"/>
  </div>
  <div id="divGoogleBranding"></div>
  <div id="divMainContent">
    This is where your main text goes.
  </div>
  <div id="divSearchStarting">Searching for data...</div>
  <div id="divSearchResults"></div>
</body>
</HTML>
```

On line 3, we create a global JavaScript variable to hold a reference to the MyGSearch object. The InitializeMyGSearch function starts on line 9. Line 11 checks to see if the object already exists and is initialized if so exits the function. Line 14 - 21 initialize the MyGSearch object and sets the basic properties of it. Lines 24 - 26, hide the search related divs. Line 28 we get a reference to the input box so that we can add our OnBlur and OnFocus events to the control. Line 34, we call the onInputBlur methods of the MyGSearch to set the watermark. Line 38 loads all of the Google Search APIs. Line 41 calls a Google helper function to call InitializeMyGSearch once the form loads. That's it.

## Samples

Within the ZIP file I included two HTML pages that demonstrate how to use the MyGSearch object. The first sample ([google.html](http://www.josephguadagno.net/test/google.html)) provides the required code for a simple search. The required Google branding div is present as well as the search results, search close, search start and main divs.

The second example ([page404.html](http://www.josephguadagno.net/test/page404.html)) is a page that shows what would be required to use the Google AJAX Search API to query google when a user tries to access a page that does not exist on your server. In addition, this example demonstrates how you can automatically search for some text when the page loads.

``` js
// Add a search for the site search
searcher = new google.search.WebSearch();
// This is the label for the tab
searcher.setUserDefinedLabel("JosephGuadagno.net");
// This restricts the search to just josephguadagno.net
searcher.setSiteRestriction("josephguadagno.net");
```

Here you would change lines 4 and 6 to match whatever domain you want. Line 4 is the label for the tab within the results and line 6 is the domain you want to search.

Other possible modifications include adding additional Google searchers to search other domains or other file types like Images, Video or Blogs. You could also change the Google draw objects to draw the search results in a result set.

# References

* Get your Google API Key: [http://code.google.com/apis/ajaxsearch/signup.html](http://code.google.com/apis/ajaxsearch/signup.html)
* Google AJAX API: [http://code.google.com/apis/ajaxsearch/](http://code.google.com/apis/ajaxsearch/)
* Google AJAX API Documentation: [http://code.google.com/apis/ajaxsearch/documentation/](http://code.google.com/apis/ajaxsearch/documentation/)
* Google AJAX API User Group: [http://groups-beta.google.com/group/Google-AJAX-Search-API](http://groups-beta.google.com/group/Google-AJAX-Search-API)