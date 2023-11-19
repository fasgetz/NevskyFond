FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Development
WORKDIR /src
COPY ["NevskyFond.Encyclopedia.Api/NevskyFond.Encyclopedia.Api.csproj", "NevskyFond.Encyclopedia.Api/"]
COPY ["NevskyFond.Encyclopedia.Infrastructure/NevskyFond.Encyclopedia.Infrastructure.csproj", "NevskyFond.Encyclopedia.Infrastructure/"]
COPY ["NevskyFond.Encyclopedia.Data/NevskyFond.Encyclopedia.Data.csproj", "NevskyFond.Encyclopedia.Data/"]
COPY ["NevskyFond.Encyclopedia.Domain/NevskyFond.Encyclopedia.Domain.csproj", "NevskyFond.Encyclopedia.Domain/"]
COPY ["NevskyFond.SocialNetwork.Communication/NevskyFond.SocialNetwork.Communication.csproj", "NevskyFond.SocialNetwork.Communication/"]
RUN dotnet restore "./NevskyFond.Encyclopedia.Api/./NevskyFond.Encyclopedia.Api.csproj"
COPY . .
WORKDIR "/src/NevskyFond.Encyclopedia.Api"
RUN dotnet build "./NevskyFond.Encyclopedia.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Development
RUN dotnet publish "./NevskyFond.Encyclopedia.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NevskyFond.Encyclopedia.Api.dll"]