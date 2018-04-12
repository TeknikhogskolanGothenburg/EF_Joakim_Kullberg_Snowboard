using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SnowboardApp.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EndDate = table.Column<DateTime>(nullable: false),
                    EventLocation = table.Column<string>(nullable: true),
                    EventName = table.Column<string>(nullable: true),
                    FirstPlace = table.Column<string>(nullable: true),
                    SecondPlace = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    ThirdPlace = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HomeResorts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Country = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    VerticalMeters = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeResorts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Athletes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Age = table.Column<int>(nullable: false),
                    BirthCountry = table.Column<string>(nullable: true),
                    ContestId = table.Column<int>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Athletes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Athletes_Contests_ContestId",
                        column: x => x.ContestId,
                        principalTable: "Contests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AthleteContest",
                columns: table => new
                {
                    AthleteId = table.Column<int>(nullable: false),
                    ContestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AthleteContest", x => new { x.AthleteId, x.ContestId });
                    table.ForeignKey(
                        name: "FK_AthleteContest_Athletes_AthleteId",
                        column: x => x.AthleteId,
                        principalTable: "Athletes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AthleteContest_Contests_ContestId",
                        column: x => x.ContestId,
                        principalTable: "Contests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AthleteHomeResort",
                columns: table => new
                {
                    AthleteId = table.Column<int>(nullable: false),
                    HomeResortId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AthleteHomeResort", x => new { x.AthleteId, x.HomeResortId });
                    table.ForeignKey(
                        name: "FK_AthleteHomeResort_Athletes_AthleteId",
                        column: x => x.AthleteId,
                        principalTable: "Athletes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AthleteHomeResort_HomeResorts_HomeResortId",
                        column: x => x.HomeResortId,
                        principalTable: "HomeResorts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Snowboards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AthelteId = table.Column<int>(nullable: false),
                    AthleteId = table.Column<int>(nullable: true),
                    Brand = table.Column<string>(nullable: true),
                    Length = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Snowboards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Snowboards_Athletes_AthleteId",
                        column: x => x.AthleteId,
                        principalTable: "Athletes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AthleteContest_ContestId",
                table: "AthleteContest",
                column: "ContestId");

            migrationBuilder.CreateIndex(
                name: "IX_AthleteHomeResort_HomeResortId",
                table: "AthleteHomeResort",
                column: "HomeResortId");

            migrationBuilder.CreateIndex(
                name: "IX_Athletes_ContestId",
                table: "Athletes",
                column: "ContestId");

            migrationBuilder.CreateIndex(
                name: "IX_Snowboards_AthleteId",
                table: "Snowboards",
                column: "AthleteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AthleteContest");

            migrationBuilder.DropTable(
                name: "AthleteHomeResort");

            migrationBuilder.DropTable(
                name: "Snowboards");

            migrationBuilder.DropTable(
                name: "HomeResorts");

            migrationBuilder.DropTable(
                name: "Athletes");

            migrationBuilder.DropTable(
                name: "Contests");
        }
    }
}
