﻿// <auto-generated />
using System;
using Lesson07;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Lesson07.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20231105101451_Update_Discriminator")]
    partial class Update_Discriminator
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Lesson07.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("person_type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Persons");

                    b.HasDiscriminator<string>("person_type").HasValue("Person");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Lesson07.Models.Employee", b =>
                {
                    b.HasBaseType("Lesson07.Models.Person");

                    b.Property<DateTime>("Hiredate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.HasDiscriminator().HasValue("person_employee");
                });

            modelBuilder.Entity("Lesson07.Models.Student", b =>
                {
                    b.HasBaseType("Lesson07.Models.Person");

                    b.Property<decimal>("AverageGrade")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Semester")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("person_student");
                });

            modelBuilder.Entity("Lesson07.Models.Teacher", b =>
                {
                    b.HasBaseType("Lesson07.Models.Person");

                    b.Property<double>("Experience")
                        .HasColumnType("float");

                    b.Property<decimal>("HourlyRate")
                        .HasColumnType("decimal(18,2)");

                    b.HasDiscriminator().HasValue("person_teacher");
                });

            modelBuilder.Entity("Lesson07.Models.Security", b =>
                {
                    b.HasBaseType("Lesson07.Models.Employee");

                    b.Property<int>("Smena")
                        .HasColumnType("int");

                    b.ToTable("Persons", t =>
                        {
                            t.Property("Smena")
                                .HasColumnName("Security_Smena");
                        });

                    b.HasDiscriminator().HasValue("person_security");
                });

            modelBuilder.Entity("Lesson07.Models.FullTimeStudent", b =>
                {
                    b.HasBaseType("Lesson07.Models.Student");

                    b.Property<int>("Smena")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("person_student_full_time");
                });

            modelBuilder.Entity("Lesson07.Models.PartTimeStudent", b =>
                {
                    b.HasBaseType("Lesson07.Models.Student");

                    b.Property<int>("StudyDays")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("person_student_part_time");
                });
#pragma warning restore 612, 618
        }
    }
}
