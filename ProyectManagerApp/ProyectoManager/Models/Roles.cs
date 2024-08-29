
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProyectoManager.Models
{
    public class Roles
    {
        [Key]
        [DisplayName("Id")]
        public int id_rol {get; set;}

        [Required]
        [Display(Name = "Tipo de Rol")]
        public string nombre_rol {get; set;}

     
    }
}
