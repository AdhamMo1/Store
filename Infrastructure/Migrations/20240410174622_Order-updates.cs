using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Orderupdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ProductItemOrdered",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ShippToAddressId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemOrderdId",
                table: "OrderItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Address",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductItemOrdered",
                table: "ProductItemOrdered",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShippToAddressId",
                table: "Orders",
                column: "ShippToAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ItemOrderdId",
                table: "OrderItems",
                column: "ItemOrderdId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_ProductItemOrdered_ItemOrderdId",
                table: "OrderItems",
                column: "ItemOrderdId",
                principalTable: "ProductItemOrdered",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Address_ShippToAddressId",
                table: "Orders",
                column: "ShippToAddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_ProductItemOrdered_ItemOrderdId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Address_ShippToAddressId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductItemOrdered",
                table: "ProductItemOrdered");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ShippToAddressId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_ItemOrderdId",
                table: "OrderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProductItemOrdered");

            migrationBuilder.DropColumn(
                name: "ShippToAddressId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ItemOrderdId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Address");
        }
    }
}
