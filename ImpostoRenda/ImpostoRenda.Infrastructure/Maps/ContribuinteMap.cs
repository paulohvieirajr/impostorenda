using ImpostoRenda.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImpostoRenda.Infrastructure.Maps
{
    public class ContribuinteMap : IEntityTypeConfiguration<Contribuinte>
    {
        public void Configure(EntityTypeBuilder<Contribuinte> builder)
        {
            // Key
            builder.HasKey(x => x.IdContribuinte);

            // Columns
            builder.Property(x => x.Nome).HasColumnName("Nome").HasMaxLength(50).IsRequired(); 
            builder.Property(x => x.CPF).HasColumnName("Cpf").HasMaxLength(11).IsRequired();
            builder.Property(x => x.Dependentes).HasColumnName("Dependentes").IsRequired();
            builder.Property(x => x.Salario).HasColumnName("Salario").IsRequired();
            builder.Property(x => x.SalarioLiquido).HasColumnName("SalarioComDesconto").IsRequired();

            // Relatioships

            // Table name
            builder.ToTable("Contribuinte");
        }
    }
}
