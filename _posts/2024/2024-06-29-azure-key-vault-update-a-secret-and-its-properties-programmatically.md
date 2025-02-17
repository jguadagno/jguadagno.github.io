---
title: "Azure Key Vault - Update a Secret and its Properties Programmatically"
header:
    og_image: /assets/images/posts/header/azure-key-vault-secret-update.png
date: 2024-06-29 13:18:00 -0700
categories:
- Articles
tags:
- Azure
- Key Vault
- .NET
---

When you use the Azure Key Vault SDK, you can create, read, update, and delete secrets.  In this post, you will learn how to update a secret and its properties using the Azure Key Vault SDK.

I was working on the [JosephGuadagno.NET Broadcasting](https://github.com/jguadagno/jjgnet-broadcast){:target="_blank"} application this weekend and wanted to create a feature that would automatically refresh the tokens that are used to authenticate with the various social media platforms. For reasons, these tokens were stored locally in the application settings.  I know, bad choice, but when I started this project I really didn't know Azure Key Vault, so I went with what I knew.  I moved these tokens to Azure Key Vault, so now I needed to update the tokens in the Key Vault. However, when use Azure Key Vault SDK to update secrets, it creates an new version of the secret and doesn't disable the previous secret.  Since I am refreshing the token, the old token is no longer valid, so I needed to disable the old secret.  At the same time, Azure Key Vaults secrets have an expiration date, so I wanted to update the expiration date of the secret as well.  Let's take a look at how to do this.

This post assumes you have an Azure Key Vault instance and you know how to setup a secret.  If you don't know how to set up a secret, you can follow the steps in the post [Securing Azure Function Settings with Azure Key Vault]({% post_url 2020/2020-07-10-securing-azure-function-settings-with-azure-key-vault %}){:target="_blank"}.
{: .notice}

## The Process

There are a couple of steps to update a secret and its properties to achieve what I wanted to.  The steps are:

1. Establish a connection to the Azure Key Vault and obtain a `SecretClient` [class](https://learn.microsoft.com/en-us/dotnet/api/azure.security.keyvault.secrets.secretclient?view=azure-dotnet&?wt.mc_id=DT-MVP-4024623){:target="_blank"}.
2. Get the current secret from the vault using the `GetSecretAsync` [method](https://learn.microsoft.com/en-us/dotnet/api/azure.security.keyvault.secrets.secretclient.getsecretasync?view=azure-dotnet&?wt.mc_id=DT-MVP-4024623){:target="_blank"} of the `SecretClient` class.
3. Call the `UpdateSecretPropertiesAsync` [method](https://learn.microsoft.com/en-us/dotnet/api/azure.security.keyvault.secrets.secretclient.updatesecretproperties?view=azure-dotnet&?wt.mc_id=DT-MVP-4024623){:target="_blank"} of the `SecretClient` class to disable the secret.
4. Update / create a new version of the secret using the `SetSecretAsync` [method](https://learn.microsoft.com/en-us/dotnet/api/azure.security.keyvault.secrets.secretclient.setsecretasync?view=azure-dotnet&?wt.mc_id=DT-MVP-4024623){:target="_blank"} of the `SecretClient` class
5. Call the `UpdateSecretPropertiesAsync` [method](https://learn.microsoft.com/en-us/dotnet/api/azure.security.keyvault.secrets.secretclient.updatesecretproperties?view=azure-dotnet&?wt.mc_id=DT-MVP-4024623){:target="_blank"} of the `SecretClient` class using the `KeyVaultSecret` returned from the step 4 to update the expiration date of the secret.

### The Code

Here is the code to update a secret and its properties.

```csharp
public async Task UpdateSecretValueAndProperties(SecretClient client, 
            string secretName, string secretValue, DateTime expiresOn)
{
    // Step 2: Get the current secret
    var originalSecretResponse = await client.GetSecretAsync(secretName);
    var originalSecret = originalSecretResponse.Value;
    
    // Step 3: Disable the old secret
    // Set the old secret to disabled
    originalSecret.Properties.Enabled = false;
    var updatePropertiesResponse = 
        await client.UpdateSecretPropertiesAsync(originalSecret.Properties);
    
    // Step 4: Create a new version of the secret
    // Update secret value (create a new version)
    var newSecretVersionResponse = await client.SetSecretAsync(secretName, secretValue);
    var newKeyVaultSecretVersion = newSecretVersionResponse.Value;
    
    // Step 5: Update the expiration date
    // Update the expiration date
    newKeyVaultSecretVersion.Properties.ExpiresOn = expiresOn;
    updatePropertiesResponse = 
        await client.UpdateSecretPropertiesAsync(newKeyVaultSecretVersion.Properties);
}
```

The error handling in this code was removed for brevity.  You should add error handling to your code. You can find the full code in the [jjgnet-broadcasting](https://github.com/jguadagno/jjgnet-broadcast/blob/a16b3f6dabc19b3ab60f1dacee23736d51b9adb3/src/JosephGuadagno.Broadcasting.Functions/Facebook/RefreshTokens.cs#L110){:target="_blank"} repository.
{: .notice}

## Wrap Up

I'm not sure why these steps are necessary to update a secret and its properties.  I would think that the `SetSecretAsync` method would update the secret and its properties with an overloaded method and/or better yet add an option to the `SetSecretAsync` method to disable the previous version, if one exists.  However, it doesn't. I hope this post helps you if you need to update a secret and its properties in Azure Key Vault.

## References

* [Azure Key Vault](https://docs.microsoft.com/en-us/azure/key-vault/key-vault-overview?wt.mc_id=DT-MVP-4024623){:target="_blank"}
* [Azure Key Vault SDK - SecretClient Class](https://learn.microsoft.com/en-us/dotnet/api/azure.security.keyvault.secrets.secretclient?view=azure-dotnet&?wt.mc_id=DT-MVP-4024623){:target="_blank"}
* [Azure Key Vault SDK - SecretClient.GetSecretAsync Method](https://learn.microsoft.com/en-us/dotnet/api/azure.security.keyvault.secrets.secretclient.getsecretasync?view=azure-dotnet&?wt.mc_id=DT-MVP-4024623){:target="_blank"}
* [Azure Key Vault SDK - SecretClient.SetSecretAsync Method](https://learn.microsoft.com/en-us/dotnet/api/azure.security.keyvault.secrets.secretclient.setsecretasync?view=azure-dotnet&?wt.mc_id=DT-MVP-4024623){:target="_blank"}
* [Azure Key Vault SDK - SecretProperties Class](https://learn.microsoft.com/en-us/dotnet/api/azure.security.keyvault.secrets.secretproperties?view=azure-dotnet&?wt.mc_id=DT-MVP-4024623){:target="_blank"}
* [Azure Key Vault SDK - SecretClient.UpdateSecretPropertiesMethod](https://learn.microsoft.com/en-us/dotnet/api/azure.security.keyvault.secrets.secretclient.updatesecretproperties?view=azure-dotnet&?wt.mc_id=DT-MVP-4024623){:target="_blank"}
* [Azure.Security.KeyVault.Secrets Documentation](https://azuresdkdocs.blob.core.windows.net/$web/dotnet/Azure.Security.KeyVault.Secrets/4.6.0/api/index.html#create-a-secret-asynchronously?wt.mc_id=DT-MVP-4024623){:target="_blank"}
