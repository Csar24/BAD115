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
    public class ExperienciasLaboralesController : Controller
    {
        private readonly ExperienciaLaboralContext _context;

        public ExperienciasLaboralesController(ExperienciaLaboralContext context)
        {
            _context = context;
        }

        // GET: ExperienciasLaborales
        public async Task<IActionResult> Index()
        {
            return View(await _context.ExperienciaLaboral.ToListAsync());
        }

        // GET: ExperienciasLaborales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experienciaLaboral = await _context.ExperienciaLaboral
                .FirstOrDefaultAsync(m => m.idExperienciaLaboral == id);
            if (experienciaLaboral == null)
            {
                return NotFound();
            }

            return View(experienciaLaboral);
        }

        // GET: ExperienciasLaborales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExperienciasLaborales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idExperienciaLaboral,Institucion,Periodo,FuncionesRealizadas,IdCandidato")] ExperienciaLaboral experienciaLaboral)
        {
            if (ModelState.IsValid)
            {
                _context.Add(experienciaLaboral);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(experienciaLaboral);
        }

        // GET: ExperienciasLaborales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experienciaLaboral = await _context.ExperienciaLaboral.FindAsync(id);
            if (experienciaLaboral == null)
            {
                return NotFound();
            }
            return View(experienciaLaboral);
        }

        // POST: ExperienciasLaborales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idExperienciaLaboral,Institucion,Periodo,FuncionesRealizadas,IdCandidato")] ExperienciaLaboral experienciaLaboral)
        {
            if (id != experienciaLaboral.idExperienciaLaboral)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(experienciaLaboral);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExperienciaLaboralExists(experienciaLaboral.idExperienciaLaboral))
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
            return View(experienciaLaboral);
        }

        // GET: ExperienciasLaborales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experienciaLaboral = await _context.ExperienciaLaboral
                .FirstOrDefaultAsync(m => m.idExperienciaLaboral == id);
            if (experienciaLaboral == null)
            {
                return NotFound();
            }

            return View(experienciaLaboral);
        }

        // POST: ExperienciasLaborales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var experienciaLaboral = await _context.ExperienciaLaboral.FindAsync(id);
            if (experienciaLaboral != null)
            {
                _context.ExperienciaLaboral.Remove(experienciaLaboral);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExperienciaLaboralExists(int id)
        {
            return _context.ExperienciaLaboral.Any(e => e.idExperienciaLaboral == id);
        }
    }
}
