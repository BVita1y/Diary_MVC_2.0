using Microsoft.EntityFrameworkCore.Migrations;

namespace Diary_MVC_2._0.Migrations
{
    public partial class AddIsPerformed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPerformed",
                table: "Plan",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPerformed",
                table: "Plan");
        }
    }
}
