using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RequestManager.Database.Migrations;

/// <inheritdoc />
public partial class dsgds12 : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<string>(
            name: "Status",
            table: "Requests",
            type: "text",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "text");

        migrationBuilder.AlterColumn<string>(
            name: "SendersPhoneNumber",
            table: "Requests",
            type: "text",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "character varying(12)",
            oldMaxLength: 12);

        migrationBuilder.AlterColumn<string>(
            name: "SendersPassport",
            table: "Requests",
            type: "text",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "character varying(10)",
            oldMaxLength: 10);

        migrationBuilder.AlterColumn<string>(
            name: "SendersName",
            table: "Requests",
            type: "text",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "text");

        migrationBuilder.AlterColumn<string>(
            name: "RecipientsPhoneNumber",
            table: "Requests",
            type: "text",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "character varying(12)",
            oldMaxLength: 12);

        migrationBuilder.AlterColumn<string>(
            name: "RecipientsPassport",
            table: "Requests",
            type: "text",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "character varying(10)",
            oldMaxLength: 10);

        migrationBuilder.AlterColumn<string>(
            name: "RecipientsName",
            table: "Requests",
            type: "text",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "text");

        migrationBuilder.AlterColumn<string>(
            name: "DeliveryAddress",
            table: "Requests",
            type: "text",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "text");

        migrationBuilder.AlterColumn<string>(
            name: "CargoDescription",
            table: "Requests",
            type: "text",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "text");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<string>(
            name: "Status",
            table: "Requests",
            type: "text",
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "text",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "SendersPhoneNumber",
            table: "Requests",
            type: "character varying(12)",
            maxLength: 12,
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "text",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "SendersPassport",
            table: "Requests",
            type: "character varying(10)",
            maxLength: 10,
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "text",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "SendersName",
            table: "Requests",
            type: "text",
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "text",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "RecipientsPhoneNumber",
            table: "Requests",
            type: "character varying(12)",
            maxLength: 12,
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "text",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "RecipientsPassport",
            table: "Requests",
            type: "character varying(10)",
            maxLength: 10,
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "text",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "RecipientsName",
            table: "Requests",
            type: "text",
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "text",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "DeliveryAddress",
            table: "Requests",
            type: "text",
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "text",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "CargoDescription",
            table: "Requests",
            type: "text",
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "text",
            oldNullable: true);
    }
}