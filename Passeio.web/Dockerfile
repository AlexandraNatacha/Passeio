FROM mcr.microsoft.com/dotnet/sdk:6.0

# COPY CSPROJ AND RESTORE AS DISTINCT LAYERS
COPY ./ /source

# SETA O DIRETORIO BASE PARA DOTNET RESTORE E PUBLISH
WORKDIR /source/Passeio.web

# RESTAURAO EXPLCITA PARA PACOTES NUGET
#RUN dotnet restore Passeio.web.csproj

# COMPILA O CODIGO PARA IMPLANTAO EM UM SISTEMA DE HOSPEDAGEM
RUN dotnet publish Passeio.sln -c Release -o out
RUN dotnet publish Passeio.web.csproj -c release -o /app

# SETA O DIRETORIO BASE PARA ENTRYPOINT
WORKDIR /app
EXPOSE 8080 443
ENTRYPOINT dotnet Passeio.web.dll