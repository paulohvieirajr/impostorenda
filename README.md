# impostorenda

Projeto de API desenvolvido utilizando ASP.NET Core Web API, Entity Framework Core com migration, base de dados MySql, repositórios genéricos, DDD, TDD, injeção de dependencia e Swagger para documentar a API. Pontos a melhorar: autenticação usando JWT, melhorar retornos da API visando utilizar melhor os recursos do HTTP melhorando também a documentação do swagger.

Para testar o projeto é preciso uma conexão com o MYSQL com permissão para gerar a base de dados, caso não exista. Isso ocorrerá através do migration já configurado no projeto. 

Para o projeto de front, desenvolvido em AngularJS, abrir o CMD na pasta raiz ImpostoRenda.APP e executar os seguintes comandos. 

Para instalar os pacotes
> npm i

> bower i

O projeto foi automatizado utilizando gulp como task runner. 

Para rodar em modo desenv: 
> gulp serve

Para rodar em modo release: 
> gulp serve-release

No mode release é criada uma pasta target/www a partir da pasta raiz. Lá é colocado todo o código js minificado e otimizado para produção. 

Duvida ou sugestões, entre em contato. 
Estou a disposição para mais informações. 
