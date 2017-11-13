namespace StoreOfBuild.Domain 
{
    public interface IRepository<TEntity> where TEntity: class
    {
        TEntity GetById(int id);
        void Save(TEntity entity);
    }
}