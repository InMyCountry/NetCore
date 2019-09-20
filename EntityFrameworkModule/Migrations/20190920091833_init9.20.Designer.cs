﻿// <auto-generated />
using System;
using EntityFrameworkModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EntityFrameworkModule.Migrations
{
    [DbContext(typeof(StepByStepDbContext))]
    [Migration("20190920091833_init9.20")]
    partial class init920
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DBEntityModule.Test.Student", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddTime")
                        .HasMaxLength(23);

                    b.Property<int>("Age");

                    b.Property<string>("Gender")
                        .IsRequired();

                    b.Property<bool>("IsDelete")
                        .HasMaxLength(1);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Remark")
                        .HasMaxLength(128);

                    b.Property<string>("StudentTestId");

                    b.HasKey("Id");

                    b.HasIndex("StudentTestId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("DBEntityModule.Test.StudentTest", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddTime")
                        .HasMaxLength(23);

                    b.Property<int>("Age");

                    b.Property<string>("Gender")
                        .IsRequired();

                    b.Property<bool>("IsDelete")
                        .HasMaxLength(1);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Remark")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.ToTable("StudentTests");
                });

            modelBuilder.Entity("DBEntityModule.Test.Student", b =>
                {
                    b.HasOne("DBEntityModule.Test.StudentTest")
                        .WithMany("FKStudents")
                        .HasForeignKey("StudentTestId");
                });
#pragma warning restore 612, 618
        }
    }
}
