using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoManager.Models
{
    public class Archivos
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
        public string ruta {  get; set; }
        [Required]
        [Display(Name = "Id")]
        public int id_publicacion { get; set; }
    }
}
