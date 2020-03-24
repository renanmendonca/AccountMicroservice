using Microsoft.EntityFrameworkCore;

namespace Account.Infra.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base (options)
        {

        }

        public DbSet<Account.Domain.Entities.Account> Account { get; set; }

        public DbSet<Account.Domain.Entities.Transaction> Transaction { get; set; }
    }
}
