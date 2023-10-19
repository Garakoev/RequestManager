using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RequestManager.Database.Migrations;

/// <inheritdoc />
public partial class Migration5 : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "RecipientsPassportNumber",
            table: "Requests");

        migrationBuilder.DropColumn(
            name: "RecipientsPassportSeries",
            table: "Requests");

        migrationBuilder.DropColumn(
            name: "SendersPassportNumber",
            table: "Requests");

        migrationBuilder.DropColumn(
            name: "SendersPassportSeries",
            table: "Requests");

        migrationBuilder.AddColumn<int>(
            name: "RecipientsPassport",
            table: "Requests",
            type: "integer",
            maxLength: 10,
            nullable: false,
            defaultValue: 0);

        migrationBuilder.AddColumn<int>(
            name: "SendersPassport",
            table: "Requests",
            type: "integer",
            maxLength: 10,
            nullable: false,
            defaultValue: 0);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "RecipientsPassport",
            table: "Requests");

        migrationBuilder.DropColumn(
            name: "SendersPassport",
            table: "Requests");

        migrationBuilder.AddColumn<int>(
            name: "RecipientsPassportNumber",
            table: "Requests",
            type: "integer",
            maxLength: 6,
            nullable: false,
            defaultValue: 0);

        migrationBuilder.AddColumn<int>(
            name: "RecipientsPassportSeries",
            table: "Requests",
            type: "integer",
            maxLength: 4,
            nullable: false,
            defaultValue: 0);

        migrationBuilder.AddColumn<int>(
            name: "SendersPassportNumber",
            table: "Requests",
            type: "integer",
            maxLength: 6,
            nullable: false,
            defaultValue: 0);

        migrationBuilder.AddColumn<int>(
            name: "SendersPassportSeries",
            table: "Requests",
            type: "integer",
            maxLength: 4,
            nullable: false,
            defaultValue: 0);
    }
}