# DesafioFinalClienteApi
Desafio do bootcamp da pós em arquitetura de sofwtare.

## Objetivo
Disponibilizar publicamente dados de Clientes via API REST para parceiros, permitindo operações CRUD e consultas agregadas (contagem, busca por nome), seguindo o MVC.

## Requisitos Funcionais
1. Criar cliente ( POST /api/clientes ).
2. Listar todos os clientes ( GET /api/clientes ).
3. Buscar por ID ( GET /api/clientes/{id} ).
4. Buscar por nome (contém) ( GET /api/clientes/nome/{nome} ).
5. Atualizar cliente ( PUT /api/clientes/{id} ).
6. Excluir cliente ( DELETE /api/clientes/{id} ).
7. Contar clientes ( GET /api/clientes/contar ).

## Decisões Arquiteturais
- MVC: Controller expõe endpoints, delega regra de negócio ao Service; Model representa aentidade; Data (DbContext) provê acesso a dados.
- EF Core InMemory: simula persistência, sem custos de infraestrutura.
- DI: serviços registrados via container padrão do ASP.NET Core.
- Swagger: padrão de documentação para navegação e testes manuais.

## Estrutura de pastas
```
  Controllers/ - Camada de apresentação HTTP (REST). Recebe requisições, valida entrada básica e orquestra chamadas ao Service.
  Data/ - Contexto de dados (EF Core). Centraliza DbContext e DbSets.
  Models/ - Entidades de domínio (Cliente), com anotações de validação.
  Services/ - Regras de negócio e orquestração de acesso a dados (via DbContext).
  Program.cs - Configuração de DI, EF InMemory e Swagger.
```
## Diagrama de Classes
![diagrama](docs/diagramaDeClasses.png)
