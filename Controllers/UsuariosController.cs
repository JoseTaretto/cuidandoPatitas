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
    public class UsuariosController : Controller
    {
        readonly DatosUsuarios DatosUsuarios = new();
        readonly DatosDocumento DatosDocumento = new();

        public enum TipoDocumento
        {
            DocumentoHumano = 1           
        }

        [Authorize(Roles = "admin")]
        public IActionResult ListarUsuarios()
        {
            var listaUsuarios = DatosUsuarios.Listar();     

            return View(listaUsuarios);
        }

        public IActionResult NuevoUsuario()
        {
            var listaDocumentos = DatosDocumento.ListarDocumento((int)TipoDocumento.DocumentoHumano);
            ViewBag.ListaDocumentos = listaDocumentos;

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
                return View("VerUser", usuario);
            }
            else
            {
                return View();
            }
        }

        public IActionResult DesactivarUser(int id)
        {
            var userBajaId = Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var usuario = DatosUsuarios.Baja(id, userBajaId);

            if (usuario)
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

        public IActionResult EditarUsuarioView(int id)
        {
            var usuario = DatosUsuarios.TraerUno(id);          

            if (usuario != null)
            {
                var listaDocumentos = DatosDocumento.ListarDocumento((int)TipoDocumento.DocumentoHumano);
                ViewBag.ListaDocumentos = listaDocumentos;
                return View(usuario);
            }
            else
            {
                return RedirectToAction("listarUsuarios");
            }
        }

        [HttpPost]
        public IActionResult Editar(ModelUsuarios objUsuario)
        {

            var respuesta = DatosUsuarios.Editar(objUsuario);

            if (respuesta)
            {
                return RedirectToAction("listarUsuarios");
            }
            else
            {             
                return View();
            }
        }
    }
}
