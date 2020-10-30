## Calculate Interest

Projeto desenvolvido para realizar cálculos de taxa de juros.

### Projetos

#### API - Rate
Tem o objetivo de fornecer a taxa de juros.

#### API - Compute
Tem o objetivo de calcular os juros compostos.

### Iniciando
Use as instruções abaixo para executar o projeto.

#### Requisitos
Você precisará das seguintes ferramentas para codificar algo:

* [Visual Studio Code ou 2019](http://www.visualstudio.com/downloads/)
* [.NET Core SDK 3.1](http://www.microsoft.com/net/download)

Você precisará das seguintes ferramentas executar o projeto usando docker:

* [Docker](http://www.docker.com/)
* [Docker-compose](http://docs.docker.com/compose/install/)

### 🎲 Setup
Siga estas etapas para para rodar o projeto em produção:

  1. Clone o repositório

  2. No diretório raiz, restaure os pacotes (nuget) executando:
     ```
     dotnet restore
     ```
  3. Em seguida compile o projeto executando:
     ```
     dotnet build
     ```
  3. Após acesse o diretório das APIs e execute:
     ```
     dotnet run
     ```
  4. Agora seus projetos estão em execução, abra o navegador e acesse: 
  - http://localhost:6005/swagger (Calcula juros)
  - http://localhost:5000/swagger (Taxa de juros)

### 🎲 Setup (Com Docker)

Siga estas etapas para para rodar o projeto em produção:

  1. Clone o repositório

  2. No diretório raiz, execute o comando:
     ```
     docker-compose build
     docker-compose up -d
     ```
  3. Agora seus projetos estão em execução, abra o navegador e acesse: 
  - http://localhost:8000/swagger (Calcula juros)
  - http://localhost:8001/swagger (Taxa de juros)

### Exemplos

#### API - Taxa de juros
```shell
curl --request GET \
  --url http://localhost:5000/taxaJuros \
  --header 'accept: application/json'

{
  "value": 0.01
}
```

#### API - Cálculo de juros
```shell
curl --request GET \
  --url 'http://localhost:6005/calculajuros?initialValue=100&time=5' \
  --header 'accept: application/json'

{
  "result": 105.1
}
```

### 🛠 Tecnologias

- [C# 8.0](https://docs.microsoft.com/pt-br/dotnet/csharp/)
- [ASP.NET Core 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1)
- [ASP.NET WebApi Core 3.1](https://dotnet.microsoft.com/apps/aspnet)
- [.NET Core Native DI](https://docs.microsoft.com/pt-br/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-3.1)
- [Refit](https://www.nuget.org/packages/Refit.HttpClientFactory/)
- [Docker](https://www.docker.com/)

### Autor
* **Mario Mendonça** - *Contribuidor* - [Mario Mendonça](https://lab.coodesh.com/mario.mendonca)


### Licença
Este projeto está licenciado sob a Licença MIT: [LICENSE.md](https://lab.coodesh.com/mario.mendonca/dotnet-20200902/-/blob/master/LICENSE).
