using Account.Application.Common;
using System.Threading.Tasks;

namespace Account.Application.Services
{
    public class EmailService : IEmailService
    {
        public Task SendEmail(EmailDto email)
        {
            // Send an Email...
            return Task.CompletedTask;
        }
    }
}
