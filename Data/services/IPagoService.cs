using Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.services
{
    public interface IPagoService
    {
        void AddPago(PagoDto pagoDto);
        IEnumerable<PagoDto> GetPagosByMonth(int year, int month);
        IEnumerable<PagoDto> GetPagosByDateRange(DateTime startDate, DateTime endDate);
    }
}
