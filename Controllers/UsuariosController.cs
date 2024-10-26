using Microsoft.AspNetCore.Mvc;
using AppCuidandoPatitas.Datos;
using AppCuidandoPatitas.Interface;
using AppCuidandoPatitas.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace AppCuidandoPatitas.Controllers
{
    public partial class UsuariosController : Controller
    {
        readonly DatosUsuarios DatosUsuarios = new();
        readonly DatosDocumento DatosDocumento = new();

        public enum TipoDocumento
        {
            DocumentoHumano = 1,
            DocumentoAnimal = 2
        }

        [Authorize(Roles = "dmin")]
        public IActionResult ListarUsuarios()
        {
            var listaUsuarios = DatosUsuarios.Listar();
            var listaDocumentos = DatosDocumento.ListarDocumento((int)TipoDocumento.DocumentoHumano);

            return View(listaUsuarios);
        }

        public IActionResult NuevoUsuario()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GuardarUsuario(ModelUsuarios objUsuario)
        {
            var respuesta = DatosUsuarios.Guardar(objUsuario);

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

            var usuario = DatosUsuarios.TraerUno(id);

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

        public IActionResult DesactivarUser(int id)
        {
            var userBaja = Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var usuario = DatosUsuarios.Baja(id, userBaja);
            {
                if(usuario != 0)
                {
                    TempData["Mensaje"] = "Usuario dado de baja";
                    return RedirectToAction("listarUsuarios");
                }
                else
                {
                    TempData["Mensaje"] = "No existe el usuario";
                    return RedirectToAction("listarUsuarios");

                }

            }
        }

        [HttpPost]
        public IActionResult editarUsuario(ModelUsuarios objUsuario)
        {

            var respuesta = DatosUsuarios.Editar(objUsuario);

            if (respuesta == true)
            {
                return RedirectToAction("editarUsuarios");
            }
            else
            {
                Console.WriteLine("error");
                return View();
            }
        }

        public IActionResult EditarUsuarioView(int id)
        {

            var usuario = DatosUsuarios.TraerUno(id);

            if (usuario != null)
            {
                Console.WriteLine($"ID del Usuario: {id}");
                return View("EditarUsuarioView", usuario);
            }
            else
            {
                Console.WriteLine("error");
                return View();
            }
        }
    }
}
