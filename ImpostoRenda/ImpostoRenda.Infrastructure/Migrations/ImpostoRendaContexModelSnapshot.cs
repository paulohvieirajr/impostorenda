﻿// <auto-generated />
using ImpostoRenda.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ImpostoRenda.Infrastructure.Migrations
{
    [DbContext(typeof(ImpostoRendaContex))]
    partial class ImpostoRendaContexModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ImpostoRenda.Domain.Entidades.Contribuinte", b =>
                {
                    b.Property<int>("IdContribuinte")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnName("Cpf")
                        .HasMaxLength(11);

                    b.Property<int>("Dependentes")
                        .HasColumnName("Dependentes");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasMaxLength(50);

                    b.Property<decimal>("Salario")
                        .HasColumnName("Salario");

                    b.Property<decimal>("SalarioLiquido")
                        .HasColumnName("SalarioComDesconto");

                    b.HasKey("IdContribuinte");

                    b.ToTable("Contribuinte");
                });

            modelBuilder.Entity("ImpostoRenda.Dominio.Entidades.SalarioMinino", b =>
                {
                    b.Property<int>("IdSalarioMinino")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Valor")
                        .HasColumnName("Valor");

                    b.HasKey("IdSalarioMinino");

                    b.ToTable("SalarioMinino");
                });
#pragma warning restore 612, 618
        }
    }
}
