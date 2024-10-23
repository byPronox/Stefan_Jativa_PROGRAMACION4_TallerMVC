using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Stefan_Jativa_PROGRMACION4_Taller_aplicación_web_MVC.Models
{
    public class Equipo
    {
        [Key]
        [NotNull]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(5)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength (100)]
        [MinLength(5)]
        public string Ciudad { get; set; }

        [NotNull]
        [Range (0, 100)]
        public int Titutlos { get; set; }

        [NotNull]
        public bool AceptaExtranjeros { get; set; }

        [ForeignKey("Estadio")]
        public int IDestadio { get; set; }
        public Estadio? Estadio { get; set; }
    }
}
