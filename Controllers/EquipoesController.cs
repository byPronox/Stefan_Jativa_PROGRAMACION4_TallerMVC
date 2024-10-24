using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Stefan_Jativa_PROGRAMACION4_TallerMVC.Data;
using Stefan_Jativa_PROGRMACION4_Taller_aplicación_web_MVC.Models;

namespace Stefan_Jativa_PROGRAMACION4_TallerMVC.Controllers
{
    public class EquipoesController : Controller
    {
        private readonly Stefan_Jativa_PROGRAMACION4_TallerMVCContext _context;

        public EquipoesController(Stefan_Jativa_PROGRAMACION4_TallerMVCContext context)
        {
            _context = context;
        }

        // GET: Equipoes
        public async Task<IActionResult> Index()
        {
            // Incluir el nombre del estadio al listar los equipos
            var stefan_Jativa_PROGRAMACION4_TallerMVCContext = _context.Equipo
                .Include(e => e.Estadio) // Aseguramos de incluir la información del estadio
                .ToListAsync(); // Recuperamos la lista

            return View(await stefan_Jativa_PROGRAMACION4_TallerMVCContext);
        }

        // GET: Equipoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipo = await _context.Equipo
                .Include(e => e.Estadio) // Incluimos el estadio
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipo == null)
            {
                return NotFound();
            }

            return View(equipo);
        }

        // GET: Equipoes/Create
        public IActionResult Create()
        {
            ViewData["IDestadio"] = new SelectList(_context.Estadio, "id", "Nombre"); // Mostrar el nombre del estadio
            return View();
        }

        // POST: Equipoes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Ciudad,Titutlos,AceptaExtranjeros,IDestadio")] Equipo equipo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDestadio"] = new SelectList(_context.Estadio, "id", "Nombre", equipo.IDestadio);
            return View(equipo);
        }

        // GET: Equipoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipo = await _context.Equipo.FindAsync(id);
            if (equipo == null)
            {
                return NotFound();
            }
            ViewData["IDestadio"] = new SelectList(_context.Estadio, "id", "Nombre", equipo.IDestadio); // Mostrar nombre del estadio
            return View(equipo);
        }

        // POST: Equipoes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Ciudad,Titutlos,AceptaExtranjeros,IDestadio")] Equipo equipo)
        {
            if (id != equipo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipoExists(equipo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDestadio"] = new SelectList(_context.Estadio, "id", "Nombre", equipo.IDestadio);
            return View(equipo);
        }

        // GET: Equipoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipo = await _context.Equipo
                .Include(e => e.Estadio) // Incluir el estadio en la consulta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipo == null)
            {
                return NotFound();
            }

            return View(equipo);
        }

        // POST: Equipoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equipo = await _context.Equipo.FindAsync(id);
            if (equipo != null)
            {
                _context.Equipo.Remove(equipo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipoExists(int id)
        {
            return _context.Equipo.Any(e => e.Id == id);
        }
    }
}
