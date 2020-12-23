using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IMailer
    {
        Task SendEmailAsync(string email, string subject, string body);
    }
}