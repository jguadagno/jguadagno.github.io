// Call the functions that should not be ran until the user has accepted cookies.

// If the user is not viewing a post, the Post Ad function will not be defined, so only call it if it is defined.
if (typeof(RunGoogleAdsensePostAdvertisementJavaScript) === typeof(Function))
{
	RunGoogleAdsensePostAdvertisementJavaScript()
}

RunGoogleAdsenseFooterAdvertisementJavaScript()
RunMsClarityJavaScript()

// Google Analytics are not included when running locally/debugging, so to avoid an error only call this function if it is defined.
if (typeof (RunGoogleAdsensePostAdvertisementJavaScript) === typeof(Function))
{
	RunGoogleAnalyticsJavaScript();
}
