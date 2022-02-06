using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveTaPlace.Data.Migrations
{
    public partial class addSessionDateCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Date");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Date",
                newName: "SessionDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SessionDate",
                table: "Date",
                newName: "StartDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Date",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
