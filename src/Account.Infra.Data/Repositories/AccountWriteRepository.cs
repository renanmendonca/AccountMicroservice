using Account.Domain.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace Account.Infra.Data.Repositories
{
    public class AccountWriteRepository : IAccountWriteRepository
    {
        private DataContext _context;

        public AccountWriteRepository(DataContext context)
        {
            _context = context;
        }

        public async Task UpdateAsync(Account.Domain.Entities.Account account)
        {
            _context.Update(account);
            await _context.SaveChangesAsync();
        }
    }
}
