using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace JEPCO.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AuditLogging : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "WeatherForecastTableSet");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "WeatherForecastTableSet",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "WeatherForecastTableSet",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Day",
                table: "WeatherForecastTableSet",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "WeatherForecastTableSet",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedAt",
                table: "WeatherForecastTableSet",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "WeatherForecastTableSet",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Month",
                table: "WeatherForecastTableSet",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "WeatherForecastTableSet",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    TableName = table.Column<string>(type: "text", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OldValues = table.Column<string>(type: "text", nullable: false),
                    NewValues = table.Column<string>(type: "text", nullable: false),
                    AffectedColumns = table.Column<string>(type: "text", nullable: false),
                    PrimaryKey = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "WeatherForecastTableSet");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "WeatherForecastTableSet");

            migrationBuilder.DropColumn(
                name: "Day",
                table: "WeatherForecastTableSet");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "WeatherForecastTableSet");

            migrationBuilder.DropColumn(
                name: "LastModifiedAt",
                table: "WeatherForecastTableSet");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "WeatherForecastTableSet");

            migrationBuilder.DropColumn(
                name: "Month",
                table: "WeatherForecastTableSet");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "WeatherForecastTableSet");

            migrationBuilder.AddColumn<DateOnly>(
                name: "Date",
                table: "WeatherForecastTableSet",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }
    }
}
