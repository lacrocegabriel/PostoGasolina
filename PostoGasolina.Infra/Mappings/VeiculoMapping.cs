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
    public class VeiculoMapping : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.HasKey(v => v.Id);

            builder.Property(v => v.Marca)
                .IsRequired()
                .HasColumnType("VARCHAR(50)");

            builder.Property(v => v.Modelo)
                .IsRequired()
                .HasColumnType("VARCHAR(50)");

            builder.Property(v => v.Ano)
                .IsRequired();

            builder.Property(v => v.Placa)
                .IsRequired()
                .HasColumnType("VARCHAR(8)");

            builder.HasMany(v => v.Abastecimentos)
                .WithOne(a => a.Veiculo)
                .HasForeignKey(a => a.VeiculoId);

            builder.ToTable("Veiculos");
        }
    }
}
