using Flunt.Notifications;
using ImpostoRenda.Domain.Entidades;
using ImpostoRenda.Dominio.Entidades;
using ImpostoRenda.Infrastructure.Maps;
using Microsoft.EntityFrameworkCore;
using System;

namespace ImpostoRenda.Infrastructure
{
    public class ImpostoRendaContex : DbContext
    {
        public ImpostoRendaContex(DbContextOptions<ImpostoRendaContex> options)
                : base(options)
        {
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=1234;database=Interface");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();
            modelBuilder.ApplyConfiguration(new ContribuinteMap());
            modelBuilder.ApplyConfiguration(new SalarioMinimoMap());
        }

        public DbSet<Contribuinte> Contribuintes { get; set; }

        public DbSet<SalarioMinino> SalariosMininos { get; set; }
    }
}
