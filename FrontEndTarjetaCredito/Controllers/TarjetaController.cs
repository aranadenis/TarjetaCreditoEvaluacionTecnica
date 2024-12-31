using FrontEndTarjetaCredito.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEndTarjetaCredito.Controllers
{
    public class TarjetaController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TarjetaController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:5128/api/Tarjetas");

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.ErrorMessage = "No se pudo recuperar la información de las tarjetas.";
                return View("Error");
            }

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var tarjetas = JsonConvert.DeserializeObject<List<TarjetaViewModel>>(jsonResponse);

            return View(tarjetas);
        }
    }
}
