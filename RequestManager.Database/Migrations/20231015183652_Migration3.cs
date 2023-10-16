using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RequestManager.Database.Migrations;

/// <inheritdoc />
public partial class Migration3 : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<int>(
            name: "PassportNumber",
            table: "Requests",
            type: "integer",
            maxLength: 6,
            nullable: false,
            defaultValue: 0);

        migrationBuilder.AddColumn<int>(
            name: "PassportSeries",
            table: "Requests",
            type: "integer",
            maxLength: 4,
            nullable: false,
            defaultValue: 0);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "PassportNumber",
            table: "Requests");

        migrationBuilder.DropColumn(
            name: "PassportSeries",
            table: "Requests");
    }
}
