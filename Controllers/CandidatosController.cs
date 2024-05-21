using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;
using WebApplication4.Data;
using WebApplication4.Models.ViewModel;

namespace WebApplication4
{
    public class CandidatosController : Controller
    {
        private readonly CandidatoContext _context;
        private readonly UsuarioContext _usuarioContext;

        public CandidatosController(CandidatoContext context , UsuarioContext usuarioContext)
        {
            _context = context;
            _usuarioContext = usuarioContext;
        }

        // GET: Candidatos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Candidato.ToListAsync());
        }

        // GET: Candidatos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidato = await _context.Candidato
                .FirstOrDefaultAsync(m => m.idCandidato == id);
            if (candidato == null)
            {
                return NotFound();
            }

            return View(candidato);
        }

        // GET: Candidatos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Candidatos/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idCandidato,PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,Nacionalidad,Genero,FechaNacimiento,DUI,NIT,Correo,RedesSociales,idUsuario")] Candidato candidato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(candidato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(candidato);
        }


        //Metodo Nuevo   ------------------------------------------------------------ Crear ViewModel

        // GET: Candidatos/Crear
        public IActionResult Crear()
        {
            return View();
        }

        // POST: Candidatos/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(RegistrarCandidatoViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Crear el usuario
                var usuario = new Usuario
                {
                    Nombre = model.NombreUsuario,
                    Contrasenia = model.ContraseniaUsuario,
                    Tipo = "Candidato"
                };

                _usuarioContext.Usuario.Add(usuario);
                await _usuarioContext.SaveChangesAsync();

                // Crear el candidato y asignar el IdUsuario
                var candidato = new Candidato
                {
                    PrimerNombre = model.PrimerNombre,
                    SegundoNombre = model.SegundoNombre,
                    PrimerApellido = model.PrimerApellido,
                    SegundoApellido = model.SegundoApellido,
                    Nacionalidad = model.Nacionalidad,
                    Genero = model.Genero,
                    FechaNacimiento = model.FechaNacimiento,
                    DUI = model.DUI,
                    NIT = model.NIT,
                    Correo = model.Correo,
                    RedesSociales = model.RedesSociales,
                    idUsuario = usuario.idUsuario // Asignar el ID del Usuario creado
                };

                _context.Candidato.Add(candidato);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }


       




        // GET: Candidatos/Edit/5 
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidato = await _context.Candidato.FindAsync(id);
            if (candidato == null)
            {
                return NotFound();
            }
            return View(candidato);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idCandidato,PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,Nacionalidad,Genero,FechaNacimiento,DUI,NIT,Correo,RedesSociales,idUsuario")] Candidato candidato)
        {
            if (id != candidato.idCandidato)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Desconectar el objeto 'candidato' del contexto para evitar el seguimiento
                    _context.Entry(candidato).State = EntityState.Detached;

                    // Obtener el candidato existente en la base de datos antes de la edición
                    var candidatoExistente = await _context.Candidato.AsNoTracking().FirstOrDefaultAsync(c => c.idCandidato == id);

                    if (candidatoExistente != null)
                    {
                        // Asignar el valor existente de idUsuario al objeto candidato que se va a actualizar
                        candidato.idUsuario = candidatoExistente.idUsuario;

                        // Actualizar el objeto candidato en la base de datos
                        _context.Update(candidato);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        return NotFound(); // Manejar el caso en que el candidato no exista
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidatoExists(candidato.idCandidato))
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
            return View(candidato);
        }

        // GET: Candidatos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidato = await _context.Candidato
                .FirstOrDefaultAsync(m => m.idCandidato == id);
            if (candidato == null)
            {
                return NotFound();
            }

            return View(candidato);
        }

        // POST: Candidatos/Delete/5 -------------------------------------- Eliminar
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var candidato = await _context.Candidato.FindAsync(id);
            if (candidato == null)
            {
                return NotFound();
            }

            // Obtener el usuario asociado
            var usuario = await _usuarioContext.Usuario.FindAsync(candidato.idUsuario);
            if (usuario == null)
            {
                return NotFound();
            }

            // Eliminar el candidato
            _context.Candidato.Remove(candidato);
            await _context.SaveChangesAsync();

            // Eliminar el usuario
            _usuarioContext.Usuario.Remove(usuario);
            await _usuarioContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool CandidatoExists(int id)
        {
            return _context.Candidato.Any(e => e.idCandidato == id);
        }
    }
}
