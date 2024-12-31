using Data.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : ControllerBase
    {

        private readonly IPagoService _pagoService;

        public PagoController(IPagoService pagoService)
        {
            _pagoService = pagoService;
        }

        [HttpPost]
        public IActionResult AddPago([FromBody] PagoDto pagoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _pagoService.AddPago(pagoDto);
            return Ok(new { Message = "Pago registrado correctamente." });
        }

        [HttpGet("byMonth")]
        public IActionResult GetPagosByMonth(int year, int month)
        {
            var pagos = _pagoService.GetPagosByMonth(year, month);
            return Ok(pagos);
        }

    }
}
