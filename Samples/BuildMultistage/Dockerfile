FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS builder

WORKDIR /WebApp
COPY WebApp /WebApp
RUN dotnet restore BuildMultistage.csproj
RUN dotnet publish --configuration Release --output ./app



FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
LABEL maintainer "frank@pommerening-online.de"
ENV REFRESHED_AT 2019-07-15

WORKDIR /app

COPY --from=builder /WebApp/app/* ./

ENV ASPNETCORE_URLS http://0.0.0.0:5000
EXPOSE 5000
ENTRYPOINT ["dotnet", "BuildMultistage.dll" ]
