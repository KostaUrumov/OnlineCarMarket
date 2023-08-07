using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineCarMarket_Infastructure.Migrations
{
    public partial class seedEnginesss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AciveVignette",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "IsRegistered",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "RightHanded",
                table: "Cars");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AciveVignette",
                table: "Cars",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRegistered",
                table: "Cars",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RightHanded",
                table: "Cars",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
