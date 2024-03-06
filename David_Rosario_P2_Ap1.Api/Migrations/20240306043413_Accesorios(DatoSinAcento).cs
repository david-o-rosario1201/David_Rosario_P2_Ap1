using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace David_Rosario_P2_Ap1.Api.Migrations
{
    /// <inheritdoc />
    public partial class AccesoriosDatoSinAcento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accesorios",
                keyColumn: "AccesorioId",
                keyValue: 1,
                column: "Descripcion",
                value: "Cámara Trasera");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accesorios",
                keyColumn: "AccesorioId",
                keyValue: 1,
                column: "Descripcion",
                value: "Camara Trasera");
        }
    }
}
