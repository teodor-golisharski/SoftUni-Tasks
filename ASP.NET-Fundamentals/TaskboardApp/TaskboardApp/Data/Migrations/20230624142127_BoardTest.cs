using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskboardApp.Data.Migrations
{
    public partial class BoardTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BoardId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tasks_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ba3897dc-80d0-4fb6-92ab-0bd0f100ec47", 0, "548e11c4-a9b1-4362-80b7-3ce90e7a4a4c", null, false, false, null, null, "TEST@SOFTUNI.BG", "AQAAAAEAACcQAAAAEJvFWVOrCVRCbN+XLjF8aDAx1r+e84Sryzdo5L/mXRl3HxhXhkImIa6wCtf1MDRvlQ==", null, false, "f88a70f1-6d5f-4374-87d2-a66b3843c304", false, "test@softuni.bg" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "In Progress" },
                    { 3, "Done" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 3, 11, 17, 21, 26, 838, DateTimeKind.Local).AddTicks(8405), "Implement better styling for all public pages", "ba3897dc-80d0-4fb6-92ab-0bd0f100ec47", "Improve CSS styles", null },
                    { 2, 1, new DateTime(2023, 1, 24, 17, 21, 26, 838, DateTimeKind.Local).AddTicks(8445), "Create Android client app for the TaskBoard RESTful API", "ba3897dc-80d0-4fb6-92ab-0bd0f100ec47", "Android Client App", null },
                    { 3, 2, new DateTime(2023, 5, 24, 17, 21, 26, 838, DateTimeKind.Local).AddTicks(8449), "Create Windows Forms desktop app for the TaskBoard RESTful API", "ba3897dc-80d0-4fb6-92ab-0bd0f100ec47", "Desktop Client App", null },
                    { 4, 3, new DateTime(2022, 6, 24, 17, 21, 26, 838, DateTimeKind.Local).AddTicks(8452), "Implement [Create Task] page for adding new tasks", "ba3897dc-80d0-4fb6-92ab-0bd0f100ec47", "Create Tasks", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_BoardId",
                table: "Tasks",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Boards");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ba3897dc-80d0-4fb6-92ab-0bd0f100ec47");
        }
    }
}
