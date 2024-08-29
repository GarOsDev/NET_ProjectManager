using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoManager.Models
{
    public class Usuarios
    {
        [Key]
        [Display(Name = "Id")]
        public int id_usuario { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public string nombre { get; set;}

        [Required]
        [Display(Name = "Email")]
        public string email { get; set;}

        [Required]
        [Display(Name = "Contraseña")]
        public string contrasena { get; set;}

        [Required]
        [Display(Name = "Rol")]
        public int id_rol { get; set;}
    }

}
