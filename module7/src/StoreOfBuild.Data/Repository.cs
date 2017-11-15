using System.Collections.Generic;
using System.Linq;
using StoreOfBuild.Domain;

namespace StoreOfBuild.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity: Entity
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TEntity> All()
        {
           return _context.Set<TEntity>().AsEnumerable();
        }

        public TEntity GetById(int id)
        {
           return _context.Set<TEntity>().SingleOrDefault(e => e.Id.Equals(id));
        }

        public void Save(TEntity entity)
        {
           _context.Set<TEntity>().Add(entity);
        }
    }
}