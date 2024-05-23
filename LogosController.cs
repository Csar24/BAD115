using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Models;

namespace WebApplication4
{
    public class LogosController : Controller
    {
        private readonly LogoContext _context;

        public LogosController(LogoContext context)
        {
            _context = context;
        }

        // GET: Logos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Logo.ToListAsync());
        }

        // GET: Logos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logo = await _context.Logo
                .FirstOrDefaultAsync(m => m.idLogo == id);
            if (logo == null)
            {
                return NotFound();
            }

            return View(logo);
        }

        // GET: Logos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Logos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idLogo,idEmpresa,LogoURL,Empresa")] Logo logo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(logo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(logo);
        }

        // GET: Logos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logo = await _context.Logo.FindAsync(id);
            if (logo == null)
            {
                return NotFound();
            }
            return View(logo);
        }

        // POST: Logos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idLogo,idEmpresa,LogoURL,Empresa")] Logo logo)
        {
            if (id != logo.idLogo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(logo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LogoExists(logo.idLogo))
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
            return View(logo);
        }

        // GET: Logos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logo = await _context.Logo
                .FirstOrDefaultAsync(m => m.idLogo == id);
            if (logo == null)
            {
                return NotFound();
            }

            return View(logo);
        }

        // POST: Logos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var logo = await _context.Logo.FindAsync(id);
            if (logo != null)
            {
                _context.Logo.Remove(logo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LogoExists(int id)
        {
            return _context.Logo.Any(e => e.idLogo == id);
        }
    }
}
