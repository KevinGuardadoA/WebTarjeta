namespace WebTarjeta.Models
{
    public class Tarjeta
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public double Saldo { get; set; }
        public double Limite { get; set; }
        public double Disponible { get; set; }
        public double TasaInteres { get; set; }
        public string NumeroTarjeta { get; set; }
        public string CCV { get; set; }
        public string Expedicion { get; set; }
        public string Vencimiento { get; set; }
        //public List<Movimiento> movimientos { get; set; }


    }
}
