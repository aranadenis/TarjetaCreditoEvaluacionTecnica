using Data.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogosController : ControllerBase
    {
        private readonly ICatalogosService _catalogosService;

        public CatalogosController(ICatalogosService catalogosService)
        {
            _catalogosService = catalogosService;
        }

        // GET: api/Catalogos/EstadosTarjeta
        [HttpGet("EstadosTarjeta")]
        public IActionResult GetEstadosTarjeta()
        {
            var estados = _catalogosService.GetEstadosTarjeta();
            return Ok(estados);
        }

        // GET: api/Catalogos/TiposTarjeta
        [HttpGet("TiposTarjeta")]
        public IActionResult GetTiposTarjeta()
        {
            var tipos = _catalogosService.GetTiposTarjeta();
            return Ok(tipos);
        }

        // POST: api/Catalogos/EstadosTarjeta
        [HttpPost("EstadosTarjeta")]
        public IActionResult AddEstadoTarjeta([FromBody] EstadoTarjeta estadoTarjeta)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _catalogosService.AddEstadoTarjeta(estadoTarjeta);
            return CreatedAtAction(nameof(GetEstadosTarjeta), new { id = estadoTarjeta.EstadoID }, estadoTarjeta);
        }

        // POST: api/Catalogos/TiposTarjeta
        [HttpPost("TiposTarjeta")]
        public IActionResult AddTipoTarjeta([FromBody] TipoTarjeta tipoTarjeta)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _catalogosService.AddTipoTarjeta(tipoTarjeta);
            return CreatedAtAction(nameof(GetTiposTarjeta), new { id = tipoTarjeta.TipoTarjetaID }, tipoTarjeta);
        }

    }
}
