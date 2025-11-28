FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

COPY . .
WORKDIR /app/MyPortfolıoUdemy
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/MyPortfolıoUdemy/out .
EXPOSE 80
ENTRYPOINT ["dotnet", "MyPortfolıoUdemy.dll"]
