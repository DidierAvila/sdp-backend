using FluentValidation;
using SDP.Domain.Entities;

namespace SDP.Domain.Validators
{
    public class ShipperValidator : AbstractValidator<Shipper>
    {
        public ShipperValidator()
        {
            RuleFor(shipper => shipper.CompanyName)
                .NotEmpty().WithMessage("El nombre de la compañía no puede estar vacío")
                .MaximumLength(40).WithMessage("El nombre de la compañía no puede exceder los 40 caracteres");

            RuleFor(shipper => shipper.Phone)
                .NotEmpty().WithMessage("El teléfono no puede estar vacío")
                .MaximumLength(24).WithMessage("El teléfono no puede exceder los 24 caracteres")
                .Matches(@"^[0-9\-\+\(\)\s]+$").WithMessage("El formato del teléfono no es válido");
        }
    }
}
