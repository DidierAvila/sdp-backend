using FluentValidation;
using SDP.Domain.Entities;

namespace SDP.Domain.Validators
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(employee => employee.LastName)
                .NotEmpty().WithMessage("El apellido no puede estar vacío")
                .MaximumLength(20).WithMessage("El apellido no puede exceder los 20 caracteres");

            RuleFor(employee => employee.FirstName)
                .NotEmpty().WithMessage("El nombre no puede estar vacío")
                .MaximumLength(10).WithMessage("El nombre no puede exceder los 10 caracteres");

            RuleFor(employee => employee.Title)
                .NotEmpty().WithMessage("El título no puede estar vacío")
                .MaximumLength(30).WithMessage("El título no puede exceder los 30 caracteres");

            RuleFor(employee => employee.TitleOfCourtesy)
                .NotEmpty().WithMessage("El título de cortesía no puede estar vacío")
                .MaximumLength(25).WithMessage("El título de cortesía no puede exceder los 25 caracteres");

            RuleFor(employee => employee.BirthDate)
                .NotEmpty().WithMessage("La fecha de nacimiento no puede estar vacía")
                .LessThan(DateTime.Now.AddYears(-18)).WithMessage("El empleado debe tener al menos 18 años");

            RuleFor(employee => employee.HireDate)
                .NotEmpty().WithMessage("La fecha de contratación no puede estar vacía")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("La fecha de contratación no puede ser futura");

            RuleFor(employee => employee.Address)
                .NotEmpty().WithMessage("La dirección no puede estar vacía")
                .MaximumLength(60).WithMessage("La dirección no puede exceder los 60 caracteres");

            RuleFor(employee => employee.City)
                .NotEmpty().WithMessage("La ciudad no puede estar vacía")
                .MaximumLength(15).WithMessage("La ciudad no puede exceder los 15 caracteres");

            RuleFor(employee => employee.Region)
                .MaximumLength(15).WithMessage("La región no puede exceder los 15 caracteres");

            RuleFor(employee => employee.PostalCode)
                .MaximumLength(10).WithMessage("El código postal no puede exceder los 10 caracteres");

            RuleFor(employee => employee.Country)
                .NotEmpty().WithMessage("El país no puede estar vacío")
                .MaximumLength(15).WithMessage("El país no puede exceder los 15 caracteres");

            RuleFor(employee => employee.Phone)
                .NotEmpty().WithMessage("El teléfono no puede estar vacío")
                .MaximumLength(24).WithMessage("El teléfono no puede exceder los 24 caracteres");
        }
    }
}
