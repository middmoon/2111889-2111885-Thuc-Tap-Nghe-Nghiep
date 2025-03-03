using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Migrations
{
    public partial class UpdateBlogForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
