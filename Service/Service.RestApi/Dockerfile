#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Service/Service.RestApi/Service.RestApi.csproj", "Service/Service.RestApi/"]
COPY ["Service/Service.Models/Service.Models.csproj", "Service/Service.Models/"]
COPY ["Service/Service.Domain.EntityFramework/Service.Domain.EntityFramework.csproj", "Service/Service.Domain.EntityFramework/"]
COPY ["Service/Service.Domain/Service.Domain.csproj", "Service/Service.Domain/"]
COPY ["Service/Service.Services/Service.Services.csproj", "Service/Service.Services/"]
RUN dotnet restore "Service/Service.RestApi/Service.RestApi.csproj"
COPY . .
WORKDIR "/src/Service/Service.RestApi"
RUN dotnet build "Service.RestApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Service.RestApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Service.RestApi.dll"]