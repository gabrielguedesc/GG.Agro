#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["GG.Agro.Api/GG.Agro.Api.csproj", "GG.Agro.Api/"]
RUN dotnet restore "GG.Agro.Api/GG.Agro.Api.csproj"
COPY . .
WORKDIR "/src/GG.Agro.Api"
RUN dotnet build "GG.Agro.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GG.Agro.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GG.Agro.Api.dll"]