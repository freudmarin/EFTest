using Microsoft.EntityFrameworkCore.Migrations;

namespace ebookstore.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "ShoppingCartItems",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_userId",
                table: "ShoppingCartItems",
                column: "userId",
                unique: true,
                filter: "[userId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_AspNetUsers_userId",
                table: "ShoppingCartItems",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_AspNetUsers_userId",
                table: "ShoppingCartItems");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCartItems_userId",
                table: "ShoppingCartItems");

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "ShoppingCartItems",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
