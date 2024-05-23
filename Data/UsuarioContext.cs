using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace WebApplication4.Data
{
    public class UsuarioContext : DbContext
    {
        public UsuarioContext (DbContextOptions<UsuarioContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication4.Models.Usuario> Usuario { get; set; } = default!;
    }
}
