#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ParkEasyNBP.API/ParkEasyNBP.API.csproj", "ParkEasyNBP.API/"]
COPY ["Infrastructure.MongoDB/ParkEasyNBP.Infrastructure.MongoDB.csproj", "Infrastructure.MongoDB/"]
COPY ["ParkEasyNBP.Domain/ParkEasyNBP.Domain.csproj", "ParkEasyNBP.Domain/"]
COPY ["Infrastructure.Neo4j/ParkEasyNBP.Infrastructure.Neo4j.csproj", "Infrastructure.Neo4j/"]
COPY ["ParkEasyNBP.Application/ParkEasyNBP.Application.csproj", "ParkEasyNBP.Application/"]
COPY ["ParkEasyNBP.Infrastructure.SqlServer/ParkEasyNBP.Infrastructure.SqlServer.csproj", "ParkEasyNBP.Infrastructure.SqlServer/"]
COPY ["Repository/Repository.csproj", "Repository/"]
RUN dotnet restore "./ParkEasyNBP.API/ParkEasyNBP.API.csproj"
COPY . .
WORKDIR "/src/ParkEasyNBP.API"
RUN dotnet build "./ParkEasyNBP.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ParkEasyNBP.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ParkEasyNBP.API.dll"]