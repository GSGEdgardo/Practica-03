using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rut = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    dish_id = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "id", "name", "rut" },
                values: new object[,]
                {
                    { 1, "customer1", "20.416.853-9" },
                    { 2, "customer2", "12.613.809-1" }
                });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "id", "name", "price" },
                values: new object[,]
                {
                    { 1, "Pollo con papas", 8000 },
                    { 2, "Cazuela", 5000 }
                });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "id", "created_at", "customer_id", "dish_id", "updated_at" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 6, 9, 12, 54, 35, 152, DateTimeKind.Local).AddTicks(4449), 1, 1, new DateTime(2023, 6, 9, 12, 54, 35, 152, DateTimeKind.Local).AddTicks(4497) },
                    { 2, new DateTime(2023, 3, 8, 12, 54, 35, 152, DateTimeKind.Local).AddTicks(4500), 1, 2, new DateTime(2023, 3, 8, 12, 54, 35, 152, DateTimeKind.Local).AddTicks(4501) },
                    { 3, new DateTime(2023, 6, 6, 12, 54, 35, 152, DateTimeKind.Local).AddTicks(4503), 2, 1, new DateTime(2023, 6, 6, 12, 54, 35, 152, DateTimeKind.Local).AddTicks(4505) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "Purchases");
        }
    }
}
