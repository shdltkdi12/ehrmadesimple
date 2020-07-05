using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ehrmadesimple.Migrations
{
    public partial class init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "Diagnosis",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "DiagnosisTimestamp",
                table: "Clients");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Timestamp",
                table: "Sessions",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "ChartNote",
                table: "Sessions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoteType",
                table: "Sessions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TreatmentPlan",
                table: "Sessions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChartNote",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "NoteType",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "TreatmentPlan",
                table: "Sessions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Timestamp",
                table: "Sessions",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Sessions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Diagnosis",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DiagnosisTimestamp",
                table: "Clients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
