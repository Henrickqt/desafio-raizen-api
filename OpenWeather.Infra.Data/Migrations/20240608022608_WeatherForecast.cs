using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpenWeather.Infra.Data.Migrations
{
    public partial class WeatherForecast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeatherForecast",
                columns: table => new
                {
                    WeatherForecastId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Latitude = table.Column<decimal>(type: "decimal(12,7)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(12,7)", nullable: false),
                    Timezone = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    TimezoneOffset = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherForecast", x => x.WeatherForecastId);
                });

            migrationBuilder.CreateTable(
                name: "Daily",
                columns: table => new
                {
                    DailyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<int>(type: "int", nullable: false),
                    Humidity = table.Column<int>(type: "int", nullable: false),
                    WindSpeed = table.Column<decimal>(type: "decimal(12,5)", nullable: false),
                    Precipitation = table.Column<decimal>(type: "decimal(12,5)", nullable: false),
                    TemperatureMin = table.Column<decimal>(type: "decimal(12,5)", nullable: false),
                    TemperatureMax = table.Column<decimal>(type: "decimal(12,5)", nullable: false),
                    WeatherForecastId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Daily", x => x.DailyId);
                    table.ForeignKey(
                        name: "FK_Daily_WeatherForecast_WeatherForecastId",
                        column: x => x.WeatherForecastId,
                        principalTable: "WeatherForecast",
                        principalColumn: "WeatherForecastId");
                });

            migrationBuilder.CreateTable(
                name: "Hourly",
                columns: table => new
                {
                    HourlyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<int>(type: "int", nullable: false),
                    Temperature = table.Column<decimal>(type: "decimal(12,5)", nullable: false),
                    Humidity = table.Column<int>(type: "int", nullable: false),
                    WindSpeed = table.Column<decimal>(type: "decimal(12,5)", nullable: false),
                    Precipitation = table.Column<decimal>(type: "decimal(12,5)", nullable: false),
                    WeatherForecastId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hourly", x => x.HourlyId);
                    table.ForeignKey(
                        name: "FK_Hourly_WeatherForecast_WeatherForecastId",
                        column: x => x.WeatherForecastId,
                        principalTable: "WeatherForecast",
                        principalColumn: "WeatherForecastId");
                });

            migrationBuilder.CreateTable(
                name: "DailyWeather",
                columns: table => new
                {
                    DailyWeatherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Main = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Icon = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    DailyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyWeather", x => x.DailyWeatherId);
                    table.ForeignKey(
                        name: "FK_DailyWeather_Daily_DailyId",
                        column: x => x.DailyId,
                        principalTable: "Daily",
                        principalColumn: "DailyId");
                });

            migrationBuilder.CreateTable(
                name: "HourlyWeather",
                columns: table => new
                {
                    HourlyWeatherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Main = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Icon = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    HourlyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HourlyWeather", x => x.HourlyWeatherId);
                    table.ForeignKey(
                        name: "FK_HourlyWeather_Hourly_HourlyId",
                        column: x => x.HourlyId,
                        principalTable: "Hourly",
                        principalColumn: "HourlyId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Daily_WeatherForecastId",
                table: "Daily",
                column: "WeatherForecastId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyWeather_DailyId",
                table: "DailyWeather",
                column: "DailyId");

            migrationBuilder.CreateIndex(
                name: "IX_Hourly_WeatherForecastId",
                table: "Hourly",
                column: "WeatherForecastId");

            migrationBuilder.CreateIndex(
                name: "IX_HourlyWeather_HourlyId",
                table: "HourlyWeather",
                column: "HourlyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyWeather");

            migrationBuilder.DropTable(
                name: "HourlyWeather");

            migrationBuilder.DropTable(
                name: "Daily");

            migrationBuilder.DropTable(
                name: "Hourly");

            migrationBuilder.DropTable(
                name: "WeatherForecast");
        }
    }
}
