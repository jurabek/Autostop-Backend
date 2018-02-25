using System.Threading.Tasks;

namespace Autostop.Services.Identity.Abstraction.Services
{
    public interface IEmailService
    {
	    Task<bool> SendAsync(string email, string body);
    }
}
