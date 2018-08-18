FROM microsoft/dotnet:2.1-sdk AS builder

WORKDIR /app
COPY src /app
RUN dotnet restore Secrets.csproj
RUN dotnet publish --configuration Release --output ./out


FROM microsoft/dotnet:2.1-aspnetcore-runtime
LABEL maintainer "frank@pommerening-online.de"
ENV ASPNETCORE_URLS http://0.0.0.0:5000
EXPOSE 5000
WORKDIR /app/

COPY --from=builder /app/out/* ./

ENV REFRESHED_AT 2018-08-18

ENTRYPOINT ["dotnet", "Secrets.dll"]