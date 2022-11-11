using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddHumanoPeso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Altura",
                table: "humano",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Peso",
                table: "humano",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Peso",
                table: "humano");

            migrationBuilder.AlterColumn<float>(
                name: "Altura",
                table: "humano",
                type: "float",
                nullable: true,
                oldClrType: typeof(float));
        }
    }
}
