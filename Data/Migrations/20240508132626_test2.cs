using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITProjectTryThree.Data.Migrations
{
    /// <inheritdoc />
    public partial class test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Collection",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntName1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntName2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntName3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StringName1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StringName2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StringName3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoolName1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoolName2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoolName3 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collection", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "007", 0, "1c3901c0-211d-40b5-b0ac-b03a343f2c4c", "zampo1it17@gmail.com", false, false, null, null, null, null, null, false, "56cca470-6929-4c31-a428-2d9c7b4f0c4b", false, "constantine" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Collection");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "007");
        }
    }
}
