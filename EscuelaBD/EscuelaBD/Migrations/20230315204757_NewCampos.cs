using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EscuelaBD.Migrations
{
    /// <inheritdoc />
    public partial class NewCampos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlumnoID",
                table: "Salones");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AlumnoID",
                table: "Salones",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
