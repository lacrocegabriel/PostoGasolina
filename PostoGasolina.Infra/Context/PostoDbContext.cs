using Microsoft.EntityFrameworkCore;
using PostoGasolina.Business.Models;
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

        }

        public DbSet<Abastecimento> Abastecimentos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Combustivel> Combustiveis  { get; set; }
        public DbSet<Veiculo> Veiculos  { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostoDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
        }
    }
}
