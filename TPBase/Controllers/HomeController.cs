using Microsoft.AspNetCore.Mvc;
using TPBase.Models;
namespace TPBase.Controllers;

public class HomeController : Controller
{
    public static int idUsuario; 
    private readonly ILogger<HomeController> _logger;
    private IWebHostEnvironment Environment;
       
    public HomeController(IWebHostEnvironment environment)
    {
        Environment = environment;
    }

    public IActionResult Index()
    {
        return View("IniciarSesion");
    }
    public IActionResult Creditos()
    {
        return View();
    }
    public IActionResult VerificarTarjeta(Tarjeta T)
    {
        Tarjeta tarjeta = BD.VerificarSiExisteTarjeta(T.Numero);
        if (tarjeta != null)
        {
            return RedirectToAction("Compra", "Home");
        }
        else
        {
            return RedirectToAction("Error", "Home");
        }
    }
    public IActionResult Compra()
    {
        return View();
    }
    [HttpPost]
    public int LikesAjax(int IdConcierto, int cantLikes)
    {
        BD.ActualizarLikesconciertoSP(IdConcierto, cantLikes);
        return BD.VerCantLikes(IdConcierto);
    }

    

    public IActionResult VerificarUsuario(Usuario U)
    {

        if (VerificarSiExisteUsuario(U) == true)
        {
            Usuario usuarioBD = BD.BuscarUsuarioXNombre(U.Nombre);

            if (usuarioBD.Contraseña == U.Contraseña)
            {
                idUsuario = usuarioBD.IdUsuario;
                return RedirectToAction("PaginaPrincipal", "Home");

            }
            else
            {
                ViewBag.Mensaje = "La contraseña es incorrecta";
                return View("IniciarSesion");
            }
        }
        else 
        {
            ViewBag.Mensaje = "El usuario no existe o es incorrecto";
            return View("IniciarSesion");
        }
    }
    public bool VerificarSiExisteUsuario(Usuario U)
    {
        return BD.BuscarUsuarioXNombre(U.Nombre) != null;
    }
    public IActionResult VerificarUsuarioRegistro(Usuario U, string Contraseña2)
    {

        if (VerificarSiExisteUsuario(U) == true)
        {
            ViewBag.Mensaje = "El usuario ya existe, ingrese otro nombre";
            return View("Registrarse");
        }
        if (U.Contraseña != Contraseña2)
        {
            ViewBag.Mensaje = "Las contraseñas no coinciden";
            return View("Registrarse");
        }
        BD.AgregarUsuario(U);

        return RedirectToAction("PaginaPrincipal", "Home");
    }
    public IActionResult Registrarse()
    {
        return View();
    }
    public IActionResult OlvidoContraseña(Usuario U)
    {
        ViewBag.Usuario = BD.BuscarContraXUsuario(U.Nombre);
        if (ViewBag.Usuario != null)
        {
            ViewBag.Mensaje = "La contraseña es: " + ViewBag.Usuario.Contraseña;
        }
        else
        {
            ViewBag.Mensaje = "No encontramos el usuario ingresado";
        }
        return View();
    }
    public IActionResult BuscarOlvidoContraseña()
    {
        return View("OlvidoContraseña");
    }
    [HttpPost]
    public IActionResult InsertarUsuario(Usuario U, string Contraseña2)
    {
        if (U.Contraseña == Contraseña2)
        {
            BD.AgregarUsuario(U);
            return RedirectToAction("PaginaPrincipal", "Home");
        }
        else
        {
            ViewBag.Mensaje = "Las contraseñas no coinciden";
            return View("Registrarse");
        }
    }

    public IActionResult PaginaPrincipal(int idConcierto)
    {
        @ViewBag.listaconciertos = BD.TraerConciertos();
        return View("Index");
    }

    public Concierto MostrarConciertosAjax(int IdConcierto)
    {
        return BD.verInfoConcierto(IdConcierto);

    }
     public IActionResult GuardarConcierto(int idConcierto)
    {
        DateTime fechaCompra= DateTime.Today;
        @ViewBag.listaconciertos = BD.TraerConciertos();
        string nombreConcierto = BD.TraerNombreConcierto(idConcierto);
        BD.GuardarCompra(idUsuario, idConcierto, fechaCompra, nombreConcierto);
        return View("Index");
    }
    public IActionResult ComprarConcierto(int idConcierto)
    {
          ViewBag.idConcierto = idConcierto;
          return View(idConcierto);
    }

    public Concierto MostrarMasInfoAjax(int IdConcierto)
    {
        return BD.verInfoConcierto(IdConcierto);
    }

    public IActionResult CrearCuentaAjax(Usuario usuario)
    {
        BD.AgregarUsuario(usuario);
        return View("Index");

    }
     private static List<HistorialCompras> historial = new List<HistorialCompras>();     
    public IActionResult VerHistorial()
    {
       List<HistorialCompras> historial = BD.TraerHistorialCompras(idUsuario);
        return View("HistorialCompras",historial);
    }
}