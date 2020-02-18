---
title: 'Using Ajax Professional'
date: 2007-11-23T01:00:00+00:00
author: Joseph Guadagno
permalink: /assets/downloads/using_ajax_professional.htm
categories:
  - Articles
---

## Enabling the Website

### Web.Config

Add into the web config the required httpHandlers within the `<system.web>` section

``` xml
<httpHandlers>
  <add verb="POST,GET">
    path="ajaxpro/*.ashx" type="AjaxPro.AjaxHandlerFactory, AjaxPro"/>
</httpHandlers>
```

### Visual Studio Solution

Add a reference to the AjaxPro library

## Enabling the Page

### CS File

Register the page for use with the AjaxPro library. This creates the JavaScript files on the server for the class and methods.

The syntax is

```vb
' VB
AjaxPro.Utility.RegisterTypeForAjax(GetType(Namespace.ClassName))
```

Or

```csharp
// C#
AjaxPro.Utility.RegisterTypeForAjax(typeof(Namespace.ClassName))
```

#### Sample

##### C# Sample

```csharp
private void Page_Load(object sender, System.EventArgs e)
{
  // Put user code to initialize the page here
  AjaxPro.Utility.RegisterTypeForAjax(typeof(AjaxVB.WebForm1));
}
```

##### Visual Basic Sample.

```vb
Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  'Put user code to initialize the page here
  AjaxPro.Utility.RegisterTypeForAjax(GetType(AjaxVB.WebForm1))
End Sub
```

### Enabling a Method

Once you have Ajax-enabled the page and website, Ajax-enabling a method is quite simple. The only item that is required is to add the `AjaxMethod` attribute to the class.

#### C# File

```csharp
[AjaxPro.AjaxMethod()]
public string GetServerTime()
{
  return DateTime.Now.ToString();
}
```

#### VB File

```vb
<AjaxPro.AjaxMethod()> _
Public Function GetServerTime() As String
  Return DateTime.Now.ToString()
End Function
```

#### ASPX File

Within the HTML designer, add the following line to include the JavaScript library to the page. It is recommended to name the JavaScript file, the same as the web page name.

```html
<script language="javascript" src="WebForm1.js"></script>
```

#### Javascript file

The JavaScript file contains the calls to the server.  In order to call the ASP.NET method, you follow the following syntax:

```javascript
namespace.classname.methodname (params, callback_function)
```

The params can be any number of parameters but should match the signature of the ASP.NET method. **Please note** the current version of AjaxPro.Net library does not support overloaded methods.

The `callback_function` is optional but stronger recommended.

```javascript
function GetServerTime()
{
  AjaxVB.WebForm1.GetServerTime(GetServerTime_Callback)
}

function GetServerTime_Callback(response)
{
  Label1.innerHTML = response.value;
}
```

When a callback function is used, which is strongly recommended, a response object will be passed as the only parameter.  The response object contained two (2) objects

|---|---|
| Value | The returned value from the ASP.NET method |
| Error | If not null, an object containing error information |

Error Object

|---|---|
| Message | The message text, `Err.ToString()` |
| Type | The type of Exception |
| Stack | A full stack trace |
| Source | The page source that generated the error. |

## Recommendations

Use a JavaScript file. This will enable you to Debug any problems within the Visual Studio IDE.

Use the callback function

```javascript
function GetServerTime_Callback(response)
{
  if (response.error != null)
  {
    // Display the error
    return;
  }
  var saveResults = response.value;

  if (saveResults != "")
  {
    // Nothing was return
  }
  
  // Work with the response
  Label1.innerHTML = saveResults;
}
```

## Samples

### Populating a Drop Down List, SELECT element

```javascript
function GetTeamList(response)
{
  var teamsList = document.getElementById("ctrlContent__ctl0_ucProfile_dropTeam");

  //if the server side code threw an exception
  if (response.error != null)
  {
    alert("A problem occurred in Profile:LoadTeams\n" + response.error.Message); //we should probably do better than this
    return;
  }

  var teams = response.value;

  //if the response wasn't what we expected
  if (teams == null || typeof(teams) != "object")
  {
    alert('A problem occurred in Profile:LoadTeams');
    return;
  }

  teamsList.options.length = 0; //reset the teams dropdown

  //note that this is JavaScript casing and the L in length is lowercase for arrays
  teamsList.options[teamsList.options.length] = new Option("", "");

  for (var i = 0; i < teams.Rows.length; ++i)
  {
    teamsList.options[teamsList.options.length] = new Option(teams.Rows[i].team_name, teams.Rows[i].team);
    //teamsList.options[teamsList.options.length] = new Option(teams[i].team_name, teams[i].team);
  }
}
```

The example above assumes that the ASP.NET method returns a `DataTable`. If a `DataSet` is returned, preface the `.Rows` with `.Tables[0]`.

### Sending a DataSet to the Server

```csharp
// Create the DataSet
var ds = new Ajax.Web.DataSet();

// Create a DataTable
Var dt = new Ajax.Web.DataTable();

// Add the columns
dt.addColumn("NodeId", "System.Int");
dt.addColumn("ParentId", "System.Int");
dt.addColumn("MenuText", "System.String");
dt.addColumn("StatusText", "System.String");
dt.addColumn("NavigateUrl", "System.String");
dt.addColumn("LookId", "System.String");
dt.addColumn("LeftImage", "System.String");
dt.addColumn("LeftHoverImage", "System.String");
dt.addColumn("RightImage", "System.String");
dt.addColumn("RightHoverImage", "System.String");

// Create an populate the row
var drToAdd = new Object();
drToAdd.NodeId = document.getElementById("txtNodeId").value;
drToAdd.ParentId = document.getElementById("txtParentId").value;
drToAdd.MenuText = document.getElementById("txtMenuText").value;
drToAdd.StatusText = document.getElementById("txtStatusText").value;
drToAdd.NavigateUrl = document.getElementById("txtNavigateUrl").value;
drToAdd.LookId = document.getElementById("txtLookId").value;
drToAdd.LeftImage = document.getElementById("txtLeftImage").value;
drToAdd.LeftHoverImage = document.getElementById("txtLeftHoverImage").value;
drToAdd.RightImage = document.getElementById("txtRightImage").value;
drToAdd.RightHoverImage = document.getElementById("txtRightHoverImage").value;

// Add the rows
dt.addRow(drToAdd);

// Add the table to the DataTable
ds.addTable(dt);
```
