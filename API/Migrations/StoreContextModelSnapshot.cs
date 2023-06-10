﻿// <auto-generated />
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

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
                            code = "codigolibro1",
                            description = "Ea non nesciunt distinctio aspernatur eum id id"
                        },
                        new
                        {
                            id = 2,
                            book = "Felipa Lindgren DVM",
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

                    b.ToTable("Reserves");

                    b.HasData(
                        new
                        {
                            id = 1,
                            book_id = 1,
                            reserved_at = new DateTime(2023, 6, 2, 20, 44, 0, 757, DateTimeKind.Local).AddTicks(9572),
                            user_id = 1
                        },
                        new
                        {
                            id = 2,
                            book_id = 2,
                            reserved_at = new DateTime(2023, 3, 1, 20, 44, 0, 757, DateTimeKind.Local).AddTicks(9617),
                            user_id = 1
                        },
                        new
                        {
                            id = 3,
                            book_id = 1,
                            reserved_at = new DateTime(2023, 5, 30, 20, 44, 0, 757, DateTimeKind.Local).AddTicks(9620),
                            user_id = 2
                        },
                        new
                        {
                            id = 4,
                            book_id = 2,
                            reserved_at = new DateTime(2023, 6, 8, 20, 44, 0, 757, DateTimeKind.Local).AddTicks(9622),
                            user_id = 2
                        });
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
#pragma warning restore 612, 618
        }
    }
}
