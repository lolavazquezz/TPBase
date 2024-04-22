

namespace TPBase.Models
{
    public class Concierto
    {
        public int IdConcierto {get; set;}
        public string Nombre {get; set;}
        public string Descripcion {get; set;}
        public DateTime FechaConcierto {get; set;}
        public string Imagen {get; set;}
        public int Precio {get; set;}
        public int FkCategoria {get; set;}
         public int CantLikes{get; set;}

        public Concierto(int idConcierto, string nombre, string descripcion, DateTime fechaConcierto, string imagen, int precio, int fkCategoria, int cantLikes)
        {
            IdConcierto = idConcierto;
            Nombre = nombre;
            Descripcion = descripcion;
            FechaConcierto = fechaConcierto;
            Imagen = imagen;
            Precio = precio;
            FkCategoria = fkCategoria;
            CantLikes = cantLikes;
        }

        public Concierto() { }
    }
}
