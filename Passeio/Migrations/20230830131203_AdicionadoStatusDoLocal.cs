using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Passeio.Migrations
{
    /// <inheritdoc />
    public partial class AdicionadoStatusDoLocal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Locais",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Locais");
        }
    }
}
