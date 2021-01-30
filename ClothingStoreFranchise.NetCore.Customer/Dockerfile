#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 4550

ARG csproj=ClothingStoreFranchise.NetCore.Customers.csproj
ARG configuration=Release
ARG feed='--source "https://api.nuget.org/v3/index.json"'

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ClothingStoreFranchise.NetCore.Customers.csproj", "./"]
RUN dotnet restore "./ClothingStoreFranchise.NetCore.Customers.csproj" ${feed}
COPY . .
WORKDIR /src/.
RUN dotnet build "ClothingStoreFranchise.NetCore.Customers.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ClothingStoreFranchise.NetCore.Customers.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ClothingStoreFranchise.NetCore.Customers.dll"]