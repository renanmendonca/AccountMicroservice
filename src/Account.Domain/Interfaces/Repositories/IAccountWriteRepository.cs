using System;
using System.Threading.Tasks;

namespace Account.Domain.Interfaces.Repositories
{
    public interface IAccountWriteRepository
    {
        Task UpdateAsync(Account.Domain.Entities.Account account);
    }
}
