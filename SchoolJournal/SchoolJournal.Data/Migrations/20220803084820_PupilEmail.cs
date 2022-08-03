using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolJournal.Data.Migrations
{
    public partial class PupilEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Pupils",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Pupils");
        }
    }
}
