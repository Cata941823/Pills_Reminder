using Microsoft.EntityFrameworkCore.Migrations;

namespace PillsReminder.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdMedicament",
                table: "DozaMedicament",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdMedicament",
                table: "DozaMedicament");
        }
    }
}
