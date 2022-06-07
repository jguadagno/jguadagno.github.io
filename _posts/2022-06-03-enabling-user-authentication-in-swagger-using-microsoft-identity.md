---
title: "Enabling user authentication in Swagger using Microsoft Identity"
header:
    og_image: /assets/images/posts/header/swagger-msal.png
date: 2022-06-03 14:00:00 -0700
categories:
  - Articles
tags:
  - swagger
  - Identity
  - MSAL
  - Managed Identity
  - Entra
---

I've been working on a personal project of mine called "[JosephGuadagno.NET Broadcasting](https://github.com/jguadagno/jjgnet-broadcast){:target="_blank"}. I know a terrible name, but I'll work on a better name when it's ready to be launched. :smile: This application is a web application that allows users to broadcast their content to their followers. One of the components of the application is an API that allows users to create and schedule their content in the application. The application is built using ASP.NET Core, Azure, Swagger, and other [components](https://github.com/jguadagno/jjgnet-broadcast/blob/main/infrastructure-needs.md). I recently secured the application using Microsoft's [MSAL](https://docs.microsoft.com/en-us/azure/active-directory-b2c/msal-overview?WT.mc_id=AZ-MVP-4024623) library. Now, I'm going to show you how to enable user authentication in Swagger using Microsoft Identity.

***Note***: When I started creating this post, Microsoft is/was in the process of renaming Microsoft Identity to [Microsoft Entra](https://www.microsoft.com/en-us/security/business/microsoft-entra). As a result, some of the links in this post might change in the future. :slightly_frowning_face:
{: .notice--info }

## Assumptions

I'm going to assume that you already have an API secured with Microsoft Identity, if not, you can check out a series I put together previously called [Protecting an ASP.NET Core API with Microsoft Identity Platform]({% post_url 2020-06-12-protecting-an-asp-net-core-api-with-microsoft-identity-platform %}).

I'm also going to assume that you already have swagger configured. If not, check out [this](https://docs.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger?view=aspnetcore-6.0&WT.mc_id=AZ-MVP-4024623)

## Configure Swagger to use Microsoft Identity

First step is to add the security requirements, `AddSecurityRequirement`, and security definitions, `AddSecurityDefinition` to the Swagger configuration.

Locate in your application code, typically in the `Program.cs`, the `AddSwaggerGen` method and add the following code:

```csharp
// Enabled OAuth security in Swagger
var scopes = JosephGuadagno.Broadcasting.Domain.Scopes.ToDictionary(settings.ApiScopeUrl);
scopes.Add($"{settings.ApiScopeUrl}user_impersonation", "Access application on user behalf");
c.AddSecurityRequirement(new OpenApiSecurityRequirement() {  
    {  
        new OpenApiSecurityScheme {  
            Reference = new OpenApiReference {  
                Type = ReferenceType.SecurityScheme,  
                Id = "oauth2"  
            },  
            Scheme = "oauth2",  
            Name = "oauth2",  
            In = ParameterLocation.Header  
        },  
        new List <string> ()  
    }  
});   
c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
{
    Type = SecuritySchemeType.OAuth2,
    Flows = new OpenApiOAuthFlows
    {
        Implicit = new OpenApiOAuthFlow()
        {
            AuthorizationUrl = new Uri("https://login.microsoftonline.com/common/oauth2/v2.0/authorize"),
            TokenUrl = new Uri("https://login.microsoftonline.com/common/common/v2.0/token"),
            Scopes = scopes
        }
    }
});
```

You can also view the code [here](https://github.com/jguadagno/jjgnet-broadcast/blob/d9648a049b172cd600dcfb8a5847ff6e852ddbc9/src/JosephGuadagno.Broadcasting.Api/Program.cs#L62-L92).

Most of this code does not need to change except the `scopes` variable (lines 1 and 2) and the `AuthorizationUrl` and `TokenUrl` (lines 25 and 26).

The `scopes` variable is a dictionary that maps the scope name to the scope description. The scope description is used in the swagger UI to describe the scope.  This should be a list of scopes that you want your Swagger UI to have access to.  

***BTW***, this should only been done in a development and/or testing environment.  In most cases, you will not want to enable the Swagger UI in production.
{: .notice--info }

The `AuthorizationUrl` and `TokenUrl` may change depending on the tenant and/or organization type you selected when you created your application.  You can find the correct values on the [Register an Application](https://docs.microsoft.com/en-us/azure/active-directory/develop/quickstart-register-app#register-an-application?WT.mc_id=AZ-MVP-4024623) page.

## Get a Client Secret for Swagger UI

First, we'll need to get client secret for the Swagger UI so that the application can authenticate users to the API. We will need to go to the application in the whichever Azure Active Directory it is registered in.  In this example, I have an application named "*JosephGuadagno.NET Broadcasting (Test) - API*" registered in my *Default Directory*.

Now let's see how to get the client secret.

- Navigate to the [Azure Portal](https://portal.azure.com)
- Navigate to the respective directory. *Default Directory* in this example.
- Click on *App registrations*
- Click the application for the API

You should see something similar to the following:

![Registered App](/assets/images/posts/swagger-msal-registered-app.png)

Next, click on the *Certificates & secrets* menu item. After that, click on the *Client Secrets* tab item, then *+ New client secret*. All highlighted in red in the image below.

![Create client secret](/assets/images/posts/swagger-msal-create-client-secret.png)

In the dialog box that follows, enter the following:

| Field | Description | Value |
| Description | A description of the client | `SwaggerClient` |
| Expires | How long the client secret will be valid for | `6 months` |

- Click *Add*

After it is done creating the client secret, you should see something similar to the following:

![Created client secret](/assets/images/posts/swagger-msal-create-client-secret-created.png)

***NOTE***: Copy the client secret and store it securely. You'll need it for the next step and once this blade closes, you cannot access the client secret again.
{: .notice--info }

## Enable Swagger UI to use Microsoft Identity

Locate in your code the `UseSwaggerUI` method and add the following code:

```csharp
app.UseSwaggerUI(options =>
{
    options.OAuthAppName("Swagger Client");
    options.OAuthClientId("<Your client id>");
    options.OAuthClientSecret("<Your client secret>");
    options.OAuthUseBasicAuthenticationWithAccessCodeGrant();
});
```

Now, you'll need to replace the `<Your client id>` with the client id of the registered application. In the example above it is labeled as *Application (client) ID* and starts with *027edf*.  The `<Your client secret>` is the client secret you copied earlier.

## Testing out the Swagger UI

If everything is configured correctly, once you start your API and navigate to the Swagger UI, you should see something similar to the following:

![Secured Swagger UI](/assets/images/posts/swagger-msal-secured-swagger-ui.png)

Clicking on the *Authorize* button will bring up a page showing you some information about the application, including the name, authorization url, client_id, and scopes being requested.  

![Secured Swagger UI](/assets/images/posts/swagger-msal-available-authorizations.png)

- Select all the permissions that you want to test
- Click the `Authorize` button to start the sign in process.

The Microsoft Identity will redirect you to the authorization url.  Once you are redirected, you will be able to sign in with your Microsoft account. And you will be presented with a page that shows you the permissions that you have selected and allows you to authorize this application to access those permissions.

![Microsoft Authorize UI](/assets/images/posts/swagger-msal-microsoft-authorize-ui.png)

The Swagger UI will let you know that it received the authorization.

![Swagger Authorized Response](/assets/images/posts/swagger-msal-swagger-authorized-response.png)

Now the Swagger UI will look like this:

![Swagger is Authorized](/assets/images/posts/swagger-msal-swagger-is-authorized.png)

## Wrap Up

So with a little work, we can see how easy it is to use the Swagger UI to authenticate users to the API. This is a great way to test out the API and make sure that it is working as expected.

Most of the code here can be just copied and pasted into future projects.  The only thing you would need to do is tweak the scopes and update the client id/secret.

## References

- [Swagger OAuth2 documentation](https://swagger.io/docs/specification/authentication/oauth2)
- [Microsoft Identity - Register an application]({% post_url 2020-08-29-working-with-microsoft-identity-registering-an-application %})
- [Microsoft Identity - Configure Local Development]({% post_url 2020-08-29-working-with-microsoft-identity-configure-local-development %})
- [Microsoft Identity - Assigning a Role]({% post_url 2020-08-29-working-with-microsoft-identity-assigning-a-role %})
