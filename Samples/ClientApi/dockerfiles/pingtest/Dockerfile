FROM ubuntu:latest
LABEL maintainer "frank@pommerening-online.de"
ENV REFRESHED_AT 2017-05-21

RUN set -x \
    && apt-get update && apt-get install -y --no-install-recommends iputils-ping && rm -rf /var/lib/apt/lists/*
	