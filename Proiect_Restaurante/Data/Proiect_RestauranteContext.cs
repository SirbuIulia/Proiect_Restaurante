using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect_Restaurante.Models;

namespace Proiect_Restaurante.Data
{
    public class Proiect_RestauranteContext : DbContext
    {
        public Proiect_RestauranteContext (DbContextOptions<Proiect_RestauranteContext> options)
            : base(options)
        {
        }

        public DbSet<Proiect_Restaurante.Models.Client> Client { get; set; } = default!;

        public DbSet<Proiect_Restaurante.Models.Recenzie>? Recenzie { get; set; }

        public DbSet<Proiect_Restaurante.Models.Restaurant>? Restaurant { get; set; }

        public DbSet<Proiect_Restaurante.Models.Rezervare>? Rezervare { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rezervare>()
        .HasOne(r => r.Restaurant)
        .WithMany(r => r.Rezervari)
        .HasForeignKey(r => r.RestaurantID);
        }
    }
}
