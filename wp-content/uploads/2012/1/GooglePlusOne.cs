using System.Web;
using System.Web.UI.HtmlControls;
using BlogEngine.Core;
using BlogEngine.Core.Web.Controls;
using BlogEngine.Core.Web.Extensions;

/// <summary>
/// Google Plus One extension for BlogEngine.NET
/// </summary>
[Extension(
	"Adds the Google Plus One to your blog Posts", 
	"1.0", 
	"<a href=\"http://www.josephguadagno.net/\">Joseph Guadagno</a>",
	800)]
public class GooglePlusOne
{

static protected ExtensionSettings ExtensionSettings;
private const string ExtensionName = "GooglePlusOne";
public GooglePlusOne()
{
  InitializeSettings();
  Post.Serving += ServingHandler;
  Page.Serving += ServingHandler;
}

void ServingHandler(object sender, ServingEventArgs e)
{
  if (!ExtensionManager.ExtensionEnabled(ExtensionName)) return;
  if (e.Location == ServingLocation.Feed) return;

  HttpContext context = HttpContext.Current;
  if (context != null)
  {
    System.Web.UI.Page page = context.CurrentHandler as System.Web.UI.Page;
    if (page != null)
    {
      ScriptInject(page);
    }
  }
  var post = sender as Post;
  if (post != null)
      e.Body += GetButton(post.AbsoluteLink.AbsoluteUri);
}

private void InitializeSettings()
{
  var settings = new ExtensionSettings(ExtensionName)
  	{Help = "Adds Google Plus One to your Post Home page and Post page", IsScalar = true};

  settings.AddParameter("size", "Size", 20, false, false, ParameterType.ListBox);
  settings.AddValue("size", new[] { "standard", "small", "medium", "tall" }, "standard");
  ExtensionSettings = ExtensionManager.InitSettings(ExtensionName, settings);
}

public static void ScriptInject(System.Web.UI.Page page)
{
  HtmlGenericControl googleScript = new HtmlGenericControl("script");
  googleScript.Attributes["type"] = "text/javascript";
  googleScript.Attributes["src"] = "https://apis.google.com/js/plusone.js";
  page.Header.Controls.Add(googleScript);
}

public static string GetButton(string url)
{
  string size = ExtensionSettings.GetSingleValue("size") ?? "standard";
  string googlebutton = string.Format("<g:plusone size=\"{0}\" href=\"{1}\"></g:plusone>", size, url);
  return googlebutton;
}
}