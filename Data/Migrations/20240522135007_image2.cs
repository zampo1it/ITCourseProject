using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITProjectTryThree.Data.Migrations
{
    /// <inheritdoc />
    public partial class image2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "007",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "33202a7f-cffe-41c2-a54d-683cb1e528f9", "278efb99-f261-430d-80e9-d2d59179839f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Collections");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "007",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "09679d9a-8ccf-4d4e-823e-5fde2184fa71", "d5031555-a618-4334-8c3b-61392758bfdc" });
        }
    }
}
