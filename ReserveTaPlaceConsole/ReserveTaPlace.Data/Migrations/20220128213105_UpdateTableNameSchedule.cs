using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveTaPlace.Data.Migrations
{
    public partial class UpdateTableNameSchedule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SessionHour_Session_SessionEntityId",
                table: "SessionHour");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SessionHour",
                table: "SessionHour");

            migrationBuilder.RenameTable(
                name: "SessionHour",
                newName: "Schedule");

            migrationBuilder.RenameIndex(
                name: "IX_SessionHour_SessionEntityId",
                table: "Schedule",
                newName: "IX_Schedule_SessionEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schedule",
                table: "Schedule",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Session_SessionEntityId",
                table: "Schedule",
                column: "SessionEntityId",
                principalTable: "Session",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Session_SessionEntityId",
                table: "Schedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schedule",
                table: "Schedule");

            migrationBuilder.RenameTable(
                name: "Schedule",
                newName: "SessionHour");

            migrationBuilder.RenameIndex(
                name: "IX_Schedule_SessionEntityId",
                table: "SessionHour",
                newName: "IX_SessionHour_SessionEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SessionHour",
                table: "SessionHour",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SessionHour_Session_SessionEntityId",
                table: "SessionHour",
                column: "SessionEntityId",
                principalTable: "Session",
                principalColumn: "Id");
        }
    }
}
