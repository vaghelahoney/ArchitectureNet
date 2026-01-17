using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuiteRx.Interface.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddMissingColumnsToRegistration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Registration",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    full_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password_hash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registration", x => x.id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user123",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ac3a06ab-00d4-40d3-88dc-26c557c31a4f", "2d3dd9fb-9875-447b-b075-e724660ad4bf" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registration");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user123",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "25c7eac8-54c3-466b-8e67-5676be809c5c", "8323c118-07e6-4d13-9935-c4faf58af283" });
        }
    }
}
