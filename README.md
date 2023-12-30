# DotnetBackgroundService-Example
Projeto de api REST para praticar o uso de background services em .net e C#

![Csharp](https://img.shields.io/badge/csharp-019733?&style=for-the-badge&logo=csharp&logoColor=white)
![.NET7](https://img.shields.io/badge/.NET7-512BD4?logo=.net&logoColor=ffffff&style=for-the-badge)
![Visual Studio](https://img.shields.io/badge/VisualStudio-6C33AF?logo=visual%20studio&style=for-the-badge)
![SQL Server](https://img.shields.io/badge/Microsoft%20SQL%20Server-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white)
[![LinkedIn](https://img.shields.io/badge/linkedin-%230077B5.svg?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/rafael-francisco-44750522/)

## Fluxo
O usuario realiza uma solicitação informando um documento (CNPJ) e 3 processos serão executados nessa solicitação. Para não deixar o usuário parado esperando o termino do processamento os 3 processos serão executados em background e seus status atualizados para que 
a aplicação cliente possa acompanhar o andamento.

## Execução
- rodar o comando dotnet run no diretorio onde se encontra o .csproj
- com a api rodando, executar o comando npm run start ou ng serve no projeto do frontend