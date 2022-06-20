FROM ruby

# Set default locale for the environment
ENV LC_ALL C.UTF-8
ENV LANG en_US.UTF-8
ENV LANGUAGE en_US.UTF-8

RUN gem install bundler
RUN gem install jekyll -v 3.9

WORKDIR /src
COPY Gemfile Gemfile.lock /src/
RUN bundle install

EXPOSE 4000

