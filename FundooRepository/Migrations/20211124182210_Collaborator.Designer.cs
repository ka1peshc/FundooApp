﻿// <auto-generated />
using FundooRepository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FundooRepository.Migrations
{
    [DbContext(typeof(UserContext))]
    [Migration("20211124182210_Collaborator")]
    partial class Collaborator
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("FundooModels.CollaboratorModel", b =>
                {
                    b.Property<int>("CollaboratorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("EmailId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("NoteId")
                        .HasColumnType("int");

                    b.HasKey("CollaboratorID");

                    b.HasIndex("NoteId");

                    b.ToTable("Collaborator");
                });

            modelBuilder.Entity("FundooModels.NotesModel", b =>
                {
                    b.Property<int>("NoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AddImage")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Body")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Color")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("IsArchive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsPin")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsTrash")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("RemindMe")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Title")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("NoteId");

                    b.HasIndex("UserID");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("FundooModels.RegisterModel", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("UserID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("FundooModels.CollaboratorModel", b =>
                {
                    b.HasOne("FundooModels.NotesModel", "NotesModel")
                        .WithMany()
                        .HasForeignKey("NoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FundooModels.NotesModel", b =>
                {
                    b.HasOne("FundooModels.RegisterModel", "RegisterModel")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
