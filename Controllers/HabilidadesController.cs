using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class HabilidadesController : Controller
    {
        private readonly HabilidadContext _context;

        public HabilidadesController(HabilidadContext context)
        {
            _context = context;
        }

        // GET: Habilidades
        public async Task<IActionResult> Index()
        {
            return View(await _context.Habilidad.ToListAsync());
        }

        // GET: Habilidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habilidad = await _context.Habilidad
                .FirstOrDefaultAsync(m => m.idHabilidad == id);
            if (habilidad == null)
            {
                return NotFound();
            }

            return View(habilidad);
        }

        // GET: Habilidades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Habilidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idHabilidad,Descripcion,Tipo,IdCandidato")] Habilidad habilidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(habilidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(habilidad);
        }

        // GET: Habilidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habilidad = await _context.Habilidad.FindAsync(id);
            if (habilidad == null)
            {
                return NotFound();
            }
            return View(habilidad);
        }

        // POST: Habilidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idHabilidad,Descripcion,Tipo,IdCandidato")] Habilidad habilidad)
        {
            if (id != habilidad.idHabilidad)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(habilidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HabilidadExists(habilidad.idHabilidad))
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
            return View(habilidad);
        }

        // GET: Habilidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habilidad = await _context.Habilidad
                .FirstOrDefaultAsync(m => m.idHabilidad == id);
            if (habilidad == null)
            {
                return NotFound();
            }

            return View(habilidad);
        }

        // POST: Habilidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var habilidad = await _context.Habilidad.FindAsync(id);
            if (habilidad != null)
            {
                _context.Habilidad.Remove(habilidad);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HabilidadExists(int id)
        {
            return _context.Habilidad.Any(e => e.idHabilidad == id);
        }
    }
}
