using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Migrations
{
    public partial class AddIsApproveBlogUserLikeBlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Blog",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "UserLikeBlog",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BlogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLikeBlog", x => new { x.UserId, x.BlogId });
                    table.ForeignKey(
                        name: "FK_UserLikeBlog_Blog_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLikeBlog_Users_UserId",
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

            migrationBuilder.CreateIndex(
                name: "IX_UserLikeBlog_BlogId",
                table: "UserLikeBlog",
                column: "BlogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLikeBlog");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Blog");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEHcPq0ALRDPptcuUmNAJU5YlEsP9m1MakkMy1dradDVCuRETs6EyJkLaluRUjZxoZA==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEIxVENNkVt4FmQsAlQrJ0Uno0rJIJFmcEE/llulPdqd6/mFR4KDEoqkMWo81fAyO9A==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAELbvIHsDeUIC3ZevEhB5DyzWI3dJovg/WawkwZYtd/KDQBzl/x6VF9gE3Augn0ie5Q==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEHk7cSLpZoorbetZe6AkQnsLeY1jeV2be39nuME3/L0f+rgzpn7Rq1lMwd/v1kfBrA==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEBUwSmVtMz53W5jpVlTH33xHWMB4WnhnkyNX94xNSuSSlmuSEJFDuvrGWS6uTukodw==");
        }
    }
}
