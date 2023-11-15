﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using taskManaggerAPI.DBContexts;

#nullable disable

namespace taskManaggerAPI.Migrations
{
    [DbContext(typeof(taskManaggerContext))]
    partial class taskManaggerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("taskManaggerAPI.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TaskId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("TaskId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("taskManaggerAPI.Entities.Tasks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AdminId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AdminId1")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ClientId1")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("AdminId1");

                    b.HasIndex("ClientId");

                    b.HasIndex("ClientId1");

                    b.ToTable("Tasks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AdminId = 1,
                            ClientId = 3,
                            Description = "Crear componente UserList",
                            Name = "Componente"
                        },
                        new
                        {
                            Id = 2,
                            AdminId = 1,
                            ClientId = 3,
                            Description = "Crear componente DashBoard",
                            Name = "Componente"
                        },
                        new
                        {
                            Id = 3,
                            AdminId = 1,
                            ClientId = 3,
                            Description = "Crear componente Login",
                            Name = "Componente"
                        });
                });

            modelBuilder.Entity("taskManaggerAPI.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("UserType").HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("taskManaggerAPI.Entities.Admin", b =>
                {
                    b.HasBaseType("taskManaggerAPI.Entities.User");

                    b.HasDiscriminator().HasValue("Admin");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "renzo@gmail.com",
                            Password = "123",
                            UserName = "Renzo"
                        },
                        new
                        {
                            Id = 2,
                            Email = "tomas@gmail.com",
                            Password = "123",
                            UserName = "Tomas"
                        });
                });

            modelBuilder.Entity("taskManaggerAPI.Entities.Client", b =>
                {
                    b.HasBaseType("taskManaggerAPI.Entities.User");

                    b.HasDiscriminator().HasValue("Client");

                    b.HasData(
                        new
                        {
                            Id = 3,
                            Email = "javier@gmail.com",
                            Password = "123",
                            UserName = "Javier"
                        },
                        new
                        {
                            Id = 4,
                            Email = "sebastian@gmail.com",
                            Password = "123",
                            UserName = "Sebastian"
                        });
                });

            modelBuilder.Entity("taskManaggerAPI.Entities.Comment", b =>
                {
                    b.HasOne("taskManaggerAPI.Entities.Client", "Client")
                        .WithMany("Comments")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("taskManaggerAPI.Entities.Tasks", "Task")
                        .WithMany("Comments")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Task");
                });

            modelBuilder.Entity("taskManaggerAPI.Entities.Tasks", b =>
                {
                    b.HasOne("taskManaggerAPI.Entities.Admin", "Admin")
                        .WithMany("CreatedTasks")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("taskManaggerAPI.Entities.Admin", null)
                        .WithMany("AssignedTasks")
                        .HasForeignKey("AdminId1");

                    b.HasOne("taskManaggerAPI.Entities.Client", "Client")
                        .WithMany("AssignedTasks")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("taskManaggerAPI.Entities.Client", null)
                        .WithMany("Tasks")
                        .HasForeignKey("ClientId1");

                    b.Navigation("Admin");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("taskManaggerAPI.Entities.Tasks", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("taskManaggerAPI.Entities.Admin", b =>
                {
                    b.Navigation("AssignedTasks");

                    b.Navigation("CreatedTasks");
                });

            modelBuilder.Entity("taskManaggerAPI.Entities.Client", b =>
                {
                    b.Navigation("AssignedTasks");

                    b.Navigation("Comments");

                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}