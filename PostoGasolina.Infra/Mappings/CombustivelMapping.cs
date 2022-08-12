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
    public class CombustivelMapping : IEntityTypeConfiguration<Combustivel>
    {
        public void Configure(EntityTypeBuilder<Combustivel> builder)
        {
            builder.HasKey(c => c.Id);

            builder.ToTable("Combustiveis");
        }
    }
}
