using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebTarjeta.Extencion;
using WebTarjeta.Models;
using WebTarjeta.Servicios;

namespace WebTarjeta.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServicio_API _servicioApi;

        public HomeController(IServicio_API servicio_API)
        {
            _servicioApi = servicio_API;
        }

        public async Task< IActionResult> Index()
        {
            List<Movimiento> movimientos =await _servicioApi.Get();
            return View(movimientos);
        }
        [HttpPost]
        public async Task<IActionResult> NumeroTarjeta(string NumeroTarjeta)
        {
            Tarjeta modelo_tarjeta= new Tarjeta();
           // ViewBag.Accion = "";
           // List<Tarjeta> modelo
               modelo_tarjeta = await _servicioApi.NumeroTarjeta(NumeroTarjeta);
            if (modelo_tarjeta is null)
            {
                return NoContent();
            }
            //ViewBag.Tarjeta(ViewBag.NumeroTarjeta);
            //var id = modelo_tarjeta.Id;
            //HttpContent
            HttpContext.Session.SetObject("Tarjeta", modelo_tarjeta);
            //Movimiento movimientos = await _servicioApi.TarjetaPagos(id);
            //ViewBag.movimientos(ViewBag.movimiento);
            //modelo_tarjeta.movimientos=new List<Movimiento> { movimientos };
            return View();
            //Tarjeta tarjeta = new Tarjeta();
            //Task<Tarjeta> tarjeta = await _servicioApi.NumeroTarjeta(NumeroTarjeta);
            //return View(tarjeta);
        }
        public async Task<IActionResult> pagosTarjeta(int IdTarjeta)
        {
            //List<Movimiento> movimientos = await _servicioApi.Get();
            //Tarjeta modelo_tarjeta = new Tarjeta();
            // ViewBag.Accion = "";
            // List<Tarjeta> modelo
            //Movimiento movimientos = new Movimiento();
            Movimiento movimientos = await _servicioApi.TarjetaPagos(IdTarjeta);

            if (movimientos is null)
            {
                return NoContent();
            }
            return View(movimientos);
            //Tarjeta tarjeta = new Tarjeta();
            //Task<Tarjeta> tarjeta = await _servicioApi.NumeroTarjeta(NumeroTarjeta);
            //return View(tarjeta);
        }
        [HttpPost]
        public async Task<IActionResult> GuardarPago(Movimiento movimiento)
        {
            bool respuesta;
            respuesta = await _servicioApi.Post(movimiento);
            if (respuesta)
            {
                return View("Index");
            }
            else
            {
                return NoContent();
            }
            

        }

        public IActionResult Pago()
        {
            return View();
        }
        public IActionResult Compra()
        {
            return View();
        }
        public IActionResult NumeroTarjeta()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}