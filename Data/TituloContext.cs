using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace WebApplication4.Data
{
    public class TituloContext : DbContext
    {
        public TituloContext (DbContextOptions<TituloContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication4.Models.Titulo> Titulo { get; set; } = default!;
    }
}
