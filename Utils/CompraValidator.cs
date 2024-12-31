using FluentValidation;
using Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class CompraValidator : AbstractValidator<CompraDto>
    {
        
    

        public CompraValidator()
        {
            RuleFor(c => c.TarjetaID)
                .NotEmpty().WithMessage("Debe ingresar una tarjeta de credito para hacer la compra.")
                .GreaterThan(0).WithMessage("Debe especificar una tarjeta válida.");

            RuleFor(c => c.Descripcion)
                .NotEmpty().WithMessage("La descripción de la compra no debe estar vacía.")
                .MaximumLength(200).WithMessage("La descripción no puede exceder los 200 caracteres.");

            RuleFor(c => c.Monto)
                .GreaterThan(0).WithMessage("El monto de la compra debe ser mayor a cero.");
        }
    }
}
