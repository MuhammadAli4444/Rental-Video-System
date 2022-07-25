using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalVideoSystem.Migrations
{
    public partial class abc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    GenericId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.GenericId);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserGenericId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_ApplicationUser_ApplicationUserGenericId",
                        column: x => x.ApplicationUserGenericId,
                        principalTable: "ApplicationUser",
                        principalColumn: "GenericId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ManagerTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserGenericId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagerTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManagerTable_ApplicationUser_ApplicationUserGenericId",
                        column: x => x.ApplicationUserGenericId,
                        principalTable: "ApplicationUser",
                        principalColumn: "GenericId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReminderEmail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BorrowDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReminderEmail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReminderEmail_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    StoreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Manager_ObjId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.StoreId);
                    table.ForeignKey(
                        name: "FK_Store_ManagerTable_Manager_ObjId",
                        column: x => x.Manager_ObjId,
                        principalTable: "ManagerTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VideoCassete",
                columns: table => new
                {
                    VideoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoCassete", x => x.VideoId);
                    table.ForeignKey(
                        name: "FK_VideoCassete_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RentalVideoCasset",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BorrowDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerIDId = table.Column<int>(type: "int", nullable: true),
                    VideoId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalVideoCasset", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RentalVideoCasset_Customer_CustomerIDId",
                        column: x => x.CustomerIDId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RentalVideoCasset_VideoCassete_VideoId",
                        column: x => x.VideoId,
                        principalTable: "VideoCassete",
                        principalColumn: "VideoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ApplicationUser",
                columns: new[] { "GenericId", "Email", "MobileNumber", "Name", "Role", "StoreId" },
                values: new object[,]
                {
                    { 1, "ali123mazhar@gmail.com", "03035024309", "MAMB", "Manager", null },
                    { 2, "abdullah@gmail.com", "03035024308", "Abdullah", "Customer", null }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "ApplicationUserGenericId" },
                values: new object[] { 1, null });

            migrationBuilder.InsertData(
                table: "ManagerTable",
                columns: new[] { "Id", "ApplicationUserGenericId" },
                values: new object[] { 1, null });

            migrationBuilder.InsertData(
                table: "VideoCassete",
                columns: new[] { "VideoId", "Description", "Price", "StoreId", "TitleName" },
                values: new object[] { 1, "Amazing movie", 100, null, "Abcd2" });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUser_StoreId",
                table: "ApplicationUser",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_ApplicationUserGenericId",
                table: "Customer",
                column: "ApplicationUserGenericId");

            migrationBuilder.CreateIndex(
                name: "IX_ManagerTable_ApplicationUserGenericId",
                table: "ManagerTable",
                column: "ApplicationUserGenericId");

            migrationBuilder.CreateIndex(
                name: "IX_ReminderEmail_CustomerId",
                table: "ReminderEmail",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_RentalVideoCasset_CustomerIDId",
                table: "RentalVideoCasset",
                column: "CustomerIDId");

            migrationBuilder.CreateIndex(
                name: "IX_RentalVideoCasset_VideoId",
                table: "RentalVideoCasset",
                column: "VideoId");

            migrationBuilder.CreateIndex(
                name: "IX_Store_Manager_ObjId",
                table: "Store",
                column: "Manager_ObjId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoCassete_StoreId",
                table: "VideoCassete",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUser_Store_StoreId",
                table: "ApplicationUser",
                column: "StoreId",
                principalTable: "Store",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUser_Store_StoreId",
                table: "ApplicationUser");

            migrationBuilder.DropTable(
                name: "ReminderEmail");

            migrationBuilder.DropTable(
                name: "RentalVideoCasset");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "VideoCassete");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropTable(
                name: "ManagerTable");

            migrationBuilder.DropTable(
                name: "ApplicationUser");
        }
    }
}
