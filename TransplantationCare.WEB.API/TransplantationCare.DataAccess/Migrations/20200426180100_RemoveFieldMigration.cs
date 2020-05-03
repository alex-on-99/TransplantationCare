using Microsoft.EntityFrameworkCore.Migrations;

namespace TransplantationCare.DataAccess.Migrations
{
    public partial class RemoveFieldMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPositive",
                table: "Reviews");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPositive",
                table: "Reviews",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
