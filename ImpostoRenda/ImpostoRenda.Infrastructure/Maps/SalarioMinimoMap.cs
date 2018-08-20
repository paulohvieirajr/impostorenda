using ImpostoRenda.Domain.Entidades;
using ImpostoRenda.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImpostoRenda.Infrastructure.Maps
{
    public class SalarioMinimoMap : IEntityTypeConfiguration<SalarioMinino>
    {
        public void Configure(EntityTypeBuilder<SalarioMinino> builder)
        {
            // Key
            builder.HasKey(x => x.IdSalarioMinino);

            // Columns 
            builder.Property(x => x.Valor).HasColumnName("Valor").IsRequired();

            // Relatioships

            // Table name
            builder.ToTable("SalarioMinino");
        }
    }
}
