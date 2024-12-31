using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class CompraRepository: ICompraRepository
    {
        private readonly CreditCardDbContext _context;

        public CompraRepository(CreditCardDbContext context)
        {
            _context = context;
        }

        public void Add(Compra compra)
        {
            _context.Set<Compra>().Add(compra);
            _context.SaveChanges();
        }

        public IEnumerable<Compra> GetByDateRange(DateTime startDate, DateTime endDate)
        {
            return _context.Set<Compra>()
                .Where(c => c.FechaCompra >= startDate && c.FechaCompra <= endDate)
                .ToList();
        }

        public IEnumerable<Compra> GetByMonth(int year, int month)
        {
            return _context.Set<Compra>()
                .Where(c => c.FechaCompra.Year == year && c.FechaCompra.Month == month)
                .ToList();
        }

       

        

        public IEnumerable<CompraMesActual> GetComprasMesActual(int tarjetaId)
        {
            return _context.ComprasMesActual
                .FromSqlInterpolated($"EXEC [dbo].[RecuperarComprasMesActual] @TarjetaID = {tarjetaId}")
                .ToList();  // Devuelve una lista de compras
        }

    }
}
