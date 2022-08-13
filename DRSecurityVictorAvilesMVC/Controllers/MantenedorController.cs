using Microsoft.AspNetCore.Mvc;
using DRSecurityVictorAvilesMVC.Datos;
using DRSecurityVictorAvilesMVC.Models;
namespace DRSecurityVictorAvilesMVC.Controllers
{

    public class MantenedorController : Controller
    {

        ContactoDatos _ContactoDatos = new ContactoDatos();

        public IActionResult Listar()
        {
            var oLista = _ContactoDatos.Listar();

            return View(oLista);
        }

        public IActionResult Guardar()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Guardar(Carro oContacto)
        {



            var respuesta = _ContactoDatos.Guardar(oContacto);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }

            else
            {
                return View();
            }
        }

        public IActionResult Editar(int IdCarro)
        {

            var ocontacto = _ContactoDatos.Obtener(IdCarro);
            return View(ocontacto);
        }

        [HttpPost]
        public IActionResult Editar(Carro oContacto)
        {
            



            var respuesta = _ContactoDatos.Editar(oContacto);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }

            else
            {
                return View();
            }

        }

        public IActionResult Eliminar(int IdCarro)
        {
            //METODO SOLO DEVUELVE LA VISTA
            var ocontacto = _ContactoDatos.Obtener(IdCarro);
            return View(ocontacto);
        }
        [HttpPost]
        public IActionResult Eliminar(Carro oContacto)
        {

            var respuesta = _ContactoDatos.Eliminar(oContacto.IdCarro);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }

            else
            {
                return View();
            }
        }

    }
}
