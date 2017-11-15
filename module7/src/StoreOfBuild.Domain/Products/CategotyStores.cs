

namespace StoreOfBuild.Domain.Products
{
    public class CategoryStores
    {
        private readonly IRepository<Category> _repositoryCategory;

        public CategoryStores(IRepository<Category> repositoryCategory)
        {
            _repositoryCategory = repositoryCategory;
        }

        public void Store(int id,string name)
        {
            var category = _repositoryCategory.GetById(id);
            if (category == null)
            {
                category = new Category(name);
                _repositoryCategory.Save(category);
            }
            else
            {
                category.update(name);
            }
        }
    }
}