using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ordering.DA.Migrations
{
    public partial class InitCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Deivery",
                columns: table => new
                {
                    DeliveryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstNameReceiver = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastNameReceiver = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deivery", x => x.DeliveryID);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaymentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                name: "Order",
                columns: table => new
                {
                    OrderID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConfirmDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalAmount = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: true),
                    StaffID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeliveryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Order_Deivery_DeliveryID",
                        column: x => x.DeliveryID,
                        principalTable: "Deivery",
                        principalColumn: "DeliveryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Payment_PaymentID",
                        column: x => x.PaymentID,
                        principalTable: "Payment",
                        principalColumn: "PaymentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    OrderDetailID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IMEI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    VAT = table.Column<double>(type: "float", nullable: false),
                    SalePrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.OrderDetailID);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Deivery",
                columns: new[] { "DeliveryID", "Address", "CustomerID", "Email", "FirstNameReceiver", "LastNameReceiver", "PhoneNo" },
                values: new object[] { new Guid("9c8389da-3a06-40e0-a17b-aefa996d4ce6"), "123 ABC", new Guid("eec92800-02a2-4f87-91b5-dd5f03a5d9d8"), "asd@gmail.com", "Viet", "Lam", "0123213" });

            migrationBuilder.InsertData(
                table: "Payment",
                columns: new[] { "PaymentID", "CVV", "CardName", "CardNo", "Expiration", "PaymentMethod" },
                values: new object[] { new Guid("4ccb9f59-4452-46c1-9ea0-38893a7a07bd"), "123", "ABC", "1221313", new DateTime(2022, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "" });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderID", "ConfirmDate", "CustomerID", "DeliveryID", "IsDelete", "OrderDate", "PaymentID", "StaffID", "Status", "TotalAmount" },
                values: new object[] { new Guid("135d885d-33ab-48b6-aaf3-c3468d49dca4"), null, new Guid("eec92800-02a2-4f87-91b5-dd5f03a5d9d8"), new Guid("9c8389da-3a06-40e0-a17b-aefa996d4ce6"), false, new DateTime(2021, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4ccb9f59-4452-46c1-9ea0-38893a7a07bd"), new Guid("00000000-0000-0000-0000-000000000000"), null, 100000.0 });

            migrationBuilder.InsertData(
                table: "OrderDetail",
                columns: new[] { "OrderDetailID", "IMEI", "OrderID", "ProductName", "Quantity", "SalePrice", "VAT" },
                values: new object[] { new Guid("d2930de6-a1cc-42ce-b0bc-4a59e3e1b054"), "312312321312", new Guid("135d885d-33ab-48b6-aaf3-c3468d49dca4"), "Itel 33", 1, 50000.0, 0.10000000000000001 });

            migrationBuilder.InsertData(
                table: "OrderDetail",
                columns: new[] { "OrderDetailID", "IMEI", "OrderID", "ProductName", "Quantity", "SalePrice", "VAT" },
                values: new object[] { new Guid("0a307435-8605-46ee-a01b-66fc4b6ba6c3"), null, new Guid("135d885d-33ab-48b6-aaf3-c3468d49dca4"), "Tai nghe Sony", 1, 50000.0, 0.10000000000000001 });

            migrationBuilder.CreateIndex(
                name: "IX_Order_DeliveryID",
                table: "Order",
                column: "DeliveryID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_PaymentID",
                table: "Order",
                column: "PaymentID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderID",
                table: "OrderDetail",
                column: "OrderID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Deivery");

            migrationBuilder.DropTable(
                name: "Payment");
        }
    }
}
