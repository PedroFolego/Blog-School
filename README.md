# Tryitter

## Projeto Final da Aceleração C# 


### Contexto
A Trybe decidiu desenvolver sua própria rede social, totalmente baseada em texto. O objetivo é proporcionar um ambiente em que as pessoas estudantes poderão, por meio de textos e imagens, compartilhar suas experiências e também acessar posts que possam contribuir para seu aprendizado.

### Técnologias usadas

> Desenvolvido usando: .NET, C#, ASP.NET Core, Entity Framework Core, SQL Server, xUnit, FluentAssertions, Moq, Docker


### Executando aplicação
 

* Rode o banco de dados com o docker (opcional):

 ```
 docker-compose up --build -d
 ```
 
* Adicione uma Connection String (exemplo):

```
export DOTNET_CONNECTION_STRING="Server=127.0.0.1;Database=blog_school;User=SA;Password=Password12@"
```

* Baixe as dependências do projeto:

 ```
 cd src/Blog-Post && dotnet restore
 ```

* Rode a aplicação:

```
dotnet run
```
