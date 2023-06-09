﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(StoreContext))]
    partial class StoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API.Book", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("book")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("cant_reserved")
                        .HasColumnType("int");

                    b.Property<string>("code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            id = 1,
                            book = "Yvette Corwin V",
                            cant_reserved = 0,
                            code = "codigolibro1",
                            description = "Ea non nesciunt distinctio aspernatur eum id id"
                        },
                        new
                        {
                            id = 2,
                            book = "Felipa Lindgren DVM",
                            cant_reserved = 0,
                            code = "codigolibro2",
                            description = "lure quibusdam aut quo qui pariatur eum libero."
                        });
                });

            modelBuilder.Entity("API.Reserve", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("book_id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("reserved_at")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("book_id");

                    b.HasIndex("user_id");

                    b.ToTable("Reserves");
                });

            modelBuilder.Entity("API.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("faculty")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            id = 1,
                            code = "codigo1",
                            faculty = "Voluptatibus quia voluptatem quia nisi.",
                            name = "Prof. Aleen Konopelsk"
                        },
                        new
                        {
                            id = 2,
                            code = "codigo2",
                            faculty = "Animi laboriosam voluptatum assumenda odit.",
                            name = "Antoinette Mayer"
                        });
                });

            modelBuilder.Entity("API.Reserve", b =>
                {
                    b.HasOne("API.Book", "book")
                        .WithMany()
                        .HasForeignKey("book_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.User", "user")
                        .WithMany()
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("book");

                    b.Navigation("user");
                });
#pragma warning restore 612, 618
        }
    }
}