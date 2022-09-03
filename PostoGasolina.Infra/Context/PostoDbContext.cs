using Microsoft.EntityFrameworkCore;
using PostoGasolina.Business.Models;
using PostoGasolina.Business.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostoGasolina.Infra.Context
{
    public class PostoDbContext : DbContext
    {
        public PostoDbContext(DbContextOptions options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
            
            

        }

        public DbSet<Abastecimento> Abastecimentos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        //public DbSet<Combustivel> Combustiveis  { get; set; }
        public DbSet<Veiculo> Veiculos  { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostoDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            modelBuilder
            .Entity<Abastecimento>()
            .Property(e => e.IdTipoCombustivel)
            .HasConversion<int>();

            modelBuilder
            .Entity<Veiculo>()
            .Property(e => e.IdTipoCombustivel)
            .HasConversion<int>();

            modelBuilder
                .Entity<TipoCombustivel>()
                .Property(e => e.Id)
                .HasConversion<int>();

            modelBuilder
            .Entity<TipoCombustivel>().HasData(
                Enum.GetValues(typeof(IdTipoCombustivel))
                    .Cast<IdTipoCombustivel>()
                    .Select(e => new TipoCombustivel()
                    {
                        Id = e,
                        Name = e.ToString()
                    })
            );
        }
    }
}
