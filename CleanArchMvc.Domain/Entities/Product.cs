using System;
using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : BaseEntity
    {
        #region model entities
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        #endregion

        #region constructors
        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidationDomain(name, description, price, stock, image);
        }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value");
            Id = id;
            ValidationDomain(name, description, price, stock, image);
        }
        #endregion

        #region methods
        private void ValidationDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(
                                      String.IsNullOrEmpty(name),
                                     "Invalid name. Name is required"
                                          );

            DomainExceptionValidation.When(
                                      name.Length < 3,
                                     "Invalid name. Name too short, minimum 3 characters"
                                          );

            DomainExceptionValidation.When(
                                      String.IsNullOrEmpty(description),
                                     "Invalid description. Description is required"
                                           );

            DomainExceptionValidation.When(
                                      description.Length < 5,
                                     "Invalid description. Description too short, minimum 5 characters"
                                           );

            DomainExceptionValidation.When(
                                      price < 0,
                                     "Invaid price value"
                                          );

            DomainExceptionValidation.When(
                                      stock < 0,
                                     "Invaid stock value"
                                          );

            DomainExceptionValidation.When(
                                      image.Length > 250,
                                     "Invaid image name, too long, maximum 250 characters "
                                          );

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }

        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidationDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }
        #endregion
    }
}
