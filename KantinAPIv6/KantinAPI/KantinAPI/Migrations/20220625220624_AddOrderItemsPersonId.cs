using Microsoft.EntityFrameworkCore.Migrations;

namespace KantinAPI.Migrations
{
    public partial class AddOrderItemsPersonId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "OrderItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "OrderItems");
        }
    }
}
