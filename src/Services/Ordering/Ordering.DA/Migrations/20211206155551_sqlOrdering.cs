using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ordering.DA.Migrations
{
    public partial class sqlOrdering : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Deivery",
                columns: table => new
                {
                    DeliveryID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstNameReceiver = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastNameReceiver = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deivery", x => x.DeliveryID);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaymentID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CVV = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PaymentID);
                });

            migrationBuilder.CreateTable(
                name: "SaleOrder",
                columns: table => new
                {
                    OrderID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConfirmDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalAmount = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: true),
                    StaffID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    CustomerPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DeliveryID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleOrder", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_SaleOrder_Deivery_DeliveryID",
                        column: x => x.DeliveryID,
                        principalTable: "Deivery",
                        principalColumn: "DeliveryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleOrder_Payment_PaymentID",
                        column: x => x.PaymentID,
                        principalTable: "Payment",
                        principalColumn: "PaymentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaleOrderDetail",
                columns: table => new
                {
                    OrderDetailID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IMEI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    VAT = table.Column<double>(type: "float", nullable: false),
                    SalePrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleOrderDetail", x => x.OrderDetailID);
                    table.ForeignKey(
                        name: "FK_SaleOrderDetail_SaleOrder_OrderID",
                        column: x => x.OrderID,
                        principalTable: "SaleOrder",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Deivery",
                columns: new[] { "DeliveryID", "Address", "CustomerID", "Email", "FirstNameReceiver", "LastNameReceiver", "PhoneNo" },
                values: new object[] { "172899e9-aafd-422a-9ae9-700784893d51", "123 ABC", "9c993247-4e9d-4f26-9bd0-52f3eb420d4c", "asd@gmail.com", "Viet", "Lam", "0123213" });

            migrationBuilder.InsertData(
                table: "Payment",
                columns: new[] { "PaymentID", "CVV", "CardName", "CardNo", "CustomerID", "Expiration", "PaymentMethod" },
                values: new object[] { "f8bff311-f0d8-400e-b34e-0aa801841a2f", "123", "ABC", "1221313", "9c993247-4e9d-4f26-9bd0-52f3eb420d4c", new DateTime(2022, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "" });

            migrationBuilder.InsertData(
                table: "SaleOrder",
                columns: new[] { "OrderID", "ConfirmDate", "CustomerAddress", "CustomerID", "CustomerName", "CustomerPhone", "DeliveryID", "Gender", "IsDelete", "OrderDate", "PaymentID", "StaffID", "Status", "TotalAmount" },
                values: new object[] { "bc8e1e84-b0dd-44c3-b551-50c432df025d", null, null, "9c993247-4e9d-4f26-9bd0-52f3eb420d4c", "Viet", null, "172899e9-aafd-422a-9ae9-700784893d51", 0, false, new DateTime(2021, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "f8bff311-f0d8-400e-b34e-0aa801841a2f", null, null, 100000.0 });

            migrationBuilder.InsertData(
                table: "SaleOrderDetail",
                columns: new[] { "OrderDetailID", "IMEI", "OrderID", "ProductID", "ProductName", "Quantity", "SalePrice", "VAT" },
                values: new object[] { "dcdc9940-b56d-481e-8d4c-54c574a9667a", "312312321312", "bc8e1e84-b0dd-44c3-b551-50c432df025d", null, "Itel 33", 1, 50000.0, 0.10000000000000001 });

            migrationBuilder.InsertData(
                table: "SaleOrderDetail",
                columns: new[] { "OrderDetailID", "IMEI", "OrderID", "ProductID", "ProductName", "Quantity", "SalePrice", "VAT" },
                values: new object[] { "f28c6161-116f-44c1-a08d-c9b3f9b72e3a", null, "bc8e1e84-b0dd-44c3-b551-50c432df025d", null, "Tai nghe Sony", 1, 50000.0, 0.10000000000000001 });

            migrationBuilder.CreateIndex(
                name: "IX_SaleOrder_DeliveryID",
                table: "SaleOrder",
                column: "DeliveryID");

            migrationBuilder.CreateIndex(
                name: "IX_SaleOrder_PaymentID",
                table: "SaleOrder",
                column: "PaymentID");

            migrationBuilder.CreateIndex(
                name: "IX_SaleOrderDetail_OrderID",
                table: "SaleOrderDetail",
                column: "OrderID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SaleOrderDetail");

            migrationBuilder.DropTable(
                name: "SaleOrder");

            migrationBuilder.DropTable(
                name: "Deivery");

            migrationBuilder.DropTable(
                name: "Payment");
        }
    }
}
