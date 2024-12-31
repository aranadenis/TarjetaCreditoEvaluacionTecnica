using FluentValidation;
using Model;
using Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class PagoValidator : AbstractValidator<PagoDto>
    {
        public PagoValidator()
        {
            RuleFor(c => c.TarjetaID)
               .NotEmpty().WithMessage("Debe ingresar una tarjeta de credito para hacer el pago.")
               .GreaterThan(0).WithMessage("Debe especificar una tarjeta válida.");
            RuleFor(p => p.Monto)
                .GreaterThan(0).WithMessage("El monto debe ser mayor a cero.");

            RuleFor(p => p.FechaPago)
                .NotEmpty().WithMessage("La fecha de pago es obligatoria.")
                .Must(BeValidDateFormat).WithMessage("La fecha debe estar en formato dd/M/yyyy.");

            
        }

        private bool BeValidDateFormat(DateTime date)
        {
            
            return true; // DateTime es automáticamente válido al deserializar.
        }
    }
}
