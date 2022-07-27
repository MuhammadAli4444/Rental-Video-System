using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalVideoSystem.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RentedVideos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BorrowDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    VideoID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentedVideos", x => x.Id);
                });

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
                name: "Manager",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserGenericId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manager", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manager_ApplicationUser_ApplicationUserGenericId",
                        column: x => x.ApplicationUserGenericId,
                        principalTable: "ApplicationUser",
                        principalColumn: "GenericId",
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
                        name: "FK_Store_Manager_Manager_ObjId",
                        column: x => x.Manager_ObjId,
                        principalTable: "Manager",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VideoTable",
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
                    table.PrimaryKey("PK_VideoTable", x => x.VideoId);
                    table.ForeignKey(
                        name: "FK_VideoTable_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "StoreId",
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
                table: "Manager",
                columns: new[] { "Id", "ApplicationUserGenericId" },
                values: new object[] { 1, null });

            migrationBuilder.InsertData(
                table: "VideoTable",
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
                name: "IX_Manager_ApplicationUserGenericId",
                table: "Manager",
                column: "ApplicationUserGenericId");

            migrationBuilder.CreateIndex(
                name: "IX_Store_Manager_ObjId",
                table: "Store",
                column: "Manager_ObjId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoTable_StoreId",
                table: "VideoTable",
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
                name: "Customer");

            migrationBuilder.DropTable(
                name: "RentedVideos");

            migrationBuilder.DropTable(
                name: "VideoTable");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropTable(
                name: "Manager");

            migrationBuilder.DropTable(
                name: "ApplicationUser");
        }
    }
}
