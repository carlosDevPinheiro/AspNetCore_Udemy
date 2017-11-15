using System.Threading.Tasks;

namespace StoreOfBuild.Domain.Account
{
    public interface IAuthentication
    {
        Task<bool> Autheticate(string email, string password);
    }
}