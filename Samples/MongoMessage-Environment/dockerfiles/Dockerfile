FROM microsoft/dotnet:1.0.4-core
LABEL maintainer "frank@pommerening-online.de"
ENV REFRESHED_AT 2017-03-27


COPY /app /home/

RUN set -x \
    && apt-get update && apt-get install -y --no-install-recommends p7zip && rm -rf /var/lib/apt/lists/* \
    && p7zip -d /home/mongomessage.7z \
    && mv /mongomessage/ /app/ \
	&& apt-get purge -y --auto-remove p7zip

WORKDIR /app/
EXPOSE 5000
ENTRYPOINT ["dotnet", "MongoMessage.dll"]