using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class stations_relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Stations_PostStationId",
                table: "Stations",
                column: "PostStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Stations_PreStationId",
                table: "Stations",
                column: "PreStationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stations_Stations_PostStationId",
                table: "Stations",
                column: "PostStationId",
                principalTable: "Stations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stations_Stations_PreStationId",
                table: "Stations",
                column: "PreStationId",
                principalTable: "Stations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stations_Stations_PostStationId",
                table: "Stations");

            migrationBuilder.DropForeignKey(
                name: "FK_Stations_Stations_PreStationId",
                table: "Stations");

            migrationBuilder.DropIndex(
                name: "IX_Stations_PostStationId",
                table: "Stations");

            migrationBuilder.DropIndex(
                name: "IX_Stations_PreStationId",
                table: "Stations");
        }
    }
}
