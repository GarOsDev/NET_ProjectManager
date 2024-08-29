using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ProyectoManager.Models
{
    public class Publicaciones
    {
        [Key]
        [Display(Name = "Identificador")]
        public int id_publicacion { get; set; }


        [Required]
        [Display(Name = "Título")]
        public string titulo { get; set; }


        [Required]
        [Display(Name = "Contenido")]
        public string contenido { get; set;}


        [DataType(DataType.Date)]
        [Display(Name = "Fecha de registro")]
        public DateOnly fecha { get; set; }


        [Required]
        [Display(Name = "Identificador Usuario")]
        public int id_usuario { get; set; }

    }
}
