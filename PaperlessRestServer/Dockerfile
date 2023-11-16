#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Container we use for final publish
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 8080

# Build container
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy the csproj file and restore dependencies
COPY ["NPaperless.Services/PaperlessRestServer.csproj", "NPaperless.Services/"]
COPY ["BusinessLogic/BusinessLogic.csproj", "BusinessLogic/"]
COPY ["BusinessLogic.Entities/BusinessLogic.Entities.csproj", "BusinessLogic.Entities/"]
COPY ["BusinessLogic.Interfaces/BusinessLogic.Interfaces.csproj", "BusinessLogic.Interfaces/"]

RUN dotnet restore "NPaperless.Services/PaperlessRestServer.csproj"

# Copy the rest of the source code into the container
COPY . .

WORKDIR "/src/NPaperless.Services"
# Build the API
RUN dotnet build "PaperlessRestServer.csproj" -c Release -o /app/build

# Publish it
FROM build AS publish
RUN dotnet publish "PaperlessRestServer.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Make the final image for publishing
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NPaperless.Services.dll"]
