using AppCuidandoPatitas.Datos;
using Microsoft.AspNetCore.Mvc;

namespace AppCuidandoPatitas.Controllers
{
    public class AdoptadosController : Controller
    {
        public DatosAdopciones DatosAdopciones = new();

        public IActionResult TraerListaAdoptadosVista()
        {
            var ListaAdopciones = DatosAdopciones.Listar();

            return View(ListaAdopciones);
        }

        public IActionResult AceptarAdopcion(int id)
        {
            var respuesta = DatosAdopciones.AceptarAdopcion(id);

            if (respuesta != 0)
            {
                TempData["SuccessMessage"] = "Se Acepto la adopcion.";
                return RedirectToAction("TraerListaAdoptadosVista");
            }
            else
            {
                return RedirectToAction("TraerListaAdoptadosVista");
            }


        }

        public IActionResult DeclinarAdopcion(int id)
        {
            var respuesta = DatosAdopciones.EliminarAdopcion(id);

            if (respuesta != 0)
            {
                TempData["SuccessMessage"] = "Se Elimino la adopcion.";
                return RedirectToAction("TraerListaAdoptadosVista");
            }
            else
            {
                return RedirectToAction("TraerListaAdoptadosVista");
            }


        }
    }
}
