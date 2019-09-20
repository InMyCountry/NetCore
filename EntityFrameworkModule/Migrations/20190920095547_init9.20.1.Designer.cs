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
    [Migration("20190920095547_init9.20.1")]
    partial class init9201
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DBEntityModule.RoleMenu", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddTime")
                        .HasMaxLength(23);

                    b.Property<bool>("IsDelete")
                        .HasMaxLength(1);

                    b.Property<string>("Remark")
                        .HasMaxLength(128);

                    b.Property<string>("SystemMenusId");

                    b.Property<string>("SystemRolesId");

                    b.HasKey("Id");

                    b.HasIndex("SystemMenusId");

                    b.HasIndex("SystemRolesId");

                    b.ToTable("RoleMenus");
                });

            modelBuilder.Entity("DBEntityModule.SystemMenu", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddTime")
                        .HasMaxLength(23);

                    b.Property<string>("DisplayName")
                        .HasMaxLength(128);

                    b.Property<string>("IconUrl")
                        .HasMaxLength(128);

                    b.Property<bool>("IsDelete")
                        .HasMaxLength(1);

                    b.Property<bool>("IsDisplay")
                        .HasMaxLength(1);

                    b.Property<bool>("IsSystem")
                        .HasMaxLength(1);

                    b.Property<string>("LinkUrl")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.Property<string>("ParentMenuId");

                    b.Property<string>("Permission")
                        .HasMaxLength(256);

                    b.Property<string>("Remark")
                        .HasMaxLength(128);

                    b.Property<int>("Sort")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.HasIndex("ParentMenuId");

                    b.ToTable("SystemMenus");
                });

            modelBuilder.Entity("DBEntityModule.SystemRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddTime")
                        .HasMaxLength(23);

                    b.Property<bool>("IsDelete")
                        .HasMaxLength(1);

                    b.Property<bool>("IsSystem")
                        .HasMaxLength(1);

                    b.Property<string>("Remark")
                        .HasMaxLength(128);

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<int>("RoleType")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("SystemRoles");
                });

            modelBuilder.Entity("DBEntityModule.SystemUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddTime")
                        .HasMaxLength(23);

                    b.Property<string>("Avatar")
                        .HasMaxLength(256);

                    b.Property<string>("Email")
                        .HasMaxLength(128);

                    b.Property<bool>("IsDelete")
                        .HasMaxLength(1);

                    b.Property<bool>("IsLock")
                        .HasMaxLength(1);

                    b.Property<int>("LoginCount")
                        .HasMaxLength(10);

                    b.Property<string>("LoginLastIp")
                        .HasMaxLength(64);

                    b.Property<DateTime>("LoginLastTime")
                        .HasMaxLength(23);

                    b.Property<string>("Mobile")
                        .HasMaxLength(16);

                    b.Property<string>("NickName")
                        .HasMaxLength(32);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("Remark")
                        .HasMaxLength(128);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.HasKey("Id");

                    b.ToTable("SystemUsers");
                });

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

                    b.ToTable("Student");
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

            modelBuilder.Entity("DBEntityModule.UserRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddTime")
                        .HasMaxLength(23);

                    b.Property<bool>("IsDelete")
                        .HasMaxLength(1);

                    b.Property<string>("Remark")
                        .HasMaxLength(128);

                    b.Property<string>("SystemRoleId");

                    b.Property<string>("UserAccountId");

                    b.HasKey("Id");

                    b.HasIndex("SystemRoleId");

                    b.HasIndex("UserAccountId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("DBEntityModule.RoleMenu", b =>
                {
                    b.HasOne("DBEntityModule.SystemMenu", "SystemMenus")
                        .WithMany("RoleMenus")
                        .HasForeignKey("SystemMenusId");

                    b.HasOne("DBEntityModule.SystemRole", "SystemRoles")
                        .WithMany("RoleMenus")
                        .HasForeignKey("SystemRolesId");
                });

            modelBuilder.Entity("DBEntityModule.SystemMenu", b =>
                {
                    b.HasOne("DBEntityModule.SystemMenu", "ParentMenu")
                        .WithMany()
                        .HasForeignKey("ParentMenuId");
                });

            modelBuilder.Entity("DBEntityModule.Test.Student", b =>
                {
                    b.HasOne("DBEntityModule.Test.StudentTest")
                        .WithMany("FKStudents")
                        .HasForeignKey("StudentTestId");
                });

            modelBuilder.Entity("DBEntityModule.UserRole", b =>
                {
                    b.HasOne("DBEntityModule.SystemRole", "SystemRole")
                        .WithMany("UserRoles")
                        .HasForeignKey("SystemRoleId");

                    b.HasOne("DBEntityModule.SystemUser", "UserAccount")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserAccountId");
                });
#pragma warning restore 612, 618
        }
    }
}
