using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Migrations
{
    public partial class SeedRolesAndUsersUpadate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 2, 2 },
                    { 2, 3 }
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAECymKMMqSAhO5obnowDkUM5PjmD6gNl2RRb/82+d44KTgBouXJXvz7V4ziCmgZD4sA==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEEzSoGYvGacwFTZR/0SBeywqS2nNGR+8xYz6c6ZJqCBPovbP4xZGjqR3sDEY03gfJg==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEN4TecSukvlWV28yUqHPnjmKZg3/J/3fIy8T2ip/Ej9O2+iPR5i7ZlxP+HfvzgV0Fw==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEAEx+amVeTxAiBXxGiZJ5ZDM4n4O36nNiVn5LtJMjiUWFrKQGo+n+N38gCi2aQHtOA==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEJLNmcGjd5N1fjK+EopJxxu74wSsP+41RYKYx9k7dKTfdVVOgrIyIOkimgcbrxZSmw==");
        }
    }
}
