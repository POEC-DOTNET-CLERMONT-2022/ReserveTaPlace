using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveTaPlace.Data.Migrations
{
    public partial class UpdatePlannigEntitySheduleEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Session_PlanningEntity_PlanningId",
                table: "Session");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlanningEntity",
                table: "PlanningEntity");

            migrationBuilder.RenameTable(
                name: "PlanningEntity",
                newName: "Planning");

            migrationBuilder.RenameColumn(
                name: "Start",
                table: "Schedule",
                newName: "HourStart");

            migrationBuilder.RenameColumn(
                name: "End",
                table: "Schedule",
                newName: "HourEnd");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Planning",
                table: "Planning",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Session_Planning_PlanningId",
                table: "Session",
                column: "PlanningId",
                principalTable: "Planning",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Session_Planning_PlanningId",
                table: "Session");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Planning",
                table: "Planning");

            migrationBuilder.RenameTable(
                name: "Planning",
                newName: "PlanningEntity");

            migrationBuilder.RenameColumn(
                name: "HourStart",
                table: "Schedule",
                newName: "Start");

            migrationBuilder.RenameColumn(
                name: "HourEnd",
                table: "Schedule",
                newName: "End");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlanningEntity",
                table: "PlanningEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Session_PlanningEntity_PlanningId",
                table: "Session",
                column: "PlanningId",
                principalTable: "PlanningEntity",
                principalColumn: "Id");
        }
    }
}
