using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using ProyectoManager.Data;
using ProyectoManager.Models;
using System.Diagnostics;
using System.Security.Claims;
using Newtonsoft.Json;
using ProyectoManager.Recursos;

namespace ProyectoManager.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ProyectoManagerContext _context;
        public HomeController(ProyectoManagerContext context)
        {
            _context = context;
        }       

        public async Task<IActionResult> Index(string SearchTitle, string SearchContent, DateOnly SearchDate)
        {

            if (_context.Publicaciones == null)
            {
                return Problem("Entity set 'MvcHomeContext.Publicaciones'  is null.");
            }

            //var publi = from m in _context.Publicaciones select m;
            var queryPublicaciones = _context.Publicaciones.AsQueryable();


            if (!String.IsNullOrEmpty(SearchTitle) || !String.IsNullOrEmpty(SearchContent) || SearchDate != DateOnly.MinValue)
            {
                //publi = publi.Where(s => s.titulo!.Contains(SearchTitle) || s.contenido!.Contains(SearchContent) || s.fecha == SearchDate);
                queryPublicaciones = queryPublicaciones.Where(s => s.titulo!.Contains(SearchTitle) || s.contenido!.Contains(SearchContent) || s.fecha == SearchDate);
            }

            var publicaciones = await queryPublicaciones.Select(p => new PublicationViewModel
            {
                id_publicacion = p.id_publicacion,
                titulo = p.titulo,
                contenido = p.contenido,
                fecha = p.fecha,
                nombre = _context.Usuarios.FirstOrDefault(u => u.id_usuario == p.id_usuario).nombre
            }).ToListAsync();

            var usuarios = await _context.Usuarios.ToListAsync();

            var viewModel = new PublicationIndexViewModel
            {
                Publicaciones = publicaciones,
                Usuarios = usuarios,
                SearchTitle = SearchTitle,
                SearcContent = SearchContent,
            };

            return View(viewModel);
        }

        [Route("upload/image")]
        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest(new { message = "No file uploaded" });
            }

            var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
            if (!Directory.Exists(uploads))
            {
                Directory.CreateDirectory(uploads);
            }

            var filePath = Path.Combine(uploads, file.FileName);
            using(var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            var fileUrl = $"/uploads/{file.FileName}";
            return Ok(new {location = fileUrl});
        }

        //*********************** VENTANA MODAL EDITAR ******************************************

        [HttpPost]
        public async Task<IActionResult> Update([Bind("id_publicacion,titulo,fecha,contenido,id_usuario")] Publicaciones model)
        {

            if (ModelState.IsValid)
            {
                var publicacion = await _context.Publicaciones.FindAsync(model.id_publicacion);
                if (publicacion != null)
                {
                    publicacion.titulo = model.titulo;
                    publicacion.contenido = model.contenido;
                    publicacion.fecha = model.fecha;
                    publicacion.id_usuario = model.id_usuario;

                    _context.Update(publicacion);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }


        //*********************** VENTANA MODAL CREAR ******************************************

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("titulo,fecha,contenido,id_usuario")] Publicaciones model)
        {
            if (ModelState.IsValid)
            {
                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        //*********************** VENTANA MODAL ELIMINAR ******************************************

        [HttpPost]
        public async Task<IActionResult> Delete(int id_publicacion)
        {

            var publicacion = await _context.Publicaciones.FindAsync(id_publicacion);
            if (publicacion == null)
            {
                return NotFound();
            }

            _context.Publicaciones.Remove(publicacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        //*********************** VISTA PRIVACY ******************************************

        public IActionResult Privacy()
        {
            return View();
        }

        //********************************************************************************

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> CerrarSesion()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("IniciarSesion", "Inicio");
        }
    }
}
