---
title: "The Technology Behind MoreSpeakers.com"
excerpt: "In this post, we delve into the technology stack and development process behind MoreSpeakers.com, a platform dedicated to connecting aspiring speakers with experienced mentors in the technology community."
header:
    og_image: /assets/images/posts/header/the-technology-behind-morespeakers-com.png
date: 2026-01-30 08:01:00 -0700

categories:
- Articles
tags:
- .NET
- dotnet
- Development
- csharp
- Community
- Bootstrap
- ASP.NET
- Microsoft Azure
- Azure Functions
- Aspire
---
In my previous [post]({% post_url 2026/2026-01-30-introducing-morespeakers-com %}){:target="_blank" rel="noopener"} , I introduced [MoreSpeakers.com](https://morespeakers.com){:target="_blank" rel="noopener"}, a platform dedicated to connecting aspiring speakers with experienced mentors in the technology community. In this post, I want to share some insights into the technology stack and development process behind MoreSpeakers.com.

## Technology Used

MoreSpeakers.com is built using a combination of modern web technologies to ensure an user-friendly experience.

### Development Stack

Tools and frameworks used in the development of MoreSpeakers.com include.

#### Tools

- JetBrains [Rider](https://www.jetbrains.com/rider/){:target="_blank" rel="noopener"}: The primary IDE used for development, providing a robust environment for C# and web development.
- [Azure Storage Explorer](https://azure.microsoft.com/en-us/features/storage-explorer/){:target="_blank" rel="noopener"}: Used for managing Azure Storage resources.
- [GitHub](https://github.com){:target="_blank" rel="noopener"}: For version control and collaboration among the development team.
- Microsoft [Azure](https://azure.microsoft.com){:target="_blank" rel="noopener"}: Hosting and deployment of the application.
- [Aspire](https://www.aspire.dev){:target="_blank" rel="noopener"}: Used for to help manage dependencies and ensure an easier on boarding for new engineers.

#### Frameworks and Libraries

- **Frontend**
  - The frontend is built using [Bootstrap 5](https://getbootstrap.com){:target="_blank" rel="noopener"} for responsive design and a clean user interface.
  - [HTMX](https://htmx.org){:target="_blank" rel="noopener"} is used to enhance interactivity and provide a seamless user experience without the need for heavy JavaScript frameworks.
- **Backend**
  - The backend is developed using [ASP.NET Core](https://dotnet.microsoft.com/en-us/apps/aspnet){:target="_blank" rel="noopener"}, providing a robust and scalable foundation for the application.
  - [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/){:target="_blank" rel="noopener"} is used for data access and management, allowing for efficient interaction with the database.
  - [SQL Server](https://www.microsoft.com/en-us/sql-server){:target="_blank" rel="noopener"} serves as the primary database for storing user profiles, mentorship requests, and other application data.

You can read more about the [architecture](https://github.com/cwoodruff/morespeakers-com/blob/main/docs/developer-startup.md){:target="_blank" rel="noopener"} and [developer](https://github.com/cwoodruff/morespeakers-com/blob/main/docs/developer-startup.md){:target="_blank" rel="noopener"} start up of MoreSpeakers.com in the GitHub repository.

### AI and Vibe Coding

AI and "*Vibe Coding*" is all the rage these days. As I mentioned in the previous [post]({% post_url 2026/2026-01-30-introducing-morespeakers-com %}){:target="_blank" rel="noopener"}, this project was prototyped with [Claude Code](https://claude.com/product/claude-code){:target="_blank" rel="noopener"}. Now while the application compiled and ran, it was a mess. It took some time to get the project in a maintainable state.

Since then, we have continued to use AI tools to help with various aspects of the development process. I primarily used JetBrains [Junie](https://www.jetbrains.com/junie/){:target="_blank" rel="noopener"} to help me with code generation, unit test creation, refactoring, and documentation. We've also used [GitHub Copilot](https://docs.github.com/en/copilot){:target="_blank" rel="noopener"} to help with code reviews of pull requests.  We've used [ChatGPT](https://chat.openai.com){:target="_blank" rel="noopener"} to help with the hero images and generating a lists of features to include in the platform. While AI has been a helpful tool throughout the development process, it is important to note that you still need skilled developers to "double-check" the work guide the process and ensure the quality of the final product.

#### AI Instructions

We used the following instructions when using AI tools to help with the development of MoreSpeakers.com.

##### Claude Code Instructions

[Claude Code](https://claude.com/product/claude-code){:target="_blank" rel="noopener"} allows you to create custom instructions to guide Claude in generating code and assisting with development tasks.

Our instructions are organized into two main categories: Commands and Skills. For overall instructions for Claude Code, we have:

- [Claude.md](https://github.com/cwoodruff/morespeakers-com/blob/main/CLAUDE.md){:target="_blank" rel="noopener"}: Instructions for using Claude to generate code snippets and assist with development tasks.

###### Claude Code Commands

- Claude [Commands](https://github.com/cwoodruff/morespeakers-com/tree/main/.claude/commands){:target="_blank" rel="noopener"}: A collection of custom commands to streamline the use of Claude in the development process.
  - [db-change.md](https://github.com/cwoodruff/morespeakers-com/blob/main/.claude/commands/db-change.md){:target="_blank" rel="noopener"}: Instructions for making database schema changes using Claude.
  - [docs.md](https://github.com/cwoodruff/morespeakers-com/blob/main/.claude/commands/docs.md){:target="_blank" rel="noopener"}: Instructions for generating documentation using Claude.
  - [feature.md](https://github.com/cwoodruff/morespeakers-com/blob/main/.claude/commands/feature.md){:target="_blank" rel="noopener"}: Instructions for adding new features using Claude.
  - [test.md](https://github.com/cwoodruff/morespeakers-com/blob/main/.claude/commands/test.md){:target="_blank" rel="noopener"}: Instructions for creating and running tests using Claude.

###### Claude Code Skills

- Claude [Skills](https://github.com/cwoodruff/morespeakers-com/blob/main/.claude/skills){:target="_blank" rel="noopener"}: A set of predefined skills to enhance the capabilities of Claude in the development process.
  - [dotnet-feature](https://github.com/cwoodruff/morespeakers-com/blob/main/.claude/skills/dotnet-feature/SKILL.md){:target="_blank" rel="noopener"}: A skill for generating .NET features using Claude.
  - [qa-engineer](https://github.com/cwoodruff/morespeakers-com/blob/main/.claude/skills/qa-engineer/SKILL.md){:target="_blank" rel="noopener"}: A skill for performing quality assurance tasks using Claude.
  - [sql-schema](https://github.com/cwoodruff/morespeakers-com/blob/main/.claude/skills/sql-schema/SKILL.md){:target="_blank" rel="noopener"}: A skill for managing SQL schemas using Claude.

##### GitHub Copilot Instructions

GitHub Copilot allows you to create customize how GitHub Copilot responds to your prompts by creating custom instructions.

According to the [documentation](https://docs.github.com/en/copilot/concepts/prompting/response-customization){:target="_blank" rel="noopener"}, you can create custom instructions to guide GitHub Copilot's responses.

> GitHub Copilot can provide responses that are tailored to your personal preferences, the way your team works, the tools you use, or the specifics of your project, if you provide it with enough context to do so. Instead of repeatedly adding this contextual detail to your prompts, you can create custom instructions that automatically add this information for you. The additional information is not displayed, but is available to Copilot to allow it to generate higher quality responses.

We build a couple of task based agents/instructions to help with various development tasks. Here are the instructions we used for MoreSpeakers.com:

###### GitHub Agents

- [Agents.md](https://github.com/cwoodruff/morespeakers-com/blob/main/.github/agents/agents.md){:target="_blank" rel="noopener"}: Instructions for using GitHub Copilot Agents to automate development tasks.
- [api-agent.md](https://github.com/cwoodruff/morespeakers-com/blob/main/.github/agents/api-agent.md){:target="_blank" rel="noopener"}: An agent for managing API-related tasks using GitHub Copilot.
- [dev-deploy-agent.md](https://github.com/cwoodruff/morespeakers-com/blob/main/.github/agents/dev-deploy-agent.md){:target="_blank" rel="noopener"}: An agent for handling development and deployment tasks using GitHub Copilot.
- [docs-agent.md](https://github.com/cwoodruff/morespeakers-com/blob/main/.github/agents/docs-agent.md){:target="_blank" rel="noopener"}: An agent for managing documentation tasks using GitHub Copilot.
- [lint-agent.md](https://github.com/cwoodruff/morespeakers-com/blob/main/.github/agents/lint-agent.md){:target="_blank" rel="noopener"}: An agent for performing linting tasks using GitHub Copilot.
- [test-agent.md](https://github.com/cwoodruff/morespeakers-com/blob/main/.github/agents/test-agent.md){:target="_blank" rel="noopener"}: An agent for managing testing tasks using GitHub Copilot.

##### JetBrains Junie Instructions

[JetBrains Junie](https://www.jetbrains.com/junie/){:target="_blank" rel="noopener"} allows you to create custom instructions to guide Junie in generating code and assisting with development tasks. Instructions for customizing Junie can be found in the [documentation](https://www.jetbrains.com/help/junie/customize-guidelines.html){:target="_blank" rel="noopener"}.

Our instructions for Junie are documented in the file [guidelines.md](https://github.com/cwoodruff/morespeakers-com/blob/main/src/.junie/guidelines.md){:target="_blank" rel="noopener"}.

### Want to Contribute?

If you want to help out with the project, the repository is available on [GitHub](https://github.com/cwoodruff/morespeakers-com){:target="_blank" rel="noopener"}. Find a bug, submit an issue and/or a pull request. We are open to [contributions](https://github.com/cwoodruff/morespeakers-com/blob/main/CONTRIBUTING.md){:target="_blank" rel="noopener"}, whether it's fixing bugs, adding new features, or improving documentation.

## Wrap Up

As you can see, MoreSpeakers.com is built using a combination of modern web technologies and AI tools to provide a seamless user experience. The development process has been greatly enhanced by the use of AI, allowing us to focus on building a platform that truly meets the needs of aspiring speakers and experienced mentors in the technology community.

## References

- [MoreSpeakers.com](https://morespeakers.com){:target="_blank" rel="noopener"}
- [GitHub Repository](https://github.com/cwoodruff/morespeakers-com){:target="_blank" rel="noopener"}
- [Bootstrap 5](https://getbootstrap.com){:target="_blank" rel="noopener"}
- [ASP.NET Core](https://dotnet.microsoft.com/en-us/apps/aspnet){:target="_blank" rel="noopener"}
- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/){:target="_blank" rel="noopener"}
- [Aspire](https://www.aspire.dev){:target="_blank" rel="noopener"}
- [HTMX](https://htmx.org){:target="_blank" rel="noopener}
- [ASP.NET Core Reimagined with HTMX book](https://aspnet-htmx.com/){:target="_blank" rel="noopener"}
- [JetBrains Rider](https://www.jetbrains.com/rider/){:target="_blank" rel="noopener"}
- [Claude Code](https://claude.com/product/claude-code){:target="_blank" rel="noopener"}
- [GitHub Copilot](https://docs.github.com/en/copilot){:target="_blank" rel="noopener"}
- [JetBrains Junie](https://www.jetbrains.com/junie/){:target="_blank" rel="noopener"}
- [ChatGPT](https://chat.openai.com){:target="_blank" rel="noopener"}
