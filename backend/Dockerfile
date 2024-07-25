FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

COPY src/MechControl.Api/MechControl.Api.csproj MechControl.Api/
COPY src/MechControl.Application/MechControl.Application.csproj MechControl.Application/
COPY src/MechControl.Domain/MechControl.Domain.csproj MechControl.Domain/
COPY src/MechControl.Infrastructure/MechControl.Infrastructure.csproj MechControl.Infrastructure/

RUN dotnet restore MechControl.Api/MechControl.Api.csproj

COPY src/ .

RUN dotnet build MechControl.Api/MechControl.Api.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish MechControl.Api/MechControl.Api.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

RUN apt-get update && apt-get install -y curl gnupg procps

RUN apt-get update && apt-get install -y unzip \
    && curl -sSL https://aka.ms/getvsdbgsh | bash /dev/stdin -v latest -l /vsdbg

COPY --from=publish /app/publish .

ENV ASPNETCORE_URLS=http://+:5678;https://+:5679

ENTRYPOINT ["dotnet", "MechControl.Api.dll"]

EXPOSE 5678
EXPOSE 5679
EXPOSE 9229
