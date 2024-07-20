FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build


WORKDIR /src

COPY ["src/MechControl.Api/MechControl.Api.csproj", "src/MechControl.Api/"]
COPY ["src/MechControl.Application/MechControl.Application.csproj", "src/MechControl.Application/"]
COPY ["src/MechControl.Domain/MechControl.Domain.csproj", "src/MechControl.Domain/"]
COPY ["src/MechControl.Infrastructure/MechControl.Infrastructure.csproj", "src/MechControl.Infrastructure/"]

RUN dotnet restore "src/MechControl.Api/MechControl.Api.csproj"

COPY . .

RUN dotnet build "src/MechControl.Api/MechControl.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "src/MechControl.Api/MechControl.Api.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

COPY --from=publish /app/publish .

ENV ASPNETCORE_URLS=http://+:5678

ENTRYPOINT ["dotnet", "MechControl.Api.dll"]

EXPOSE 5678