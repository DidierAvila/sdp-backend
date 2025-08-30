using FluentValidation;
using SDP.Domain.Entities;

namespace SDP.Domain.Validators
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(order => order.CustId)
                .NotEmpty().WithMessage("El ID del cliente es requerido")
                .GreaterThan(0).WithMessage("El ID del cliente debe ser mayor que cero");

            RuleFor(order => order.EmpId)
                .NotEmpty().WithMessage("El ID del empleado es requerido")
                .GreaterThan(0).WithMessage("El ID del empleado debe ser mayor que cero");

            RuleFor(order => order.OrderDate)
                .NotEmpty().WithMessage("La fecha de pedido no puede estar vacía")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("La fecha de pedido no puede ser futura");

            RuleFor(order => order.RequiredDate)
                .NotEmpty().WithMessage("La fecha requerida no puede estar vacía")
                .GreaterThanOrEqualTo(order => order.OrderDate)
                .WithMessage("La fecha requerida debe ser igual o posterior a la fecha de pedido");

            RuleFor(order => order.ShippedDate)
                .GreaterThanOrEqualTo(order => order.OrderDate)
                .When(order => order.ShippedDate.HasValue)
                .WithMessage("La fecha de envío debe ser igual o posterior a la fecha de pedido");

            RuleFor(order => order.ShipperId)
                .NotEmpty().WithMessage("El ID del transportista es requerido")
                .GreaterThan(0).WithMessage("El ID del transportista debe ser mayor que cero");

            RuleFor(order => order.Freight)
                .GreaterThanOrEqualTo(0).WithMessage("El flete debe ser mayor o igual a cero");

            RuleFor(order => order.ShipName)
                .NotEmpty().WithMessage("El nombre de envío no puede estar vacío")
                .MaximumLength(40).WithMessage("El nombre de envío no puede exceder los 40 caracteres");

            RuleFor(order => order.ShipAddress)
                .NotEmpty().WithMessage("La dirección de envío no puede estar vacía")
                .MaximumLength(60).WithMessage("La dirección de envío no puede exceder los 60 caracteres");

            RuleFor(order => order.ShipCity)
                .NotEmpty().WithMessage("La ciudad de envío no puede estar vacía")
                .MaximumLength(15).WithMessage("La ciudad de envío no puede exceder los 15 caracteres");

            RuleFor(order => order.ShipRegion)
                .MaximumLength(15).WithMessage("La región de envío no puede exceder los 15 caracteres");

            RuleFor(order => order.ShipPostalCode)
                .MaximumLength(10).WithMessage("El código postal de envío no puede exceder los 10 caracteres");

            RuleFor(order => order.ShipCountry)
                .NotEmpty().WithMessage("El país de envío no puede estar vacío")
                .MaximumLength(15).WithMessage("El país de envío no puede exceder los 15 caracteres");
        }
    }
}
