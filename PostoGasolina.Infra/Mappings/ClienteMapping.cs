using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostoGasolina.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostoGasolina.Infra.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("VARCHAR(200)");

            builder.Property(c => c.Documento)
                .IsRequired()
                .HasColumnType("VARCHAR(14)");

            builder.HasMany(c => c.Veiculos)
                .WithOne(v => v.Cliente)
                .HasForeignKey(v => v.ClienteId);

            builder.HasMany(c => c.Abastecimentos)
                .WithOne(a => a.Cliente)
                .HasForeignKey(a => a.ClienteId);

            builder.ToTable("Clientes");
                
        }
    }
}
