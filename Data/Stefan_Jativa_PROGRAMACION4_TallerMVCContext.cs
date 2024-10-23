using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Stefan_Jativa_PROGRMACION4_Taller_aplicación_web_MVC.Models;

namespace Stefan_Jativa_PROGRAMACION4_TallerMVC.Data
{
    public class Stefan_Jativa_PROGRAMACION4_TallerMVCContext : DbContext
    {
        public Stefan_Jativa_PROGRAMACION4_TallerMVCContext (DbContextOptions<Stefan_Jativa_PROGRAMACION4_TallerMVCContext> options)
            : base(options)
        {
        }

        public DbSet<Stefan_Jativa_PROGRMACION4_Taller_aplicación_web_MVC.Models.Estadio> Estadio { get; set; } = default!;
        public DbSet<Stefan_Jativa_PROGRMACION4_Taller_aplicación_web_MVC.Models.Equipo> Equipo { get; set; } = default!;
        public DbSet<Stefan_Jativa_PROGRMACION4_Taller_aplicación_web_MVC.Models.Jugador> Jugador { get; set; } = default!;
    }
}
