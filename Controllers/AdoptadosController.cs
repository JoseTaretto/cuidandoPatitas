using Microsoft.AspNetCore.Mvc;

namespace AppCuidandoPatitas.Controllers
{
    public class AdoptadosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
