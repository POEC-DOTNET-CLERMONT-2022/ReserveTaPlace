using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveTaPlace.Data.Migrations
{
    public partial class addScheduleSeat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Session_SessionId",
                table: "Schedule");

            migrationBuilder.DropTable(
                name: "Date");

            migrationBuilder.DropTable(
                name: "SessionSeat");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Session",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<Guid>(
                name: "SessionId",
                table: "Schedule",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ScheduleSeat",
                columns: table => new
                {
                    ScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SeatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleSeat", x => new { x.ScheduleId, x.SeatId });
                    table.ForeignKey(
                        name: "FK_ScheduleSeat_Schedule_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedule",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ScheduleSeat_Seat_SeatId",
                        column: x => x.SeatId,
                        principalTable: "Seat",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleSeat_SeatId",
                table: "ScheduleSeat",
                column: "SeatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Session_SessionId",
                table: "Schedule",
                column: "SessionId",
                principalTable: "Session",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Session_SessionId",
                table: "Schedule");

            migrationBuilder.DropTable(
                name: "ScheduleSeat");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Session");

            migrationBuilder.AlterColumn<Guid>(
                name: "SessionId",
                table: "Schedule",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateTable(
                name: "Date",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SessionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Date", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Date_Session_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Session",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SessionSeat",
                columns: table => new
                {
                    SessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SeatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionSeat", x => new { x.SessionId, x.SeatId });
                    table.ForeignKey(
                        name: "FK_SessionSeat_Seat_SeatId",
                        column: x => x.SeatId,
                        principalTable: "Seat",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SessionSeat_Session_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Session",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Date_SessionId",
                table: "Date",
                column: "SessionId",
                unique: true,
                filter: "[SessionId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SessionSeat_SeatId",
                table: "SessionSeat",
                column: "SeatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Session_SessionId",
                table: "Schedule",
                column: "SessionId",
                principalTable: "Session",
                principalColumn: "Id");
        }
    }
}
