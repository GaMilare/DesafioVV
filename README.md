# DesafioVV

Projeto desenvolvido para atender o desafio proposto:
[O desafio](https://github.com/viavarejo/backend-test):
Seu objetivo é criar um endpoint para que possamos simular a compra de um produto, deve retornar uma lista de parcelas, acrescidas de juros com base na taxa SELIC de 1.15% ao mês (se possível consultar a taxa em tempo real), somente quando o número de parcelas for superior a 06 (seis) parcelas.

## Primeiros passos

Clone o projeto e inicie através da solution

```
DesafioViaVarejo.sln
``` 

Ao rodar o projeto, sua tela inicial será a interface do swagger contendo os seguintes métodos:

Authentication
* GET - /api/Authentication/GetUsers
* POST - /api/Authentication/login

Product
* GET - /api/Product/GetAllProducts
* POST - /api/Product/GetInstallmentConditions

A API possui chamadas com autenticação JWT, sendo assim, para executar as chamadas da API de Produtos, será preciso realizar a autenticação para obter o Bearer Token.

Para obter a lista de usuários disponiveis para realizar o Login, realize uma chamada GET para o endpoint/api/Authentication/GetUsers.
Com o UserName e o UserPsw obtidos, realize o Post de Login (/api/Authentication/login) para receber o token de autenticação.
Exemplo de retorno de User

```
{
  "success": true,
  "data": [
    {
      "id": 1,
      "userName": "ViaVarejo",
      "userPsw": "123456"
    }
  ]
}

``` 
Após obter o Token, autentique seu swagger no cadeado de Authorize inserindo o Value sendo Bearer mais o valor do token obtido, como o de examplo: 'Bearer 12345abcdef'

Agora que autenticado, a API permite executar o Get de todos os produtos e o POST /api/Product/GetInstallmentConditions para obter o valor das prestações

Exemplo de request para /api/Product/GetInstallmentConditions
```
{
  "Produto": {
      "Codigo": 14,
      "Nome": "Produto A14",
      "Valor": 2100
    },
  "CondicaoPagamento": {
    "ValorEntrada": 300,
    "QtdeParcelas": 10
  }
}
``` 
Response
```
{
  "success": true,
  "data": {
    "numeroParcela": 10,
    "valor": 183.28,
    "taxaJurosAoMes": 0.33
  }
}
``` 
Os testes realizados se encontram na camada .Tests

##Contato

* Gabriel Milaré - gmilare@outlook.com