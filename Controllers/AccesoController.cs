using Microsoft.AspNetCore.Mvc;

namespace AppCuidandoPatitas.Controllers
{
    public class AccesoController : Controller
    {
        public IActionResult LogIn()
        {
            return View();
        }
    }
}
