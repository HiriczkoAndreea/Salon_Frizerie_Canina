﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Salon_Frizerie_Canina.Data;

#nullable disable

namespace Salon_Frizerie_Canina.Migrations
{
    [DbContext(typeof(Salon_Frizerie_CaninaContext))]
    [Migration("20230105120926_DogGender")]
    partial class DogGender
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Salon_Frizerie_Canina.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("AppointmentHour")
                        .HasColumnType("datetime2");

                    b.Property<int?>("BreedId")
                        .HasColumnType("int");

                    b.Property<int?>("DogId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BreedId");

                    b.HasIndex("DogId");

                    b.ToTable("Appointment");
                });

            modelBuilder.Entity("Salon_Frizerie_Canina.Models.Breed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BreedName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Breed");
                });

            modelBuilder.Entity("Salon_Frizerie_Canina.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("Salon_Frizerie_Canina.Models.Dog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Age")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Dog");
                });

            modelBuilder.Entity("Salon_Frizerie_Canina.Models.DogGender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AppointmentId")
                        .HasColumnType("int");

                    b.Property<int>("DogId")
                        .HasColumnType("int");

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId");

                    b.HasIndex("DogId");

                    b.HasIndex("GenderId");

                    b.ToTable("DogGender");
                });

            modelBuilder.Entity("Salon_Frizerie_Canina.Models.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("GenderName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Gender");
                });

            modelBuilder.Entity("Salon_Frizerie_Canina.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(6,2)");

                    b.HasKey("Id");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("Salon_Frizerie_Canina.Models.Appointment", b =>
                {
                    b.HasOne("Salon_Frizerie_Canina.Models.Breed", "Breed")
                        .WithMany("Appointments")
                        .HasForeignKey("BreedId");

                    b.HasOne("Salon_Frizerie_Canina.Models.Dog", "Dog")
                        .WithMany("Appointments")
                        .HasForeignKey("DogId");

                    b.Navigation("Breed");

                    b.Navigation("Dog");
                });

            modelBuilder.Entity("Salon_Frizerie_Canina.Models.DogGender", b =>
                {
                    b.HasOne("Salon_Frizerie_Canina.Models.Appointment", null)
                        .WithMany("DogGenders")
                        .HasForeignKey("AppointmentId");

                    b.HasOne("Salon_Frizerie_Canina.Models.Dog", "Dog")
                        .WithMany()
                        .HasForeignKey("DogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Salon_Frizerie_Canina.Models.Gender", "Gender")
                        .WithMany("DogGenders")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dog");

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("Salon_Frizerie_Canina.Models.Appointment", b =>
                {
                    b.Navigation("DogGenders");
                });

            modelBuilder.Entity("Salon_Frizerie_Canina.Models.Breed", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("Salon_Frizerie_Canina.Models.Dog", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("Salon_Frizerie_Canina.Models.Gender", b =>
                {
                    b.Navigation("DogGenders");
                });
#pragma warning restore 612, 618
        }
    }
}
