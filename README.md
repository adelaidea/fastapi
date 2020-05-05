#FastAPI - Projeto extensível para desenvolvimento de API's com .net core de forma rápida

[![Codacy Badge](https://api.codacy.com/project/badge/Grade/46e1a04ebb9940a488ad41a00e8a4853)](https://app.codacy.com/manual/rafaelherik/fastapi?utm_source=github.com&utm_medium=referral&utm_content=rafaelherik/fastapi&utm_campaign=Badge_Grade_Dashboard)

# Tecnologias Utilizadas

- .Net Core 3.1
- Entity Framework Core
- AutoMapper 9
- Fluent Validation


# Considerações importantes

Como o intuito desse modelo é entregar um conjunto de facilidades para o desenvolvimento de um projeto,
muitas ideias podem ser retiradas daqui. Não aconselho utilizar esse código em projetos de grande complexidade mas sim em 
pequenos projetos em que deseja entregar de forma rápida um código organizado, conciso e altamente testável.

No decorrer do tempo vou atualizar tanto a descrição como o código do projeto para explicar melhor como utilizá-lo.

# Projeto de Exemplo 

## API

 - API Controllers

 - CRUD Controllers 

Para atribuir 4 operações a uma entidade por herança do controller base que implementa de forma genérica 4 operações (Create, Read, Update e Delete) basta herdar o controller CrudController.

Existem as seguintes premissas:
- Entidada
- Modelos para as operações Create, Update e Read
- Application Service.

    [ApiController]
    [Route("users")]
    public class UserController : CrudController<User, int, UserAddModel, UserUpdateModel, UserReadModel>
    {        
        public UserController(IUserApplicationService service) : base(service)
        {
        
        }
    
    }



## Application

- Application Services
- Models
- AutoMapper Configuration

## Infra

- Repositories
- DbContext

## Domain

- Entities
- Repository Contracts
- Domain Services (Implementation / Contracts)



