FROM microsoft/dotnet:2.1-sdk-nanoserver-sac2016 AS builder

WORKDIR /WebApp
COPY WebApp /WebApp
RUN dotnet restore BuildMultistage.csproj
RUN dotnet publish --configuration Release --output ./app



FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-sac2016
LABEL maintainer "frank@pommerening-online.de"
ENV REFRESHED_AT 2018-08-18

WORKDIR /app

COPY --from=builder c:/WebApp/app/ c:/app/

ENV ASPNETCORE_URLS http://0.0.0.0:5000
EXPOSE 5000
ENTRYPOINT ["dotnet", "BuildMultistage.dll" ]
