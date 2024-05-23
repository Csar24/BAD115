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
    public class OfertasLaboralesController : Controller
    {
        private readonly OfertasLaboralesContext _context;

        public OfertasLaboralesController(OfertasLaboralesContext context)
        {
            _context = context;
        }

        // GET: OfertasLaborales
        public async Task<IActionResult> Index()
        {
            return View(await _context.OfertaLaboral.ToListAsync());
        }

        // GET: OfertasLaborales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ofertaLaboral = await _context.OfertaLaboral
                .FirstOrDefaultAsync(m => m.idOfertaLaboral == id);
            if (ofertaLaboral == null)
            {
                return NotFound();
            }

            return View(ofertaLaboral);
        }

        // GET: OfertasLaborales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OfertasLaborales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idOfertaLaboral,Cargo,Vacante,Descripcion,FechaLimite,Salario,Lugar,IdEmpresa")] OfertaLaboral ofertaLaboral)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ofertaLaboral);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ofertaLaboral);
        }

        // GET: OfertasLaborales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ofertaLaboral = await _context.OfertaLaboral.FindAsync(id);
            if (ofertaLaboral == null)
            {
                return NotFound();
            }
            return View(ofertaLaboral);
        }

        // POST: OfertasLaborales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idOfertaLaboral,Cargo,Vacante,Descripcion,FechaLimite,Salario,Lugar,IdEmpresa")] OfertaLaboral ofertaLaboral)
        {
            if (id != ofertaLaboral.idOfertaLaboral)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ofertaLaboral);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OfertaLaboralExists(ofertaLaboral.idOfertaLaboral))
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
            return View(ofertaLaboral);
        }

        // GET: OfertasLaborales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ofertaLaboral = await _context.OfertaLaboral
                .FirstOrDefaultAsync(m => m.idOfertaLaboral == id);
            if (ofertaLaboral == null)
            {
                return NotFound();
            }

            return View(ofertaLaboral);
        }

        // POST: OfertasLaborales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ofertaLaboral = await _context.OfertaLaboral.FindAsync(id);
            if (ofertaLaboral != null)
            {
                _context.OfertaLaboral.Remove(ofertaLaboral);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OfertaLaboralExists(int id)
        {
            return _context.OfertaLaboral.Any(e => e.idOfertaLaboral == id);
        }
    }
}
