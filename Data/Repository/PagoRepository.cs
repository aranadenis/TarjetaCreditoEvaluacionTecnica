using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class PagoRepository: IPagoRepository
    {
        private readonly CreditCardDbContext _context;

        public PagoRepository(CreditCardDbContext context)
        {
            _context = context;
        }

        public void Add(Pago pago)
        {
            _context.Set<Pago>().Add(pago);
            _context.SaveChanges();
        }

        public IEnumerable<Pago> GetPagosByMonth(int year, int month)
        {
            return _context.Set<Pago>()
                .Where(p => p.FechaPago.Year == year && p.FechaPago.Month == month)
                .ToList();
        }

            public IEnumerable<Pago> GetByDateRange(DateTime startDate, DateTime endDate)
            {
                return _context.Set<Pago>()
                    .Where(c => c.FechaPago >= startDate && c.FechaPago <= endDate)
                    .ToList();
            }
        }
}
