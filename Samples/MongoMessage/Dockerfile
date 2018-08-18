FROM microsoft/dotnet:2.1-sdk AS builder

WORKDIR /WebApp
COPY src /WebApp
RUN dotnet restore MongoMessage.csproj
RUN dotnet publish --configuration Release --output ./app



FROM microsoft/dotnet:2.1-aspnetcore-runtime
LABEL maintainer "frank@pommerening-online.de"
ENV REFRESHED_AT 2018-08-18

WORKDIR /app

COPY --from=builder /WebApp/app/* ./

ENV ASPNETCORE_URLS http://0.0.0.0:5000
EXPOSE 5000
ENTRYPOINT ["dotnet", "MongoMessage.dll" ]
