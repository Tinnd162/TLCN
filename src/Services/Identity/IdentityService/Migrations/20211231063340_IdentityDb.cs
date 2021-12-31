using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityService.Migrations
{
    public partial class IdentityDb : Migration
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
                    { "61cea2fbcb8af21f87c2eb0c", null, "admin" },
                    { "61cea30163e98302a5ec0a12", null, "customer" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserID", "Address", "BirthDay", "FirstName", "LastName", "Password", "UserName" },
                values: new object[,]
                {
                    { "61cea2f03d7ec05a7321745d", null, null, null, null, "******", "Admin" },
                    { "61cea2f375e10dd236f9de06", null, null, null, null, "*****", "Customer" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleID", "UserID" },
                values: new object[] { "61cea2fbcb8af21f87c2eb0c", "61cea2f03d7ec05a7321745d" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleID", "UserID" },
                values: new object[] { "61cea30163e98302a5ec0a12", "61cea2f375e10dd236f9de06" });

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
