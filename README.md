DevEvents
=========
Projeto experimental para estudo da plataforma .net.

## Descrição
Sistema responsável pelo gerenciamento de eventos para desenvolvedores. O sistema deverá permitir o cadastro, consulta e atualização de usuário, categoria e evento.

## Executar a aplicação

Para executar a aplicação é necessário ter todo o ambiente do .Net 5 instalado na máquina.

- Para gerar as migrations é necessário rodar o comando abaixo:
  - *dotnet ef migrations add PrimeiraMigration -o .\Persistencia\Migrations*
- Após as migrations terem sido geradas, execute o comando abaixo para gerar o banco:
  - *dotnet ef database update*