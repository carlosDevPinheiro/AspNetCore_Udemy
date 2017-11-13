using StoreOfBuild.Domain.Dtos;


namespace StoreOfBuild.Domain.Products
{
   public class ProductStore 
    {
        private readonly IRepository<Category> _repositoryCategory;
        private readonly IRepository<Product> _repositoryProduct;

        public ProductStore(IRepository<Product> repositoryProduct, IRepository<Category> repositoryCategory)
        {
            _repositoryCategory = repositoryCategory;
            _repositoryProduct = repositoryProduct;
        }

        public void Store(ProductDTO dto)
        {
           var category =  _repositoryCategory.GetById(dto.CategoryId);
            DomainException.When(category == null, "Category not exist");
            
            var product = _repositoryProduct.GetById(dto.Id);
            if (product == null)
            {
                product = new Product(dto.Name,category,dto.Price,dto.StockQuantity);
                _repositoryProduct.Save(product);
            }
            else 
            {
                product.UpDate(dto.Name,category,dto.Price,dto.StockQuantity);              
            }
        }
    }
}