FROM microsoft/dotnet:1.0.4-sdk
LABEL maintainer "frank@pommerening-online.de"
ENV REFRESHED_AT 2017-03-08

COPY WebApp /WebApp

RUN cd /WebApp && dotnet restore && dotnet build
WORKDIR /WebApp
EXPOSE 5000
ENTRYPOINT ["dotnet", "run"]
