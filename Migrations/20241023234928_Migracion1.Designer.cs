﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Stefan_Jativa_PROGRAMACION4_TallerMVC.Data;

#nullable disable

namespace Stefan_Jativa_PROGRAMACION4_TallerMVC.Migrations
{
    [DbContext(typeof(Stefan_Jativa_PROGRAMACION4_TallerMVCContext))]
    [Migration("20241023234928_Migracion1")]
    partial class Migracion1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Stefan_Jativa_PROGRMACION4_Taller_aplicación_web_MVC.Models.Equipo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("AceptaExtranjeros")
                        .HasColumnType("bit");

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("IDestadio")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Titutlos")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IDestadio");

                    b.ToTable("Equipo");
                });

            modelBuilder.Entity("Stefan_Jativa_PROGRMACION4_Taller_aplicación_web_MVC.Models.Estadio", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("Capacidad")
                        .HasColumnType("int");

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("id");

                    b.ToTable("Estadio");
                });

            modelBuilder.Entity("Stefan_Jativa_PROGRMACION4_Taller_aplicación_web_MVC.Models.Jugador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<int>("IdEquipo")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Posicion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("IdEquipo");

                    b.ToTable("Jugador");
                });

            modelBuilder.Entity("Stefan_Jativa_PROGRMACION4_Taller_aplicación_web_MVC.Models.Equipo", b =>
                {
                    b.HasOne("Stefan_Jativa_PROGRMACION4_Taller_aplicación_web_MVC.Models.Estadio", "Estadio")
                        .WithMany()
                        .HasForeignKey("IDestadio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estadio");
                });

            modelBuilder.Entity("Stefan_Jativa_PROGRMACION4_Taller_aplicación_web_MVC.Models.Jugador", b =>
                {
                    b.HasOne("Stefan_Jativa_PROGRMACION4_Taller_aplicación_web_MVC.Models.Equipo", "Equipo")
                        .WithMany()
                        .HasForeignKey("IdEquipo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipo");
                });
#pragma warning restore 612, 618
        }
    }
}
