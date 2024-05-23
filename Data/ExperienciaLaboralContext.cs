using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace WebApplication4.Data
{
    public class ExperienciaLaboralContext : DbContext
    {
        public ExperienciaLaboralContext (DbContextOptions<ExperienciaLaboralContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication4.Models.ExperienciaLaboral> ExperienciaLaboral { get; set; } = default!;
    }
}
