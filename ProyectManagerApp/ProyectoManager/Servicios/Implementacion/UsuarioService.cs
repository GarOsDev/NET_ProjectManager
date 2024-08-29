using Microsoft.EntityFrameworkCore;
using ProyectoManager.Data;
using ProyectoManager.Models;
using ProyectoManager.Servicios.Contrato;

namespace ProyectoManager.Servicios.Implementacion
{
    public class UsuarioService : IUsuarioService
    {
        private readonly ProyectoManagerContext _context;

        public UsuarioService(ProyectoManagerContext context)
        {
            _context = context;
        }
        public async Task<Usuarios> GetUsuarios(string correo, string contrasena)
        {
            Usuarios usuario_encontrado = await _context.Usuarios.Where(u => u.email == correo && u.contrasena == contrasena)
                .FirstOrDefaultAsync();

            return usuario_encontrado;
            
        }

        public async Task<Usuarios> SaveUsuario(Usuarios modelo)
        {
            _context.Usuarios.Add(modelo);
            await _context.SaveChangesAsync();
            return modelo;
        }
    }
}
