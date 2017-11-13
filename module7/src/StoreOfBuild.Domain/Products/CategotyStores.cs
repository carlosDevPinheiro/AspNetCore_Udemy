using StoreOfBuild.Domain.Dtos;

namespace StoreOfBuild.Domain.Products
{
    public class CategoryStores
    {
        private readonly IRepository<Category> _repositoryCategory;

        public CategoryStores(IRepository<Category> repositoryCategory)
        {
            _repositoryCategory = repositoryCategory;
        }

        public void Store(CategoryDto dto)
        {
            var category = _repositoryCategory.GetById(dto.Id);
            if (category == null)
            {
                category = new Category(dto.Name);
                _repositoryCategory.Save(category);
            }
            else 
            {
                category.update(dto.Name);
            }
        }
    }
}