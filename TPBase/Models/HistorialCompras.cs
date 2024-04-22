namespace TPBase.Models
{
    public class HistorialCompras
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdConcierto { get; set; }
        public string nombreConcierto { get; set; }
        public DateTime FechaCompra { get; set; }
    }
}
