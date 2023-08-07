using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineCarMarket_Infastructure.Migrations
{
    public partial class seedEngines : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Engines",
                columns: new[] { "Id", "EngineTypeId", "FuelConsumption", "HorsePower", "ManifacturerId", "Volume" },
                values: new object[,]
                {
                    { 1, 1, 10.800000000000001, 150, 1, 2000 },
                    { 2, 2, 7.4000000000000004, 140, 8, 1800 },
                    { 3, 1, 6.4000000000000004, 90, 13, 1100 },
                    { 4, 2, 2.2000000000000002, 80, 4, 900 },
                    { 5, 3, 1.0, 90, 7, 500 },
                    { 6, 2, 5.2999999999999998, 124, 1, 1600 },
                    { 7, 4, 14.5, 184, 3, 2700 },
                    { 8, 6, 2.6000000000000001, 186, 4, 600 },
                    { 9, 1, 6.7000000000000002, 118, 9, 1500 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
