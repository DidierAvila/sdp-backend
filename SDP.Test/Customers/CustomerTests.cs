using FluentAssertions;
using SDP.Domain.Entities;
using SDP.Domain.Validators;

namespace SDP.Test.Customers
{
    public class CustomerTests
    {
        private readonly CustomerValidator _validator;

        public CustomerTests()
        {
            _validator = new CustomerValidator();
        }

        [Fact]
        public void Should_Have_Error_When_CompanyName_Is_Empty()
        {
            // Arrange
            var customer = new Customer { CompanyName = string.Empty };

            // Act
            var result = _validator.Validate(customer);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(e => e.PropertyName == nameof(Customer.CompanyName));
        }

        [Fact]
        public void Should_Have_Error_When_CompanyName_Exceeds_MaxLength()
        {
            // Arrange
            var customer = new Customer { CompanyName = new string('A', 41) }; // 41 characters, maximum is 40

            // Act
            var result = _validator.Validate(customer);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(e => e.PropertyName == nameof(Customer.CompanyName));
        }

        [Fact]
        public void Should_Have_Error_When_ContactName_Is_Empty()
        {
            // Arrange
            var customer = new Customer 
            { 
                CompanyName = "Valid Company",
                ContactName = string.Empty 
            };

            // Act
            var result = _validator.Validate(customer);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(e => e.PropertyName == nameof(Customer.ContactName));
        }

        [Fact]
        public void Should_Have_Error_When_Address_Is_Empty()
        {
            // Arrange
            var customer = new Customer
            {
                CompanyName = "Valid Company",
                ContactName = "John Doe",
                ContactTitle = "Manager",
                Address = string.Empty
            };

            // Act
            var result = _validator.Validate(customer);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(e => e.PropertyName == nameof(Customer.Address));
        }

        [Fact]
        public void Should_Be_Valid_When_All_Required_Fields_Are_Provided()
        {
            // Arrange
            var customer = new Customer
            {
                CompanyName = "Valid Company",
                ContactName = "John Doe",
                ContactTitle = "Manager",
                Address = "123 Main St",
                City = "New York",
                Country = "USA",
                Phone = "555-1234"
            };

            // Act
            var result = _validator.Validate(customer);

            // Assert
            result.IsValid.Should().BeTrue();
        }
    }
}
