using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace WebApplication4.Data
{
    public class EventoContext : DbContext
    {
        public EventoContext (DbContextOptions<EventoContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication4.Models.Evento> Evento { get; set; } = default!;
    }
}
