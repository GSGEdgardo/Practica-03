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
                    cant_reserved = table.Column<int>(type: "int", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.id);
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
                    table.ForeignKey(
                        name: "FK_Reserves_Books_book_id",
                        column: x => x.book_id,
                        principalTable: "Books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reserves_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "id", "book", "cant_reserved", "code", "description" },
                values: new object[,]
                {
                    { 1, "Yvette Corwin V", 0, "codigolibro1", "Ea non nesciunt distinctio aspernatur eum id id" },
                    { 2, "Felipa Lindgren DVM", 0, "codigolibro2", "lure quibusdam aut quo qui pariatur eum libero." }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "code", "faculty", "name" },
                values: new object[,]
                {
                    { 1, "codigo1", "Voluptatibus quia voluptatem quia nisi.", "Prof. Aleen Konopelsk" },
                    { 2, "codigo2", "Animi laboriosam voluptatum assumenda odit.", "Antoinette Mayer" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reserves_book_id",
                table: "Reserves",
                column: "book_id");

            migrationBuilder.CreateIndex(
                name: "IX_Reserves_user_id",
                table: "Reserves",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reserves");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
