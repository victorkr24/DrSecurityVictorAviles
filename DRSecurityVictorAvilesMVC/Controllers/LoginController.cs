using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using DRSecurityVictorAvilesMVC.Datos;
using DRSecurityVictorAvilesMVC.Models;
namespace DRSecurityVictorAvilesMVC.Controllers
{
    public class LoginController : Controller
    {
        ContactoDatos _ContactoDatos = new ContactoDatos();
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {
            string password = "123";
            string emails = "prueba@gmail.com";
            if(password == usuario.Passwoord && emails == usuario.Correo)
            {
               return RedirectToAction("Listar", "Mantenedor");
            }
            else
            {
                ViewBag.Message = "La contraseña no existe";
                return View();
            }
            
        }
    

    }
}
