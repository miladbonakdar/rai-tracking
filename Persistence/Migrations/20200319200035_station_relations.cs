using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class station_relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "Stations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PostStationId",
                table: "Stations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PreStationId",
                table: "Stations",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 11, 168, 167 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 20, 229, 169 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 20, 121, 172 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 20, 173, 202 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 5,
                column: "OrganizationId",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 8, 211, 210 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 8, 213, 442 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 8, 215, 214 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 8, 217, 216 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "OrganizationId", "PreStationId" },
                values: new object[] { 8, 195 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 8, 225, 224 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "OrganizationId", "PreStationId" },
                values: new object[] { 8, 443 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 11, 14, 162 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 11, 161, 13 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 11, 16, 161 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 11, 17, 15 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 11, 18, 16 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 11, 120, 17 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 19, 20, 418 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 19, 21, 19 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 19, 22, 20 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 19, 23, 21 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 19, 24, 22 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 19, 25, 23 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 19, 26, 24 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 19, 27, 25 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 19, 28, 26 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 19, 29, 27 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 19, 30, 28 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 19, 31, 29 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 19, 32, 30 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 19, 33, 31 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 19, 34, 32 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 19, 35, 33 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 19, 36, 34 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 19, 37, 35 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 19, 39, 36 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 19, 39, 37 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 19, 40, 37 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 19, 41, 39 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 19, 42, 40 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 19, 43, 41 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 19, 44, 42 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 19, 45, 43 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "OrganizationId", "PreStationId" },
                values: new object[] { 19, 44 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "OrganizationId", "PreStationId" },
                values: new object[] { 10, 270 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 23, 48, 312 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 23, 313, 47 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 23, 314, 313 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 23, 52, 51 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 23, 50, 315 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 23, 316, 50 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "OrganizationId", "PreStationId" },
                values: new object[] { 23, 324 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 23, 55, 325 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "OrganizationId", "PreStationId" },
                values: new object[] { 23, 54 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 18, 150, 151 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "OrganizationId", "PreStationId" },
                values: new object[] { 15, 129 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "OrganizationId", "PreStationId" },
                values: new object[] { 24, 362 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 59,
                column: "OrganizationId",
                value: 24);

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 24, 343, 342 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 14, 62, 293 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 14, 63, 61 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 14, 64, 62 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 14, 65, 63 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 14, 66, 64 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 14, 67, 65 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 14, 68, 66 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 14, 69, 67 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 14, 70, 68 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 14, 336, 69 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "OrganizationId", "PostStationId" },
                values: new object[] { 16, 326 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 16, 327, 326 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 16, 333, 332 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 16, 75, 333 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 16, 76, 74 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 16, 399, 75 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 16, 76, 76 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 12, 233, 423 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 9, 80, 78 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 9, 81, 79 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 9, 82, 80 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 9, 83, 81 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 9, 84, 82 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 9, 85, 83 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 9, 86, 84 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 9, 87, 85 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 9, 88, 86 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 9, 89, 87 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 9, 90, 88 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 2, 91, 89 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 2, 92, 90 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 2, 93, 91 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 2, 94, 92 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 2, 95, 93 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 2, 96, 94 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 2, 97, 95 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 2, 98, 96 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 2, 99, 97 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 2, 100, 98 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 2, 101, 99 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 22, 102, 100 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 22, 103, 101 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 22, 104, 102 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 22, 105, 103 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 22, 106, 104 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 22, 107, 105 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 22, 108, 106 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 22, 109, 107 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 22, 110, 108 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 22, 111, 109 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 22, 100, 110 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 13, 113, 111 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 13, 114, 112 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 13, 115, 113 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 13, 116, 114 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 13, 187, 115 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 18, 200, 118 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 18, 117, 159 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 18, 160, 120 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 18, 119, 18 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 20, 173, 3 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "OrganizationId", "PreStationId" },
                values: new object[] { 15, 123 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 15, 122, 124 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 15, 123, 125 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 15, 124, 126 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 15, 125, 127 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 15, 126, 128 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 15, 127, 130 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 15, 128, 130 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 15, 129, 131 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 15, 130, 132 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 15, 131, 133 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 15, 132, 134 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 15, 133, 135 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 15, 134, 421 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 15, 421, 137 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 15, 136, 138 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 15, 137, 139 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 15, 138, 140 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 140,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 15, 139, 420 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 141,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 18, 420, 142 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 142,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 18, 141, 143 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 143,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 18, 142, 144 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 144,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 18, 143, 145 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 145,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 18, 144, 146 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 146,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 18, 145, 147 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 147,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 18, 146, 148 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 148,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 18, 147, 149 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 149,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 18, 148, 150 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 150,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 18, 149, 56 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 151,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 18, 56, 64 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 152,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 18, 151, 153 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 153,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 18, 64, 154 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 154,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 18, 153, 155 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 155,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 18, 154, 156 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 156,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 18, 155, 157 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 157,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 18, 156, 158 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 158,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 18, 157, 199 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 159,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 18, 118, 160 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 160,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 18, 159, 119 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 161,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 11, 15, 14 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 162,
                columns: new[] { "OrganizationId", "PostStationId" },
                values: new object[] { 11, 13 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 163,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 11, 164, 162 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 164,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 11, 165, 163 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 165,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 11, 166, 164 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 166,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 11, 167, 165 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 167,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 11, 1, 166 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 168,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 11, 169, 1 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 169,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 11, 2, 168 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 170,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 20, 171, 2 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 171,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 20, 172, 170 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 172,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 20, 3, 171 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 173,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 20, 174, 121 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 174,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 20, 175, 173 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 175,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 20, 176, 174 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 176,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 20, 177, 175 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 177,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 20, 178, 176 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 178,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 20, 179, 177 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 179,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 20, 180, 178 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 180,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 20, 181, 179 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 181,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 20, 182, 180 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 182,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 20, 183, 181 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 183,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 20, 184, 182 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 184,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 20, 185, 183 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 185,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 20, 186, 184 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 186,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 20, 201, 185 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 187,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 13, 192, 116 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 188,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 13, 189, 187 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 189,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 13, 190, 188 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 190,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 13, 191, 189 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 191,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 13, 434, 190 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 192,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 13, 193, 187 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 193,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 13, 194, 192 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 194,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 13, 195, 193 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 195,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 8, 10, 220 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 196,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 13, 198, 195 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 197,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 13, 198, 196 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 198,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 13, 188, 197 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 199,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 18, 158, 200 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 200,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 18, 199, 117 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 201,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 20, 202, 186 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 202,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 20, 4, 201 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 203,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 20, 204, 4 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 204,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 20, 205, 203 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 205,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 20, 206, 204 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 206,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 20, 207, 205 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 207,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 20, 433, 206 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 208,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 20, 209, 433 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 209,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 20, 210, 208 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 210,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 8, 6, 209 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 211,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 8, 212, 6 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 212,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 8, 442, 211 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 213,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 8, 214, 7 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 214,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 8, 8, 213 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 215,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 8, 216, 8 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 216,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 8, 9, 215 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 217,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 8, 441, 9 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 218,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 8, 219, 441 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 219,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 8, 220, 218 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 220,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 8, 195, 219 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 221,
                columns: new[] { "OrganizationId", "PostStationId" },
                values: new object[] { 13, 220 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 222,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 8, 223, 216 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 223,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 8, 224, 222 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 224,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 8, 11, 223 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 225,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 8, 226, 11 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 226,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 8, 227, 225 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 227,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 8, 228, 226 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 228,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 8, 443, 227 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 229,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 11, 230, 162 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 230,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 11, 231, 417 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 231,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 11, 232, 230 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 232,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 11, 245, 230 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 233,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 12, 234, 404 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 234,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 12, 235, 233 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 235,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 12, 236, 234 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 236,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 12, 237, 235 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 237,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 12, 238, 236 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 238,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 12, 239, 237 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 239,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 12, 240, 238 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 240,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 12, 241, 239 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 241,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 12, 242, 240 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 242,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 12, 422, 241 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 243,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 11, 422, 244 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 244,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 11, 243, 245 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 245,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 11, 244, 232 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 246,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 10, 242, 248 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 247,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 10, 246, 246 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 248,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 10, 247, 247 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 249,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 10, 247, 248 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 250,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 10, 252, 249 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 251,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 10, 250, 250 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 252,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 10, 254, 251 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 253,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 10, 252, 252 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 254,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 10, 256, 253 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 255,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 10, 254, 256 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 256,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 10, 257, 255 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 257,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 10, 258, 256 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 258,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 10, 260, 257 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 259,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 10, 258, 260 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 260,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 10, 262, 259 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 261,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 10, 260, 262 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 262,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 10, 261, 263 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 263,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 10, 271, 262 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 264,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 10, 263, 263 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 265,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 10, 264, 264 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 266,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 10, 267, 265 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 267,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 10, 375, 266 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 268,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 10, 270, 375 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 269,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 10, 270, 268 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 270,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 10, 435, 269 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 271,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 10, 272, 263 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 272,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 10, 273, 271 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 273,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 10, 274, 272 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 274,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 10, 275, 273 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 275,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 10, 276, 274 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 276,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 10, 277, 275 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 277,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 10, 278, 276 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 278,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 10, 279, 277 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 279,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 10, 280, 278 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 280,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 10, 281, 279 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 281,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 14, 294, 293 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 282,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 14, 283, 430 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 283,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 14, 284, 282 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 284,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 14, 285, 283 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 285,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 14, 286, 284 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 286,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 14, 287, 285 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 287,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 14, 288, 286 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 288,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 14, 289, 287 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 289,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 14, 290, 288 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 290,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 14, 291, 289 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 291,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 14, 292, 290 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 292,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 14, 293, 291 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 293,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 14, 294, 292 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 294,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 14, 295, 281 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 295,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 14, 296, 294 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 296,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 14, 297, 295 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 297,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 14, 298, 296 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 298,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 14, 299, 297 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 299,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 14, 300, 298 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 300,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 14, 301, 299 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 301,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 14, 302, 300 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 302,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 14, 303, 301 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 303,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 14, 308, 302 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 304,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 14, 305, 308 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 305,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 24, 306, 304 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 306,
                columns: new[] { "OrganizationId", "PostStationId" },
                values: new object[] { 24, 307 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 307,
                columns: new[] { "OrganizationId", "PostStationId" },
                values: new object[] { 24, 334 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 308,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 14, 304, 303 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 309,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 23, 310, 432 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 310,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 23, 309, 309 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 311,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 23, 310, 310 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 312,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 23, 311, 311 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 313,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 23, 48, 48 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 314,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 23, 49, 49 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 315,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 23, 314, 314 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 316,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 23, 52, 52 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 317,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 23, 316, 316 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 318,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 23, 317, 317 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 319,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 23, 318, 318 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 320,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 23, 319, 319 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 321,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 23, 320, 320 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 322,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 23, 321, 321 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 323,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 23, 322, 322 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 324,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 23, 323, 323 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 325,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 23, 54, 324 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 326,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 16, 72, 71 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 327,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 16, 328, 72 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 328,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 16, 329, 327 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 329,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 16, 330, 328 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 330,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 16, 331, 329 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 331,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 16, 332, 330 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 332,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 16, 73, 331 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 333,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 16, 74, 73 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 334,
                columns: new[] { "OrganizationId", "PostStationId" },
                values: new object[] { 24, 335 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 335,
                columns: new[] { "OrganizationId", "PostStationId" },
                values: new object[] { 24, 336 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 336,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 24, 337, 335 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 337,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 24, 338, 336 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 338,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 24, 339, 337 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 339,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 24, 340, 338 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 340,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 24, 341, 339 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 341,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 24, 342, 340 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 342,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 24, 60, 341 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 343,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 24, 244, 60 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 344,
                columns: new[] { "OrganizationId", "PostStationId" },
                values: new object[] { 24, 345 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 345,
                columns: new[] { "OrganizationId", "PostStationId" },
                values: new object[] { 24, 346 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 346,
                columns: new[] { "OrganizationId", "PostStationId" },
                values: new object[] { 24, 347 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 347,
                columns: new[] { "OrganizationId", "PostStationId" },
                values: new object[] { 24, 348 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 348,
                columns: new[] { "OrganizationId", "PostStationId" },
                values: new object[] { 24, 349 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 349,
                column: "OrganizationId",
                value: 24);

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 350,
                column: "OrganizationId",
                value: 24);

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 351,
                column: "OrganizationId",
                value: 24);

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 352,
                column: "OrganizationId",
                value: 24);

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 353,
                column: "OrganizationId",
                value: 24);

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 354,
                column: "OrganizationId",
                value: 24);

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 355,
                column: "OrganizationId",
                value: 24);

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 356,
                column: "OrganizationId",
                value: 24);

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 357,
                column: "OrganizationId",
                value: 24);

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 358,
                column: "OrganizationId",
                value: 24);

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 359,
                column: "OrganizationId",
                value: 24);

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 360,
                columns: new[] { "OrganizationId", "PreStationId" },
                values: new object[] { 24, 359 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 361,
                columns: new[] { "OrganizationId", "PreStationId" },
                values: new object[] { 24, 360 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 362,
                columns: new[] { "OrganizationId", "PreStationId" },
                values: new object[] { 24, 361 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 363,
                column: "OrganizationId",
                value: 24);

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 364,
                columns: new[] { "OrganizationId", "PreStationId" },
                values: new object[] { 24, 365 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 365,
                column: "OrganizationId",
                value: 24);

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 366,
                columns: new[] { "OrganizationId", "PreStationId" },
                values: new object[] { 24, 365 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 367,
                columns: new[] { "OrganizationId", "PreStationId" },
                values: new object[] { 24, 366 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 368,
                columns: new[] { "OrganizationId", "PreStationId" },
                values: new object[] { 17, 414 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 369,
                columns: new[] { "OrganizationId", "PreStationId" },
                values: new object[] { 17, 368 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 370,
                columns: new[] { "OrganizationId", "PreStationId" },
                values: new object[] { 17, 374 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 371,
                columns: new[] { "OrganizationId", "PreStationId" },
                values: new object[] { 17, 370 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 372,
                column: "OrganizationId",
                value: 17);

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 373,
                columns: new[] { "OrganizationId", "PreStationId" },
                values: new object[] { 17, 371 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 374,
                columns: new[] { "OrganizationId", "PreStationId" },
                values: new object[] { 17, 369 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 375,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 10, 268, 267 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 376,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 25, 377, 375 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 377,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 25, 378, 376 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 378,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 25, 379, 377 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 379,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 25, 389, 378 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 380,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 25, 398, 381 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 381,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 25, 380, 382 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 382,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 25, 381, 383 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 383,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 25, 382, 384 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 384,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 25, 383, 385 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 385,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 25, 384, 386 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 386,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 25, 385, 387 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 387,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 25, 386, 388 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 388,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 25, 387, 389 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 389,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 25, 388, 379 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 390,
                column: "OrganizationId",
                value: 25);

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 391,
                columns: new[] { "OrganizationId", "PreStationId" },
                values: new object[] { 25, 392 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 392,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 25, 391, 393 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 393,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 25, 392, 394 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 394,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 25, 393, 395 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 395,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 25, 394, 396 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 396,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 25, 395, 397 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 397,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 25, 396, 398 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 398,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 25, 397, 380 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 399,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 16, 400, 76 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 400,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 16, 401, 399 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 401,
                columns: new[] { "OrganizationId", "PreStationId" },
                values: new object[] { 16, 400 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 402,
                column: "OrganizationId",
                value: 16);

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 403,
                columns: new[] { "OrganizationId", "PreStationId" },
                values: new object[] { 17, 404 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 404,
                columns: new[] { "OrganizationId", "PreStationId" },
                values: new object[] { 17, 405 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 405,
                columns: new[] { "OrganizationId", "PreStationId" },
                values: new object[] { 16, 406 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 406,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 16, 405, 407 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 407,
                columns: new[] { "OrganizationId", "PostStationId" },
                values: new object[] { 16, 406 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 408,
                columns: new[] { "OrganizationId", "PreStationId" },
                values: new object[] { 17, 409 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 409,
                columns: new[] { "OrganizationId", "PreStationId" },
                values: new object[] { 17, 410 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 410,
                columns: new[] { "OrganizationId", "PreStationId" },
                values: new object[] { 17, 403 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 411,
                columns: new[] { "OrganizationId", "PreStationId" },
                values: new object[] { 17, 412 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 412,
                columns: new[] { "OrganizationId", "PreStationId" },
                values: new object[] { 17, 413 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 413,
                columns: new[] { "OrganizationId", "PreStationId" },
                values: new object[] { 17, 408 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 414,
                columns: new[] { "OrganizationId", "PreStationId" },
                values: new object[] { 17, 415 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 415,
                columns: new[] { "OrganizationId", "PreStationId" },
                values: new object[] { 17, 416 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 416,
                columns: new[] { "OrganizationId", "PreStationId" },
                values: new object[] { 17, 411 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 417,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 11, 165, 230 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 418,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 19, 19, 18 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 419,
                columns: new[] { "OrganizationId", "PreStationId" },
                values: new object[] { 19, 29 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 420,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 15, 140, 141 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 421,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 15, 135, 136 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 422,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 12, 423, 242 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 423,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 12, 424, 242 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 424,
                columns: new[] { "OrganizationId", "PreStationId" },
                values: new object[] { 12, 231 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 425,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 9, 426, 86 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 426,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 9, 427, 425 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 427,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 9, 428, 426 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 428,
                columns: new[] { "OrganizationId", "PreStationId" },
                values: new object[] { 9, 427 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 429,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 14, 430, 431 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 430,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 14, 282, 429 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 431,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 14, 429, 254 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 432,
                columns: new[] { "OrganizationId", "PostStationId" },
                values: new object[] { 23, 309 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 433,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 20, 208, 207 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 434,
                columns: new[] { "OrganizationId", "PreStationId" },
                values: new object[] { 13, 191 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 435,
                columns: new[] { "OrganizationId", "PreStationId" },
                values: new object[] { 10, 270 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 436,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 14, 309, 308 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 437,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 13, 191, 190 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 438,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 13, 190, 189 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 439,
                column: "OrganizationId",
                value: 13);

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 440,
                column: "OrganizationId",
                value: 13);

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 441,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 8, 218, 217 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 442,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 8, 7, 212 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 443,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 8, 12, 228 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 444,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 20, 445, 209 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 445,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 20, 22, 444 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 446,
                columns: new[] { "OrganizationId", "PostStationId", "PreStationId" },
                values: new object[] { 20, 448, 447 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 447,
                column: "OrganizationId",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 448,
                column: "OrganizationId",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 449,
                column: "OrganizationId",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 450,
                column: "OrganizationId",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 451,
                columns: new[] { "OrganizationId", "PreStationId" },
                values: new object[] { 20, 450 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 452,
                column: "OrganizationId",
                value: 19);

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 453,
                columns: new[] { "OrganizationId", "PreStationId" },
                values: new object[] { 22, 111 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 454,
                column: "OrganizationId",
                value: 19);

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 455,
                column: "OrganizationId",
                value: 19);

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 456,
                column: "OrganizationId",
                value: 19);

            migrationBuilder.CreateIndex(
                name: "IX_Stations_OrganizationId",
                table: "Stations",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Stations_PostStationId",
                table: "Stations",
                column: "PostStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Stations_PreStationId",
                table: "Stations",
                column: "PreStationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stations_Organizations_OrganizationId",
                table: "Stations",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Stations_Organizations_OrganizationId",
                table: "Stations");

            migrationBuilder.DropForeignKey(
                name: "FK_Stations_Stations_PostStationId",
                table: "Stations");

            migrationBuilder.DropForeignKey(
                name: "FK_Stations_Stations_PreStationId",
                table: "Stations");

            migrationBuilder.DropIndex(
                name: "IX_Stations_OrganizationId",
                table: "Stations");

            migrationBuilder.DropIndex(
                name: "IX_Stations_PostStationId",
                table: "Stations");

            migrationBuilder.DropIndex(
                name: "IX_Stations_PreStationId",
                table: "Stations");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "Stations");

            migrationBuilder.DropColumn(
                name: "PostStationId",
                table: "Stations");

            migrationBuilder.DropColumn(
                name: "PreStationId",
                table: "Stations");
        }
    }
}
