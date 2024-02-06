using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Piotrowicz_Alicja_RazorPages.Models;

namespace Piotrowicz_Alicja_RazorPages.Data
{
    public class Piotrowicz_Alicja_RazorPagesContext : DbContext
    {
        public Piotrowicz_Alicja_RazorPagesContext (DbContextOptions<Piotrowicz_Alicja_RazorPagesContext> options)
            : base(options)
        {
        }

        public DbSet<Piotrowicz_Alicja_RazorPages.Models.Trening> Trening { get; set; } = default!;
    }
}
