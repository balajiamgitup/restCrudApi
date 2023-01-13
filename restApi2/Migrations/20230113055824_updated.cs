using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace restApi2.Migrations
{
    /// <inheritdoc />
    public partial class updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    OrderID = table.Column<long>(type: "bigint", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    GTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderNo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order", x => x.OrderID);
                });

            migrationBuilder.CreateTable(
                name: "orderItems",
                columns: table => new
                {
                    OrderItemID = table.Column<long>(type: "bigint", nullable: false),
                    OrderID = table.Column<long>(type: "bigint", nullable: true),
                    ItemID = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderItems", x => x.OrderItemID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "orderItems");
        }
    }
}
