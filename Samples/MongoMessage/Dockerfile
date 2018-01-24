FROM microsoft/dotnet:2.0-sdk-jessie AS builder

WORKDIR /WebApp
COPY src /WebApp
RUN dotnet restore MongoMessage.csproj
RUN dotnet publish --configuration Release --output ./app



FROM microsoft/aspnetcore:2.0-jessie
LABEL maintainer "frank@pommerening-online.de"
ENV REFRESHED_AT 2018-01-24

WORKDIR /app

COPY --from=builder /WebApp/app/* ./

ENV ASPNETCORE_URLS http://0.0.0.0:5000
EXPOSE 5000
ENTRYPOINT ["dotnet", "MongoMessage.dll" ]
