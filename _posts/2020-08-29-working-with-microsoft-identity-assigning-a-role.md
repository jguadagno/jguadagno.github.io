---
title: "Working with Microsoft Identity - Assigning a Role"
header:
    og_image: /assets/images/posts/header/msal-assigning-a-role.png
categories:
  - Articles
tags:
  - Azure
  - Identity
  - MSAL
  - Managed Identity
---
Securing our applications and data is critical in this day and age.  I've been working a lot with the new [Microsoft identity platform](https://docs.microsoft.com/en-us/azure/active-directory/develop/){:target="_blank"}  (MSAL) library, so I decided to create a series of blog posts around working with it.

* [Register an application]({% link _posts/2020-08-29-working-with-microsoft-identity-registering-an-application.md %}).
* [Configure Local Development]({% link _posts/2020-08-29-working-with-microsoft-identity-configure-local-development.md  %})
* Assigning a Role (this post)

## Role-Based Access Control

Before we assign a role, we should take a look out what [Azure RBAC](https://docs.microsoft.com/en-us/azure/role-based-access-control/overview){:target="_blank"} is. Azure RBAC, or Azure Role-Based Access Control, is an authorization system built on Azure Resource Manager that provides fine-grained access management of Azure resources.  It allows you to create roles or use predefined roles for your applications.

Azure RBAC includes several [built-in roles](https://docs.microsoft.com/en-us/azure/role-based-access-control/built-in-roles){:target="_blank"} that you can use. The following lists four built-in roles. The first three apply to all resource types.

* **Owner** - Has full access to all resources including the right to delegate access to others.
* **Contributor** - Can create and manage all types of Azure resources but can't grant access to others.
* **Reader** - Can view existing Azure resources.
* **User Access Administrator** - Lets you manage user access to Azure resources.

If you don't find a role that fits your needs, you can create [custom roles](https://docs.microsoft.com/en-us/azure/role-based-access-control/custom-roles){:target="_blank"}. From what I have found, the default roles are adequate for my use.

## Assigning a Role

Assigning a role to an application assigns a set of permissions to the Azure resource for the given application.  In the sample below, we are going to assign the `Storage Blob Data Contributor` role to our application.

In the Azure Portal, navigate to the resource that you want to provide access to and click on 'Access control (IAM') on the left menu.

There are two ways to add the role.  

* Option 1, is click the '+ Add', then 'Add role assignment'.
* Option 2, is to click the 'Add' button.

![Add IAM Role](/assets/images/posts/securing-container-add-role.png){: .align-center}

Enter the following:

| --- | --- | --- |
| Name | Value | Description |
| Role | `Storage Blob Data Contributor` | Add what makes sense for your application.  Not sure what setting to use, hover over the 'i' or check out the permissions mentioned earlier in this post. |
| Assign access to | `Azure AD user, group, or service principal` | |
| Select | *The name of the application* | The default will be your user id.  Type in the first couple of characters of the application |

![Add Role Assignment](/assets/images/posts/securing-container-add-role-assignment.png){: .align-center}

* Click 'Save'

## Verifying Role Access

### Check Application Access

If you want to check what applications/users have access to a given resource

* Navigate to the resource
* Click 'Access control (IAM)'
* Click 'Check Access'

![Check Access](/assets/images/posts/msal-check-access.png){: .align-center}

Underneath 'Find', choose the type of managed identity you are want to check.

![MSAL - Identity Types](/assets/images/posts/msal-find-list.png){: .align-center}

The default of `Azure AD user, group, or service principal` should be enough.  If you have a lot of resources, you can narrow the search results down by choosing another identity type.

* Type the first couple of characters of the application and/or resource.

Once you see the resource you are wanting to check roles on, click it and you will see any permissions assigned.  In this example, there were no permissions assigned.

![MSAL - No Permissions Assigned](/assets/images/posts/msal-no-permissions-assigned.png){: .align-center}

### View All Roles Assigned

You can view all of the roles assigned to a given resource in Azure.

* Navigate to the resource
* Click 'Access control (IAM)'
* Click 'Role assignments'

This will list all of the registered applications and/or users that have access to this application.

![MSAL - Roles Assigned](/assets/images/posts/msal-role-assignments.png){: .align-center}

The number 1 on the image tells us how many roles we have assigned in our subscription, not for this resource.

The number 2 on the image, provides you the ability to narrow down the results.  In this case, I have it filtered to those applications/users that have the `Storage Blob Data Contributor` role.

The number 3 on this image, lists all of the applications/users that match the filters above.

## Resources

* [Add/Remove Azure role assignments using the Azure portal](https://docs.microsoft.com/en-us/azure/role-based-access-control/role-assignments-portal){:target="_blank"}
* [Add or remove Azure role assignments using Azure CLI](https://docs.microsoft.com/en-us/azure/role-based-access-control/role-assignments-cli){:target="_blank"}
