FROM fpommerening/rpi-mono:wheezy
LABEL maintainer "frank@pommerening-online.de"
ENV REFRESHED_AT 2017-04-24

COPY /webapp /app/

WORKDIR /app/
EXPOSE 7777
ENTRYPOINT ["mono", "WebApp.exe"]
