using System;
using System.Collections.Generic;
using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category : BaseEntity
    {
        #region model entities
        public string Name { get; private set; }
        public ICollection<Product> Products { get; private set; }
        #endregion

        #region constructors
        public Category(string name)
        {
            ValidateDomain(name);
        }

        public Category (int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value");
            Id = id;
            ValidateDomain(name);
        }
        #endregion

        #region methods
        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(
                                     String.IsNullOrEmpty(name), 
                                    "Invalid name. Name is required"
                                          );

            DomainExceptionValidation.When(
                                      name.Length < 3, 
                                      "Very short name. The name must contain at least three characters."
                                           );

            Name = name;
        }

        public void Update(string name)
        {
            ValidateDomain(name);
        }
        #endregion
    }
}
