using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostoGasolina.Business.Models;

namespace PostoGasolina.Infra.Mappings
{
    internal class AbastecimentoMapping : IEntityTypeConfiguration<Abastecimento>
    {
        public void Configure(EntityTypeBuilder<Abastecimento> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Litragem)
                .IsRequired();

            builder.Property(a => a.ValorLitro)
                .IsRequired();

            builder.Property(a => a.TipoCombustivel)
                .IsRequired();

            builder.Property(a => a.DataAbastecimento)
                .IsRequired();

            builder.ToTable("Abastecimentos");
        }
    }
}
