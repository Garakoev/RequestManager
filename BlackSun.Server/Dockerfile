#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["BlackSun.Server/BlackSun.Server.csproj", "BlackSun.Server/"]
RUN dotnet restore "BlackSun.Server/BlackSun.Server.csproj"
COPY . .
WORKDIR "/src/BlackSun.Server"
RUN dotnet build "BlackSun.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlackSun.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlackSun.Server.dll"]