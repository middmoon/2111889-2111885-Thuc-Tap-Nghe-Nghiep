using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Migrations
{
    public partial class AddEditorApplyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EditorApply",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EditorApply", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_EditorApply_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEBZjiF/qADNO4Oxv48mmTEjOc1QDbqsBLmib0V/odXIqyrrOhOOxIyRCby5EhrtuZQ==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEBFxnSYhwX/juSNek1mez+3gzHoraQZoIk+dni2cSMFXe7cl9r+KMpuKKb4/0HqIcw==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEIiDYumA8lxO/81CrXDZoz6Vi8R+hfS8WI0jhr8p7/+0iKVsbJJwXainuyQMHtfFYA==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEJOEyQ5bQO3lFi2K3EVXsKY9KrFg4tRziIx/o8NMBvi3lbcu1dtpNOhblUV15EILTw==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEIs+RF96Libtia/WMgEJGVySZ9PoLlTrElpn1RRULQDv48ioOhuzB3N6okdxYdunjg==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EditorApply");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEKP2mxLj1E+Ra1pa+9loBgAxCQpT1tUkp+i9CKJLuMShTBBVu4eSVRF+IAD/3h2zCQ==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEIZJfeKGGF3FwUAe3rIUQBUNrB0HcB4yXp7fI611yIi4J2c/Wz0VUJSpz1V8ZQJWDg==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAECiHVpBG2rL4ULKW9gJ3K5LN7gr2mOhw5OqOVUzlzBAakm4Zk3tLmnKwXK0usnYhqQ==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAENcsQnRRCQ9HvWl28wL1zyNxrUzNCB6PKDnRrupUTgooKpeSLMyz10ywYwAyTvt8tw==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEKGdKw7EmqsP/+I0SYeurreO1frbL56orbOvybulE2VvVkkc8vI8Apb8fTYYUcn8/A==");
        }
    }
}
