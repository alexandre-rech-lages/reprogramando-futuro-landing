# Web API - Reprogramando Futuro

## Descrição
Web API para o projeto Reprogramando Futuro. Esta API fornece endpoints para gerenciar dados da plataforma.

## Tecnologias
- ASP.NET Core
- Entity Framework Core
- SQL Server

## Estrutura do Projeto
```
web-api/
├── Controllers/
├── Models/
├── Services/
├── Data/
└── appsettings.json
```

## Como Executar
1. Instale as dependências: `dotnet restore`
2. Configure a conexão de banco de dados em `appsettings.json`
3. Execute as migrations: `dotnet ef database update`
4. Inicie a API: `dotnet run`

## Endpoints Principais
- `GET /api/` - Raiz da API
- Documentação adicional em desenvolvimento

## Contribuição
Para contribuir, crie uma branch, faça suas alterações e envie um pull request.

## Deploy
Para rodar o deploy da webapi, deve ser feito uma alteração em algum arquivo dentro da pasta server