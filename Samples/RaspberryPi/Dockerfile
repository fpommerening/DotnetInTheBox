FROM microsoft/dotnet:2.0-sdk-jessie AS builder

WORKDIR /WebApp
COPY src/WebApp /WebApp
RUN dotnet restore RaspberryPi.csproj
RUN dotnet publish --configuration Release --output ./app  -r linux-arm



FROM microsoft/dotnet:2.0-runtime-deps-stretch-arm32v7
LABEL maintainer "frank@pommerening-online.de"
ENV REFRESHED_AT 2018-01-24

WORKDIR /app

COPY --from=builder /WebApp/app/* ./

ENV ASPNETCORE_URLS http://0.0.0.0:5000
EXPOSE 5000
ENTRYPOINT ["dotnet", "RaspberryPi.dll" ]
