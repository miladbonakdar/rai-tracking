using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class models_changed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AdminType",
                table: "Admins",
                nullable: false,
                defaultValue: "UserType.Agent",
                oldClrType: typeof(string),
                oldType: "text",
                oldDefaultValue: "AdminType.Agent");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AdminType",
                table: "Admins",
                type: "text",
                nullable: false,
                defaultValue: "AdminType.Agent",
                oldClrType: typeof(string),
                oldDefaultValue: "UserType.Agent");
        }
    }
}
