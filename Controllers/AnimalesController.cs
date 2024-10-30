using Microsoft.AspNetCore.Mvc;
using AppCuidandoPatitas.Datos;
using AppCuidandoPatitas.Models;
using System.Collections.Generic;

namespace AppCuidandoPatitas.Controllers
{
    public class AnimalesController : Controller
    {
        private readonly DatosAnimales _datosAnimales;

        public AnimalesController(DatosAnimales datosAnimales)
        {
            _datosAnimales = datosAnimales;
        }

        public IActionResult Index()
        {
            List<ModelAnimales> listaAnimales = _datosAnimales.Listar(); // Aseg�rate de implementar este m�todo
            return View("ListarAnimales", listaAnimales);
        }
    }
}
