---
title: Protecting a .NET API with Microsoft Identity Platform (Microsoft Entra)
isKeynote: false
isRetired: false
sourceUrl:
powerPointUrl: https://1drv.ms/p/c/406ee4c95978c038/UQQ4wHhZyeRuIIBAS4ABAAAAANy9NNDUfJOXK9c
sessionizeUrl: protecting-a-.net-api-with-microsoft-identity-plat/33628
level: 300
redirect_from:
    - /presentations/protecting-a-net-core-api-with-microsoft-identity-platform
links:
    - title: Microsoft identity platform
      url: https://learn.microsoft.com/en-us/entra/identity-platform/p/?WT.mc_id=AZ-MVP-4024623
    - title: Identity and access management (IAM) fundamental concepts
      url: https://learn.microsoft.com/en-us/entra/fundamentals/identity-fundamental-concepts/?WT.mc_id=AZ-MVP-4024623
    - title: Microsoft Identity Web
      url: https://www.nuget.org/packages/Microsoft.Identity.Web

---

With the rise of microservices and cloud-native applications, securing APIs has become paramount for protecting data and ensuring seamless user experiences. This session delves into using C# with the Microsoft Identity Platform to secure APIs effectively.

In this session, we will take a look at how you can use [Microsoft Identity Web](https://www.nuget.org/packages/Microsoft.Identity.Web){:target="_blank"} in conjunction with ASP.NET Core for integrating with the [Microsoft identity platform](https://docs.microsoft.com/en-us/azure/active-directory/develop/?WT.mc_id=AZ-MVP-4024623){:target="_blank"} (formerly *Azure AD v2.0 endpoint*) and [Azure Active Directory B2C](https://docs.microsoft.com/en-us/azure/active-directory-b2c/?WT.mc_id=AZ-MVP-4024623){:target="_blank"} to protect your .NET APIs.

We'll walk through the following:

* Setting up Azure Active Directory (AD) tenant with the necessary '*application*' registrations to use the power of Azure and Microsoft Account logins to secure your API and applications.
* Add authentication and authorization to your API
* Add authentication to client applications.

At the end of the session, you'll want to go and add authentication and authorization to your APIs.
