using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITProjectTryThree.Data.Migrations
{
    /// <inheritdoc />
    public partial class role : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "007",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2a045e5a-fe1a-4a25-a8be-c9454cd16f71", "2ea888ff-7979-42fa-8178-b577039d2372" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "007",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6deb29a7-04bb-48ab-b92d-bbf3cbd41fdb", "e39bb6fb-28ca-4253-b70d-8af6a32d15f9" });
        }
    }
}
