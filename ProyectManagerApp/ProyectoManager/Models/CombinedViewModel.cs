using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoManager.Models
{
    public class UsuarioViewModel
    {
        [Key]
        [Display(Name = "Id")]
        public int id_usuario { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string email { get; set; }

        [Required]
        [Display(Name = "Contraseña")]
        public string contrasena { get; set; }

        [Required]
        [Display(Name = "Rol")]
        public int id_rol { get; set; }

        [Required]
        [Display(Name = "Tipo de Rol")]
        public string nombre_rol { get; set; }
    }

    public class UsuarioIndexViewModel
    {
        public IEnumerable<UsuarioViewModel> Usuarios { get; set; }
        public IEnumerable<Roles> Roles { get; set; }
    }

    public class PublicationViewModel
    {
        [Key]
        [Display(Name = "Identificador")]
        public int id_publicacion { get; set; }

        [Required]
        [Display(Name = "Título")]
        public string titulo { get; set; }

        [Required]
        [Display(Name = "Contenido")]
        public string contenido { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de registro")]
        public DateOnly fecha { get; set; }


        [Required]
        [Display(Name = "Identificador Usuario")]
        public int id_usuario { get; set; }

        [Required]
        [Display(Name = "Nombre Usuario")]
        public string nombre { get; set; }
    }

    public class PublicationIndexViewModel
    {
        public IEnumerable<PublicationViewModel> Publicaciones { get; set; }
        public IEnumerable<Usuarios> Usuarios { get; set; }

        public string SearchTitle { get; set; }
        public string SearcContent { get; set; }
        public string SearchDate { get; }
    }

    public class ProjectViewModel
    {

        [Key]
        [Display(Name = "Identificador")]
        public int id_archivo { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required]
        [Display(Name = "Tipo")]
        public string tipo { get; set; }

        [Required]
        [Display(Name = "Ruta")]
        public string ruta { get; set; }

        [Required]
        [Display(Name = "Id")]
        public int id_publicacion { get; set; }

        [Display(Name = "Titulo")]
        public string titulo { get; set; }

    }

    public class ProjectIndexViewModel
    {
        public IEnumerable<ProjectViewModel> Proyectos { get; set; }
        public IEnumerable<Publicaciones> Publicaciones { get; set; }
    }
}
