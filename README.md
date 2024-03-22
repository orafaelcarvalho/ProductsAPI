Projeto .NET 5 DDD Web API - Controle de Produtos e Fornecedores

Este projeto é uma aplicação de exemplo desenvolvida em .NET 5 utilizando a arquitetura DDD (Domain-Driven Design) para gerenciamento de produtos e seus respectivos fornecedores.
O objetivo deste projeto é fornecer uma base sólida para entender e praticar os princípios do DDD em uma aplicação Web API.

Funcionalidades:
- Cadastro, atualização, remoção e consulta de produtos.
- Associação de produtos a fornecedores.
- Cadastro, atualização, remoção e consulta de fornecedores.
- Consultas complexas utilizando filtros por código
- Paginação para facilitar a navegação através de grandes conjuntos de dados.

Tecnologias Utilizadas:
- .NET 5
- ASP.NET Core Web API
- Entity Framework Core
- Dapper para consultas SQL otimizadas
- AutoMapper para mapeamento de objetos
- Swagger UI para documentação da API
- Banco de dados SQL Server (pode ser facilmente substituído por outro banco de dados)

Estrutura do Projeto:
O projeto está organizado utilizando a estrutura padrão do DDD, incluindo os seguintes diretórios:
- Domain: Contém as entidades de domínio, interfaces de repositório e serviços de domínio.
- Application: Camada responsável pela lógica de aplicação, incluindo os serviços de aplicação e os DTOs (Data Transfer Objects).
- Infrastructure: Responsável pela implementação concreta dos repositórios, contexto do banco de dados e outras dependências externas.
- Presentation: Contém os controladores da Web API e configurações de injeção de dependência.
