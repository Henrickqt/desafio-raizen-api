# Open Weather API

API desenvolvida utilizando .NET 6, Entity Framework, SQL Server e Docker Compose. É um projeto que segue os princípios do Domain Driven Design (DDD).

## Integrações

Essa API faz integração com a ferramenta [Open Weather](https://openweathermap.org/api/one-call-3), na sua versão 3.0.

## Pré-requisitos

- [.NET 6](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Docker](https://www.docker.com/products/docker-desktop)
- [Docker Compose](https://docs.docker.com/compose/install/)

## Como executar

1. Clone o repositório
```bash
git clone https://github.com/Henrickqt/desafio-raizen-api.git
```

2. Navegue até o diretório do projeto
```bash
cd desafio-raizen-api
```

3. Execute o Docker Compose
```bash
docker-compose up
```

A aplicação estará disponível nas portas `http://localhost:5000` e `http://localhost:5001`.

## Banco de Dados

Este projeto utiliza o SQL Server como banco de dados. As configurações de conexão podem ser encontradas no arquivo `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "Database": "Server=sqlserver,1433;User ID=SA;Password=etVRD#b0DXh@94BU;Initial Catalog=OpenWeather;Persist Security Info=False;"
  }
}
```

O banco de dados é automaticamente criado pelo Docker Compose, conforme definido no arquivo `docker-compose.yml`:
```yaml
services:
  sqlserver:
    image: mcr.microsoft.com/mssql/server:2022-latest
    container_name: sqlserver
    environment:
      ACCEPT_EULA: "Y"
      MSSQL_SA_PASSWORD: ********
    volumes:
      - ./.containers/sql-vol:/var/opt/mssql/data
    ports:
      - "1433:1433"
```

Obs.: para acessar o banco de dados localmente (por fora do container, utilizar a seguinte configuração:
```json
{
  "ConnectionStrings": {
    "Database": "Server=localhost,1433;User ID=SA;Password=etVRD#b0DXh@94BU;Initial Catalog=OpenWeather;Persist Security Info=False;"
  }
}
```
