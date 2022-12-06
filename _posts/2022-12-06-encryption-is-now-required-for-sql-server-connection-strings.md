---
title: "Encryption Is Now Required for SQL Server Connection Strings"
header:
    og_image: /assets/images/posts/header/encryption-sql-server.png
date: 2022-12-06 04:22:00 -0700
categories:
  - Articles
tags:
  - .NET
  - dotnet
  - SQL Server
---

While I was presenting my workshop [Building and Deploying a New Cloud App from Scratch]({% link _presentations/building-and-deploying-a-new-cloud-app-from-scratch.md %}){:target="_blank"} at [DEVIntersections](https://www.devintersections.com){:target="_blank"} yesterday the connection to the database kept failing. Which was weird because I've gone through the code quite a few times to make sure everything worked.  The good thing is that it failed during the creation of the integration tests which demonstrated the benefit of creating them.  However, that did not help me on stage.  I was getting the following error:

```text
A connection was successfully established with the server, but then an error occurred during the login process. 
(provider: SSL Provider, error: 0 - The certificate chain was issued by an authority that is not trusted.)
```

I could not figure out what was wrong.  It worked a few days ago.  Then one attendee said that he saw something similiar last week and he had to add an additional parameter to the connection string, `encrypt=optional`.  I added that to the connection string and it worked.  I was able to continue with the workshop.  However, I was curious why this was happening.  I did some research and found that there was a breaking change to the `Microsoft.Data.SqlClient`, as outlined on the [Entity Framework Core 7.0 Breaking Changes](https://learn.microsoft.com/en-us/ef/core/what-is-new/ef-core-7.0/breaking-changesWT.mc_id=AZ-MVP-4024623#high-impact-changes){:target="_blank"} page. As it turns out, when I ran this workshop a week or so ago, I was using `Entity Framework Core` version 6.0 along with the corresponding version of `Microsoft.Data.SqlClient` version 6.0 and this change was introduced in `Microsoft.Data.SqlClient` version 7.0 which `Entity Framework Core` version 7.0 uses.

It turns out the change is important I/we should have the proper certificates on the SQL Server, that's the next think I need to figure out how to do locally, so that I can continue to use the default connection string.  However, I'm glad I found the issue and was able to continue with the workshop.

Hopefully, this helps someone else.
