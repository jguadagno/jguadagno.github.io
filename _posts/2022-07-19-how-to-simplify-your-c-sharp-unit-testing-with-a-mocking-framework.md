---
title: "How to simplify your C# unit testing with a mocking framework"
header:
    og_image: /assets/images/posts/header/github-copilot-writing.png
date: 2022-07-19 06:10:00 -0500
categories:
  - Articles
tags:
  - Mock
  - Unit Tests
  - testing
---

## What is Mocking

It's time to take your unit testing to the next level.  You've implemented either [NUnit](https://www.nunit.org), or [xUnit](https://xunit.net), or [MSTest](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-mstest?WT.mc_id=AZ-MVP-4024623) in your projects. You've gotten your code coverage to 80+%. But the are just some things that are hard to test or validate in your project.  How do you test the "business logic" in your repository class?  How do you test your dependent web service or database? Yeah, you can write special unit test and create fake objects to mimic these dependencies but why waste your time writing code that does not ship with the end product. Or write a lot of code with the `ExcludeFromCoverage` attribute :smile:. Well this is mocking comes in.

Mocking is a framework that allows you to create a mock object that can be used to simulate the behavior of a real object.  You can use the mock object to verify that the real object was called with the expected parameters, and to verify that the real object was not called with unexpected parameters.  You can also verify that the real object was called the expected number of times.  You can also verify that the real object was called with the expected parameters and that the real object was not called with unexpected parameters. The possibilities are endless. Mocking comes in three flavors: *fakes*, *stubs*, and *mocks*. The fakes are the simplest.  They are used when you want to test the behavior of a class that has no dependencies.  The stubs are used when you want to test the behavior of a class that has dependencies.  The mocks are used when you want to test the behavior of a class that has dependencies.

*For more information on mocking and the differences between stubs, fakes and mocks read the [Fakes, Stubs and Mocks](https://www.telerik.com/blogs/30-days-of-tdd-day-11-what-s-the-deal-with-mocking) blog post.*

## Getting Started with Mocking

First, you'll need a mocking framework to get started.  Something like Telerik [JustMock](https://www.telerik.com/products/mocking.aspx) or their free version [JustMock Lite](https://www.telerik.com/justmock/free-mocking).

***MAYBE:*** **Insert a cool ad or picture about JustMock here** Similar to https://www.telerik.com/blogs/30-days-of-tdd-day-11-what-s-the-deal-with-mocking

A mocking framework is what you creates the objects and *"pretends"* to be the object(s) you are testings.

### Arrange, Act, Assert

Now that you have a mocking framework, let's get started with the primary parts of the unit testing process, Arrange, Act, Assert. Arrange, Act, Assert, or AAA, is a common term used to describe the process of setting up the test environment, executing the test, and verifying the results. It's a best practice in unit testing. Basically, each of your unit tests should have these three parts:

- Arrange: Set up the test.
- Act: Execute the test.
- Assert: Verify the results.

When I write tests, in this case using xUnit, I generally start with this "stub" pattern:

```csharp
[Fact]
public void GetContact_WithAnInvalidId_ShouldReturnNull()
{
    // Arrange 

    // Act

    // Assert
}
```

The method name is follows a consistent format:

- `[Fact]`: This is a fact test.
- `public void`: This is a public method.
- `GetContact`: This is the method you are testing.
- `_WithAnInvalidId_`: Whatever variables you are using, in this example, an *invalid id*.
- `ShouldReturnNull`: The expected outcome.

While this convention is not required, I tend to use it so when I am looking at the results, or another engineer is looking at the code, he/she can see the intent of the test.

![All Unit Tests Pass Successfully](/assets/images/posts/mocking-unit-test-success.jpg)

## Mocking Stuff

There are a lot of different types of things to mock, like services, databases, queues, and other types of dependencies. For this introductory example, I am going to demonstrate different ways to test a class that requires a dependency of a database. I'll be using [xUnit](https://xunit.net) and Telerik [JustMock]([https](https://www.telerik.com/products/mocking.aspx)) for these examples.

The project used in this example can be found [here](https://github.com/jguadagno/contacts-mocking). This project is a C# project that was build on my [Twitch](https://www.twitch.tv/jguadagno) stream. The application provides a way to manage a list of contacts. It uses a variety of technologies including:

- Web API
- SQL Server
- ASP.NET Core
- ASP.NET Core MVC
- Azure Storage
- Azure Functions

With all these dependencies I needed a way to validate that these dependencies are working as expected. And before you ask, no, I am not testing the functionality of SQL Server, or Azure Storage, or Azure Functions.  I am only testing the interaction with this services. That's where mocking comes in. For the rest of this post, I'll focus on testing the `ContactManager` class and mocking the `ContactRepository`.

Before we get started, let's take a look at the `ContactManager` class. The `ContactManager` implements the `IContactManager` interface. This is what we are testing.

```csharp
public interface IContactManager
{
    Contact GetContact(int contactId);
    List<Contact> GetContacts();
    List<Contact> GetContacts(string firstName, string lastName);
    Contact SaveContact(Contact contact);
    bool DeleteContact(int contactId);
    bool DeleteContact(Contact contact);
    List<Phone> GetContactPhones(int contactId);
    Phone GetContactPhone(int contactId, int phoneId);
    List<Address> GetContactAddresses(int contactId);
    Address GetContactAddress(int contactId, int addressId);
    /// Other methods removed for brevity
}
```

Full code for this class can be found [here](https://github.com/jguadagno/contacts-mocking/blob/main/src/Contacts.Domain/Interfaces/IContactManager.cs)

We'll be mocking the `ContactRepository` object which implements the `IContactRepository` interface.

```csharp
public interface IContactRepository
{
    Contact GetContact(int contactId);
    List<Contact> GetContacts();
    List<Contact> GetContacts(string firstName, string lastName);
    Contact SaveContact(Contact contact);
    bool DeleteContact(int contactId);
    bool DeleteContact(Contact contact);
    List<Phone> GetContactPhones(int contactId);
    Phone GetContactPhone(int contactId, int phoneId);
    List<Address> GetContactAddresses(int contactId);
    Address GetContactAddress(int contactId, int addressId);
    /// Other methods removed for brevity
}
```

While objects that are being mocked don't need to be interfaces, it certainly helps.  The `IContactManager` interface is a contract that defines the methods that interact with a *contact*.  The `ContactManager` class implements the `IContactManager` interface, in this case.  However, one thing to note is that the `ContactManager` requires an `IContactRepository` dependency, which is what we are going to mock. The `IContactRepository` interface, defines the contract with the database, which we do not want to test.  This is were mocking comes in.  We want to be able to test that the logic in the `ContactManager` class is working as expected without going back and forth with the database. This allows use to test things like validation or objects on save, returning the correct exceptions when things go wrong, etc.

### Our First Mock

Let's start with the most common test. Let's validate that a call to `GetContacts` returns a list of contacts.  We'll start with the simplest test, and then move to more complex tests.

The signature of `GetContacts` is:

```csharp
Task<List<Contact>> GetContacts();
```

If we start with our template from above, we should stub out a test that looks like this:

```csharp
public void GetContacts_ShouldReturnLists()
{
    // Arrange

    // Act

    // Assert
}
```

#### Arrange: The test

Now, let's look at the *arrange* part. For the arrange part, we need to setup the mocks so that the mocking framework knows what to mimic or mock. Here's the arrange part for the `GetContacts_ShouldReturnLists` method:

```csharp
var mockContactRepository = Mock.Create<IContactRepository>();
Mock.Arrange(() => mockContactRepository.GetContacts())
  .Returns(new List<Contact>
  {
      new Contact { ContactId = 1 }, new Contact { ContactId = 2 }
  });
var contactManager = new ContactManager(mockContactRepository);
```

On line 1, we create a variable, `mockContactRepository` that is the mock of the `IContactRepository` interface.  Line 2, we create a mock of the `GetContacts` method.  Lines 3-6, we create a list of contacts and tell the the mock framework return this object when a call is made to `GetObjects`. Finally, on line 7, we create a new `ContactManager` object and pass in the mock `IContactRepository` object.

#### Act: Execute on the test

In this case, the *act* is trivial.  We just call the `GetContacts` method on the `ContactManager` object.

```csharp
var contacts = contactManager.GetContacts();
```

This should return a list of contacts with two contacts with the ids of 1 and 2.

#### Assert: verify the results

Let's validate that the list of contacts has two contacts.

```csharp
Assert.NotNull(contacts);
Assert.Equal(2, contacts.Count);
```

Line 1 is checking that the list of contacts is not null.  Line 2 is checking that the list of contacts has two contacts.

#### The Complete Test

```csharp
[Fact]
public void GetContacts_ShouldReturnLists()
{
    // Arrange
    var mockContactRepository = Mock.Create<IContactRepository>();
    Mock.Arrange(() => mockContactRepository.GetContacts())
      .Returns(new List<Contact>
      {
        new Contact { ContactId = 1 }, new Contact { ContactId = 2 }
      });

    var contactManager = new ContactManager(mockContactRepository);

    // Act
    var contacts = contactManager.GetContacts();

    // Assert
    Assert.NotNull(contacts);
    Assert.Equal(2, contacts.Count);
}
```

### Mocking with Ranges

There is a method in the `ContactManager` called `GetContact` which requires an integer as a parameter. In our business case, the identifier of a contact is a positive number (integer). So let's set up some test that make sure a call to get `GetContact` with a negative number returns `null` and a call to get `GetContact` with a positive number returns a contact.

For this, we'll use a feature called *matchers*. Matchers let you ignore passing actual values as arguments used in mocks. Instead, they give you the possibility to pass just an expression that satisfies the argument type or the expected value range. The means that we don't have to write a test for each possible value. We can just write a test for the range of values. We are going to use the `InRange` matcher for our two tests.

For the test, `GetContact_WithAnInvalidId_ShouldReturnNull` where we expect a `null` return, we would arrange the test like this:

```csharp
Mock.Arrange(() => 
  mockContactRepository.GetContact(Arg.IsInRange(int.MinValue, 0, RangeKind.Inclusive)))
    .Returns<Contact>(null);
```

In this arrangement, we are saying that when a call to `GetContact` is made with an argument that is in the range of `int.MinValue` to 0, inclusive, we should return `null`.

Our act and assert looks like:

```csharp
// Act
var contact = contactManager.GetContact(-1); // Any number less than zero

// Assert
Assert.Null(contact);
```

For the test, `GetContact_WithAnValidId_ShouldReturnContact`, we would arrange the test like this:

```csharp
Mock.Arrange(() =>
  mockContactRepository.GetContact(Arg.IsInRange(1, int.MaxValue, RangeKind.Inclusive)))
    .Returns(
    (int contactId) => new Contact
    {
        ContactId = contactId
    });

var contactManager = new ContactManager(mockContactRepository);
const int requestedContactId = 1;
```

This one required a little bit more work because we needed to specific an object to return, lines 3 to 6, and a value for the contact id, line 9, to validate in our test.

Our act and assert looks like:

```csharp
// Act
// Assumes that a contact record exists with the ContactId of 1
var contact = contactManager.GetContact(requestedContactId);

// Assert
Assert.NotNull(contact);
Assert.Equal(requestedContactId, contact.ContactId);
```

### Mocking with Exceptions

The `GetContacts` method has an overload which expects two string parameters, one for first name and the other for last name.  The method, also requires that the first name and last name are not `null` or empty. If so, it should throw an `ArgumentNullException`. Let's create a test that validates that a call to `GetContacts` with an empty first name and last name throws the exception.

Let's arrange the test like this:

```csharp
// Arrange 
var mockContactRepository = Mock.Create<IContactRepository>();
Mock.Arrange(() =>
    mockContactRepository.GetContacts(null, Arg.IsAny<string>()));

var contactManager = new ContactManager(mockContactRepository);
```

Here we are passing a `null` for the `FirstName` parameter and using the `Arg.IsAny<string>` matcher for the `LastName` parameter which will match any string.

Our act, which is also and asset, looks like this:

```csharp
// Act
ArgumentNullException ex =
  Assert.Throws<ArgumentNullException>(() => contactManager.GetContacts(null, "Guadagno"));
```

Here we are creating a variable `ex` which is of type `ArgumentNullException` and then we are asserting that the `GetContacts` method throws an `ArgumentNullException` when called with the `FirstName` parameter set to `null` and the `LastName` parameter set to `Guadagno`.

Then in the assert, we are checking that the exception message is correct.

```csharp
// Assert
Assert.Equal("firstName", ex.ParamName);
Assert.Equal("FirstName is a required field (Parameter 'firstName')", ex.Message);
```

Note, JustMock supports an alternative way of asserting that an exception is thrown. We can use `Mock.Arrange` to assert that an exception is thrown.  We can use the `Throws` matcher to assert that an exception is thrown.  We can use the `Throws<T>` matcher to assert that an exception of a specific type is thrown.

```csharp
Mock.Arrange(() => contactManager.GetContacts(null, "Guadagno"))
  .Throws<ArgumentNullException>("FirstName is a required field (Parameter 'firstName')"); 
```

### Complete Contact Tests

The complete code for the `ContactManager` class can be found [here](https://github.com/jguadagno/contacts-mocking/blob/main/src/Contacts.Logic/ContactManager.cs).
The complete code for the `ContactManagerTest` class can be found [here](https://github.com/jguadagno/contacts-mocking/blob/main/src/Contacts.Logic.Tests/ContactManagerTests.cs).

## Wrapping Up

This just scratches the surface of mocking.  There are many more ways to mock using a mocking framework like JustMock.  Maybe we'll cover more in a future post.
