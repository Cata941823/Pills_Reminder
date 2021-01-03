﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PillsReminder.Data;
using AppContext = PillsReminder.Data.AppContext;

namespace PillsReminder.Migrations
{
    [DbContext(typeof(AppContext))]
    [Migration("20210103203417_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("DozaMedicamentUser", b =>
                {
                    b.Property<int>("DozaMedicamentId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("DozaMedicamentId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("DozaMedicamentUser");
                });

            modelBuilder.Entity("PillsReminder.Entities.Adresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("IdUtilizator")
                        .HasColumnType("int");

                    b.Property<string>("Locatie")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdUtilizator")
                        .IsUnique();

                    b.ToTable("Adresa");
                });

            modelBuilder.Entity("PillsReminder.Entities.DozaMedicament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Cantitate_pastila")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Luata")
                        .HasColumnType("bit");

                    b.Property<int?>("MedicamentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Ora")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MedicamentId");

                    b.ToTable("DozaMedicament");
                });

            modelBuilder.Entity("PillsReminder.Entities.ListaMedicament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("MedicamentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MedicamentId");

                    b.ToTable("ListaMedicament");
                });

            modelBuilder.Entity("PillsReminder.Entities.Medicament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Denumire")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Medicament");
                });

            modelBuilder.Entity("PillsReminder.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ListaMedicamentId")
                        .HasColumnType("int");

                    b.Property<string>("Nume")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Parola")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenume")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ListaMedicamentId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DozaMedicamentUser", b =>
                {
                    b.HasOne("PillsReminder.Entities.DozaMedicament", null)
                        .WithMany()
                        .HasForeignKey("DozaMedicamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PillsReminder.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PillsReminder.Entities.Adresa", b =>
                {
                    b.HasOne("PillsReminder.Entities.User", "User")
                        .WithOne("Adresa")
                        .HasForeignKey("PillsReminder.Entities.Adresa", "IdUtilizator")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PillsReminder.Entities.DozaMedicament", b =>
                {
                    b.HasOne("PillsReminder.Entities.Medicament", "Medicament")
                        .WithMany("DozaMedicament")
                        .HasForeignKey("MedicamentId");

                    b.Navigation("Medicament");
                });

            modelBuilder.Entity("PillsReminder.Entities.ListaMedicament", b =>
                {
                    b.HasOne("PillsReminder.Entities.Medicament", "Medicament")
                        .WithMany("ListaMedicament")
                        .HasForeignKey("MedicamentId");

                    b.Navigation("Medicament");
                });

            modelBuilder.Entity("PillsReminder.Entities.User", b =>
                {
                    b.HasOne("PillsReminder.Entities.ListaMedicament", "ListaMedicament")
                        .WithMany("User")
                        .HasForeignKey("ListaMedicamentId");

                    b.Navigation("ListaMedicament");
                });

            modelBuilder.Entity("PillsReminder.Entities.ListaMedicament", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("PillsReminder.Entities.Medicament", b =>
                {
                    b.Navigation("DozaMedicament");

                    b.Navigation("ListaMedicament");
                });

            modelBuilder.Entity("PillsReminder.Entities.User", b =>
                {
                    b.Navigation("Adresa");
                });
#pragma warning restore 612, 618
        }
    }
}
