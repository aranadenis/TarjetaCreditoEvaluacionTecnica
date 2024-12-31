using FrontEndTarjetaCredito.Models;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos;
using Newtonsoft.Json;
using System.Net.Http;

namespace FrontEndTarjetaCredito.Controllers
{
    public class EstadoCuentaController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public EstadoCuentaController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> VerEstadoCuenta(int id)
        {
            try
            {
                //var client = _httpClientFactory.CreateClient();

                // Crear cliente con la configuración de "ApiBase"
                var client = _httpClientFactory.CreateClient("ApiBase");

                // Obtener el estado de cuenta
                var estadoCuentaResponse = await client.GetAsync($"api/EstadoCuenta/{id}");
                if (!estadoCuentaResponse.IsSuccessStatusCode)
                {
                    ViewBag.ErrorMessage = "No se pudo obtener el estado de cuenta. Intenta nuevamente.";
                    return View();
                }

                var jsonEstadoCuenta = await estadoCuentaResponse.Content.ReadAsStringAsync();
                var estadoCuenta = JsonConvert.DeserializeObject<EstadoCuentaViewModel>(jsonEstadoCuenta);

                // Obtener compras mensuales
                var comprasResponse = await client.GetAsync($"api/Compra/{id}");
                if (comprasResponse.IsSuccessStatusCode)
                {
                    var jsonCompras = await comprasResponse.Content.ReadAsStringAsync();
                    var comprasMesActual = JsonConvert.DeserializeObject<IEnumerable<CompraMesActualDto>>(jsonCompras);
                    estadoCuenta.ComprasMesActual = comprasMesActual.ToList();
                }
                else
                {
                    ViewBag.WarningMessage = "No se pudo obtener las compras del mes actual.";
                    estadoCuenta.ComprasMesActual = new List<CompraMesActualDto>();
                }

                return View(estadoCuenta);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Error: {ex.Message}";
                return View();
            }
        }
    }
}
