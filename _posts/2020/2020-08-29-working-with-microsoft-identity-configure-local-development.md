---
title: "Working with Microsoft Identity - Configure Local Development"
header:
    og_image: /assets/images/posts/header/msal-configure-local-development.png
categories:
  - Articles
tags:
  - Azure
  - Identity
  - MSAL
  - Managed Identity
  - Entra
---
Securing our applications and data is critical in this day and age.  I've been working a lot with the new [Microsoft identity platform](https://docs.microsoft.com/en-us/azure/active-directory/develop/?WT.mc_id=AZ-MVP-4024623){:target="_blank"}  (MSAL) library, so I decided to create a series of blog posts around working with it.

* [Register an application]({% link _posts/2020/2020-08-29-working-with-microsoft-identity-registering-an-application.md %}).
* Configure Local Development (this post)
* [Assigning a Role]({% link _posts/2020/2020-08-29-working-with-microsoft-identity-assigning-a-role.md %})

## Using Environment Variable

Your setup may vary depending on the IDE you are using, Visual Studio, JetBrains Rider, IntelliJ, Visual Studio Code, etc.  I'm going to show you how to set up your *Environment* variables to use the `DefaultAzureCredentials`.  For this, you will need the Application (Client) ID, Directory (Tenant) ID, and Client Secret (password) obtained from registering your application with the Azure portal.  If you need to register an application, check out the post [Register an application]({% link _posts/2020/2020-08-29-working-with-microsoft-identity-registering-an-application.md %}).

### Windows

* [Open](https://www.techjunkie.com/environment-variables-windows-10/){:target="_blank"} up your environment variables.
* Enter the following environment variables.

| --- | --- | --- |
| Name | Corresponding Value | Value |
| `AZURE_CLIENT_ID` | The Azure application/client id | `6c04f5c5-97f7-486d-bbb2-eeeeeeeeee` |
| `AZURE_CLIENT_SECRET`| The client secret/password | `QPxyBvw3.UE8Bw6AJAt63pWx~BB40deded` |
| `AZURE_TENANT_ID` | The directory/tenant id | `bee716cf-fa94-4610-b72e-5df4bf5a9999` |

***NOTE*** These are not real values! :smile:
{: .notice--warning}

***NOTE*** Depending on your IDE, Terminal, etc, you may need to restart it after updating these values.
{: .notice--info}

### Mac

The procedure may vary depending on your environment/shell. For ZSH/bash, add the following your profile.

```bash
export AZURE_CLIENT_ID=6c04f5c5-97f7-486d-bbb2-eeeeeeeeee
export AZURE_CLIENT_SECRET=QPxyBvw3.UE8Bw6AJAt63pWx~BB40deded
export AZURE_TENANT_ID=bee716cf-fa94-4610-b72e-5df4bf5a9999
```

## Next Steps

Any questions, please feel free to send me and email or tweet.  Like what you see, watch my [stream](https://jjg.me/stream){:target="_blank"} and/or subscribe to my [YouTube channel](https://jjg.me/youtube){:target="_blank"}.

### Resources

* Microsoft identity platform [documentation](https://docs.microsoft.com/en-us/azure/active-directory/develop/?WT.mc_id=AZ-MVP-4024623){:target="_blank"}
* Follow the 425show on [Twitch](https://www.twitch.tv/425show){:target="_blank"}
