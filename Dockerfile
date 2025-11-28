FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MyPortfolioUdemy/MyPortfolioUdemy.csproj", "MyPortfolioUdemy/"]
RUN dotnet restore "MyPortfolioUdemy/MyPortfolioUdemy.csproj"
COPY . .
WORKDIR "/src/MyPortfolioUdemy"
RUN dotnet build "MyPortfolioUdemy.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyPortfolioUdemy.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyPortfolioUdemy.dll"]
