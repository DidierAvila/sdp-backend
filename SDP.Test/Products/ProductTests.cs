using FluentAssertions;
using SDP.Domain.Entities;
using SDP.Domain.Validators;

namespace SDP.Test.Products
{
    public class ProductTests
    {
        private readonly ProductValidator _validator;

        public ProductTests()
        {
            _validator = new ProductValidator();
        }

        [Fact]
        public void Should_Have_Error_When_ProductName_Is_Empty()
        {
            // Arrange
            var product = new Product { ProductName = string.Empty };

            // Act
            var result = _validator.Validate(product);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(e => e.PropertyName == nameof(Product.ProductName));
        }

        [Fact]
        public void Should_Have_Error_When_ProductName_Exceeds_MaxLength()
        {
            // Arrange
            var product = new Product { ProductName = new string('A', 41) }; // 41 characters, maximum is 40

            // Act
            var result = _validator.Validate(product);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(e => e.PropertyName == nameof(Product.ProductName));
        }

        [Fact]
        public void Should_Have_Error_When_SupplierId_Is_Zero()
        {
            // Arrange
            var product = new Product
            {
                ProductName = "Valid Product",
                SupplierId = 0, // Invalid supplier ID
                CategoryId = 1,
                UnitPrice = 10.99m
            };

            // Act
            var result = _validator.Validate(product);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(e => e.PropertyName == nameof(Product.SupplierId));
        }

        [Fact]
        public void Should_Have_Error_When_CategoryId_Is_Zero()
        {
            // Arrange
            var product = new Product
            {
                ProductName = "Valid Product",
                SupplierId = 1,
                CategoryId = 0, // Invalid category ID
                UnitPrice = 10.99m
            };

            // Act
            var result = _validator.Validate(product);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(e => e.PropertyName == nameof(Product.CategoryId));
        }

        [Fact]
        public void Should_Be_Valid_When_All_Required_Fields_Are_Provided()
        {
            // Arrange
            var product = new Product
            {
                ProductName = "Valid Product",
                SupplierId = 1,
                CategoryId = 1,
                UnitPrice = 10.99m,
                Discontinued = false
            };

            // Act
            var result = _validator.Validate(product);

            // Assert
            result.IsValid.Should().BeTrue();
        }
    }
}
