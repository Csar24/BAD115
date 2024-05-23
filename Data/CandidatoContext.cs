using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace WebApplication4.Data
{
    public class CandidatoContext : DbContext
    {
        public CandidatoContext (DbContextOptions<CandidatoContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication4.Models.Candidato> Candidato { get; set; } = default!;
    }
}
