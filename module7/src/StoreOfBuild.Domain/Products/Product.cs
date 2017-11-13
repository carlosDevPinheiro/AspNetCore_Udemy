using System;

namespace StoreOfBuild.Domain.Products
{
    public class Product
    {
        public Product(string name, Category category, decimal price, int stockQuantity)
        {
            ValidateValues(name, category, price, stockQuantity);
            SetValues(name, category, price, stockQuantity);
        }



        public int Id { get; private set; }
        public string Name { get; private set; }
        public Category Category { get; private set; }
        public decimal Price { get; private set; }
        public int StockQuantity { get; private set; }


        public void UpDate(string name, Category category, decimal price, int stockQuantity)
        {
            ValidateValues(name, category, price, stockQuantity);
            SetValues(name, category, price, stockQuantity);
        }

        public void SetValues(string name, Category category, decimal price, int stockQuantity)
        {
            Name = name;
            Category = category;
            Price = price;
            StockQuantity = stockQuantity;
        }

        public static void ValidateValues(string name, Category category, decimal price, int stockQuantity)
        {
            DomainException.When(string.IsNullOrEmpty(name), "Name is required");
            DomainException.When(category == null, "Category is required");
            DomainException.When(price < 1, "Name is required");
            DomainException.When(stockQuantity < 1, "Name is required");
        }
    }
}