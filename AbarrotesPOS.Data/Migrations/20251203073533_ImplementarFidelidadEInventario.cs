using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbarrotesPOS.Data.Migrations
{
    /// <inheritdoc />
    public partial class ImplementarFidelidadEInventario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PuntosAcumulados",
                table: "Clientes",
                newName: "Puntos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Puntos",
                table: "Clientes",
                newName: "PuntosAcumulados");
        }
    }
}
