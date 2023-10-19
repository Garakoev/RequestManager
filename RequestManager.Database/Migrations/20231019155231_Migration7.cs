using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RequestManager.Database.Migrations;

/// <inheritdoc />
public partial class Migration7 : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropUniqueConstraint(
            name: "AK_Requests_Number",
            table: "Requests");

        migrationBuilder.DropColumn(
            name: "Number",
            table: "Requests");

        migrationBuilder.DropColumn(
            name: "Patronymic",
            table: "Couriers");

        migrationBuilder.DropColumn(
            name: "Surname",
            table: "Couriers");

        migrationBuilder.RenameColumn(
            name: "CargoName",
            table: "Requests",
            newName: "CargoDescription");

        migrationBuilder.AlterColumn<string>(
            name: "SendersPassport",
            table: "Requests",
            type: "character varying(10)",
            maxLength: 10,
            nullable: false,
            oldClrType: typeof(int),
            oldType: "integer");

        migrationBuilder.AlterColumn<string>(
            name: "RecipientsPassport",
            table: "Requests",
            type: "character varying(10)",
            maxLength: 10,
            nullable: false,
            oldClrType: typeof(int),
            oldType: "integer");

        migrationBuilder.AddColumn<string>(
            name: "Passport",
            table: "Couriers",
            type: "character varying(10)",
            maxLength: 10,
            nullable: false,
            defaultValue: "");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "Passport",
            table: "Couriers");

        migrationBuilder.RenameColumn(
            name: "CargoDescription",
            table: "Requests",
            newName: "CargoName");

        migrationBuilder.AlterColumn<int>(
            name: "SendersPassport",
            table: "Requests",
            type: "integer",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "character varying(10)",
            oldMaxLength: 10);

        migrationBuilder.AlterColumn<int>(
            name: "RecipientsPassport",
            table: "Requests",
            type: "integer",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "character varying(10)",
            oldMaxLength: 10);

        migrationBuilder.AddColumn<int>(
            name: "Number",
            table: "Requests",
            type: "integer",
            nullable: false,
            defaultValue: 0);

        migrationBuilder.AddColumn<string>(
            name: "Patronymic",
            table: "Couriers",
            type: "text",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "Surname",
            table: "Couriers",
            type: "text",
            nullable: false,
            defaultValue: "");

        migrationBuilder.AddUniqueConstraint(
            name: "AK_Requests_Number",
            table: "Requests",
            column: "Number");
    }
}