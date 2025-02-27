using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Migrations
{
    public partial class AddBlogModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blog_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEPXRZ8fzK5nnaFEWAuRnjVBxzMNvj/tSErubCZkRjWtJ/Vcwvj9XAcOFAsv7eWwcPA==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEOgft4Y78QgSwTavUxIA8WLmasPCbialoqFdjQpB2+59e2OeT7btSbL8SOv19xd0uQ==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEM1pV0XxSTYpFHGToBPPvbEQUFslK8ViSEqG+7tf4sImRplf4SuLrEuJhAm9SPidnA==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAECmp0kdwH4pRXqe49LpNVqsPlsqeeiKXb3Qhre3fOlc3cE5lNf/rnB8LIELtY3LWZQ==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEJxJa2EvclMmfkW8YRfEtFq9ogez4OlDSBFEwuPtNAMuFRyP2s4zbHtDXa0XSkmOzw==");

            migrationBuilder.CreateIndex(
                name: "IX_Blog_AuthorId",
                table: "Blog",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blog");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEFGzOQpo0i0+tQqjfcZcV9CpjBNPWhLCzrXMTM6t0R0rIWBEI8G7dnuqxY9IxAZkxg==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEJ0MQEs4WGVnop2xvONyi/H8zO/DSQjWE4dAZJOVgHSuc3W67TJKJlMNazgekjiiuw==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAENY+mAeQCG865Yan5DFyf/HMQIJLamqn445LNci/EgKx5LxkCmyhsnMV+mXAvBeqMw==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEPFsW+v3NipwiZjyZJjcPXMokCwEoA/bXuBh7xQ4oYGqQvINPLRTg719padQoYiJYQ==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAELjYslBDQkh5zm+uvWqcKJSUmA7OK/1FJzKwmPsi9fwiqaJ9/MTCrLLzxcmoKv6EEQ==");
        }
    }
}
