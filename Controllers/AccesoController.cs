using Microsoft.AspNetCore.Mvc;
using AppCuidandoPatitas.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using AppCuidandoPatitas.Datos;


namespace AppCuidandoPatitas.Controllers
{
    public class AccesoController : Controller
    {
        public IActionResult LogIn()
        {
            return View();  
        }

        [HttpPost]
        public async Task<IActionResult> LogInIndex(ModelUsuarios user) { 
        
            DatosUsuarios ObjUsuario = new();

            var usuario = ObjUsuario.ValidarUsuario(user.UsuarioUserName, user.UsuarioPassword);

            if (usuario != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario.UsuarioUserName),
                    new Claim(ClaimTypes.NameIdentifier, usuario.UsuarioId.ToString()),
                    new Claim(ClaimTypes.Role, usuario.UsuarioRol)                 

                };

                var ClaimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(ClaimsIdentity));

                return RedirectToAction("IndexLogin", "Home");
            }

            else
            {
                TempData["SuccessMessage"] = "Ha ingresado una contraseña erronea o un usuario erroneo";
                return RedirectToAction("LogIn", "Acceso");
            }

        }

        // Salir de la Aplicacion

        public async Task<IActionResult> Salir()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }


    }
}
