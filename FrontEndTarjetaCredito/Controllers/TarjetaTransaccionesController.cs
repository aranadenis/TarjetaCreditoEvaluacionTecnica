using FrontEndTarjetaCredito.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace FrontEndTarjetaCredito.Controllers
{
    public class TarjetaTransaccionesController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TarjetaTransaccionesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult AgregarPago(int tarjetaId)
        {
            return View(new PagoViewModel { TarjetaID = tarjetaId });
        }

        


        public async Task<IActionResult> AgregarPago(PagoViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                var client = _httpClientFactory.CreateClient();
                var pago = new
                {
                    pagoID = 0,
                    tarjetaID = model.TarjetaID,
                    fechaPago = model.FechaPago,
                    monto = model.Monto
                };

                var json = JsonConvert.SerializeObject(pago);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("http://localhost:5128/api/Pago", content);

                if (!response.IsSuccessStatusCode)
                {
                    ViewBag.ErrorMessage = "No se pudo agregar el pago. Intenta nuevamente.";
                    return View(model);
                }

                // Redirige a la vista de confirmación después de un pago exitoso
                return RedirectToAction("ConfirmacionPago", new { monto = model.Monto });
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Error: {ex.Message}";
                return View(model);
            }
        }

        public IActionResult ConfirmacionPago(decimal monto)
        {
            ViewBag.Monto = monto; // Se pasa el monto como un parámetro
            return View();
        }
    




        [HttpGet]
        public IActionResult AgregarCompra(int tarjetaId)
        {
            return View(new CompraViewModel { TarjetaID = tarjetaId });
        }

        [HttpPost]
        public async Task<IActionResult> AgregarCompra(CompraViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                var client = _httpClientFactory.CreateClient();
                var compra = new
                {
                    compraID = 0,
                    tarjetaID = model.TarjetaID,
                    fechaCompra = model.FechaCompra,
                    descripcion = model.Descripcion,
                    monto = model.Monto
                };

                var json = JsonConvert.SerializeObject(compra);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("http://localhost:5128/api/Compra", content);

                if (!response.IsSuccessStatusCode)
                {
                    ViewBag.ErrorMessage = "No se pudo agregar la compra. Intenta nuevamente.";
                    return View(model);
                }

                // Redirige a la vista de confirmación después de una compra exitosa
                return RedirectToAction("ConfirmacionCompra", new { monto = model.Monto });
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Error: {ex.Message}";
                return View(model);
            }
        }

        public IActionResult ConfirmacionCompra(decimal monto)
        {
            ViewBag.Monto = monto; // Pasamos el monto de la compra a la vista
            return View();
        }

    }
}
