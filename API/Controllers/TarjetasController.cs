using Data.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Dtos;
using System.Text;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarjetasController : ControllerBase
    {

        private readonly ITarjetaService _tarjetaService;

        public TarjetasController(ITarjetaService tarjetaService)
        {
            _tarjetaService = tarjetaService;
        }

        // GET: api/Tarjetas
        [HttpGet]
        public IActionResult GetAll()
        {
            var tarjetas = _tarjetaService.GetAllTarjetas();
            return Ok(tarjetas);
        }

        // GET: api/Tarjetas/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var tarjeta = _tarjetaService.GetTarjetaById(id);
            if (tarjeta == null)
                return NotFound();

            return Ok(tarjeta);
        }
        // POST: api/Tarjetas
        [HttpPost]
        public IActionResult Create(TarjetaDto tarjetaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            tarjetaDto.NumeroTarjeta = Convert.ToBase64String(Encoding.UTF8.GetBytes(tarjetaDto.NumeroTarjeta));
            tarjetaDto.CVV = Convert.ToBase64String(Encoding.UTF8.GetBytes(tarjetaDto.CVV));

            _tarjetaService.AddTarjeta(tarjetaDto);
            return CreatedAtAction(nameof(GetById), new { id = tarjetaDto.TarjetaID }, tarjetaDto);
        }

        // PUT: api/Tarjetas/{id}
        //[HttpPut("{id}")]
        //public IActionResult Update(int id, [FromBody] Tarjeta tarjeta)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    if (id != tarjeta.TarjetaID)
        //        return BadRequest();

        //    var existingTarjeta = _tarjetaService.GetTarjetaById(id);
        //    if (existingTarjeta == null)
        //        return NotFound();

        //    _tarjetaService.UpdateTarjeta(tarjeta);
        //    return NoContent();
        //}


    }
}
