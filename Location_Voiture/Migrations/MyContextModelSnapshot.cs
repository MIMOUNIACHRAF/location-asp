﻿// <auto-generated />
using System;
using Location_Voiture.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Location_Voiture.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Location_Voiture.Models.Assurance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Agence")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateDebut")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateFin")
                        .HasColumnType("datetime2");

                    b.Property<int>("Prix")
                        .HasColumnType("int");

                    b.Property<int?>("VoitureId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VoitureId");

                    b.ToTable("Assurances");
                });

            modelBuilder.Entity("Location_Voiture.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Cin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tele")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Location_Voiture.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date_Debut")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date_Fin")
                        .HasColumnType("datetime2");

                    b.Property<int>("Prix_Jour")
                        .HasColumnType("int");

                    b.Property<bool>("Retour")
                        .HasColumnType("bit");

                    b.Property<int?>("VoitureId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("VoitureId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Location_Voiture.Models.Marque", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Libelle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Marques");
                });

            modelBuilder.Entity("Location_Voiture.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Date_inscription")
                        .HasColumnType("datetime2");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassWord")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("date_connction")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Location_Voiture.Models.Voiture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Couleur")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MarqueId")
                        .HasColumnType("int");

                    b.Property<string>("Matricule")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Nbr_Porte")
                        .HasColumnType("int");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MarqueId");

                    b.ToTable("Voitures");
                });

            modelBuilder.Entity("Location_Voiture.Models.Assurance", b =>
                {
                    b.HasOne("Location_Voiture.Models.Voiture", "Voiture")
                        .WithMany("Assurances")
                        .HasForeignKey("VoitureId");

                    b.Navigation("Voiture");
                });

            modelBuilder.Entity("Location_Voiture.Models.Location", b =>
                {
                    b.HasOne("Location_Voiture.Models.Client", "Client")
                        .WithMany("Locations")
                        .HasForeignKey("ClientId");

                    b.HasOne("Location_Voiture.Models.Voiture", "Voiture")
                        .WithMany("Locations")
                        .HasForeignKey("VoitureId");

                    b.Navigation("Client");

                    b.Navigation("Voiture");
                });

            modelBuilder.Entity("Location_Voiture.Models.Voiture", b =>
                {
                    b.HasOne("Location_Voiture.Models.Marque", "Marque")
                        .WithMany("Voitures")
                        .HasForeignKey("MarqueId");

                    b.Navigation("Marque");
                });

            modelBuilder.Entity("Location_Voiture.Models.Client", b =>
                {
                    b.Navigation("Locations");
                });

            modelBuilder.Entity("Location_Voiture.Models.Marque", b =>
                {
                    b.Navigation("Voitures");
                });

            modelBuilder.Entity("Location_Voiture.Models.Voiture", b =>
                {
                    b.Navigation("Assurances");

                    b.Navigation("Locations");
                });
#pragma warning restore 612, 618
        }
    }
}
