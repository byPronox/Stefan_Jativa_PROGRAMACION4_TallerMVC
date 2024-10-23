using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Stefan_Jativa_PROGRMACION4_Taller_aplicación_web_MVC.Models
{
    public class Jugador
    {
        [Key]
        [NotNull]
        public int Id { get; set; }

        [MinLength(1)]
        [MaxLength(50)]
        [Required]
        public string Nombre { get; set; }

        [MinLength(1)]
        [MaxLength(50)]
        [Required]
        public string Posicion { get; set; }

        [NotNull]
        [Range(0, 110)]
        public int Edad {  get; set; }

        [ForeignKey("Equipo")]
        public int IdEquipo { get; set; }
        public Equipo? Equipo { get; set; }
    }
}
