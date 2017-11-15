using System.Threading.Tasks;

namespace StoreOfBuild.Domain
{
    public interface IUnityOfWork
    {
        Task Commit();
    }
}