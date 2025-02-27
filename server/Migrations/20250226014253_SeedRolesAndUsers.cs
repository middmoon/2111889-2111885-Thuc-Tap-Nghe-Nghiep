using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Migrations
{
    public partial class SeedRolesAndUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "admin" },
                    { 2, "reader" },
                    { 3, "writer" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "Username" },
                values: new object[,]
                {
                    { 1, "AQAAAAEAACcQAAAAECymKMMqSAhO5obnowDkUM5PjmD6gNl2RRb/82+d44KTgBouXJXvz7V4ziCmgZD4sA==", "admin" },
                    { 4, "AQAAAAEAACcQAAAAEAEx+amVeTxAiBXxGiZJ5ZDM4n4O36nNiVn5LtJMjiUWFrKQGo+n+N38gCi2aQHtOA==", "user1" },
                    { 2, "AQAAAAEAACcQAAAAEEzSoGYvGacwFTZR/0SBeywqS2nNGR+8xYz6c6ZJqCBPovbP4xZGjqR3sDEY03gfJg==", "editor1" },
                    { 3, "AQAAAAEAACcQAAAAEN4TecSukvlWV28yUqHPnjmKZg3/J/3fIy8T2ip/Ej9O2+iPR5i7ZlxP+HfvzgV0Fw==", "editor2" },
                    { 5, "AQAAAAEAACcQAAAAEJLNmcGjd5N1fjK+EopJxxu74wSsP+41RYKYx9k7dKTfdVVOgrIyIOkimgcbrxZSmw==", "user2" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 2, 4 },
                    { 3, 2 },
                    { 3, 3 },
                    { 2, 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
