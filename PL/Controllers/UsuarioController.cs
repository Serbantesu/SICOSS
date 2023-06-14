using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Security.Cryptography;

namespace PL.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(ML.Usuario usuario, string password)
        {
            ML.SuperDigito superDigito = new ML.SuperDigito();  
            //Crear una instancia del algoritmo de hash bcrypt
            var bcrypt = new Rfc2898DeriveBytes(password, new byte[20], 10000, HashAlgorithmName.SHA256);
            //Obtener el hash de la contraseña ingresada 
            var passwordHash = bcrypt.GetBytes(20);

            if (usuario.Username == null)
            {
                usuario.Password = passwordHash;
                ML.Result result = BL.Usuario.UsuarioAdd(usuario);
                return View();
            }
            else
            {
                ML.Result result = BL.SuperDigito.SDByUsuario(usuario.Username);
                //usuario = (ML.Usuario)result.Object;
                superDigito = (ML.SuperDigito)result.Object;

                //if (usuario.Password.SequenceEqual(passwordHash))
                //{
                return RedirectToAction("GetAll", "SuperDigito", new { UserName = usuario.Username });
                //return RedirectToAction("Index", "Home");
                //}
            }            
        }
    }
}
