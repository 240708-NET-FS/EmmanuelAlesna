using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project1.app.Migrations
{
    /// <inheritdoc />
    public partial class Update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Passwords",
                keyColumn: "PasswordID",
                keyValue: -2,
                columns: new[] { "Hash", "Salt" },
                values: new object[] { "5D553F36FF17B4556D485940D5E5F5CD866319AD432A7548D8609B7B7F32953AD76D26432A6870B8E33240DF6E5923E3339B01B255269108B3A33860E853F07C", new byte[] { 39, 123, 245, 70, 104, 222, 186, 142, 191, 124, 251, 31, 143, 166, 18, 20, 162, 194, 136, 180, 39, 46, 253, 229, 225, 190, 85, 129, 114, 136, 220, 205, 56, 80, 226, 130, 0, 217, 229, 103, 57, 10, 182, 121, 101, 57, 17, 43, 140, 23, 205, 93, 65, 58, 251, 154, 241, 79, 123, 213, 7, 131, 222, 202 } });

            migrationBuilder.UpdateData(
                table: "Passwords",
                keyColumn: "PasswordID",
                keyValue: -1,
                columns: new[] { "Hash", "Salt" },
                values: new object[] { "5375D5C8A0B679DE9178212FA9A54E7FE564E3EEC479B9E61149E29487FC8F2D8D97224C7F8A3E7DF8997E9D1AA4D788C34CFD7937C401B8FCEB4BA91DB8A175", new byte[] { 204, 105, 7, 67, 49, 248, 78, 236, 103, 220, 5, 189, 206, 244, 213, 131, 124, 170, 144, 215, 200, 73, 55, 206, 192, 160, 33, 88, 181, 88, 245, 66, 122, 171, 213, 219, 253, 230, 216, 71, 37, 204, 5, 232, 30, 110, 244, 236, 169, 239, 159, 159, 55, 95, 221, 94, 71, 107, 94, 158, 160, 229, 52, 189 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Passwords",
                keyColumn: "PasswordID",
                keyValue: -2,
                columns: new[] { "Hash", "Salt" },
                values: new object[] { "F395A11C4251F2D3DCA45006B561A40F0EB267F387D8599F204A7A06026FE779A6876636136C7B15D6FEC5303BAD776BE139E2317B07B2F3DAFED54FA9C13710", new byte[] { 72, 255, 141, 143, 195, 184, 64, 121, 219, 96, 241, 24, 147, 149, 75, 122, 49, 40, 172, 48, 45, 27, 233, 31, 93, 196, 89, 154, 238, 11, 119, 95, 37, 251, 134, 165, 210, 96, 130, 29, 212, 214, 251, 15, 170, 225, 254, 137, 95, 151, 201, 96, 23, 225, 190, 51, 220, 148, 252, 202, 90, 117, 250, 147 } });

            migrationBuilder.UpdateData(
                table: "Passwords",
                keyColumn: "PasswordID",
                keyValue: -1,
                columns: new[] { "Hash", "Salt" },
                values: new object[] { "D774572E64B789873592A8E96315D0B40CCC5AB9E2BA2D5FB8558611E69FC32202837373365243FD6CACEA738099BED5573552B32F89216EACB032C145A25C19", new byte[] { 208, 77, 222, 183, 30, 233, 129, 17, 101, 25, 172, 72, 145, 113, 151, 32, 201, 208, 184, 137, 198, 21, 34, 113, 197, 237, 177, 101, 8, 35, 51, 177, 157, 200, 120, 124, 65, 93, 18, 219, 200, 132, 33, 78, 128, 245, 205, 212, 125, 177, 127, 76, 24, 34, 207, 182, 8, 66, 102, 92, 24, 245, 179, 15 } });
        }
    }
}
