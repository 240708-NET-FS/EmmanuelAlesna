using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project1.app.Migrations
{
    /// <inheritdoc />
    public partial class seeddata2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Passwords",
                keyColumn: "PasswordID",
                keyValue: -1,
                columns: new[] { "Hash", "Salt" },
                values: new object[] { "D774572E64B789873592A8E96315D0B40CCC5AB9E2BA2D5FB8558611E69FC32202837373365243FD6CACEA738099BED5573552B32F89216EACB032C145A25C19", new byte[] { 208, 77, 222, 183, 30, 233, 129, 17, 101, 25, 172, 72, 145, 113, 151, 32, 201, 208, 184, 137, 198, 21, 34, 113, 197, 237, 177, 101, 8, 35, 51, 177, 157, 200, 120, 124, 65, 93, 18, 219, 200, 132, 33, 78, 128, 245, 205, 212, 125, 177, 127, 76, 24, 34, 207, 182, 8, 66, 102, 92, 24, 245, 179, 15 } });

            migrationBuilder.InsertData(
                table: "Passwords",
                columns: new[] { "PasswordID", "Hash", "Salt" },
                values: new object[] { -2, "F395A11C4251F2D3DCA45006B561A40F0EB267F387D8599F204A7A06026FE779A6876636136C7B15D6FEC5303BAD776BE139E2317B07B2F3DAFED54FA9C13710", new byte[] { 72, 255, 141, 143, 195, 184, 64, 121, 219, 96, 241, 24, 147, 149, 75, 122, 49, 40, 172, 48, 45, 27, 233, 31, 93, 196, 89, 154, 238, 11, 119, 95, 37, 251, 134, 165, 210, 96, 130, 29, 212, 214, 251, 15, 170, 225, 254, 137, 95, 151, 201, 96, 23, 225, 190, 51, 220, 148, 252, 202, 90, 117, 250, 147 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Passwords",
                keyColumn: "PasswordID",
                keyValue: -2);

            migrationBuilder.UpdateData(
                table: "Passwords",
                keyColumn: "PasswordID",
                keyValue: -1,
                columns: new[] { "Hash", "Salt" },
                values: new object[] { "0CA637A1EC5BCC84A58FA334202DD0EE9540CDCDF171E7B9CDCE4F6F2DB4D01DC403B632894C186516BEB8DB1992B49954FE58A6ACA20C788FCCE0D3E706C7F6", new byte[] { 59, 49, 192, 206, 162, 145, 166, 92, 108, 25, 216, 255, 7, 24, 243, 113, 124, 85, 196, 152, 67, 71, 62, 154, 47, 18, 206, 174, 187, 17, 197, 168, 245, 59, 165, 26, 253, 149, 224, 8, 226, 29, 136, 203, 22, 105, 176, 123, 211, 215, 196, 193, 115, 155, 80, 188, 17, 46, 58, 33, 82, 77, 41, 41 } });
        }
    }
}
