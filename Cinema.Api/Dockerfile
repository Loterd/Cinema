FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Cinema.Api/Cinema.Api.csproj", "Cinema.Api/"]
RUN dotnet restore "Cinema.Api/Cinema.Api.csproj"
COPY . .
WORKDIR "/src/Cinema.Api"
RUN dotnet build "Cinema.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Cinema.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Cinema.Api.dll"]
