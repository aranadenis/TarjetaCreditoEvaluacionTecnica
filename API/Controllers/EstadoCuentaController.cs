using Data.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoCuentaController : ControllerBase
    {

        private readonly IEstadoCuentaService _estadoCuentaService;

        public EstadoCuentaController(IEstadoCuentaService estadoCuentaService)
        {
            _estadoCuentaService = estadoCuentaService;
        }

        [HttpGet("{tarjetaId}")]
        public IActionResult ObtenerEstadoCuenta(int tarjetaId)
        {
            try
            {
                var estadoCuenta = _estadoCuentaService.ObtenerEstadoCuenta(tarjetaId);

                if (estadoCuenta == null)
                    return NotFound(new { Message = "Estado de cuenta no encontrado." });

                return Ok(estadoCuenta);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
