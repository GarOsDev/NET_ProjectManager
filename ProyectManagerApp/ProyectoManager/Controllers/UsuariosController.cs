using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoManager.Data;
using ProyectoManager.Models;
using ProyectoManager.Recursos;

namespace ProyectoManager.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly ProyectoManagerContext _context;

        public UsuariosController(ProyectoManagerContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var usuarios = await _context.Usuarios.Join(_context.Roles, usuarios => usuarios.id_rol, rol => rol.id_rol, (usuarios, rol) => new UsuarioViewModel
            {
                id_usuario = usuarios.id_usuario,
                nombre = usuarios.nombre,
                email = usuarios.email,
                contrasena = usuarios.contrasena,
                nombre_rol = rol.nombre_rol

            }).ToListAsync();

            var roles = await _context.Roles.ToListAsync();
            var viewModel = new UsuarioIndexViewModel
            {
                Usuarios = usuarios,
                Roles = roles
            };

            return View(viewModel);
        }

        //*********************** VENTANA MODAL CREAR ******************************************

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("nombre,email,contrasena,id_rol")] Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                usuarios.contrasena = Utilidades.EncriptarClave(usuarios.contrasena);
                _context.Add(usuarios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuarios);
        }

        //*********************** VENTANA MODAL EDITAR ******************************************

        [HttpPost]
        public async Task<IActionResult> Update(int id_usuario, [Bind("id_usuario,nombre,email,contrasena,id_rol")] Usuarios usuario)
        {
            if (id_usuario != usuario.id_usuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    usuario.contrasena = Utilidades.EncriptarClave(usuario.contrasena);
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuariosExists(usuario.id_usuario))
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
            return View(Index);
        }

        private bool UsuariosExists(int id)
        {
            return _context.Usuarios.Any(e => e.id_usuario == id);
        }

        //*********************** VENTANA MODAL ELIMINAR ******************************************

        [HttpPost]
        public async Task<IActionResult> Delete(int id_usuario)
        {

            var usuario = await _context.Usuarios.FindAsync(id_usuario);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        //*****************************************************************************************


    }
}
