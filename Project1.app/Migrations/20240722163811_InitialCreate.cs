using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project1.app.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AAPL = table.Column<double>(type: "float", nullable: false),
                    MSFT = table.Column<double>(type: "float", nullable: false),
                    NVDA = table.Column<double>(type: "float", nullable: false),
                    GOOG = table.Column<double>(type: "float", nullable: false),
                    AMZN = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountID);
                });

            migrationBuilder.CreateTable(
                name: "Passwords",
                columns: table => new
                {
                    PasswordID = table.Column<int>(type: "int", nullable: false),
                    Hash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salt = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passwords", x => x.PasswordID);
                    table.ForeignKey(
                        name: "FK_Passwords_Accounts_PasswordID",
                        column: x => x.PasswordID,
                        principalTable: "Accounts",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountID", "AAPL", "AMZN", "GOOG", "MSFT", "NVDA", "Username" },
                values: new object[,]
                {
                    { -2, 0.0, 0.0, 0.0, 0.0, 0.0, "test2" },
                    { -1, 0.0, 0.0, 0.0, 0.0, 0.0, "test1" }
                });

            migrationBuilder.InsertData(
                table: "Passwords",
                columns: new[] { "PasswordID", "Hash", "Salt" },
                values: new object[] { -1, "DCB5FBF28CE2CE2F23E802CF41637698F74F3B15E1A065051138770FE3F6CA72B58A4993C524D73646B3EDF7C912F7B5D386367405BA063DF57B2F576ACD720B", new byte[] { 209, 152, 237, 24, 58, 178, 81, 102, 66, 186, 188, 23, 114, 38, 87, 198, 25, 22, 232, 204, 79, 82, 213, 224, 127, 190, 93, 197, 50, 74, 41, 34, 169, 141, 162, 110, 71, 114, 61, 193, 15, 69, 217, 142, 136, 229, 143, 95, 51, 253, 255, 89, 106, 106, 43, 178, 112, 109, 183, 12, 128, 144, 195, 249 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Passwords");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
