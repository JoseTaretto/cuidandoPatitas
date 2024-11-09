using Microsoft.AspNetCore.Mvc;
using AppCuidandoPatitas.Datos;
using AppCuidandoPatitas.Models;

namespace AppCuidandoPatitas.Controllers
{
    public class AnimalesController : Controller
    {
        private readonly DatosAnimales _datosAnimales;

        public AnimalesController(DatosAnimales datosAnimales)
        {
            _datosAnimales = datosAnimales;
        }

        public IActionResult traerMascotas()
        {
            List<ModelAnimales> listaAnimales = _datosAnimales.Listar();
            return View("ListarAnimales", listaAnimales);
        }

        [HttpGet]
        public IActionResult vistaIngresarMascota()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult ingresarMascota(ModelAnimales objMascota)

        {
            var respuesta = _datosAnimales.ingresarAnimal(objMascota);

            if (respuesta == true)
            {
                TempData["SuccessMessage"] = "La mascota se ingresó correctamente.";
                return RedirectToAction("traerMascotas");
                
            }
            else
            {
                TempData["ErrorMessage"] = "No se pudo ingresar la mascota. Intenta nuevamente.";
                TempData["ModelErrors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("vistaIngresarMascota");
                //return View();
            }
        }

        [HttpPost]
        public IActionResult adoptarMascota(int animalId, int userId){

            var respuesta = _datosAnimales.adoptarAnimal(animalId, userId);

            if (respuesta != 0)
            {
                return traerMascotas();
            }
            else
            {
                 return traerMascotas(); //ENTRA AL ELSE POR EL USER ID
            }                 
        }   

        [HttpPost]
        public IActionResult eliminarMascota(int animalId) {

            var respuesta = _datosAnimales.eliminarAnimal(animalId);

             if (respuesta != 0)
            {
                return traerMascotas();
            }
            else
            {
                return View();
            }                 
        }

        [HttpPost]
        public IActionResult actualizarMascota(ModelAnimales objAnimal) {

            var respuesta = _datosAnimales.actualizarAnimal(objAnimal);

             if (respuesta != true)
            {
                return View();
            }
            else
            {
                return traerMascotas();
            }                 
        }
    }
}