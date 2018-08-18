FROM microsoft/dotnet:2.1-aspnetcore-runtime
LABEL maintainer "frank@pommerening-online.de"
ENV REFRESHED_AT 2018-08-18


COPY /app /home/

RUN set -x \
	&& mkdir /app/ \
    && tar -xzf /home/webapp.tar.gz -C /app/
	
WORKDIR /app/
ENV ASPNETCORE_URLS http://0.0.0.0:4000
EXPOSE 4000
ENTRYPOINT ["dotnet", "BuildOutside.dll"]