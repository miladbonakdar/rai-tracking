using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Persistence.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsAdmin = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    Location_Latitude = table.Column<double>(nullable: true),
                    Location_Longitude = table.Column<double>(nullable: true),
                    Code = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    CreatedById = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedById = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PersonName_Firstname = table.Column<string>(maxLength: 200, nullable: true),
                    PersonName_Lastname = table.Column<string>(maxLength: 200, nullable: true),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 13, nullable: true),
                    Telephone = table.Column<string>(maxLength: 13, nullable: true),
                    About = table.Column<string>(nullable: true),
                    AdminType = table.Column<string>(nullable: true, defaultValue: "AdminType.Agent"),
                    OrganizationId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    CreatedById = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedById = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admins_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    Location_Latitude = table.Column<double>(nullable: true),
                    Location_Longitude = table.Column<double>(nullable: true),
                    PreStationId = table.Column<int>(nullable: true),
                    PostStationId = table.Column<int>(nullable: true),
                    OrganizationId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    CreatedById = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedById = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stations_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stations_Stations_PostStationId",
                        column: x => x.PostStationId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stations_Stations_PreStationId",
                        column: x => x.PreStationId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Depos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Location_Latitude = table.Column<double>(nullable: true),
                    Location_Longitude = table.Column<double>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    OrganizationId = table.Column<int>(nullable: false),
                    StationId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    CreatedById = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedById = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Depos_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Depos_Stations_StationId",
                        column: x => x.StationId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PhoneNumber = table.Column<string>(maxLength: 13, nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    LastLocation_Latitude = table.Column<double>(nullable: true),
                    LastLocation_Longitude = table.Column<double>(nullable: true),
                    PersonName_Firstname = table.Column<string>(maxLength: 200, nullable: true),
                    PersonName_Lastname = table.Column<string>(maxLength: 200, nullable: true),
                    AgentInfo_IsGpsOn = table.Column<bool>(nullable: true),
                    AgentInfo_Battery = table.Column<int>(nullable: true),
                    AgentInfo_UpdatedAt = table.Column<DateTime>(nullable: true),
                    AgentSetting_Version = table.Column<int>(nullable: true),
                    DepoId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    CreatedById = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedById = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agents_Depos_DepoId",
                        column: x => x.DepoId,
                        principalTable: "Depos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AgentEvent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OccurredAt = table.Column<DateTime>(nullable: false),
                    EventType = table.Column<int>(nullable: false),
                    AgentLocation_Latitude = table.Column<double>(nullable: true),
                    AgentLocation_Longitude = table.Column<double>(nullable: true),
                    IsValidLocation = table.Column<bool>(nullable: false),
                    Seen = table.Column<bool>(nullable: false),
                    EventData = table.Column<string>(nullable: false),
                    AgentId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    CreatedById = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedById = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgentEvent_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Commands",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<int>(nullable: false),
                    SentAt = table.Column<DateTime>(nullable: false),
                    CommandData = table.Column<string>(nullable: false),
                    AgentId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    CreatedById = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedById = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commands_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Missions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RemainingTime = table.Column<int>(nullable: false),
                    OTDR = table.Column<int>(nullable: true),
                    StartedAt = table.Column<DateTime>(nullable: true),
                    FinishedAt = table.Column<DateTime>(nullable: true),
                    FailureLocation_Latitude = table.Column<double>(nullable: true),
                    FailureLocation_Longitude = table.Column<double>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    StartOneId = table.Column<int>(nullable: false),
                    StartTwoId = table.Column<int>(nullable: false),
                    AgentId = table.Column<int>(nullable: false),
                    AdminId = table.Column<int>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    CreatedById = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedById = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Missions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Missions_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Missions_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Missions_Stations_StartOneId",
                        column: x => x.StartOneId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Missions_Stations_StartTwoId",
                        column: x => x.StartTwoId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MissionEvent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OccurredAt = table.Column<DateTime>(nullable: false),
                    EventType = table.Column<int>(nullable: false),
                    AgentLocation_Latitude = table.Column<double>(nullable: true),
                    AgentLocation_Longitude = table.Column<double>(nullable: true),
                    IsValidLocation = table.Column<bool>(nullable: false),
                    Seen = table.Column<bool>(nullable: false),
                    EventData = table.Column<string>(nullable: false),
                    AgentId = table.Column<int>(nullable: false),
                    MissionId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    CreatedById = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedById = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MissionEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MissionEvent_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MissionEvent_Missions_MissionId",
                        column: x => x.MissionId,
                        principalTable: "Missions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MissionLocation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Location_Latitude = table.Column<double>(nullable: true),
                    Location_Longitude = table.Column<double>(nullable: true),
                    MissionId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    CreatedById = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedById = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MissionLocation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MissionLocation_Missions_MissionId",
                        column: x => x.MissionId,
                        principalTable: "Missions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_Email",
                table: "Admins",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Admins_OrganizationId",
                table: "Admins",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_AgentEvent_AgentId",
                table: "AgentEvent",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Agents_DepoId",
                table: "Agents",
                column: "DepoId");

            migrationBuilder.CreateIndex(
                name: "IX_Agents_Email",
                table: "Agents",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Agents_PhoneNumber",
                table: "Agents",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Commands_AgentId",
                table: "Commands",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Depos_Name",
                table: "Depos",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Depos_OrganizationId",
                table: "Depos",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Depos_StationId",
                table: "Depos",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_MissionEvent_AgentId",
                table: "MissionEvent",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_MissionEvent_MissionId",
                table: "MissionEvent",
                column: "MissionId");

            migrationBuilder.CreateIndex(
                name: "IX_MissionLocation_MissionId",
                table: "MissionLocation",
                column: "MissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Missions_AdminId",
                table: "Missions",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Missions_AgentId",
                table: "Missions",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Missions_StartOneId",
                table: "Missions",
                column: "StartOneId");

            migrationBuilder.CreateIndex(
                name: "IX_Missions_StartTwoId",
                table: "Missions",
                column: "StartTwoId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_Code",
                table: "Organizations",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_Name",
                table: "Organizations",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stations_Code",
                table: "Stations",
                column: "Code",
                unique: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgentEvent");

            migrationBuilder.DropTable(
                name: "Commands");

            migrationBuilder.DropTable(
                name: "MissionEvent");

            migrationBuilder.DropTable(
                name: "MissionLocation");

            migrationBuilder.DropTable(
                name: "Missions");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropTable(
                name: "Depos");

            migrationBuilder.DropTable(
                name: "Stations");

            migrationBuilder.DropTable(
                name: "Organizations");
        }
    }
}
