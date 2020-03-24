using Account.Application.Common;
using System.Threading.Tasks;

namespace Account.Application.Services
{
    public interface IEmailService
    {
        Task SendEmail(EmailDto email);
    }
}
