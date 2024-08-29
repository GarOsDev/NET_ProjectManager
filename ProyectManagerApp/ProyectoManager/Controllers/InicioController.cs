using Microsoft.AspNetCore.Mvc;
using ProyectoManager.Models;
using ProyectoManager.Recursos;
using ProyectoManager.Servicios.Contrato;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace ProyectoManager.Controllers
{
    public class InicioController : Controller
    {
        private IUsuarioService _usuarioServicio;

        public InicioController(IUsuarioService usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
        }
       
        public IActionResult Registrarse()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Registrarse(Usuarios modelo)
        {
            modelo.contrasena = Utilidades.EncriptarClave(modelo.contrasena);
            Usuarios usuario_creado = await _usuarioServicio.SaveUsuario(modelo);

            if (usuario_creado.id_usuario > 0)
                return RedirectToAction("IniciarSesion", "Inicio");

            ViewData["Mensaje"] = "Error al crear usuario";
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> RegistrarseLogueado(Usuarios modelo)
        {
            modelo.contrasena = Utilidades.EncriptarClave(modelo.contrasena);
            Usuarios usuario_creado = await _usuarioServicio.SaveUsuario(modelo);

            if (usuario_creado.id_usuario > 0)
                return RedirectToAction("Index", "Usuarios");

            ViewData["Mensaje"] = "Error al crear usuario";
            return View();
        }


        public IActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion(string email, string contrasena )
        {
            Usuarios usuario_encontrado = await _usuarioServicio.GetUsuarios(email, Utilidades.EncriptarClave(contrasena));

            if(usuario_encontrado == null)
            {
                ViewData["Mensaje"] = "Usuario no encontrado";
                return View();
            }

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, usuario_encontrado.nombre)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    properties
            );
            return RedirectToAction("Index", "Home");
        }

    }
}
