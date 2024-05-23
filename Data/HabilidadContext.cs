using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace WebApplication4.Data
{
    public class HabilidadContext : DbContext
    {
        public HabilidadContext (DbContextOptions<HabilidadContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication4.Models.Habilidad> Habilidad { get; set; } = default!;
    }
}
