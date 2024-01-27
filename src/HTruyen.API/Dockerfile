FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["HTruyen.API/HTruyen.API.csproj", "HTruyen.API/"]
COPY ["Core/Core.csproj", "Core/"]
RUN dotnet restore "./HTruyen.API/./HTruyen.API.csproj"
COPY . .
WORKDIR "/src/HTruyen.API"
RUN dotnet build "./HTruyen.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./HTruyen.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HTruyen.API.dll"]
