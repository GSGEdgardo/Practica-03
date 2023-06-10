using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class MigracionPractica : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    book = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Reserves",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    book_id = table.Column<int>(type: "int", nullable: false),
                    reserved_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserves", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    faculty = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "id", "book", "code", "description" },
                values: new object[,]
                {
                    { 1, "Yvette Corwin V", "codigolibro1", "Ea non nesciunt distinctio aspernatur eum id id" },
                    { 2, "Felipa Lindgren DVM", "codigolibro2", "lure quibusdam aut quo qui pariatur eum libero." }
                });

            migrationBuilder.InsertData(
                table: "Reserves",
                columns: new[] { "id", "book_id", "reserved_at", "user_id" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 6, 2, 20, 44, 0, 757, DateTimeKind.Local).AddTicks(9572), 1 },
                    { 2, 2, new DateTime(2023, 3, 1, 20, 44, 0, 757, DateTimeKind.Local).AddTicks(9617), 1 },
                    { 3, 1, new DateTime(2023, 5, 30, 20, 44, 0, 757, DateTimeKind.Local).AddTicks(9620), 2 },
                    { 4, 2, new DateTime(2023, 6, 8, 20, 44, 0, 757, DateTimeKind.Local).AddTicks(9622), 2 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "code", "faculty", "name" },
                values: new object[,]
                {
                    { 1, "codigo1", "Voluptatibus quia voluptatem quia nisi.", "Prof. Aleen Konopelsk" },
                    { 2, "codigo2", "Animi laboriosam voluptatum assumenda odit.", "Antoinette Mayer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Reserves");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
