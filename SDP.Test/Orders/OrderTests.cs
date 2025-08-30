using FluentAssertions;
using SDP.Domain.Entities;
using SDP.Domain.Validators;

namespace SDP.Test.Orders
{
    public class OrderTests
    {
        private readonly OrderValidator _validator;

        public OrderTests()
        {
            _validator = new OrderValidator();
        }

        [Fact]
        public void Should_Have_Error_When_CustId_Is_Zero()
        {
            // Arrange
            var order = new Order { CustId = 0 };

            // Act
            var result = _validator.Validate(order);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(e => e.PropertyName == nameof(Order.CustId));
        }

        [Fact]
        public void Should_Have_Error_When_EmpId_Is_Zero()
        {
            // Arrange
            var order = new Order 
            { 
                CustId = 1,
                EmpId = 0 
            };

            // Act
            var result = _validator.Validate(order);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(e => e.PropertyName == nameof(Order.EmpId));
        }

        [Fact]
        public void Should_Have_Error_When_OrderDate_Is_In_Future()
        {
            // Arrange
            var order = new Order
            {
                CustId = 1,
                EmpId = 1,
                OrderDate = DateTime.Now.AddDays(1), // Future date
                RequiredDate = DateTime.Now.AddDays(2),
                ShipperId = 1
            };

            // Act
            var result = _validator.Validate(order);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(e => e.PropertyName == nameof(Order.OrderDate));
        }

        [Fact]
        public void Should_Have_Error_When_ShipAddress_Is_Empty()
        {
            // Arrange
            var orderDate = DateTime.Now.AddDays(-1);
            var order = new Order
            {
                CustId = 1,
                EmpId = 1,
                OrderDate = orderDate,
                RequiredDate = orderDate.AddDays(5),
                ShipperId = 1,
                ShipName = "Test Ship",
                ShipAddress = string.Empty, // Empty ship address
                ShipCity = "New York",
                ShipCountry = "USA"
            };

            // Act
            var result = _validator.Validate(order);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(e => e.PropertyName == nameof(Order.ShipAddress));
        }

        [Fact]
        public void Should_Be_Valid_When_All_Required_Fields_Are_Provided()
        {
            // Arrange
            var orderDate = DateTime.Now.AddDays(-2);
            var requiredDate = orderDate.AddDays(5);
            
            var order = new Order
            {
                CustId = 1,
                EmpId = 1,
                OrderDate = orderDate,
                RequiredDate = requiredDate,
                ShipperId = 1,
                Freight = 10.0m,
                ShipName = "Test Ship",
                ShipAddress = "123 Main St",
                ShipCity = "New York",
                ShipCountry = "USA"
            };

            // Act
            var result = _validator.Validate(order);

            // Assert
            result.IsValid.Should().BeTrue();
        }
    }
}
