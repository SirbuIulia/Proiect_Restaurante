﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proiect_Restaurante.Data;

#nullable disable

namespace Proiect_Restaurante.Migrations
{
    [DbContext(typeof(Proiect_RestauranteContext))]
    partial class Proiect_RestauranteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Proiect_Restaurante.Models.Client", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("NrTelefon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeFamilie")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Prenume")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ID");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("Proiect_Restaurante.Models.Recenzie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("ClientID")
                        .HasColumnType("int");

                    b.Property<string>("Comentariu")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int?>("RestaurantID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ClientID");

                    b.HasIndex("RestaurantID");

                    b.ToTable("Recenzie");
                });

            modelBuilder.Entity("Proiect_Restaurante.Models.Restaurant", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NrTelefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("RatingTotal")
                        .HasColumnType("float");

                    b.Property<string>("Website")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Restaurant");
                });

            modelBuilder.Entity("Proiect_Restaurante.Models.Rezervare", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("ClientID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumarMese")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("Ora")
                        .HasColumnType("time");

                    b.Property<int?>("RestaurantID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ClientID");

                    b.HasIndex("RestaurantID");

                    b.ToTable("Rezervare");
                });

            modelBuilder.Entity("Proiect_Restaurante.Models.Recenzie", b =>
                {
                    b.HasOne("Proiect_Restaurante.Models.Client", "Client")
                        .WithMany("Recenzii")
                        .HasForeignKey("ClientID");

                    b.HasOne("Proiect_Restaurante.Models.Restaurant", "Restaurant")
                        .WithMany("Recenzii")
                        .HasForeignKey("RestaurantID");

                    b.Navigation("Client");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("Proiect_Restaurante.Models.Rezervare", b =>
                {
                    b.HasOne("Proiect_Restaurante.Models.Client", "Client")
                        .WithMany("Rezervari")
                        .HasForeignKey("ClientID");

                    b.HasOne("Proiect_Restaurante.Models.Restaurant", "Restaurant")
                        .WithMany("Rezervari")
                        .HasForeignKey("RestaurantID");

                    b.Navigation("Client");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("Proiect_Restaurante.Models.Client", b =>
                {
                    b.Navigation("Recenzii");

                    b.Navigation("Rezervari");
                });

            modelBuilder.Entity("Proiect_Restaurante.Models.Restaurant", b =>
                {
                    b.Navigation("Recenzii");

                    b.Navigation("Rezervari");
                });
#pragma warning restore 612, 618
        }
    }
}
