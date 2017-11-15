using System.Threading.Tasks;
using StoreOfBuild.Domain;

namespace StoreOfBuild.Data
{
    public class UnityOfWork: IUnityOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnityOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}