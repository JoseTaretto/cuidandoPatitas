using Microsoft.AspNetCore.Mvc;
using AppCuidandoPatitas.Datos;
using AppCuidandoPatitas.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace AppCuidandoPatitas.Controllers
{
    public class AnimalesController : Controller
    {
        readonly DatosAnimales DatosAnimales = new();
       
        public IActionResult traerMascotas()
        {
            var listaAnimales = DatosAnimales.Listar();
            return View("ListarAnimales", listaAnimales);
        }

        public IActionResult vistaIngresarMascota()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult ingresarMascota(ModelAnimales objMascota)

        {
            var respuesta = DatosAnimales.Guardar(objMascota);

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
              
            }
        }

        [HttpPost]
        public IActionResult adoptarMascota(int animalId, int userId){

            var respuesta = DatosAnimales.adoptarAnimal(animalId, userId);

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

            var respuesta = DatosAnimales.eliminarAnimal(animalId);

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

            var respuesta = DatosAnimales.Editar(objAnimal);

             if (respuesta != true)
            {
                return RedirectToAction("traerMascotas");
            }
            else
            {
                return traerMascotas();
            }                 
        }

        public IActionResult modificarAnimalVista(int animalId)
        {

            var mascota = DatosAnimales.TraerUno(animalId);

            if(mascota != null)
            {
                return View(mascota);
            }
            else
            {
                return RedirectToAction("traerMascotas");
            }
        }
    }
}