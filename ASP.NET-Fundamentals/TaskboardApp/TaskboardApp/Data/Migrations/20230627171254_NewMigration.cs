using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskboardApp.Data.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_AspNetUsers_UserId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ba3897dc-80d0-4fb6-92ab-0bd0f100ec47");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Tasks");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "Tasks",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e2a2e67f-c414-49c8-b0d7-915f75c4c375", 0, "2534259c-0b6f-41cc-b50b-3d3a66dd26a0", null, false, false, null, null, "TEST@SOFTUNI.BG", "AQAAAAEAACcQAAAAEBKIYqyqTPhmWEQwOzQihnpYfsOsbuSFFVtZYxbFQIJg3Djaa04+j9zgznWZ/QiKDg==", null, false, "f46efb5c-9a7c-4981-8872-dd834ff55313", false, "test@softuni.bg" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2020, 3, 14, 20, 12, 54, 151, DateTimeKind.Local).AddTicks(9616), "e2a2e67f-c414-49c8-b0d7-915f75c4c375" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2023, 1, 27, 20, 12, 54, 151, DateTimeKind.Local).AddTicks(9648), "e2a2e67f-c414-49c8-b0d7-915f75c4c375" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2023, 5, 27, 20, 12, 54, 151, DateTimeKind.Local).AddTicks(9652), "e2a2e67f-c414-49c8-b0d7-915f75c4c375" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2022, 6, 27, 20, 12, 54, 151, DateTimeKind.Local).AddTicks(9654), "e2a2e67f-c414-49c8-b0d7-915f75c4c375" });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_OwnerId",
                table: "Tasks",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_AspNetUsers_OwnerId",
                table: "Tasks",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_AspNetUsers_OwnerId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_OwnerId",
                table: "Tasks");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2a2e67f-c414-49c8-b0d7-915f75c4c375");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Tasks",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ba3897dc-80d0-4fb6-92ab-0bd0f100ec47", 0, "548e11c4-a9b1-4362-80b7-3ce90e7a4a4c", null, false, false, null, null, "TEST@SOFTUNI.BG", "AQAAAAEAACcQAAAAEJvFWVOrCVRCbN+XLjF8aDAx1r+e84Sryzdo5L/mXRl3HxhXhkImIa6wCtf1MDRvlQ==", null, false, "f88a70f1-6d5f-4374-87d2-a66b3843c304", false, "test@softuni.bg" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2020, 3, 11, 17, 21, 26, 838, DateTimeKind.Local).AddTicks(8405), "ba3897dc-80d0-4fb6-92ab-0bd0f100ec47" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2023, 1, 24, 17, 21, 26, 838, DateTimeKind.Local).AddTicks(8445), "ba3897dc-80d0-4fb6-92ab-0bd0f100ec47" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2023, 5, 24, 17, 21, 26, 838, DateTimeKind.Local).AddTicks(8449), "ba3897dc-80d0-4fb6-92ab-0bd0f100ec47" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2022, 6, 24, 17, 21, 26, 838, DateTimeKind.Local).AddTicks(8452), "ba3897dc-80d0-4fb6-92ab-0bd0f100ec47" });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_AspNetUsers_UserId",
                table: "Tasks",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
