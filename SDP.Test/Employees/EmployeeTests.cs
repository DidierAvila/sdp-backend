using FluentAssertions;
using SDP.Domain.Entities;
using SDP.Domain.Validators;

namespace SDP.Test.Employees
{
    public class EmployeeTests
    {
        private readonly EmployeeValidator _validator;

        public EmployeeTests()
        {
            _validator = new EmployeeValidator();
        }

        [Fact]
        public void Should_Have_Error_When_LastName_Is_Empty()
        {
            // Arrange
            var employee = new Employee { LastName = string.Empty };

            // Act
            var result = _validator.Validate(employee);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(e => e.PropertyName == nameof(Employee.LastName));
        }

        [Fact]
        public void Should_Have_Error_When_LastName_Exceeds_MaxLength()
        {
            // Arrange
            var employee = new Employee { LastName = new string('A', 21) }; // 21 characters, maximum is 20

            // Act
            var result = _validator.Validate(employee);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(e => e.PropertyName == nameof(Employee.LastName));
        }

        [Fact]
        public void Should_Have_Error_When_FirstName_Is_Empty()
        {
            // Arrange
            var employee = new Employee 
            { 
                LastName = "Doe",
                FirstName = string.Empty 
            };

            // Act
            var result = _validator.Validate(employee);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(e => e.PropertyName == nameof(Employee.FirstName));
        }

        [Fact]
        public void Should_Have_Error_When_BirthDate_Is_Less_Than_18_Years_Ago()
        {
            // Arrange
            var employee = new Employee
            {
                LastName = "Doe",
                FirstName = "John",
                Title = "Sales Representative",
                TitleOfCourtesy = "Mr.",
                BirthDate = DateTime.Now.AddYears(-17), // 17 years old, minimum is 18
                HireDate = DateTime.Now,
                Address = "123 Main St",
                City = "New York",
                Country = "USA",
                Phone = "555-1234"
            };

            // Act
            var result = _validator.Validate(employee);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(e => e.PropertyName == nameof(Employee.BirthDate));
        }

        [Fact]
        public void Should_Be_Valid_When_All_Required_Fields_Are_Provided()
        {
            // Arrange
            var employee = new Employee
            {
                LastName = "Doe",
                FirstName = "John",
                Title = "Sales Representative",
                TitleOfCourtesy = "Mr.",
                BirthDate = DateTime.Now.AddYears(-30),
                HireDate = DateTime.Now.AddDays(-1),
                Address = "123 Main St",
                City = "New York",
                Country = "USA",
                Phone = "555-1234"
            };

            // Act
            var result = _validator.Validate(employee);

            // Assert
            result.IsValid.Should().BeTrue();
        }
    }
}
