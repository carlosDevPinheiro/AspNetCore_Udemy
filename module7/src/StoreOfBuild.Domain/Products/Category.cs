using System;

namespace StoreOfBuild.Domain.Products
{
    public class Category : Entity
    {
        protected Category()
        {
            
        }
        public Category(string name)
        {
            SetValueNameAndSetNameProperty(name);
        }

        public void SetValueNameAndSetNameProperty(string name)
        {
            DomainException.When(string.IsNullOrEmpty(name), "Name is required");
            DomainException.When(name.Length < 3, "length maior 3");
            this.Name = name;
        }

        
        public string Name { get; private set; }

        public void update(string name) => SetValueNameAndSetNameProperty(name);
        
    }
}
