﻿// <auto-generated />
using System;
using AutoParc.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AutoParc.DataContext.Migrations
{
    [DbContext(typeof(MainDbContext))]
    [Migration("20250302121138_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.36")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AutoParc.Model.EmployeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("EntrepriseId")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VehiculeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EntrepriseId");

                    b.HasIndex("VehiculeId")
                        .IsUnique()
                        .HasFilter("[VehiculeId] IS NOT NULL");

                    b.ToTable("Employe");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EntrepriseId = 1,
                            Nom = "Test 1",
                            Prenom = "Test 1",
                            VehiculeId = 1
                        },
                        new
                        {
                            Id = 2,
                            EntrepriseId = 2,
                            Nom = "Test 2",
                            Prenom = "Test 2",
                            VehiculeId = 2
                        },
                        new
                        {
                            Id = 3,
                            EntrepriseId = 3,
                            Nom = "Test 3",
                            Prenom = "Test 3",
                            VehiculeId = 3
                        });
                });

            modelBuilder.Entity("AutoParc.Model.EntrepriseModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("ContratActif")
                        .HasColumnType("bit");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Entreprise");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ContratActif = true,
                            Nom = "Test 1"
                        },
                        new
                        {
                            Id = 2,
                            ContratActif = false,
                            Nom = "Test 2"
                        },
                        new
                        {
                            Id = 3,
                            ContratActif = true,
                            Nom = "Test 3"
                        });
                });

            modelBuilder.Entity("AutoParc.Model.VehiculeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Disponibilite")
                        .HasColumnType("bit");

                    b.Property<int?>("EmployeId")
                        .HasColumnType("int");

                    b.Property<int>("EntrepriseId")
                        .HasColumnType("int");

                    b.Property<string>("Marque")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modele")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RaisonIndisponibilite")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeId");

                    b.HasIndex("EntrepriseId");

                    b.ToTable("Vehicule");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Disponibilite = true,
                            EntrepriseId = 1,
                            Marque = "Test 1",
                            Modele = "Test 1"
                        },
                        new
                        {
                            Id = 2,
                            Disponibilite = false,
                            EntrepriseId = 2,
                            Marque = "Test 2",
                            Modele = "Test 2",
                            RaisonIndisponibilite = "Test 2"
                        },
                        new
                        {
                            Id = 3,
                            Disponibilite = true,
                            EntrepriseId = 3,
                            Marque = "Test 3",
                            Modele = "Test 3"
                        });
                });

            modelBuilder.Entity("AutoParc.Model.EmployeModel", b =>
                {
                    b.HasOne("AutoParc.Model.EntrepriseModel", "Entreprise")
                        .WithMany("Employes")
                        .HasForeignKey("EntrepriseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoParc.Model.VehiculeModel", "Vehicule")
                        .WithOne()
                        .HasForeignKey("AutoParc.Model.EmployeModel", "VehiculeId");

                    b.Navigation("Entreprise");

                    b.Navigation("Vehicule");
                });

            modelBuilder.Entity("AutoParc.Model.VehiculeModel", b =>
                {
                    b.HasOne("AutoParc.Model.EmployeModel", "Employe")
                        .WithMany()
                        .HasForeignKey("EmployeId");

                    b.HasOne("AutoParc.Model.EntrepriseModel", "Entreprise")
                        .WithMany("Vehicules")
                        .HasForeignKey("EntrepriseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employe");

                    b.Navigation("Entreprise");
                });

            modelBuilder.Entity("AutoParc.Model.EntrepriseModel", b =>
                {
                    b.Navigation("Employes");

                    b.Navigation("Vehicules");
                });
#pragma warning restore 612, 618
        }
    }
}
