using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Persistence.Migrations
{
    public partial class init : Migration
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
                    Code = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    Altitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.Id);
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
                    AdminType = table.Column<string>(nullable: false, defaultValue: "UserType.Agent"),
                    OrganizationId = table.Column<int>(nullable: false)
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
                    CreatedById = table.Column<int>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedById = table.Column<int>(nullable: false)
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
                    CreatedById = table.Column<int>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedById = table.Column<int>(nullable: false)
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
                    CreatedById = table.Column<int>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedById = table.Column<int>(nullable: false)
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
                    CreatedById = table.Column<int>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedById = table.Column<int>(nullable: false)
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
                    Phase = table.Column<int>(nullable: false),
                    FailureLocation_Latitude = table.Column<double>(nullable: true),
                    FailureLocation_Longitude = table.Column<double>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    StationOneId = table.Column<int>(nullable: false),
                    StationTwoId = table.Column<int>(nullable: true),
                    AgentId = table.Column<int>(nullable: false),
                    AdminId = table.Column<int>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    CreatedById = table.Column<int>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedById = table.Column<int>(nullable: false)
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
                        name: "FK_Missions_Stations_StationOneId",
                        column: x => x.StationOneId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Missions_Stations_StationTwoId",
                        column: x => x.StationTwoId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    CreatedById = table.Column<int>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedById = table.Column<int>(nullable: false)
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
                    CreatedById = table.Column<int>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedById = table.Column<int>(nullable: false)
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

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "Code", "IsAdmin", "Name" },
                values: new object[,]
                {
                    { 1, "000", true, "ستاد" },
                    { 26, "138", false, "شمال شرق 2" },
                    { 25, "058", false, "فارس" },
                    { 24, "047", false, "شرق" },
                    { 23, "045", false, "هرمزگان" },
                    { 21, "136", false, "لرستان" },
                    { 20, "038", false, "شمال غرب" },
                    { 19, "035", false, "شمال" },
                    { 18, "036", false, "شمال شرق 1" },
                    { 17, "132", false, "جنوب شرق" },
                    { 22, "041", false, "زاگرس" },
                    { 15, "037", false, "خراسان" },
                    { 14, "044", false, "یزد" },
                    { 13, "042", false, "جنوب" },
                    { 12, "137", false, "قم" },
                    { 11, "034", false, "تهران" },
                    { 10, "043", false, "اصفهان" },
                    { 9, "040", false, "اراک" },
                    { 8, "039", false, "آذربایجان" },
                    { 2, "999", false, "نامعلوم" },
                    { 16, "057", false, "کرمان" }
                });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "Altitude", "Latitude", "Longitude", "Name" },
                values: new object[,]
                {
                    { 301, 1314.9000000000001, 31.74812, 54.929920000000003, "تبركوه" },
                    { 302, 1161.5, 31.712759999999999, 55.081400000000002, "مهرداد" },
                    { 303, 1014.2, 31.643689999999999, 55.240200000000002, "بهرام گور" },
                    { 304, 1018.8, 31.618559999999999, 55.438749999999999, "مباركه" },
                    { 305, 1210.0, 31.740200000000002, 55.479399999999998, "بيشه در" },
                    { 310, 1283.3, 31.175799999999999, 55.498309999999996, "جنت آباد" },
                    { 307, 1660.5, 31.892209999999999, 55.691189999999999, "سه چاهون" },
                    { 308, 1016.8, 31.58765, 55.39902, "بافق" },
                    { 309, 1050.4000000000001, 31.496099999999998, 55.458010000000002, "اضطراري 25" },
                    { 300, 1438.8, 31.745450000000002, 54.772869999999998, "چاه خاور" },
                    { 306, 1422.3, 31.86983, 55.5565, "شهید پور اکبری" },
                    { 299, 1297.2, 31.776990000000001, 54.635460000000002, "رخش" },
                    { 289, 1029.9000000000001, 32.83117, 53.59008, "دو گنبدان" },
                    { 297, 1268.9000000000001, 31.864419999999999, 54.34449, "يزد" },
                    { 296, 1210.0999999999999, 31.957599999999999, 54.150869999999998, "نظر آباد" },
                    { 295, 1190.4000000000001, 32.117420000000003, 53.985169999999997, "شمسي" },
                    { 294, 1154.4000000000001, 32.229199999999999, 53.929519999999997, "ميبد" },
                    { 293, 1091.0999999999999, 32.350549999999998, 53.898029999999999, "اردكان" },
                    { 292, 1056.3, 32.405549999999998, 53.880560000000003, "بي سيم" },
                    { 291, 1015.7, 32.589700000000001, 53.765180000000001, "سرو" },
                    { 290, 1010.2, 32.689540000000001, 53.692819999999998, "سياه كوه" },
                    { 311, 1497.5999999999999, 30.863, 55.496769999999998, "اضطراري 22" },
                    { 288, 1099.5, 32.950420000000001, 53.505330000000001, "سر گز" },
                    { 287, 1105.5, 33.070430000000002, 53.416240000000002, "نايين" },
                    { 298, 1285.5999999999999, 31.817900000000002, 54.500219999999999, "يزدگرد" },
                    { 312, 1425.3, 30.74718, 55.514609999999998, "بياض" },
                    { 323, 172.19999999999999, 27.406839999999999, 55.973959999999998, "تيكو" },
                    { 314, 1763.0, 29.508949999999999, 55.649700000000003, "سيرجان" },
                    { 339, 907.39999999999998, 32.777760000000001, 55.86844, "رباط پشت بادام" },
                    { 338, 1026.8, 32.595320000000001, 55.865569999999998, "خنج" },
                    { 337, 1065.9000000000001, 32.479170000000003, 55.762569999999997, "رمل" },
                    { 336, 1219.8, 32.35078, 55.699930000000002, "جندق" },
                    { 335, 1421.2, 32.230510000000002, 55.711489999999998, "چاه محمدو" },
                    { 334, 1602.9000000000001, 32.077390000000001, 55.770989999999998, "بهاباد" },
                    { 333, 1723.5999999999999, 30.655760000000001, 56.700560000000003, "حسامي" },
                    { 332, 1700.0, 30.812660000000001, 56.582349999999998, "زرند" },
                    { 331, 1649.8, 30.87369, 56.413260000000001, "جلال آباد" },
                    { 330, 1582.0, 30.870560000000001, 56.239789999999999, "گل زرد" },
                    { 329, 1483.9000000000001, 30.940670000000001, 56.108890000000002, "سنگ" },
                    { 328, 1394.0999999999999, 31.03267, 55.944690000000001, "سي ريز" },
                    { 327, 1304.4000000000001, 31.16056, 55.838329999999999, "مورد" },
                    { 326, 1147.8, 31.37529, 55.638109999999998, "كاوه" },
                    { 325, 28.0, 27.135919999999999, 56.072920000000003, "مانوري" },
                    { 324, 42.299999999999997, 27.200279999999999, 56.122019999999999, "انشعاب" },
                    { 286, 1116.0, 33.270679999999999, 53.148789999999998, "ويادوك" },
                    { 322, 313.89999999999998, 27.620740000000001, 55.898620000000001, "فين" },
                    { 321, 472.0, 27.766629999999999, 55.695329999999998, "اضطراري 6" },
                    { 320, 678.20000000000005, 27.937889999999999, 55.713509999999999, "زاد محمود" },
                    { 319, 688.29999999999995, 28.125309999999999, 55.778959999999998, "اضطراري 8" },
                    { 318, 895.10000000000002, 28.269269999999999, 55.784239999999997, "تزرج" },
                    { 317, 1237.5999999999999, 28.415800000000001, 55.738590000000002, "چاه تر" },
                    { 316, 1448.2, 28.588609999999999, 55.723239999999997, "كهه" },
                    { 315, 1711.4000000000001, 29.336670000000002, 55.617440000000002, "اضطراري 16" },
                    { 313, 1987.3, 29.915790000000001, 55.541499999999999, "خاتون آباد" },
                    { 285, 1094.4000000000001, 33.311630000000001, 53.076070000000001, "سهيل" },
                    { 275, 1703.8, 32.468890000000002, 52.905450000000002, "شيراز كوه" },
                    { 283, 1091.2, 33.394829999999999, 52.82752, "شهر آب" },
                    { 253, 1037.3, 33.788539999999998, 51.825389999999999, "ده آباد" },
                    { 252, 1033.0, 33.836660000000002, 51.763869999999997, "سرخ گل" },
                    { 251, 1024.7, 33.915599999999998, 51.618119999999998, "گز" },
                    { 250, 964.60000000000002, 33.987340000000003, 51.471620000000001, "كاشان" },
                    { 249, 920.60000000000002, 34.109549999999999, 51.386090000000003, "مد آباد" },
                    { 248, 867.60000000000002, 34.236980000000003, 51.300609999999999, "دهنار" },
                    { 247, 890.39999999999998, 34.368650000000002, 51.260129999999997, "فيروز آباد" },
                    { 246, 925.29999999999995, 34.450659999999999, 51.12003, "شوراب" },
                    { 245, 982.60000000000002, 35.265770000000003, 51.171399999999998, "علي آباد" },
                    { 244, 837.10000000000002, 34.987839999999998, 51.147779999999997, "نمكزار" },
                    { 243, 851.20000000000005, 34.791620000000002, 51.138480000000001, "سپر رستم" },
                    { 254, 1030.8, 33.657110000000003, 52.030500000000004, "بادرود" },
                    { 242, 915.39999999999998, 34.558799999999998, 51.048780000000001, "محمديه" },
                    { 240, 950.39999999999998, 34.648380000000003, 50.872619999999998, "قم" },
                    { 239, 944.20000000000005, 34.710030000000003, 50.839440000000003, "گارمانوري قم" },
                    { 238, 950.79999999999995, 34.771079999999998, 50.794330000000002, "پل" },
                    { 237, 925.0, 34.887990000000002, 50.705599999999997, "نودژ" },
                    { 236, 973.70000000000005, 34.987760000000002, 50.615029999999997, "انجيلاوند" },
                    { 235, 1178.7, 35.102159999999998, 50.634099999999997, "كوه پنگ" },
                    { 234, 1288.2, 35.223590000000002, 50.696120000000001, "شهيد خيري پور" },
                    { 233, 1206.9000000000001, 35.357889999999998, 50.691949999999999, "پرندك" },
                    { 232, 1011.9, 35.4236, 51.19903, "فرودگاه" },
                    { 231, 1064.7, 35.481760000000001, 51.075029999999998, "رباط كريم" },
                    { 230, 1093.5999999999999, 35.554079999999999, 51.215089999999996, "اسلامشهر" },
                    { 241, 942.39999999999998, 34.597380000000001, 50.91798, "جمكران" },
                    { 255, 1226.2, 33.536589999999997, 52.040520000000001, "جزن" },
                    { 256, 1412.0999999999999, 33.47184, 52.02778, "اسپيدان" },
                    { 257, 1619.5999999999999, 33.382779999999997, 52.013210000000001, "ابیازان" },
                    { 282, 1034.5999999999999, 33.395829999999997, 52.661920000000002, "رباط" },
                    { 281, 1244.0999999999999, 32.320230000000002, 53.816200000000002, "ارژنگ" },
                    { 280, 1304.5999999999999, 32.37677, 53.673580000000001, "عقدا" },
                    { 279, 1377.9000000000001, 32.38364, 53.572180000000003, "اشك" },
                    { 278, 1493.0, 32.382010000000001, 53.406730000000003, "ساسان" },
                    { 277, 1512.7, 32.394689999999997, 53.225239999999999, "هما" },
                    { 276, 1614.7, 32.430160000000001, 53.071460000000002, "شبنم" },
                    { 340, 831.29999999999995, 32.934469999999997, 55.89772, "تل حميد" },
                    { 274, 1714.5, 32.526000000000003, 52.76032, "ورزنه" },
                    { 273, 1668.2, 32.569569999999999, 52.606839999999998, "مشك" },
                    { 272, 1663.3, 32.628920000000001, 52.453209999999999, "هرند" },
                    { 271, 1588.4000000000001, 32.641660000000002, 52.285409999999999, "خير آباد" },
                    { 270, 1780.8, 32.424419999999998, 51.363799999999998, "زرين شهر" },
                    { 269, 1763.0, 32.416710000000002, 51.416939999999997, "ريز" },
                    { 268, 1687.2, 32.407789999999999, 51.525739999999999, "ديز بچه" },
                    { 267, 1649.7, 32.496589999999998, 51.57329, "آب نيل" },
                    { 266, 1660.0, 32.521470000000001, 51.637590000000003, "ايران كوه" },
                    { 265, 1608.9000000000001, 32.549880000000002, 51.695140000000002, "اصفهان" },
                    { 264, 1564.3, 32.614780000000003, 51.923099999999998, "فيروزه" },
                    { 263, 1566.5999999999999, 32.66986, 52.112209999999997, "سيستان" },
                    { 262, 1688.0, 32.833730000000003, 52.121319999999997, "ورتون" },
                    { 261, 1858.8, 32.92756, 52.11795, "گرم آب" },
                    { 260, 2107.5999999999999, 33.042450000000002, 52.09131, "چاريسه" },
                    { 259, 2013.8, 33.177039999999998, 52.106879999999997, "گل" },
                    { 258, 1876.2, 33.291679999999999, 52.093150000000001, "رنگان" },
                    { 284, 1073.0, 33.342840000000002, 52.99747, "سنگي" },
                    { 341, 960.0, 33.025709999999997, 56.000309999999999, "شهید منتظر قائم" },
                    { 352, 943.39999999999998, 34.591920000000002, 57.864139999999999, "قاسم آباد" },
                    { 343, 927.29999999999995, 33.324489999999997, 56.578299999999999, "كال زرد" },
                    { 425, 0.0, 0.0, 0.0, "حك" },
                    { 424, 0.0, 0.0, 0.0, "رودشور-قم" },
                    { 423, 0.0, 0.0, 0.0, "شوراب قم" },
                    { 422, 0.0, 0.0, 0.0, "قم رود" },
                    { 421, 0.0, 0.0, 0.0, "فولاد" },
                    { 420, 1121.8, 36.655670000000001, 57.418509999999998, "نقاب" },
                    { 419, 0.0, 0.0, 0.0, "آزاد مهر" },
                    { 418, 1040.0999999999999, 35.304879999999997, 52.42754, "بنكوه" },
                    { 417, 0.0, 0.0, 0.0, "آپرين" },
                    { 416, 1616.0999999999999, 29.311229999999998, 60.789819999999999, "جيگولي" },
                    { 415, 1411.2, 29.430900000000001, 60.912799999999997, "زاهدان جديد" },
                    { 426, 0.0, 0.0, 0.0, "جلاير" },
                    { 414, 1398.5, 29.47963, 60.874670000000002, "زاهدان قديم" },
                    { 412, 1555.0, 29.18242, 60.449039999999997, "دومك" },
                    { 411, 1801.0, 29.20147, 60.651350000000001, "كنجانك" },
                    { 410, 698.20000000000005, 29.185739999999999, 59.868549999999999, "نمكزار-زاهدان" },
                    { 409, 939.39999999999998, 29.26868, 59.961579999999998, "كلات" },
                    { 408, 1184.9000000000001, 29.232479999999999, 60.04325, "رود ماهي" },
                    { 407, 692.79999999999995, 28.97429, 58.858460000000001, "فهرج" },
                    { 406, 578.10000000000002, 29.041319999999999, 59.022190000000002, "ميل نادري" },
                    { 405, 483.69999999999999, 29.105399999999999, 59.259529999999998, "شورگز" },
                    { 404, 487.30000000000001, 29.238510000000002, 59.4895, "رودشور-زاهدان" },
                    { 403, 557.60000000000002, 29.286840000000002, 59.698459999999997, "مزارآب" },
                    { 402, 1088.3, 29.033429999999999, 58.351959999999998, "بم" },
                    { 413, 1393.3, 29.168189999999999, 60.23433, "شورو" },
                    { 427, 0.0, 0.0, 0.0, "پري" },
                    { 428, 0.0, 0.0, 0.0, "ملاير" },
                    { 429, 0.0, 0.0, 0.0, "سهاميه" },
                    { 454, 0.0, 0.0, 0.0, "قرتپه" },
                    { 453, 0.0, 0.0, 0.0, "شوشتر" },
                    { 452, 0.0, 0.0, 0.0, "اينچه برون" },
                    { 451, 0.0, 0.0, 0.0, "اروميه" },
                    { 450, 0.0, 0.0, 0.0, "رشكان" },
                    { 449, 0.0, 0.0, 0.0, "شيرين بلاغ" },
                    { 448, 0.0, 0.0, 0.0, "نقده" },
                    { 447, 0.0, 0.0, 0.0, "مهاباد-شمالغرب" },
                    { 446, 0.0, 0.0, 0.0, "قز قلعه" },
                    { 445, 0.0, 0.0, 0.0, "مياندواب" },
                    { 444, 0.0, 0.0, 0.0, "ملكان" },
                    { 443, 0.0, 0.0, 0.0, "شهيد مصطفي اميني" },
                    { 442, 0.0, 0.0, 0.0, "شیر آئین" },
                    { 441, 0.0, 0.0, 0.0, "كندلج" },
                    { 440, 0.0, 0.0, 0.0, "مرغزار" },
                    { 439, 0.0, 0.0, 0.0, "گمنام" },
                    { 438, 0.0, 0.0, 0.0, "آهو" },
                    { 437, 0.0, 0.0, 0.0, "گرمدشت" },
                    { 436, 0.0, 0.0, 0.0, "اضطراري 26" },
                    { 435, 0.0, 0.0, 0.0, "ذوب آهن" },
                    { 434, 0.0, 0.0, 0.0, "شلمچه" },
                    { 433, 0.0, 0.0, 0.0, "گل تپه" },
                    { 432, 0.0, 0.0, 0.0, "اضطراري 26- هرمزگان" },
                    { 431, 0.0, 0.0, 0.0, "موغار" },
                    { 430, 0.0, 0.0, 0.0, "زواره" },
                    { 401, 1876.0, 29.388539999999999, 57.789389999999997, "تهرود" },
                    { 400, 2162.5999999999999, 29.640470000000001, 57.470820000000003, "راين" },
                    { 399, 2182.4000000000001, 29.83389, 57.03875, "حسين آباد" },
                    { 398, 2205.5999999999999, 30.465060000000001, 53.232599999999998, "شهيد آباد" },
                    { 368, 0.0, 0.0, 0.0, "پدكي" },
                    { 367, 1495.0, 35.786020000000001, 59.136690000000002, "نمكي" },
                    { 366, 1676.9000000000001, 35.65361, 59.227589999999999, "حصار جلال" },
                    { 365, 1758.0999999999999, 35.480440000000002, 59.205309999999997, "كامه" },
                    { 364, 1580.2, 35.39425, 59.27469, "رخ" },
                    { 363, 1394.8, 35.274380000000001, 59.308700000000002, "تربت حيدريه" },
                    { 362, 1112.3, 34.742780000000003, 60.002540000000003, "سلامي" },
                    { 361, 1094.5999999999999, 34.873469999999998, 59.79956, "چمن آباد" },
                    { 360, 1197.3, 35.028579999999998, 59.560229999999997, "رشت خوار" },
                    { 359, 1249.5999999999999, 35.153779999999998, 59.378100000000003, "سالار" },
                    { 358, 1201.7, 35.165640000000003, 59.100439999999999, "شادمهر" },
                    { 357, 1027.4000000000001, 35.036580000000001, 58.906059999999997, "نصر آباد" },
                    { 356, 874.5, 34.863320000000002, 58.728490000000001, "كال شور" },
                    { 355, 904.79999999999995, 34.712359999999997, 58.485460000000003, "يونسي" },
                    { 354, 1073.3, 34.612549999999999, 58.219259999999998, "بجستان" },
                    { 353, 1015.6, 34.60528, 58.067520000000002, "آهنگ" },
                    { 229, 1141.9000000000001, 35.61139, 51.305779999999999, "تپه سفيد" },
                    { 351, 847.60000000000002, 34.41527, 57.638370000000002, "جزين" },
                    { 350, 889.60000000000002, 34.309109999999997, 57.352330000000002, "بشرويه" },
                    { 349, 1078.3, 34.219819999999999, 57.198779999999999, "غني آباد" },
                    { 348, 1053.7, 34.06682, 56.985489999999999, "عشق آباد" },
                    { 347, 1022.3, 34.010129999999997, 56.79027, "شير گشت" },
                    { 346, 768.5, 33.814500000000002, 56.790669999999999, "ده شور" },
                    { 345, 672.5, 33.613709999999998, 56.890270000000001, "طبس" },
                    { 344, 694.5, 33.422980000000003, 56.747149999999998, "نمكزار" },
                    { 369, 0.0, 0.0, 0.0, "كچه رود" },
                    { 342, 1041.8, 33.048169999999999, 56.14461, "ريزو" },
                    { 370, 0.0, 0.0, 0.0, "خان محمدچاه" },
                    { 372, 0.0, 0.0, 0.0, "لندي عباس" },
                    { 397, 2158.8000000000002, 30.363420000000001, 53.349710000000002, "ديدگان" },
                    { 396, 2085.4000000000001, 30.25292, 53.424419999999998, "قادر آباد" },
                    { 395, 1932.3, 30.229559999999999, 53.262160000000002, "مرغاب" },
                    { 394, 1890.3, 30.154109999999999, 53.210929999999998, "پاسارگاد" },
                    { 393, 1786.7, 30.105619999999998, 53.094340000000003, "سعادت شهر" },
                    { 392, 1735.8, 30.089510000000001, 52.909790000000001, "سيوند" },
                    { 391, 1614.4000000000001, 29.840630000000001, 52.741280000000003, "مرودشت" },
                    { 390, 1804.3, 29.764050000000001, 52.432209999999998, "شيراز" },
                    { 389, 2125.5, 31.6572, 52.05733, "امين آباد" },
                    { 388, 2235.0999999999999, 31.48865, 52.152520000000003, "ابزد خواست" },
                    { 387, 2198.4000000000001, 31.425260000000002, 52.346110000000003, "شورحستان" },
                    { 386, 2135.4000000000001, 31.31279, 52.485469999999999, "صغاد" },
                    { 385, 2102.6999999999998, 31.17022, 52.580370000000002, "آباده" },
                    { 384, 2045.8, 31.006779999999999, 52.750340000000001, "اقليد" },
                    { 383, 2162.9000000000001, 30.914149999999999, 52.818019999999997, "بيد بيدك" },
                    { 382, 2365.0, 30.834689999999998, 52.99944, "خانه خوره" },
                    { 381, 2555.0, 30.743919999999999, 53.16583, "خرم بيد" },
                    { 380, 2334.6999999999998, 30.585129999999999, 53.195340000000002, "صفاشهر" },
                    { 379, 1995.8, 31.817810000000001, 51.96452, "وشاره" },
                    { 378, 1885.0, 31.976089999999999, 51.832030000000003, "شهرضا" },
                    { 377, 1736.4000000000001, 32.189340000000001, 51.796639999999996, "مهيار" },
                    { 376, 1692.2, 32.35942, 51.686819999999997, "اسد آباد" },
                    { 375, 1676.2, 32.43291, 51.593089999999997, "سيد آباد" },
                    { 374, 0.0, 0.0, 0.0, "چهار صوله" },
                    { 373, 0.0, 0.0, 0.0, "ميرجاوه" },
                    { 371, 0.0, 0.0, 0.0, "بوك" },
                    { 228, 1655.4000000000001, 38.451039999999999, 44.699350000000003, "ميلادي" },
                    { 218, 1335.0999999999999, 38.43676, 45.793689999999998, "مرند" },
                    { 226, 1557.3, 38.33023, 44.8264, "سلماس" },
                    { 81, 1727.0, 34.385190000000001, 50.337510000000002, "راهگرد" },
                    { 80, 1550.0, 34.481090000000002, 50.400449999999999, "سواريان(شهيد محبوبي" },
                    { 79, 1379.3, 34.570659999999997, 50.490409999999997, "باغيك(شهيد نيك نفس" },
                    { 78, 1123.9000000000001, 34.589489999999998, 50.693989999999999, "ساقه" },
                    { 77, 1828.8, 30.094909999999999, 56.917720000000003, "باغين" },
                    { 76, 1770.0999999999999, 30.246459999999999, 57.023299999999999, "كرمان" },
                    { 75, 1768.0999999999999, 30.356190000000002, 56.893050000000002, "سلطاني" },
                    { 74, 1741.7, 30.52412, 56.80283, "پورمند" },
                    { 73, 1707.4000000000001, 30.800699999999999, 56.601730000000003, "زغال شويي" },
                    { 72, 1209.3, 31.257180000000002, 55.718449999999997, "ماني" },
                    { 71, 1088.4000000000001, 31.500080000000001, 55.515279999999997, "دره ريگ" },
                    { 82, 1839.0999999999999, 34.327779999999997, 50.16151, "نانگرد" },
                    { 70, 1272.5999999999999, 32.334240000000001, 55.536079999999998, "چادر ملو" },
                    { 68, 1154.8, 32.331650000000003, 55.2395, "خوشومي" },
                    { 67, 1038.9000000000001, 32.332839999999997, 55.049860000000002, "دره انجير" },
                    { 66, 1016.8, 32.454079999999998, 54.908810000000003, "ني باد" },
                    { 65, 1064.3, 32.624850000000002, 54.739629999999998, "ريگ" },
                    { 64, 1147.2, 32.712069999999997, 54.6023, "زرين" },
                    { 63, 1107.8, 32.630580000000002, 54.402470000000001, "توت" },
                    { 62, 1044.0999999999999, 32.554450000000003, 54.205199999999998, "چغا سرخ" },
                    { 61, 1020.1, 32.47654, 54.011029999999998, "گلدانه" },
                    { 60, 1140.8, 33.162289999999999, 56.336509999999997, "عباس آباد" },
                    { 59, 789.0, 33.06073, 56.818150000000003, "معدن زغال سنگ پرواده" },
                    { 58, 1015.1, 34.567779999999999, 60.185890000000001, "خواف" },
                    { 69, 1153.8, 32.394910000000003, 55.398249999999997, "ساغند" },
                    { 83, 1714.5999999999999, 34.203090000000003, 50.022379999999998, "مشك آباد" },
                    { 84, 1698.2, 34.109610000000004, 49.861109999999996, "ملك آباد" },
                    { 85, 1802.4000000000001, 34.071420000000003, 49.702060000000003, "اراك" },
                    { 110, 93.0, 32.204859999999996, 48.2898, "شوش" },
                    { 109, 115.3, 32.337150000000001, 48.280659999999997, "سبز آب" },
                    { 108, 158.80000000000001, 32.456629999999997, 48.351410000000001, "انديمشك" },
                    { 107, 236.90000000000001, 32.560279999999999, 48.297139999999999, "دو كوهه" },
                    { 106, 418.10000000000002, 32.645350000000001, 48.312139999999999, "گل محك" },
                    { 105, 457.89999999999998, 32.71414, 48.368670000000002, "بالارود" },
                    { 104, 459.5, 32.788400000000003, 48.510919999999999, "مازو" },
                    { 103, 479.10000000000002, 32.783000000000001, 48.654539999999997, "شهبازان" },
                    { 102, 507.80000000000001, 32.82405, 48.766359999999999, "تله زنگ" },
                    { 101, 560.79999999999995, 32.944479999999999, 48.745750000000001, "تنگ پنج" },
                    { 100, 680.89999999999998, 33.043799999999997, 48.671379999999999, "تنگ هفت" },
                    { 99, 782.0, 33.135330000000003, 48.643279999999997, "كشور" },
                    { 98, 871.0, 33.166339999999998, 48.763330000000003, "چمسنگر" },
                    { 97, 1086.9000000000001, 33.223179999999999, 48.883310000000002, "سپيد دشت" },
                    { 96, 1247.0, 33.330559999999998, 48.87715, "بيشه" },
                    { 95, 1387.3, 33.42118, 48.996020000000001, "قارون" },
                    { 94, 1478.9000000000001, 33.485379999999999, 49.062989999999999, "درود" },
                    { 93, 1629.3, 33.463999999999999, 49.173879999999997, "رودك" },
                    { 92, 1768.2, 33.433390000000003, 49.307989999999997, "دربند" },
                    { 91, 1890.2, 33.454360000000001, 49.452309999999997, "ازنا" },
                    { 90, 1953.8, 33.58905, 49.520600000000002, "مومن اباد" },
                    { 89, 2093.5999999999999, 33.679740000000002, 49.457830000000001, "سميه" },
                    { 88, 2197.1999999999998, 33.798229999999997, 49.421570000000003, "نور آباد" },
                    { 87, 1923.7, 33.941429999999997, 49.418219999999998, "شازند" },
                    { 86, 1985.4000000000001, 34.015929999999997, 49.560740000000003, "سمنگان)شهيدهاشمي ن‍زاد)" },
                    { 57, 981.29999999999995, 36.304690000000001, 59.624839999999999, "مشهد" },
                    { 111, 89.0, 32.073509999999999, 48.337980000000002, "هفت تپه" },
                    { 56, 1328.0, 36.400069999999999, 55.001220000000004, "شاهرود" },
                    { 54, 34.200000000000003, 27.12518, 56.043509999999998, "پايانه نفتي" },
                    { 24, 2144.4000000000001, 35.824249999999999, 52.917200000000001, "گدوك" },
                    { 23, 1958.3, 35.749650000000003, 52.775030000000001, "فيروزكوه" },
                    { 22, 1786.4000000000001, 35.662430000000001, 52.706200000000003, "مهاباد" },
                    { 21, 1611.8, 35.572119999999998, 52.60313, "زرين دشت" },
                    { 20, 1483.4000000000001, 35.520560000000003, 52.501130000000003, "سيمين دشت" },
                    { 19, 1279.7, 35.426630000000003, 52.428379999999997, "كبوتر دره" },
                    { 18, 874.29999999999995, 35.235489999999999, 52.308369999999996, "گرمسار" },
                    { 17, 833.5, 35.163969999999999, 52.038870000000003, "كوير" },
                    { 16, 865.39999999999998, 35.205219999999997, 51.802019999999999, "ابردژ" },
                    { 15, 936.89999999999998, 35.289839999999998, 51.721069999999997, "پيشوا" },
                    { 14, 1009.8, 35.464449999999999, 51.53575, "بهرام" },
                    { 25, 1755.0, 35.880890000000001, 52.968470000000003, "دو گل" },
                    { 13, 1076.8, 35.580750000000002, 51.424810000000001, "ري" },
                    { 11, 1347.2, 38.286879999999996, 45.119190000000003, "چشمه كنان" },
                    { 10, 751.70000000000005, 38.93777, 45.630719999999997, "جلفا" },
                    { 9, 1651.3, 38.336779999999997, 45.883270000000003, "سيوان" },
                    { 8, 1383.0999999999999, 38.071939999999998, 46.227809999999998, "تبريز" },
                    { 7, 1317.0999999999999, 37.76737, 45.876289999999997, "آذر شهر" },
                    { 6, 1336.9000000000001, 37.434339999999999, 45.978900000000003, "ديزه رود" },
                    { 5, 1837.9000000000001, 37.292160000000003, 46.636130000000001, "خراجو" },
                    { 4, 1552.3, 37.381390000000003, 47.112369999999999, "خراسانك" },
                    { 3, 1407.5999999999999, 36.031669999999998, 49.54204, "سياه باغ" },
                    { 2, 1326.8, 36.201880000000003, 50.19285, "كهندژ" },
                    { 1, 1268.0, 35.949280000000002, 50.668939999999999, "هشتگرد" },
                    { 12, 2069.0, 38.493020000000001, 44.344169999999998, "رازي" },
                    { 26, 1525.5999999999999, 35.90663, 52.98574, "ورسك" },
                    { 27, 1203.4000000000001, 35.954360000000001, 53.005800000000001, "سرخ آباد" },
                    { 28, 926.79999999999995, 36.018700000000003, 53.044550000000001, "سواد كوه" },
                    { 53, 23.399999999999999, 27.211670000000002, 56.25506, "بند رعباس" },
                    { 52, 1659.5999999999999, 28.78791, 55.515039999999999, "قره تپه" },
                    { 51, 1709.5, 29.140080000000001, 55.423900000000003, "گل گهر" },
                    { 50, 1759.8, 29.089130000000001, 55.332000000000001, "معدن گل گهر" },
                    { 49, 1915.7, 29.77636, 55.584949999999999, "چوران" },
                    { 48, 2028.5999999999999, 30.079070000000002, 55.55312, "ميمند" },
                    { 47, 1597.9000000000001, 30.491150000000001, 55.606299999999997, "احمد آباد" },
                    { 46, 1747.3, 32.314619999999998, 51.412799999999997, "حسن آباد" },
                    { 45, 100.59999999999999, 36.855539999999998, 54.420259999999999, "گرگان" },
                    { 44, 33.100000000000001, 36.886150000000001, 54.219949999999997, "سبز دشت" },
                    { 43, 39.299999999999997, 36.893259999999998, 54.065770000000001, "بندر تركمن" },
                    { 42, 35.299999999999997, 36.77469, 53.950650000000003, "بند گز" },
                    { 41, 18.600000000000001, 36.747059999999998, 53.812910000000002, "گلوگاه" },
                    { 40, 20.199999999999999, 36.726970000000001, 53.724589999999999, "تير تاش" },
                    { 39, 20.0, 36.702590000000001, 53.540199999999999, "بهشهر" },
                    { 38, 37.299999999999997, 36.847670000000001, 53.357509999999998, "بندر امير آباد" },
                    { 37, 18.699999999999999, 36.687370000000001, 53.413209999999999, "رستم كلا" },
                    { 36, 66.200000000000003, 36.65625, 53.289279999999998, "نكا" },
                    { 35, 61.700000000000003, 36.61016, 53.209960000000002, "شهيد نوبخت" },
                    { 34, 77.200000000000003, 36.552770000000002, 53.058729999999997, "ساري" },
                    { 33, 57.799999999999997, 36.481900000000003, 52.89817, "گوني بافي" },
                    { 32, 76.0, 36.462739999999997, 52.862839999999998, "قائم شهر" },
                    { 31, 258.60000000000002, 36.294420000000002, 52.888159999999999, "شير گاه" },
                    { 30, 445.10000000000002, 36.177050000000001, 52.971179999999997, "زير اب" },
                    { 29, 592.0, 36.11544, 53.056040000000003, "پل سفيد" },
                    { 55, 40.899999999999999, 27.107340000000001, 56.050269999999998, "اسكله" },
                    { 112, 53.899999999999999, 31.96988, 48.44706, "ميان آب" },
                    { 113, 40.299999999999997, 31.874179999999999, 48.560220000000001, "آهو دشت" },
                    { 114, 36.600000000000001, 31.687799999999999, 48.668559999999999, "بامدژ" },
                    { 196, 24.300000000000001, 30.54241, 49.068460000000002, "سربندر" },
                    { 195, 16.0, 30.753450000000001, 48.968690000000002, "گرگر-آذربایچان" },
                    { 194, 24.899999999999999, 31.06457, 48.821750000000002, "خسروي" },
                    { 193, 26.100000000000001, 31.23151, 48.740810000000003, "مياندشت" },
                    { 192, 20.600000000000001, 31.320350000000001, 48.698050000000002, "كارون" },
                    { 191, 17.399999999999999, 30.447800000000001, 48.162280000000003, "خرمشهر" },
                    { 190, 23.300000000000001, 30.80809, 48.185549999999999, "حسينيه" },
                    { 189, 18.5, 31.131329999999998, 48.304319999999997, "شهيد حميد موسوي" },
                    { 188, 33.899999999999999, 31.290320000000001, 48.583120000000001, "قدس" },
                    { 187, 38.0, 31.326329999999999, 48.664090000000002, "اهواز" },
                    { 186, 1144.0999999999999, 37.391930000000002, 47.575389999999999, "قزانقو" },
                    { 197, 16.699999999999999, 30.559370000000001, 49.168419999999998, "بندر ماهشهر" },
                    { 185, 1093.5, 37.382739999999998, 47.739420000000003, "ميانه" },
                    { 183, 1149.3, 37.140099999999997, 47.793640000000003, "رجين" },
                    { 182, 1229.5, 37.071669999999997, 47.964199999999998, "سر چم" },
                    { 181, 1329.4000000000001, 36.963979999999999, 48.107120000000002, "آذر پي" },
                    { 180, 1439.5999999999999, 36.82602, 48.19717, "نيك پي" },
                    { 179, 1556.7, 36.729140000000001, 48.3367, "خرم پي" },
                    { 178, 1649.5, 36.661000000000001, 48.481529999999999, "زنجان" },
                    { 177, 1728.4000000000001, 36.599829999999997, 48.647640000000003, "بناب" },
                    { 176, 1805.4000000000001, 36.500900000000001, 48.79522, "سلطانيه" },
                    { 175, 1824.5999999999999, 36.386589999999998, 48.964530000000003, "پيرزاغه" },
                    { 174, 1718.4000000000001, 36.300330000000002, 49.10962, "زرين دژ" },
                    { 173, 1619.8, 36.18685, 49.23986, "خرم دره" },
                    { 184, 1104.8, 37.298859999999998, 47.808950000000003, "پل دختر" },
                    { 198, 21.600000000000001, 30.434200000000001, 49.078650000000003, "بندر امام خميني" },
                    { 199, 1411.8, 35.539839999999998, 53.763249999999999, "آبگرم" },
                    { 200, 1248.5999999999999, 35.573819999999998, 53.602699999999999, "مياندره" },
                    { 225, 1478.9000000000001, 38.302199999999999, 44.941310000000001, "شهيد برزگر منافي" },
                    { 224, 1325.0999999999999, 38.263860000000001, 45.342239999999997, "تسوج قلعه" },
                    { 223, 1316.3, 38.16769, 45.48556, "شرفخانه" },
                    { 222, 1357.4000000000001, 38.143450000000001, 45.749470000000002, "ديزج خليل" },
                    { 221, 1005.1, 38.831629999999997, 45.633229999999998, "گرگر" },
                    { 220, 1379.0999999999999, 38.730440000000002, 45.623130000000003, "زال" },
                    { 219, 1491.9000000000001, 38.626080000000002, 45.693330000000003, "هرزند" },
                    { 455, 0.0, 0.0, 0.0, "یامپی" },
                    { 217, 1829.0, 38.349730000000001, 45.800249999999998, "پيام" },
                    { 216, 1419.9000000000001, 38.272970000000001, 46.002719999999997, "صوفيان" },
                    { 215, 1368.3, 38.197180000000003, 46.097839999999998, "سهلان" },
                    { 214, 1355.2, 38.01126, 46.083359999999999, "عباسي" },
                    { 213, 1337.8, 37.905970000000003, 45.940640000000002, "زارعي" },
                    { 212, 1463.7, 37.564630000000001, 45.79627, "پرويز بهمن" },
                    { 211, 1340.2, 37.501640000000002, 45.882199999999997, "عجب شير" },
                    { 210, 1387.5, 37.372570000000003, 46.123480000000001, "آذربناب" },
                    { 209, 1463.2, 37.379539999999999, 46.234250000000003, "مراغه" },
                    { 208, 1635.9000000000001, 37.335149999999999, 46.353099999999998, "خواجه نصير" },
                    { 207, 1735.7, 37.306829999999998, 46.531910000000003, "سهند" },
                    { 206, 1873.2, 37.306809999999999, 46.709229999999998, "سراجو" },
                    { 205, 1752.2, 37.320680000000003, 46.773969999999998, "آتش بغ" },
                    { 204, 1639.9000000000001, 37.319580000000002, 46.879179999999998, "هشترود" },
                    { 203, 1581.5, 37.373449999999998, 46.985329999999998, "صائب" },
                    { 202, 1428.2, 37.351660000000003, 47.264380000000003, "بابك" },
                    { 201, 1299.5999999999999, 37.346290000000003, 47.425600000000003, "شيخ صفي" },
                    { 172, 1291.3, 36.071910000000003, 49.703800000000001, "تاكستان" },
                    { 171, 1282.0, 36.162219999999998, 49.840739999999997, "سياه چشمه" },
                    { 170, 1307.5, 36.243560000000002, 50.007579999999997, "قزوين" },
                    { 169, 1286.0999999999999, 36.11074, 50.356520000000003, "زياران" },
                    { 139, 1137.3, 36.524039999999999, 57.845619999999997, "بيهق" },
                    { 138, 1198.5999999999999, 36.45064, 58.080869999999997, "سبزوار" },
                    { 137, 1252.9000000000001, 36.373350000000002, 58.326349999999998, "فردوس" },
                    { 136, 1177.8, 36.28443, 58.564500000000002, "عطار" },
                    { 135, 1186.0, 36.194670000000002, 58.785150000000002, "نيشابور" },
                    { 134, 1248.0, 36.085479999999997, 58.991720000000001, "خيام" },
                    { 133, 1304.0, 35.969059999999999, 59.211680000000001, "كاشمر" },
                    { 132, 1394.0999999999999, 35.946280000000002, 59.384520000000002, "ابومسلم" },
                    { 131, 1280.9000000000001, 35.957569999999997, 59.575670000000002, "تربت" },
                    { 130, 1134.0, 36.00056, 59.763249999999999, "فريمان" },
                    { 129, 1001.7, 36.148809999999997, 59.73171, "سلام" },
                    { 128, 1059.9000000000001, 36.030079999999998, 59.820749999999997, "شهيد مطهري" },
                    { 127, 908.70000000000005, 36.03322, 60.067219999999999, "آزادگان" },
                    { 126, 822.39999999999998, 36.078580000000002, 60.232889999999998, "رباط ماهي" },
                    { 125, 714.10000000000002, 36.086880000000001, 60.46293, "مختوم قلي" },
                    { 124, 887.79999999999995, 36.130159999999997, 60.611629999999998, "مرزداران" },
                    { 123, 613.60000000000002, 36.183259999999997, 60.81935, "رباط شرف" },
                    { 122, 377.5, 36.320010000000003, 60.92315, "گنبدلي" },
                    { 121, 1513.4000000000001, 36.086190000000002, 49.377769999999998, "قروه" },
                    { 120, 880.60000000000002, 35.216000000000001, 52.491300000000003, "ياتري" },
                    { 119, 849.0, 35.248899999999999, 52.725079999999998, "ده نمك" },
                    { 118, 1075.3, 35.429110000000001, 53.278449999999999, "بيابانك" },
                    { 117, 1115.8, 35.552480000000003, 53.404910000000001, "سمنان" },
                    { 116, 39.299999999999997, 31.472000000000001, 48.690530000000003, "نظاميه" },
                    { 115, 38.5, 31.61253, 48.69303, "خاور" },
                    { 140, 1117.5999999999999, 36.589829999999999, 57.632989999999999, "اسفراين" },
                    { 227, 1505.5, 38.451369999999997, 44.796509999999998, "بابكان" },
                    { 141, 1105.8, 36.725409999999997, 57.174030000000002, "جوين" },
                    { 143, 991.79999999999995, 36.741660000000003, 56.748150000000003, "آزادور" },
                    { 168, 1250.0, 36.032130000000002, 50.510420000000003, "آبيك" },
                    { 167, 1318.5, 35.868740000000003, 50.826630000000002, "كردان" },
                    { 166, 1333.7, 35.77955, 50.989089999999997, "كرج" },
                    { 165, 1212.0, 35.71199, 51.146680000000003, "ملكي" },
                    { 164, 1209.0, 35.689450000000001, 51.209569999999999, "لشكري" },
                    { 163, 1201.5, 35.67803, 51.255479999999999, "نيك پسندي" },
                    { 162, 1138.9000000000001, 35.657060000000001, 51.397419999999997, "تهران" },
                    { 161, 956.60000000000002, 35.335450000000002, 51.644269999999999, "ورامين" },
                    { 160, 864.79999999999995, 35.270949999999999, 52.87894, "سرخ دشت" },
                    { 159, 1022.6, 35.328319999999998, 53.08222, "لاهور" },
                    { 158, 1542.8, 35.600569999999998, 53.859690000000001, "گرداب" },
                    { 157, 1584.9000000000001, 35.660809999999998, 54.075960000000002, "هفتخوان" },
                    { 156, 1459.2, 35.752719999999997, 54.138869999999997, "لارستان" },
                    { 155, 1188.9000000000001, 35.915950000000002, 54.205410000000001, "امروان" },
                    { 154, 1117.0, 36.041780000000003, 54.290300000000002, "سرخده" },
                    { 153, 1149.0999999999999, 36.150449999999999, 54.370199999999997, "دامغان" },
                    { 152, 1091.3, 36.215269999999997, 54.610529999999997, "زرين" },
                    { 151, 1166.9000000000001, 36.283320000000003, 54.846820000000001, "كلاتخوان" },
                    { 150, 1335.4000000000001, 36.457430000000002, 55.212530000000001, "بسطام" },
                    { 149, 1213.0999999999999, 36.475810000000003, 55.428829999999998, "شيرين چشمه" },
                    { 148, 1071.2, 36.513860000000001, 55.6173, "گيلان" },
                    { 147, 1020.5, 36.559489999999997, 55.83764, "بكران" },
                    { 146, 1023.1, 36.630229999999997, 56.070889999999999, "جهان آباد" },
                    { 145, 903.20000000000005, 36.667050000000003, 56.283859999999997, "ابريشم" },
                    { 144, 934.20000000000005, 36.703859999999999, 56.527189999999997, "جاجرم" },
                    { 142, 1047.3, 36.758690000000001, 56.962879999999998, "سنخواست" },
                    { 456, 0.0, 0.0, 0.0, "پتروشیمی" }
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
                name: "IX_Missions_StationOneId",
                table: "Missions",
                column: "StationOneId");

            migrationBuilder.CreateIndex(
                name: "IX_Missions_StationTwoId",
                table: "Missions",
                column: "StationTwoId");

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
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "Stations");
        }
    }
}
