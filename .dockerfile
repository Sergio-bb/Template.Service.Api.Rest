# Establece la imagen base para la etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Establece el directorio de trabajo
WORKDIR /src

# Copia el archivo de proyecto y restaura las dependencias
COPY ["Template.Service.Api.Rest.csproj", "./"]
RUN dotnet restore "Template.Service.Api.Rest.csproj"

# Copia el resto de los archivos de la aplicación y construye el proyecto
COPY . .
RUN dotnet build "Template.Service.Api.Rest.csproj" -c Release -o /app/build

# Publica la aplicación
FROM build AS publish
RUN dotnet publish "Template.Service.Api.Rest.csproj" -c Release -o /app/publish

# Establece la imagen base para la etapa de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final

# Establece el directorio de trabajo
WORKDIR /app

# Copia los archivos publicados desde la etapa anterior
COPY --from=publish /app/publish .

# Expone el puerto que la aplicación escucha
EXPOSE 80

# Especifica el comando para ejecutar la aplicación
ENTRYPOINT ["dotnet", "Template.Service.Api.Rest.dll"]
