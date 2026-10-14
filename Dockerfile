# Usa a imagem oficial do .NET 10.0
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /app

# Copia os arquivos e compila a API
COPY . ./
RUN dotnet publish -c Release -o out

# Gera a imagem final mais leve para rodar na nuvem
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app/out .

# Expõe a porta que a nuvem vai usar
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "wakeBus.dll"]