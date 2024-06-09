using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITProjectTryThree.Data.Migrations
{
    /// <inheritdoc />
    public partial class Test42 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Collection",
                table: "Collection");

            migrationBuilder.RenameTable(
                name: "Collection",
                newName: "Collections");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Collections",
                table: "Collections",
                column: "id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "007",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "85754b71-0be4-4dfe-b5d0-bf3c5c3893c6", "289fbe70-62a8-4454-af69-d277154d42ee" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Collections",
                table: "Collections");

            migrationBuilder.RenameTable(
                name: "Collections",
                newName: "Collection");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Collection",
                table: "Collection",
                column: "id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "007",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1c3901c0-211d-40b5-b0ac-b03a343f2c4c", "56cca470-6929-4c31-a428-2d9c7b4f0c4b" });
        }
    }
}
