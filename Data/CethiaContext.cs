using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using redestro.Models;

namespace redestro.Data
{
    public class CethiaContext : DbContext
    {
        public CethiaContext (DbContextOptions<CethiaContext> options)
            : base(options)
        {
        }

        public DbSet<Stagiaire> Stagiaire { get; set; }
        public DbSet<Inscription> Inscription { get; set; }
        public DbSet<Tache> Tache { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<Marche> Marches { get; set; }
        public DbSet<Instructeur> Instructeurs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Tache>().ToTable(nameof(Tache))
                .HasMany(c => c.Instructeurs)
                .WithMany(i => i.Taches);modelBuilder.Entity<Tache>().ToTable("Tache");
            modelBuilder.Entity<Stagiaire>().ToTable(nameof(Stagiaire));
            modelBuilder.Entity<Instructeur>().ToTable(nameof(Instructeur))
            ;
        }
    }
}
 