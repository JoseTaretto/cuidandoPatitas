using AppCuidandoPatitas.Datos;
using AppCuidandoPatitas.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AppCuidandoPatitas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        readonly DatosHome datosHome = new();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ModelHome modelHome = new();
            modelHome.ListaRescatados = datosHome.ListarRescatados();
            modelHome.ListaAdoptados = datosHome.ListarAdoptados();

            return View(modelHome);
        }

        public IActionResult IndexLogIn()
        {
            return View();
        }

        public IActionResult Nosotros()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GuardarMensaje(ModelHome objHome)
        {
            var respuesta = datosHome.Guardar(objHome);

            if (respuesta == true)
            {
                return RedirectToAction("Index");
            }
            else
            {
                
                return RedirectToAction("Index");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}