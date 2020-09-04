using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DealerInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    Address1 = table.Column<string>(nullable: false),
                    Address2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: false),
                    PostCode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DealerInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DealerContacts",
                columns: table => new
                {
                    DealerContactId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    Designation = table.Column<string>(maxLength: 250, nullable: true),
                    Email = table.Column<string>(nullable: false),
                    PhoneNumberStr = table.Column<string>(nullable: false),
                    DealerInfoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DealerContacts", x => x.DealerContactId);
                    table.ForeignKey(
                        name: "FK_DealerContacts_DealerInfos_DealerInfoId",
                        column: x => x.DealerInfoId,
                        principalTable: "DealerInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DealerOperatingHours",
                columns: table => new
                {
                    DealerOperatingHourId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayOfTheWeek = table.Column<int>(nullable: false),
                    OpeningTime = table.Column<TimeSpan>(nullable: false),
                    ClosingTime = table.Column<TimeSpan>(nullable: false),
                    DealerInfoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DealerOperatingHours", x => x.DealerOperatingHourId);
                    table.ForeignKey(
                        name: "FK_DealerOperatingHours_DealerInfos_DealerInfoId",
                        column: x => x.DealerInfoId,
                        principalTable: "DealerInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DealerContacts_DealerInfoId",
                table: "DealerContacts",
                column: "DealerInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_DealerOperatingHours_DealerInfoId",
                table: "DealerOperatingHours",
                column: "DealerInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DealerContacts");

            migrationBuilder.DropTable(
                name: "DealerOperatingHours");

            migrationBuilder.DropTable(
                name: "DealerInfos");
        }
    }
}
