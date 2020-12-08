#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["OpenCommon.ServiceHost/OpenCommon.ServiceHost.csproj", "OpenCommon.ServiceHost/"]
RUN dotnet restore "OpenCommon.ServiceHost/OpenCommon.ServiceHost.csproj"
COPY . .
WORKDIR "/src/OpenCommon.ServiceHost"
RUN dotnet build "OpenCommon.ServiceHost.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OpenCommon.ServiceHost.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OpenCommon.ServiceHost.dll"]