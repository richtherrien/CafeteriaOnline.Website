using Microsoft.EntityFrameworkCore.Migrations;

namespace CafeteriaOnline.Website.Data.Migrations
{
    public partial class AddedOrderItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_MealConfiguration_MealConfigurationId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Order");

            migrationBuilder.AlterColumn<int>(
                name: "MealConfigurationId",
                table: "Order",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    OrderItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(nullable: false),
                    MealConfigurationId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK_OrderItem_MealConfiguration_MealConfigurationId",
                        column: x => x.MealConfigurationId,
                        principalTable: "MealConfiguration",
                        principalColumn: "MealConfigurationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_MealConfigurationId",
                table: "OrderItem",
                column: "MealConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_MealConfiguration_MealConfigurationId",
                table: "Order",
                column: "MealConfigurationId",
                principalTable: "MealConfiguration",
                principalColumn: "MealConfigurationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_MealConfiguration_MealConfigurationId",
                table: "Order");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.AlterColumn<int>(
                name: "MealConfigurationId",
                table: "Order",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_MealConfiguration_MealConfigurationId",
                table: "Order",
                column: "MealConfigurationId",
                principalTable: "MealConfiguration",
                principalColumn: "MealConfigurationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
