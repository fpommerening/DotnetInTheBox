FROM microsoft/dotnet:2.0.0-sdk-jessie AS builder

WORKDIR /WebApp
COPY src/WebApp /WebApp
RUN dotnet restore RaspberryPi.csproj
RUN dotnet publish --configuration Release --output ./app  -r linux-arm



FROM microsoft/aspnetcore:2.0.0-runtime-stretch-arm32v7
LABEL maintainer "frank@pommerening-online.de"
ENV REFRESHED_AT 2017-10-31

WORKDIR /app

COPY --from=builder /WebApp/app/* ./

ENV ASPNETCORE_URLS http://0.0.0.0:5000
EXPOSE 5000
ENTRYPOINT ["dotnet", "RaspberryPi.dll" ]
