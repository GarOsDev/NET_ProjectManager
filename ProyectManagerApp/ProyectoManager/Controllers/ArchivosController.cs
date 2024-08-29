using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoManager.Data;
using ProyectoManager.Models;

namespace ProyectoManager.Controllers
{
    public class ArchivosController : Controller
    {
        private readonly ProyectoManagerContext _context;

        public ArchivosController(ProyectoManagerContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var archivos = await _context.Archivos.Join(_context.Publicaciones, archivos => archivos.id_publicacion, publicacion => publicacion.id_publicacion, (archivos, publicacion) => new ProjectViewModel
            {
                id_archivo = archivos.id_archivo,
                nombre = archivos.nombre,
                tipo = archivos.tipo,
                ruta = archivos.ruta,
                titulo = publicacion.titulo

            }).ToListAsync();

            var publicaciones = await _context.Publicaciones.ToListAsync();

            var viewModel = new ProjectIndexViewModel
            {
                Proyectos = archivos,
                Publicaciones = publicaciones
            };

            return View(viewModel);
        }

        //*********************** VENTANA MODAL CREAR ******************************************

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("nombre,tipo,ruta,id_publicacion")] Archivos archivos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(archivos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(archivos);
        }

        //*********************** VENTANA MODAL EDITAR ******************************************

        private bool ArchivosExists(int id)
        {
            return _context.Archivos.Any(e => e.id_archivo == id);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id_archivo, [Bind("id_archivo,nombre,tipo,ruta,id_publicacion")] Archivos model)
        {
            // Para sacar extension archivo
            //var extension = "";
            //for (int i = 0; i < model.ruta.Length; i++)
            //{
            //    var letter = model.ruta[i];
            //    if (letter == '.')
            //    {
            //        for (int j = i; j < model.ruta.Length; j++)
            //        {
            //            extension += model.ruta[j];
            //        }
            //    }
            //}
            //model.tipo = extension;

            if (id_archivo != model.id_archivo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArchivosExists(model.id_archivo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(Index());
        }

        //*********************** VENTANA MODAL ELIMINAR ******************************************

        [HttpPost]
        public async Task<IActionResult> Delete(int id_archivo)
        {
            var archivo = await _context.Archivos.FindAsync(id_archivo);
            if (archivo == null)
            {
                return NotFound();
            }

            _context.Archivos.Remove(archivo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

       
    }
}
