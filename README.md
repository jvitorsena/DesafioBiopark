Para executar o backend da aplicação é necessario a instalação do dotnet core na versão 7.0 ou superior.

Para executar o frontend da aplicação é necessario a instalação do npm versão 9.5 ou superior e nodejs versão 18 ou superior.

###### 

## Execução backend

###### Para a execução do backend favor alterar os arquivos BioparkContext.cs e Config/App.config com os dados de configuração do banco de dados.

###### Na raiz do projeto executar o comando terminal para carga inicial do banco de dados:

- dotnet ef migrations add InitialCreate
- dotnet ef database update



###### Após a criação e configuração do banco de dados executar o projeto WebApi na raiz do com o comando:

- dotnet run

  

## Execução frontend

Configurar url da api no arquivo api.ts localizado na pasta client/api.ts

Após a execução da WebApi navegar até a pasta client na raiz do projeto e rodar os seguintes comandos para execução do  projeto frontend:

- npm i
- npm start

## Observação

Foi feito o deploy do backend na AWS, caso preferir, executar somente o frontend ao clonar o projeto, a configuração da url da webapi esta direcionada para a aws como padrão.



