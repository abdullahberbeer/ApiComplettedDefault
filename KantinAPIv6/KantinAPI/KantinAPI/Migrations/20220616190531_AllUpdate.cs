using Microsoft.EntityFrameworkCore.Migrations;

namespace KantinAPI.Migrations
{
    public partial class AllUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_AspNetUsers_UserId",
                table: "Baskets");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Orders",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                newName: "IX_Orders_PersonId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Baskets",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Baskets_UserId",
                table: "Baskets",
                newName: "IX_Baskets_PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_Persons_PersonId",
                table: "Baskets",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Persons_PersonId",
                table: "Orders",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_Persons_PersonId",
                table: "Baskets");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Persons_PersonId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Orders",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_PersonId",
                table: "Orders",
                newName: "IX_Orders_UserId");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Baskets",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Baskets_PersonId",
                table: "Baskets",
                newName: "IX_Baskets_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_AspNetUsers_UserId",
                table: "Baskets",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
