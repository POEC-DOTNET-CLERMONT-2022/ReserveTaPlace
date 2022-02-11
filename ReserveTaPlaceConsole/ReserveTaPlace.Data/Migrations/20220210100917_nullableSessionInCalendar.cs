using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveTaPlace.Data.Migrations
{
    public partial class nullableSessionInCalendar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calendar_Session_SessionId",
                table: "Calendar");

            migrationBuilder.DropIndex(
                name: "IX_Calendar_SessionId",
                table: "Calendar");

            migrationBuilder.AlterColumn<Guid>(
                name: "SessionId",
                table: "Calendar",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calendar_Session_SessionId",
                table: "Calendar");

            migrationBuilder.DropIndex(
                name: "IX_Calendar_SessionId",
                table: "Calendar");

            migrationBuilder.AlterColumn<Guid>(
                name: "SessionId",
                table: "Calendar",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Calendar_SessionId",
                table: "Calendar",
                column: "SessionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Calendar_Session_SessionId",
                table: "Calendar",
                column: "SessionId",
                principalTable: "Session",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
