﻿// <auto-generated />
using System;
using BrianTecnology.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BrianTecnology.Migrations
{
    [DbContext(typeof(MarketContext))]
    partial class MarketContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BrianTecnology.Models.Categorium", b =>
                {
                    b.Property<int>("IdCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCategoria"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdCategoria")
                        .HasName("PK__CATEGORI__A3C02A102B3C74BF");

                    b.ToTable("CATEGORIA", (string)null);
                });

            modelBuilder.Entity("BrianTecnology.Models.Producto", b =>
                {
                    b.Property<int>("IdProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProducto"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("IdCategoria")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<decimal?>("Precio")
                        .IsRequired()
                        .HasColumnType("decimal(10,2)");

                    b.Property<int?>("Stock")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("IdProducto")
                        .HasName("PK__PRODUCTO__0988921059064F42");

                    b.HasIndex("IdCategoria");

                    b.ToTable("PRODUCTOS", (string)null);
                });

            modelBuilder.Entity("BrianTecnology.Models.Producto", b =>
                {
                    b.HasOne("BrianTecnology.Models.Categorium", "IdCategoriaNavigation")
                        .WithMany("Productos")
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__PRODUCTOS__IdCat__267ABA7A");

                    b.Navigation("IdCategoriaNavigation");
                });

            modelBuilder.Entity("BrianTecnology.Models.Categorium", b =>
                {
                    b.Navigation("Productos");
                });
#pragma warning restore 612, 618
        }
    }
}
