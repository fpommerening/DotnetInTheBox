FROM microsoft/dotnet:1.0.5-core
LABEL maintainer "frank@pommerening-online.de"
ENV REFRESHED_AT 2017-05-21

COPY /app /home/

RUN set -x \
	&& mkdir /app/ \
    && tar -xzf /home/mongomessage.tar.gz -C /app/

WORKDIR /app/
EXPOSE 5000
ENTRYPOINT ["dotnet", "MongoMessage.dll"]