FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 80

# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Smooth.Flaunt.Api/src/Smooth.Flaunt.Api/Smooth.Flaunt.Api.csproj", "Smooth.Flaunt.Api/src/Smooth.Flaunt.Api/"]
COPY ["Smooth.Flaunt.Api/src/Smooth.Flaunt.Api.Application/Smooth.Flaunt.Api.Application.csproj", "Smooth.Flaunt.Api/src/Smooth.Flaunt.Api.Application/"]
COPY ["Smooth.Flaunt.Api/src/Smooth.Flaunt.Api.Infrastructure/Smooth.Flaunt.Api.Infrastructure.csproj", "Smooth.Flaunt.Api/src/Smooth.Flaunt.Api.Infrastructure/"]
COPY ["Smooth.Flaunt.Api/src/Smooth.Flaunt.Shared/Smooth.Flaunt.Shared.csproj", "Smooth.Flaunt.Shared/src/Smooth.Flaunt.Shared/"]
RUN dotnet restore "./Smooth.Flaunt.Api/src/Smooth.Flaunt.Api/Smooth.Flaunt.Api.csproj"
COPY . .
WORKDIR "/src/Smooth.Flaunt.Api/src/Smooth.Flaunt.Api"
RUN dotnet build "./Smooth.Flaunt.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Smooth.Flaunt.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Smooth.Flaunt.Api.dll"]