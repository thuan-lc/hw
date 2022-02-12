using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryManagementAPI.Migrations
{
    public partial class AddCreditsFieldToIdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Credits",
                table: "AspNetUsers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Credits",
                table: "AspNetUsers");
        }
    }
}
