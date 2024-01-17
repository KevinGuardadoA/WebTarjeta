using Microsoft.AspNetCore.Mvc;
using WebTarjeta.Models;

namespace WebTarjeta.Servicios
{
    public interface IServicio_API
    {
        Task<List<Movimiento>>  Get();
        Task<Movimiento> Tarjeta(int IdTarjeta);
        Task<Movimiento> TarjetaPagos(int IdTarjeta);
        Task<Movimiento> TarjetaCompas(int IdTarjeta);
        Task<bool> Post(Movimiento movimiento);
        Task<Tarjeta> NumeroTarjeta(string NumeroTarjeta);
        //Task<Tarjeta> NumeroTarjeta(Func<string, Task<IActionResult>> numeroTarjeta);
        //Task<List<Movimiento>> TarjetaCompas(int IdTarjeta);
    }
}
