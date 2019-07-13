FROM mcr.microsoft.com/dotnet/core/sdk:2.1
LABEL maintainer "frank@pommerening-online.de"
ENV REFRESHED_AT 2018-08-16

ENV ASPNETCORE_URLS http://0.0.0.0:5000
EXPOSE 5000

COPY WebApp /WebApp
RUN cd /WebApp && dotnet restore && dotnet build
WORKDIR /WebApp
ENTRYPOINT ["dotnet", "run"]
