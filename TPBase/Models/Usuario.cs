
namespace TPBase.Models
{
    public class Usuario
    {
        public int IdUsuario {get; set;}
        public string Nombre {get; set;}
        public string Contraseña {get; set;}

        public Usuario(int idUsuario, string contraseña, string nombre)
        {           
            IdUsuario = idUsuario;
            Contraseña = contraseña;
            Nombre = nombre;
        }

        public Usuario() { }

    }
}
