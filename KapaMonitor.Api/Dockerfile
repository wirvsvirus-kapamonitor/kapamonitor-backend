FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["KapaMonitor.Api/KapaMonitor.Api.csproj", "KapaMonitor.Api/"]
COPY ["KapaMonitor.Application/KapaMonitor.Application.csproj", "KapaMonitor.Application/"]
COPY ["KapaMonitor.Database/KapaMonitor.Database.csproj", "KapaMonitor.Database/"]
COPY ["KapaMonitor.Domain/KapaMonitor.Domain.csproj", "KapaMonitor.Domain/"]
RUN dotnet restore "KapaMonitor.Api/KapaMonitor.Api.csproj"
COPY . .
WORKDIR "/src/KapaMonitor.Api"
RUN dotnet build "KapaMonitor.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KapaMonitor.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KapaMonitor.Api.dll"]
