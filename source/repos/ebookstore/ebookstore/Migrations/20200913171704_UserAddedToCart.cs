using Microsoft.EntityFrameworkCore.Migrations;

namespace ebookstore.Migrations
{
    public partial class UserAddedToCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "ShoppingCartItems",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userId",
                table: "ShoppingCartItems");
        }
    }
}
