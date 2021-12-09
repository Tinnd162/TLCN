using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityService.Migrations
{
    public partial class IdentityDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserID, x.RoleID });
                    table.ForeignKey(
                        name: "FK_UserRoles_Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "RoleID", "Description", "RoleName" },
                values: new object[,]
                {
                    { "c26070b0-afec-4fec-8f61-af5687bfc5d8", null, "admin" },
                    { "78241f9d-0d2f-4be1-a238-d79b63f219b2", null, "customer" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserID", "Address", "BirthDay", "FirstName", "LastName", "Password", "UserName" },
                values: new object[,]
                {
                    { "a897f752-2234-4b8f-8780-324896017a3f", null, null, null, null, "12345", "Viet" },
                    { "d7c4f37c-721a-48b3-834a-ce00b72b8e03", null, null, null, null, "12345", "Customer" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleID", "UserID" },
                values: new object[] { "c26070b0-afec-4fec-8f61-af5687bfc5d8", "a897f752-2234-4b8f-8780-324896017a3f" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleID", "UserID" },
                values: new object[] { "78241f9d-0d2f-4be1-a238-d79b63f219b2", "d7c4f37c-721a-48b3-834a-ce00b72b8e03" });

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleID",
                table: "UserRoles",
                column: "RoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
