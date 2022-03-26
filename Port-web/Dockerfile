#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Port-web/Port-web.csproj", "Port-web/"]
RUN dotnet restore "Port-web/Port-web.csproj"
COPY . .
WORKDIR "/src/Port-web"
RUN dotnet build "Port-web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Port-web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Port-web.dll"]