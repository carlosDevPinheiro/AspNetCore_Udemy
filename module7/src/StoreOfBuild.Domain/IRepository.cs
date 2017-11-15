using System.Collections.Generic;

namespace StoreOfBuild.Domain 
{
    public interface IRepository<TEntity> where TEntity: Entity
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> All();
        void Save(TEntity entity);
    }
}