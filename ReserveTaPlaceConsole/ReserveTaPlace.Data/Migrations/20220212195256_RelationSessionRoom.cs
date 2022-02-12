using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveTaPlace.Data.Migrations
{
    public partial class RelationSessionRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Session_Room_RoomId",
                table: "Session");

            migrationBuilder.DropIndex(
                name: "IX_Session_RoomId",
                table: "Session");

            migrationBuilder.AddColumn<Guid>(
                name: "RoomEntityId",
                table: "Session",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Session_RoomEntityId",
                table: "Session",
                column: "RoomEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Session_Room_RoomEntityId",
                table: "Session",
                column: "RoomEntityId",
                principalTable: "Room",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Session_Room_RoomEntityId",
                table: "Session");

            migrationBuilder.DropIndex(
                name: "IX_Session_RoomEntityId",
                table: "Session");

            migrationBuilder.DropColumn(
                name: "RoomEntityId",
                table: "Session");

            migrationBuilder.CreateIndex(
                name: "IX_Session_RoomId",
                table: "Session",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Session_Room_RoomId",
                table: "Session",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id");
        }
    }
}
