using FluentValidation;
using SDP.Domain.Entities;

namespace SDP.Domain.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.CompanyName)
                .NotEmpty().WithMessage("El nombre de la compañía no puede estar vacío")
                .MaximumLength(40).WithMessage("El nombre de la compañía no puede exceder los 40 caracteres");

            RuleFor(customer => customer.ContactName)
                .NotEmpty().WithMessage("El nombre del contacto no puede estar vacío")
                .MaximumLength(30).WithMessage("El nombre del contacto no puede exceder los 30 caracteres");

            RuleFor(customer => customer.ContactTitle)
                .NotEmpty().WithMessage("El título del contacto no puede estar vacío")
                .MaximumLength(30).WithMessage("El título del contacto no puede exceder los 30 caracteres");

            RuleFor(customer => customer.Address)
                .NotEmpty().WithMessage("La dirección no puede estar vacía")
                .MaximumLength(60).WithMessage("La dirección no puede exceder los 60 caracteres");

            RuleFor(customer => customer.City)
                .NotEmpty().WithMessage("La ciudad no puede estar vacía")
                .MaximumLength(15).WithMessage("La ciudad no puede exceder los 15 caracteres");

            RuleFor(customer => customer.Region)
                .MaximumLength(15).WithMessage("La región no puede exceder los 15 caracteres");

            RuleFor(customer => customer.PostalCode)
                .MaximumLength(10).WithMessage("El código postal no puede exceder los 10 caracteres");

            RuleFor(customer => customer.Country)
                .NotEmpty().WithMessage("El país no puede estar vacío")
                .MaximumLength(15).WithMessage("El país no puede exceder los 15 caracteres");

            RuleFor(customer => customer.Phone)
                .NotEmpty().WithMessage("El teléfono no puede estar vacío")
                .MaximumLength(24).WithMessage("El teléfono no puede exceder los 24 caracteres");

            RuleFor(customer => customer.Fax)
                .MaximumLength(24).WithMessage("El fax no puede exceder los 24 caracteres");
        }
    }
}
