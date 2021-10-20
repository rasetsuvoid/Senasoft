using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Senasoft.Models;

namespace Senasoft.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>(EntityTypeBuilder =>
            {
                EntityTypeBuilder.Property(u => u.FirstName)
                                .HasMaxLength(100)
                                .HasDefaultValue(1);
                EntityTypeBuilder.Property(u => u.LastName)
                                .HasMaxLength(100)
                                .HasDefaultValue(1);

            });
            // Es obligatorio especificar que la tabla intermedia tiene una clave
            // primaria compuesta
            

    }
        public DbSet<FacturasModel> facturas { get; set; }
        public DbSet<TiposFacturasModel> TiposFacturas { get; set; }
    }
}