#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MilsatInternAPI.csproj", "."]
RUN dotnet restore "./MilsatInternAPI.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "MilsatInternAPI.csproj" -c Release -o outbuild

FROM build AS publish
RUN dotnet publish "MilsatInternAPI.csproj" -c Release -o out	

FROM base AS final
WORKDIR /app
COPY --from=publish /app/out .
ENTRYPOINT ["dotnet", "MilsatInternAPI.dll"]