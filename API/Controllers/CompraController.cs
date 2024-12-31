using Data.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.Dtos;
using System;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        private readonly ICompraService _compraService;

        public CompraController(ICompraService compraService)
        {
            _compraService = compraService;
        }

        [HttpPost]
        public IActionResult AddCompra([FromBody] CompraDto compraDto)
        {
            _compraService.AddCompra(compraDto);
            return Ok(new { message = "Compra agregada exitosamente." });
        }

        //GET /api/Compra/date-range?startDate=YYYY-MM-DD&endDate=YYYY-MM-DD: Recupera compras dentro de un rango de fechas
        [HttpGet("date-range")]
        public IActionResult GetComprasByDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var compras = _compraService.GetComprasByDateRange(startDate, endDate);
            return Ok(compras);
        }

        //GET /api/Compra/month? year = YYYY & month = MM Recupera compras realizadas en un mes específico.
        [HttpGet("month")]
        public IActionResult GetComprasByMonth([FromQuery] int year, [FromQuery] int month)
        {
            var compras = _compraService.GetComprasByMonth(year, month);
            return Ok(compras);
        }

        [HttpGet("{tarjetaId}")]
        public IActionResult ObtenerComprasMesActual(int tarjetaId)
        {
            try
            {
                var comprasMesActual = _compraService.ObtenerComprasMesActual(tarjetaId);

                if (comprasMesActual == null)
                    return NotFound(new { Message = "Compras no encontradas." });

                return Ok(comprasMesActual);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }


    }
}
