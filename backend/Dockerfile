# Use the SDK image to build the project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory
WORKDIR /src

# Copy the project files
COPY ["src/MechControl.Api/MechControl.Api.csproj", "src/MechControl.Api/"]
COPY ["src/MechControl.Application/MechControl.Application.csproj", "src/MechControl.Application/"]
COPY ["src/MechControl.Domain/MechControl.Domain.csproj", "src/MechControl.Domain/"]
COPY ["src/MechControl.Infrastructure/MechControl.Infrastructure.csproj", "src/MechControl.Infrastructure/"]

RUN dotnet restore "src/MechControl.Api/MechControl.Api.csproj"

# Copy the rest of the project files
COPY . .


# Build the project
RUN dotnet build "src/MechControl.Api/MechControl.Api.csproj" -c Release -o /app/build

# Publish the project
FROM build AS publish
RUN dotnet publish "src/MechControl.Api/MechControl.Api.csproj" -c Release -o /app/publish

# Use the ASP.NET runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copy the published files
COPY --from=publish /app/publish .

# Set the entry point
ENTRYPOINT ["dotnet", "MechControl.Api.dll"]

# Expose the port
EXPOSE 5678