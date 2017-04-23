FROM microsoft/dotnet:1.0.4-core
LABEL maintainer "frank@pommerening-online.de"
ENV REFRESHED_AT 2017-04-23

COPY /app /home/

RUN set -x \
   && mkdir /app/ \
   && tar -xzf /home/webhook.tar.gz -C /app/

WORKDIR /app/
EXPOSE 4000
ENTRYPOINT ["dotnet", "Service.dll"]