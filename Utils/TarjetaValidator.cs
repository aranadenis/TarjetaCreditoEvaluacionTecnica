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
    public class TarjetaValidator : AbstractValidator<TarjetaDto>
    {
        public TarjetaValidator()
        {
            RuleFor(t => t.NumeroTarjeta)
                    .NotNull()
                    .NotEmpty().WithMessage("El número de tarjeta es obligatorio.")
                    .Length(16).WithMessage("El número de tarjeta debe tener 16 dígitos.");

            RuleFor(t => t.UsuarioID)
                    .GreaterThan(0).WithMessage("Debe especificar un Usuario válido.");

            RuleFor(t => t.NombreTitular)
                    .NotNull()
                    .NotEmpty().WithMessage("El nombre del titular es obligatorio.")
                    .MaximumLength(100).WithMessage("El nombre del titular no debe exceder 100 caracteres.");

            RuleFor(t => t.LimiteCredito)
                    .GreaterThan(0).WithMessage("El límite de crédito debe ser mayor que 0.");

            RuleFor(t => t.PorcentajeSaldoMinimo)
                    .InclusiveBetween(1, 100).WithMessage("El porcentaje de saldo mínimo debe estar entre 1% y 100%.");

            RuleFor(t => t.PorcentajeInteres)
                    .InclusiveBetween(0, 100).WithMessage("El porcentaje de interés debe estar entre 0% y 100%.");
        }
    }
}
