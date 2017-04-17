FROM microsoft/dotnet:1.0.3-core
LABEL maintainer "frank@pommerening-online.de"
ENV REFRESHED_AT 2017-03-15

COPY /app /service/

RUN set -x \
    && apt-get update && apt-get install -y --no-install-recommends ca-certificates wget p7zip && rm -rf /var/lib/apt/lists/* \
    && p7zip -d /home/service.7z \
    && mv /service/ /app/ \
	&& apt-get purge -y --auto-remove ca-certificates wget p7zip

WORKDIR /app/
EXPOSE 4000
ENTRYPOINT ["dotnet", "Service.dll"]