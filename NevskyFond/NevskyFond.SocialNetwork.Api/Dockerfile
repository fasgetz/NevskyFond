#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Development
WORKDIR /src
COPY ["NevskyFond.SocialNetwork.Api/NevskyFond.SocialNetwork.Api.csproj", "NevskyFond.SocialNetwork.Api/"]
COPY ["NevskyFond.SocialNetwork.Infrastructure/NevskyFond.SocialNetwork.Infrastructure.csproj", "NevskyFond.SocialNetwork.Infrastructure/"]
COPY ["NevskyFond.SocialNetwork.Communication/NevskyFond.SocialNetwork.Communication.csproj", "NevskyFond.SocialNetwork.Communication/"]
COPY ["NevskyFond.SocialNetwork.Data/NevskyFond.SocialNetwork.Data.csproj", "NevskyFond.SocialNetwork.Data/"]
COPY ["NevskyFond.SocialNetwork.Domain/NevskyFond.SocialNetwork.Domain.csproj", "NevskyFond.SocialNetwork.Domain/"]
RUN dotnet restore "./NevskyFond.SocialNetwork.Api/./NevskyFond.SocialNetwork.Api.csproj"
COPY . .
WORKDIR "/src/NevskyFond.SocialNetwork.Api"
RUN dotnet build "./NevskyFond.SocialNetwork.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Development
RUN dotnet publish "./NevskyFond.SocialNetwork.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NevskyFond.SocialNetwork.Api.dll"]