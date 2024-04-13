using System.Collections.ObjectModel;
using CMyOld_Api.Domain.Validation;

namespace CMyOld_Api.Domain.Entities
{
    public sealed class Category : Entity
    {
        public string Name { get; private set; }

        public Category(string name)
        {
            ValidationDomain(name);
        }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "invalid Id value.");
            Id = id;
            ValidationDomain(name);
        }

        public void Update(string name)
        {
            ValidationDomain(name);
        }

        public Collection<Product> Products { get; private set; }

        private void ValidationDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required");
            DomainExceptionValidation.When(name.Length < 3, "Invalid name. too short, minimum 3 characters");
            Name = name;
        }
    }
}