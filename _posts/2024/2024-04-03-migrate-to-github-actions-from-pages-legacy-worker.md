---
title: "Migrate to GitHub Actions from Pages Legacy Worker"
header:
    og_image: /assets/images/posts/header/github-migrate.png
date: 2024-04-03 16:45:00 -0700
categories:
- Articles
tags:
- GitHub
- Jekyll
- GitHub Actions
---
GitHub Pages has deprecated the legacy worker and will be removed by the end of June 2024. The legacy worker was used to build and deploy Jekyll sites on GitHub Pages. The new way to build and deploy Jekyll sites on GitHub Pages is to use GitHub Actions. This post will show you how to migrate your Jekyll site from the legacy worker to GitHub Actions.

## Are you using the legacy worker?

If you received an email from GitHub titled, "***Important Announcement Re: Pages Legacy Worker Sunset***", you are likely using GitHub Pages with the legacy worker. If you are unsure if you are using the legacy worker you can check your repository settings.

* Go to the repository settings, click on the "Pages" tab, scroll down to "Build and Deployment", the *Source* would be set to `Deploy from a branch` similar to the image below

![Build and Deployment](/assets/images/posts/2024/migrate-to-github-actions/migrate-to-github-actions-source.png)

If you already migrated to GitHub Actions, you will see the `Source` set to `GitHub Actions` and you should have a workflow file in the `.github\workflows` folder.

## Migrate to GitHub Actions

To migrate to GitHub Actions, you will need to create a workflow file in the `.github\workflows` folder. The workflow file will build and deploy your Jekyll site to GitHub Pages. Below is an example of a workflow file that builds and deploys a Jekyll site to GitHub Pages.

Navigate to the *Settings* page of your repository, click on the *Pages* tab, and scroll to *Build and deployment. Change the *Source* to `GitHub Actions`.  The page should update with two options, `GitHub Page Jekyll` and `Static HTML`. Choose the appropriate option for your site.

![GitHub Action Template](/assets/images/posts/2024/migrate-to-github-actions/migrate-to-github-actions-template.png)

If you are using Jekyll, choose the `GitHub Page Jekyll` option. If you are using static HTML, choose the `Static HTML` option. The templates are below.  If you do not need to modify the template you can click on *Commit changes* and GitHub will create the workflow file for you.

### Jekyll Workflow Template

```yaml
# Sample workflow for building and deploying a Jekyll site to GitHub Pages
name: Deploy Jekyll with GitHub Pages dependencies preinstalled

on:
  # Runs on pushes targeting the default branch
  push:
    branches: ["main"]

  # Allows you to run this workflow manually from the Actions tab
  workflow_dispatch:

# Sets permissions of the GITHUB_TOKEN to allow deployment to GitHub Pages
permissions:
  contents: read
  pages: write
  id-token: write

# Allow only one concurrent deployment, skipping runs queued between the run in-progress and latest queued.
# However, do NOT cancel in-progress runs as we want to allow these production deployments to complete.
concurrency:
  group: "pages"
  cancel-in-progress: false

jobs:
  # Build job
  build:
    runs-on: ubuntu-latest
    steps:
      - name: Checkout
        uses: actions/checkout@v4
      - name: Setup Pages
        uses: actions/configure-pages@v5
      - name: Build with Jekyll
        uses: actions/jekyll-build-pages@v1
        with:
          source: ./
          destination: ./_site
      - name: Upload artifact
        uses: actions/upload-pages-artifact@v3

  # Deployment job
  deploy:
    environment:
      name: github-pages
      url: ${{ steps.deployment.outputs.page_url }}
    runs-on: ubuntu-latest
    needs: build
    steps:
      - name: Deploy to GitHub Pages
        id: deployment
        uses: actions/deploy-pages@v4
```

### Static HTML Workflow Template

