FROM mcr.microsoft.com/dotnet/core/sdk:2.2
LABEL maintainer "frank@pommerening-online.de"
ENV REFRESHED_AT 2019-07-15


EXPOSE 5000

COPY WebApp /WebApp
RUN cd /WebApp && dotnet restore && dotnet build
WORKDIR /WebApp
ENTRYPOINT [ "dotnet", "watch", "run", "--no-restore", "--urls", "http://0.0.0.0:5000"]
