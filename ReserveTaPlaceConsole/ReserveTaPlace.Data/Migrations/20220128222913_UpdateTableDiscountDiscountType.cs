using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveTaPlace.Data.Migrations
{
    public partial class UpdateTableDiscountDiscountType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "DiscountType");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "DiscountType");

            migrationBuilder.AddColumn<float>(
                name: "Amount",
                table: "Discount",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "Rate",
                table: "Discount",
                type: "smallint",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Discount");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Discount");

            migrationBuilder.AddColumn<float>(
                name: "Amount",
                table: "DiscountType",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<short>(
                name: "Rate",
                table: "DiscountType",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);
        }
    }
}
