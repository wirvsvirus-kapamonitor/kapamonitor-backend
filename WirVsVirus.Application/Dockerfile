#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["WirVsVirus.Application/WirVsVirus.Application.csproj", "WirVsVirus.Application/"]
RUN dotnet restore "WirVsVirus.Application/WirVsVirus.Application.csproj"
COPY . .
WORKDIR "/src/WirVsVirus.Application"
RUN dotnet build "WirVsVirus.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WirVsVirus.Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WirVsVirus.Application.dll"]
