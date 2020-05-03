using Microsoft.EntityFrameworkCore.Migrations;

namespace TransplantationCare.DataAccess.Migrations
{
    public partial class AddDescriptionMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Contracts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Contracts");
        }
    }
}
