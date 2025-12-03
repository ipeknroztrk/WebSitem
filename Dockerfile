# 1️⃣ Build aşaması
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# UTF-8 ve Türkçe locale kurulumu
RUN apt-get update && \
    apt-get install -y locales && \
    locale-gen tr_TR.UTF-8

# Ortam değişkenleri
ENV DOTNET_CLI_UI_LANGUAGE=tr-TR
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
ENV LC_ALL=tr_TR.UTF-8
ENV LANG=tr_TR.UTF-8

WORKDIR /app
COPY . .

WORKDIR /app/MyPortfolıoUdemy
RUN dotnet restore
RUN dotnet publish -c Release -o out

# 2️⃣ Runtime aşaması
FROM mcr.microsoft.com/dotnet/aspnet:6.0

# UTF-8 ayarlarını runtime container'a da ekle
RUN apt-get update && \
    apt-get install -y locales && \
    locale-gen tr_TR.UTF-8
ENV DOTNET_CLI_UI_LANGUAGE=tr-TR
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
ENV LC_ALL=tr_TR.UTF-8
ENV LANG=tr_TR.UTF-8

WORKDIR /app
COPY --from=build /app/MyPortfolıoUdemy/out .

# Render'ın dinamik portunu kullan
ENV ASPNETCORE_URLS=http://+:${PORT:-8080}

ENTRYPOINT ["dotnet", "MyPortfolıoUdemy.dll"]
