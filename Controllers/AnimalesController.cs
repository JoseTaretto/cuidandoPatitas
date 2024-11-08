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
                return RedirectToAction("traerMascotas", "Animales");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]

        public IActionResult adoptarMascota(int animalId){

            var respuesta = _datosAnimales.adoptarAnimal(animalId);

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