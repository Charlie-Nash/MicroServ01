# Etapa de compilación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar los archivos del proyecto y restaurar dependencias
COPY ["MicroServ01.Api/*.csproj", "MicroServ01.Api/"]
COPY ["MicroServ01.Application/*.csproj", "MicroServ01.Application/"]
COPY ["MicroServ01.Domain/*.csproj", "MicroServ01.Domain/"]
COPY ["MicroServ01.Infrastructure/*.csproj", "MicroServ01.Infrastructure/"]

RUN dotnet restore "MicroServ01.Api/MicroServ01.Api.csproj"

# Copiar todo y compilar
COPY . .
RUN dotnet publish "MicroServ01.Api/MicroServ01.Api.csproj" -c Release -o /publish

# Etapa de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /publish .

EXPOSE 80
ENTRYPOINT ["dotnet", "MicroServ01.Api.dll"]