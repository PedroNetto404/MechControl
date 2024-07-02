FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

COPY ["MechControl.Api/MechControl.Api.csproj", "MechControl.Api/"]

COPY ["MechControl.Application/MechControl.Application.csproj", "MechControl.Application/"]

COPY ["MechControl.Domain/MechControl.Domain.csproj", "MechControl.Domain/"]

COPY ["MechControl.Infrastructure/MechControl.Infrastructure.csproj", "MechControl.Infrastructure/"]

RUN dotnet restore "MechControl.Api/MechControl.Api.csproj"

COPY . .

WORKDIR "/src/MechControl.Api"

RUN dotnet build "MechControl.Api.csproj" -c Release -o /app/build

# Publish
FROM build AS publish

RUN dotnet publish "MechControl.Api.csproj" -c Release -o /app/publish

# Final
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final

WORKDIR /app

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "MechControl.Api.dll"]

EXPOSE 80