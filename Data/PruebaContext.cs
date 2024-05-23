﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace WebApplication4.Data
{
    public class PruebaContext : DbContext
    {
        public PruebaContext (DbContextOptions<PruebaContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication4.Models.Pruebas> Pruebas { get; set; } = default!;
    }
}
