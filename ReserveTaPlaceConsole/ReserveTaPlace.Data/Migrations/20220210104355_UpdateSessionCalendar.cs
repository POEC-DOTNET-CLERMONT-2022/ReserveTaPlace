using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveTaPlace.Data.Migrations
{
    public partial class UpdateSessionCalendar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calendar_Session_SessionId",
                table: "Calendar");

            migrationBuilder.DropIndex(
                name: "IX_Calendar_SessionId",
                table: "Calendar");

            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "Calendar");

            migrationBuilder.AddColumn<Guid>(
                name: "CalendarId",
                table: "Session",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Session_CalendarId",
                table: "Session",
                column: "CalendarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Session_Calendar_CalendarId",
                table: "Session",
                column: "CalendarId",
                principalTable: "Calendar",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Session_Calendar_CalendarId",
                table: "Session");

            migrationBuilder.DropIndex(
                name: "IX_Session_CalendarId",
                table: "Session");

            migrationBuilder.DropColumn(
                name: "CalendarId",
                table: "Session");

            migrationBuilder.AddColumn<Guid>(
                name: "SessionId",
                table: "Calendar",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Calendar_SessionId",
                table: "Calendar",
                column: "SessionId",
                unique: true,
                filter: "[SessionId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Calendar_Session_SessionId",
                table: "Calendar",
                column: "SessionId",
                principalTable: "Session",
                principalColumn: "Id");
        }
    }
}
