using Microsoft.EntityFrameworkCore;
using ProyectoManager.Models;


namespace ProyectoManager.Servicios.Contrato
{
    public interface IUsuarioService
    {
        Task<Usuarios> GetUsuarios(string correo, string contrasena);

        Task<Usuarios> SaveUsuario(Usuarios modelo);
    }
}
