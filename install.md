# Installation Instructions

This document contains the installation instructions for setting up and building this site locally.  It does not cover the creation of the GitHub [pages](https://pages.github.com/)  site.

There are two ways to build and test the site locally.  The first way is with [Docker](#running-with-docker) and the second is running it [locally with Ruby](#running-locally-with-ruby). The first option on requires Docker to be installed on your local machine. The second option, requires installing Ruby on your machine and some other required tools. Both options required the [machine configuration](#machine-configuration) which creates a local environment variable to avoid committing keys and secrets.

## Machine Configuration

Because the Jekyll site uses a remote theme, [Minimal Mistakes](https://github.com/mmistakes/minimal-mistakes){:target="_blank"}, we have to add a System Environment variable with the Github Personal Access token.  Acquire a token from [Personal access tokens](https://github.com/settings/tokens) from Github.

Create an environment variable named `JEKYLL_GITHUB_TOKEN` with the value of the personal access token.

## Running with Docker

Execute the following command to build the site for local development

```bash
docker build -f dockerfile -t jekyll . --no-cache
docker-compose -f docker-compose.yml up
```

## Running the site

This should "*compile*" and generate the site. The site is accessible at [http://127.0.0.1:4000](http://127.0.0.1:4000).
