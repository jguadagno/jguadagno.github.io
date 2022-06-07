---
title: "Using Yarn with ASP.NET Core Projects"
date: 2021-01-18 09:00:00 -0700
header:
    og_image: /assets/images/posts/header/yarn-aspnet-core.png
categories:
  - Articles
tags:
  - Yarn
  - ASP.NET
  - ASP.NET Core
  - ASP.NET Core MVC
  - Razor
  - MVC
  - Web
---
Since I got bitten by the CI/CD bug, I've been looking at ways to clean up some code-bases and make it easier to deploy and store less *unneeded* files in my repositories.  This time around it got me looking into {:target="_blank"}

> Yarn is a package manager that doubles down as project manager. Whether you work on one-shot projects or large monorepos, as a hobbyist or an enterprise user, we've got you covered.

If you are familiar with what Nuget is for packages in the .NET ecosystem, Yarn does the same thing except for web packages (HTML, CSS, javascript, etc).

I looked at Yarn to update the commonly used web frameworks like, [Bootstrap](https://www.getbootstrap.com){:target="_blank"}, [jQuery](https://jquery.com){:target="_blank"} (required for Bootstrap), and [Fontawesome](https://fontawesome.com/){:target="_blank"} and I couldn't find anything that told me how. Microsoft started a project called [LibMan](https://docs.microsoft.com/en-us/aspnet/core/client-side/libman/libman-vs?view=aspnetcore-5.0&WT.mc_id=AZ-MVP-4024623){:target="_blank"} which helped with the management of packages but that only worked in the IDE.  So, as I like to do, I worked on figuring it out.

Let's get to it!

## Getting Started

First, you need to down and install Yarn. Details can be found on their [Getting Started](https://yarnpkg.com/getting-started){:target="_blank"} page. The second step, if you already have an existing ASP.NET project, Core/MVC/Razor, delete the `wwwroot\lib` folder, assuming you have nothing in it but the 3rd party packages.

## Adding Packages with Yarn

### Configuring Yarn

By default, Yarn will place everything in the `node_modules` folder which could work for you, for me, I was trying to have the smallest amount of changes to the rest of the project.  There are two ways to override that folder.  You can add `--modules-folder wwwroot/lib` to the command line every time you run Yarn, or you can create a Yarn configuration file.

***NOTE***: The `.yarnrc` file is going away, from what I can tell with v2 of Yarn.
{: .notice--info}

To create the configuration file, you need to create a `.yarnrc` file in the root of your web project. Depending on what IDE you need, the instructions will vary slightly. Once the file is created, add the following line to the `.yarnrc` file. I found this on [StackOverflow](https://stackoverflow.com/a/53072639/89184){:target="_blank"}.

```bash
--modules-folder wwwroot/lib
```

Save the file.

### Adding Package

I'm going to cover adding the required files for the templates that are included with ASP.NET.  Here, you will need to go to a command-line, terminal, bash-script, whichever is your choice, to add the packages.  The syntax is `yarn add <packageName>` where the `<packageName>` is the name of the package you want to add.

Here are the commands for the ASP.NET Core template.

```bash
yarn add popper.js (deprecation warning)
yarn add jquery
yarn add bootstrap
yarn add jquery-validation
yarn add jquery-validation-unobtrusive
yarn add @fortawesome/fontawesome-free
```

***Note***: You will see a warning that `popper.js` is deprecated, you can ignore that, the next version of Bootstrap will have popper.js built-in so you will no longer need it.
{: .notice--danger}

If you have additional packages that you want to add, search the Yarn [site](https://yarnpkg.com){:target="_blank"} to see what packages they have.  If you find the package there the site includes other details about the package, including the primary site for the package, what CDNs host the package, and more.
{: .notice--info}

You'll notice that a `package.json` and `yarn.lock` file gets created.  The `package.json` is the list. or manifest, of packages you have added. The files can be edited directly if you know the name and versions of the packages you want to install.  The `yarn.lock` file is used by Yarn and contains some more details around the packages.

If you used the location of `wwwroot/lib` you shouldn't need to do anything else.  When you want to update a library, just edit the `package.json` file and run `yarn` from the terminal.

## Using a Content Delivery Network (CDN)

Bonus Content! Win/Win!

What's a content delivery network you ask?

> A Content Delivery Network (CDN) is a system of geographically distributed servers that work together to provide fast delivery of Internet content. It's designed to minimize latency in loading web pages by reducing the physical distance between the server and the user. A CDN allows for a quick transfer of assets needed to load content such as HTML pages, javascript files, stylesheets, images, and videos.

Using Yarn to add your HTML, CSS, or javascript dependencies provides you with the option to not add these files to your source code repositories since you can install them at any time.  That choice is yours. However, using packages added by Yarn also make it easier for you to use CDNs for hosting these same files.  

There are several CDNs out there to use. If you discover the package on the Yarn site, you'll see mentions of a few CDNs like [jsDeliver](https://www.jsdelivr.com/){:target="_blank"}, [unpkg](https://unpkg.com/){:target="_blank"}, and [bundle.run](https://bundle.run/){:target="_blank"}, I'll use [cdnjs](https://cdnjs.com){:target="_blank"} for these examples.

Using a CDN has several advantages but at the same time has a disadvantage. If the CDN you chose is down, your content will not be served which will lead to a less than designed look and feel for your site.  The good news is, ASP.NET has a built-in feature to fallback to local content in the event the CDN is down. These features are the [Script](https://docs.microsoft.com/en-us/aspnet/core/mvc/views/tag-helpers/built-in/script-tag-helper?view=aspnetcore-5.0&WT.mc_id=AZ-MVP-4024623){:target="_blank"} & [Link](https://docs.microsoft.com/en-us/aspnet/core/mvc/views/tag-helpers/built-in/link-tag-helper?view=aspnetcore-5.0&WT.mc_id=AZ-MVP-4024623){:target="_blank"} tag helpers.

Looking at the sample for jQuery you'll notice four additional attributes.

```html
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.5.1/jquery.min.js"
  integrity="sha512-bLT0Qm9VnAYZDflyKcBaQ2gg0hSYNQrJ8RilYldYQ1FxQYoCLtUjuuRuZo+fjqhx/qtq/1itJ0C2ejDxltZVFg=="
  crossorigin="anonymous"
  asp-fallback-src="~/lib/jquery/dist/jquery.min.js"
  asp-fallback-test="window.jQuery">
</script>
```

| Name | Usage |
| asp-fallback-src | The local source to use if the CDN failed to load the resource |
| asp-fallback-test| A test that ASP.NET will inject into your page to see if loading from the CDN worked. |

You can replace all of the scripts now with a `script` tag similar to this one.  Later in the post, you'll see a working example.

## Using the Environment Tag Helper

Even more bonus content! Win/Win Again!

ASP.NET Core added an [Environment](https://docs.microsoft.com/en-us/aspnet/core/mvc/views/tag-helpers/built-in/environment-tag-helper?view=aspnetcore-5.0&WT.mc_id=AZ-MVP-4024623){:target="_blank"} tag helper.  This helper allows you to render content specific to an environment.  This means, you can scripts from your local machine when running in development and serve them from a CDN when running in production. I know, at this point you are probably saying *'Joe, that sounds really complicated'*.  Well, it isn't! Let me show you.

In this example.

```html
<environment include="Staging,Production">
    <strong>IWebHostEnvironment.EnvironmentName is Staging or Production</strong>
</environment>
```

ASP.NET will render **IWebHostEnvironment.EnvironmentName is Staging or Production**.

You can use the `exclude` and `include` attributes together to create something like this.

```html
<environment include="Development">
    <link rel="stylesheet" href="~/lib/bootstrap/dist/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="~/css/site.css"/>
</environment>
<environment exclude="Development">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.5.3/css/bootstrap.min.css"
          integrity="sha512-oc9+XSs1H243/FRN9Rw62Fn8EtxjEYWHXRvjS43YtueEewbS6ObfXcJNyohjHqVKFPoXXUxwc+q1K7Dee6vv9g=="
          crossorigin="anonymous"
          asp-fallback-href="~/lib/bootstrap/dist/css/bootstrap.min.css"
          asp-fallback-test-class="sr-only" asp-fallback-test-property="position" asp-fallback-test-value="absolute"/>
    <link rel="stylesheet" href="~/css/site.css" asp-append-version="true"/>
</environment>
```

In the `Development` environment, ASP.NET Core will render the files from the local machine. In all other environments, it will try from a CDN first, then locally.

### New Template

Here is a completed template using the `Environment` tags, and CDNs.

```html
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>@ViewData["Title"] - @conferenceName</title>
    <environment include="Development">
        <link rel="stylesheet" href="~/lib/bootstrap/dist/css/bootstrap.min.css"/>
        <link rel="stylesheet" href="~/css/site.css"/>
    </environment>
    <environment exclude="Development">
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.5.3/css/bootstrap.min.css"
              integrity="sha512-oc9+XSs1H243/FRN9Rw62Fn8EtxjEYWHXRvjS43YtueEewbS6ObfXcJNyohjHqVKFPoXXUxwc+q1K7Dee6vv9g=="
              crossorigin="anonymous"
              asp-fallback-href="~/lib/bootstrap/dist/css/bootstrap.min.css"
              asp-fallback-test-class="sr-only" asp-fallback-test-property="position" asp-fallback-test-value="absolute"/>
        <link rel="stylesheet" href="~/css/site.css" asp-append-version="true"/>
    </environment>
    <environment include="Development">
        <script defer src="~/lib/@("@")fortawesome/fontawesome-free/js/all.js"></script>
    </environment>
    <environment exclude="Development">
        <script src="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.1/js/all.min.js"
                integrity="sha512-F5QTlBqZlvuBEs9LQPqc1iZv2UMxcVXezbHzomzS6Df4MZMClge/8+gXrKw2fl5ysdk4rWjR0vKS7NNkfymaBQ=="
                crossorigin="anonymous">
        </script>
    </environment>
</head>
<body>
<header>
    <nav class="navbar navbar-expand-sm navbar-toggleable-sm navbar-dark bg-dark border-bottom box-shadow mb-3">
        <div class="container">
            <a class="navbar-brand" asp-area="" asp-controller="Home" asp-action="Index">Home Page</a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target=".navbar-collapse" aria-controls="navbarSupportedContent"
                    aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="navbar-collapse collapse d-sm-inline-flex justify-content-between">
                <ul class="navbar-nav flex-grow-1">
                    <li class="nav-item">
                        <a class="nav-link" asp-area="" asp-controller="Home" asp-action="Index">Home</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" asp-area="" asp-controller="Events" asp-action="About">About</a>
                    </li>
                </ul>
            </div>
        </div>
    </nav>
</header>
<div class="container">
    <main role="main" class="pb-3">
        @RenderBody()
    </main>
</div>

<footer class="border-top footer text-muted">
    <div class="container">
        &copy; 2021 - JosephGuadagno.NET, LLC - <a asp-area="" asp-controller="Home" asp-action="Privacy">Privacy</a>
    </div>
</footer>
<environment include="Development">
    <script src="~/lib/jquery/dist/jquery.min.js"></script>
    <script src="~/lib/bootstrap/dist/js/bootstrap.bundle.min.js"></script>
</environment>
<environment exclude="Development">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.5.1/jquery.min.js"
            integrity="sha512-bLT0Qm9VnAYZDflyKcBaQ2gg0hSYNQrJ8RilYldYQ1FxQYoCLtUjuuRuZo+fjqhx/qtq/1itJ0C2ejDxltZVFg=="
            crossorigin="anonymous"
            asp-fallback-src="~/lib/jquery/dist/jquery.min.js"
            asp-fallback-test="window.jQuery">
    </script>

    <script src="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.5.3/js/bootstrap.min.js"
            integrity="sha512-8qmis31OQi6hIRgvkht0s6mCOittjMa9GMqtK9hes5iEQBQE/Ca6yGE5FsW36vyipGoWQswBj/QBm2JR086Rkw=="
            crossorigin="anonymous"
            asp-fallback-src="~/lib/bootstrap/dist/js/bootstrap.bundle.min.js"
            asp-fallback-test="window.jQuery && window.jQuery.fn && window.jQuery.fn.modal">
    </script>
</environment>

<script src="~/js/site.js" asp-append-version="true"></script>
@await RenderSectionAsync("Scripts", required: false)
</body>
</html>
```

## Wrapping Up

I hope this helps you.  In a future post, I'll add how I can use Yarn in my build scripts so I don't have to check in all of the package contents.
