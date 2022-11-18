using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kalin.EntityframeworkCore.Migrations
{
    /// <inheritdoc />
    public partial class PortAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Port",
                table: "Requests",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Port",
                table: "Requests");
        }
    }
}
