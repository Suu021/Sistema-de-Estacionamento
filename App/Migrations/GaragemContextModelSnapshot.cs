﻿// <auto-generated />
using System;
using App;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace App.Migrations
{
    [DbContext(typeof(GaragemContext))]
    partial class GaragemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("App.Models.Cliente", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("CpfCnpj")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NomeCliente")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("App.Models.Estacionamento", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("HoraFim")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("HoraInicio")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("IdCliente")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("IdVeiculo")
                        .HasColumnType("TEXT");

                    b.Property<int>("StatusEstacionamento")
                        .HasColumnType("INTEGER");

                    b.Property<double>("ValorCobrado")
                        .HasColumnType("REAL");

                    b.HasKey("ID");

                    b.ToTable("Estacionamentos");
                });

            modelBuilder.Entity("App.Models.HistoricoCaixa", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("IdEstacionamento")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("TEXT");

                    b.Property<double>("ValorAtualCaixa")
                        .HasColumnType("REAL");

                    b.HasKey("ID");

                    b.ToTable("HistoricoCaixa");
                });

            modelBuilder.Entity("App.Models.Veiculo", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TipoVeiculo")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("Veiculos");
                });
#pragma warning restore 612, 618
        }
    }
}
