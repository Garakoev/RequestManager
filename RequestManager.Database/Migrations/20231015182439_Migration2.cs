using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RequestManager.Database.Migrations;

/// <inheritdoc />
public partial class Migration2 : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Requests_Couriers_CourierId",
            table: "Requests");

        migrationBuilder.AlterColumn<long>(
            name: "CourierId",
            table: "Requests",
            type: "bigint",
            nullable: true,
            oldClrType: typeof(long),
            oldType: "bigint");

        migrationBuilder.AddColumn<string>(
            name: "Comment",
            table: "Requests",
            type: "text",
            nullable: true);

        migrationBuilder.AddForeignKey(
            name: "FK_Requests_Couriers_CourierId",
            table: "Requests",
            column: "CourierId",
            principalTable: "Couriers",
            principalColumn: "Id");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Requests_Couriers_CourierId",
            table: "Requests");

        migrationBuilder.DropColumn(
            name: "Comment",
            table: "Requests");

        migrationBuilder.AlterColumn<long>(
            name: "CourierId",
            table: "Requests",
            type: "bigint",
            nullable: false,
            defaultValue: 0L,
            oldClrType: typeof(long),
            oldType: "bigint",
            oldNullable: true);

        migrationBuilder.AddForeignKey(
            name: "FK_Requests_Couriers_CourierId",
            table: "Requests",
            column: "CourierId",
            principalTable: "Couriers",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }
}