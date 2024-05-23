using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace WebApplication4.Data
{
    public class LogoContext : DbContext
    {
        public LogoContext (DbContextOptions<LogoContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication4.Models.Logo> Logo { get; set; } = default!;
    }
}
