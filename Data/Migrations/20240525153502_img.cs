using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITProjectTryThree.Data.Migrations
{
    /// <inheritdoc />
    public partial class img : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imageRealPath",
                table: "DetailsItemViewModel");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "DetailsItemViewModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImagePathString",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "007",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "08219287-7ae0-4dcd-9ac8-54edafe093cf", "b5f1427f-ff24-4c4f-a375-61ca1c6d9f1e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "DetailsItemViewModel");

            migrationBuilder.DropColumn(
                name: "ImagePathString",
                table: "Collections");

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
    }
}
