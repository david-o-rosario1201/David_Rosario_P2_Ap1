using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace David_Rosario_P2_Ap1.Api.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accesorios",
                columns: table => new
                {
                    AccesorioId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accesorios", x => x.AccesorioId);
                });

            migrationBuilder.InsertData(
                table: "Accesorios",
                columns: new[] { "AccesorioId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Camara Trasera" },
                    { 2, "Pantalla Interior" },
                    { 3, "Interior en Piel" },
                    { 4, "Sun Roof" },
                    { 5, "Aros de Lujo" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accesorios");
        }
    }
}
