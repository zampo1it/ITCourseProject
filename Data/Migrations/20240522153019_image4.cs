using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITProjectTryThree.Data.Migrations
{
    /// <inheritdoc />
    public partial class image4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "EditItemViewModel");

            migrationBuilder.AddColumn<string>(
                name: "ImagePathString",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "imageRealPath",
                table: "DetailsItemViewModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "007",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c4e41da9-8118-4ee2-8e1a-0e0047637ca5", "431cb1a1-e27e-4c29-8f6d-1dea0db7ddd1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePathString",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "imageRealPath",
                table: "DetailsItemViewModel");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "EditItemViewModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "007",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c3a26b97-2dca-43cf-9e9e-6d1dee1fed16", "6c601cdd-77bf-409f-a89f-ed5a2a847c15" });
        }
    }
}
