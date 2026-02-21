using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbarrotesPOS.Data.Migrations
{
    /// <inheritdoc />
    public partial class RelacionVentaCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VentaDetalles_Ventas_VentaId",
                table: "VentaDetalles");

            migrationBuilder.DropIndex(
                name: "IX_VentaDetalles_VentaId",
                table: "VentaDetalles");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "VentaDetalles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VentaDetalles_ClienteId",
                table: "VentaDetalles",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_VentaDetalles_Ventas_ClienteId",
                table: "VentaDetalles",
                column: "ClienteId",
                principalTable: "Ventas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VentaDetalles_Ventas_ClienteId",
                table: "VentaDetalles");

            migrationBuilder.DropIndex(
                name: "IX_VentaDetalles_ClienteId",
                table: "VentaDetalles");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "VentaDetalles");

            migrationBuilder.CreateIndex(
                name: "IX_VentaDetalles_VentaId",
                table: "VentaDetalles",
                column: "VentaId");

            migrationBuilder.AddForeignKey(
                name: "FK_VentaDetalles_Ventas_VentaId",
                table: "VentaDetalles",
                column: "VentaId",
                principalTable: "Ventas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
