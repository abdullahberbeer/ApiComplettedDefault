using Microsoft.EntityFrameworkCore.Migrations;

namespace KantinAPI.Migrations
{
    public partial class AddTotalPaye : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TotalPaye",
                table: "Baskets",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPaye",
                table: "Baskets");
        }
    }
}
