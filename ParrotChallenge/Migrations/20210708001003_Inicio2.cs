using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class Inicio2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "Producto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cantidad",
                table: "Producto",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
