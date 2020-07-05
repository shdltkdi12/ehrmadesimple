using Microsoft.EntityFrameworkCore.Migrations;

namespace ehrmadesimple.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProgressNote",
                table: "Appointments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PsychoNote",
                table: "Appointments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProgressNote",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "PsychoNote",
                table: "Appointments");
        }
    }
}
