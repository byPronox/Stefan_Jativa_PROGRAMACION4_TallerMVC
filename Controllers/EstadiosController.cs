﻿using System;
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
    public class EstadiosController : Controller
    {
        private readonly Stefan_Jativa_PROGRAMACION4_TallerMVCContext _context;

        public EstadiosController(Stefan_Jativa_PROGRAMACION4_TallerMVCContext context)
        {
            _context = context;
        }

        // GET: Estadios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Estadio.ToListAsync());
        }

        // GET: Estadios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadio = await _context.Estadio
                .FirstOrDefaultAsync(m => m.id == id);
            if (estadio == null)
            {
                return NotFound();
            }

            return View(estadio);
        }

        // GET: Estadios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Estadios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Nombre,Direccion,Ciudad,Capacidad")] Estadio estadio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadio);
        }

        // GET: Estadios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadio = await _context.Estadio.FindAsync(id);
            if (estadio == null)
            {
                return NotFound();
            }
            return View(estadio);
        }

        // POST: Estadios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Nombre,Direccion,Ciudad,Capacidad")] Estadio estadio)
        {
            if (id != estadio.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadioExists(estadio.id))
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
            return View(estadio);
        }

        // GET: Estadios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadio = await _context.Estadio
                .FirstOrDefaultAsync(m => m.id == id);
            if (estadio == null)
            {
                return NotFound();
            }

            return View(estadio);
        }

        // POST: Estadios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estadio = await _context.Estadio.FindAsync(id);
            if (estadio != null)
            {
                _context.Estadio.Remove(estadio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadioExists(int id)
        {
            return _context.Estadio.Any(e => e.id == id);
        }
    }
}
