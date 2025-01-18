# Use a imagem mais recente do .NET SDK para construir o projeto
FROM mcr.microsoft.com/dotnet/sdk:latest AS build

# Defina o diretório de trabalho no container
WORKDIR /app

# Copie o arquivo de solução e o código-fonte para o diretório de trabalho
COPY . .

# Restaure as dependências do projeto
RUN dotnet restore

# Compile o projeto
RUN dotnet publish -c Release -o /app/out

# Use a imagem mais recente do .NET Runtime para rodar o aplicativo
FROM mcr.microsoft.com/dotnet/runtime:latest

# Defina o diretório de trabalho no container
WORKDIR /app

# Copie os arquivos compilados da etapa de build
COPY --from=build /app/out .

# Comando para rodar o aplicativo de console
ENTRYPOINT ["dotnet", "FormCI.dll"]