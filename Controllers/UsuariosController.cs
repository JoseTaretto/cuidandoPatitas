using Microsoft.AspNetCore.Mvc;
using AppCuidandoPatitas.Datos;
using AppCuidandoPatitas.Models;

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
    }
}
