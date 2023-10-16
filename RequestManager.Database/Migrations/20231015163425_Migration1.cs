using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RequestManager.Database.Migrations;

/// <inheritdoc />
public partial class Migration1 : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Couriers",
            columns: table => new
            {
                Id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                Surname = table.Column<string>(type: "text", nullable: false),
                Name = table.Column<string>(type: "text", nullable: false),
                Patronymic = table.Column<string>(type: "text", nullable: true),
                PhoneNumber = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Couriers", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Requests",
            columns: table => new
            {
                Id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                Number = table.Column<int>(type: "integer", nullable: false),
                RegistrationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                SendersSurname = table.Column<string>(type: "text", nullable: false),
                SendersName = table.Column<string>(type: "text", nullable: false),
                SendersPatronymic = table.Column<string>(type: "text", nullable: true),
                SendersPhoneNumber = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: false),
                CargoName = table.Column<string>(type: "text", nullable: false),
                DeliveryAddress = table.Column<string>(type: "text", nullable: false),
                Status = table.Column<string>(type: "text", nullable: false),
                CourierId = table.Column<long>(type: "bigint", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Requests", x => x.Id);
                table.UniqueConstraint("AK_Requests_Number", x => x.Number);
                table.ForeignKey(
                    name: "FK_Requests_Couriers_CourierId",
                    column: x => x.CourierId,
                    principalTable: "Couriers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Requests_CourierId",
            table: "Requests",
            column: "CourierId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Requests");

        migrationBuilder.DropTable(
            name: "Couriers");
    }
}
