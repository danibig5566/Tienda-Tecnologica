using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiendaBackendApi.Migrations
{
    /// <inheritdoc />
    public partial class FixCategoriaNombre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoriaNombre",
                table: "Productos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoriaNombre",
                table: "Productos");
        }
    }
}
