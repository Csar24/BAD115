using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace WebApplication4.Data
{
    public class OfertasLaboralesContext : DbContext
    {
        public OfertasLaboralesContext (DbContextOptions<OfertasLaboralesContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication4.Models.OfertaLaboral> OfertaLaboral { get; set; } = default!;
    }
}
