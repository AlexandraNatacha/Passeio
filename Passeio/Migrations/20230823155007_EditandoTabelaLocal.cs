using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Passeio.Migrations
{
    /// <inheritdoc />
    public partial class EditandoTabelaLocal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Localização",
                table: "Locais",
                newName: "Localizacao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Localizacao",
                table: "Locais",
                newName: "Localização");
        }
    }
}
