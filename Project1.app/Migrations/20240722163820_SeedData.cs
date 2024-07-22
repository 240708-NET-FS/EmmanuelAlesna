using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project1.app.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Passwords",
                keyColumn: "PasswordID",
                keyValue: -1,
                columns: new[] { "Hash", "Salt" },
                values: new object[] { "0CA637A1EC5BCC84A58FA334202DD0EE9540CDCDF171E7B9CDCE4F6F2DB4D01DC403B632894C186516BEB8DB1992B49954FE58A6ACA20C788FCCE0D3E706C7F6", new byte[] { 59, 49, 192, 206, 162, 145, 166, 92, 108, 25, 216, 255, 7, 24, 243, 113, 124, 85, 196, 152, 67, 71, 62, 154, 47, 18, 206, 174, 187, 17, 197, 168, 245, 59, 165, 26, 253, 149, 224, 8, 226, 29, 136, 203, 22, 105, 176, 123, 211, 215, 196, 193, 115, 155, 80, 188, 17, 46, 58, 33, 82, 77, 41, 41 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Passwords",
                keyColumn: "PasswordID",
                keyValue: -1,
                columns: new[] { "Hash", "Salt" },
                values: new object[] { "DCB5FBF28CE2CE2F23E802CF41637698F74F3B15E1A065051138770FE3F6CA72B58A4993C524D73646B3EDF7C912F7B5D386367405BA063DF57B2F576ACD720B", new byte[] { 209, 152, 237, 24, 58, 178, 81, 102, 66, 186, 188, 23, 114, 38, 87, 198, 25, 22, 232, 204, 79, 82, 213, 224, 127, 190, 93, 197, 50, 74, 41, 34, 169, 141, 162, 110, 71, 114, 61, 193, 15, 69, 217, 142, 136, 229, 143, 95, 51, 253, 255, 89, 106, 106, 43, 178, 112, 109, 183, 12, 128, 144, 195, 249 } });
        }
    }
}
