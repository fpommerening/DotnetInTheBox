FROM fpommerening/rpi-mono
LABEL maintainer "frank@pommerening-online.de"
ENV REFRESHED_AT 2017-03-11

COPY /webapp /app/

WORKDIR /app/
EXPOSE 7777
ENTRYPOINT ["mono", "WebApp.exe"]
