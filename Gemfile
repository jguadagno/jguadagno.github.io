source "https://rubygems.org"

# Hello! This is where you manage which Jekyll version is used to run.
# When you want to use a different version, change it below, save the
# file and run `bundle install`. Run Jekyll with `bundle exec`, like so:
#
#     bundle exec jekyll serve
#
# This will help ensure the proper Jekyll version is running.
# Happy Jekylling!

# This is the default theme for new Jekyll sites. You may change this to anything you like.
#gem "minima", "~> 2.0"
#gem "minimal-mistakes-jekyll"

# If you want to use GitHub Pages, remove the "gem "jekyll"" above and
# uncomment the line below. To upgrade, run `bundle update github-pages`.
gem "github-pages", group: :jekyll_plugins

gem 'jekyll-include-cache'

# If you have any plugins, put them here!
group :jekyll_plugins do
  
end

# Windows does not include zoneinfo files, so bundle the tzinfo-data gem
gem "tzinfo-data", platforms: [:mingw, :mswin, :x64_mingw, :jruby]

# Performance-booster for watching directories on Windows
gem "wdm", "~> 0.1.0" if Gem.win_platform?

# Override packages because a vulnerabilities
gem "faraday", "~> 2.7.1"
gem "faraday-retry"

# Needed as a dependency with Ruby 3.0 or higher
gem "webrick"

# Address dependabot alert: https://github.com/jguadagno/jguadagno.github.io/security/dependabot/36
gem "uri", ">= 1.0.3"

gem "csv"