using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveTaPlace.Data.Migrations
{
    public partial class AddPlannigEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PlanningId",
                table: "Session",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PlanningEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanningEntity", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Session_PlanningId",
                table: "Session",
                column: "PlanningId");

            migrationBuilder.AddForeignKey(
                name: "FK_Session_PlanningEntity_PlanningId",
                table: "Session",
                column: "PlanningId",
                principalTable: "PlanningEntity",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Session_PlanningEntity_PlanningId",
                table: "Session");

            migrationBuilder.DropTable(
                name: "PlanningEntity");

            migrationBuilder.DropIndex(
                name: "IX_Session_PlanningId",
                table: "Session");

            migrationBuilder.DropColumn(
                name: "PlanningId",
                table: "Session");
        }
    }
}
