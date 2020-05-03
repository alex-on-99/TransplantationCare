using Microsoft.EntityFrameworkCore.Migrations;

namespace TransplantationCare.DataAccess.Migrations
{
    public partial class AddAdminIdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ContractStatuses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "Processes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Processes");

            migrationBuilder.InsertData(
                table: "ContractStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "Відхилено" });
        }
    }
}
