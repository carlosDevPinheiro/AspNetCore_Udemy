using System;

namespace StoreOfBuild.Domain.Products
{
    public class Category
    {
        public Category(string name)
        {
            SetValueNameAndSetNameProperty(name);
        }

        public void SetValueNameAndSetNameProperty(string name)
        {
            DomainException.When(string.IsNullOrEmpty(name), "Name is required");
            this.Name = name;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }

        public void update(string name) => SetValueNameAndSetNameProperty(name);
        
    }
}
