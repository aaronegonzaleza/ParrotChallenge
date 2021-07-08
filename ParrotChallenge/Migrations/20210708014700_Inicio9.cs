using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class Inicio9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetallesOrdenes_Ordenes_OrdenId",
                table: "DetallesOrdenes");

            migrationBuilder.DropForeignKey(
                name: "FK_DetallesOrdenes_Productos_ProductoId",
                table: "DetallesOrdenes");

            migrationBuilder.AlterColumn<int>(
                name: "ProductoId",
                table: "DetallesOrdenes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrdenId",
                table: "DetallesOrdenes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesOrdenes_Ordenes_OrdenId",
                table: "DetallesOrdenes",
                column: "OrdenId",
                principalTable: "Ordenes",
                principalColumn: "OrdenId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesOrdenes_Productos_ProductoId",
                table: "DetallesOrdenes",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "ProductoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetallesOrdenes_Ordenes_OrdenId",
                table: "DetallesOrdenes");

            migrationBuilder.DropForeignKey(
                name: "FK_DetallesOrdenes_Productos_ProductoId",
                table: "DetallesOrdenes");

            migrationBuilder.AlterColumn<int>(
                name: "ProductoId",
                table: "DetallesOrdenes",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "OrdenId",
                table: "DetallesOrdenes",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesOrdenes_Ordenes_OrdenId",
                table: "DetallesOrdenes",
                column: "OrdenId",
                principalTable: "Ordenes",
                principalColumn: "OrdenId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesOrdenes_Productos_ProductoId",
                table: "DetallesOrdenes",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "ProductoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
