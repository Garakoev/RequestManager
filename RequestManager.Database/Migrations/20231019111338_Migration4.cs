using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RequestManager.Database.Migrations;

/// <inheritdoc />
public partial class Migration4 : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "SendersPatronymic",
            table: "Requests");

        migrationBuilder.RenameColumn(
            name: "SendersSurname",
            table: "Requests",
            newName: "RecipientsName");

        migrationBuilder.RenameColumn(
            name: "PassportSeries",
            table: "Requests",
            newName: "SendersPassportSeries");

        migrationBuilder.RenameColumn(
            name: "PassportNumber",
            table: "Requests",
            newName: "SendersPassportNumber");

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

        migrationBuilder.AddColumn<string>(
            name: "RecipientsPhoneNumber",
            table: "Requests",
            type: "character varying(12)",
            maxLength: 12,
            nullable: false,
            defaultValue: "");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "RecipientsPassportNumber",
            table: "Requests");

        migrationBuilder.DropColumn(
            name: "RecipientsPassportSeries",
            table: "Requests");

        migrationBuilder.DropColumn(
            name: "RecipientsPhoneNumber",
            table: "Requests");

        migrationBuilder.RenameColumn(
            name: "SendersPassportSeries",
            table: "Requests",
            newName: "PassportSeries");

        migrationBuilder.RenameColumn(
            name: "SendersPassportNumber",
            table: "Requests",
            newName: "PassportNumber");

        migrationBuilder.RenameColumn(
            name: "RecipientsName",
            table: "Requests",
            newName: "SendersSurname");

        migrationBuilder.AddColumn<string>(
            name: "SendersPatronymic",
            table: "Requests",
            type: "text",
            nullable: true);
    }
}