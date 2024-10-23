using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Stefan_Jativa_PROGRMACION4_Taller_aplicación_web_MVC.Models
{
    public class Estadio
    {
        [Key]
        [NotNull]
        public int id { get; set; }

        [Required]
        [MaxLength(200)]
        [MinLength(5)]
        public string Direccion { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(5)]
        public string Ciudad { get; set; }

        [NotNull]
        [Range(0, 100000)]
        public int Capacidad { get; set; }
    }
}
