# API Financeiro

Uma API RESTful desenvolvida em **.NET 8** para gerenciamento de finanças e controle de despesas.

## Tecnologias Utilizadas

* [.NET 8](https://dotnet.microsoft.com/download/dotnet/8.0)
* ASP.NET Core Web API
* AutoMapper (Mapeamento de DTOs)
* Swagger/OpenAPI (Documentação da API)

## Estrutura do Projeto

O projeto segue uma arquitetura baseada em serviços e DTOs para separar as responsabilidades:
* **Models**: Entidades de domínio (ex: `Despesa`).
* **Dtos**: Objetos de transferência de dados (`DespesaDto`, `DespesaUpdateDto`).
* **Services**: Regras de negócio (`DespesaServices`).
* **Profiles**: Configurações de mapeamento (`DespesaProfile`).
* **Controllers**: Endpoints de entrada da API.

## Como Executar

1. Clone o repositório:
2. Navegue até a pasta do projeto:
3. Execute a aplicação:
4. Acesse o Swagger no seu navegador (geralmente em `http://localhost:<porta>/swagger`) para interagir com os endpoints da API.

## Endpoints Principais

A API possui rotas para o gerenciamento de despesas, permitindo listar, criar, atualizar (PUT) e excluir registros.