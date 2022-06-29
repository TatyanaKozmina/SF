using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstApp.Migrations
{
    public partial class HireDate_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "HireDate",
                table: "Users",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HireDate",
                table: "Users");
        }
    }
}
