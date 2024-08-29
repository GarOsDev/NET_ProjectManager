using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoManager.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ProyectoManager.Data
{
    public class ProyectoManagerContext : DbContext
    {
        public ProyectoManagerContext (DbContextOptions<ProyectoManagerContext> options)
            : base(options)
        {
        }

        public DbSet<ProyectoManager.Models.Roles> Roles { get; set; } = default!;
        public DbSet<ProyectoManager.Models.Usuarios> Usuarios { get; set; } = default!;
        public DbSet<ProyectoManager.Models.Archivos> Archivos { get; set; } = default!;
        public DbSet<ProyectoManager.Models.Publicaciones> Publicaciones { get; set; } = default!;
    }
}
