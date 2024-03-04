﻿// <auto-generated />
using System;
using David_Rosario_P2_Ap1.Api.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace David_Rosario_P2_Ap1.Api.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("Library.Models.Accesorios", b =>
                {
                    b.Property<int>("AccesorioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("AccesorioId");

                    b.ToTable("Accesorios");

                    b.HasData(
                        new
                        {
                            AccesorioId = 1,
                            Descripcion = "Camara Trasera"
                        },
                        new
                        {
                            AccesorioId = 2,
                            Descripcion = "Pantalla Interior"
                        },
                        new
                        {
                            AccesorioId = 3,
                            Descripcion = "Interior en Piel"
                        },
                        new
                        {
                            AccesorioId = 4,
                            Descripcion = "Sun Roof"
                        },
                        new
                        {
                            AccesorioId = 5,
                            Descripcion = "Aros de Lujo"
                        });
                });

            modelBuilder.Entity("Library.Models.Vehiculos", b =>
                {
                    b.Property<int>("VehiculoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Costo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Gastos")
                        .HasColumnType("TEXT");

                    b.HasKey("VehiculoId");

                    b.ToTable("Vehiculos");
                });

            modelBuilder.Entity("Library.Models.VehiculosDetalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccesorioId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Valor")
                        .HasColumnType("TEXT");

                    b.Property<int>("VehiculoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("VehiculoId");

                    b.ToTable("VehiculosDetalle");
                });

            modelBuilder.Entity("Library.Models.VehiculosDetalle", b =>
                {
                    b.HasOne("Library.Models.Vehiculos", null)
                        .WithMany("VehiculosDetalles")
                        .HasForeignKey("VehiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Library.Models.Vehiculos", b =>
                {
                    b.Navigation("VehiculosDetalles");
                });
#pragma warning restore 612, 618
        }
    }
}
