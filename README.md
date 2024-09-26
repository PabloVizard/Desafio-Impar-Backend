# Desafio Desenvolvedor Fullstack - .NET/React

## Descrição

O desafio proposto consiste no desenvolvimento de uma API CRUD para gerenciamento de cards, incluindo suporte para upload de fotos.

## Tecnologias Utilizadas

- [ASP.NET Core 6](https://docs.microsoft.com/pt-br/aspnet/core/?view=aspnetcore-6.0)
- [Entity Framework Core](https://docs.microsoft.com/pt-br/ef/core/)
- [AutoMapper](https://automapper.org/)
- [FluentValidation](https://docs.fluentvalidation.net/en/latest/)

## Estruturação DDD

A aplicação foi estruturada seguindo os princípios de Domain-Driven Design (DDD), dividida nas seguintes camadas:

1. **API**: Contém os controladores responsáveis pelos endpoints da aplicação.
2. **Application**: Abriga a lógica de negócios e a implementação dos serviços.
3. **Domain**: Representa os modelos do sistema e as validações correspondentes utilizadas na camada Application.
4. **Infrastructure**: Implementa o contexto de dados, gerencia as migrações do banco de dados e define as entidades.

## Instruções para Execução

### 1. Instalação
Faça a instação do [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) juntamente com o [.NET Core 6.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0).

### 2. Clone o Repositório
Execute os seguintes comandos no terminal:
```bash
git clone <URL_DO_REPOSITORIO_BACKEND>
cd <NOME_DA_PASTA_BACKEND>
```

### 3. Configuração da Conexão com o Banco de Dados
- Abra o arquivo `appsettings.json`.
- Atualize a chave `ConnectionStrings.DefaultConnection` com a string de conexão do seu banco de dados.

### 4. Abra a Solução
- Utilize o Visual Studio para abrir a solução `Backend.sln`.
- Selecione o projeto `Backend.API` como o projeto de inicialização.

### 5. Compilação e Execução do Projeto
- Clique no menu superior, onde está indicado o projeto de inicialização, e verifique se o localhost gerado está funcionando corretamente.

## Considerações Finais

Sinta-se à vontade para explorar o código e testar as diversas funcionalidades da API. 

### Contato

Para perguntas ou feedback, não hesite em entrar em contato.
