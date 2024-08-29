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
    public class RolesController : Controller
    {
        private readonly ProyectoManagerContext _context;

        public RolesController(ProyectoManagerContext context)
        {
            _context = context;
        }

        // GET: Roles
        public async Task<IActionResult> Index()
        {
            if (_context.Roles == null)
            {
                return Problem("Entity set 'MvcRolesContext.Roles'  is null.");
            }

            var publi = from m in _context.Roles select m;

            return View(await publi.ToListAsync());
        }

        // GET: Roles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_rol,nombre_rol")] Roles roles)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roles);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roles);
        }

        //*********************** VENTANA MODAL EDITAR ******************************************

        public IActionResult Edit(int id)
        {
            Roles rol = _context.Roles.Where(r => r.id_rol == id).FirstOrDefault();
            return PartialView("_EditRolPartialView", rol);
        }

        [HttpPost]
        public IActionResult Edit(Roles roles)
        {
            _context.Roles.Update(roles);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //*********************** VENTANA MODAL ELIMINAR ******************************************

        public IActionResult Delete(int id)
        {
            Roles rol = _context.Roles.Where(r => r.id_rol == id).FirstOrDefault();
            return PartialView("_DeleteRolPartialView", rol);
        }

        [HttpPost]
        public IActionResult Delete(Roles roles)
        {

            if (RolesUserRelationshipExists(roles.id_rol))
            {
                return View("_ModalMessageView");
            }

            _context.Roles.Remove(roles);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //*********************** VENTANA MODAL DETAILS  ******************************************

        public IActionResult Detail(int id)
        {
            Roles rol = _context.Roles.Where(r => r.id_rol == id).FirstOrDefault();
            return PartialView("_DetailRolPartialView", rol);
        }

        //*****************************************************************************************

        private bool RolesExists(int id)
        {
            return _context.Roles.Any(e => e.id_rol == id);
        }

        private bool RolesUserRelationshipExists(int id)
        {
            return _context.Usuarios.Any(e => e.id_rol == id);
        }
    }
}
