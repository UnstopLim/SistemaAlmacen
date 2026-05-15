using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaAlmacen.Migrations
{
    /// <inheritdoc />
    public partial class _3terceramigracción : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Credenciales");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "Credenciales",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
