using Microsoft.EntityFrameworkCore.Migrations;

namespace KantinAPI.Migrations
{
    public partial class AddOrderTotalPaye : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TotalPaye",
                table: "Orders",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPaye",
                table: "Orders");
        }
    }
}
