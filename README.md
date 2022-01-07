# **DevEvents**

Projeto experimental para estudo da plataforma .Net. Desenvolvido durante o bootcamp ASP.Net Core por [Luis Dev](https://www.linkedin.com/in/luisdeol/)

<p align="center">
    <img width="460" height="440" src="https://user-images.githubusercontent.com/58376382/106148375-bfa14b80-6157-11eb-8c4e-bad35e2547b3.jpg"/>
</p>

## **Descrição**

API responsável pelo gerenciamento de eventos para desenvolvedores. A API possui as seguintes funcionalidades:

- Cadastro, edição, cancelamento, consulta e inscrição em um evento;
- Gerenciamento de categorias do evento;
- Gerenciamento de usuários;

## 🚀 **Tecnologias**

Este projeto foi desenvolvido com as seguintes tecnologias:

- [.NET Core 5](https://dotnet.microsoft.com/download/dotnet/5.0)
- [Entity Framework](https://docs.microsoft.com/pt-br/ef/)
- [Dapper](https://docs.microsoft.com/pt-br/archive/msdn-magazine/2016/may/data-points-dapper-entity-framework-and-hybrid-apps)
- [SQLite](https://www.sqlite.org/docs.html)

## **Executar a aplicação**

Para executar a aplicação é necessário ter todo o ambiente do .Net 5 e Entity Framework Core instalados na máquina.

- Para gerar as migrations é necessário rodar o comando abaixo:
  - _dotnet ef migrations add NomeDaMigration -o .\Persistencia\Migrations_
- Após as migrations terem sido geradas, execute o comando abaixo para gerar o banco:
  - _dotnet ef database update_

Desenvolvido por ❤ [Jordan santos](linkedin.com/in/jordan-santos-dev)
