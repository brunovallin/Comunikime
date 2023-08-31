# Comunikime

O projeto a seguir se trata de um pequeno sistema que faz controle de estoque de produtos diversos e realiza as vendas destes produtos.

Desenvolvido em camadas contando com:
    
* API em .Net 5.0
  * Entity Framework 
* Front-end em Angular 16
  * Font-Awesome
  * Bootstrap 4.6
  * ngx-bootstrap 4

## Estrutura

### API

A solution envolvida na API é estruturada em 4 projetos divididos por funcionalidade.

![Alt text](image.png)

### Front-End

Por se tratar de um framework focado em SPA(Single Page Application), a solução de páginas é feita por componentes.

![Alt text](image-1.png)

## Como funciona?

### Instalação

Serão necessárias algumas instalações para executar o projeto sendo elas:

[![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)](https://dotnet.microsoft.com/en-us/download/dotnet/5.0)



### Execução do projeto

Para execução do projeto são necessários 2 terminais:

* Para executar a API.
  * Na pasta do projeto Comunikime.API, execute o comando:

    `dotnet watch run`

* Para executar o Angular.
  * Na pasta do projeto ComunikimeApp, execute o comando:

    `ng serve -o`

### Funcionalidade

### Funções 