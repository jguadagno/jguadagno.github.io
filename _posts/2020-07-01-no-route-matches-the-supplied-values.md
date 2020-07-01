---
title: "No route matches the supplied values"
categories:
  - Articles
tags:
  - WebApi
  - ASP.NET Core
  - MVC
  - ASP.NET Core MVC
---
> No route matches the supplied values

I spent about two hours figuring out why I was getting this error message for the [Contacts API](https://www.github.com/jguadagno/contacts). I followed the [Todo List](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/tutorials/first-web-api/samples/3.0) example by the book so that if someone from the stream were confused, they would have something to fall back on. Unfortunately, it wasn’t totally by the book.

I have code in the API for saving the contact which looks like this:

```cs
public async Task<ActionResult<Contact>> SaveContact(Contact contact)
{
    HttpContext.VerifyUserHasAnyAcceptedScope(Domain.Permissions.Contacts.Save);
    var savedContact = await _contactManager.SaveContactAsync(contact);

    if (savedContact != null)
    {
        return CreatedAtAction(nameof(GetContactAsync),
            new {id = contact.ContactId},
            contact);
    }
    return Problem("Failed to insert the contact");
}
```

This code uses the `CreatedAtAction` to return the `contact` and the URL to view the contact details.  However, this call kept returning an exception ***No route matches the supplied values***. I made sure the method/action existed. Here it is!

```cs
[HttpGet("{id}")]
public async Task<Contact> GetContactAsync(int id)
{
    HttpContext.VerifyUserHasAnyAcceptedScope(Domain.Permissions.Contacts.View);
    return await _contactManager.GetContactAsync(id);
}
```

I double-checked all of the route settings. I double-checked the name of the 'Get' function, `GetContactsAsync`, and everything looked ok. I even tried to skip the `nameof` operator and just hard the `GetContactsAsync`, but I kept getting the exception ***No route matches the supplied values***

I Googled and Binged for a while and did not come up with anything.  Until I came to this StackOverflow [question](https://stackoverflow.com/questions/39459348/asp-net-core-web-api-no-route-matches-the-supplied-values). The first answer was not the answer that solved my problem, but an answer [below](https://stackoverflow.com/a/61536687/89184).

As the answer suggests, ASP.NET Routing has an issue with the method name ending in the word `Async`.  As a result, it could not find my `GetContactsAsync` method.

So my options were to rename the method or not use the `CreatedAtAction`. I was not too fond of either option. The answer did suggest that I could use the `ActionName` attribute to inform the routing of what the actual name of the method is. I've updated the method as follows.

```cs
[HttpGet("{id}")]
[ActionName(nameof(GetContactAsync))]
public async Task<Contact> GetContactAsync(int id)
{
    HttpContext.VerifyUserHasAnyAcceptedScope(Domain.Permissions.Contacts.View);
    return await _contactManager.GetContactAsync(id);
}
```

So using the `ActionName` got me over the hurdle of '***No route matches the supplied values***.' I hope this helps someone.
