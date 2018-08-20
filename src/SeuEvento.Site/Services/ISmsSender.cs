using System.Threading.Tasks;

namespace SeuEvento.Site.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
