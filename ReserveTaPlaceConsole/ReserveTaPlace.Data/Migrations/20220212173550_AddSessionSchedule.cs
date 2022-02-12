using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveTaPlace.Data.Migrations
{
    public partial class AddSessionSchedule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Session_SessionId",
                table: "Schedule");

            migrationBuilder.DropIndex(
                name: "IX_Schedule_SessionId",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "Schedule");

            migrationBuilder.CreateTable(
                name: "SessionSchedule",
                columns: table => new
                {
                    SchedulesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SessionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionSchedule", x => new { x.SchedulesId, x.SessionsId });
                    table.ForeignKey(
                        name: "FK_SessionSchedule_Schedule_SchedulesId",
                        column: x => x.SchedulesId,
                        principalTable: "Schedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SessionSchedule_Session_SessionsId",
                        column: x => x.SessionsId,
                        principalTable: "Session",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SessionSchedule_SessionsId",
                table: "SessionSchedule",
                column: "SessionsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SessionSchedule");

            migrationBuilder.AddColumn<Guid>(
                name: "SessionId",
                table: "Schedule",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_SessionId",
                table: "Schedule",
                column: "SessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Session_SessionId",
                table: "Schedule",
                column: "SessionId",
                principalTable: "Session",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
