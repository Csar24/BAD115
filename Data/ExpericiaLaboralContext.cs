using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace WebApplication4.Data
{
    public class ExpericiaLaboralContext : DbContext
    {
        public ExpericiaLaboralContext (DbContextOptions<ExpericiaLaboralContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication4.Models.ExperienciaLaboral> ExperienciaLaboral { get; set; } = default!;
    }
}