```yaml
# Simple workflow for deploying static content to GitHub Pages
name: Deploy static content to Pages

on:
  # Runs on pushes targeting the default branch
  push:
    branches: ["main"]

  # Allows you to run this workflow manually from the Actions tab
  workflow_dispatch:

# Sets permissions of the GITHUB_TOKEN to allow deployment to GitHub Pages
permissions:
  contents: read
  pages: write
  id-token: write

# Allow only one concurrent deployment, skipping runs queued between the run in-progress and latest queued.
# However, do NOT cancel in-progress runs as we want to allow these production deployments to complete.
concurrency:
  group: "pages"
  cancel-in-progress: false

jobs:
  # Single deploy job since we're just deploying
  deploy:
    environment:
      name: github-pages
      url: ${{ steps.deployment.outputs.page_url }}
    runs-on: ubuntu-latest
    steps:
      - name: Checkout
        uses: actions/checkout@v4
      - name: Setup Pages
        uses: actions/configure-pages@v5
      - name: Upload artifact
        uses: actions/upload-pages-artifact@v3
        with:
          # Upload entire repository
          path: '.'
      - name: Deploy to GitHub Pages
        id: deployment
        uses: actions/deploy-pages@v4
```

### Building your site

Based on the default workflow templates, GitHub Actions will build your site on pushes to the default branch (`main`). If you need to build your site on pushes to other branches, you can modify the `branches` key in the `on` section of the workflow file.

## Using Jekyll and Remote Themes

If you are using Jekyll with remote theme, and the remote theme is specified in the `_config.yml` file, you will need to add the GitHub Token to the workflow file in order to load the theme during the build. The GitHub Token is required to access GitHub from your action and use the remote theme.  If you do not have a GitHub token when your site is build you will a warning during the build process

GitHub Metadata: No GitHub API authentication could be found. Some fields may be missing or have incorrect data.
{: .notice--warning}

Your site will still build but it will not look like you intended.

### Getting the GitHub Token

1. Sign in to GitHub and in the upper right hand corner click on your profile picture and select *Settings*.
2. In the left sidebar, click on *Developer Settings*.
3. In the left sidebar, click on *Personal access tokens*.
4. Click *Tokens (Classic)*.
5. Click on *Generate new token (classic)*.
6. Authenticate, if required.
7. For the note, enter a descriptive name for the token. Example: `JEKYLL_GITHUB_TOKEN`.
8. Under `repo`, select `public_repo`
9. Click *Generate token*.

Copy this token and store it in a secure location. You will need it later and you can not get it back once you leave the page.

Navigate back to the settings of your repository. Click on the *Secrets and variables* tab. Click on *Actions*. Click on *New repository secret*. Enter the following information:

| Name | Value |
| Name | `JEKYLL_GITHUB_TOKEN` *or something similar* |
| Secret | *Paste the token you copied earlier* |

* Click *Add Secret*

### Add GitHub Token to the Workflow File

Now we need to update the workflow file to use the token.

Edit the workflow file in your favorite editor to add the token to the environment.  If you used the default template, look in the `build` task for the *step* of `Build with Jekyll`, it should be around line 45. For this step we need to add an addition `env` key for the token.  The updated step should look like the following:

```yaml
      - name: Build with Jekyll
        # Outputs to the './_site' directory by default
        run: bundle exec jekyll build --baseurl "${{ steps.pages.outputs.base_path }}"
        env:
          JEKYLL_ENV: production
          {% raw %}JEKYLL_GITHUB_TOKEN: ${{ secrets.JEKYLL_GITHUB_TOKEN }}{% endraw %}
```

* Replace `secrets.JEKYLL_GITHUB_TOKEN` with the name you used when you added the secret in the previous step.

Save and commit the changes to your repository.  Once saved, the workflow will run and build your site.

## Wrap Up

This should be all you need to migrate a GitHub Pages site from the legacy worker to GitHub Actions. If you have any questions or need help, please feel free to reach out to me on [Twitter](https://twitter.com/jguadagno){:target="_blank"}.

## References

* [GitHub Actions Documentation](https://docs.github.com/en/actions){:target="_blank"}
* [GitHub Pages and Jekyll](https://docs.github.com/en/pages/setting-up-a-github-pages-site-with-jekyll/about-github-pages-and-jekyll){:target="_blank"}
* [Using custom workflows with GitHub pages](https://docs.github.com/en/pages/getting-started-with-github-pages/using-custom-workflows-with-github-pages){:target="_blank"}
* [GitHub Workflow Action for JosephGuadagno.NET](https://github.com/jguadagno/jguadagno.github.io/blob/main/.github/workflows/jekyll.yml){:target="_blank"}
