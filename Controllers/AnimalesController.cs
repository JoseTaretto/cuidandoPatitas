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

            try
            {

                if (respuesta == true)
                {
                    return traerMascotas();

                }
                else
                {
                    return View(objMascota);

                }
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}