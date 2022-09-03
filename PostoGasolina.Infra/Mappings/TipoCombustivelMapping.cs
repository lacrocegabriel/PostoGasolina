using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostoGasolina.Business.Models;

namespace PostoGasolina.Infra.Mappings
{
    internal class TipoCombustivelMapping : IEntityTypeConfiguration<TipoCombustivel>
    {
        public void Configure(EntityTypeBuilder<TipoCombustivel> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Descricao);
                
            builder.ToTable("TipoCombustivel");
        }
    }
}
