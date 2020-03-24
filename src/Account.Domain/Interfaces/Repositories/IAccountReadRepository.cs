using System.Threading.Tasks;

namespace Account.Domain.Interfaces.Repositories
{
    public interface IAccountReadRepository
    {
        Task<Entities.Account> GetAccountAsync(int bankId, string number, string agency);
    }
}
