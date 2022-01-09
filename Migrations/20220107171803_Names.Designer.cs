﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProiectWeb.Data;

namespace ProiectWeb.Migrations
{
    [DbContext(typeof(ProiectWebContext))]
    [Migration("20220107171803_Names")]
    partial class Names
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProiectWeb.Models.Contact", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nr_tel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("ProiectWeb.Models.Factura", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ContactID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ProprietateID")
                        .HasColumnType("int");

                    b.Property<decimal>("suma")
                        .HasColumnType("decimal(6,2)");

                    b.HasKey("ID");

                    b.HasIndex("ContactID");

                    b.HasIndex("ProprietateID");

                    b.ToTable("Factura");
                });

            modelBuilder.Entity("ProiectWeb.Models.Proprietate", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Amplasament")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Nr_camere")
                        .HasColumnType("int");

                    b.Property<int>("Suprafata")
                        .HasColumnType("int");

                    b.Property<string>("Tip_oferta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zona")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Proprietate");
                });

            modelBuilder.Entity("ProiectWeb.Models.Factura", b =>
                {
                    b.HasOne("ProiectWeb.Models.Contact", null)
                        .WithMany("Facturi")
                        .HasForeignKey("ContactID");

                    b.HasOne("ProiectWeb.Models.Proprietate", null)
                        .WithMany("Facturi")
                        .HasForeignKey("ProprietateID");
                });

            modelBuilder.Entity("ProiectWeb.Models.Contact", b =>
                {
                    b.Navigation("Facturi");
                });

            modelBuilder.Entity("ProiectWeb.Models.Proprietate", b =>
                {
                    b.Navigation("Facturi");
                });
#pragma warning restore 612, 618
        }
    }
}
