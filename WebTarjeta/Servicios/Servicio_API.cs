using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebTarjeta.Models;

namespace WebTarjeta.Servicios
{
    public class Servicio_API:IServicio_API
    {
        private static string _urlbase;

        public Servicio_API()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            _urlbase = builder.GetSection("ApiSetting:urlbase").Value;
        }

        public async Task<List<Movimiento>> Get()
        {
            List<Movimiento> lista = new List<Movimiento>();
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:44388/api/movimientos");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var json=await response.Content.ReadAsStringAsync();
            lista= JsonConvert.DeserializeObject<List<Movimiento>>(json);

            return lista;

        }

        public async Task<Tarjeta> NumeroTarjeta(string NumeroTarjeta)
        {
            Tarjeta tarjetas = new Tarjeta();

            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get,$"https://localhost:44388/api/tarjetas/{NumeroTarjeta}");
            var response = await client.SendAsync(request);
           // response.EnsureSuccessStatusCode();
            
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                tarjetas = JsonConvert.DeserializeObject<Tarjeta>(json);

            }

            return tarjetas;
            
        }

        public async Task<bool> Post(Movimiento movimiento)
        {
            bool respuesta=false;
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, $"https://localhost:44388/api/movimientos");
            var content = new StringContent(JsonConvert.SerializeObject(movimiento),null, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
           // if (response.EnsureSuccessStatusCode())
            //{
             response.EnsureSuccessStatusCode();
            //}
            var r=await response.Content.ReadAsStringAsync();
            if (r == "OK") { 
                respuesta=true; 
            }

            return respuesta;
        }

        public async Task<Movimiento> Tarjeta(int IdTarjeta)
        {
            Movimiento mivimientoTarjeta = new Movimiento();

            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:44388/api/movimientos/tarjeta/{IdTarjeta}");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            //Console.WriteLine(await response.Content.ReadAsStringAsync());
            var json = await response.Content.ReadAsStringAsync();
            mivimientoTarjeta = JsonConvert.DeserializeObject<Movimiento>(json);
            return mivimientoTarjeta;

        }

        public async Task<Movimiento> TarjetaCompas(int IdTarjeta)
        {
            Movimiento compraTarjeta = new Movimiento();

            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:44388/api/movimientos/tarjetacompas/{IdTarjeta}");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            //Console.WriteLine(await response.Content.ReadAsStringAsync());
            var json = await response.Content.ReadAsStringAsync();
            compraTarjeta = JsonConvert.DeserializeObject<Movimiento>(json);
            return compraTarjeta;
        }

        //public Task<List<Movimiento>> TarjetaCompas(int IdTarjeta)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<Movimiento> TarjetaPagos(int IdTarjeta)
        {
            Movimiento pagoTarjeta = new Movimiento();

            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:44388/api/movimientos/tarjetapagos/{IdTarjeta}");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            //Console.WriteLine(await response.Content.ReadAsStringAsync());
            var json = await response.Content.ReadAsStringAsync();
            pagoTarjeta = JsonConvert.DeserializeObject<Movimiento>(json);
            return pagoTarjeta;
        }
    }
}
