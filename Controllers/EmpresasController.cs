using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Models;
using WebApplication4.Models.ViewModel;

namespace WebApplication4.Controllers
{    
    public class EmpresasController : Controller
    {
        private readonly EmpresaContext _context;
        
        private readonly UsuarioContext _usuarioContext;

        private readonly LogoContext _logoContext;

        private readonly IWebHostEnvironment _hostEnvironment;

        public EmpresasController(EmpresaContext context, UsuarioContext usuarioContext, LogoContext logoContext, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _usuarioContext= usuarioContext;
            _logoContext=logoContext;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Empresas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Empresa.ToListAsync());
        }

        // GET: Empresas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = await _context.Empresa
                .FirstOrDefaultAsync(m => m.idEmpresa == id);
            if (empresa == null)
            {
                return NotFound();
            }

            return View(empresa);
        }

        // GET: Empresas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Empresas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idEmpresa,Correo,Nombre,Direccion,Descripcion,Telefono,idUsuario")] Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empresa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empresa);
        }

        // GET: Candidatos/Edit/5  ------------------------------------------- Editar
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = await _context.Empresa.FindAsync(id);
            if (empresa == null)
            {
                return NotFound();
            }
            return View(empresa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idEmpresa,Correo,Nombre,Direccion,Descripcion,Telefono,idUsuario")] Empresa empresa)
        {
            if (id != empresa.idEmpresa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Desconectar el objeto 'candidato' del contexto para evitar el seguimiento
                    _context.Entry(empresa).State = EntityState.Detached;

                    // Obtener el candidato existente en la base de datos antes de la edición
                    var empresaExistente = await _context.Empresa.AsNoTracking().FirstOrDefaultAsync(c => c.idEmpresa == id);

                    if (empresaExistente != null)
                    {
                        // Asignar el valor existente de idUsuario al objeto candidato que se va a actualizar
                        empresa.idUsuario = empresaExistente.idUsuario;

                        // Actualizar el objeto candidato en la base de datos
                        _context.Update(empresa);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        return NotFound(); // Manejar el caso en que el candidato no exista
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpresaExists(empresa.idEmpresa))
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
            return View(empresa);
        }

        // GET: Candidatos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = await _context.Empresa
                .FirstOrDefaultAsync(m => m.idEmpresa == id);
            if (empresa == null)
            {
                return NotFound();
            }

            return View(empresa);
        }

        // POST: Empresa/Delete/5 -------------------------------------- Eliminar
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empresa = await _context.Empresa.FindAsync(id);
            if (empresa == null)
            {
                return NotFound();
            }

            // Obtener el usuario asociado
            var usuario = await _usuarioContext.Usuario.FindAsync(empresa.idUsuario);
            if (usuario == null)
            {
                return NotFound();
            }

            // Eliminar el candidato
            _context.Empresa.Remove(empresa);
            await _context.SaveChangesAsync();

            // Eliminar el usuario
            _usuarioContext.Usuario.Remove(usuario);
            await _usuarioContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }



        //Metodo Nuevo   ------------------------------------------------------------ Crear ViewModel

        // GET: Empresa/Crear
        public IActionResult Crear()
        {
            return View();
        }

        // POST: Empresa/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(RegistrarEmpresaViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Crear el usuario
                    var usuario = new Usuario
                    {
                        Nombre = model.NombreUsuario,
                        Contrasenia = model.ContraseniaUsuario,
                        Tipo = "Empresa"
                    };

                    _usuarioContext.Usuario.Add(usuario);
                    await _usuarioContext.SaveChangesAsync();

                    // Verificar que se haya creado el usuario exitosamente
                    if (usuario.idUsuario > 0)
                    {
                        // Crear la empresa y asignar el IdUsuario
                        var empresa = new Empresa
                        {
                            Nombre = model.Nombre,
                            Correo = model.Correo,
                            Descripcion = model.Descripcion,
                            Telefono = model.Telefono,
                            Direccion = model.Direccion,
                            idUsuario = usuario.idUsuario // Asignar el ID del Usuario creado
                        };

                        _context.Empresa.Add(empresa);
                        await _context.SaveChangesAsync();

                        // Crear el logo y asignar la URL
                        var logo = new Logo
                        {
                            idEmpresa = empresa.idEmpresa, // Asignar el ID de la empresa creada
                            LogoURL = "" // Inicialmente dejar la URL en blanco
                        };

                        // Manejar la carga del archivo del logo
                        if (model.Logo != null && model.Logo.Length > 0)
                        {
                            

                            // Generar un nombre único para el archivo
                            var fileName = Path.GetFileNameWithoutExtension(model.Logo.FileName);
                            var extension = Path.GetExtension(model.Logo.FileName);
                            var fileNameWithExtension = $"{fileName}_{DateTime.Now.Ticks}{extension}";

                            // Definir la ruta donde se guardará el archivo
                            var path = Path.Combine(_hostEnvironment.WebRootPath, "Content\\Logos", fileNameWithExtension);

                            // Guardar el archivo en el servidor
                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                await model.Logo.CopyToAsync(stream);
                            }

                            // Actualizar la URL del logo con la ruta del archivo
                            logo.LogoURL = $"/Content/Logos/{fileNameWithExtension}";
                        }

                        _logoContext.Logo.Add(logo);
                        await _logoContext.SaveChangesAsync();

                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError("", "Error al crear el usuario.");
                    }
                }
                catch (Exception ex)
                {
                    // Registrar la excepción para su diagnóstico
                    Console.WriteLine($"Error al crear la empresa: {ex.Message}");
                    ModelState.AddModelError("", "Ocurrió un error al crear la empresa. Por favor, inténtalo de nuevo.");
                }
            }
            else
            {
                // Añadir un mensaje de error general
                ModelState.AddModelError("", "El formulario contiene errores. Por favor, revisa los campos e inténtalo de nuevo.");
            }
            return View(model);
        
    
    }


private bool EmpresaExists(int id)
        {
            return _context.Empresa.Any(e => e.idEmpresa == id);
        }
    }
}
