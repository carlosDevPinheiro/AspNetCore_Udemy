
 // " Data Transfer Objetct "=> obajto de Transferencia 

namespace StoreOfBuild.Domain.Dtos
{
   
    public class ProductDTO
    {
        public int Id { get;  set; }
        public string Name { get;  set; }
        public int CategoryId { get;  set; }
        public decimal Price { get;  set; }
        public int StockQuantity { get;  set; }
    }
}