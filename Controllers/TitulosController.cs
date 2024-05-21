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
    public class TitulosController : Controller
    {
        private readonly TituloContext _context;

        public TitulosController(TituloContext context)
        {
            _context = context;
        }

        // GET: Titulos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Titulo.ToListAsync());
        }

        // GET: Titulos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var titulo = await _context.Titulo
                .FirstOrDefaultAsync(m => m.idTitulo == id);
            if (titulo == null)
            {
                return NotFound();
            }

            return View(titulo);
        }

        // GET: Titulos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Titulos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idTitulo,NombreTitulo,Fecha,Institucion,IdCandidato")] Titulo titulo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(titulo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(titulo);
        }

        // GET: Titulos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var titulo = await _context.Titulo.FindAsync(id);
            if (titulo == null)
            {
                return NotFound();
            }
            return View(titulo);
        }

        // POST: Titulos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idTitulo,NombreTitulo,Fecha,Institucion,IdCandidato")] Titulo titulo)
        {
            if (id != titulo.idTitulo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(titulo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TituloExists(titulo.idTitulo))
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
            return View(titulo);
        }

        // GET: Titulos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var titulo = await _context.Titulo
                .FirstOrDefaultAsync(m => m.idTitulo == id);
            if (titulo == null)
            {
                return NotFound();
            }

            return View(titulo);
        }

        // POST: Titulos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var titulo = await _context.Titulo.FindAsync(id);
            if (titulo != null)
            {
                _context.Titulo.Remove(titulo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TituloExists(int id)
        {
            return _context.Titulo.Any(e => e.idTitulo == id);
        }
    }
}
