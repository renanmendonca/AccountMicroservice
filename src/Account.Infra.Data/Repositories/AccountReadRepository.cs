using Account.Domain.Interfaces.Repositories;
using Dapper;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Account.Infra.Data.Repositories
{
    public class AccountReadRepository : IAccountReadRepository
    {

        private readonly string connectionString;

        public AccountReadRepository(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            this.connectionString = configuration.GetSection("ConnectionStrings:SqlServer:ConnectionString").Value;
        }

        public async Task<Domain.Entities.Account> GetAccountAsync(int bankId, string number, string agency)
        {
            var query = @"
                SELECT 
                     [Id]
                    ,[BankId]
                    ,[Number]
                    ,[Agency]
                    ,[Amount]
                FROM
                    Account
                WHERE
                    [BankId] = @BankId
                    [Number] = @Number
                    [Agency] = @Agency                    
            ";

            using (var conn = new SqlConnection(this.connectionString))
            {
                return await conn.QuerySingleAsync<Domain.Entities.Account>(query, new { bankId, number, agency });
            }
        }
    }
}
