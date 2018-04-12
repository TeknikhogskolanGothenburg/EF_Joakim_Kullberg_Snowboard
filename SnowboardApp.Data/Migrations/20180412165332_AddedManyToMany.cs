using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SnowboardApp.Data.Migrations
{
    public partial class AddedManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Athletes_Contests_ContestId",
                table: "Athletes");

            migrationBuilder.DropIndex(
                name: "IX_Athletes_ContestId",
                table: "Athletes");

            migrationBuilder.DropColumn(
                name: "ContestId",
                table: "Athletes");

            migrationBuilder.AddColumn<int>(
                name: "AthleteId",
                table: "HomeResorts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AthleteId",
                table: "HomeResorts");

            migrationBuilder.AddColumn<int>(
                name: "ContestId",
                table: "Athletes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Athletes_ContestId",
                table: "Athletes",
                column: "ContestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Athletes_Contests_ContestId",
                table: "Athletes",
                column: "ContestId",
                principalTable: "Contests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
