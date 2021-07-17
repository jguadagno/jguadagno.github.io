# Installation Instructions

This document contains the installation instructions for setting up and building this site locally.  It does not cover the create of the GitHub [pages](https://pages.github.com/) site.

## Ruby Installation

[Jekyll](https://jekyllrb.com/) requires Ruby version 2.4.0 or higher, including the development headers. [Jekyll Install Docs](https://jekyllrb.com/docs/installation/)

Windows Download: [Ruby 2.7.4.1](https://github.com/oneclick/rubyinstaller2/releases/download/RubyInstaller-2.7.4-1/rubyinstaller-2.7.4-1-x64.exe)

After the install, you are prompted to install/update the Devkit. When presented with the options 1,3 just hit enter or option 3.

Open up a new terminal or command prompt and check the version of Ruby.

```bash
ruby -v
```

The output should be something like `ruby 2.7.4p191 (2021-07-07 revision a21a3b7d23) [x64-mingw32]`

## Machine Configuration

Because the Jekyll site uses a remote theme, [Minimal Mistakes](https://github.com/mmistakes/minimal-mistakes), we have to add a System Environment variable with the Github Personal Access token.  Acquire a token from [Personal access tokens](https://github.com/settings/tokens) from Github.

Create an environment variable named `JEKYLL_GITHUB_TOKEN` with the value of the personal access token.

## Jekyll Install

This repository should have everything needed to get started.  Navigate to the repository in a terminal or command prompt. Example:

```bash
cd c:\Projects\jguadagno.github.io
```

Then add/install all the Gems with the following command

```bash
bundle install
```

After the successful updating of Gems, verify the site

```bash
bundle exec jekyll serve
```

This should "*compile*" and generate the site. The site is accessible at [http://127.0.0.1:4000](http://127.0.0.1:4000).
