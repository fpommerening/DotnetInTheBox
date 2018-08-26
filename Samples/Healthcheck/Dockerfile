FROM microsoft/dotnet:2.1-sdk AS builder

WORKDIR /app
COPY src /app
RUN dotnet restore Healthcheck.csproj
RUN dotnet publish --configuration Release --output ./out


FROM microsoft/dotnet:2.1-aspnetcore-runtime
LABEL maintainer "frank@pommerening-online.de"
ENV ASPNETCORE_URLS http://0.0.0.0:5000
EXPOSE 5000
WORKDIR /app/

COPY --from=builder /app/out/* ./

HEALTHCHECK --interval=5s --timeout=20s --start-period=5s --retries=3 CMD curl -f http://localhost:5000/api/healthcheck || exit 1

ENV REFRESHED_AT 2018-08-26

ENTRYPOINT ["dotnet", "Healthcheck.dll"]