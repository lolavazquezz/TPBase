namespace TPBase.Models
{
    public class Categoria
    {
        public int IdCategoria { get; set; }
        public string TipoCategoria { get; set; }

        public Categoria(int idCategoria, string tipoCategoria)
        {
            IdCategoria = idCategoria;
            TipoCategoria = tipoCategoria;
        }

        public Categoria() { }
    }
}
