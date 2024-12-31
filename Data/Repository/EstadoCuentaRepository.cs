using Microsoft.EntityFrameworkCore;
using Model;
using Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class EstadoCuentaRepository: IEstadoCuentaRepository
    {
        private readonly CreditCardDbContext _context;

        public EstadoCuentaRepository(CreditCardDbContext context)
        {
            _context = context;
        }

        public EstadoCuenta GetEstadoCuenta(int tarjetaId)
        {
            var estadoCuenta = _context.EstadoCuenta
                .FromSqlInterpolated($"EXEC EstadoCuenta @TarjetaID = {tarjetaId}")
                .AsEnumerable()
                .FirstOrDefault();

            return estadoCuenta;
        }





    }
}
