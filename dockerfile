FROM ruby:2.6
RUN gem install jekyll bundler
WORKDIR /src
COPY Gemfile Gemfile.lock /src/
RUN bundle install
EXPOSE 35729
EXPOSE 4000
