using Account.Domain.Entities;
using Account.Domain.Enums;
using Account.Domain.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace Account.Infra.Data.Repositories
{
    public class TransactionWriteRepository : ITransactionWriteRepository
    {
        private DataContext _context;

        public TransactionWriteRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateAsync(Transaction transaction)
        {
            _context.Transaction.Add(transaction);
            await _context.SaveChangesAsync();

            return transaction.Id;
        }
    }
}
