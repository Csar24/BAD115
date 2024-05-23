using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace WebApplication4.Data
{
    public class EmpresaContext : DbContext
    {
        public EmpresaContext (DbContextOptions<EmpresaContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication4.Models.Empresa> Empresa { get; set; } = default!;
    }
}
