using Microsoft.AspNetCore.Mvc;
using AppCuidandoPatitas.Datos;
using AppCuidandoPatitas.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace AppCuidandoPatitas.Controllers
{
    public class MensajesController : Controller
    {
        readonly DatosMensajes DatosMensajes = new();

        [Authorize(Roles = "cp_admin")]
        public IActionResult ListarMensajesView()
        {
            var listaMensajes = DatosMensajes.Listar();

            return View(listaMensajes);
        }

        [Authorize(Roles = "cp_admin")]
        public IActionResult VerMensajeView(int id)
        {
            var objMensaje = DatosMensajes.TraerUno(id);

            return View(objMensaje);
        }
    }
}
