using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class SuperDigitoController : Controller
    {
        public ActionResult GetAll(string Username)
        {
            ML.Usuario usuario = new ML.Usuario();
            ML.SuperDigito superDigito = new ML.SuperDigito();
            ML.Result result = BL.SuperDigito.SDByUsuario(Username);            

            if (result.Correct)
            {
                superDigito.SuperDigitos = result.Objects; 
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al hacer la consulta de Usuarios";
            }

            return View(superDigito); 
        }
    }
}
