using Account.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Account.Domain.Interfaces.Repositories
{
    public interface ITransactionWriteRepository
    {
        Task<Guid> CreateAsync(Transaction transaction);
    }
}
