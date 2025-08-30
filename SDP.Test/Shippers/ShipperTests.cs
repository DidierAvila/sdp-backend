using FluentAssertions;
using SDP.Domain.Entities;
using SDP.Domain.Validators;

namespace SDP.Test.Shippers
{
    public class ShipperTests
    {
        private readonly ShipperValidator _validator;

        public ShipperTests()
        {
            _validator = new ShipperValidator();
        }

        [Fact]
        public void Should_Have_Error_When_CompanyName_Is_Empty()
        {
            // Arrange
            var shipper = new Shipper { CompanyName = string.Empty };

            // Act
            var result = _validator.Validate(shipper);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(e => e.PropertyName == nameof(Shipper.CompanyName));
        }

        [Fact]
        public void Should_Have_Error_When_CompanyName_Exceeds_MaxLength()
        {
            // Arrange
            var shipper = new Shipper { CompanyName = new string('A', 41) }; // 41 characters, maximum is 40

            // Act
            var result = _validator.Validate(shipper);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(e => e.PropertyName == nameof(Shipper.CompanyName));
        }

        [Fact]
        public void Should_Have_Error_When_Phone_Is_Empty()
        {
            // Arrange
            var shipper = new Shipper
            {
                CompanyName = "Valid Shipper",
                Phone = string.Empty
            };

            // Act
            var result = _validator.Validate(shipper);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(e => e.PropertyName == nameof(Shipper.Phone));
        }

        [Fact]
        public void Should_Have_Error_When_Phone_Exceeds_MaxLength()
        {
            // Arrange
            var shipper = new Shipper
            {
                CompanyName = "Valid Shipper",
                Phone = new string('1', 25) // 25 characters, maximum is 24
            };

            // Act
            var result = _validator.Validate(shipper);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(e => e.PropertyName == nameof(Shipper.Phone));
        }

        [Fact]
        public void Should_Be_Valid_When_All_Required_Fields_Are_Provided()
        {
            // Arrange
            var shipper = new Shipper
            {
                CompanyName = "Valid Shipper",
                Phone = "555-1234"
            };

            // Act
            var result = _validator.Validate(shipper);

            // Assert
            result.IsValid.Should().BeTrue();
        }
    }
}
