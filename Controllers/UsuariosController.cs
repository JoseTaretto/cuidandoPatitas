using Microsoft.AspNetCore.Mvc;
using AppCuidandoPatitas.Datos;
using AppCuidandoPatitas.Models;
using System.Reflection;

namespace AppCuidandoPatitas.Controllers
{
    public class UsuariosController : Controller
    {
        readonly DatosUsuarios DatosUsuarios = new DatosUsuarios();

        public IActionResult ListarUsuarios()
        {
            var listaUsuarios = DatosUsuarios.Listar();
            return View(listaUsuarios);
        }

        public IActionResult NuevoUsuario()
        {
            return View();
        }

        [HttpPost]

        public IActionResult GuardarUsuario(ModelUsuarios objUsuario)
        {

            var respuesta = DatosUsuarios.guardar(objUsuario);

            if(respuesta == true)
            {
                return RedirectToAction("listarUsuarios");
            }
            else
            {
                Console.WriteLine("error");
                return View();
            }
        }

        public IActionResult TraerUsuario(int id) {

            var usuario = DatosUsuarios.obtenerUsuario(id);

            if (usuario != null)
            {
                Console.WriteLine($"ID del Usuario: {id}" );
                return View("VerUser", usuario);
            }
            else
            {
                Console.WriteLine("error");
                return View();
            }
        }

    }
}
