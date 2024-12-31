using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface IPagoRepository
    {
        void Add(Pago pago);
        IEnumerable<Pago> GetPagosByMonth(int year, int month);
        IEnumerable<Pago> GetByDateRange(DateTime startDate, DateTime endDate);
    }
}
