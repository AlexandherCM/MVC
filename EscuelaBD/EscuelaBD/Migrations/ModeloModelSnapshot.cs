﻿// <auto-generated />
using EscuelaBD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EscuelaBD.Migrations
{
    [DbContext(typeof(Modelo))]
    partial class ModeloModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EscuelaBD.Models.clsAlumno", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SalonID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("SalonID");

                    b.ToTable("Alumnos");
                });

            modelBuilder.Entity("EscuelaBD.Models.clsSalon", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Salon")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.HasKey("ID");

                    b.ToTable("Salones");
                });

            modelBuilder.Entity("EscuelaBD.Models.clsAlumno", b =>
                {
                    b.HasOne("EscuelaBD.Models.clsSalon", "Salon")
                        .WithMany("Alumnos")
                        .HasForeignKey("SalonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Salon");
                });

            modelBuilder.Entity("EscuelaBD.Models.clsSalon", b =>
                {
                    b.Navigation("Alumnos");
                });
#pragma warning restore 612, 618
        }
    }
}