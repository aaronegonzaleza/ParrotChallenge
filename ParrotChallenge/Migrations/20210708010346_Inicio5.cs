using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class Inicio5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleOrden_Ordenes_OrdenId",
                table: "DetalleOrden");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalleOrden_Productos_ProductoId",
                table: "DetalleOrden");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DetalleOrden",
                table: "DetalleOrden");

            migrationBuilder.RenameTable(
                name: "DetalleOrden",
                newName: "DetallesOrdenes");

            migrationBuilder.RenameIndex(
                name: "IX_DetalleOrden_ProductoId",
                table: "DetallesOrdenes",
                newName: "IX_DetallesOrdenes_ProductoId");

            migrationBuilder.RenameIndex(
                name: "IX_DetalleOrden_OrdenId",
                table: "DetallesOrdenes",
                newName: "IX_DetallesOrdenes_OrdenId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetallesOrdenes",
                table: "DetallesOrdenes",
                column: "DetalleOrdenId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetallesOrdenes_Ordenes_OrdenId",
                table: "DetallesOrdenes");

            migrationBuilder.DropForeignKey(
                name: "FK_DetallesOrdenes_Productos_ProductoId",
                table: "DetallesOrdenes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DetallesOrdenes",
                table: "DetallesOrdenes");

            migrationBuilder.RenameTable(
                name: "DetallesOrdenes",
                newName: "DetalleOrden");

            migrationBuilder.RenameIndex(
                name: "IX_DetallesOrdenes_ProductoId",
                table: "DetalleOrden",
                newName: "IX_DetalleOrden_ProductoId");

            migrationBuilder.RenameIndex(
                name: "IX_DetallesOrdenes_OrdenId",
                table: "DetalleOrden",
                newName: "IX_DetalleOrden_OrdenId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetalleOrden",
                table: "DetalleOrden",
                column: "DetalleOrdenId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleOrden_Ordenes_OrdenId",
                table: "DetalleOrden",
                column: "OrdenId",
                principalTable: "Ordenes",
                principalColumn: "OrdenId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleOrden_Productos_ProductoId",
                table: "DetalleOrden",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "ProductoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
