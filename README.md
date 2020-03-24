# AccountMicroservice

Exemplo conceitual de implementação de um microserviço de transferência entre contas

Recursos:
- Asp.Net Core 3.1
- MediatR
- Swashbuckle.AspNetCore (Swagger)

- SQLServer
  - EF (Write)
  - Dapper (Read)
  
- Tests
  - Entities Tests

-Endpoint: /v1/account/transfer
-Payload:
{
	"Source": {
		"BankId" : 1,
		"Number" : "0001-1",
		"Agency" : "123",
		"Ammount" : 100
	},
	"Destination": {		
		"BankId" : 1,
		"Number" : "0002-1",
		"Agency" : "123",
		"Ammount" : 200
	},
	"Ammount" : 50
}
