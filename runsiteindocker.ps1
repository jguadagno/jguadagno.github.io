docker run --rm --volume=$(pwd):/srv/jekyll -p 4000:4000 --env JEKYLL_GITHUB_TOKEN=$ENV:JEKYLL_GITHUB_TOKEN jekyll/jekyll:latest gem install bundler:2.2.24 && bundle install && bundler exec jekyll serve