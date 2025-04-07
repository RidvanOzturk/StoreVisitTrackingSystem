FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY StoreVisitTrackingSystem.sln ./
COPY StoreVisitTrackingSystem.Api/StoreVisitTrackingSystem.Api.csproj StoreVisitTrackingSystem.Api/
COPY StoreVisitTrackingSystem.Data/StoreVisitTrackingSystem.Data.csproj StoreVisitTrackingSystem.Data/
COPY StoreVisitTrackingSystem.Service/StoreVisitTrackingSystem.Service.csproj StoreVisitTrackingSystem.Service/
RUN dotnet restore

COPY . .
WORKDIR /src/StoreVisitTrackingSystem.Api
RUN dotnet build -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StoreVisitTrackingSystem.Api.dll"]
