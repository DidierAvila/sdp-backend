using FluentValidation;
using SDP.Domain.Entities;

namespace SDP.Domain.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(product => product.ProductName)
                .NotEmpty().WithMessage("El nombre del producto no puede estar vacío")
                .MaximumLength(40).WithMessage("El nombre del producto no puede exceder los 40 caracteres");

            RuleFor(product => product.SupplierId)
                .NotEmpty().WithMessage("El ID del proveedor es requerido")
                .GreaterThan(0).WithMessage("El ID del proveedor debe ser mayor que cero");

            RuleFor(product => product.CategoryId)
                .NotEmpty().WithMessage("El ID de la categoría es requerido")
                .GreaterThan(0).WithMessage("El ID de la categoría debe ser mayor que cero");

            RuleFor(product => product.UnitPrice)
                .NotEmpty().WithMessage("El precio unitario no puede estar vacío")
                .GreaterThanOrEqualTo(0).WithMessage("El precio unitario debe ser mayor o igual a cero");
        }
    }
}
